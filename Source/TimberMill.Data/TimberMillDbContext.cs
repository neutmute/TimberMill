using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NLog;
using TimberMill.Domain.Objects;

namespace TimberMill.Data
{
    public class TimberMillDbContext : DbContext
    {
        #region Fields

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        public DbSet<Source> Sources { get; set; }

        public DbSet<LogEvent> LogEvents { get; set; }

        public DbSet<Batch> Batchs { get; set; }

        #endregion

        #region Ctor

        static TimberMillDbContext()
        {
            var initialiser = new DropCreateDatabaseIfModelChanges<TimberMillDbContext>();
            Database.SetInitializer(initialiser);
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        #endregion
    }
}
