using System;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_CUSTOMERTYPE_Details : frm_Base
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

        public CUSTOMERTYPE CUSTPE = new CUSTOMERTYPE();
        private CUSTOMERTYPEBUS CUSTPEBUS = new CUSTOMERTYPEBUS();

        public F_CUSTOMERTYPE_Details()
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
                        CUSTPEBUS.CUSTOMERTYPE_INSERT(CUSTPE);
                    }
                    else if (isAction == "Edit")
                    {
                        Set4Object();
                        CUSTPEBUS.CUSTOMERTYPE_UPDATE(CUSTPE);
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
            txtID.Text = CUSTPE.Id.ToString();
            txtMaKH.Text = CUSTPE.CUSTTYPECode;
            txtTenKH.Text = CUSTPE.CUSTTYPEName;
            txtNote.Text = CUSTPE.Note;
            cmbKhoa.Text = CUSTPE.Locked.ToString();
        }

        public void Set4Object()
        {
            CUSTPE.CUSTTYPECode = txtMaKH.Text;
            CUSTPE.CUSTTYPEName = txtTenKH.Text;
            CUSTPE.Note = txtNote.Text;
            CUSTPE.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }

        public void ResetControl()
        {
            txtID.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            txtMaKH.ReadOnly = bl;
            txtTenKH.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
        }
    }
}