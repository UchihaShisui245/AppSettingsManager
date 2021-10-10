using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSettingsManager.Models
{
    public class SocialLoginsSettings
    {
        public bool IsSocialLoginsEnabled { get; set; }

        public KeyValuePair FaceBookLoginSettings { get; set; }

        public KeyValuePair GoogleLoginSettings { get; set; }
    }

    public class KeyValuePair
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
