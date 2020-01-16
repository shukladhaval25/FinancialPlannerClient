using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlannerInfo
{
    public class SessionInfo
    {
        DataTable _dtSession;
        int clientId;

        private readonly string ADD_SESSIONS = "Sessions/Add";
        private readonly string GET_SESSIONS = "Sessions/GetAll?clientId={0}";
        public SessionInfo(int clientId)
        {
            _dtSession = new DataTable();
            this.clientId = clientId;
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
            IList<Sessions> sessionsList = GetAll();
            foreach(string session in sessions)
            {
                Sessions sessionsobj = sessionsList.FirstOrDefault(i => i.SessionName == session);
                DataRow dr = _dtSession.NewRow();
                dr["Session"] = session;
                if (sessionsobj != null)
                {
                    dr["SessionDate"] = sessionsobj.SessionDate;
                    dr["IsSessionCovered"] = sessionsobj.IsCoverd;
                    dr["Note"] = sessionsobj.Notes;
                }
                _dtSession.Rows.Add(dr);
            }
        }

        internal void fillSessionInfo(GridControl gridControlSession)
        {
            gridControlSession.DataSource = _dtSession;
        }
       
        internal bool Save(IList<Sessions> sessions)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_SESSIONS;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                JSONSerialization jSON = new JSONSerialization();
                string jsonStr = jSON.SerializeToString <IList<Sessions>>(sessions);
                restApiExecutor.Execute<IList<Sessions>>(apiurl, sessions, "POST");
                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        public IList<Sessions> GetAll()
        {
            IList<Sessions> sessions = new List<Sessions>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_SESSIONS,clientId));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Sessions>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    sessions = jsonSerialization.DeserializeFromString<IList<Sessions>>(restResult.ToString());
                }
                return sessions;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

    }
}
