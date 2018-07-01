using System.Collections.Generic;
using ao.i_account.service.dal;

namespace ao.i_mail.service.data.dal.Usp
{
    public class ConfigUspBase : UspBase
    {
        public ConfigUspBase(Operation operation):base(operation)
        {
            StoreProcedureList = new Dictionary<Operation, string>
            {
                {Operation.Insert, "usp_Insert_Config"},
                {Operation.Get, "usp_Get_Config"}
            };
        }
    }
}