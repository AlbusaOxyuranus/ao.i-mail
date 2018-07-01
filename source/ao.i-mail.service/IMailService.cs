
using System.Runtime.Serialization;
using System.ServiceModel;
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
        void GetUser(int id);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
