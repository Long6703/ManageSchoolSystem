using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    [DataContract]
    public class Grade
    {
        [DataMember(Order = 1)]
        public virtual int GradeId { get; set; }
        [DataMember(Order = 2)]
        public virtual User User { get; set; }
        [DataMember(Order = 3)]
        public virtual Courses Course { get; set; }
        [DataMember(Order = 4)]
        public virtual Classs Class { get; set; }
        [DataMember(Order = 5)]
        public virtual float? GradeValue { get; set; }
        [DataMember(Order = 6)]
        public virtual DateTime CreatedAt { get; set; }
    }
}
