using DevExpress.XtraVerticalGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public interface ITransactionType
    {
        void setVGridControl(VGridControl vGrid);
        VGridControl GetGridControl();
        void BindDataSource(Object obj);
        object GetTransactionType();
        bool IsAllRequireInputAvailable();
        void SetARN(int arnNo);
    }
}
