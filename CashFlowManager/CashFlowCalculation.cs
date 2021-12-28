﻿using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.CashFlowManager
{
    public class CashFlowCalculation
    {
        int _pid;
        int _cid;
        int _sid;
        string _clientName;
        string _spouseName;
        DateTime _clientDateOfBirth;
        DateTime _spouseDateOfBirth;
        int _clientCurrentAge;
        int _spouseCurrentAge;
        int _clientLifeExpected;
        int _spouseLifeExpected;
        int _clientRetirementAge;
        int _spouseRetirementAge;        
        IList<Income> lstIncomes;
        IList<Expenses> lstExpenses;
        IList<LifeInsurance> lifeInsurances;
        IList<GeneralInsurance> generalInsurances;
        IList<Loan> lstLoans;
        IList<Goals> lstGoals;
        int _planStartYear;
        private bool _islientRetirmentAgeForPrimaryCalculation;

        public int Pid
        {
            get
            {
                return _pid;
            }

            set
            {
                _pid = value;
            }
        }

        public int Cid
        {
            get
            {
                return _cid;
            }

            set
            {
                _cid = value;
            }
        }

        public int Sid
        {
            get
            {
                return _sid;
            }

            set
            {
                _sid = value;
            }
        }

        public string ClientName
        {
            get
            {
                return _clientName;
            }

            set
            {
                _clientName = value;
            }
        }

        public string SpouseName
        {
            get
            {
                return _spouseName;
            }

            set
            {
                _spouseName = value;
            }
        }

        public DateTime ClientDateOfBirth
        {
            get
            {
                return _clientDateOfBirth;
            }

            set
            {
                _clientDateOfBirth = value;
            }
        }

        public DateTime SpouseDateOfBirth
        {
            get
            {
                return _spouseDateOfBirth;
            }

            set
            {
                _spouseDateOfBirth = value;
            }
        }

        public int ClientCurrentAge
        {
            get
            {
                _clientCurrentAge = this.PlanStartYear - _clientDateOfBirth.Year;
                return _clientCurrentAge;
            }           
        }

        public int SpouseCurrentAge
        {
            get
            {
                _spouseCurrentAge = this.PlanStartYear - _spouseDateOfBirth.Year;
                return _spouseCurrentAge;
            }
        }

        public int ClientLifeExpected
        {
            get
            {
                return _clientLifeExpected;
            }

            set
            {
                _clientLifeExpected = value;
            }
        }

        public int SpouseLifeExpected
        {
            get
            {
                return _spouseLifeExpected;
            }

            set
            {
                _spouseLifeExpected = value;
            }
        }

        public IList<Income> LstIncomes
        {
            get
            {
                return lstIncomes;
            }

            set
            {
                lstIncomes = value;
            }
        }

        public int ClientRetirementAge
        {
            get
            {
                return _clientRetirementAge;
            }

            set
            {
                _clientRetirementAge = value;
            }
        }

        public int SpouseRetirementAge
        {
            get
            {
                return _spouseRetirementAge;
            }

            set
            {
                _spouseRetirementAge = value;
            }
        }

        public IList<Expenses> LstExpenses
        {
            get
            {
                return lstExpenses;
            }

            set
            {
                lstExpenses = value;
            }
        }

        public IList<Loan> LstLoans
        {
            get
            {
                return lstLoans;
            }

            set
            {
                lstLoans = value;
            }
        }

        public IList<Goals> LstGoals
        {
            get
            {
                return lstGoals;
            }

            set
            {
                lstGoals = value;
            }
        }

        public IList<LifeInsurance> LstLifeInsurances
        {
            get { return lifeInsurances; }
            set { lifeInsurances = value; }
        }

        public IList<GeneralInsurance> LstGeneralInsurances
        {
            get { return generalInsurances; }
            set { generalInsurances = value; }
        }

        public int PlanStartYear
        {
            get
            {
                return _planStartYear;
            }

            set
            {
                _planStartYear = value;
            }
        }

        public bool IslientRetirmentAgeForPrimaryCalculation { get => _islientRetirmentAgeForPrimaryCalculation; set => _islientRetirmentAgeForPrimaryCalculation = value; }
    }
}
