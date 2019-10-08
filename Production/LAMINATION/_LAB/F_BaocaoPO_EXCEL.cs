using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_BaocaoPO_EXCEL : UC_Base
    {
        private string TenBaocao = "";
        private string filename = "";

        private PO_Header_BUS POH_BUS = new PO_Header_BUS();

        public F_BaocaoPO_EXCEL()
        {
            InitializeComponent();

            Load += (s, e) =>
                {
                };

            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "STT" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };

            action1.Excel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Excel));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            gridView1.CellValueChanged += (s, e) =>
            {
                e.Column.BestFit();
            };
        }

        private void ItemClickEventHandler_Excel(object sender, EventArgs e)
        {
            try
            {
                TenBaocao = "PO_Tonghop";
                filename = @"X:\\" + TenBaocao + DateTime.Today.ToShortDateString().Replace("/", "_") + ".xlsx";
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
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = POH_BUS.PO_List_Report(DateTime.Parse(dteFrDate.Text), DateTime.Parse(dteToDate.Text));
            GridColumn colCounter = gridView1.Columns.AddVisible("STT");
            colCounter.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            colCounter.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colCounter.VisibleIndex = 0;
        }
    }
}