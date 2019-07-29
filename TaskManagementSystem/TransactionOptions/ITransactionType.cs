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
        VGridControl GetGridControl();
        void BindDataSource(DataTable dataTable);
        void HideGridControl();
    }
}
