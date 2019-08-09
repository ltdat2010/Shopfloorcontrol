using System;
using System.Windows.Forms;
using System.IO;

namespace Production.Class
{
    public partial class F_COA_Template_Details_Added_Row : frm_Base
    {
        string Path = Directory.GetCurrentDirectory();
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
        public COA_Template_Details OBJ = new COA_Template_Details();
        COA_Template_DetailsBUS BUS = new COA_Template_DetailsBUS();

        public F_COA_Template_Details_Added_Row()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                LoadDataIntoTable();
                
                if (isAction == "Edit")
                {
                    txtID.ReadOnly = true;
                    Set4Controls();
                }
                else if (isAction == "Add")
                {
                    txtID.ReadOnly = true;
                    txtCOAID.Text = OBJ.COATemplateID.ToString() ;
                }                    
            };

            btnSave.Click += (s,e) =>
            {         
                    if (isAction == "Add")
                    {
                        Set4Object();
                        BUS.COA_Template_DetailsDAO_INSERT(OBJ);
                    }
                    else if (isAction == "Edit")
                    {                        
                        Set4Object();
                        BUS.COA_Template_DetailsDAO_UPDATE(OBJ);
                    }                
                    Is_close = true;                
            };

            btnCancel.Click += (s, e) =>
            {
                this.Close();
            };

            lkeHMKT.ButtonClick += (s, e) =>
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

            txtCOAID.Text = OBJ.COATemplateID.ToString();            
            
            lkeHMKT.EditValue = OBJ.HMKTID;
            
            txtTolerance.EditValue = OBJ.Tolerance;           

            txtNote.Text = OBJ.Note;

            cmbKhoa.Text = OBJ.Locked.ToString();
        }

        public void Set4Object()
        {
            if (isAction == "Edit")
                OBJ.ID = int.Parse(txtID.Text);

            OBJ.COATemplateID = int.Parse(txtCOAID.Text);

            OBJ.HMKTID = int.Parse(lkeHMKT.EditValue.ToString());

            OBJ.Tolerance = txtTolerance.Text;

            OBJ.Note = txtNote.Text;
            
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            
        }
        public void ResetControl()
        {
            txtID.Text = "";
            txtCOAID.Text = "";
            lkeHMKT.EditValue = "";
            txtTolerance.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            
            lkeHMKT.ReadOnly = bl;
            txtTolerance.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
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
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_HangMucKiemTra' table. You can move, or remove it, as needed.
            this.tbl_HangMucKiemTraTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_HangMucKiemTra);
        }
    }
}
