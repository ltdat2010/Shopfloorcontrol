using System;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_AI_RESULT_LIST : UC_Base
    {
        private MYCOTOXIN_RESULT_Lines OBJLines = new MYCOTOXIN_RESULT_Lines();
        private MYCOTOXIN_RESULT_Header OBJHeader = new MYCOTOXIN_RESULT_Header();

        private MYCOTOXIN_RESULT_LinesBUS BUSLines = new MYCOTOXIN_RESULT_LinesBUS();
        private MYCOTOXIN_RESULT_HeaderBUS BUSHeader = new MYCOTOXIN_RESULT_HeaderBUS();

        private CSVFromToDataTable XLSX = new CSVFromToDataTable();

        private SplashScreen1 Splash = new SplashScreen1();

        private string Path = Directory.GetCurrentDirectory();

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

        public F_AI_RESULT_LIST()
        {
            InitializeComponent();

            Load += (s, e) =>
                {
                    this.tbl_MYCOTOXIN_RESULT_StandardCurve_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_StandardCurve_LAB);
                    this.tbl_MYCOTOXIN_RESULT_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Header_LAB);
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
                F_AI_RESULT_Details FRM = new F_AI_RESULT_Details();
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
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                R_AI_RESULT FRM = new R_AI_RESULT();
                //FRM.ID = int.Parse(gridView1.GetFocusedRowCellValue("MYCOTOXIN_RESULT_Header_ID").ToString());
                //FRM.acr = gridView1.GetFocusedRowCellValue("Acronym").ToString();
                //FRM.RptName = "Rpt_AI_RESULT_LAB";
                FRM.Show();
            }
            else if (e.Button.Index == 1)
            {
                R_AI_RESULT FRM = new R_AI_RESULT();
                //FRM.ID = int.Parse(gridView1.GetFocusedRowCellValue("MYCOTOXIN_RESULT_Header_ID").ToString());
                //FRM.acr = gridView1.GetFocusedRowCellValue("Acronym").ToString();
                //FRM.RptName = "Rpt_AI_RESULT_LAB";
                FRM.Show();
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                R_AI_RESULT FRM = new R_AI_RESULT();
                //FRM.ID = int.Parse(gridView1.GetFocusedRowCellValue("MYCOTOXIN_RESULT_Header_ID").ToString());
                //FRM.acr = gridView1.GetFocusedRowCellValue("Acronym").ToString();
                //FRM.RptName = "Rpt_AI_RESULT_LAB";
                FRM.Show();
            }
        }
    }
}