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
        public LicenseInformation(string title, string license, bool isTrial)
        {
            Title = title;
            License = license;
            IsTrial = isTrial;            
        }
    }
}
