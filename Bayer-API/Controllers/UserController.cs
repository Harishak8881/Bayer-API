using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.DTOs;
using Service.Interfaces;

namespace Bayer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly string connectionString = "Server=localhost;Database=bayer-health-care-dev;Trusted_Connection=True;";

        public UserController(IConfiguration configuration,IUserService userService) {         
           // _userService = userService;
            _configuration = configuration;
        }

        [HttpGet("username")]
        public IActionResult GetUserByUserName([FromQuery] string username)
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
           // var result= await _userService.GetUser(username);
           return Ok(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] UserDTO userDTO)
        {
            var result = "";// await _userService.InsertUser(userDTO);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<string>();
            string connectionString = "Server=localhost;Database=bayer-health-care-dev;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("✅ Connection established successfully.");

                    // Example query
                    string query = "SELECT UserID,UserName,Age,Gender,Height,Weight FROM tblUser";
                    SqlCommand command = new SqlCommand(query, connection);

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

            return Ok(users);
        }

    }
}
