
using ao.i_mail.service.data.models;
using ao.i_mail.service.tests.i_MailService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ao.i_mail.service.tests
{
    [TestClass]
    public class MailServiceTests
    {
        [TestMethod]
        public void CreateUser_Test()
        {
            var client = new MailServiceClient();
            var user = new User() {Username = "MailServiceTests",Password = "000"};
            var resultUser = client.CreateUser(user);
            Assert.IsNotNull(resultUser);
        }

        [TestMethod]
        public void GetUser_Test()
        {
            var client = new MailServiceClient();
            var user = new User() { Username = "MailServiceTests", Password = "001" };
            var resultUser = client.CreateUser(user);
            var getUser = client.GetUser(resultUser.Id);
            Assert.IsNotNull(getUser);
        }

        [TestMethod]
        public void CreateConfig_Test()
        {
            var client = new MailServiceClient();
            var user = new User() { Username = "MailServiceTests", Password = "001" };
            var resultUser = client.CreateUser(user);
            var getUser = client.GetUser(resultUser.Id);

            var config = new Config() { Key = "Key Tests", Value= "myconfig" };
            var resultConfig = client.CreateConfig(getUser,config);
            Assert.IsNotNull(resultConfig);
        }

    }
}
