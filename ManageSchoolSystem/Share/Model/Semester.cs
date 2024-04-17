using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    [DataContract]
    public class Semester
    {
        [DataMember(Order = 1)]
        public virtual int SemesterId { get; set; }
        [DataMember(Order = 2)]
        public virtual string SemesterName { get; set; }
        [DataMember(Order = 3)]
        public virtual DateTime StartDate { get; set; }
        [DataMember(Order = 4)]
        public virtual DateTime EndDate { get; set; }
    }
}
