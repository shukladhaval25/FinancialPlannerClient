using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.Insurance
{
    internal class InsuranceCoverageService
    {
        private const int singlePersonRetirmentCorpusPercentage = 70;
        int currentYear = DateTime.Now.Year;
        DataTable dtInsurance = new DataTable();
        DataTable dtInsuranceCoverage = new DataTable();
        double totalLoanAmountDue = 0;
        private double proposeEstimatedInsuranceRequire = 0;
        private double insuranceReturnRate = 0;
        const decimal npvReturnRate = 8;
        Client client;
        Planner planner;
        PlannerAssumption plannerAssumption;
        IList<Expenses> expenses;
        IList<Goals> goalsResult;
        IList<Loan> loansResult;
        public InsuranceCoverageService(Client client,Planner planner)
        {
            this.client = client;
            this.planner = planner;
            plannerAssumption = new PlannerAssumptionInfo().GetAll(planner.ID);
            AssumptionMaster  assumptionMaster = Program.GetAssumptionMaster();
            insuranceReturnRate = double.Parse(assumptionMaster.InsuranceReturnRate.ToString());
        }

        public void CalculateInsuranceCoverNeed()
        {
            dtInsuranceCoverage.Columns.Add("Item");
            dtInsuranceCoverage.Columns.Add("Amount", Type.GetType("System.Double"));

            DataColumn dcYear = new DataColumn("Year", Type.GetType("System.Int32"));
            dtInsurance.Columns.Add(dcYear);

            int remainYearsForRetirement = plannerAssumption.ClientRetirementAge - (currentYear - client.DOB.Year);

            for (int cy = currentYear; cy <= currentYear + remainYearsForRetirement; cy++)
            {
                DataRow dr = dtInsurance.NewRow();
                dr["Year"] = cy;
                dtInsurance.Rows.Add(dr);
            }

            for (int rowIndex = 0; rowIndex <= dtInsurance.Rows.Count - 1; rowIndex++)
            {
                addExpensesIntoInsuranceCoverage(rowIndex);
                addGoalsIntoInsuranceCoverage(rowIndex);
                addLoansIntoInsuranceCoverage(rowIndex);
                addRetirementCorpusFundInCoverage(rowIndex);

                addLifeInsuranceSumAssured(rowIndex);
                addFinancialAssets(rowIndex);
                addNonFinancialAssets(rowIndex);
                
                addTotalExpCovergeRequire(rowIndex);

            }
            calculateEstimateInsuranceRequire();

           
        }

        public DataTable GetEstimatedTable()
        {
            return dtInsurance;
        }

        public DataTable GetInsurnaceCoverage()
        {
            return dtInsuranceCoverage;
        }
        public double GetEstimatedInsurnceAmount()
        {
            return proposeEstimatedInsuranceRequire;
        }

        private void addRetirementCorpusFundInCoverage(int rowIndex)
        {
            if (plannerAssumption.SpouseLifeExpectancy == 0 )
                return;
            PlanOptionInfo planOptionInfo = new PlanOptionInfo();
            DataTable planOptionTable = planOptionInfo.GetAll(planner.ID);
            if (planOptionTable.Rows.Count > 0 && rowIndex == 0)
            {
                int riskProfileId = int.Parse(planOptionTable.Rows[0]["RiskProfileId"].ToString());
                PostRetirementCashFlowService postRetirementCashFlowService;
                CashFlowService cashFlowService = new CashFlowService();
                cashFlowService.GenerateCashFlow(client.ID, planner.ID,riskProfileId);
                postRetirementCashFlowService = new PostRetirementCashFlowService(planner, cashFlowService);
                postRetirementCashFlowService.GetPostRetirementCashFlowData();
                postRetirementCashFlowService.calculateEstimatedRequireCorpusFund();
                double totalEstimatedRetirementCorpusFund = Math.Round(postRetirementCashFlowService.GetProposeEstimatedCorpusFund(), 2);

                double estimatedRetirementCorpusForSinglePerson = 
                    (totalEstimatedRetirementCorpusFund * singlePersonRetirmentCorpusPercentage) / 100;

                int remainYearsForRetirement = (plannerAssumption.ClientRetirementAge + 1) - (currentYear - client.DOB.Year);

                estimatedRetirementCorpusForSinglePerson = presentValue(estimatedRetirementCorpusForSinglePerson, npvReturnRate, remainYearsForRetirement);
                
                    DataColumn dcFinancialAssets = new DataColumn("RetirementCorpus", Type.GetType("System.Double"));
                    dtInsurance.Columns.Add(dcFinancialAssets);
                    DataRow dr = dtInsurance.Rows[rowIndex];
                    dr["RetirementCorpus"] = estimatedRetirementCorpusForSinglePerson;
            }
        }

        private void addNonFinancialAssets(int rowIndex)
        {
            IList<NonFinancialAsset> nonFinancialAssets = new NonFinancialAssetInfo().GetAll(this.planner.ID);
            
            if (nonFinancialAssets != null &&  nonFinancialAssets.Count > 0)
            {
                nonFinancialAssets = nonFinancialAssets.ToList().FindAll(i => i.EligibleForInsuranceCover == true);
                double totalNonFinancialAsset = 0;
                if (rowIndex == 0)
                {
                    DataColumn dcFinancialAssets = new DataColumn("NonFinancialAssets", Type.GetType("System.Double"));
                    dtInsurance.Columns.Add(dcFinancialAssets);
                    foreach(NonFinancialAsset nonFinancialAsset in nonFinancialAssets)
                    {
                        totalNonFinancialAsset = totalNonFinancialAsset + nonFinancialAsset.CurrentValue;
                    }

                    DataRow dr = dtInsurance.Rows[rowIndex];
                    dr["NonFinancialAssets"] = totalNonFinancialAsset;
                }
            }
        }

        private void addFinancialAssets(int rowIndex)
        {
            CurrentStatusCalculation currentStatusCalculation = new CurrentStatusInfo().GetAllCurrestStatus(this.planner.ID);
            if (currentStatusCalculation != null)
            {
                if (rowIndex == 0)
                {
                    DataColumn dcFinancialAssets = new DataColumn("FinancialAssets", Type.GetType("System.Double"));
                    dtInsurance.Columns.Add(dcFinancialAssets);
                    DataRow dr = dtInsurance.Rows[rowIndex];
                    dr["FinancialAssets"] = currentStatusCalculation.Total;
                }
            }
        }

        private void addLifeInsuranceSumAssured(int rowIndex)
        {
            IList<LifeInsurance> lifeInsurances = new LifeInsuranceInfo().GetAllLifeInsurance(planner.ID);
            if (lifeInsurances != null)
            {
                if (lifeInsurances.Count > 0)
                {
                    List<LifeInsurance> lics = lifeInsurances.ToList().FindAll(x => x.Applicant == client.Name);

                    if (rowIndex == 0)
                    {
                        double totalSumAssured = 0;
                        foreach (LifeInsurance lic in lics)
                        {
                            DataColumn dcLoan = new DataColumn("LIC -" + lic.Applicant, Type.GetType("System.Double"));
                            dtInsurance.Columns.Add(dcLoan);

                            DataRow dr = dtInsurance.Rows[rowIndex];
                            dr["LIC -" + lic.Applicant] = lic.SumAssured;
                            totalSumAssured = totalSumAssured + lic.SumAssured;
                        }
                    }
                }
            }
        }

        private void calculateEstimateInsuranceRequire()
        {
            if (!dtInsurance.Columns.Contains("EstimatedRequireInsurance"))
            {
                DataColumn dcExp = new DataColumn("EstimatedRequireInsurance", Type.GetType("System.Double"));
                dtInsurance.Columns.Add(dcExp);
            }
          
            for (int i = dtInsurance.Rows.Count - 1; i >= 1; i--)
            {
                double totalExpAmount = (double.Parse(dtInsurance.Rows[i]["TotalCoverageRequire"].ToString()));

                if (i == dtInsurance.Rows.Count - 1)
                    dtInsurance.Rows[i]["EstimatedRequireInsurance"] = 0;
                dtInsurance.Rows[i - 1]["EstimatedRequireInsurance"] = Math.Round(totalExpAmount +
                    getEstimatedCorpusFundWithReturnCalculation(
                        double.Parse(dtInsurance.Rows[i]["EstimatedRequireInsurance"].ToString())
                    ), 2);
            }
            proposeEstimatedInsuranceRequire = System.Math.Round(
                double.Parse(dtInsurance.Rows[0]["EstimatedRequireInsurance"].ToString()), 2);

            proposeEstimatedInsuranceRequire = (proposeEstimatedInsuranceRequire * 100) / (100 + insuranceReturnRate);

            double totalExpAmountForFirstRow = (double.Parse(dtInsurance.Rows[0]["TotalCoverageRequire"].ToString()));
            proposeEstimatedInsuranceRequire = proposeEstimatedInsuranceRequire + totalExpAmountForFirstRow;
            double[] expValues = getExpneses(dtInsurance);
        }

        private double[] getExpneses(DataTable dtInsurance)
        {
            if (dtInsurance.Rows.Count == 0)
                return new double[] { 0 };

            double[] expValues;
            double totalExpenses = 0;
            double totalExistingCoverage = 0;
            foreach (DataColumn dataColumn in dtInsurance.Columns)
            {
                if (!dataColumn.ColumnName.Equals("TotalCoverageRequire") &&
                    !dataColumn.ColumnName.Equals("EstimatedRequireInsurance"))
                {
                    expValues = new double[dtInsurance.Rows.Count];
                    if (expenses.Count(i => i.Item == dataColumn.ColumnName) > 0)
                    {
                        for (int rowindex = 0; rowindex <= dtInsurance.Rows.Count - 1; rowindex++)
                        {
                            expValues[rowindex] = double.Parse(dtInsurance.Rows[rowindex][dataColumn.ColumnName].ToString());
                        }
                        double npv = npvValue(npvReturnRate, ref expValues);
                        DataRow dataRow = dtInsuranceCoverage.NewRow();
                        dataRow["Item"] = dataColumn.ColumnName.ToString();
                        dataRow["Amount"] = Math.Round(npv);
                        dtInsuranceCoverage.Rows.Add(dataRow);
                        totalExpenses = totalExpenses + npv;
                    }
                    else if (!dataColumn.ColumnName.ToString().Equals("Year"))
                    {
                        DataRow dataRow = dtInsuranceCoverage.NewRow();
                        dataRow["Item"] = dataColumn.ColumnName.ToString();
                        dataRow["Amount"] = Math.Round(double.Parse(dtInsurance.Rows[0][dataColumn.ColumnName].ToString()));
                        dtInsuranceCoverage.Rows.Add(dataRow);
                        if ((goalsResult.Count(x => x.Name == dataColumn.ColumnName.ToString()) > 0) ||
                            (loansResult.Count(x => x.TypeOfLoan == dataColumn.ColumnName.ToString()) > 0) ||
                            dataColumn.ColumnName.Equals("RetirementCorpus"))
                        {
                            totalExpenses = totalExpenses + Math.Round(double.Parse(dtInsurance.Rows[0][dataColumn.ColumnName].ToString()));
                        }
                        else
                        {
                            totalExistingCoverage = totalExistingCoverage + Math.Round(double.Parse(dtInsurance.Rows[0][dataColumn.ColumnName].ToString()));
                        }
                    }
                }
            }
            double totalCoverageRequire = totalExpenses - totalExistingCoverage;
            DataRow[] drs = dtInsuranceCoverage.Select("Item = '" + "TotalCoverageRequire" + "'");
            drs[0]["Amount"] = (totalCoverageRequire > 0) ? totalCoverageRequire : 0;
            //dtInsuranceCoverage.Rows[0]["TotalCoverageRequire"] = (totalCoverageRequire > 0) ? totalCoverageRequire : 0;


            //Dictionary<string, double[]> keyPairExpenses = new Dictionary<string, double[]>();
            //double[] expensesValue = new double[dtInsurance.Rows.Count];

            ////expenses[i] = double.Parse(dtInsurance.Rows[i][""].ToString());
            //for (int rowIndex = 0; rowIndex <= dtInsurance.Rows.Count - 1; rowIndex++)
            //{
            //    int cy = dtInsurance.Rows[rowIndex].Field<int>("Year");
            //    if (expenses.Count > 0)
            //    {
            //        List<Expenses> exps = expenses.ToList().FindAll(i => i.EligibleForInsuranceCoverage && (int.Parse(i.ExpStartYear) <= cy) && (i.ExpEndYear == "" || (i.ExpEndYear != null && cy <= int.Parse(i.ExpEndYear))));

            //        foreach (Expenses exp in exps)
            //        {
            //            if (dtInsurance.Columns.Contains(exp.Item))
            //            {
            //                if (keyPairExpenses.ContainsKey(exp.Item))
            //                {
            //                    double[] currentExpes;
            //                    keyPairExpenses.TryGetValue(exp.Item, out currentExpes);

            //                }
            //            }
            //        }
            //    }

            //}
            return null;
        }

        private double getEstimatedCorpusFundWithReturnCalculation(double value)
        {
            return (value * 100) / (100 + insuranceReturnRate);
        }

        private void addTotalExpCovergeRequire(int rowindex)
        {
            if (!dtInsurance.Columns.Contains("TotalCoverageRequire"))
            {
                DataColumn dcExp = new DataColumn("TotalCoverageRequire", Type.GetType("System.Double"));
                dtInsurance.Columns.Add(dcExp);
            }

            double totalExpRequire = 0;
            for (int columnIndex = 1; columnIndex <= dtInsurance.Columns.Count - 1; columnIndex++)
            {
                if (dtInsurance.Rows[rowindex][columnIndex] != DBNull.Value)
                {
                    if (dtInsurance.Columns[columnIndex].ToString().StartsWith("LIC") ||
                        dtInsurance.Columns[columnIndex].ToString() == "FinancialAssets" ||
                        dtInsurance.Columns[columnIndex].ToString() == "NonFinancialAssets")
                    {
                        totalExpRequire = totalExpRequire -
                           double.Parse(dtInsurance.Rows[rowindex][columnIndex].ToString());
                    }
                    else
                    {
                        totalExpRequire = totalExpRequire +
                            double.Parse(dtInsurance.Rows[rowindex][columnIndex].ToString());
                    }
                }
            }
            dtInsurance.Rows[rowindex]["TotalCoverageRequire"] = totalExpRequire;
        }

        private void addLoansIntoInsuranceCoverage(int rowIndex)
        {
            #region "Loans"
            loansResult = new LoanInfo().GetAll(planner.ID);
            if (loansResult.Count > 0)
            {
                List<Loan> loans = loansResult.ToList();

                if (rowIndex == 0)
                {
                    foreach (Loan loan in loans)
                    {
                        DataColumn dcLoan = new DataColumn(loan.TypeOfLoan, Type.GetType("System.Double"));
                        dtInsurance.Columns.Add(dcLoan);

                        DataRow dr = dtInsurance.Rows[rowIndex];
                        dr[loan.TypeOfLoan] = loan.OutstandingAmt;
                        totalLoanAmountDue = totalLoanAmountDue + loan.OutstandingAmt;
                    }
                }
            }
            #endregion
        }

        private void addGoalsIntoInsuranceCoverage(int rowIndex)
        {
            #region "Gaols"
            int cy = dtInsurance.Rows[rowIndex].Field<int>("Year");
            goalsResult = new GoalsInfo().GetAll(planner.ID);
            if (goalsResult.Count > 0)
            {
                List<Goals> goals = goalsResult.ToList().FindAll(i => i.IsDeleted == false && i.EligibleForInsuranceCoverage == true && int.Parse(i.StartYear) == cy);
                //List<Goals> goals = GetAllGoals().FindAll(i => i.StartYear == cy);
                foreach (Goals goal in goals)
                {

                    if (!dtInsurance.Columns.Contains(goal.Name))
                    {
                        DataColumn dcExp = new DataColumn(goal.Name, Type.GetType("System.Double"));
                        dtInsurance.Columns.Add(dcExp);
                        DataRow dr = dtInsurance.Rows[rowIndex];
                        dr[goal.Name] = futureValue(goal.Amount, (decimal)goal.InflationRate, int.Parse(goal.StartYear) - currentYear);
                    }
                }
            }
            #endregion
        }

        private void addExpensesIntoInsuranceCoverage(int rowIndex)
        {
            #region "Exp"
            int cy = dtInsurance.Rows[rowIndex].Field<int>("Year");
            expenses = new ExpensesInfo().GetAll(planner.ID);
            if (expenses.Count > 0)
            {
                List<Expenses> exps = expenses.ToList().FindAll(i => i.EligibleForInsuranceCoverage && (int.Parse(i.ExpStartYear) <= cy) && (i.ExpEndYear == "" || (i.ExpEndYear != null && cy <= int.Parse(i.ExpEndYear))));

                foreach (Expenses exp in exps)
                {
                    if (!dtInsurance.Columns.Contains(exp.Item))
                    {
                        DataColumn dcExp = new DataColumn(exp.Item, Type.GetType("System.Double"));
                        dtInsurance.Columns.Add(dcExp);
                        DataRow dr = dtInsurance.Rows[rowIndex];
                        dr[exp.Item] =(exp.OccuranceType == 0) ? (exp.Amount * 12) : exp.Amount;
                    }
                    else
                    {
                        double inflationRate = exp.InflationRate;
                        double lastYearExp = dtInsurance.Rows[rowIndex - 1].Field<double>(exp.Item);
                        DataRow dr = dtInsurance.Rows[rowIndex];
                        dr[exp.Item] = Math.Round(lastYearExp + ((lastYearExp * inflationRate) / 100));
                    }
                }
            }
            #endregion
        }

        private static double futureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        {
            //FV = PV * (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal futureValue = (decimal)presentValue *
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)futureValue);
        }
        private static double presentValue(double futureValue, decimal interest_rate, int timePeriodInYears)
        {
            //PV = FV / (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal presentValue = (decimal)futureValue /
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)presentValue);
        }
        private double npvValue(decimal returnPercentage,ref double[] values)
        {
           decimal interestRate = returnPercentage / 100;
            return  Microsoft.VisualBasic.Financial.NPV( double.Parse(interestRate.ToString()),ref values);
        }
    }
}
