using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class MyReminders : Form
    {
        public MyReminders()
        {
            InitializeComponent();
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            FinancialPlannerClient.TaskManagementSystem.CustomAppointmentForm form = new FinancialPlannerClient.TaskManagementSystem.CustomAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

        }

        private void MyReminders_Load(object sender, EventArgs e)
        {
            schedulerControl.Start = DateTime.Now.Date;
        }
    }
}
