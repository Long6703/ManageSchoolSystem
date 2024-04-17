using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.ViewModel
{
    [DataContract]
    public class UserViewModel
    {
        [DataMember(Order = 1)]
        public int UserID { get; set; }

        [DataMember(Order = 2)]
        public string DisplayName { get; set; }

        [DataMember(Order = 3)]
        public string Email { get; set; }

        [DataMember(Order = 4)]
        public string PhoneNumber { get; set; }

        [DataMember(Order = 5)]
        public string ClassName { get; set; }
    }
}
