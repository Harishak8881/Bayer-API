using Bayer_API.Controllers;
using Service.Interfaces;

namespace Bayer_API.UnitTest
{
    public class LoginTest
    {
        LoginController _loginController { get; set; }
        public LoginTest() {
            _loginController = new LoginController();
        }
        [Fact]
        public void Test1()
        {
            //Arrange

            //Act
           string token =_loginController.GenerateJwtToken("user1");

            //Assert
            Assert.NotEmpty(token);

        }
    }
}