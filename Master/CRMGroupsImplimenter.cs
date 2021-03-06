﻿using FinancialPlanner.Common.DataConversion;
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
    public class CRMGroupsImplimenter : IOtherItems
    {
        CRMGroupInfo _CRMGroupInfo;
        DataTable _dtCRMGroup;
        public CRMGroupsImplimenter()
        {
            _CRMGroupInfo = new CRMGroupInfo();
            _dtCRMGroup = new DataTable();
        }
        public bool Delete(object obj)
        {
            CRMGroup fest = (CRMGroup) obj;
            return _CRMGroupInfo.Delete(fest);
        }

        public object GetAll()
        {
            return _CRMGroupInfo.GetAll();
        }

        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void LoadData(DataGridView dtGridView)
        {
            IList<CRMGroup> CRMGroup =  _CRMGroupInfo.GetAll();
            _dtCRMGroup = ListtoDataTable.ToDataTable(CRMGroup.ToList());
            loadDataOnGrid(dtGridView, _dtCRMGroup);
        }

        private void loadDataOnGrid(DataGridView dtGridView, DataTable _dtCRMGroup)
        {
            dtGridView.DataSource = _dtCRMGroup;
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
            CRMGroup fest = (CRMGroup) obj;
            return _CRMGroupInfo.Add(fest);
        }

    }
}
