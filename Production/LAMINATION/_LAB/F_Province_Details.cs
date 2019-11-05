﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_Province_Details : frm_Base
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

        public Province LOC = new Province();
        private ProvinceBUS LOCBUS = new ProvinceBUS();

        public F_Province_Details()
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
                if (isAction == "Add")
                {
                    Set4Object();
                    LOCBUS.Province_INSERT(LOC);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông báo ";
                    args.Text = "Đã thêm mới khu vực thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                else if (isAction == "Edit")
                {
                    Set4Object();
                    LOCBUS.Province_UPDATE(LOC);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông báo ";
                    args.Text = "Đã cập nhật thông tin khu vực thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                //XtraMessageBox.Show("here");
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
            //throw new NotImplementedException();
        }

        public void Set4Controls()
        {
            txtID.Text = LOC.Id.ToString();
            txtKhuvuc.Text = LOC.ProvinceCode;
            txtTenKhuvuc.Text = LOC.ProvinceName;
            lkeLOCId.EditValue = LOC.LOCId;
            txtNote.Text = LOC.Note;
            cmbKhoa.Text = LOC.Locked.ToString();
        }

        public void Set4Object()
        {
            LOC.ProvinceCode = txtKhuvuc.Text;
            LOC.ProvinceName = txtTenKhuvuc.Text;
            LOC.LOCId = int.Parse(lkeLOCId.EditValue.ToString());
            LOC.Note = txtNote.Text;
            LOC.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }

        public void ResetControl()
        {
            txtID.Text = "";
            txtKhuvuc.Text = "";
            txtTenKhuvuc.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            txtKhuvuc.ReadOnly = bl;
            txtTenKhuvuc.ReadOnly = bl;
            lkeLOCId.Properties.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
        }

        private void F_Province_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LOCATION_LAB' table. You can move, or remove it, as needed.
            this.tbl_LOCATION_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LOCATION_LAB);

        }
    }
}