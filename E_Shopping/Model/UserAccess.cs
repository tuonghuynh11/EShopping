using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopping.Model
{
    public class UserAccess
    {
        public static string UserType(string username)
        {
            var person = DataProvider.ins.db.PEOPLE.Where(p => p.userName == username).SingleOrDefault();
            var role = DataProvider.ins.db.Roles.Where(r => r.id == person.idRole).SingleOrDefault();
            return role.roleName;
        }
    }
}
