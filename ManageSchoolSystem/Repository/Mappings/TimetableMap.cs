using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share.Model;

namespace Repository.Mappings
{
    public class TimetableMap : ClassMap<Timetable>
    {
        public TimetableMap()
        {
            Table("Timetable");
            Id(x => x.TimetableId).GeneratedBy.Identity();
            References(x => x.Class).Column("class_id");
            Map(x => x.Slot).Column("Slot");
            Map(x => x.DayOfWeek).Column("DayOfWeek");
            References(x => x.Course).Column("CourseID");
            References(x => x.User).Column("userid");
            Map(x => x.Room).Column("Room");
            Map(x => x.CreatedAt).Column("CreatedAt");
            Map(x => x.CreatedBy).Column("CreatedBy");
            References(x => x.Semester).Column("SemesterID");
        }
    }
}
