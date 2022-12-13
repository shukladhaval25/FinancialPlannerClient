using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinancialPlannerClient.Clients
{
    public class ImportFromExcel
    {
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkbook;
        public ImportFromExcel(string excelFilePath)
        {
            xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];

        }
        public PersonalInformation GetClientPersonalInformation()
        {
            PersonalInformation personalInfo = new PersonalInformation();
            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("1.PERSONAL DETAILS"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    excelSheet.Activate();
                    Excel.Range xlRange = excelSheet.UsedRange;

                    Client client = fetchClientInformation(excelSheet);
                    personalInfo.Client = client;
                    ClientSpouse clientSpouse = fetchSpouseInformation(excelSheet);
                    personalInfo.Spouse = clientSpouse;
                    break;
                }
            }
            //personalInfo.Spouse = getClientSpouseData();
            return personalInfo;
        }

        private ClientSpouse fetchSpouseInformation(Excel.Worksheet excelSheet)
        {
            ClientSpouse clientSpouse = new ClientSpouse();
            for (int row = 10; row < 22; row++)
            {
                //string clientName, gender,marritalstatus, panCard, aadharCard, POB, fatherName, montherName;
                Excel.Range rng = (Excel.Range)excelSheet.Cells[row, 10];
                if (row == 10)
                    clientSpouse.Name = rng.Value;
                else if (row == 11)
                    clientSpouse.DOB = (rng.Value == null) ? new DateTime() : ((DateTime)rng.Value);
                else if (row == 12)
                    clientSpouse.Gender = (((string)rng.Value).ToUpper().Equals("MALE") || ((string)rng.Value).ToUpper().Equals("M")) ? "Male" : "Female";
                else if (row == 13)
                    clientSpouse.MarriageAnniversary = (rng.Value != null) ? ((DateTime)rng.Value) : (DateTime?)null;
                else if (row == 14)
                    clientSpouse.IsMarried = ((string)rng.Value).ToUpper().Equals("MARRIED") ? true : false;
                else if (row == 15)
                    clientSpouse.PAN = rng.Value;
                else if (row == 16)
                    clientSpouse.Aadhar = rng.Value;
                else if (row == 17)
                    clientSpouse.PlaceOfBirth = rng.Value;
                else if (row == 18)
                    clientSpouse.FatherName = rng.Value;
                else if (row == 19)
                    clientSpouse.MotherName = rng.Value;
            }
            clientSpouse.IsActive = true;
            clientSpouse.IsDeleted = false;
            clientSpouse.CreatedOn = DateTime.Now;
            clientSpouse.CreatedBy = Program.CurrentUser.Id;
            clientSpouse.UpdatedOn = DateTime.Now;
            clientSpouse.UpdatedBy = Program.CurrentUser.Id;
            clientSpouse.MachineName = System.Environment.MachineName;
            return clientSpouse;
        }

        private static Client fetchClientInformation(Excel.Worksheet excelSheet)
        {
            Client client = new Client();
            for (int row = 10; row < 22; row++)
            {
                //string clientName, gender,marritalstatus, panCard, aadharCard, POB, fatherName, montherName;
                Excel.Range rng = (Excel.Range)excelSheet.Cells[row, 6];
                if (row == 10)
                    client.Name = rng.Value;
                else if (row == 11)
                    client.DOB = rng.Value == null ? new DateTime() : ((DateTime)rng.Value);
                else if (row == 12)
                    client.Gender = (((string)rng.Value).ToUpper().Equals("MALE") || ((string)rng.Value).ToUpper().Equals("M")) ? "Male" : "Female";
                else if (row == 14)
                    client.IsMarried = ((string)rng.Value).ToUpper().Equals("MARRIED") ? true : false;
                else if (row == 15)
                    client.PAN = rng.Value;
                else if (row == 16)
                    client.Aadhar = rng.Value;
                else if (row == 17)
                    client.PlaceOfBirth = rng.Value;
                else if (row == 18)
                    client.FatherName = rng.Value;
                else if (row == 19)
                    client.MotherName = rng.Value;
            }
            client.IsActive = true;
            client.IsDeleted = false;
            client.CreatedOn = DateTime.Now;
            client.CreatedBy = Program.CurrentUser.Id;
            client.UpdatedOn = DateTime.Now;
            client.UpdatedBy = Program.CurrentUser.Id;
            client.MachineName = System.Environment.MachineName;
            return client;
        }

        public ClientContact GetClientContact()
        {
            ClientContact clientContact = new ClientContact();
            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("1.PERSONAL DETAILS"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    excelSheet.Activate();
                    Excel.Range xlRange = excelSheet.UsedRange;
                    for (int row = 25; row < 32; row++)
                    {
                        //string clientName, gender,marritalstatus, panCard, aadharCard, POB, fatherName, montherName;
                        Excel.Range rng = (Excel.Range)excelSheet.Cells[row, 6];
                        if (row == 25)
                            clientContact.Add1 = (rng.Value == null) ? "" : rng.Value;
                        else if (row == 26)
                            clientContact.Street = (rng.Value == null) ? "" : rng.Value;
                        else if (row == 27)
                            clientContact.City = (rng.Value == null) ? "" : rng.Value;
                        else if (row == 28)
                            clientContact.State = (rng.Value == null) ? "" : rng.Value;
                        else if (row == 29)
                            clientContact.Pin = rng.Value != null ? Convert.ToString(rng.Value) : "";
                        else if (row == 30)
                        {
                            clientContact.Email = rng.Value;
                            clientContact.PrimaryEmail = rng.Value;
                        }

                        else if (row == 31)
                        {
                            clientContact.Mobile = rng.Value != null ? Convert.ToString(rng.Value) : "";
                            clientContact.PrimaryMobile = clientContact.Mobile;
                        }
                    }
                    break;
                }
            }
            clientContact.Area = "";
            clientContact.PreferedTime = "";
            clientContact.CreatedOn = DateTime.Now;
            clientContact.CreatedBy = Program.CurrentUser.Id;
            clientContact.UpdatedOn = DateTime.Now;
            clientContact.UpdatedBy = Program.CurrentUser.Id;
            clientContact.MachineName = System.Environment.MachineName;
            clientContact.UpdatedByUserName = Program.CurrentUser.UserName;
            return clientContact;
        }

        public void CloseFile()
        {
            xlApp.DisplayAlerts = false;
            xlWorkbook.Save();
            xlWorkbook.Close();
            xlApp.DisplayAlerts = true;
            xlApp.Quit();
        }

        internal Employment GetEmployment()
        {
            Employment employment = new Employment();

            employment.ClientEmployment = getClientEmployment();
            employment.SpouseEmployment = getSpouseEmployment();
            return employment;
        }

        private ClientEmployment getClientEmployment()
        {
            ClientEmployment clientEmployment = new ClientEmployment();

            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("1.PERSONAL DETAILS"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    excelSheet.Activate();
                    Excel.Range xlRange = excelSheet.UsedRange;
                    for (int row = 36; row <= 42; row++)
                    {
                        Excel.Range rng = (Excel.Range)excelSheet.Cells[row, 6];
                        if (row == 36)
                            clientEmployment.Designation = rng.Value;
                        else if (row == 37)
                            clientEmployment.EmployerName = rng.Value;
                        else if (row == 38)
                            clientEmployment.Address = rng.Value;
                        else if (row == 39)
                            clientEmployment.Street = rng.Value;
                        else if (row == 40)
                            clientEmployment.City = rng.Value;
                        else if (row == 41)
                        {

                        }
                        else if (row == 42)
                            clientEmployment.Pin = rng.Value != null ? Convert.ToString(rng.Value) : "";
                    }
                    break;
                }
            }
            clientEmployment.CreatedOn = DateTime.Now;
            clientEmployment.CreatedBy = Program.CurrentUser.Id;
            clientEmployment.UpdatedOn = DateTime.Now;
            clientEmployment.UpdatedBy = Program.CurrentUser.Id;
            clientEmployment.MachineName = System.Environment.MachineName;
            clientEmployment.UpdatedByUserName = Program.CurrentUser.UserName;
            return clientEmployment;
        }

        private SpouseEmployment getSpouseEmployment()
        {
            SpouseEmployment spouseEmployment = new SpouseEmployment();

            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("1.PERSONAL DETAILS"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    excelSheet.Activate();
                    Excel.Range xlRange = excelSheet.UsedRange;

                    for (int row = 36; row <= 42; row++)
                    {
                        Excel.Range rng = (Excel.Range)excelSheet.Cells[row, 10];
                        if (row == 36)
                            spouseEmployment.Designation = rng.Value;
                        else if (row == 37)
                            spouseEmployment.EmployerName = rng.Value;
                        else if (row == 38)
                            spouseEmployment.Address = rng.Value;
                        else if (row == 39)
                            spouseEmployment.Street = rng.Value;
                        else if (row == 40)
                            spouseEmployment.City = rng.Value;
                        else if (row == 41)
                        {

                        }
                        else if (row == 42)
                            spouseEmployment.Pin = rng.Value != null ? Convert.ToString(rng.Value) : "";
                    }
                    break;
                }
            }
            spouseEmployment.CreatedOn = DateTime.Now;
            spouseEmployment.CreatedBy = Program.CurrentUser.Id;
            spouseEmployment.UpdatedOn = DateTime.Now;
            spouseEmployment.UpdatedBy = Program.CurrentUser.Id;
            spouseEmployment.MachineName = System.Environment.MachineName;
            spouseEmployment.UpdatedByUserName = Program.CurrentUser.UserName;
            return spouseEmployment;
        }

        internal List<FamilyMember> GetFamilyMember()
        {
            //2.Family Details
            List<FamilyMember> familyMembers = new List<FamilyMember>();
            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("2.FAMILY DETAILS"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    Excel.Range xlRange = excelSheet.UsedRange;

                    for (int row = 10; row <= 18; row++)
                    {
                        FamilyMember familyMember = new FamilyMember();
                        bool addToList = true;
                        for (int col = 2; col <= 25; col++)
                        {
                            Excel.Range rng = (Excel.Range)excelSheet.Cells[row, col];
                            if (col == 2 && rng.Value == null)
                            {
                                addToList = false;
                                break;
                            }
                            else
                            {
                                addToList = true;
                            }
                            if (col == 2)
                            {
                                familyMember.Name = rng.Value;
                            }
                            else if (col == 6)
                            {
                                familyMember.Relationship = rng.Value;
                            }
                            else if (col == 10)
                            {
                                familyMember.DOB = (rng.Value != null) ? (DateTime)rng.Value : new DateTime?();
                            }
                            else if (col == 18)
                            {
                                if (rng.Value != null)
                                    familyMember.IsDependent = Convert.ToString(rng.Value).Equals("Yes") ? true : false;
                            }
                            else if (col == 22)
                            {
                                familyMember.ChildrenClass = rng.Value != null ? Convert.ToString(rng.Value) : "";
                            }
                            else if (col == 25)
                            {
                                if (rng.Value != null)
                                    familyMember.IsHuf = Convert.ToString(rng.Value).Equals("Yes") ? false : true;
                            }
                        }
                        familyMember.CreatedOn = DateTime.Now;
                        familyMember.CreatedBy = Program.CurrentUser.Id;
                        familyMember.UpdatedOn = DateTime.Now;
                        familyMember.UpdatedBy = Program.CurrentUser.Id;
                        familyMember.MachineName = System.Environment.MachineName;
                        familyMember.UpdatedByUserName = Program.CurrentUser.UserName;
                        if (addToList)
                            familyMembers.Add(familyMember);
                    }
                    break;
                }
            }
            return familyMembers;
        }

        internal List<Goals> GetGoals()
        {

            List<Goals> goals = new List<Goals>();
            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("3.GOAL SHEET"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    Excel.Range xlRange = excelSheet.UsedRange;

                    for (int row = 31; row < 48; row++)
                    {
                        Goals goal = new Goals();
                        bool addToList = true;
                        for (int col = 2; col <= 30; col++)
                        {
                            Excel.Range rng = (Excel.Range)excelSheet.Cells[row, col];
                            if (col == 2 && rng.Value == null)
                            {
                                addToList = false;
                                break;
                            }
                            else
                            {
                                addToList = true;
                            }
                            if (col == 2)
                            {
                                goal.Name = rng.Value;
                            }
                            else if (col == 6)
                            {
                                goal.Category = rng.Value;
                            }
                            else if (col == 7)
                            {
                                goal.Amount = Convert.ToDouble(rng.Value);
                            }
                            else if (col == 11)
                            {
                                if (rng.Value != null)
                                    goal.StartYear = Convert.ToString(rng.Value);
                            }
                            else if (col == 15)
                            {
                                goal.EndYear = Convert.ToString(rng.Value);
                            }
                            else if (col == 19)
                            {
                                goal.Recurrence = (rng.Value != null) ? Convert.ToInt16(rng.Value) : 1;
                            }
                            else if (col == 23)
                            {
                                if (rng.Value != null)
                                    goal.Priority = (int)(rng.Value);
                            }
                            else if (col == 26)
                            {
                                if (rng.Value != null)
                                    goal.EligibleForInsuranceCoverage = Convert.ToString(rng.Value).Equals("Yes") ? true : false;
                            }
                            else if (col == 27)
                            {
                                if (rng.Value != null)
                                    goal.InflationRate = Convert.ToDecimal(rng.Value);
                            }
                            else if (col == 30)
                            {
                                goal.Description = rng.Value;
                            }
                        }
                        goal.CreatedOn = DateTime.Now;
                        goal.CreatedBy = Program.CurrentUser.Id;
                        goal.UpdatedOn = DateTime.Now;
                        goal.UpdatedBy = Program.CurrentUser.Id;
                        goal.MachineName = System.Environment.MachineName;
                        goal.UpdatedByUserName = Program.CurrentUser.UserName;
                        if (addToList)
                            goals.Add(goal);
                    }
                    break;
                }
            }
            return goals;
        }

        internal List<Loan> GetLoan()
        {
            List<Loan> loans = new List<Loan>();
            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("5.LOANS"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    Excel.Range xlRange = excelSheet.UsedRange;

                    for (int row = 10; row < 19; row++)
                    {
                        Loan loan = new Loan();
                        bool addToList = true;
                        for (int col = 2; col <= 28; col++)
                        {
                            Excel.Range rng = (Excel.Range)excelSheet.Cells[row, col];
                            if (col == 2 && rng.Value == null)
                            {
                                addToList = false;
                                break;
                            }
                            else
                            {
                                addToList = true;
                            }
                            if (col == 2)
                            {
                                loan.TypeOfLoan = rng.Value;
                            }
                            else if (col == 6)
                            {
                                loan.OutstandingAmt = Convert.ToDouble(rng.Value);
                            }
                            else if (col == 10)
                            {
                                loan.Emis = (int)(rng.Value);
                            }
                            else if (col == 14)
                            {
                                if (rng.Value != null)
                                    loan.InterestRate = Convert.ToDecimal(rng.Value);
                            }
                            else if (col == 18)
                            {
                                loan.TermLeftInMonths = (int)(rng.Value);
                            }
                            else if (col == 25)
                            {
                                loan.LoanStartDate = (rng.Value != null) ? Convert.ToDateTime(rng.Value) : new DateTime();
                            }
                            else if (col == 28)
                            {
                                loan.Description = rng.Value;
                            }
                        }
                        loan.CreatedOn = DateTime.Now;
                        loan.CreatedBy = Program.CurrentUser.Id;
                        loan.UpdatedOn = DateTime.Now;
                        loan.UpdatedBy = Program.CurrentUser.Id;
                        loan.MachineName = System.Environment.MachineName;
                        loan.UpdatedByUserName = Program.CurrentUser.UserName;
                        if (addToList)
                            loans.Add(loan);
                    }
                    break;
                }
            }
            return loans;
        }

        internal List<NonFinancialAsset> GetNonFinancialAsset(int plannerId,PersonalInformation personalInformation)
        {
            List<NonFinancialAsset> nonFinancialAssets = new List<NonFinancialAsset>();
            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("6.NON-FINANCIAL ASSETS"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    Excel.Range xlRange = excelSheet.UsedRange;

                    for (int row = 12; row < 33; row++)
                    {
                        NonFinancialAsset nonFinancialAsset = new NonFinancialAsset();
                        bool addToList = true;
                        for (int col = 2; col <= 26; col++)
                        {
                            Excel.Range rng = (Excel.Range)excelSheet.Cells[row, col];
                            if (col == 2 && rng.Value == null)
                            {
                                addToList = false;
                                break;
                            }
                            else
                            {
                                addToList = true;
                            }
                            if (col == 2)
                            {
                                nonFinancialAsset.Name = rng.Value;
                            }
                            else if (col == 6)
                            {
                                nonFinancialAsset.CurrentValue = Convert.ToDouble(rng.Value);
                            }
                            else if (col == 10)
                            {
                                if (rng.Value != null)
                                {
                                    if (Convert.ToString(rng.Value).ToUpper().Equals(personalInformation.Client.Name.ToUpper()))
                                    {
                                        
                                        Excel.Range primaryShare = (Excel.Range)excelSheet.Cells[row,14];
                                        nonFinancialAsset.PrimaryholderShare = (int)(primaryShare.Value);
                                    }
                                    else 
                                    {
                                        nonFinancialAsset.OtherHolderName = rng.Value;
                                        Excel.Range primaryShare = (Excel.Range)excelSheet.Cells[row,14];
                                        nonFinancialAsset.OtherHolderShare = (int)(primaryShare.Value);
                                    }
                                }
                               
                            }
                            else if (col == 16)
                            {
                                if (rng.Value != null)
                                {
                                     if (Convert.ToString(rng.Value).ToUpper().Equals(personalInformation.Spouse.Name.ToUpper()))
                                    {

                                        Excel.Range secondaryShare = (Excel.Range)excelSheet.Cells[row,20];
                                        nonFinancialAsset.SecondaryHolderShare = (int)(secondaryShare.Value);
                                    }
                                    else
                                    {
                                        nonFinancialAsset.OtherHolderName = rng.Value;
                                        Excel.Range secondaryShare = (Excel.Range)excelSheet.Cells[row,20];
                                        if (secondaryShare.Value != null)
                                            nonFinancialAsset.OtherHolderShare = (int) (secondaryShare.Value);
                                    }
                                }



                                   // nonFinancialAsset.SecondaryHolderShare = (int)(rng.Value);
                            }
                            else if (col == 22)
                            {
                                if (rng.Value != null)
                                {
                                    GoalsInfo goalsInfo = new GoalsInfo();
                                    IList<Goals> goals = goalsInfo.GetAll(plannerId);
                                    foreach (Goals goal in goals)
                                    {
                                        if (goal.Name == rng.Value)
                                        {
                                            nonFinancialAsset.MappedGoalId = goal.Id;
                                            Excel.Range shareAllocationToGoal = (Excel.Range)excelSheet.Cells[row,28];
                                            if (rng.Value != null)
                                                nonFinancialAsset.AssetMappingShare = Convert.ToDecimal(rng.Value);
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    nonFinancialAsset.MappedGoalId = 0;
                                }

                            }
                            else if (col == 25)
                            {
                                nonFinancialAsset.AssetRealisationYear = Convert.ToString(rng.Value);
                            }
                            else if (col == 26)
                            {
                                if (rng.Value != null)
                                    nonFinancialAsset.GrowthPercentage = Convert.ToDecimal(rng.Value);
                            }
                            else if (col == 27)
                            {
                                if (rng.Value != null)
                                    nonFinancialAsset.EligibleForInsuranceCover = Convert.ToString(rng.Value).Equals("Yes") ? true : false;
                            }
                            else if (col == 29)
                            {
                                if (rng.Value != null)
                                    nonFinancialAsset.Description = rng.Value;
                            }

                        }
                        nonFinancialAsset.CreatedOn = DateTime.Now;
                        nonFinancialAsset.CreatedBy = Program.CurrentUser.Id;
                        nonFinancialAsset.UpdatedOn = DateTime.Now;
                        nonFinancialAsset.UpdatedBy = Program.CurrentUser.Id;
                        nonFinancialAsset.MachineName = System.Environment.MachineName;
                        nonFinancialAsset.UpdatedByUserName = Program.CurrentUser.UserName;
                        if (addToList)
                            nonFinancialAssets.Add(nonFinancialAsset);
                    }
                    break;
                }
            }
            return nonFinancialAssets;
        }

        internal List<Income> GetIncome()
        {
            List<Income> incomes = new List<Income>();
            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("7.INCOME"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    Excel.Range xlRange = excelSheet.UsedRange;

                    for (int row = 10; row < 24; row++)
                    {
                        Income income = new Income();
                        bool addToList = true;
                        string incomeByVar = "";
                        if (row < 17)
                        {
                            Excel.Range rngTemp = (Excel.Range)excelSheet.Cells[10, 5];
                            incomeByVar = rngTemp.Value;
                        }
                        else
                        {
                            Excel.Range rngTemp = (Excel.Range)excelSheet.Cells[17, 5];
                            incomeByVar = rngTemp.Value;
                        }
                        if (row != 10 && row != 17)
                        {
                            for (int col = 2; col <= 28; col++)
                            {
                                Excel.Range rng = (Excel.Range)excelSheet.Cells[row, col];
                                if (col == 2 && rng.Value == null)
                                {
                                    addToList = false;
                                    break;
                                }
                                else
                                {
                                    addToList = true;
                                }

                                income.IncomeBy = incomeByVar;

                                if (col == 2)
                                {
                                    income.Source = rng.Value;
                                }
                                else if (col == 7)
                                {
                                    income.Amount = Convert.ToDouble(rng.Value);
                                }
                                else if (col == 15)
                                {
                                    income.ExpectGrowthInPercentage = (rng.Value != null) ? Convert.ToDecimal(rng.Value) : 0;
                                    income.ExpectedGrowthType = (rng.Value != null) ? "P" : "A";
                                }
                                else if (col == 19)
                                {
                                    if (rng.Value != null)
                                    {
                                        income.ExpectedGrwothInAmount = Convert.ToDouble(rng.Value);
                                    }
                                    else
                                    {
                                        income.ExpectedGrwothInAmount = 0;
                                    }
                                }
                                else if (col == 22)
                                {
                                    income.StartYear = Convert.ToString(rng.Value);
                                }
                                else if (col == 25)
                                {
                                    income.EndYear = Convert.ToString(rng.Value);
                                }
                                else if (col == 28)
                                {
                                    if (rng.Value != null)
                                        income.IncomeTax = (float)(rng.Value);
                                }
                            }
                            income.CreatedOn = DateTime.Now;
                            income.CreatedBy = Program.CurrentUser.Id;
                            income.UpdatedOn = DateTime.Now;
                            income.UpdatedBy = Program.CurrentUser.Id;
                            income.MachineName = System.Environment.MachineName;
                            income.UpdatedByUserName = Program.CurrentUser.UserName;
                            if (addToList)
                                incomes.Add(income);
                        }
                    }
                    break;
                }
            }
            return incomes;
        }

        internal List<Expenses> GetExpense()
        {
            List<Expenses> expenses = new List<Expenses>();
            foreach (Excel.Worksheet eSheet in xlWorkbook.Worksheets)
            {
                if (eSheet.Name.ToUpper().Equals("8.EXPENSES"))
                {
                    Excel.Worksheet excelSheet = eSheet;
                    Excel.Range xlRange = excelSheet.UsedRange;
                    int[] excludeRow = new int[] { 13, 14, 24, 25, 34, 35, 40, 41 };
                    //for (int row = 11; row < 52; row++)
                    //{
                    //    Expenses expense = new Expenses();
                    //    bool addToList = true;

                    //    foreach (int val in excludeRow)
                    //    {
                    //        if (val == row)
                    //        {
                    //            addToList = false;
                    //            break;
                    //        }
                    //    }
                    //    if (addToList)
                    //    {
                    //        for (int col = 3; col <= 10; col++)
                    //        {
                    //            Excel.Range rng = (Excel.Range)excelSheet.Cells[row, col];
                    //            if (col == 3 && rng.Value == null)
                    //            {
                    //                addToList = false;
                    //                break;
                    //            }
                    //            else
                    //            {
                    //                addToList = true;
                    //            }

                    //            if (col == 3)
                    //            {
                    //                expense.ItemCategory = rng.Value;
                    //                expense.Item = rng.Value;
                    //            }
                    //            else if (col == 7)
                    //            {
                    //                if (rng.Value != null)
                    //                {
                    //                    expense.Amount = Convert.ToDouble(rng.Value);
                    //                    expense.OccuranceType = ExpenseType.Monthly;
                    //                }
                    //                else
                    //                {
                    //                    addToList = false;
                    //                    break;
                    //                }
                    //            }
                    //            else if (col == 10)
                    //            {
                    //                if (rng.Value != null)
                    //                {
                    //                    expense.InflationRate = ((float)rng.Value);
                    //                }
                    //            }
                    //        }

                    //        expense.ItemCategory = "Ongoing Expense";
                    //        Excel.Range totalExpAmount = (Excel.Range)excelSheet.Cells[53, 7];
                    //        if (totalExpAmount.Value != null)
                    //            expense.Amount = Convert.ToDouble(totalExpAmount.Value);

                    //        Excel.Range rngStartYear = (Excel.Range)excelSheet.Cells[53,10];
                    //        expense.ExpStartYear = Convert.ToString(rngStartYear.Value);
                    //        Excel.Range rngEndYear = (Excel.Range)excelSheet.Cells[53, 13];
                    //        expense.ExpEndYear = Convert.ToString(rngEndYear.Value);
                    //        Excel.Range rngInflationRate = (Excel.Range)excelSheet.Cells[53, 14];
                    //        expense.InflationRate = (rngInflationRate.Value == null) ? 0 : ((float)rngInflationRate.Value);
                    //        expense.CreatedOn = DateTime.Now;
                    //        expense.CreatedBy = Program.CurrentUser.Id;
                    //        expense.UpdatedOn = DateTime.Now;
                    //        expense.UpdatedBy = Program.CurrentUser.Id;
                    //        expense.MachineName = System.Environment.MachineName;
                    //        expense.UpdatedByUserName = Program.CurrentUser.UserName;
                    //        if (addToList)
                    //            expenses.Add(expense);
                    //    }
                    //}
                    //break;
                    Expenses expense = new Expenses();
                    expense.ItemCategory = "Ongoing Expense";
                    Excel.Range totalExpAmount = (Excel.Range)excelSheet.Cells[54, 7];
                    if (totalExpAmount.Value != null)
                        expense.Amount = Convert.ToDouble(totalExpAmount.Value);

                    Excel.Range rngStartYear = (Excel.Range)excelSheet.Cells[54, 10];
                    expense.ExpStartYear = Convert.ToString(rngStartYear.Value);
                    Excel.Range rngEndYear = (Excel.Range)excelSheet.Cells[54, 13];
                    expense.ExpEndYear = Convert.ToString(rngEndYear.Value);
                    Excel.Range rngInflationRate = (Excel.Range)excelSheet.Cells[54, 14];
                    expense.InflationRate = (rngInflationRate.Value == null) ? 0 : ((float)rngInflationRate.Value);
                    expense.CreatedOn = DateTime.Now;
                    expense.CreatedBy = Program.CurrentUser.Id;
                    expense.UpdatedOn = DateTime.Now;
                    expense.UpdatedBy = Program.CurrentUser.Id;
                    expense.MachineName = System.Environment.MachineName;
                    expense.UpdatedByUserName = Program.CurrentUser.UserName;
                    expenses.Add(expense);
                }
            }
            return expenses;
        }
    }
}
