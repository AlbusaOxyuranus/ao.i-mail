using System.Configuration;
using ao.i_account.service.dal;

namespace ao.i_mail.service.data.tests
{
    public class TestMode : IMode
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["Test-db"].ConnectionString;
    }
}
