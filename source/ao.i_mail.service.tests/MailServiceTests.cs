﻿using ao.i_mail.service.tests.i_MailService;
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
            var user = new User {Username = "MailServiceTests", Password = "password"};
            var resultUser = client.CreateUser(user);
            
        }
    }
}