using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using Service.Interfaces;

namespace Bayer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BMIController : ControllerBase
    {
        readonly IBMIService _bMIService;
        private readonly string connectionString = "Server=localhost;Database=bayer-health-care-dev;Trusted_Connection=True;";

        public BMIController(IBMIService bMIService)
        {
            _bMIService = bMIService;
        }

        [HttpGet("username")]
        public IActionResult GetBMIbyUsername(string username)
        {
            UserDTO userDTO = new UserDTO();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Example query
                    string query = "SELECT UserID,UserName,Age,Gender,Height,Weight FROM tblUser where UserName=@username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userDTO = new UserDTO();
                            userDTO.UserID = Convert.ToInt32(reader["UserID"]);
                            userDTO.UserName = Convert.ToString(reader["UserName"]);
                            userDTO.Age = Convert.ToInt32(reader["Age"]);
                            userDTO.Height = Convert.ToDecimal(reader["Height"]);
                            userDTO.Weight = Convert.ToInt32(reader["Weight"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                }
            }
            var bMIDto = new BMIDto();
            bMIDto.UserID = userDTO.UserID;
            bMIDto.Name = userDTO.UserName;
            if (userDTO.Weight.HasValue && userDTO.Weight.Value > 0)
            {
                decimal weight = userDTO.Weight.Value;
                bMIDto.BMI = (decimal)(weight / (userDTO.Height * userDTO.Height));
            }
            return Ok(bMIDto);
        }
    }
}
