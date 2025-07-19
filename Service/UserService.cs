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
    public class UserService : IUserService
    {
        public int DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetUser(string username)
        {
            UserDTO userDTO = null;
            using(var db=new bayer_Entities())
            {
                var userData= await db.tblUsers.FirstOrDefaultAsync(x=>x.Equals(username));
                if (userData != null)
                {
                    userDTO = new UserDTO()
                    {
                        UserID = userData.UserID,
                        UserName = userData.UserName,
                        Age = userData.Age,
                        Height = userData.Height,
                        Weight = userData.Weight,
                    };
                }
            }
            return userDTO;
        }

        public int InsertUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public int UpdateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
