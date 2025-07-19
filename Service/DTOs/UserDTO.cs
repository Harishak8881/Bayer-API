using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int? Age {  get; set; }
        public decimal? Height {  get; set; }
        public decimal? Weight { get; set; }

    }
}
