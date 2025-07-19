using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface IBMIService
    {
        Task<BMIDto> GetBMIbyUserName(string userName);
    }
}
