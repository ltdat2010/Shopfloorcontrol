using System;

namespace Production.Class
{
    public partial class F_RECEIPT_List : UC_Base
    {
        private RECEIPT of = new RECEIPT();
        private RECEIPTBUS OFB = new RECEIPTBUS();

        public F_RECEIPT_List()
        {
            InitializeComponent();

            Load += (s, e) =>
            {
                //--------------------------------------------------------------
                gridControl1.DataSource = OFB.F_RECEIPT_List();
            };
            simpleButton1.Click += (s, e) =>
            {
                //of.ECH_RECEPS = gridView1.GetFocusedRowCellDisplayText(ECH_RECEPS).ToString();
                //OFB.F_RECEIPT_DetailsCSV(of.ECH_RECEPS);
                //MessageBox.Show("Export to RECEIPT CSV successfully.");
            };
            action1.CSV(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_CSV));
        }

        private void ItemClickEventHandler_CSV(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellDisplayText(ECH_RECEPS).ToString().Length > 0)
            {
                F_RECEIPT_Details FRCD = new F_RECEIPT_Details();
                FRCD.ECHRECEPS = gridView1.GetFocusedRowCellDisplayText(ECH_RECEPS).ToString();
                FRCD.Show();
            }
        }

        //Them
        public override UC_Base Add()
        {
            return base.Add();
        }

        //Sua
        public override frm_Base Modify()
        {
            return base.Modify();
        }

        //Luu
        public override void Save()
        {
            base.Save();
        }

        //Xoa
        public override void Delete()
        {
            base.Delete();
        }

        //Thoat
        public override void Close()
        {
            this.Dispose();
        }

        //Next

        //Prev

        //Last

        //First

        //Chart
        public override UC_Base Chart()
        {
            return base.Chart();
        }

        ////Report
        //public override UC_Base Report()
        //{
        //    return base.Report();
        //}
        //Report Lite
        //public override UC_Base ReportLite()
        //{
        //    return base.Report();
        //}

        public void Update(object sender)
        {
            //var frm = (DevExpress.XtraEditors.XtraForm)sender;
            //CM_bus.Select_All( gridControl1, dataNavigator1);
            //frm.Dispose();
        }
    }
}