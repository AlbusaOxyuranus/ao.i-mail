using System.Configuration;
using ao.i_account.service.dal;

namespace ao.i_mail.service
{
    public class AppMode : IMode
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Prod-db"].ConnectionString; }
        }
    }
}