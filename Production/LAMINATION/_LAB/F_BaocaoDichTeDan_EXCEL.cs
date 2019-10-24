using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_BaocaoDichTeDan_EXCEL : UC_Base
    {
        private PXN_HeaderBUS BUS = new PXN_HeaderBUS();
        private string TenBaocao = "";
        private string filename = "";
        private string month = "";
        private string year = "";
        private string quater = "";

        public F_BaocaoDichTeDan_EXCEL()
        {
            InitializeComponent();

            Load += (s, e) =>
                {
                    TenBaocao = "TONGHOP_DICHTEVUNG";

                    Readonly4Controls(true);
                };
            action1.Excel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Excel));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            filter_Vertical1.Find(new EventHandler(EventHandler_Find));
            filter_Vertical1.Excel(new EventHandler(EventHandler_Excel));
            filter_Vertical1.Exit(new EventHandler(EventHandler_Exit));

            chkTheoThang.CheckStateChanged += (s, e) =>
            {
                if (chkTheoThang.CheckState == CheckState.Checked)
                {
                    chkTheoQuy.CheckState = CheckState.Unchecked;
                    chkTheoNam.CheckState = CheckState.Unchecked;
                    Readonly4Controls(true);
                    cmbThangTheoThang.ReadOnly = false;
                    cmbNamTheoThang.ReadOnly = false;
                }
            };

            chkTheoQuy.CheckStateChanged += (s, e) =>
            {
                if (chkTheoQuy.CheckState == CheckState.Checked)
                {
                    chkTheoThang.CheckState = CheckState.Unchecked;
                    chkTheoNam.CheckState = CheckState.Unchecked;
                    Readonly4Controls(true);
                    cmbQuyTheoQuy.ReadOnly = false;
                    cmbNamTheoQuy.ReadOnly = false;
                }
            };

            chkTheoNam.CheckStateChanged += (s, e) =>
            {
                if (chkTheoNam.CheckState == CheckState.Checked)
                {
                    chkTheoQuy.CheckState = CheckState.Unchecked;
                    chkTheoThang.CheckState = CheckState.Unchecked;
                    Readonly4Controls(true);
                    cmbNamTheoNam.ReadOnly = false;
                }
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
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_mm_yy(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, filter_Vertical1.dteFrDateVal.ToString(), filter_Vertical1.dteToDateVal.ToString());
                    break;
                case ("Next day"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Daily(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 1);
                    break;
                case ("Today"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Daily(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 0);
                    break;
                case ("Last day"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Daily(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, -1);
                    break;
                case ("Next week"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Weekly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 1);
                    break;
                case ("This week"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Weekly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 0);
                    break;
                case ("Last week"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Weekly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, -1);
                    break;
                case ("Next month"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Monthly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 1);
                    break;
                case ("This month"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Monthly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 0);
                    break;
                case ("Last month"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Monthly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, -1);
                    break;
                case ("Next quater"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Quaterly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 1);
                    break;
                case ("This quater"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Quaterly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 0);
                    break;
                case ("Last quater"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Quaterly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, -1);
                    break;
                case ("Next year"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Yearly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 1);
                    break;
                case ("This year"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Yearly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, 0);
                    break;
                case ("Last year"):
                    gridControl1.DataSource = baoCao_DichTeVungTableAdapter.Fill_BaoCao_DichTeVung_Yearly(sYNC_NUTRICIEL_REPORT.BaoCao_DichTeVung, -1);
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
        private void ItemClickEventHandler_Excel(object sender, EventArgs e)
        {
            try
            {
                filename = @"X:\\" + TenBaocao + ".xlsx";
                //Export excel file
                gridControl1.ExportToXlsx(filename);
                //Open excel file
                System.Diagnostics.Process.Start(filename);
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
            R_FrDate_ToDate_OABatch RFTOAB = new R_FrDate_ToDate_OABatch();
            RFTOAB.Show();
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            //TenBaocao = "BC_DichTeChung_Nhan_Tu"+dteFrmDate.Text.ToString().Replace("/","")+"_Den"+ dteToDate.Text.ToString().Replace("/", "");

            //gridControl1.DataSource = BUS.BaoCaoDichTeDan_Thang_xport2Excel(DateTime.Parse(dteFrmDate.EditValue.ToString()), DateTime.Parse(dteToDate.EditValue.ToString()));
        }

        private void Readonly4Controls(bool bl)
        {
            cmbNamTheoNam.ReadOnly = bl;
            cmbNamTheoQuy.ReadOnly = bl;
            cmbNamTheoThang.ReadOnly = bl;
            cmbQuyTheoQuy.ReadOnly = bl;
            cmbThangTheoThang.ReadOnly = bl;
        }
    }
}