using System.Data.Entity.Infrastructure;

namespace Aamco.Data
{
    public class AamcoDbContextFactory : IDbContextFactory<AamcoDbContext>
    {
        private readonly string _connectionString;

        public AamcoDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AamcoDbContext Create()
        {
            return new AamcoDbContext(_connectionString);
        }
    }
}
