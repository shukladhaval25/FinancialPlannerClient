using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlannerClient.PlannerInfo;
using System.Collections.Generic;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common;
using System.Data;
using FinancialPlanner.Common.DataConversion;
using DevExpress.XtraCharts;
using static DevExpress.XtraExport.Helpers.TableCellCss;
using System.Diagnostics;
using System.Reflection;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class IncomeInflowChart : DevExpress.XtraReports.UI.XtraReport
    {
        //Client client;
        //Planner planner;
        DataTable _dtIncome;
        //double distributedFaceRetirementAmount = 0;
        public IncomeInflowChart(DataTable dtIncome)
        {
            InitializeComponent();
            //this.client = client;
            //this.planner = planner;
            //if (planner.FaceType.Equals("D"))
            //{
            //    getRetirementGoal();
            //}
            this._dtIncome = dtIncome;
            getIncomeData();
        }

        //private void getRetirementGoal()
        //{
        //    IList<Goals> goals = new GoalsInfo().GetAll(this.planner.ID);
        //    if (goals.Count > 0)
        //    {
        //        foreach (Goals goal in goals)
        //        {
        //            if (goal.Category.Equals("Retirement"))
        //            {
        //                distributedFaceRetirementAmount = getGoalFutureValue(false, goal);
        //            }
        //        }
        //    }
        //}

        //private double getGoalFutureValue(bool includeRetirementCase, Goals _goal)
        //{
        //    double futureValueOfGoal = 0;
        //    if (_goal != null)
        //    {
        //        if (_goal.Category != "Retirement")
        //        {
        //            int years = getRemainingYearsFromPlanStartYear(_goal);
        //            futureValueOfGoal = futureValue(_goal.Amount + _goal.OtherAmount, _goal.InflationRate, years);
        //        }
        //        else
        //        {
        //            int years = getRemainingYearsFromPlanStartYear(_goal);
        //            futureValueOfGoal = futureValue(_goal.Amount + _goal.OtherAmount, _goal.InflationRate, years);
        //            //double totalPostReirementExp = getPostRetirementExpTotal();
        //        }
        //    }
        //    return futureValueOfGoal;
        //}

        //private double futureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        //{
        //    try
        //    {
        //        //FV = PV * (1 + I)T;
        //        interest_rate = interest_rate / 100;
        //        decimal futureValue = (decimal)presentValue *
        //            ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

        //        return Math.Round((double)futureValue);
        //    }
        //    catch (Exception ex)
        //    {
        //        StackTrace st = new StackTrace();
        //        StackFrame sf = st.GetFrame(0);
        //        MethodBase currentMethodName = sf.GetMethod();
        //        LogDebug(currentMethodName.Name, ex);
        //        return 0;
        //    }
        //}

        //private void LogDebug(string methodName, Exception ex)
        //{
        //    DebuggerLogInfo debuggerInfo = new DebuggerLogInfo
        //    {
        //        ClassName = this.GetType().Name,
        //        Method = methodName,
        //        ExceptionInfo = ex
        //    };
        //    Logger.LogDebug(debuggerInfo);
        //}

        //private int getRemainingYearsFromPlanStartYear(Goals goal)
        //{
        //    if (int.Parse(goal.StartYear) > this.planner.StartDate.Year)
        //    {
        //        return int.Parse(goal.StartYear) - this.planner.StartDate.Year;
        //    }
        //    return 0;
        //}


        private void getIncomeData()
        {
            //IncomeInfo incomeInfo = new IncomeInfo();
            //List<Income> lstIncome = (List<Income>)incomeInfo.GetAll(this.planner.ID);
            //_dtIncome = ListtoDataTable.ToDataTable(lstIncome);


            ////_dtIncome = _dtIncome.Select("StartYear <='" + DateTime.Now.Year.ToString() + "' and EndYear >='" + DateTime.Now.Year.ToString() + "'").CopyToDataTable();
            //DataRow[] drs = _dtIncome.Select("StartYear <='" + DateTime.Now.Year.ToString() + "' and EndYear >='" + DateTime.Now.Year.ToString() + "'");
            //if (drs.Length > 0)
            //    _dtIncome = _dtIncome.Select("StartYear <='" + DateTime.Now.Year.ToString() + "' and EndYear >='" + DateTime.Now.Year.ToString() + "'").CopyToDataTable();



            //if (this.planner.FaceType.Equals("D"))
            //{
            //    double income = distributedFaceRetirementAmount;
            //    DataRow dr = _dtIncome.NewRow();
            //    dr["Source"] = "Withdrawal from Portfolio";
            //    dr["IncomeBy"] = this.client.Name;
            //    dr["Amount"] = income;
            //    dr["StartYear"] = DateTime.Now.Year;
            //    dr["EndYear"] = DateTime.Now.Year;
            //    dr["IncomeTax"] = "0";
            //    _dtIncome.Rows.Add(dr);
            //}


            this.DataSource = _dtIncome;
            this.DataMember = _dtIncome.TableName;
            xrChart1.DataSource = this.DataSource;
            xrChart1.DataMember = this.DataMember;

            xrChart1.Series[0].Points.Clear();
            xrChart1.Legend.CustomItems.Clear();
            
            int index = 0;
            foreach (DataRow dr in _dtIncome.Rows)
            {
                SeriesPoint seriesPoint = new SeriesPoint(dr["IncomeBy"].ToString(), new double[] { double.Parse(dr["Amount"].ToString())});

                seriesPoint.Color = (index == 0) ? System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))) : 
                    (index == 1) ? System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(179)))), ((int)(((byte)(226))))) :
                    (index == 2) ? System.Drawing.Color.Green : (index == 3) ? System.Drawing.Color.Indigo :
                    (index == 4) ? System.Drawing.Color.LightSkyBlue : (index == 5) ? System.Drawing.Color.Magenta :
                    (index == 6) ? System.Drawing.Color.MediumSlateBlue : System.Drawing.Color.Red;
                xrChart1.Series[0].Points.Add(seriesPoint);
                xrChart1.Legend.CustomItems.Insert(index, new CustomLegendItem(dr["IncomeBy"].ToString()));
                xrChart1.Legend.CustomItems[index].MarkerColor = seriesPoint.Color; // xrChart1.Series[0].Points[index].Color;
                
                xrChart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                
                index = index + 1;
            }
        }
    }
}
