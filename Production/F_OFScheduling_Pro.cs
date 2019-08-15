using DevExpress.XtraScheduler;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Production.Class
{
    public partial class F_OFScheduling_Pro : frm_Base
    {
        private OFBUS OFB = new OFBUS();

        public F_OFScheduling_Pro()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                schedulerStorage1.AppointmentsInserted += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentsInserted);
                schedulerStorage1.AppointmentsChanged += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentsChanged);
                schedulerStorage1.AppointmentsDeleted += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentsDeleted);

                schedulerStorage1.AppointmentDependenciesInserted += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentDependenciesInserted);
                schedulerStorage1.AppointmentDependenciesChanged += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentDependenciesChanged);
                schedulerStorage1.AppointmentDependenciesDeleted += new PersistentObjectsEventHandler(schedulerStorage1_AppointmentDependenciesDeleted);

                schedulerStorage1.Appointments.CommitIdToDataSource = false;
                this.appointmentsTableAdapter.Adapter.RowUpdated += new SqlRowUpdatedEventHandler(appointmentsTableAdapter_RowUpdated);

                // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.Appointments' table. You can move, or remove it, as needed.
                this.appointmentsTableAdapter.FillByThisWeek(this.sYNC_NUTRICIELDataSet.Appointments);
                // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.TaskDependencies' table. You can move, or remove it, as needed.
                //this.taskDependenciesTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.TaskDependencies);
                // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.Resources' table. You can move, or remove it, as needed.
                //this.resourcesTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.Resources);
                //foreach (DataRow dr in this.sYNC_NUTRICIELDataSet.Tables["Appointments"].Rows)
                // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.Resources' table. You can move, or remove it, as needed.
                this.resourcesTableAdapter.FillByThisWeek(this.sYNC_NUTRICIELDataSet.Resources);
                //schedulerControl1.Start = DateTime.Parse(dtestr.ToString());
            };

            btnView.Click += (s, e) =>
                {
                    // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.Appointments' table. You can move, or remove it, as needed.
                    this.appointmentsTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.Appointments, DateTime.Parse(dtestr.SelectedText), DateTime.Parse(dteend.SelectedText));
                    // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.TaskDependencies' table. You can move, or remove it, as needed.
                    //this.taskDependenciesTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.TaskDependencies);
                    // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.Resources' table. You can move, or remove it, as needed.
                    //this.resourcesTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.Resources);
                    //foreach (DataRow dr in this.sYNC_NUTRICIELDataSet.Tables["Appointments"].Rows)
                    // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.Resources' table. You can move, or remove it, as needed.
                    this.resourcesTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.Resources, DateTime.Parse(dtestr.SelectedText), DateTime.Parse(dteend.SelectedText));
                    //schedulerControl1.Start = DateTime.Parse(dtestr.ToString());
                };
        }

        private void F_OFScheduling_Pro_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.TaskDependencies' table. You can move, or remove it, as needed.
            //this.taskDependenciesTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.TaskDependencies);
            //// TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.Resources' table. You can move, or remove it, as needed.
            //this.resourcesTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.Resources);
            //// TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.Appointments' table. You can move, or remove it, as needed.
            //this.appointmentsTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.Appointments);
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            CommitTask();
        }

        private void schedulerStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            CommitTask();
        }

        private void schedulerStorage1_AppointmentsInserted(object sender, PersistentObjectsEventArgs e)
        {
            CommitTask();
            schedulerStorage1.SetAppointmentId(((Appointment)e.Objects[0]), id);
        }

        private void CommitTask()
        {
            appointmentsTableAdapter.Update(sYNC_NUTRICIELDataSet);
            this.sYNC_NUTRICIELDataSet.AcceptChanges();
        }

        private void schedulerStorage1_AppointmentDependenciesChanged(object sender, PersistentObjectsEventArgs e)
        {
            CommitTaskDependency();
        }

        private void schedulerStorage1_AppointmentDependenciesDeleted(object sender, PersistentObjectsEventArgs e)
        {
            CommitTaskDependency();
        }

        private void schedulerStorage1_AppointmentDependenciesInserted(object sender, PersistentObjectsEventArgs e)
        {
            CommitTaskDependency();
        }

        private void CommitTaskDependency()
        {
            taskDependenciesTableAdapter.Update(this.sYNC_NUTRICIELDataSet);
            this.sYNC_NUTRICIELDataSet.AcceptChanges();
        }

        private int id = 0;

        private void appointmentsTableAdapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert)
            {
                id = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT @@IDENTITY", appointmentsTableAdapter.Connection))
                {
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    e.Row["UniqueId"] = id;
                }
            }
        }

        private void btnOF_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.appointmentsTableAdapter.FillByCD_OF(this.sYNC_NUTRICIELDataSet.Appointments, btnOF.EditValue.ToString());
            this.resourcesTableAdapter.FillByCD_OF(this.sYNC_NUTRICIELDataSet.Resources, btnOF.EditValue.ToString());
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            Production.CustomAppointmentForm form = new Production.CustomAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
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
    }
}