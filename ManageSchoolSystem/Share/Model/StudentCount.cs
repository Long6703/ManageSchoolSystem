using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    [DataContract]
    public class StudentCount
    {
        [DataMember(Order = 1)]
        public string? ClassName { get; set; }

        [DataMember(Order = 2)]
        public int Count { get; set; }
    }
}
