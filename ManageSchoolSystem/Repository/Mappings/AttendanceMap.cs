using FluentNHibernate.Mapping;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mappings
{
    public class AttendanceMap : ClassMap<Attendance>
    {
        public AttendanceMap()
        {
            Table("Attendance");
            Id(x => x.AttendanceId).GeneratedBy.Identity();
            References(x => x.Timetable).Column("TimetableID");
            References(x => x.User).Column("userid");
            Map(x => x.AttendanceStatus).Column("AttendanceStatus"); ;
            Map(x => x.Date).Column("Date");
        }
    }
}
