using Assignment3;
using Entity.Assignment3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Assignment3
{
    public interface IUserDal
    {
        User GetUserByIdentity(string identity);
        User Insert(User user);

        User Get(Func<User, bool>? filter = null);


       NonSecuredUser GetNonSecuredUserByIdentity(string identity);
        NonSecuredUser InsertNonSecuredUser(NonSecuredUser user);

        NonSecuredUser GetNonSecuredUser(Func<NonSecuredUser, bool>? filter = null);
    }
}
