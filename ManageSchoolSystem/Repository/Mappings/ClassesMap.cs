using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Share.Model;

namespace Repository.Mappings
{
    public class ClassesMap : ClassMap<Classs>
    {
        public ClassesMap()
        {
            Table("Class");
            Id(x => x.ClassId).Column("class_id").GeneratedBy.Identity();
            Map(x => x.ClassName).Column("class_name");
            HasManyToMany(x => x.Courses)
            .Table("ClassCourses")
            .ParentKeyColumn("class_id") // Foreign key column in the join table that references Class
            .ChildKeyColumn("course_id") // Foreign key column in the join table that references Courses
            .Cascade.All();
        }
    }
}
