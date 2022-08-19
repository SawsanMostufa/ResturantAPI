using Resturant.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Resturant.Helpers
{
    public class TwilioSettings
    {
        public string AccountSID { get; set; }
        public string AuthToken { get; set; }
        public string TwilioPhoneNumber { get; set; }

        
    }
}
