using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Production.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace Production.LAMINATION._LAB
{
    public partial class F_Baocao_NhanMau_EXCEL : frm_Base
    {
        private string TenBaocao = "";
        private string filename = "";

        private DataTable dt = new DataTable();

        private PXN_HeaderBUS PXN_BUS = new PXN_HeaderBUS();

        public F_Baocao_NhanMau_EXCEL()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                TenBaocao = "NhanMau_Tonghop";

                //ComboBoxItemCollection coll = cmbFilter.Properties.Items;
                //coll.BeginUpdate();
                //try
                //{
                //    coll.Add("From...to...");
                //    coll.Add("Yesterday");
                //    coll.Add("Today");
                //    coll.Add("Next week");
                //    coll.Add("This week");
                //    coll.Add("Last week");
                //    coll.Add("Next month");
                //    coll.Add("This month");
                //    coll.Add("Last month");
                //    coll.Add("Next quater");
                //    coll.Add("This quater");
                //    coll.Add("Last quater");
                //    coll.Add("Next year");
                //    coll.Add("This year");
                //    coll.Add("Last year");
                //}
                //finally
                //{
                //    coll.EndUpdate();
                //}

                if (PCname == "vpv-lab-sample")
                    path = @"D:\\" + TenBaocao + DateTime.Today.ToShortDateString().Replace("/", "_") + ".xlsx";
                else
                    path = @"X:\\" + TenBaocao + DateTime.Today.ToShortDateString().Replace("/", "_") + ".xlsx";
                
                
                //dteFrDate.ReadOnly = true;
                //dteToDate.ReadOnly = true;
            };

            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                //GridView view = sender as GridView;
                //if (e.Column.FieldName == "STT" && e.IsGetData)
                //    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };

            gridView1.CellValueChanged += (s, e) =>
            {
                e.Column.BestFit();
            };

            // 7 Add hoặc New
            filter_Vertical1.Find(new EventHandler(EventHandler_Find));
            filter_Vertical1.Excel(new EventHandler(EventHandler_Excel));
            filter_Vertical1.Exit(new EventHandler(EventHandler_Exit));

                  
        }

        private void EventHandler_Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EventHandler_Excel(object sender, EventArgs e)
        {
            try
            {

                //filename = @"X:\\" + TenBaocao + DateTime.Today.ToShortDateString().Replace("/", "_") + ".xlsx";
                //Export excel file
                gridControl1.ExportToXlsx(path);
                //Open excel file
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                string _error = ex.Message;
                MessageBox.Show(_error);
                throw;
            }
        }

        private void EventHandler_Find(object sender, EventArgs e)
        {
            //XtraMessageBox.Show();
            dt.Clear();

            switch (filter_Vertical1.cmbOption_SelectedText.ToString())
            {
                case ("From...to..."):
                    //dt = PXN_BUS.BaoCao_NhanMau_Fr_To_Date(filter_Vertical1.dteFrDateVal, filter_Vertical1.dteToDateVal);
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_NhanMau_Fr_To_Date(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, filter_Vertical1.dteFrDateVal.ToString(), filter_Vertical1.dteToDateVal.ToString());
                    break;
                case ("Next day"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhamMau_Daily(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau,1);
                    break;
                case ("Today"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhamMau_Daily(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, 0);
                    break;
                case ("Last day"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhamMau_Daily(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, -1);
                    break;
                case ("Next week"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Weekly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, 1);
                    break;
                case ("This week"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Weekly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, 0);
                    break;
                case ("Last week"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Weekly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, -1);
                    break;
                case ("Next month"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Monthly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, 1);
                    break;
                case ("This month"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Monthly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, 0);
                    break;
                case ("Last month"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Monthly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, -1);
                    break;
                case ("Next quater"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Quaterly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, 1);
                    break;
                case ("This quater"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Quaterly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, 0);
                    break;
                case ("Last quater"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Quaterly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, -1);
                    break;
                case ("Next year"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Yearly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, 1);
                    break;
                case ("This year"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Yearly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, 0);
                    break;
                case ("Last year"):
                    gridControl1.DataSource = baoCao_PhieuNhanMauTableAdapter.Fill_BaoCao_PhieuNhanMau_Yearly(sYNC_NUTRICIEL_REPORT.BaoCao_PhieuNhanMau, -1);
                    break;
            }
            //this.gridControl1.DataSource = dt; //POH_BUS.PO_List_Report(DateTime.Parse(dteFrDate.Text), DateTime.Parse(dteToDate.Text));
                                               //GridColumn colCounter = gridView1.Columns.AddVisible("STT");
                                               //colCounter.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                                               //colCounter.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                                               //colCounter.VisibleIndex = 0;
        }

    }
}