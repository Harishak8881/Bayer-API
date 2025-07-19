using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs;
using Service.Interfaces;

namespace Service
{
    public class BMIService : IBMIService
    {
        public async Task<BMIDto> GetBMIbyUserName(string username)
        {
            using (var db = new bayer_Entities())
            {
                var userData = await db.tblUsers.FirstOrDefaultAsync(x => x.Equals(username));
                if (userData != null)
                {
                    decimal bmi = 0;
                    if (userData.Weight.HasValue && userData.Weight.Value > 0)
                    {
                        decimal weight = userData.Weight.Value;
                        bmi = weight / (userData.Height * userData.Height);
                    }
                }
            }
        }
    }
}
