using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class BMIDto
    {
        public int UserID {  get; set; }
        public string Name { get; set; }
        public decimal BMI { get; set; }
    }
}
