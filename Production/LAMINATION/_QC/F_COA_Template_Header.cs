using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_COA_Template_Header : frm_Base
    {
        #region Variables

        private int ImageID = 0;
        private String strFilePath = "";
        private Image DefaultImage;
        private Byte[] ImageByteArray;
        ////before executing -create database with given script - change connection string according to yours
        //public static string varConnect_S = "Data Source= 192.168.0.249;" +
        //                                       "Database= SYNC_NUTRICIEL;" +
        //                                       "User ID= netika;" +
        //                                       "password= bsvn";
        ////public static SqlConnection conn_S = new SqlConnection(Conn.varConnect_S);
        //SqlConnection sqlcon = new SqlConnection(varConnect_S);

        #endregion Variables

        private bool gridViewRowClick = false;
        private string Path = Directory.GetCurrentDirectory();

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

        public COA_Template_Header OBJ = new COA_Template_Header();
        private COA_Template_Details OBJ1 = new COA_Template_Details();
        //public KQKN_Template_Details_Row OBJ1 = new KQKN_Template_Details_Row();

        private COA_Template_HeaderBUS BUS = new COA_Template_HeaderBUS();
        private COA_Template_DetailsBUS BUS1 = new COA_Template_DetailsBUS();

        public F_COA_Template_Header()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                if (isAction == "Edit")
                {
                    TDControlsReadOnly(true);
                    Set4Controls();

                    gridControl1.DataSource = tbl_COA_Template_DetailsTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA_Template_Details, int.Parse(txtID.Text));

                    //ImageByteArray = OBJ.IMGCOA;
                    //pbxImage.Image = Image.FromStream(new MemoryStream(OBJ.IMGCOA));
                }
                else if (isAction == "Add")
                {
                    gridControl1.Enabled = false;
                    actionMini1.Enabled = false;
                    txtID.ReadOnly = true;
                }
            };

            btnSave.Click += (s, e) =>
            {
                try
                {
                    btnSave.Enabled = false;

                    if (isAction == "Add")
                    {
                        Set4ObjectHeader();
                        Set4ObjectRow();
                        BUS.COA_Template_HeaderDAO_INSERT(OBJ);
                        gridControl1.Enabled = true;
                        actionMini1.Enabled = true;

                        //Gan gia tri ID moi insert vo table tbl_KQKN_Template_Hedaer cho form
                        OBJ.ID = BUS.MAX_COA_Template_ID();
                    }
                    else if (isAction == "Edit")
                    {
                        Set4ObjectHeader();
                        Set4ObjectRow();

                        BUS.COA_Template_HeaderDAO_UPDATE(OBJ);
                    }

                    ///////////////Save image/////////////////////////////////////////////////////////////////
                    Image temp;
                    if (strFilePath == "")
                    {
                        //if (ImageByteArray.Length != 0)
                        //ImageByteArray = new byte[] { };
                        temp = (Bitmap)Properties.Resources.defaultimage;
                    }
                    else
                    {
                        temp = new Bitmap(strFilePath);
                    }

                    MemoryStream strm = new MemoryStream();
                    temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ImageByteArray = strm.ToArray();

                    if (Conn.conn_S.State == ConnectionState.Closed)
                        Conn.conn_S.Open();
                    SqlCommand sqlCmd = new SqlCommand("ImageAddOrEdit", Conn.conn_S) { CommandType = CommandType.StoredProcedure };
                    sqlCmd.Parameters.Add("@Image", ImageByteArray);
                    sqlCmd.Parameters.Add("@ID", OBJ.ID);
                    sqlCmd.ExecuteNonQuery();
                    Conn.conn_S.Close();
                    //MessageBox.Show("Saved successfuly");
                    //Clear();
                    //XtraMessageBox.Show("1");
                    //XtraMessageBox.Show("OBJ.ID : " + OBJ.ID.ToString());
                    RefreshImage(OBJ.ID);
                    //XtraMessageBox.Show("2");
                    //////////////////////////////////////////////////////////////////////////////////////////
                    Is_close = true;
                    //XtraMessageBox.Show("3");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                isAction = "";
            };
            gridView1.RowClick += (s, e) =>
            {
                gridViewRowClick = true;
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

            btnBrowse.Click += (s, e) =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    strFilePath = ofd.FileName;
                    pbxImage.Image = new Bitmap(strFilePath);
                    if (txtTitle.Text.Trim().Length == 0)//Auto-Fill title if is empty
                        txtTitle.Text = System.IO.Path.GetFileName(strFilePath);
                }
            };

            btnClear.Click += (s, e) =>
            {
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
            txtTenmauCOA.Text = OBJ.COATemplate.ToString();
            txtDienGiai.Text = OBJ.COADescription.ToString();
            txtNote.Text = OBJ.Note;
            cmbKhoa.Text = OBJ.Locked.ToString();
            pbxImage.Image = Image.FromStream(new MemoryStream(OBJ.IMGCOA));
        }

        public void Set4ObjectRow()
        {
            if (isAction == "Edit")
            {
                //OBJ1
                //MessageBox.Show("1");
                OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                //MessageBox.Show("2");
                OBJ1.HMKTID = int.Parse(gridView1.GetFocusedRowCellValue("HMKTID").ToString());
                //MessageBox.Show("3");
                OBJ1.Tolerance = gridView1.GetFocusedRowCellValue("Tolerance").ToString();
                //MessageBox.Show("4");
                //OBJ1.ToleranceVN = gridView1.GetFocusedRowCellValue("ToleranceVN").ToString();
                OBJ1.Value = gridView1.GetFocusedRowCellValue("Value").ToString();
                //MessageBox.Show("5");
                //OBJ1.ValueVN = gridView1.GetFocusedRowCellValue("ValueVN").ToString();
                OBJ1.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
                //MessageBox.Show("6");
                OBJ1.CreatedBy = gridView1.GetFocusedRowCellValue("CreatedBy").ToString();
                //MessageBox.Show("7");
                OBJ1.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
                //MessageBox.Show("8");
            }
        }

        public void Set4ObjectHeader()
        {
            if (isAction == "Edit")
            {
                //MessageBox.Show("Bat dau Edit");
                //OBJ
                OBJ.ID = int.Parse(txtID.Text);
                //OBJ.COAName = txtTenmauCOA.Text;
                //OBJ.COADescription = txtDienGiai.Text;
                OBJ.Note = txtNote.Text;
                OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            }
            OBJ.COATemplate = txtTenmauCOA.Text;
            OBJ.COADescription = txtDienGiai.Text;
            OBJ.Note = txtNote.Text;
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }

        public void ResetControl()
        {
            txtID.Text = "";
            txtTenmauCOA.Text = "";
            //lkeCTPT.Text = "";
            //lkeTC.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        public void TDControlsReadOnly(bool bl)
        {
            txtID.ReadOnly = bl;
            //lkeCTPT.ReadOnly = bl;
            //lkeTC.ReadOnly = bl;
            txtTenmauCOA.ReadOnly = bl;
            txtDienGiai.ReadOnly = bl;
            //txtNote.ReadOnly = bl;
            //cmbKhoa.ReadOnly = bl;
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isActionMini = "Add";
            //Riêng cho trường hợp tạo mới Row trên KQKN template
            //Truyen ID cua KQKN template cho Row
            OBJ1.COATemplateID = OBJ.ID;

            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            F_COA_Template_Details_Added_Row FRM = new F_COA_Template_Details_Added_Row();
            FRM.isAction = this.isActionMini;
            FRM.OBJ = this.OBJ1;
            FRM.myFinished += this.finished;
            FRM.Show();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
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
            F_COA_Template_Details_Added_Row F_LOC_Dtl = new F_COA_Template_Details_Added_Row();
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

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa muc có mã  : " + OBJ1.ID + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    BUS1.COA_Template_DetailsDAO_DELETE(OBJ1);
                }
                // 18 Load lại datasource cho grid

                gridControl1.DataSource = tbl_COA_Template_DetailsTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA_Template_Details, int.Parse(txtID.Text));

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
                    Set4ObjectHeader();
                    BUS.COA_Template_HeaderDAO_UPDATE(OBJ);
                    this.Close();
                }

                ///////////////Save image/////////////////////////////////////////////////////////////////

                if (strFilePath == "")
                {
                    if (ImageByteArray.Length != 0)
                        ImageByteArray = new byte[] { };
                }
                else
                {
                    Image temp = new Bitmap(strFilePath);
                    MemoryStream strm = new MemoryStream();
                    temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ImageByteArray = strm.ToArray();
                }
                if (Conn.conn_S.State == ConnectionState.Closed)
                    Conn.conn_S.Open();
                SqlCommand sqlCmd = new SqlCommand("ImageAddOrEdit", Conn.conn_S) { CommandType = CommandType.StoredProcedure };
                sqlCmd.Parameters.Add("@Image", ImageByteArray);
                sqlCmd.Parameters.Add("@ID", OBJ.ID);
                sqlCmd.ExecuteNonQuery();
                Conn.conn_S.Close();
                MessageBox.Show("Saved successfuly");
                //Clear();
                RefreshImage(OBJ.ID);
            }
        }

        public void finished(object sender)
        {
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            //// Step 2 : Load lại data tren grid sau khi Add
            gridControl1.DataSource = tbl_COA_Template_DetailsTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA_Template_Details, OBJ.ID);
            gridView1.BestFitColumns();
        }

        public byte[] ImageToByteArray(Image img)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        #region Methods Image

        private void RefreshImage(int ID)
        {
            if (Conn.conn_S.State == ConnectionState.Closed)
                Conn.conn_S.Open();
            SqlDataAdapter sqlda = Sql.ExecuteDataAdapter("SAP", "ImageView", CommandType.StoredProcedure, "@ID", ID);
            DataTable dtblImages = new DataTable();
            sqlda.Fill(dtblImages);
            OBJ.IMGCOA = dtblImages.Rows[0].Field<byte[]>("IMGCOA");
            pbxImage.Image = Image.FromStream(new MemoryStream(OBJ.IMGCOA));
        }

        private void Clear()
        {
            //ImageID = 0;
            txtTitle.Text = "";
            //pbxImage.Image = DefaultImage;
            //strFilePath = "";
            //btnSave.Text = "Save";
        }

        #endregion Methods Image

        private Image nullImage;

        private void pbxImage_Paint(object sender, PaintEventArgs e)
        {
            if (pbxImage.EditValue == null)
            {
                Point pt = new Point((pbxImage.Width - nullImage.Width) / 2, (pbxImage.Height - nullImage.Height) / 2);
                e.Graphics.DrawImage(nullImage, pt);
            }
        }
    }
}