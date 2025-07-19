using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(string username);
        int InsertUser(UserDTO userDTO);
        int UpdateUser(UserDTO userDTO);
        int DeleteUser(int id);

    }
}
