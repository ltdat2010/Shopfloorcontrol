using System;
using System.IO;

namespace Production.Class
{
    public partial class F_PRICELIST_History : frm_Base
    {
        private bool gridViewRowClick = false;
        private string Path = Directory.GetCurrentDirectory();

        /// <summary>
        /// DELEGATE
        /// </summary>
        public delegate void MyAdd(object sender);//, string isActionReturn);

        public event MyAdd myFinished;

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this);//, isActionReturn: isAction);
                }
            }
        }

        public PRICELIST OBJ = new PRICELIST();
        private PRICELIST_Details OBJ1 = new PRICELIST_Details();

        private PRICELISTBUS BUS = new PRICELISTBUS();
        private PRICELIST_DetailsBUS BUS1 = new PRICELIST_DetailsBUS();

        public F_PRICELIST_History()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //if (isAction == "Edit")
                //{
                TDControlsReadOnly(true);
                Set4Controls();
                //XtraMessageBox.Show(OBJ.ID.ToString());
                gridControl1.DataSource = v_PriceList_HistoryTableAdapter.FillBy_PLID(sYNC_NUTRICIELDataSet.V_PriceList_History, OBJ.ID);
                //}
            };

            btnCancel.Click += (s, e) =>
            {
                Is_close = true;
                //this.Close();
            };

            // 7 Add hoặc New
            actionMini1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));

            // 8 Lưu
            actionMini1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));

            // 9 Edit hoặc Update
            actionMini1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));

            // 10 Del
            actionMini1.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete));

            // 10a View
            actionMini1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            // 10B Cancel
            actionMini1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));

            // 10C PDF
            actionMini1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
        }

        public void Set4Controls()
        {
            txtID.Text = OBJ.ID.ToString();
        }

        public void Set4ObjectRow()
        {
        }

        public void Set4ObjectHeader()
        {
        }

        public void ResetControl()
        {
            txtID.Text = "";
        }

        public void TDControlsReadOnly(bool bl)
        {
            txtID.ReadOnly = bl;
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            string filePath = @"X:\PriceList_History_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            gridView1.ExportToXlsx(filePath);
            System.Diagnostics.Process.Start(filePath);
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
        }

        public void finished(object sender)
        {
            //Disable
            this.Enabled = true;
            //
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            //// Step 2 : Load lại data tren grid sau khi Add
            gridControl1.DataSource = v_PriceList_HistoryTableAdapter.FillBy_PLID(sYNC_NUTRICIELDataSet.V_PriceList_History, OBJ.ID);
            gridView1.BestFitColumns();
        }

        private void F_PRICELIST_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PriceList_Details_LAB' table. You can move, or remove it, as needed.
            v_PriceList_HistoryTableAdapter.FillBy_PLID(sYNC_NUTRICIELDataSet.V_PriceList_History, OBJ.ID);
        }
    }
}