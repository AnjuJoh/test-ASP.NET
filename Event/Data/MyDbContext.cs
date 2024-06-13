using Event.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Event.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

     
        public DbSet<Register> Registration { get; set; }

        internal int SaveData(string sql, Register data)
        {
            throw new NotImplementedException();
        }
    }
}
