using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.EditModel
{
    [DataContract]
    public class UserEditModel
    {
        [DataMember(Order = 1)]
        public string DisplayName { get; set; }

        [DataMember(Order = 2)]
        public string Email { get; set; }

        [DataMember(Order = 3)]
        public string ClassName { get; set; }

        [DataMember(Order = 4)]
        public string PhoneNumber { get; set; }

        [DataMember(Order = 5)]
        public bool IsActive { get; set; } = true;
    }
}
