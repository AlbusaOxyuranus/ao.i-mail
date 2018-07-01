using System.Collections.Generic;
using System.Linq;
using ao.i_account.service.dal;

namespace ao.i_mail.service.data.dal.Usp
{
    public abstract class UspBase
    {
        private readonly Operation _operation;
        protected Dictionary<Operation, string> StoreProcedureList { get; set; }

        protected UspBase(Operation operation)
        {
            _operation = operation;
            Parameters = new Dictionary<string, object>();
        }

        public string NameUsp
        {
            get { return StoreProcedureList.Single(x => x.Key == _operation).Value; }
        }

        public Dictionary<string, object> Parameters { get; }
    }
}