using System.Runtime.Serialization;

namespace ao.i_mail.service.data.models
{
    [DataContract]
    public class Config : IEntity
    {
        [DataMember] public string Key { get; set; }
        [DataMember] public string Value { get; set; }
        [DataMember] public int Id { get; set; }

        [DataMember] public int UserId { get; set; }
    }
}