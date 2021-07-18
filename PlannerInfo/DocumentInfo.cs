using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlannerInfo
{
    public class DocumentInfo
    {
        const string GET_ALL_Document_API = "Document/GetAll?plannerId={0}";
        const string GET_ALL_BY_ID_API = "Document/GetById?id={0}&plannerId={1}";
        const string ADD_Document_API = "Document/Add";
        const string UPDATE_Document_API = "Document/Update";
        const string DELETE_Document_API = "Document/Delete";
        DataTable _dtDocument;
        internal IList<Document> GetAll(int plannerId)
        {
            IList<Document> DocumentObj = new List<Document>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_Document_API,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Document>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    DocumentObj = jsonSerialization.DeserializeFromString<IList<Document>>(restResult.ToString());
                }
                return DocumentObj;
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
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        internal Document GetById(int id, int plannerId)
        {
            Document DocumentObj = new Document();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_BY_ID_API,id,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Document>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    DocumentObj = jsonSerialization.DeserializeFromString<Document>(restResult.ToString());
                }
                return DocumentObj;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        internal void setGrid(DataGridView dtGridDocument)
        {
            dtGridDocument.Columns[0].Visible = false;
            dtGridDocument.Columns[1].Visible = false;
            dtGridDocument.Columns[2].Visible = false;
            dtGridDocument.Columns["Name"].Width = 200;
            //dtGridDocument.Columns[3].HeaderText = "Bank Name";
            //dtGridDocument.Columns[4].HeaderText = "Account Type";
            //dtGridDocument.Columns[5].HeaderText = "Account No";
            //dtGridDocument.Columns[6].HeaderText = "Branch";
            //dtGridDocument.Columns[7].HeaderText = "ContactNo";
            //dtGridDocument.Columns[8].Visible = false;
            //dtGridDocument.Columns[9].Visible = false;
            //dtGridDocument.Columns[10].HeaderText = "Minimum Require Balance";
            dtGridDocument.Columns["Data"].Visible = false;
            dtGridDocument.Columns["Path"].Visible = false;
            dtGridDocument.Columns["CreatedOn"].Visible = false;
            dtGridDocument.Columns["CreatedBy"].Visible = false;
            dtGridDocument.Columns["UpdatedOn"].Visible = false;
            dtGridDocument.Columns["UpdatedBy"].Visible = false;
            dtGridDocument.Columns["UpdatedByUserName"].Visible = false;
            dtGridDocument.Columns["MachineName"].Visible = false;
        }
        internal Document GetDocumentInfo(DataGridView dtGridDocument, DataTable dtDocument)
        {
            _dtDocument = dtDocument;
            return convertSelectedRowDataToDocument(dtGridDocument);
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        internal bool Add(Document document)
        {
            try
            {
                string apiurl = Program.WebServiceUrl +"/"+ ADD_Document_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Document>(apiurl, document, "POST");
                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
            }
        }
        internal bool Update(Document document)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_Document_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Document>(apiurl, document, "POST");

                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
            }
        }
        internal bool Delete(Document Document)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ DELETE_Document_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Document>(apiurl, Document, "DELETE");

                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
            }
        }
        private Document convertSelectedRowDataToDocument(DataGridView dtGridDocument)
        {
            if (dtGridDocument.SelectedRows.Count >= 1)
            {
                Document Document = new Document();
                DataRow dr = getSelectedDataRowForDocument(dtGridDocument);
                if (dr != null)
                {
                    Document.Id = int.Parse(dr.Field<string>("ID"));
                    Document.Cid = int.Parse(dr.Field<string>("CID"));
                    Document.Pid = int.Parse(dr.Field<string>("PID"));
                    Document.Name = dr.Field<string>("Name");
                    Document.Path = dr.Field<string>("Path");
                    Document.Category = dr.Field<string>("Category");
                    Document.Data = dr.Field<string>("Data");
                    return Document;
                }
            }
            return null;
        }

        private DataRow getSelectedDataRowForDocument(DataGridView dtGridDocument)
        {
            if (dtGridDocument.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridDocument.SelectedRows[0].Index;
                if (dtGridDocument.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridDocument.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtDocument.Select("Id ='" + selectedUserId +"'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }
    }
}
