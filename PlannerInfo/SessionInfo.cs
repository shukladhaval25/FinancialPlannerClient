using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlannerInfo
{
    public class SessionInfo
    {
        DataTable _dtSession;
        public SessionInfo()
        {
            _dtSession = new DataTable();
            createDefaultColumns();
        }

        public DataTable GetSessionData()
        {
            return _dtSession;
        }
        private void createDefaultColumns()
        {           
            _dtSession.Columns.Add(new DataColumn("Topic", typeof(System.String)));
            _dtSession.Columns.Add(new DataColumn("SessionDate", typeof(System.DateTime)));
            _dtSession.Columns.Add(new DataColumn("Covered", typeof(System.Boolean)));
            _dtSession.Columns.Add(new DataColumn("Notes", typeof(System.String)));
            addDefaultValues();
        }
        private void addDefaultValues()
        {
            DataRow dr = _dtSession.NewRow();
            dr["Topic"] = "Data Gathering and Goal Setting Session";          
            dr["Covered"] = false;            
            dr["Notes"] = string.Empty;
            _dtSession.Rows.Add(dr);

            dr = _dtSession.NewRow();
            dr["Topic"] = "Financial Literacy Session";
            dr["Covered"] = false;
            dr["Notes"] = string.Empty;
            _dtSession.Rows.Add(dr);

            dr = _dtSession.NewRow();
            dr["Topic"] = "Quarterly First Portfolio Review";
            dr["Covered"] = false;
            dr["Notes"] = string.Empty;
            _dtSession.Rows.Add(dr);

            dr = _dtSession.NewRow();
            dr["Topic"] = "Quarterly Second Portfolio Review";
            dr["Covered"] = false;
            dr["Notes"] = string.Empty;
            _dtSession.Rows.Add(dr);

            dr = _dtSession.NewRow();
            dr["Topic"] = "Quarterly Third Portfolio Review";
            dr["Covered"] = false;
            dr["Notes"] = string.Empty;
            _dtSession.Rows.Add(dr);


            dr = _dtSession.NewRow();
            dr["Topic"] = "Annual Plan Review";
            dr["Covered"] = false;
            dr["Notes"] = string.Empty;
            _dtSession.Rows.Add(dr);
        }

        internal void fillSessionInfo(DataGridView dtGridSession)
        {
            dtGridSession.DataSource = _dtSession;
            dtGridSession.Columns[0].HeaderText = "Topic";
            dtGridSession.Columns[1].HeaderText = "Session Date";
            dtGridSession.Columns[2].HeaderText = "Session Covered";
            dtGridSession.Columns[3].HeaderText = "Notes";
            dtGridSession.Columns[0].Width = 250;
            dtGridSession.Columns[1].Width = 150;
            dtGridSession.Columns[2].Width = 150;
            dtGridSession.Columns[3].Width = 300;
            dtGridSession.Columns[0].ReadOnly = true;
        }
    }
}
