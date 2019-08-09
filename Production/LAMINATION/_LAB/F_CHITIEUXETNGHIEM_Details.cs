using System;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace Production.Class
{
    public partial class F_CHITIEUXETNGHIEM_Details : frm_Base
    {
        string Path = Directory.GetCurrentDirectory();
        public string isAction = "";
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
        public CHITIEUXETNGHIEM CUS = new CHITIEUXETNGHIEM();
        CHITIEUXETNGHIEMBUS CUSBUS = new CHITIEUXETNGHIEMBUS();

        public F_CHITIEUXETNGHIEM_Details()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                action_EndForm1.Add_Status(false);
                action_EndForm1.Delete_Status(false);
                action_EndForm1.Update_Status(false);
                action_EndForm1.Save_Status(true);
                action_EndForm1.View_Status(false);
                action_EndForm1.Close_Status(true);

                //if(isEditting == true)
                if (isAction == "Edit")
                {
                    Set4Controls();
                    //lkeLoaiDN.ReadOnly = true;
                }
                else if (isAction == "Add")
                    txtID.ReadOnly = true;


                
            };

            //lkePPXNID.EditValueChanged += (s, e) =>
            //{
            //    DataRowView row = lkePPXNID.Properties.GetDataSourceRowByKeyValue(lkePPXNID.EditValue) as DataRowView;
            //    txtSdt.Text = row["EMPMobile"].ToString();
            //    txtEmailNV.Text = row["EMPEmail"].ToString();
            //};

            //lkeMaDN.EditValueChanged += (s, e) =>
            //{
            //    DataRowView row = lkeMaDN.Properties.GetDataSourceRowByKeyValue(lkeMaDN.EditValue) as DataRowView;
            //    txtTenDN.Text = row["CardName"].ToString();
            //    txtCTXNDG.Text = row["Address"].ToString();
            //};

            //Action_EndForm
            action_EndForm1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action_EndForm1.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update));
            action_EndForm1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action_EndForm1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
        }

        private void ItemClickEventHandler_Save(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (isAction == "Add")
                {
                    Set4Object();
                    CUSBUS.CHITIEUXETNGHIEM_INSERT(CUS);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Lưu ý ";
                    args.Text = "Thêm mới chỉ tiêu xét nghiệm thành công. Thông báo này sẽ tự đóng sau 3 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                else if (isAction == "Edit")
                {
                    Set4Object();
                    CUSBUS.CHITIEUXETNGHIEM_UPDATE(CUS);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Lưu ý ";
                    args.Text = "Cập nhật chỉ tiêu xét nghiệm thành công. Thông báo này sẽ tự đóng sau 3 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }

                Is_close = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Close(object sender, ItemClickEventArgs e)
        {
            Is_close = true;
            //this.Close();
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Update(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void Set4Controls()
        {
            txtID.Text = CUS.ID.ToString();
            //lkeLoaiDN.EditValue                 = CUS.CUSTTYPECode;
            
            //if (lkeLoaiDN.EditValue.ToString() == "L01")
            //{
            //    lkeMaDN.Text = CUS.CUSTCODE;
            //    txtTenDN.Text = CUS.CUSTNAME;
            //}
            //else if (lkeLoaiDN.EditValue.ToString() == "L02")
            //{
            //    txtMaDN2.Text = CUS.CUSTCODE;
            //    txtTenDN2.Text = CUS.CUSTNAME;
            //}             
            
            
            txtCTXN.Text                        = CUS.CTXN;
            txtCTXNDG.Text                      = CUS.CTXNDG ;
            txtCTXNDGTA.Text                    = CUS.CTXNDGTA;
            lkeNCTXNID.EditValue                = CUS.NCTXNID;
            cmbKhoa.Text                        = CUS.Locked.ToString() ;
            lkePPXNID.EditValue                 = CUS.PPXNID;
            txtUnitValue.Text                   = CUS.UnitValue;
            txtNote.Text                        = CUS.Note ;
            txtMaCTXN.Text                      = CUS.MaCTXN;
            txtAcronym.Text = CUS.Acronym;
            cmbUoM.Text = CUS.UoM.ToString();

        }

        public void Set4Object()
        {
            if (isAction == "Edit")
            {
                CUS.ID = int.Parse(txtID.Text.ToString());
                //MessageBox.Show("txtID.Text.ToString()" + txtID.Text.ToString());
            }

            
            CUS.CTXN                    = txtCTXN.Text;
            //MessageBox.Show("txtCTXN.Text" + txtCTXN.Text);
            CUS.CTXNDG                  = txtCTXNDG.Text;
            //MessageBox.Show("txtCTXNDG.Text" + txtCTXNDG.Text);
            CUS.CTXNDGTA                = txtCTXNDGTA.Text;
            //MessageBox.Show("txtCTXNDGTA.Text" + txtCTXNDGTA.Text);
            CUS.Locked                  = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            //MessageBox.Show("cmbKhoa.SelectedText.ToString()" + cmbKhoa.SelectedText.ToString());
            CUS.NCTXNID                 = int.Parse(lkeNCTXNID.EditValue.ToString());
            //MessageBox.Show("lkeNCTXNID.EditValue.ToString()" + lkeNCTXNID.EditValue.ToString());
            CUS.PPXNID                  = int.Parse(lkePPXNID.EditValue.ToString());
            //MessageBox.Show("lkePPXNID.EditValue.ToString()" + lkePPXNID.EditValue.ToString());
            CUS.MinValue                = txtMinValue.Text;
            //MessageBox.Show("txtMinValue.Text" + txtMinValue.Text);
            CUS.MaxValue                = txtMaxValue.Text;
            //MessageBox.Show("txtMaxValue.Text" + txtMaxValue.Text);
            CUS.UnitValue               = txtUnitValue.Text;
            //MessageBox.Show("txtUnitValue.Text" + txtUnitValue.Text);
            CUS.Note                    = txtNote.Text;

            CUS.MaCTXN                  = txtMaCTXN.Text;

            CUS.Acronym                 = txtAcronym.Text;

            CUS.UoM                     = cmbUoM.Text.ToString();


        }
        public void ResetControl()
        {
            
            //lkeMaDN.Text = "";
            //txtTenDN.Text = "";
            txtCTXN.Text            = "";
            txtCTXNDG.Text          = "";
            txtCTXNDGTA.Text        = "";
            lkeNCTXNID.Text         = "";
            cmbKhoa.Text            = "";
            lkePPXNID.EditValue     = null;
            txtNote.Text            = "";
            txtMaCTXN.Text          = "";
            txtAcronym.Text         = "";
            cmbUoM.Text = "";
        }
        //
        public void ControlsReadOnly(bool bl)
        {
            
            txtCTXN.ReadOnly = bl;
            txtCTXNDG.ReadOnly = bl;
            txtCTXNDGTA.ReadOnly = bl;
            lkeNCTXNID.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
            lkePPXNID.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            txtMaCTXN.ReadOnly = bl;
            txtAcronym.ReadOnly = bl;
            cmbUoM.ReadOnly = bl;
        }

        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PhuongPhapXetNghiem_LAB' table. You can move, or remove it, as needed.
            this.tbl_PhuongPhapXetNghiem_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_PhuongPhapXetNghiem_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_NhomChiTieuXetNghiem_LAB' table. You can move, or remove it, as needed.
            this.tbl_NhomChiTieuXetNghiem_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_NhomChiTieuXetNghiem_LAB);

        }
    }
}
