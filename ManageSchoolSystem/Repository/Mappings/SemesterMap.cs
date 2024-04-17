using FluentNHibernate.Mapping;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mappings
{
    public class SemesterMap : ClassMap<Semester>
    {
       public SemesterMap()
        {
            Table("Semesters");
            Id(x => x.SemesterId).GeneratedBy.Identity().Column("SemesterID");
            Map(x => x.SemesterName).Column("SemesterName");
            Map(x => x.StartDate).Column("StartDate");
            Map(x => x.EndDate).Column("EndDate");
        }
    }
}
