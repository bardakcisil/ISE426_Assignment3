
using Entity.Assignment3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Assignment3
{
    public interface IUserService
    {
        ResponseDto Login(UserForLogin userForLogin);
        bool Register(UserForRegister userForRegister);
        ResponseDto VulnerableLogin(UserForLogin userForLogin);
        bool VulnerableRegister(UserForRegister userForRegister);

    }
}
