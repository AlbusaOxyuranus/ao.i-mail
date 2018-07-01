using System;
using ao.i_mail.service.data.bal;
using ao.i_mail.service.data.models;
using ao.i_mail.service.i_AccountService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ao.i_mail.service.data.tests
{
    [TestClass]
    public class BusinessContextTests
    {
        [TestMethod]
        public void User_InsertEntity_Test()
        {
            using (var bc = new BusinessContext(new TestMode()))
            {
                var client = new AccountServiceClient();
                var resultUser= client.CreateUser(new User() { Username = "dionis_999", Password = "999" });
                var config = bc.Add(new Config(){Key = "key",Value = "value",UserId = resultUser.Id});
                Assert.IsNotNull(config);
                Assert.IsTrue(config.Id > 0);
            }
        }

        [TestMethod]
        public void User_GetEntity_Test()
        {
            using (var bc = new BusinessContext(new TestMode()))
            {
                var client = new AccountServiceClient();
                var resultUser = client.CreateUser(new User() { Username = "dionis_999", Password = "999" });
                var config = bc.Add(new Config() { Key = "key", Value = "value", UserId = resultUser.Id });
                var result = bc.Get<Config, int>(config.Id);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Id > 0);
            }
        }
    }
}
