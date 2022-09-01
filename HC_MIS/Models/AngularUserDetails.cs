using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC_MIS.Models
{
    public class AngularUserDetails
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public List<string> UserRole { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
