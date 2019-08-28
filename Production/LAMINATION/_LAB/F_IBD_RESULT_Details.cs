﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Production.Class._GEN;
using Production.Class._LAB.RESULT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_IBD_RESULT_Details : frm_Base
    {
        public string isAction = "";
        public DateTime ngaynhanmau;
        public string str_KHMau = "";
        //EXCEL
        private Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

        private CHITIEUXETNGHIEMBUS BUSCTXN = new CHITIEUXETNGHIEMBUS();
        //BUS
        private IBD_RESULT_Header_LABBUS BUSHeader = new IBD_RESULT_Header_LABBUS();

        private IBD_RESULT_Lines_LABBUS BUSLines = new IBD_RESULT_Lines_LABBUS();
        private IBD_RESULT_Summary_LABBUS BUSSCurve = new IBD_RESULT_Summary_LABBUS();
        private int col_max;
        private int col_min, col_title;
        private Equation_Fomular EQ = new Equation_Fomular();
        private FileStream file;
        private string filename = string.Empty;
        //FileName - FilePath - FileStream
        private string filePath = string.Empty;
        // Neg - Pos - Sus
        private string neg_sus_pos;
        private int neg = 0;
        private int pos = 0;
        private int sus = 0;
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private bool gridViewRowClick = false;
        //OBJECT
        private IBD_RESULT_Header_LAB OBJHeader = new IBD_RESULT_Header_LAB();

        private IBD_RESULT_Lines_LAB OBJLines = new IBD_RESULT_Lines_LAB();
        private IBD_RESULT_Summary_LAB OBJSummary = new IBD_RESULT_Summary_LAB();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //Workbook
        //For xlsx
        //IWorkbook originalWorkbook = new XSSFWorkbook(file);
        //For xls
        private IWorkbook originalWorkbook;

        private string Path = System.IO.Directory.GetCurrentDirectory();
        private Microsoft.Office.Interop.Excel.Range range = null;
        private Microsoft.Office.Interop.Excel.Range range_tilte = null;
        private int row, col;
        private int row_data;
        private int row_max;
        //EXCEL ROW-COL
        private int row_min, row_title;

        private string[] strArray = null;
        private string TEST_SOFTWARE_CTXN_NAME = "IBD";
        private Microsoft.Office.Interop.Excel.Workbook wbook = null;
        private Worksheet worksheet = null;
        public F_IBD_RESULT_Details()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
                this.Height = Screen.PrimaryScreen.Bounds.Height - 30;

                //XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //args.AutoCloseOptions.Delay = 3000;
                //args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //args.DefaultButtonIndex = 0;
                //args.Caption = "Lưu ý ";
                //args.Text = "Vui lòng click vào dòng cần chỉnh sửa . Thông báo này sẽ tự đóng sau 3 giây.";
                //args.Buttons = new DialogResult[] { DialogResult.OK };
                //XtraMessageBox.Show(args).ToString();

                action_EndForm3.Add_Status(false);
                action_EndForm3.Delete_Status(false);
                action_EndForm3.Update_Status(false);
                action_EndForm3.Save_Status(true);
                action_EndForm3.View_Status(false);
                action_EndForm3.Close_Status(true);

                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);

                if (isAction == "Edit")
                {
                }
                else if (isAction == "Add")
                {
                    txtLan.Text = "1";
                }
            };

            btnLoad.Click += (s, e) =>
            {
                if (dxValidationProvider1.Validate() == true)
                {
                    //var filePath = string.Empty;
                    //var filename = string.Empty;
                    //OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    //Excel.Application app = new Excel.Application();
                    //Excel.Workbook wbook = null;
                    //Worksheet wsheet = null;
                    //string[] strArray = null;

                    //openFileDialog1.InitialDirectory = "c:\\";
                    openFileDialog1.Filter = "xls files (*.xls)|*.xls";
                    openFileDialog1.FilterIndex = 2;
                    openFileDialog1.RestoreDirectory = true;
                    openFileDialog1.FileName = "*.xls";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog1.FileName;
                        filename = openFileDialog1.SafeFileName; //System.IO.Path.GetFileName(filePath);
                        

                        //FileStream file = File.OpenRead(filePath);
                        file = File.OpenRead(filePath);

                        string[] lst_filename = filename.Split('.');
                        
                        //For xlsx
                        if (lst_filename[1].ToString() == "xlsx" || lst_filename[1].ToString() == "XLSX")
                            originalWorkbook = new XSSFWorkbook(file);
                        //For xls
                        else if (lst_filename[1].ToString() == "xls" || lst_filename[1].ToString() == "XLS")
                            originalWorkbook = new HSSFWorkbook(file);

                        wbook = app.Workbooks.Open(
                        openFileDialog1.FileName, 0, true, 5,
                        "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false,
                        0, true);
                        Sheets sheets = wbook.Worksheets;
                        worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);

                        SetWorksheet4OBJHeader();

                        //SetWorksheet4OBJLines();                        

                        gridControl1.DataSource = this.tbl_IBD_RESULT_Lines_LABTableAdapter.FillBy_IBD_RESULT_Header_LAB_ID(sYNC_NUTRICIELDataSet.tbl_IBD_RESULT_Lines_LAB, OBJHeader.ID);
                                                
                    }
                }
            };
            lkedonvicungcapphanmem.EditValueChanged += (s, e) =>
            {
                OBJHeader.HUYETTHANHHOC_STD_VALUE_ID = int.Parse(lkedonvicungcapphanmem.EditValue.ToString());
            };

            gridView1.RowClick += (s, e) =>
            {
                //KHMAUCTXNOBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                //gridViewRowClick = true;
                //Set4Object_Details();
            };

            //Action_EndForm
            action_EndForm3.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add3));
            action_EndForm3.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update3));
            action_EndForm3.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close3));
            action_EndForm3.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save3));
        }

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
                    //myFinished?.Invoke(sender: this);
                }
            }
        }
        //
        public void ControlsReadOnly(bool bl)
        {
            cmbKhoa.ReadOnly = bl;
            txtNote.ReadOnly = bl;
        }

        public void finished(object sender)
        {
            //Enable
            this.Enabled = true;
            //
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            this.Visible = true;

            // Step 2 : Load lại data tren grid sau khi Add

            gridView1.BestFitColumns();
        }

        public void ResetControl()
        {
            cmbKhoa.Text = "";
            txtNote.Text = "";
        }

        public void Set4Controls_Details()
        {
            ///////////////////////////////////////////////////////////////
        }

        public void Set4Controls_Header()
        {
            if (isAction == "Edit")
            {
                txtID.Text = OBJHeader.ID.ToString();
                txtLan.Text = "1";
                //lblEquation.Text = "y = " + OBJHeader.a_SLOPE + "x" + " + " + OBJHeader.b_INTERCEPT;
            }

            cmbKhoa.Text = OBJHeader.Locked.ToString();
            txtNote.Text = OBJHeader.Note;
        }

        public void Set4Object_Details()
        {
            //KHMAUCTXNOBJ
            if (isAction == "Edit" && gridView1.DataRowCount > 0)
            {
                OBJLines.ID = int.Parse(gridView1.GetFocusedRowCellValue("MYCOTOXIN_RESULT_Lines_LAB_ID").ToString());
            }
        }

        public void Set4Object_Header()
        {
            if (isAction == "Edit")
                OBJHeader.ID = int.Parse(txtID.Text.ToString());
            //OBJHeader.ReadTimes = int.Parse(txtLan.Text);
            OBJHeader.FileName = txtTenXetNghiem.Text;
            OBJHeader.CreatedBy = user.Username;
            OBJHeader.Locked = cmbKhoa.Text.ToString() == "True" ? true : false;
            OBJHeader.Note = txtNote.Text;
        }

        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_HUYETTHANHHOC_STD_VALUE' table. You can move, or remove it, as needed.
            this.tbl_HUYETTHANHHOC_STD_VALUETableAdapter.FillBy_TEST_SOFTWARE_CTXN_NAME(this.sYNC_NUTRICIELDataSet.tbl_HUYETTHANHHOC_STD_VALUE, TEST_SOFTWARE_CTXN_NAME);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB' table. You can move, or remove it, as needed.
            this.tbl_IBD_RESULT_Lines_LABTableAdapter.FillBy_IBD_RESULT_Header_LAB_ID(this.sYNC_NUTRICIELDataSet.tbl_IBD_RESULT_Lines_LAB, OBJHeader.ID);
        }

        private void ItemClickEventHandler_Add3(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Close3(object sender, ItemClickEventArgs e)
        {
            this.Is_close = true;
        }

        private void ItemClickEventHandler_Save3(object sender, ItemClickEventArgs e)
        {
            if (this.dxValidationProvider1.Validate() == true)
            {
                Set4Object_Header();
                Set4Object_Details();
                //BUS1.KHMau_LABBUS_UPDATE(KHMAUOBJ);
                Is_close = true;
            }
            else
            {
                IList<Control> IControls = this.dxValidationProvider1.GetInvalidControls();
                foreach (Control ctrl in IControls)
                    ctrl.Focus();
            }
        }
        private void ItemClickEventHandler_Update3(object sender, ItemClickEventArgs e)
        {
            //Set4Object_Details();

            ////BUS1.KHMau_LABBUS_UPDATE(KHMAUOBJ);

            //XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //args.AutoCloseOptions.Delay = 3000;
            //args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            //args.DefaultButtonIndex = 0;
            //args.Caption = "Thông báo ";
            //args.Text = "Cập nhật thành công. Thông báo này sẽ tự đóng sau 5 giây.";
            //args.Buttons = new DialogResult[] { DialogResult.OK };
            //XtraMessageBox.Show(args).ToString();

            //Is_close = true;
        }
        private void SetWorksheet4OBJHeader()
        {
            IList lst_Pic ;
            //try
            //{
                DataRowView row = (DataRowView)lkedonvicungcapphanmem.GetSelectedDataRow();
                switch (row["TEST_SOFTWARE_SUP_NAME"].ToString())
                {                    
                    case "IDEXX":
                        row_min = 21; row_title = 27;
                        row_data = 28;
                        row_max = 51;
                        col_min = 2; col_title = 3;
                        col_max = 28;

                        //For xlsx
                        //originalWorkbook = new XSSFWorkbook(file);
                        //For xls
                        //originalWorkbook = new HSSFWorkbook(file);

                        lst_Pic = originalWorkbook.GetAllPictures();

                        for (int i = 0; i < lst_Pic.Count; i++)
                        {
                            var pic = (HSSFPictureData)lst_Pic[i];
                            byte[] data = pic.Data;
                            BinaryWriter writer = new BinaryWriter(File.OpenWrite(@"D:\Temp_Xml\IBD_IDEXX_" + filename + ".jpeg"));
                            writer.Write(data);
                            writer.Flush();
                            writer.Close();
                        }

                        //////////////////////////OBJHeader///////////////////////////////////////////////////////
                        OBJHeader.FileName = txtTenXetNghiem.Text = (string)worksheet.Cells[8, "D"].Value; ;
                        OBJHeader.FilePath = openFileDialog1.FileName;
                        OBJHeader.Case = worksheet.Cells[25, "I"].Value;
                        OBJHeader.Count = int.Parse(worksheet.Cells[10, "AG"].Value);
                        OBJHeader.GMean = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[11, "AG"].Value));
                        OBJHeader.Mean = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[12, "AG"].Value));
                        OBJHeader.SD = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[13, "AG"].Value));
                        OBJHeader.CV = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[15, "AG"].Value));
                        OBJHeader.Min = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[16, "AG"].Value));
                        OBJHeader.Max = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[17, "AG"].Value));
                        OBJHeader.Tech = (string)worksheet.Cells[18, "AG"].Value;
                        //XtraMessageBox.Show((string)worksheet.Cells[20, "AG"].Value);
                        OBJHeader.Date = worksheet.Cells[20, "AG"].Value;
                        OBJHeader.ID = OBJLines.IBD_RESULT_Header_LAB_ID
                                     = BUSHeader.IBD_RESULT_Header_LABDAO_INSERT(OBJHeader);
                        txtID.Text = OBJHeader.ID.ToString();

                        for (int i = 28; i <= 51; i++)
                        {
                            if (i <= 31)
                            {
                                OBJLines.Line_No = worksheet.Cells[i, "B"].Value;
                                string well = worksheet.Cells[i, "D"].Value.ToString();
                                OBJLines.Row = well.Substring(0,1);
                                OBJLines.Col = well.Substring(1, well.Length -1);
                                OBJLines.OD = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[i, "K"].Value));
                                OBJLines.SP = Decimal.Parse(string.Format("{0:##,##0.00}","0"));
                                OBJLines.Titer = int.Parse("0");
                                OBJLines.GroupTiter = int.Parse("0");
                                OBJLines.Result = "";
                                OBJLines.IBD_RESULT_Header_LAB_ID = OBJHeader.ID;
                                //OBJLines.CTXN_ID = int.Parse(row["CTXN_ID"].ToString());
                                //OBJLines.KHMau_BanGiao = row["KHMau_BanGiao"].ToString();
                                //BUSLines.IBD_RESULT_Lines_LABDAO_INSERT(OBJLines);
                        }
                            else
                            {
                                OBJLines.Line_No = worksheet.Cells[i, "B"].Value;
                                string well = worksheet.Cells[i, "D"].Value.ToString();
                                OBJLines.Row = well.Substring(0, 1);
                                OBJLines.Col = well.Substring(1, well.Length - 1);
                                OBJLines.OD = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[i, "K"].Value));
                                OBJLines.SP = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[i, "Q"].Value));
                                OBJLines.Titer = int.Parse(worksheet.Cells[i, "W"].Value.ToString());
                                OBJLines.GroupTiter = int.Parse(worksheet.Cells[i, "Z"].Value.ToString());
                                OBJLines.Result = worksheet.Cells[i, "AA"].Value.ToString();
                                OBJLines.IBD_RESULT_Header_LAB_ID = OBJHeader.ID;
                                //OBJLines.CTXN_ID = int.Parse(row["CTXN_ID"].ToString());
                                //OBJLines.KHMau_BanGiao = row["KHMau_BanGiao"].ToString();
                                //BUSLines.IBD_RESULT_Lines_LABDAO_INSERT(OBJLines);
                        }
                        BUSLines.IBD_RESULT_Lines_LABDAO_INSERT(OBJLines);
                    }
                        break;

                    case "BIOCHEK":                        
                        //originalWorkbook = new HSSFWorkbook(file);

                        lst_Pic = originalWorkbook.GetAllPictures();

                        for (int i = 0; i < originalWorkbook.GetAllPictures().Count; i++)
                        {
                            var pic = (HSSFPictureData)lst_Pic[i];
                            byte[] data = pic.Data;
                            BinaryWriter writer = new BinaryWriter(File.OpenWrite(@"D:\Temp_Xml\IBD_BIOCHEK_" + filename + ".jpeg"));
                            writer.Write(data);
                            writer.Flush();
                            writer.Close();
                        }

                        for (int i = 20; i<=48; i++)
                        {
                            switch ((string)worksheet.Cells[i, "S"].Value)
                            {
                                case "GMT:":
                                    OBJHeader.GMean = Convert.ToDecimal(worksheet.Cells[i, "V"].Value);
                                    break;
                                case "Mean Titer:":
                                    OBJHeader.Mean = Convert.ToDecimal(worksheet.Cells[i, "V"].Value);
                                    break;
                                case "%CV:":
                                    OBJHeader.CV = Convert.ToDecimal(worksheet.Cells[i, "V"].Value);
                                    break;
                                case "Min-Max Titer:":
                                    OBJHeader.Min = Convert.ToDecimal(0.000);//float.Parse(worksheet.Cells[i, "V"].Value);
                                    OBJHeader.Max = Convert.ToDecimal(0.000);//float.Parse(worksheet.Cells[i, ""].Value);
                                    break;
                                default:
                                    OBJHeader.FileName = txtTenXetNghiem.Text = (string)worksheet.Cells[11, "J"].Value;                                   
                                    OBJHeader.FilePath = openFileDialog1.FileName;
                                    OBJHeader.Case = "0";
                                    OBJHeader.Count = 0;
                                    OBJHeader.SD = 0;
                                    OBJHeader.Tech = "0";
                                    break;
                            }

                            switch ((string)worksheet.Cells[i, "AD"].Value)
                            {
                                case "Test date:":
                                    string dte_tmp = (string)worksheet.Cells[i, "AI"].Value;
                                    string[] lst_dte_tmp = dte_tmp.Split('/');
                                    OBJHeader.Date = Convert.ToDateTime(lst_dte_tmp[1] + "/" + lst_dte_tmp[0] + "/" + lst_dte_tmp[2]);                                    
                                    break;
                                case "Neg/Sus/Pos:":
                                    neg_sus_pos = (string)worksheet.Cells[i, "AI"].Value;
                                    string[] lst_neg_sus_pos = neg_sus_pos.Split('/');
                                    OBJHeader.Neg = int.Parse(lst_neg_sus_pos[0]);
                                    OBJHeader.Sus = int.Parse(lst_neg_sus_pos[1]);
                                    OBJHeader.Pos = int.Parse(lst_neg_sus_pos[2]);
                                    break;
                        }
                        }
                        //////////////////////////OBJHeader///////////////////////////////////////////////////////
                        
                        OBJHeader.ID = OBJLines.IBD_RESULT_Header_LAB_ID
                                     = BUSHeader.IBD_RESULT_Header_LABDAO_INSERT(OBJHeader);
                        txtID.Text = OBJHeader.ID.ToString();
                        for (int i = 50; i <= 60; i++)
                        {
                            if (worksheet.Cells[i, "B"].Value == "Sample ID")
                            {
                                row_data = i+1;
                                row_max = row_data + 24;
                            }                                
                        }
                    //XtraMessageBox.Show(row_data.ToString());
                        for (int i = row_data ; i < row_max; i++)
                        {
                            if(i < row_data + 4)
                            {
                                OBJLines.Line_No = worksheet.Cells[i, "B"].Value;
                                string well = worksheet.Cells[i, "F"].Value.ToString();
                                OBJLines.Row = well.Substring(0, 1);
                                OBJLines.Col = well.Substring(1, well.Length - 1);
                                OBJLines.OD = Decimal.Parse(string.Format("{0:##,##0.000}", worksheet.Cells[i, "M"].Value));
                                OBJLines.SP = Convert.ToDecimal(worksheet.Cells[i, "O"].Value, new CultureInfo("en-US"));
                                OBJLines.Titer = 0.000M;
                                OBJLines.GroupTiter = 0;
                                OBJLines.Result = "";
                                OBJLines.IBD_RESULT_Header_LAB_ID = OBJHeader.ID;
                                OBJLines.CTXN_ID = int.Parse(row["CTXN_ID"].ToString());
                                OBJLines.KHMau_BanGiao = (string)worksheet.Cells[11, "J"].Value;
                            }
                            else
                            {
                                OBJLines.Line_No = worksheet.Cells[i, "B"].Value;
                                string well = worksheet.Cells[i, "F"].Value.ToString();
                                OBJLines.Row = well.Substring(0, 1);
                                OBJLines.Col = well.Substring(1, well.Length - 1);
                                OBJLines.OD = Decimal.Parse(string.Format("{0:##,##0.000}", worksheet.Cells[i, "M"].Value));
                                OBJLines.SP = Convert.ToDecimal(worksheet.Cells[i, "O"].Value, new CultureInfo("en-US"));
                                OBJLines.Titer = int.Parse(worksheet.Cells[i, "T"].Value.ToString());
                                OBJLines.GroupTiter = int.Parse(worksheet.Cells[i, "X"].Value.ToString()) ;
                                OBJLines.Result = worksheet.Cells[i, "AF"].Value;
                                OBJLines.IBD_RESULT_Header_LAB_ID = OBJHeader.ID;
                                OBJLines.CTXN_ID = int.Parse(row["CTXN_ID"].ToString());
                                OBJLines.KHMau_BanGiao = (string)worksheet.Cells[11, "J"].Value;
                            }                            
                                BUSLines.IBD_RESULT_Lines_LABDAO_INSERT(OBJLines);
                        }
                        break;

                    case "ID.vet":
                        
                        lst_Pic = originalWorkbook.GetAllPictures();

                        for (int i = 0; i < originalWorkbook.GetAllPictures().Count; i++)
                        {
                            var pic = (HSSFPictureData)lst_Pic[i];
                            byte[] data = pic.Data;
                            BinaryWriter writer = new BinaryWriter(File.OpenWrite(@"D:\Temp_Xml\IBD_IDvet_" + filename + ".jpeg"));
                            writer.Write(data);
                            writer.Flush();
                            writer.Close();
                        }

                        for (int i = 3; i <= 26; i++)
                        {
                            switch ((string)worksheet.Cells[i, "A"].Value)
                            {
                                case "GMT:":
                                    OBJHeader.GMean         = Convert.ToDecimal(worksheet.Cells[i, "B"].Value);
                                    break;
                                case "Mean Titer:":
                                    OBJHeader.Mean          = Convert.ToDecimal(worksheet.Cells[i, "B"].Value);
                                    break;
                                case "%CV:":
                                    OBJHeader.CV            = Convert.ToDecimal(worksheet.Cells[i, "B"].Value);
                                    break;
                                case "Test date :":
                                string dte_tmp = worksheet.Cells[i, "B"].Value.ToString();
                                //string[] lst_dte_tmp = dte_tmp.Split('/');
                                //OBJHeader.Date = Convert.ToDateTime(lst_dte_tmp[1] + "/" + lst_dte_tmp[0] + "/" + lst_dte_tmp[2]);
                                OBJHeader.Date = Convert.ToDateTime(dte_tmp.Substring(0, 10));
                                    break;
                                case "Name of farm :":
                                    OBJHeader.Case = worksheet.Cells[i, "B"].Value.ToString();
                                    OBJHeader.FileName = 
                                                        txtTenXetNghiem.Text = worksheet.Cells[i, "B"].Value.ToString();
                                    break;
                                default:
                                        
                                            OBJHeader.FilePath      = openFileDialog1.FileName;                                   
                                            OBJHeader.SD            = 0;
                                            OBJHeader.Tech          = "0";
                                            break;
                            }
                            switch ((string)worksheet.Cells[i, "L"].Value)
                            {
                                case "G.M.T.":
                                    OBJHeader.GMean = Convert.ToDecimal(worksheet.Cells[i, "M"].Value);
                                    break;
                                case "Mean":
                                    OBJHeader.Mean = Convert.ToDecimal(worksheet.Cells[i, "M"].Value);
                                    break;
                                case "CV %":
                                    OBJHeader.CV = Convert.ToDecimal(worksheet.Cells[i, "M"].Value);
                                    break;
                                case "Min":
                                    OBJHeader.Min = Convert.ToDecimal(worksheet.Cells[i, "M"].Value);                                
                                    break;
                                case "Max:":                                
                                    OBJHeader.Max = Convert.ToDecimal(worksheet.Cells[i, "M"].Value);
                                    break;
                                case "Total":
                                    OBJHeader.Count = int.Parse(worksheet.Cells[i, "M"].Value.ToString());
                                    break;
                        }
                            switch ((string)worksheet.Cells[i, "AD"].Value)
                                {                                    
                                    case "Neg/Sus/Pos:":
                                        neg_sus_pos             = (string)worksheet.Cells[i, "AI"].Value;
                                        string[] lst_neg_sus_pos = neg_sus_pos.Split('/');
                                        OBJHeader.Neg           = int.Parse(lst_neg_sus_pos[0]);
                                        OBJHeader.Sus           = int.Parse(lst_neg_sus_pos[1]);
                                        OBJHeader.Pos           = int.Parse(lst_neg_sus_pos[2]);
                                        break;
                                }
                            }
                        //////////////////////////OBJHeader///////////////////////////////////////////////////////

                        OBJHeader.ID        = OBJLines.IBD_RESULT_Header_LAB_ID
                                            = BUSHeader.IBD_RESULT_Header_LABDAO_INSERT(OBJHeader);
                        txtID.Text          = OBJHeader.ID.ToString();
                    //for (int i          = 0; i     <= 10;      i++)
                    //{
                    //    if (worksheet.Cells[i, "D"].Value.ToString() == "Reference")
                    //    {
                    //        
                    //    }
                    //}
                    row_data = 5;
                    row_max     = row_data + 96;
                    for (int i          = row_data; i   < row_max; i++)
                        {
                            if (i < row_data+4 )
                            {                            
                                OBJLines.Line_No    = worksheet.Cells[i, "D"].Value;
                                string well = worksheet.Cells[i, "E"].Value.ToString();
                                OBJLines.Row = well.Substring(0, 1);
                                OBJLines.Col = well.Substring(1, well.Length - 1);
                                OBJLines.OD         = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[i, "F"].Value));                                
                                OBJLines.SP         = 0.000M;
                                OBJLines.Titer      = 0.000M;
                                OBJLines.GroupTiter = 0;
                                OBJLines.Result     = "";
                                OBJLines.IBD_RESULT_Header_LAB_ID = OBJHeader.ID;
                            }
                            else
                            {
                                if(worksheet.Cells[i, "D"].Value != null)
                                {
                                    OBJLines.Line_No = worksheet.Cells[i, "D"].Value;
                                    string well = worksheet.Cells[i, "E"].Value.ToString();
                                    OBJLines.Row = well.Substring(0, 1);
                                    OBJLines.Col = well.Substring(1, well.Length - 1);
                                    OBJLines.OD = Decimal.Parse(string.Format("{0:##,##0.00}", worksheet.Cells[i, "F"].Value));
                                    OBJLines.SP = Convert.ToDecimal(worksheet.Cells[i, "G"].Value, new CultureInfo("en-US"));
                                    OBJLines.Titer = int.Parse(worksheet.Cells[i, "I"].Value.ToString());
                                    OBJLines.GroupTiter = int.Parse(worksheet.Cells[i, "J"].Value.ToString());
                                    OBJLines.Result = worksheet.Cells[i, "H"].Value;
                                    OBJLines.IBD_RESULT_Header_LAB_ID = OBJHeader.ID;
                                }                                
                            }
                            BUSLines.IBD_RESULT_Lines_LABDAO_INSERT(OBJLines);
                        }
                        break;                
                }
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 1000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Lưu thành công ";
                args.Text = " Đọc dữ liệu tư file excel hoàn tất. Thông báo này sẽ tự đóng sau 1 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //    args.AutoCloseOptions.Delay = 20000;
            //    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            //    args.DefaultButtonIndex = 0;
            //    args.Caption = "Thông báo ";
            //    args.Text = " Có lỗi phát sinh. Xin vui lòng chụp màn hình và gởi bộ phận phát triển. Cảm ơn ." + ex.Message + " . Thông báo này sẽ tự đóng sau 20 giây.";
            //    args.Buttons = new DialogResult[] { DialogResult.OK };
            //    XtraMessageBox.Show(args).ToString();
            //}            
        }

        private void SetWorksheet4OBJLines()
        {

        }
    }
}