using System;
using System.ServiceModel;
using ao.i_mail.service.data.bal;
using ao.i_mail.service.data.models;
using ao.i_mail.service.i_AccountService;

namespace ao.i_mail.service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MailService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MailService.svc or MailService.svc.cs at the Solution Explorer and start debugging.
    public class MailService : IMailService
    {
        public void Authentication(User user)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user)
        {
            var client = new AccountServiceClient();
            return client.CreateUser(user);
        }

        public User GetUser(int id)
        {
            var client = new AccountServiceClient();
            return client.GetUser(id);
        }

        public Config GetConfig(Config config)
        {
            throw new NotImplementedException();
        }

        public Config CreateConfig(User user, Config config)
        {
           using (var bc = new BusinessContext(new AppMode()))
           {
               config.UserId = user.Id;
                return bc.Add(config);
            }
        }
    }
}