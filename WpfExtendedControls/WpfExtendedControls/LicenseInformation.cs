using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfExtendedControls.Properties;

namespace WpfExtendedControls
{
    public class LicenseInformation
    {
        public string Title { get; }
        public string License { get; }
        public bool IsTrial { get; }
        /// <summary>
        /// Create new object of license information
        /// </summary>
        /// <param name="title">License title</param>
        /// <param name="license">License text</param>
        /// <param name="isTrial">Trial flag, if license used in trial or it used in restricted mode
        /// (for example: community licenses used in enterprise app and include restriction of this usage)</param>
        public LicenseInformation(string title, string license, bool isTrial)
        {
            Title = title;
            License = license;
            IsTrial = isTrial;            
        }
    }
}
