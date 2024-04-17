using FluentNHibernate.Mapping;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mappings
{
    public class GradeMap : ClassMap<Grade>
    {
        public GradeMap()
        {
            Table("Grades");
            Id(x => x.GradeId).GeneratedBy.Identity();
            References(x => x.User).Column("Username");
            References(x => x.Course).Column("CourseID");
            References(x => x.Class).Column("class_id");
            Map(x => x.GradeValue).Column("Grade");
            Map(x => x.CreatedAt).Column("CreatedAt");
        }
    }
}
