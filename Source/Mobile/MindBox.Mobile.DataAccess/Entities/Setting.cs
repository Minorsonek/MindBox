namespace MindBox.Mobile.DataAccess
{
	/// <summary>
	/// The entity for application's setting that's stored in the database
	/// </summary>
    public class Setting : BaseEntity<int>
    {
        #region Public Properties

        /// <summary>
        /// The name of a property for this setting
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type that this setting can be converted for
        /// Such as string/bool/int etc.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The actual value of this setting converted to string
        /// </summary>
        public string Value { get; set; }

        #endregion
    }
}
