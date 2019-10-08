using System.Data;
using System.IO;

namespace Production.Class
{
    public partial class R_BaoCaoHTH_CTXN : frm_Base
    {
        public string OF = "";
        public string TotalBatchNb = "";

        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        private bool val = false;

        private string Path = Directory.GetCurrentDirectory();
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_BaoCaoHTH_CTXN()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //dteYear.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            };
            simpleButton1.Click += (s, e) =>
                {
                    R_BaoCao_HuyetThanhHoc_EXCEL FRM = new R_BaoCao_HuyetThanhHoc_EXCEL();
                    DataRowView row = (DataRowView)lkeCTXN.GetSelectedDataRow();
                    FRM.CTXN_ID = int.Parse(row["ID"].ToString());
                    //XtraMessageBox.Show(dteYear.EditValue.ToString().Substring(dteYear.SelectedText.ToString().Length - 4, 4));
                    FRM.year = dteYear.SelectedText.ToString();
                    //RFGDate.ToDate = DEToDate.SelectedText.ToString();
                    FRM.Show();
                    this.Close();
                };
        }

        private void R_BaoCaoHTH_CTXN_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB' table. You can move, or remove it, as needed.
            this.tbl_ChiTieuXetNghiem_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB);
        }
    }
}