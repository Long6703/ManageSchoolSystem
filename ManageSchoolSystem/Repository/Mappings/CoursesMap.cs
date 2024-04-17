using FluentNHibernate.Mapping;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mappings
{
    public class CoursesMap : ClassMap<Courses>
    {
        public CoursesMap()
        {
            Table("Courses");
            Id(x => x.CourseId).Column("CourseID").GeneratedBy.Identity();
            Map(x => x.CourseName).Column("CourseName");
            HasManyToMany(x => x.Teachers)
                .Table("TeacherCourses")
                .ParentKeyColumn("CourseID")
                .ChildKeyColumn("userid")
                .Cascade.All();
            HasManyToMany(x => x.Classes)
            .Table("ClassCourses")
            .ParentKeyColumn("course_id") // Foreign key column in the join table that references Courses
            .ChildKeyColumn("class_id") // Foreign key column in the join table that references Class
            .Cascade.All();
        }
    }
}
