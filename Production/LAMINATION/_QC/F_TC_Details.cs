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
    public partial class F_TC_Details : frm_Base
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
        public TieuChuan TC = new TieuChuan();
        TieuChuanBUS TCBUS = new TieuChuanBUS();

        public F_TC_Details()
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
                        TCBUS.TC_INSERT(TC);
                    }
                    else if (isAction == "Edit")
                    {                        
                        Set4Object();
                        TCBUS.TC_UPDATE(TC);
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
            txtID.Text = TC.ID.ToString();
            txtTC.Text = TC.TC;
            txtDienGiai.Text = TC.TCDG;
            txtNote.Text = TC.Note;
            cmbKhoa.Text = TC.Locked.ToString();

        }

        public void Set4Object()
        {
            if (isAction == "Edit")
                TC.ID = int.Parse(txtID.Text);
            TC.TC = txtTC.Text;
            TC.TCDG = txtDienGiai.Text;
            TC.Note = txtNote.Text;
            TC.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }
        public void ResetControl()
        {
            txtID.Text = "";
            txtTC.Text = "";
            txtDienGiai.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            txtTC.ReadOnly = bl;
            txtDienGiai.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
        }

    }
}
