using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master
{
    public interface IOtherItems
    {
        void LoadData(DataGridView dtGridView);
        object GetAll();
        object GetById(int id);
        bool Save(object obj);
        bool Delete(object obj);
    }
}
