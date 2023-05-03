using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Assignment3
{
    public class NonSecuredUser
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public string IdentityNumber { get; set; } = null!;
        public string UserName { get; set; } = null!;
       public string Password { get; set; } = null!;    
    }
}
