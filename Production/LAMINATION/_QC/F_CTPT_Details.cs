using System;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_CTPT_Details : frm_Base
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

        public ChiTieuPhanTich CTPT = new ChiTieuPhanTich();
        private ChiTieuPhanTichBUS CTPTBUS = new ChiTieuPhanTichBUS();

        public F_CTPT_Details()
        {
            InitializeComponent();
            Load += (s, e) =>
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

            btnSave.Click += (s, e) =>
            {
                try
                {
                    if (isAction == "Add")
                    {
                        Set4Object();
                        CTPTBUS.CTPT_INSERT(CTPT);
                    }
                    else if (isAction == "Edit")
                    {
                        Set4Object();
                        CTPTBUS.CTPT_UPDATE(CTPT);
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
                this.Close();
            };
        }

        public void Set4Controls()
        {
            txtID.Text = CTPT.ID.ToString();
            txtCTPT.Text = CTPT.CTPT;
            txtDienGiai.Text = CTPT.CTPTDG;
            txtNote.Text = CTPT.Note;
            cmbKhoa.Text = CTPT.Locked.ToString();
        }

        public void Set4Object()
        {
            if (isAction == "Edit")
                CTPT.ID = int.Parse(txtID.Text);
            CTPT.CTPT = txtCTPT.Text;
            CTPT.CTPTDG = txtDienGiai.Text;
            CTPT.Note = txtNote.Text;
            CTPT.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }

        public void ResetControl()
        {
            txtID.Text = "";
            txtCTPT.Text = "";
            txtDienGiai.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            txtCTPT.ReadOnly = bl;
            txtDienGiai.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
        }
    }
}