using System.Data.Entity.Infrastructure;

namespace Aamco.Data
{
    public class AamcoContextFactory : IDbContextFactory<AamcoContext>
    {
        private readonly string _connectionString;

        public AamcoContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AamcoContext Create()
        {
            return new AamcoContext(_connectionString);
        }
    }
}
