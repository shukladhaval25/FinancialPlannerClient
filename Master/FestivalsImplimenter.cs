using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master
{
    public class FestivalsImplimenter : IOtherItems
    {
        FestivalsInfo _festivalsInfo;
        DataTable _dtFestivals;
        public FestivalsImplimenter()
        {
            _festivalsInfo = new FestivalsInfo();
            _dtFestivals = new DataTable();
        }
        public bool Delete(object obj)
        {
            Festivals fest = (Festivals) obj;
            return _festivalsInfo.Delete(fest);
        }

        public object GetAll()
        {
            return _festivalsInfo.GetAll();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void LoadData(DataGridView dtGridView)
        {
            IList<Festivals> festivals =  _festivalsInfo.GetAll();
            _dtFestivals = ListtoDataTable.ToDataTable(festivals.ToList());
            loadDataOnGrid(dtGridView,_dtFestivals);            
        }

        private void loadDataOnGrid(DataGridView dtGridView, DataTable _dtFestivals)
        {
            dtGridView.DataSource = _dtFestivals;
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
            Festivals fest = (Festivals) obj;
            return _festivalsInfo.Add(fest);
        }
        public void LoadData(GridControl grdViewOther)
        {
            IList<Festivals> festivals = _festivalsInfo.GetAll();
            _dtFestivals = ListtoDataTable.ToDataTable(festivals.ToList());
            loadDataOnGrid(grdViewOther, _dtFestivals);
        }

        private void loadDataOnGrid(GridControl dtGridView, DataTable _dtArea)
        {
            dtGridView.DataSource = _dtArea;
            setDataGridView(dtGridView.FocusedView as GridView);
        }

        private void setDataGridView(GridView dtGridView)
        {
            dtGridView.Columns["CreatedOn"].Visible = false;
            dtGridView.Columns["CreatedBy"].Visible = false;
            dtGridView.Columns["UpdatedOn"].Visible = false;
            dtGridView.Columns["UpdatedBy"].Visible = false;
            dtGridView.Columns["UpdatedByUserName"].Visible = false;
            dtGridView.Columns["MachineName"].Visible = false;
        }
    }
}
