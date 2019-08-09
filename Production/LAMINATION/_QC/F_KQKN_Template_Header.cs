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
    public partial class F_KQKN_Template_Header : frm_Base
    {
        bool gridViewRowClick = false;
        string Path = Directory.GetCurrentDirectory();

               
        /// <summary>
        /// DELEGATE
        /// </summary>        
        public delegate void MyAdd(object sender, string isActionReturn);
        public event MyAdd myFinished;

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this, isActionReturn: isAction);
                }
            }
        }
        public KQKN_Template_Header OBJ = new KQKN_Template_Header();
        public KQKN_Template_Details_Row OBJ1 = new KQKN_Template_Details_Row();

        KQKN_Template_HeaderBUS BUS = new KQKN_Template_HeaderBUS();
        KQKN_Template_Details_RowBUS BUS1 = new KQKN_Template_Details_RowBUS();

        public F_KQKN_Template_Header()
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
                    gridControl1.Enabled = false;
                    actionMini1.Enabled = false;
                    txtID.ReadOnly = true;
                    ////gridControl1.DataSource = null;
                }
                    
            };

            btnSave.Click += (s,e) =>
            {
                try
                {
                    btnSave.Enabled = false;

                    if (isAction == "Add")
                    {
                        Set4Object();
                        BUS.KQKN_Template_Header_INSERT(OBJ);
                        gridControl1.Enabled = true;
                        actionMini1.Enabled = true;
                        //Gan gia tri ID moi insert vo table tbl_KQKN_Template_Hedaer cho form
                        OBJ.ID = BUS.MAX_KQKB_Template_ID();
                    }
                    else if (isAction == "Edit")
                    {                        
                        Set4Object();
                        //MessageBox.Show(OBJ.SoMRA.ToString());
                        BUS.KQKN_Template_Header_UPDATE(OBJ);
                    }
                //XtraMessageBox.Show("here");
                    Is_close = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
            gridView1.RowClick += (s, e) =>
            {
                gridViewRowClick = true;
                Set4Object();
            };


                btnCancel.Click += (s, e) =>
            {
                this.Close();
            };

            txtNote.TextChanged += (s, e) =>
            {
                if (isAction == "Edit" || isAction == "Changed")
                {
                    isAction = "Changed";
                    btnSave.Enabled = true;
                }
            };
            cmbKhoa.TextChanged += (s, e) =>
            {
                if (isAction == "Edit" || isAction == "Changed")
                {
                    isAction = "Changed";
                    btnSave.Enabled = true;
                }
            };

            // 7 Add hoặc New
            actionMini1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));

            // 8 Lưu
            actionMini1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));

            // 9 Edit hoặc Update
            actionMini1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));

            // 10 Del
            actionMini1.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete));

            // 10a View
            actionMini1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            // 10B Cancel
            actionMini1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
        }        

        public void Set4Controls()
        {
            txtID.Text = OBJ.ID.ToString();
            txtTenmauKQKN.Text = OBJ.KQKNTemplate.ToString();
            txtSoMRA.Text = OBJ.SoMRA.ToString();
            //lkeCTPT.Text = CTPT.CTPT;
            //lkeTC.Text = CTPT.CTPTDG;
            txtNote.Text = OBJ.Note;
            cmbKhoa.Text = OBJ.Locked.ToString();

        }

        public void Set4Object()
        {
            if (isAction == "Edit")
            {
                //OBJ
                OBJ.ID = int.Parse(txtID.Text);
                //OBJ1
                OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                OBJ1.KQKNTemplateID = int.Parse(gridView1.GetFocusedRowCellValue("KQKNTemplateID").ToString());
                OBJ1.STT = gridView1.GetFocusedRowCellValue("STT").ToString();
                MessageBox.Show(OBJ1.STT);
                OBJ1.TCID = int.Parse(gridView1.GetFocusedRowCellValue("TCID").ToString());
                OBJ1.CTPTID = int.Parse(gridView1.GetFocusedRowCellValue("CTPTID").ToString());
                OBJ1.PPTID = int.Parse(gridView1.GetFocusedRowCellValue("PPTID").ToString());
                OBJ1.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
                OBJ1.CreatedBy = gridView1.GetFocusedRowCellValue("CreatedBy").ToString();
                OBJ1.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            }    
            
                OBJ.KQKNTemplate = txtTenmauKQKN.Text;
                OBJ.SoMRA = txtSoMRA.Text;
                OBJ.Note = txtNote.Text;
                OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;      
        }

        

        public void ResetControl()
        {
            txtID.Text = "";
            txtTenmauKQKN.Text = "";
            txtSoMRA.Text = "";
            //lkeCTPT.Text = "";
            //lkeTC.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            //lkeCTPT.ReadOnly = bl;
            //lkeTC.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            txtSoMRA.ReadOnly = bl;
            txtTenmauKQKN.ReadOnly = bl;
            txtNote.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
        }


        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isActionMini = "Add";
            //Riêng cho trường hợp tạo mới Row trên KQKN template
            //Truyen ID cua KQKN template cho Row
            OBJ1.KQKNTemplateID = OBJ.ID;

            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            F_KQKN_Template_Details_Added_Row FRM = new F_KQKN_Template_Details_Added_Row();
            FRM.isAction = this.isActionMini;
            FRM.OBJ = this.OBJ1;
            if (gridView1.DataRowCount == 0)
                FRM.STT = 1;
            else
                FRM.STT = int.Parse(this.gridView1.GetRowCellValue(gridView1.DataRowCount - 1, "STT").ToString()) + 1;
            FRM.myFinished += this.finished;
            FRM.Show();
        }
        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            // 25 isEditting gan bang true 
            //isEditting = true;
            isActionMini = "Edit";

            state = MenuState.Update;

            if (gridViewRowClick == true)
            {
                Set4Object();
                // Truyen object LOC to DELEGATE
                F_KQKN_Template_Details_Added_Row F_LOC_Dtl = new F_KQKN_Template_Details_Added_Row();
                F_LOC_Dtl.OBJ = this.OBJ1;
                MessageBox.Show(OBJ1.STT);                    
                F_LOC_Dtl.isAction = this.isActionMini;
                F_LOC_Dtl.myFinished += this.finished;
                F_LOC_Dtl.Show();
            }
            else
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
        }
        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {

        }
        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            // 23 Gán state UPdate cho tat ca cac nut
            state = MenuState.Update;

            //24  Edit hoặc update nên  isNew gán bằng false
            //isNew = false;

            // 25 isEditting gan bang true 
            //isEditting = true;
            isActionMini = "View";

            // 26 COntrols gỡ bỏ trạng thái đọc cho phép nhập liệu
            //ControlsReadOnly(false);

            // Truyen object LOC to DELEGATE
            F_KQKN_Template_Details_Added_Row F_LOC_Dtl = new F_KQKN_Template_Details_Added_Row();
            F_LOC_Dtl.isAction = this.isActionMini;
            F_LOC_Dtl.OBJ = this.OBJ1;
            F_LOC_Dtl.myFinished += this.finished;
            F_LOC_Dtl.Show();
        }

        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            // 14 Khai báo state cho các nút khi nhấn nút Del
            state = MenuState.Delete;

            if (gridViewRowClick == true)
            {
                OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                OBJ1.STT = gridView1.GetFocusedRowCellValue("STT").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa muc  : " + OBJ1.STT + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    BUS1.KQKN_Template_Details_Row_DELETE(OBJ1);
                }
                // 18 Load lại datasource cho grid

                gridControl1.DataSource = tbl_KQKN_Template_DetailsTableAdapter.FillByKQKNTemplateID(this.sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Details, OBJ.ID);

                gridView1.BestFitColumns();
                // 17 trả trạng thái cho các nút như ban đầu
                state = MenuState.Full;
            }
            else
                // 16 Xác nhận có muốn xoa không ?
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
        }

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
            if (isAction != "Changed")
                this.Close();
            else
            {
                DialogResult Dlg = XtraMessageBox.Show(" Bạn đã thay đổi nội dung kết luận. Bạn có muốn lưu lại ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Dlg == DialogResult.No)
                    this.Close();
                else
                {
                    Set4Object();
                    BUS.KQKN_Template_Header_UPDATE(OBJ);
                    this.Close();
                }
            }
        }

        public void finished(object sender)
        {
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            // Step 2 : Load lại data tren grid sau khi Add            
            gridControl1.DataSource = tbl_KQKN_Template_DetailsTableAdapter.FillByKQKNTemplateID(this.sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Details, OBJ.ID);
            
            gridView1.BestFitColumns();                        
        }

        

        private void F_PKQKN_Template_Header_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KQKNTemplate_Details' table. You can move, or remove it, as needed.
            this.tbl_KQKN_Template_DetailsTableAdapter.FillByKQKNTemplateID(this.sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Details,OBJ.ID);
        }
    }
}
