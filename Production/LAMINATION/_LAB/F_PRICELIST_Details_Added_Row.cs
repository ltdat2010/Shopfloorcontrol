using System;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraLayout.Utils;
using System.Data;

namespace Production.Class
{
    public partial class F_PRICELIST_Details_Added_Row : frm_Base
    {
        CUSTOMERBUS CUSBUS = new CUSTOMERBUS();
        string Path = Directory.GetCurrentDirectory();
        //public string isAction = "";
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
                }
            }
        }
        public PRICELIST_Details OBJ = new PRICELIST_Details();
        PRICELIST_DetailsBUS BUS = new PRICELIST_DetailsBUS();

        public F_PRICELIST_Details_Added_Row()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                LoadDataIntoTable();
                
                if (isAction == "Edit")
                {                  
                    txtID.ReadOnly = true;
                    lkeCTXN.Properties.ReadOnly = true;
                    Set4Controls();
                }
                else if (isAction == "Add")
                {                    
                    txtID.ReadOnly = true;
                    txtPLID.Text = OBJ.PLID.ToString() ;
                }
            };

            btnSave.Click += (s,e) =>
            {         
                    if (isAction == "Add")
                    {
                        Set4Object();
                        BUS.PRICELIST_INSERT(OBJ);
                    }
                    else if (isAction == "Edit")
                    {                        
                        Set4Object();
                        BUS.PRICELIST_UPDATE(OBJ);
                    }                
                    Is_close = true;                
            };            

            btnCancel.Click += (s, e) =>
            {
                Is_close = true;
            };

            lkeCTXN.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {                    
                    this.Enabled = false;
                    
                    F_CHITIEUXETNGHIEM_Details FRM = new F_CHITIEUXETNGHIEM_Details();
                    FRM.isAction = "Add";
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
            };

            chkNTP.CheckedChanged += (s, e) =>
            {
                if (chkNTP.CheckState == CheckState.Checked)
                {
                    layoutControlItem21.Visibility = LayoutVisibility.Never;
                    layoutControlItem22.Visibility = LayoutVisibility.Never;

                    layoutControlItem19.Visibility = LayoutVisibility.Always;
                    layoutControlItem20.Visibility = LayoutVisibility.Always;

                    lkeMaDN.Properties.DataSource = CUSBUS.CUSTOMER_LIST_SAPB1();
                    lkeMaDN.Properties.DisplayMember = "CardCode";
                    lkeMaDN.Properties.ValueMember = "CardCode";
                }
                else
                {
                    layoutControlItem21.Visibility = LayoutVisibility.Always;
                    layoutControlItem22.Visibility = LayoutVisibility.Always;

                    layoutControlItem19.Visibility = LayoutVisibility.Never;
                    layoutControlItem20.Visibility = LayoutVisibility.Never;
                }

            };

            lkeMaDN.EditValueChanged += (s, e) =>
            {
                    DataRowView row = lkeMaDN.GetSelectedDataRow() as DataRowView;
                    txtTenDN.Text = row["CardName"].ToString();
            };

            lkeCTXN.EditValueChanged += (s, e) =>
            {
                DataRowView row = lkeCTXN.GetSelectedDataRow() as DataRowView;
                txtMaCTXN.Text = row["MaCTXN"].ToString();
            };

            cmbVAT.SelectedValueChanged += (s, e) =>
            {
                if (cmbVAT.SelectedText == "0")
                {
                    if(chkNTP.CheckState == CheckState.Checked)
                        txtDonGia.Text = (float.Parse(txtDonGiaMuaNgoai.Text) * 1.2).ToString();
                }
                if (cmbVAT.SelectedText != "0")
                {
                    if (chkNTP.CheckState == CheckState.Checked)
                        txtDonGia.Text = (float.Parse(txtDonGiaMuaNgoai.Text) * float.Parse(cmbVAT.SelectedText) * 1.2).ToString();
                }
            };
        }

        public void Set4Controls()
        {
            if (OBJ.MuaNgoai == true)
            {
                chkNTP.Checked = true;
                lkeMaDN.Text = OBJ.DVMuaNgoaiCode;
                txtTenDN.Text = OBJ.DVMuaNgoaiName;
            }                           
            else
            {
                chkNTP.Checked = false;
                txtMaPTN.Text = OBJ.DVMuaNgoaiCode;
                txtTenPTN.Text = OBJ.DVMuaNgoaiName;
            }    
            
            txtID.Text = OBJ.ID.ToString();

            txtPLID.Text = OBJ.PLID.ToString();            
            
            lkeCTXN.EditValue = OBJ.CTXNID;
            
            txtDonGia.Text = OBJ.DonGia;

            txtDonGiaMuaNgoai.Text = OBJ.DonGiaMuaNgoai;

            cmbVAT.Text = OBJ.VAT;
            // SoLuong
            txtSoLuong.Text = OBJ.SoLuong;
            //UoM
            cmbUoM.Text = OBJ.UoM;
            //UoMGiam
            cmbUoMGiamGia.SelectedText = OBJ.UoMGiam;
            //Giam
            txtGiam.Text = OBJ.Giam;

            txtNote.Text = OBJ.Note;

            cmbKhoa.SelectedText = OBJ.Locked.ToString();
        }

        public void Set4Object()
        {
            if (isAction == "Edit")
                OBJ.ID = int.Parse(txtID.Text);

            OBJ.PLID = int.Parse(txtPLID.Text);

            OBJ.CTXNID = int.Parse(lkeCTXN.EditValue.ToString());

            OBJ.DonGia = txtDonGia.Text;            

            OBJ.Note = txtNote.Text;

            OBJ.Giam = txtGiam.Text;

            OBJ.SoLuong = txtSoLuong.Text;

            OBJ.UoM = cmbUoM.SelectedText;

            OBJ.UoMGiam = cmbUoMGiamGia.SelectedText;
            
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;

            OBJ.VAT = cmbVAT.Text;

            if(chkNTP.CheckState== CheckState.Checked)
            {
                OBJ.DVMuaNgoaiCode = lkeMaDN.EditValue.ToString();
                OBJ.DVMuaNgoaiName = txtTenDN.Text;
                OBJ.MuaNgoai = true;
                OBJ.DonGiaMuaNgoai = txtDonGiaMuaNgoai.Text;
            }
            else
            {
                OBJ.DVMuaNgoaiCode = "VIPHALAB";
                OBJ.DVMuaNgoaiName = "Phòng thí nghiệm VIPHALAB";
                OBJ.MuaNgoai = false;
                OBJ.DonGiaMuaNgoai = "0";
            }
        }
        public void ResetControl()
        {
            txtID.Text = "";
            txtPLID.Text = "";
            lkeCTXN.EditValue = "";
            txtDonGia.Text = "";
            txtDonGiaMuaNgoai.Text = "";
            txtNote.Text = "";
            txtSoLuong.Text = "";
            txtGiam.Text = "";
            cmbUoM.SelectedText = "";
            cmbUoMGiamGia.SelectedText = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            lkeCTXN.ReadOnly = bl;
            txtDonGia.ReadOnly = bl;
            txtDonGiaMuaNgoai.ReadOnly = bl;
            txtPLID.ReadOnly = bl;
            lkeCTXN.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            txtSoLuong.ReadOnly = bl;
            txtGiam.ReadOnly = bl;
            cmbUoM.ReadOnly = bl;
            cmbUoMGiamGia.ReadOnly = bl;
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
            this.tbl_ChiTieuXetNghiem_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB);
            // TODO: This line of code loads data into the 'vIPHAVETDataset.OCRD' table. You can move, or remove it, as needed.
            this.oCRDTableAdapter.Fill(this.vIPHAVETDataset.OCRD);
        }

        private void F_PRICELIST_Details_Added_Row_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vIPHAVETDataset.OCRD' table. You can move, or remove it, as needed.
            this.oCRDTableAdapter.Fill(this.vIPHAVETDataset.OCRD);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB' table. You can move, or remove it, as needed.
            this.tbl_ChiTieuXetNghiem_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB);
            // TODO: This line of code loads data into the 'vIPHAVETDataset.OCRD' table. You can move, or remove it, as needed.
            this.oCRDTableAdapter.Fill(this.vIPHAVETDataset.OCRD);
        }

    }
}
