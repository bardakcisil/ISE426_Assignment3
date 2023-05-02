using Assignment3;
using DataAccess.Assignment3.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Assignment3
{
    public class EfUser : IUserDal
    {
        public User Get(Func<User, bool>? filter = null)
        {
            using (DatabaseConnection context = new DatabaseConnection())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
        }

        public User GetUserByIdentity(string identity)
        {
            using var context = new DatabaseConnection();
            var user = context.Users.SingleOrDefault(x => x.IdentityNumber == identity);
            return user;
        }

        public User Insert(User user)
        {
            using var context = new DatabaseConnection();
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}
