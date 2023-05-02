using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Assignment3
{
    public class ResponseDto
    {
        public bool HasError { get; set; }
        public string Message { get; set; } = null!;
        public string Token { get; set; } = null!;

        public string userName { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!;
    }
}
