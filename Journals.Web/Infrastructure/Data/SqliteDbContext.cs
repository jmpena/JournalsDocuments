using Journals.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Journals.Web.Infrastructure.Data
{
    public class SqliteDbContext : DbContext
    {
        /// <summary>
        /// Builds a new connection string that provides for <code></code>
        /// </summary>
        /// <param name="options"></param>
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
            : base(options)
        { }
        public DbSet<JournalsDocument> JournalsDocuments { get; set; }
        public DbSet<Researcher> Researchers { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Journals.db");
            base.OnConfiguring(optionsBuilder);
        }

       
    }
}
