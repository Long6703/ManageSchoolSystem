using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    [DataContract]
    public class Courses
    {
        [DataMember(Order = 1)]
        public virtual int CourseId { get; set; }
        [DataMember(Order = 2)]
        public virtual string CourseName { get; set; }
        [DataMember(Order = 3)]
        public virtual IList<User> Teachers { get; set; }
        public virtual IList<Classs> Classes { get; set; }
    }
}
