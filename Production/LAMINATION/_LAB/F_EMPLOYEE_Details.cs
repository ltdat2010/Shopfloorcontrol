using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraBars;
using System.Collections.Generic;

namespace Production.Class
{
    public partial class F_EMPLOYEE_Details : frm_Base
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
        public EMPLOYEE EMP                     = new EMPLOYEE();
        EMPLOYEEBUS EMPBUS                      = new EMPLOYEEBUS();

        public F_EMPLOYEE_Details()
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
                    txtID.ReadOnly = true;
                    Set4Controls();
                }
                else if (isAction == "Add")
                    txtID.ReadOnly = true;
            };          

            //Action_EndForm
            //action_EndForm1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            //action_EndForm1.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update));
            action_EndForm1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action_EndForm1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));


        }

        private void ItemClickEventHandler_Save(object sender, ItemClickEventArgs e)
        {
            

            try
            {
                if (this.dxValidationProvider1.Validate() == true)
                {

                    if (isAction == "Add")
                    {
                        Set4Object();
                        EMPBUS.EMPLOYEE_INSERT(EMP);
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 3000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Thông báo ";
                        args.Text = "Lưu mới thông tin nhân viên thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                        args.Buttons = new DialogResult[] { DialogResult.OK };
                        XtraMessageBox.Show(args).ToString();
                    }
                    else if (isAction == "Edit")
                    {
                        Set4Object();
                        EMPBUS.EMPLOYEE_UPDATE(EMP);
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 3000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Thông báo ";
                        args.Text = "Cập nhật thông tin nhân viên thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                        args.Buttons = new DialogResult[] { DialogResult.OK };
                        XtraMessageBox.Show(args).ToString();
                    }

                    Is_close = true;
                }
                else
                {
                    IList<Control> IControls = this.dxValidationProvider1.GetInvalidControls();
                    foreach (Control ctrl in IControls)
                        ctrl.Focus();
                }
                   
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
            txtID.Text = EMP.Id.ToString();
            txtMaNhanvien.Text = EMP.EMPCode;
            txtTenNhanvien.Text = EMP.EMPName;
            txtSdt.Text = EMP.EMPMobile;
            txtEmail.Text = EMP.EMPEmail;
            txtNote.Text = EMP.Note;
            cmbKhoa.Text = EMP.Locked.ToString();

        }

        public void Set4Object()
        {
            EMP.EMPCode                             = txtMaNhanvien.Text;
            EMP.EMPName                             = txtTenNhanvien.Text;
            EMP.EMPMobile                           = txtSdt.Text;
            EMP.EMPEmail                            = txtEmail.Text;
            EMP.Note = txtNote.Text;
            EMP.Locked                              = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }
        public void ResetControl()
        {
            txtID.Text                              = "";
            txtMaNhanvien.Text                      = "";
            txtTenNhanvien.Text                     = "";
            txtEmail.Text                           = "";
            txtSdt.Text                             = "";
            txtNote.Text = "";
            cmbKhoa.Text                            = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            txtMaNhanvien.ReadOnly                  = bl;
            txtTenNhanvien.ReadOnly                 = bl;
            txtSdt.ReadOnly                         = bl;
            txtEmail.ReadOnly                       = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly                        = bl;
        }

    }
}
