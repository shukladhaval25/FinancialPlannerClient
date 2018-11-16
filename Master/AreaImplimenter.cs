using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master
{
    public class AreaImplimenter : IOtherItems
    {
        AreaInfo _AreaInfo;
        DataTable _dtArea;
        public AreaImplimenter()
        {
            _AreaInfo = new AreaInfo();
            _dtArea = new DataTable();
        }
        public bool Delete(object obj)
        {
            FinancialPlanner.Common.Model.Area fest = (Area) obj;
            return _AreaInfo.Delete(fest);
        }

        public object GetAll()
        {
            return _AreaInfo.GetAll();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void LoadData(DataGridView dtGridView)
        {
            IList<Area> Area =  _AreaInfo.GetAll();
            _dtArea = ListtoDataTable.ToDataTable(Area.ToList());
            loadDataOnGrid(dtGridView, _dtArea);
        }

        private void loadDataOnGrid(DataGridView dtGridView, DataTable _dtArea)
        {
            dtGridView.DataSource = _dtArea;
            setDataGridView(dtGridView);
        }


        private void setDataGridView(DataGridView dtGridView)
        {
            dtGridView.Columns["CreatedOn"].Visible = false;
            dtGridView.Columns["CreatedBy"].Visible = false;
            dtGridView.Columns["UpdatedOn"].Visible = false;
            dtGridView.Columns["UpdatedBy"].Visible = false;
            dtGridView.Columns["UpdatedByUserName"].Visible = false;
            dtGridView.Columns["MachineName"].Visible = false;
        }

        public bool Save(object obj)
        {
            Area fest = (Area) obj;
            return _AreaInfo.Add(fest);
        }
    }
}
