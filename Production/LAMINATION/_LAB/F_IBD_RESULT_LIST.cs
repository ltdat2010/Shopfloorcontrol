using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_IBD_RESULT_LIST : UC_Base
    {
        //BUS
        private IBD_RESULT_Header_LABBUS BUSHeader = new IBD_RESULT_Header_LABBUS();
        private IBD_RESULT_Lines_LABBUS BUSLines = new IBD_RESULT_Lines_LABBUS();
        private IBD_RESULT_Summary_LABBUS BUSSummary = new IBD_RESULT_Summary_LABBUS();

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

        public F_IBD_RESULT_LIST()
        {
            InitializeComponent();

            Load += (s, e) =>
                {
                    this.tbl_IBD_RESULT_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_IBD_RESULT_Header_LAB);
                };
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action1.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete));
        }
        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa kết quả " + gridView1.GetFocusedRowCellValue("FileName").ToString() + " ? . Lưu ý : Dữ liệu sẽ không thể phục hồi.", "Xác nhận xóa", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                BUSSummary.IBD_RESULT_Summary_LABDAO_DELETE(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()));
                BUSLines.IBD_RESULT_Lines_LABDAO_DELETE(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()));
                BUSHeader.IBD_RESULT_Header_LABDAO_DELETE(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()));
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 1000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Xóa ";
                args.Text = "Xóa thành công . Thông báo này sẽ tự đóng sau 1 giây .";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
                this.tbl_IBD_RESULT_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_IBD_RESULT_Header_LAB);
                gridView1.BestFitColumns();
            }

        }
        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            try
            {
                F_IBD_RESULT_Details FRM = new F_IBD_RESULT_Details();
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
            this.tbl_IBD_RESULT_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_IBD_RESULT_Header_LAB);
            gridView1.BestFitColumns();
        }

        //StandardCurve
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                R_IBD_RESULT_LAB_ANALYSISREPORT FRM = new R_IBD_RESULT_LAB_ANALYSISREPORT();
                //FRM.ID = int.Parse(gridView1.GetFocusedRowCellValue("MYCOTOXIN_RESULT_Header_ID").ToString());
                //FRM.acr = gridView1.GetFocusedRowCellValue("Acronym").ToString();
                //FRM.RptName = "Rpt_AI_RESULT_LAB";
                FRM.Show();
            }
            
        }

        
    }
}