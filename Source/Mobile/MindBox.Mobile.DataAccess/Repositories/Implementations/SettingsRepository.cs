using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MindBox.Core;

namespace MindBox.Mobile.DataAccess
{
    /// <summary>
    /// The repository for application's settings
    /// </summary>
    public class SettingsRepository : BaseRepository<Setting, int>, ISettingsRepository
    {
        #region Protected Properties

        /// <summary>
        /// The settings table that's used in this repository
        /// </summary>
        protected override DbSet<Setting> DbSet => Db.Settings;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsRepository(MindBoxMobileDbContext dbContext) : base(dbContext)
        {

        }

        #endregion

        #region Interface Implementation

        /// <summary>
        /// Gets every stored setting in the database
        /// </summary>
        /// <returns>List of settings</returns>
        public List<SettingPropertyInfo> GetAllSettings()
        {
            // Prepare list of settings to return
            var settingsInfos = new List<SettingPropertyInfo>();

            // Get every setting entity that is currently saved in database
            var entities = GetAll().ToList();

            // For each one...
            foreach (var entity in entities)
            {
                // Create new setting info
                var setting = new SettingPropertyInfo
                {
                    Name = entity.Name,
                    Type = Type.GetType(entity.Type),
                    Value = entity.Value
                };

                // Add it to the list
                settingsInfos.Add(setting);
            }

            // Return the result list
            return settingsInfos;
        }

        /// <summary>
        /// Saves specified setting into database
        /// </summary>
        /// <param name="setting">The setting to save</param>
        public void SaveSetting(SettingPropertyInfo setting)
        {
            // Find specified setting in the database
            var entity = DbSet.Where(x => x.Name == setting.Name).FirstOrDefault();

            // If none was found...
            if (entity == null)
            {
                // Create new one
                entity = new Setting
                {
                    Name = setting.Name,
                    Type = setting.Type.ToString()
                };

                // Add it to the database
                DbSet.Add(entity);
            }

            // Change its value
            entity.Value = setting.Value.ToString();

            // Save changes we made
            SaveChanges();
        }

        #endregion
    }
}
