using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    [DataContract]
    public class Attendance
    {
        [DataMember(Order = 1)]
        public virtual int AttendanceId { get; set; }
        [DataMember(Order = 2)]
        public virtual Timetable Timetable { get; set; }
        [DataMember(Order = 3)]
        public virtual User User { get; set; }
        [DataMember(Order = 4)]
        public virtual string AttendanceStatus { get; set; }
        [DataMember(Order = 5)]
        public virtual DateTime Date { get; set; }
    }
}
