using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.Masters;

namespace FinancialPlannerClient.Master
{
    public class InsuranceCompanyImplimenter : IOtherItems
    {
        InsuranceCompanyInfo insuranceCompanyInfo;
        DataTable dtInsuranceCompany;
        public InsuranceCompanyImplimenter()
        {
            insuranceCompanyInfo = new InsuranceCompanyInfo();
            dtInsuranceCompany = new DataTable();
        }
        public bool Delete(object obj)
        {
            InsuranceCompany insuranceCompany = (InsuranceCompany)obj;
            return insuranceCompanyInfo.Delete(insuranceCompany);
        }

        public object GetAll()
        {
            return insuranceCompanyInfo.GetAll();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void LoadData(DataGridView dtGridView)
        {
            IList<InsuranceCompany> Area = insuranceCompanyInfo.GetAll();
            dtInsuranceCompany = ListtoDataTable.ToDataTable(Area.ToList());
            loadDataOnGrid(dtGridView, dtInsuranceCompany);
        }

        private void loadDataOnGrid(DataGridView dtGridView, DataTable dataTable)
        {
            dtGridView.DataSource = dataTable;
            setDataGridView(dtGridView);
        }
        private void loadDataOnGrid(GridControl dtGridView, DataTable dataTable)
        {
            dtGridView.DataSource = dataTable;
            setDataGridView(dtGridView);
        }

        private void setDataGridView(GridControl gridControl)
        {
            GridView view = gridControl.MainView as GridView;
            view.Columns["Id"].Visible = false;
            //view.Columns["CreatedOn"].Visible = false;
            //view.Columns["CreatedBy"].Visible = false;
            //view.Columns["UpdatedOn"].Visible = false;
            //view.Columns["UpdatedBy"].Visible = false;
            //view.Columns["UpdatedByUserName"].Visible = false;
            //view.Columns["MachineName"].Visible = false;
        }

        private void setDataGridView(DataGridView dtGridView)
        {
            dtGridView.Columns["Id"].Visible = false;
            //dtGridView.Columns["CreatedOn"].Visible = false;
            //dtGridView.Columns["CreatedBy"].Visible = false;
            //dtGridView.Columns["UpdatedOn"].Visible = false;
            //dtGridView.Columns["UpdatedBy"].Visible = false;
            //dtGridView.Columns["UpdatedByUserName"].Visible = false;
            //dtGridView.Columns["MachineName"].Visible = false;
        }

        public bool Save(object obj)
        {
            InsuranceCompany  insuranceCompany = (InsuranceCompany)obj;
            return insuranceCompanyInfo.Add(insuranceCompany);
        }

        public void LoadData(GridControl gridControl)
        {
            IList<InsuranceCompany> insuranceCompanies = insuranceCompanyInfo.GetAll();
            if (insuranceCompanies != null)
            {
                dtInsuranceCompany = ListtoDataTable.ToDataTable(insuranceCompanies.ToList());
                loadDataOnGrid(gridControl, dtInsuranceCompany);
            }
        }
    }
}
