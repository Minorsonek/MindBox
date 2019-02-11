using System.Collections.Generic;
using MindBox.Core;

namespace MindBox.Mobile.DataAccess
{
    /// <summary>
    /// The repository for application's settings
    /// </summary>
    public interface ISettingsRepository : IRepository<Setting, int>
    {
        List<SettingPropertyInfo> GetAllSettings();

        void SaveSetting(SettingPropertyInfo setting);
    }
}
