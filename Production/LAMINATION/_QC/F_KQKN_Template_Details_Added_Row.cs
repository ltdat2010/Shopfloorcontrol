using System;
using System.Windows.Forms;
using System.IO;

namespace Production.Class
{
    public partial class F_KQKN_Template_Details_Added_Row : frm_Base
    {
        string Path = Directory.GetCurrentDirectory();
        public int STT;
        //public string isAction = "";
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
        public KQKN_Template_Details_Row OBJ = new KQKN_Template_Details_Row();
        KQKN_Template_Details_RowBUS BUS = new KQKN_Template_Details_RowBUS();

        public F_KQKN_Template_Details_Added_Row()
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
                {
                    txtID.ReadOnly = true;
                    txtKQKNTemplateID.Text = OBJ.KQKNTemplateID.ToString() ;
                    txtSTT.Text = STT.ToString();
                }
                    
            };

            btnSave.Click += (s,e) =>
            {         
                    if (isAction == "Add")
                    {
                        Set4Object();
                        BUS.KQKN_Template_Details_Row_INSERT(OBJ);
                    }
                    else if (isAction == "Edit")
                    {                        
                        Set4Object();
                        BUS.KQKN_Template_Details_Row_UPDATE(OBJ);
                    }                
                    Is_close = true;                
            };

            btnCancel.Click += (s, e) =>
            {
                this.Close();
            };

            lkeTC.ButtonClick += (s, e) =>
            {
                if(e.Button.Index == 1)
                {
                    
                    F_TC_Details FRM = new Class.F_TC_Details();
                    FRM.isAction = "Add";
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
            };

            lkePPT.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    
                    F_PPT_Details FRM = new F_PPT_Details();
                    FRM.isAction = "Add";
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
            };

            lkeCTPT.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    
                    F_CTPT_Details FRM = new F_CTPT_Details();
                    FRM.isAction = "Add";
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
            };


        }
        public void Set4Controls()
        {
            txtID.Text = OBJ.ID.ToString();
            //MessageBox.Show(txtID.Text);
            txtKQKNTemplateID.Text = OBJ.KQKNTemplateID.ToString();
            //MessageBox.Show(OBJ.STT.ToString());
            txtSTT.Text = OBJ.STT.ToString();
            
            lkeCTPT.EditValue = OBJ.CTPTID;
            
            lkeTC.EditValue = OBJ.TCID;

            lkePPT.EditValue = OBJ.PPTID;

            txtNote.Text = OBJ.Note;

            cmbKhoa.Text = OBJ.Locked.ToString();
        }

        public void Set4Object()
        {
            if (isAction == "Edit")
                OBJ.ID = int.Parse(txtID.Text);
            OBJ.KQKNTemplateID = int.Parse(txtKQKNTemplateID.Text);
            OBJ.STT = txtSTT.Text.ToString();
            OBJ.CTPTID = int.Parse(string.IsNullOrEmpty(lkeCTPT.Text.ToString()) == true ? "1" : lkeCTPT.EditValue.ToString());
            
            OBJ.TCID = int.Parse(string.IsNullOrEmpty(lkeTC.Text.ToString()) == true ? "1" : lkeTC.EditValue.ToString());
            
            OBJ.PPTID = int.Parse(string.IsNullOrEmpty(lkePPT.Text.ToString()) == true ? "1" : lkePPT.EditValue.ToString());
            
            OBJ.Note = txtNote.Text;
            
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            
        }
        public void ResetControl()
        {
            txtID.Text = "";
            txtSTT.Text = "";
            txtKQKNTemplateID.Text = "";
            lkeCTPT.EditValue = "";
            lkeTC.EditValue = "";
            lkePPT.EditValue = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            txtSTT.ReadOnly = bl;
            lkeCTPT.ReadOnly = bl;
            lkeTC.ReadOnly = bl;
            lkePPT.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
        }

        private void F_KQKN_Template_Details_Row_Load(object sender, EventArgs e)
        {
            LoadDataIntoTable();
        }

        public void finished(object sender)
        {
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            LoadDataIntoTable();
        }

        public void LoadDataIntoTable()
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PhuongPhapThu' table. You can move, or remove it, as needed.
            this.tbl_PhuongPhapThuTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_PhuongPhapThu);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_TieuChuan' table. You can move, or remove it, as needed.
            this.tbl_TieuChuanTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_TieuChuan);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_ChiTieuPhanTich' table. You can move, or remove it, as needed.
            this.tbl_ChiTieuPhanTichTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuPhanTich);
        }
    }
}
