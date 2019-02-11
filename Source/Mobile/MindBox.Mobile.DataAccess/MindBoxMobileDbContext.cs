using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace MindBox.Mobile.DataAccess
{
	/// <summary>
	/// The database context to use as database in mobile application
	/// </summary>
    public class MindBoxMobileDbContext : DbContext
    {
        #region Public Properties

        /// <summary>
        /// The database table for settings
        /// </summary>
        public DbSet<Setting> Settings { get; set; }

        #endregion

        /// <summary>
        /// Automatically called while configuring the database, helps us provide database's file path
        /// </summary>
        /// <param name="optionsBuilder">The builder that accepts additional options to configure</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Do base things
            base.OnConfiguring(optionsBuilder);

            // Use SQLite package with database's file path
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mindboxDB.sqlite");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}
