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
                    Readonly4Controls(true);
                };
            action1.Excel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Excel));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

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