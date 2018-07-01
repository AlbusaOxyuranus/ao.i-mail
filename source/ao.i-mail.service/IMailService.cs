using System.ServiceModel;
using ao.i_mail.service.data.models;
using ao.i_mail.service.i_AccountService;

namespace ao.i_mail.service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMailService" in both code and config file together.
    [ServiceContract]
    public interface IMailService
    {
        [OperationContract]
        User CreateUser(User user);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        Config GetConfig(Config config);

        [OperationContract]
        Config CreateConfig(User user, Config config);
    }
}
