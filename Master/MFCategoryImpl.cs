using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master
{
    public class MFCategoryImpl : IOtherItems
    {
        SchemeCategoryInfo schemeCategoryInfo;
        DataTable _dtSchemeCategory;
        public MFCategoryImpl()
        {
            schemeCategoryInfo = new SchemeCategoryInfo();
            _dtSchemeCategory = new DataTable();
        }
        public bool Delete(object obj)
        {
            SchemeCategory schemeCategory = (SchemeCategory)obj;
            return schemeCategoryInfo.Delete(schemeCategory);
        }

        public object GetAll()
        {
            return schemeCategoryInfo.GetAll();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void LoadData(DataGridView dtGridView)
        {
            IList<SchemeCategory> schemeCategories = schemeCategoryInfo.GetAll();
            _dtSchemeCategory = ListtoDataTable.ToDataTable(schemeCategories.ToList());
            loadDataOnGrid(dtGridView, _dtSchemeCategory);
        }

        private void loadDataOnGrid(DataGridView dtGridView, DataTable dtArea)
        {
            dtGridView.DataSource = _dtSchemeCategory;
            setDataGridView(dtGridView);
        }

        private void loadDataOnGrid(GridControl dtGridView, DataTable _dtArea)
        {
            dtGridView.DataSource = _dtArea;
            setDataGridView(dtGridView);
        }

        private void setDataGridView(GridControl gridControl)
        {
            GridView view = gridControl.MainView as GridView;
            view.Columns["Id"].Visible = false;
            view.Columns["CreatedOn"].Visible = false;
            view.Columns["CreatedBy"].Visible = false;
            view.Columns["UpdatedOn"].Visible = false;
            view.Columns["UpdatedBy"].Visible = false;
            view.Columns["UpdatedByUserName"].Visible = false;
            view.Columns["MachineName"].Visible = false;
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
            SchemeCategory schemeCategory = (SchemeCategory)obj;
            return schemeCategoryInfo.Add(schemeCategory);
        }

        public void LoadData(GridControl grdViewOther)
        {
            IList<SchemeCategory> schemeCategories = schemeCategoryInfo.GetAll();
            _dtSchemeCategory = ListtoDataTable.ToDataTable(schemeCategories.ToList());
            loadDataOnGrid(grdViewOther, _dtSchemeCategory);
        }
    }
}
