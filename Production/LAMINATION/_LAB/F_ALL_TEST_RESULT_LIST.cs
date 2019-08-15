using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_ALL_TEST_RESULT_LIST : UC_Base
    {
        private MYCOTOXIN_RESULT_Lines OBJLines = new MYCOTOXIN_RESULT_Lines();
        private MYCOTOXIN_RESULT_Header OBJHeader = new MYCOTOXIN_RESULT_Header();

        private MYCOTOXIN_RESULT_LinesBUS BUSLines = new MYCOTOXIN_RESULT_LinesBUS();
        private MYCOTOXIN_RESULT_HeaderBUS BUSHeader = new MYCOTOXIN_RESULT_HeaderBUS();

        private CSVFromToDataTable XLSX = new CSVFromToDataTable();

        private SplashScreen1 Splash = new SplashScreen1();

        /// <summary>
        /// DELEGATE
        /// </summary>
        public delegate void MyAdd(object sender);

        public event MyAdd myFinished;

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this);
                    //myFinished?.Invoke(sender: this);
                }
            }
        }

        public F_ALL_TEST_RESULT_LIST()
        {
            InitializeComponent();

            Load += (s, e) =>
                {
                    this.f_ALL_TEST_RESULT_LISTTableAdapter.Fill(sYNC_NUTRICIELDataSet.F_ALL_TEST_RESULT_LIST);
                };
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
        }

        //private string[] ConvertToStringArray(System.Array values)
        //{
        //    // create a new string array
        //    string[] theArray = new string[values.Length];

        //    // loop through the 2-D System.Array and populate the 1-D String Array
        //    for (int i = 1; i <= values.Length; i++)
        //    {
        //        if (values.GetValue(1, i) == null)
        //            theArray[i - 1] = "";
        //        else
        //            theArray[i - 1] = (string)values.GetValue(1, i).ToString();
        //    }
        //    return theArray;
        //}
        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            try
            {
                F_MYCOTOXIN_RESULT_Details FRM = new F_MYCOTOXIN_RESULT_Details();
                FRM.isAction = "Add";
                FRM.myFinished += this.finished;
                FRM.Show();
            }
            catch (Exception ex)
            {
                string _error = ex.Message;
                MessageBox.Show(_error);
                throw;
            }
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
        }

        public void finished(object sender)
        {
            //Enable
            this.Enabled = true;
            //
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            this.Visible = true;

            // Step 2 : Load lại data tren grid sau khi Add

            gridView1.BestFitColumns();
        }

        //StandardCurve

        private void repositoryItemButtonEdit2_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                R_MYCOTOXIN_RESULT_LAB_ANALYSISREPORT FRM = new R_MYCOTOXIN_RESULT_LAB_ANALYSISREPORT();
                FRM.MaCTXN = gridView1.GetFocusedRowCellValue("MaCTXN").ToString();
                FRM.SoPXN = gridView1.GetFocusedRowCellValue("SoPXN").ToString();
                FRM.Show();
            }
        }
    }
}