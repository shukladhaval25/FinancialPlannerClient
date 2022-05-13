using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.Controls
{
    public interface ICustomerReminderInfo
    {
        DataTable GetRecord(DateTime fromDate, DateTime toDate);
    }
}
