using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_CUSTOMER_Details : frm_Base
    {
        private string Path = Directory.GetCurrentDirectory();
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

        public CUSTOMER CUS = new CUSTOMER();
        private CUSTOMERBUS CUSBUS = new CUSTOMERBUS();
        private PXN_Header PXN = new PXN_Header();
        private PXN_HeaderBUS PXNBUS = new PXN_HeaderBUS();

        public F_CUSTOMER_Details()
        {
            InitializeComponent();
            Load += (s, e) =>
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

            chkBan.CheckedChanged +=(s,e) =>
                {
                    if (chkBan.CheckState == CheckState.Checked)
                        chkHotro.CheckState = CheckState.Unchecked;
                    else
                        chkHotro.CheckState = CheckState.Checked;

            };

            chkHotro.CheckedChanged += (s, e) =>
            {
                if (chkHotro.CheckState == CheckState.Checked)
                    chkBan.CheckState = CheckState.Unchecked;
                else
                    chkBan.CheckState = CheckState.Checked;

            };

            lkeTenNV.EditValueChanged += (s, e) =>
            {
                //DataRowView row = lkeTenNV.Properties.GetDataSourceRowByKeyValue(lkeTenNV.EditValue) as DataRowView;
                DataRowView row = lkeTenNV.Properties.GetRowByKeyValue(lkeTenNV.EditValue) as DataRowView;
                txtSdt.Text = row["EMPMobile"].ToString();
                txtEmailNV.Text = row["EMPEmail"].ToString();
            };

            lkeTenNV.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    //Diable form
                    this.Enabled = false;
                    //
                    F_EMPLOYEE_Details FRM = new F_EMPLOYEE_Details();
                    FRM.myFinished += this.finished;
                    FRM.isAction = "Add";
                    FRM.Show();
                }
            };

            lkeLoaiDN.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    //Diable form
                    this.Enabled = false;
                    //
                    F_CUSTOMERTYPE_Details FRM = new F_CUSTOMERTYPE_Details();
                    FRM.myFinished += this.finished;
                    FRM.isAction = "Add";
                    FRM.Show();
                }
            };

            //txtMavung.ButtonClick += (s, e) =>
            //{
            //    if (e.Button.Index == 1)
            //    {
            //        //Diable form
            //        this.Enabled = false;
            //        //
            //        F_LOCATION_Details FRM = new F_LOCATION_Details();
            //        FRM.myFinished += this.finished;
            //        FRM.isAction = "Add";
            //        FRM.Show();
            //    }
            //};

            

        lkeLoaiDN.EditValueChanged += (s, e) =>
        {
            //XtraMessageBox.Show("Chnageg text");
            //Bán
            if (lkeLoaiDN.EditValue.ToString() == "L01")
            {
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                lkeMaDN.Properties.DataSource = CUSBUS.CUSTOMER_LIST_SAPB1();
                lkeMaDN.Properties.DisplayMember = "CardCode";
                lkeMaDN.Properties.ValueMember = "CardCode";
            }
            //Hỗ trợ
            else if (lkeLoaiDN.EditValue.ToString() == "L02")
            {
                layoutControlItem22.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //lkeMaDN.Properties.ReadOnly = true;
                //txtTenDN.ReadOnly = true;
                //F_CREATE_CUSTOMER FCC = new Class.F_CREATE_CUSTOMER();
                //FCC.Show();
                if (isAction == "Add")
                {
                    if (CUSBUS.MAX_CUSTOMER_CODE() < 10)
                        txtMaDN2.Text = "HT00" + CUSBUS.MAX_CUSTOMER_CODE().ToString();
                    else if (CUSBUS.MAX_CUSTOMER_CODE() < 100 && CUSBUS.MAX_CUSTOMER_CODE() > 9)
                        txtMaDN2.Text = "HT0" + CUSBUS.MAX_CUSTOMER_CODE().ToString();
                    else
                        txtMaDN2.Text = "HT" + CUSBUS.MAX_CUSTOMER_CODE().ToString();
                }
            }
        };
            lkeMaDN.EditValueChanged += (s, e) =>
            {
                DataRowView row = lkeMaDN.GetSelectedDataRow() as DataRowView;
                txtTenDN.Text = row["CardName"].ToString();
                txtDiaChiDN.Text = row["Address"].ToString();
            };

            lkeProvinceName.EditValueChanged += (s, e) =>
             {
                 DataRowView row = lkeProvinceName.GetSelectedDataRow() as DataRowView;
                 txtMavung.Text = row["LOCName"].ToString();                 
             };

            chkKHViphaLAB.CheckedChanged += (s, e) =>
            {
                if (chkKHViphaLAB.CheckState == CheckState.Checked)
                    CUS.CUSTViphaLAB = true;
                else if (chkKHViphaLAB.CheckState == CheckState.Checked)
                    CUS.CUSTViphaLAB = false;
            };

            //Action_EndForm
            action_EndForm1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action_EndForm1.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update));
            action_EndForm1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action_EndForm1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
        }

        private void ItemClickEventHandler_Save(object sender, ItemClickEventArgs e)
        {
            if (this.dxValidationProvider1.Validate() == true)
            {
                if (isAction == "Add")
                {
                    Set4Object();
                    CUSBUS.CUSTOMER_INSERT(CUS);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông báo ";
                    args.Text = "Thêm mới khách hàng thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                else if (isAction == "Edit")
                {
                    Set4Object();
                    CUSBUS.CUSTOMER_UPDATE(CUS);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông báo ";
                    args.Text = "Cập nhật khách hàng thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                Is_close = true;

                //throw new NotImplementedException();
            }
            else
            {
                IList<Control> IControls = this.dxValidationProvider1.GetInvalidControls();
                foreach (Control ctrl in IControls)
                    ctrl.Focus();
            }
        }

        private void ItemClickEventHandler_Close(object sender, ItemClickEventArgs e)
        {
            Is_close = true;
            //this.Close();
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Update(object sender, ItemClickEventArgs e)
        {
            Set4Object();
            CUSBUS.CUSTOMER_UPDATE(CUS);
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 3000;
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            args.DefaultButtonIndex = 0;
            args.Caption = "Thông báo ";
            args.Text = "Cập nhật khách hàng thành công . Thông báo này sẽ tự đóng sau 3 giây.";
            args.Buttons = new DialogResult[] { DialogResult.OK };
            XtraMessageBox.Show(args).ToString();
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void Set4Controls()
        {
            txtID.Text = CUS.Id.ToString();
            lkeLoaiDN.EditValue = CUS.CUSTTYPECode;

            if (lkeLoaiDN.EditValue.ToString() == "L01")
            {
                lkeMaDN.Text = CUS.CUSTCODE;
                txtTenDN.Text = CUS.CUSTNAME;
            }
            else if (lkeLoaiDN.EditValue.ToString() == "L02")
            {
                txtMaDN2.Text = CUS.CUSTCODE;
                txtTenDN2.Text = CUS.CUSTNAME;
            }
            txtSdtDN.Text = CUS.CUSTPHONE;
            txtDiaChiDN.Text = CUS.CUSTADDRESS;
            txtMavung.Text = CUS.LOCName;
            txtMST.Text = CUS.TaxCode;
            cmbKhoa.Text = CUS.Locked.ToString();
            lkeTenNV.EditValue = CUS.EMPCode;
            //lkeLoaiDN.EditValue = CUS.CUSTTYPECode;
            txtNote.Text = CUS.Note;
            txtTenNLH.Text = CUS.ContactName;
            txtSdtNLH.Text = CUS.ContactNumber;
            txtEmailNLH.Text = CUS.ContactEmail;
            //XtraMessageBox.Show(CUS.ProvinceName);
            lkeProvinceName.EditValue = CUS.ProvinceId;

            if (CUS.CUSTTYPECode == "Bán")
                chkBan.CheckState = CheckState.Checked;
            else if (CUS.CUSTTYPECode == "Hỗ trợ" )
                chkHotro.CheckState = CheckState.Checked;

            if (CUS.CUSTViphaLAB == true)
                chkKHViphaLAB.CheckState = CheckState.Checked;
            else if (CUS.CUSTViphaLAB == false || CUS.CUSTViphaLAB == null)
                chkKHViphaLAB.CheckState = CheckState.Unchecked;
        }

        public void Set4Object()
        {
            CUS.CUSTTYPECode = lkeLoaiDN.EditValue.ToString();
            if (lkeLoaiDN.EditValue.ToString() == "L01")
            {
                CUS.CUSTCODE = lkeMaDN.EditValue.ToString();
                CUS.CUSTNAME = txtTenDN.Text;
            }
            else if (lkeLoaiDN.EditValue.ToString() == "L02")
            {
                CUS.CUSTCODE = txtMaDN2.Text;
                CUS.CUSTNAME = txtTenDN2.Text;
            }

            CUS.CUSTPHONE = txtSdtDN.Text;
            CUS.CUSTADDRESS = txtDiaChiDN.Text;
            CUS.LOCName = txtMavung.Text;
            CUS.TaxCode = txtMST.Text;
            CUS.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            CUS.EMPCode = lkeTenNV.EditValue.ToString();
            if (chkBan.CheckState == CheckState.Checked)
                CUS.CUSTTYPECode = "Bán";
            else if (chkHotro.CheckState == CheckState.Checked)
                CUS.CUSTTYPECode = "Hỗ trợ";

            CUS.Note = txtNote.Text;
            CUS.ContactName = txtTenNLH.Text;
            CUS.ContactNumber = txtSdtNLH.Text;
            CUS.ContactEmail = txtEmailNLH.Text;
            //XtraMessageBox.Show(cmbProvinceName.SelectedText);
            CUS.ProvinceName = lkeProvinceName.Text;
            CUS.ProvinceId = int.Parse(lkeProvinceName.EditValue.ToString());
            CUS.CUSTViphaLAB = chkKHViphaLAB.CheckState == CheckState.Checked ? true : false;
        }

        public void ResetControl()
        {
            if (lkeLoaiDN.EditValue.ToString() == "L01")
            {
                lkeMaDN.EditValue = "";
                txtTenDN.Text = "";
            }
            else if (lkeLoaiDN.EditValue.ToString() == "L02")
            {
                txtMaDN2.Text = "";
                txtTenDN2.Text = "";
            }
            lkeLoaiDN.EditValue = null;
            //lkeMaDN.Text = "";
            //txtTenDN.Text = "";
            txtSdtDN.Text = "";
            txtDiaChiDN.Text = "";
            txtMavung.EditValue = null;
            txtMST.Text = "";
            cmbKhoa.Text = "";
            lkeTenNV.EditValue = null;
            lkeLoaiDN.EditValue = null;
            txtNote.Text = "";
            txtTenNLH.Text = "";
            txtSdtNLH.Text = "";
            txtEmailNLH.Text = "";
            lkeProvinceName.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            if (lkeLoaiDN.EditValue.ToString() == "L01")
            {
                lkeMaDN.ReadOnly = bl;
                txtTenDN.ReadOnly = bl;
            }
            else if (lkeLoaiDN.EditValue.ToString() == "L02")
            {
                txtMaDN2.ReadOnly = bl;
                txtTenDN2.ReadOnly = bl;
            }
            lkeLoaiDN.ReadOnly = bl;
            //lkeMaDN.ReadOnly = bl;
            //txtTenDN.ReadOnly = bl;
            txtSdtDN.ReadOnly = bl;
            txtDiaChiDN.ReadOnly = bl;
            txtMavung.ReadOnly = bl;
            txtMST.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
            lkeTenNV.ReadOnly = bl;
            lkeLoaiDN.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            txtTenNLH.ReadOnly = bl;
            txtSdtNLH.ReadOnly = bl;
            txtEmailNLH.ReadOnly = bl;
        }

        public void finished(object sender)
        {
            //Diable form
            this.Enabled = true;
            //
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();
            //// Step 2 : Load lại data tren grid sau khi Add
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_EMPLOYEE' table. You can move, or remove it, as needed.
            this.tbl_EMPLOYEETableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_CUSTOMERTYPE' table. You can move, or remove it, as needed.
            this.tbl_CUSTOMERTYPETableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_CUSTOMERTYPE_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LOCATION' table. You can move, or remove it, as needed.
            this.tbl_ProvinceTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_Province);
        }

        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_Province' table. You can move, or remove it, as needed.
            this.tbl_ProvinceTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_Province);
            // TODO: This line of code loads data into the 'vIPHAVETDataset.OCRD' table. You can move, or remove it, as needed.
            this.oCRDTableAdapter.Fill(this.vIPHAVETDataset.OCRD);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_EMPLOYEE' table. You can move, or remove it, as needed.
            this.tbl_EMPLOYEETableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_CUSTOMERTYPE' table. You can move, or remove it, as needed.
            this.tbl_CUSTOMERTYPETableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_CUSTOMERTYPE_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LOCATION' table. You can move, or remove it, as needed.
            this.tbl_ProvinceTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_Province);
        }
    }
}