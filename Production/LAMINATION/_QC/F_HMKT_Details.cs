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
    public partial class F_HMKT_Details : frm_Base
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
        public HangMucKiemTra OBJ = new HangMucKiemTra();
        HangMucKiemTraBUS BUS = new HangMucKiemTraBUS();

        public F_HMKT_Details()
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
                        BUS.HMKT_INSERT(OBJ);
                    }
                    else if (isAction == "Edit")
                    {                        
                        Set4Object();
                        BUS.HMKT_UPDATE(OBJ);
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
            txtHMKT.Text = OBJ.HMKT;
            txtHMKTEN.Text = OBJ.HMKTEN;
            cmbCharcteristic.Text = OBJ.Characteristic;
            txtNote.Text = OBJ.Note;
            cmbKhoa.Text = OBJ.Locked.ToString();

        }

        public void Set4Object()
        {
            if (isAction == "Edit")
                OBJ.ID = int.Parse(txtID.Text);
            OBJ.HMKT = txtHMKT.Text;
            OBJ.HMKTEN = txtHMKTEN.Text;
            OBJ.Characteristic = cmbCharcteristic.Text;
            OBJ.Note = txtNote.Text;
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }
        public void ResetControl()
        {
            txtID.Text = "";
            txtHMKT.Text = "";
            txtHMKTEN.Text = "";
            cmbCharcteristic.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            txtHMKT.ReadOnly = bl;
            txtHMKTEN.ReadOnly = bl;
            cmbCharcteristic.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
        }

    }
}
