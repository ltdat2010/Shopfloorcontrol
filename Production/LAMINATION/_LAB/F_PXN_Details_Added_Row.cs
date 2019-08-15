using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_PXN_Details_Added_Row : frm_Base
    {
        public DateTime ngaynhanmau;
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

        public PXN_Details OBJ = new PXN_Details();
        private PXN_DetailsBUS BUS = new PXN_DetailsBUS();
        private PXN_ResultBUS BUS1 = new PXN_ResultBUS();
        public PXN_Result OBJ1 = new PXN_Result();

        public F_PXN_Details_Added_Row()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                LoadDataIntoTable();

                if (isAction == "Edit")
                {
                    txtID.ReadOnly = true;
                    Set4Controls();
                }
                else if (isAction == "Add")
                {
                    txtID.ReadOnly = true;
                    //txtPLID.Text = OBJ.PLID.ToString() ;
                }
            };

            btnSave.Click += (s, e) =>
            {
                if (isAction == "Add")
                {
                    Set4Object();
                    BUS.PXN_DetailsBUS_INSERT(OBJ);
                    for (int i = 0; i <= int.Parse(txtSoLuong.Text); i++)
                    {
                        Set4Object_ResultLine(i);
                        BUS1.PXN_ResultBUS_INSERT(OBJ1);
                    }
                }
                else if (isAction == "Edit")
                {
                    Set4Object();
                    BUS.PXN_DetailsBUS_UPDATE(OBJ);
                }
                Is_close = true;
            };

            btnCancel.Click += (s, e) =>
            {
                Is_close = true;
                //this.Close();
            };

            lkeCTXN.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    F_CHITIEUXETNGHIEM_Details FRM = new F_CHITIEUXETNGHIEM_Details();
                    FRM.isAction = "Add";
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
            };

            lkeCTXN.TextChanged += (s, e) =>
            {
                object row = lkeCTXN.Properties.GetDataSourceRowByKeyValue(lkeCTXN.EditValue);
                //MessageBox.Show((row as DataRowView)["PPXNID"].ToString());
                //MessageBox.Show((row as DataRowView)["VAT"].ToString());
                //MessageBox.Show((row as DataRowView)["DonGia"].ToString());
                lkePPXN.EditValue = int.Parse((row as DataRowView)["PPXNID"].ToString());
                txtDonGia.Text = (row as DataRowView)["DonGia"].ToString();
                txtVAT.Text = (row as DataRowView)["VAT"].ToString();
            };
        }

        public void Set4Controls()
        {
            if (isAction == "Edit")
                txtID.Text = OBJ.ID.ToString();

            lkeCTXN.EditValue = OBJ.CTXNID;
            MessageBox.Show(OBJ.SoPXN);
            txtSoPXN.Text = OBJ.SoPXN;

            txtDonGia.Text = OBJ.DonGia;

            txtSoLuong.Text = OBJ.SLMau;

            txtGhiChu.Text = OBJ.GhiChu;

            txtNote.Text = OBJ.Note;

            cmbKhoa.SelectedText = OBJ.Locked.ToString();
        }

        public void Set4Object()
        {
            if (isAction == "Edit")
                OBJ.ID = int.Parse(txtID.Text);

            //OBJ.SoPXN = txtSoPXN.Text;

            OBJ.CTXNID = int.Parse(lkeCTXN.EditValue.ToString());

            OBJ.DonGia = txtDonGia.Text;

            OBJ.Note = txtNote.Text;

            OBJ.GhiChu = txtGhiChu.Text;

            OBJ.SLMau = txtSoLuong.Text;
            //MessageBox.Show("txtDonGia.Text " + txtDonGia.Text);
            //MessageBox.Show("txtSoLuong.Text " + txtSoLuong.Text);
            //MessageBox.Show("txtVAT.Text " + txtVAT.Text);
            OBJ.ThanhTien = (int.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text) * (100 + int.Parse(txtVAT.Text)) / 100).ToString();

            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }

        public void Set4Object_ResultLine(int i)
        {
            //----------------------------------------------------------------------------------------------
            /////////////////////////////////////OBJ1///////////////////////////////////////////////////////
            OBJ1.CTXNID = OBJ.CTXNID;
            OBJ1.PXN_Details_ID = BUS.PXN_DetailsDAO_SELECT_ID_BY_SoPXN_CTXNID(OBJ.SoPXN, OBJ.CTXNID);
            OBJ1.ResultLine = i.ToString();
            //OBJ1.ResultUoM
            //OBJ1.ResultValue
            OBJ1.SoPXN = OBJ.SoPXN;
            //OBJ1.UnitTestCode
            //OBJ1.Positive
            //OBJ1.ID
            //OBJ1.Locked
            //OBJ1.Note
            //OBJ1.CreatedBy
            //OBJ1.CreatedDate
        }

        public void ResetControl()
        {
            txtID.Text = "";
            txtSoPXN.Text = "";
            lkeCTXN.EditValue = "";
            txtDonGia.Text = "";
            txtNote.Text = "";
            txtSoLuong.Text = "";
            //txtGiam.Text = "";
            //cmbUoM.SelectedText = "";
            //cmbUoMGiamGia.SelectedText = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;

            lkeCTXN.ReadOnly = bl;
            txtDonGia.ReadOnly = bl;
            txtSoPXN.ReadOnly = bl;
            lkeCTXN.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            txtSoLuong.ReadOnly = bl;
            //txtGiam.ReadOnly = bl;
            //cmbUoM.ReadOnly = bl;
            //cmbUoMGiamGia.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
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

            LoadDataIntoTable();
        }

        public void LoadDataIntoTable()
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB' table. You can move, or remove it, as needed.
            this.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMauTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMau, ngaynhanmau.ToString());
        }

        private void F_PRICELIST_Details_Added_Row_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PhuongPhapXetNghiem_LAB' table. You can move, or remove it, as needed.
            this.tbl_PhuongPhapXetNghiem_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_PhuongPhapXetNghiem_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB' table. You can move, or remove it, as needed.
            //this.tbl_ChiTieuXetNghiem_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB' table. You can move, or remove it, as needed.
            this.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMauTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMau, ngaynhanmau.ToString());
        }
    }
}