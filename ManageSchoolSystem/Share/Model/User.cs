using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Share.Model
{
    [DataContract]
    public class User
    {
        [DataMember(Order = 1)]
        public virtual int UserID { get; set; }

        [DataMember(Order = 2)]
        public virtual string DisplayName { get; set; }

        [DataMember(Order = 3)]
        public virtual string PhoneNumber { get; set; }

        [DataMember(Order = 4)]
        public virtual string Email { get; set; }

        [DataMember(Order = 5)]
        public virtual Classs Class { get; set; }

        [DataMember(Order = 6)]
        public virtual bool IsActive { get; set; } = true;

        [DataMember(Order = 7)]
        public virtual string Role { get; set; }
    }
}
