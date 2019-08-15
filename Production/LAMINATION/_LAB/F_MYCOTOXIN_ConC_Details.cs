using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_MYCOTOXIN_ConC_Details : frm_Base
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

        public MYCOTOXIN_ConC CUS = new MYCOTOXIN_ConC();
        private MYCOTOXIN_ConCBUS CUSBUS = new MYCOTOXIN_ConCBUS();

        public F_MYCOTOXIN_ConC_Details()
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
                    CUSBUS.MYCOTOXIN_ConC_INSERT(CUS);
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
                    CUSBUS.MYCOTOXIN_ConC_UPDATE(CUS);
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

            txtAcronym.EditValue = CUS.CTXN_ID;
            txtConC.Text = CUS.ConC.ToString();
            txtKHMau.Text = CUS.KHMau;
            cmbKhoa.Text = CUS.Locked.ToString();
            txtNote.Text = CUS.Note;
        }

        public void Set4Object()
        {
            if (isAction == "Edit")
            {
                CUS.ID = int.Parse(txtID.Text.ToString());
            }
            CUS.CTXN_ID = int.Parse(txtAcronym.EditValue.ToString());
            CUS.ConC = double.Parse(txtConC.Text);
            CUS.KHMau = txtKHMau.Text;
            CUS.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            CUS.Note = txtNote.Text;
        }

        public void ResetControl()
        {
            //lkeMaDN.Text = "";
            //txtTenDN.Text = "";

            txtConC.Text = "";
            txtKHMau.Text = "";
            cmbKhoa.Text = "";
            txtNote.Text = "";
            txtAcronym.Text = "";
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            txtConC.ReadOnly = bl;
            txtKHMau.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            txtAcronym.ReadOnly = bl;
        }

        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB' table. You can move, or remove it, as needed.
            this.tbl_ChiTieuXetNghiem_LABTableAdapter.FillAcronym(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB);
        }
    }
}