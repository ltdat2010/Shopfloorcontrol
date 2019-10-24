using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Production.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace Production.LAMINATION._LAB
{
    public partial class F_BaocaoPO_EXCEL : frm_Base
    {
        private string TenBaocao = "";
        private string filename = "";

        private DataTable dt = new DataTable();

        private PO_Header_BUS POH_BUS = new PO_Header_BUS();

        public F_BaocaoPO_EXCEL()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                TenBaocao = "PO_Tonghop";

                if (PCname == "vpv-lab-sample")
                    path = @"D:\\" + TenBaocao + DateTime.Today.ToShortDateString().Replace("/", "_") + ".xlsx";
                else
                    path = @"X:\\" + TenBaocao + DateTime.Today.ToShortDateString().Replace("/", "_") + ".xlsx";
                
            };

            filter_Vertical1.Find(new EventHandler(EventHandler_Find));
            filter_Vertical1.Excel(new EventHandler(EventHandler_Excel));
            filter_Vertical1.Exit(new EventHandler(EventHandler_Exit)); 


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
        }
        private void EventHandler_Find(object sender, EventArgs e)
        {          

            switch (filter_Vertical1.cmbOption_SelectedText.ToString())
            {
                case ("From...to..."):
                    //dt = PXN_BUS.BaoCao_NhanMau_Fr_To_Date(filter_Vertical1.dteFrDateVal, filter_Vertical1.dteToDateVal);
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_TheoNgay(sYNC_NUTRICIEL_REPORT.BaoCao_PO, filter_Vertical1.dteFrDateVal.ToString(), filter_Vertical1.dteToDateVal.ToString());
                    break;
                case ("Next day"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Daily(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 1);
                    break;
                case ("Today"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Daily(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 0);
                    break;
                case ("Last day"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Daily(sYNC_NUTRICIEL_REPORT.BaoCao_PO, -1);
                    break;
                case ("Next week"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Weekly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 1);
                    break;
                case ("This week"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Weekly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 0);
                    break;
                case ("Last week"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Weekly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, -1);
                    break;
                case ("Next month"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Monthly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 1);
                    break;
                case ("This month"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Monthly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 0);
                    break;
                case ("Last month"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Monthly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, -1);
                    break;
                case ("Next quater"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Quaterly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 1);
                    break;
                case ("This quater"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Quaterly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 0);
                    break;
                case ("Last quater"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Quaterly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, -1);
                    break;
                case ("Next year"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Yearly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 1);
                    break;
                case ("This year"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Yearly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, 0);
                    break;
                case ("Last year"):
                    gridControl1.DataSource = baoCao_POTableAdapter.Fill_BaoCao_PO_Yearly(sYNC_NUTRICIEL_REPORT.BaoCao_PO, -1);
                    break;
            }
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

        private void EventHandler_Exit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}