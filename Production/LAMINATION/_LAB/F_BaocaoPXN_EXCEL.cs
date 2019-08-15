using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_BaocaoPXN_EXCEL : UC_Base
    {
        private PXN_HeaderBUS BUS = new PXN_HeaderBUS();
        private string TenBaocao = "";
        private string filename = "";

        public F_BaocaoPXN_EXCEL()
        {
            InitializeComponent();

            Load += (s, e) =>
                {
                };
            action1.Excel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Excel));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            chkPXNNhan.CheckStateChanged += (s, e) =>
            {
                if (chkPXNNhan.CheckState == CheckState.Checked)
                {
                    chkPXNDaTra.CheckState = CheckState.Unchecked;
                    chkPXNChuaTra.CheckState = CheckState.Unchecked;
                }
            };

            chkPXNDaTra.CheckStateChanged += (s, e) =>
            {
                if (chkPXNDaTra.CheckState == CheckState.Checked)
                {
                    chkPXNNhan.CheckState = CheckState.Unchecked;
                    chkPXNChuaTra.CheckState = CheckState.Unchecked;
                }
            };

            chkPXNChuaTra.CheckStateChanged += (s, e) =>
            {
                if (chkPXNChuaTra.CheckState == CheckState.Checked)
                {
                    chkPXNDaTra.CheckState = CheckState.Unchecked;
                    chkPXNNhan.CheckState = CheckState.Unchecked;
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
                filename = "D:\\" + TenBaocao + ".xlsx";
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
            if (dteFrmDate.Text.ToString() == null || dteFrmDate.Text.Length == 0)
                dteFrmDate.EditValue = DateTime.Today;
            if (dteToDate.Text.ToString() == null || dteToDate.Text.Length == 0)
                dteToDate.EditValue = DateTime.Today;

            if (chkPXNNhan.CheckState == CheckState.Unchecked && chkPXNDaTra.CheckState == CheckState.Unchecked && chkPXNChuaTra.CheckState == CheckState.Unchecked)
                chkPXNNhan.CheckState = CheckState.Checked;
            else if (chkPXNNhan.CheckState == CheckState.Unchecked)
            {
                TenBaocao = "BC_PXN_Nhan_Tu" + dteFrmDate.Text.ToString().Replace("/", "") + "_Den" + dteToDate.Text.ToString().Replace("/", "");

                gridControl1.DataSource = BUS.BaoCaoPXN_Nhan_Export2Excel(DateTime.Parse(dteFrmDate.EditValue.ToString()), DateTime.Parse(dteToDate.EditValue.ToString()));
            }
            else if (chkPXNDaTra.CheckState == CheckState.Unchecked)
            {
                TenBaocao = "BC_PXN_DaTra_Tu" + dteFrmDate.Text.ToString().Replace("/", "") + "_Den" + dteToDate.Text.ToString().Replace("/", "");

                gridControl1.DataSource = BUS.BaoCaoPXN_DaTra_Export2Excel(DateTime.Parse(dteFrmDate.EditValue.ToString()), DateTime.Parse(dteToDate.EditValue.ToString()));
            }
            else if (chkPXNChuaTra.CheckState == CheckState.Unchecked)
            {
                TenBaocao = "BC_PXN_ChuaTra_Tu" + dteFrmDate.Text.ToString().Replace("/", "") + "_Den" + dteToDate.Text.ToString().Replace("/", "");

                gridControl1.DataSource = BUS.BaoCaoPXN_ChuaTra_Export2Excel(DateTime.Parse(dteFrmDate.EditValue.ToString()), DateTime.Parse(dteToDate.EditValue.ToString()));
            }
            //gridView1.BestFitColumns();
        }
    }
}