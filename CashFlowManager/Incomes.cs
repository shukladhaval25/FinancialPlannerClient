using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.CashFlowManager
{
    public class Incomes
    {
        int _pid;
        string _incomeBy;
        string _source;
        double _amount;
        decimal _growthBy;

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

        public string IncomeBy
        {
            get
            {
                return _incomeBy;
            }

            set
            {
                _incomeBy = value;
            }
        }

        public string Source
        {
            get
            {
                return _source;
            }

            set
            {
                _source = value;
            }
        }

        public double Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
            }
        }

        public decimal GrowthBy
        {
            get
            {
                return _growthBy;
            }

            set
            {
                _growthBy = value;
            }
        }
    }
}
