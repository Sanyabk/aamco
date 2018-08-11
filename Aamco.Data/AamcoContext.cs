using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Aamco.Data
{
    public class AamcoContext : DbContext
    {
        public AamcoContext(string connString) : base(connString)
        {
        }

        public AamcoContext() : this("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF6Usage;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
