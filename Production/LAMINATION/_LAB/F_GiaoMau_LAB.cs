using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_GiaoMau_LAB : frm_Base
    {
        public DateTime ngaynhanmau;
        private string Path = Directory.GetCurrentDirectory();
        public string isAction = "";
        public string str_KHMau = "";
        private bool gridViewRowClick = false;

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

        private PXN_HeaderBUS BUS = new PXN_HeaderBUS();
        private PXN_DetailsBUS BUS1 = new PXN_DetailsBUS();
        private KHMau_LABBUS BUS2 = new KHMau_LABBUS();
        public PXN_Header OBJ = new PXN_Header();

        public F_GiaoMau_LAB()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                this.tbl_KHMau_LABTableAdapter.FillBy_GiaoMau_SoPXN(sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, OBJ.SoPXN);

                this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
                this.Height = Screen.PrimaryScreen.Bounds.Height - 30;

                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);
            };

            gridView1.CellValueChanged += (s, e) =>
            {
                GridView view = s as GridView;
                if (view == null) return;
                if (e.Column.Caption != "Kí hiệu mẫu") return;
                string cellValue = e.Value.ToString().Substring(1, 1) + e.Value.ToString().PadRight(4);
                view.SetRowCellValue(e.RowHandle, view.Columns[4], cellValue);
            };

            btnPhieuGiaoMau.Click += (s, e) =>
            {
                R_PGM_LAB FRM = new Class.R_PGM_LAB();
                FRM.OBJ = this.OBJ;
                FRM.myFinished += this.finished;
                FRM.Show();
            };

            FormClosed += (s, e) =>
            {
                Is_close = true;
            };
        }

        public void Set4Controls_Header()
        {
        }

        public void Set4Controls_Details()
        {
        }

        public void Set4Object_Header()
        {
        }

        public void Set4Object_Details()
        {
        }

        public void ResetControl()
        {
        }

        //
        public void ControlsReadOnly(bool bl)
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

            gridView1.BestFitColumns();
        }

        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KHMau_LAB' table. You can move, or remove it, as needed.
            this.tbl_KHMau_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_KHMau_LAB);
        }
    }
}