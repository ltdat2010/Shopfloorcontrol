using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Production.Class
{
    public partial class F_PPT_Details : frm_Base
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
        public PhuongPhapThu OBJ = new PhuongPhapThu();
        PhuongPhapThuBUS BUS = new PhuongPhapThuBUS();

        public F_PPT_Details()
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
                        BUS.PPT_INSERT(OBJ);
                    }
                    else if (isAction == "Edit")
                    {                        
                        Set4Object();
                        BUS.PPT_UPDATE(OBJ);
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
            txtID.Text = OBJ.ID.ToString();
            txtCTPT.Text = OBJ.PPT;
            txtDienGiai.Text = OBJ.PPTDG;
            txtNote.Text = OBJ.Note;
            cmbKhoa.Text = OBJ.Locked.ToString();

        }

        public void Set4Object()
        {
            if (isAction == "Edit")
                OBJ.ID = int.Parse(txtID.Text);
            OBJ.PPT = txtCTPT.Text;
            OBJ.PPTDG = txtDienGiai.Text;
            OBJ.Note = txtNote.Text;
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
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
