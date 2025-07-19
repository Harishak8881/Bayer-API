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
        Task<int> InsertUser(UserDTO userDTO);
        Task<int> UpdateUser(UserDTO userDTO);
        Task<int> DeleteUser(int id);

    }
}
