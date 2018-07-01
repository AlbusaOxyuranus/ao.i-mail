using System;
using System.ServiceModel;
using System.Web.Services.Description;
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
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://i-account.xcs.local/AccountService.svc");
            //var myChannelFactory = new ChannelFactory<IMyService>(myBinding, myEndpoint);
            var client = new AccountServiceClient(myBinding,myEndpoint);
            return client.CreateUser(user);
        }

        public void GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null) throw new ArgumentNullException("composite");
            if (composite.BoolValue) composite.StringValue += "Suffix";
            return composite;
        }
    }
}