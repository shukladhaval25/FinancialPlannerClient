using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class RecomendationView : DevExpress.XtraEditors.XtraForm
    {
        Client client;
        Planner planner;
        public RecomendationView(Client client,Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
        }
    }
}
