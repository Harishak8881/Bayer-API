using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs;
using Service.Interfaces;

namespace Service
{
    public class UserService : IUserService
    {
        public async Task<int> DeleteUser(int userId)
        {
            int recordsEffected = 0;
            using (var db = new bayer_Entities())
            {
                var deleteUser = await db.tblUsers.FirstOrDefaultAsync(x => x.UserID == userId);
                if (deleteUser != null)
                {
                    db.tblUsers.Remove(deleteUser); 

                    recordsEffected = await db.SaveChangesAsync();
                }
            }
            return recordsEffected;
        }

        public async Task<UserDTO> GetUser(string username)
        {
            UserDTO userDTO = null;
            try
            {
                string connectionString = "Server=localhost;Database=bayer-health-care-dev;Trusted_Connection=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("✅ Connection established successfully.");

                        // Example query
                        string query = "SELECT UserID,UserName,Age,Gender,Height,Weight FROM tblUser where UserName=@username";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["Username"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error: {ex.Message}");
                    }
                }


                //using (var db = new bayer_Entities())
                //{
                //    var userData = await db.tblUsers.FirstOrDefaultAsync(x => x.Equals(username));
                //    if (userData != null)
                //    {
                //        userDTO = new UserDTO()
                //        {
                //            UserID = userData.UserID,
                //            UserName = userData.UserName,
                //            Age = userData.Age,
                //            Height = userData.Height,
                //            Weight = userData.Weight,
                //        };
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
            return userDTO;
        }

        public async Task<int> InsertUser(UserDTO userDTO)
        {
            int recordsEffected = 0;
            var tblUser=new tblUser()
            {
                UserName=userDTO.UserName,
                Age=userDTO.Age,
                Height=userDTO.Height,
                Weight=userDTO.Weight,
                CreatedOn=DateTime.Now,
            };
            using (var db = new bayer_Entities())
            {
                db.tblUsers.Add(tblUser);
                recordsEffected=await db.SaveChangesAsync();
            }
            return recordsEffected;
        }

        public async Task<int> UpdateUser(UserDTO userDTO)
        {
            int recordsEffected = 0;
            using (var db = new bayer_Entities())
            {
              var updateUser=await db.tblUsers.FirstOrDefaultAsync(x=>x.UserID==userDTO.UserID);
                if(updateUser!=null)
                {
                    updateUser.UserName = userDTO.UserName;
                    updateUser.Age = userDTO.Age;
                    updateUser.Height = userDTO.Height;
                    updateUser.Weight = userDTO.Weight;
                    updateUser.ModifiedOn=DateTime.Now;

                    recordsEffected = await db.SaveChangesAsync();
                }
            }
            return recordsEffected;
        }
    }
}
