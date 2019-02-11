using System;

namespace MindBox.Core
{
    /// <summary>
    /// The class that stores information about the application setting
    /// </summary>
    public class SettingPropertyInfo
    {
        #region Public Properties

        /// <summary>
        /// The name of the setting
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the setting such as bool/string/int etc.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// The actual value of the setting that can be casted to Type
        /// </summary>
        public object Value { get; set; }

        #endregion
    }
}
