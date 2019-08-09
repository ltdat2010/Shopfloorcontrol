using System;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;

namespace Production.Class
{
    public partial class F_NCTXN_Details : frm_Base
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
        public NHOMCHITIEUXETNGHIEM OBJ = new NHOMCHITIEUXETNGHIEM();
        NHOMCHITIEUXETNGHIEMBUS BUS = new NHOMCHITIEUXETNGHIEMBUS();

        public F_NCTXN_Details()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                //if(isEditting == true)
                if (isAction == "Edit")
                {
                    txtID.ReadOnly = true;
                    Set4Controls();
                }
                else if (isAction == "Add")
                    txtID.ReadOnly = true;
            };

            btnSave.Click += (s,e) =>
            {
                try
                {
                    if (isAction == "Add")
                    {
                        Set4Object();
                        BUS.NCTXN_INSERT(OBJ);
                        XtraMessageBox.Show("Đã thêm mới nhóm chỉ tiêu xét nghiệm thành công", "Info .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (isAction == "Edit")
                    {                        
                        Set4Object();
                        BUS.NCTXN_UPDATE(OBJ);
                        XtraMessageBox.Show("Đã cập nhật nhóm chỉ tiêu xét nghiệm thành công", "Info .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                //XtraMessageBox.Show("here");
                    Is_close = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };

            btnCancel.Click += (s, e) =>
            {
                Is_close = true;
                //this.Close();
            };
            
        }
        public void Set4Controls()
        {
            txtID.Text = OBJ.ID.ToString();
            txtPPXN.Text = OBJ.NCTXN;
            txtDienGiai.Text = OBJ.NCTXNDG;
            txtNote.Text = OBJ.Note;
            cmbKhoa.Text = OBJ.Locked.ToString();

        }

        public void Set4Object()
        {
            if (isAction == "Edit")
                OBJ.ID = int.Parse(txtID.Text);
            OBJ.NCTXN = txtPPXN.Text;
            OBJ.NCTXNDG = txtDienGiai.Text;
            OBJ.Note = txtNote.Text;
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }
        public void ResetControl()
        {
            txtID.Text = "";
            txtPPXN.Text = "";
            txtDienGiai.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            txtPPXN.ReadOnly = bl;
            txtDienGiai.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
        }

    }
}
