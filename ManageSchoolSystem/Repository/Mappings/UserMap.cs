using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Share.Model;

namespace Repository.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.UserID).Column("userid");
            Map(x => x.DisplayName).Column("displayName");
            Map(x => x.PhoneNumber).Column("phone_number");
            Map(x => x.Email).Column("email");
            Map(x => x.Role).Column("role");
            References(x => x.Class).Column("class_id");
            Map(x => x.IsActive).Column("isActive");
        }
    }
}
