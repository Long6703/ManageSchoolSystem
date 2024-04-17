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
    public class Timetable
    {
        [DataMember(Order = 1)]
        public virtual int TimetableId { get; set; }
        [DataMember(Order = 2)]
        public virtual Classs Class { get; set; }
        [DataMember(Order = 3)]
        public virtual int? Slot { get; set; }
        [DataMember(Order = 4)]
        public virtual int? DayOfWeek { get; set; }
        [DataMember(Order = 5)]
        public virtual Courses Course { get; set; }
        [DataMember(Order = 6)]
        public virtual User User { get; set; }
        [DataMember(Order = 7)]
        public virtual string Room { get; set; }
        [DataMember(Order = 8)]
        public virtual DateTime CreatedAt { get; set; }
        [DataMember(Order = 9)]
        public virtual string CreatedBy { get; set; }
        [DataMember(Order = 10)]
        public virtual Semester Semester { get; set; }
    }
}
