using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;

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

        private void createDefaultColumns()
        {           
            _dtSession.Columns.Add(new DataColumn("Session", typeof(System.String)));
            _dtSession.Columns.Add(new DataColumn("SessionDate", typeof(System.DateTime)));
            _dtSession.Columns.Add(new DataColumn("IsSessionCovered", typeof(System.Boolean)));
            _dtSession.Columns.Add(new DataColumn("Note", typeof(System.String)));
            addDefaultValues();
        }
        private void addDefaultValues()
        {
            string[] sessions = new string[] {
                "Introduction Session",
                "Data Gathering and goal setting session",
                "Risk Profiling and Financial literacy session",
                "Plan Presentation session",
                "Quarterly First portfolio review",
                "Quarterly Second portfolio review",
                "Quarterly Third portfolio review",
                "Annual Plan Review"
            };
            
            foreach(string session in sessions)
            {
                DataRow dr = _dtSession.NewRow();
                dr["Session"] = session;
                _dtSession.Rows.Add(dr);
            }
        }

        internal void fillSessionInfo(GridControl gridControlSession)
        {
            gridControlSession.DataSource = _dtSession;
        }
    }
}
