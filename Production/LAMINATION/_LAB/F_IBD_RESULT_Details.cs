using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Production.Class._GEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Production.Class._LAB.RESULT;

namespace Production.Class
{
    public partial class F_IBD_RESULT_Details : frm_Base
    {
        public DateTime ngaynhanmau;
        private string Path = System.IO.Directory.GetCurrentDirectory();
        public string isAction = "";
        public string str_KHMau = "";
        private bool gridViewRowClick = false;
        private Equation_Fomular EQ = new Equation_Fomular();

        //OBJECT
        private IBD_RESULT_Header_LAB OBJHeader     = new IBD_RESULT_Header_LAB();
        private IBD_RESULT_Lines_LAB OBJLines       = new IBD_RESULT_Lines_LAB();
        private IBD_RESULT_Summary_LAB OBJSCurve    = new IBD_RESULT_Summary_LAB();

        //BUS
        private IBD_RESULT_Header_LABBUS BUSHeader = new IBD_RESULT_Header_LABBUS();

        private IBD_RESULT_Lines_LABBUS BUSLines = new IBD_RESULT_Lines_LABBUS();
        private IBD_RESULT_Summary_LABBUS BUSSCurve = new IBD_RESULT_Summary_LABBUS();

        private CHITIEUXETNGHIEMBUS BUSCTXN = new CHITIEUXETNGHIEMBUS();

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
                    var filePath = string.Empty;
                    var filename = string.Empty;
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    //Excel.Application app = new Excel.Application();
                    //Excel.Workbook wbook = null;
                    //Worksheet wsheet = null;
                    //string[] strArray = null;

                    //openFileDialog1.InitialDirectory = "c:\\";
                    openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                    openFileDialog1.FilterIndex = 2;
                    openFileDialog1.RestoreDirectory = true;
                    openFileDialog1.FileName = "*.*";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog1.FileName;

                        filename = System.IO.Path.GetFileName(filePath);

                        FileStream file = File.OpenRead(filePath);
                        //For xlsx
                        //IWorkbook originalWorkbook = new XSSFWorkbook(file);
                        //For xls
                        IWorkbook originalWorkbook = new HSSFWorkbook(file);

                        var lst = originalWorkbook.GetAllPictures();
                        for (int i = 0; i < lst.Count; i++)
                        {
                            var pic = (HSSFPictureData)lst[i];
                            byte[] data = pic.Data;
                            //BinaryWriter writer = new BinaryWriter(File.OpenWrite(String.Format("{0}.jpeg", i)));
                            //writer.Write(data);
                            //writer.Flush();
                            //writer.Close();

                            BinaryWriter writer = new BinaryWriter(File.OpenWrite(@"D:\Temp_Xml\IBD_" + filename + ".jpeg"));
                            writer.Write(data);
                            writer.Flush();
                            writer.Close();
                        }

                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook wbook = null;
                        Worksheet wsheet = null;
                        Microsoft.Office.Interop.Excel.Range range_tilte = null;
                        Microsoft.Office.Interop.Excel.Range range = null;
                        string[] strArray = null;
                        //Xu ly luu data
                        //range
                        int row_min = 21, row_title = 27;
                        int row_data = 28;
                        int row_max = 51;

                        int col_min = 2, col_title = 3;
                        int col_max = 28;
                        //int row_fixed = 22, col_fixed = 2;
                        int row, col;
                        //////////////////////////////////////////////////////////////////////////////////////////
                        wbook = app.Workbooks.Open(
                           openFileDialog1.FileName, 0, true, 5,
                            "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false,
                            0, true);
                        Sheets sheets = wbook.Worksheets;
                        Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);
                        //////////////////////////OBJHeader///////////////////////////////////////////////////////
                        OBJHeader.FileName = txtTenXetNghiem.Text = (string)worksheet.Cells[8, "D"].Value; ;
                        OBJHeader.FilePath = openFileDialog1.FileName ;
                        //OBJHeader.Count = int.Parse(worksheet.Cells[6, 2].Value);
                        OBJHeader.Count = int.Parse(worksheet.Cells[10,"AG"].Value);
                        OBJHeader.GMean = float.Parse(worksheet.Cells[11, "AG"].Value);
                        OBJHeader.Mean = float.Parse(worksheet.Cells[12, "AG"].Value);
                        OBJHeader.SD = float.Parse(worksheet.Cells[13, "AG"].Value);
                        OBJHeader.CV = float.Parse(worksheet.Cells[15, "AG"].Value);
                        OBJHeader.Min = float.Parse(worksheet.Cells[16, "AG"].Value);
                        OBJHeader.Max = float.Parse(worksheet.Cells[17, "AG"].Value);
                        OBJHeader.Tech = (string)worksheet.Cells[18, "AG"].Value;
                        OBJHeader.Date = DateTime.Parse(worksheet.Cells[20, "AG"].Value);
                        OBJHeader.ID = OBJLines.IBD_RESULT_Header_LAB_ID
                                     = BUSHeader.IBD_RESULT_Header_LABDAO_INSERT(OBJHeader);
                        txtID.Text = OBJHeader.ID.ToString();

                        //////////////////////////OBJLines////////////////////////////////////////////////////////
                        
                        //for (col = col_min; col <= col_max; col++)
                        //{
                        //    //title
                        //    //check cell title empty
                        //    if ((string)worksheet.Cells[row_title, col].Value == null)
                        //    {
                        //        OBJLines.Acronym = (string)worksheet.Cells[row_title, col - 1].Value;
                        //    }
                        //    else
                        //    {
                        //        OBJLines.Acronym = (string)worksheet.Cells[row_title, col].Value;
                        //    }
                        //    for (row = row_data; row <= row_max; row++)
                        //    {
                        //        if (worksheet.Cells[row_data, col].Value > 0)
                        //        {
                        //            if (worksheet.Cells[row, col].Value > 0)
                        //            {
                        //                OBJLines.OD = worksheet.Cells[row, col].Value;
                        //                OBJLines.KHMau = worksheet.Cells[row, col + 13].Value;
                        //                OBJLines.B_Bo = 0;
                        //                OBJLines.HsoPhaLoang = 1;
                        //                OBJLines.LogConc = 0;
                        //                OBJLines.LogitB_Bo = 0;
                        //                OBJLines.Conc_ng_ml = 0;
                        //                OBJLines.Conc_ng_g = 0;
                        //                OBJLines.Row = (string)worksheet.Cells[row, col_fixed].Value;
                        //                OBJLines.Col = worksheet.Cells[row_fixed, col].Value;
                        //                OBJLines.CreatedBy = user.Username;
                        //                OBJLines.CTXN_ID = BUSCTXN.CTXN_CTXNID_SELECT(OBJLines.Acronym);
                        //                BUSLines.MYCOTOXIN_RESULT_Lines_INSERT(OBJLines);
                        //            }
                        //        }
                        //    }
                        //}


                        //splashScreenManager1.CloseWaitForm();
                    }
                    XtraMessageBox.Show("Xong").ToString();
                }
            };

            btnCalc_Log.Click += (s, e) =>
            {
                //List<string> List_Acronym = BUSLines.MYCOTOXIN_RESULT_Lines_List_Acronym(OBJHeader.ID);

                //foreach (string Arc in List_Acronym)
                //{
                //    double ConC_STD1 = 0; //double.Parse(gridView1.GetRowCellValue(0, "ConC").ToString());

                //    double OD_STD1 = 0;// double.Parse(gridView1.GetRowCellValue(0, "OD").ToString());

                //    double B_Bo_STD1 = 0; // (OD_STD1 / OD_STD1) * 100;
                //    //Dem so dong STD
                //    int STD_Row_Count = 0;

                //    List<double> Lst = new List<double>();
                //    splashScreenManager1.ShowWaitForm();
                //    for (int i = 0; i < gridView1.DataRowCount; i++)
                //    {
                //        DataRow row = gridView1.GetDataRow(i);
                //        if (row["Acronym"].ToString() == Arc)
                //        {
                //            if (row["KHMau"].ToString() == "STD1")
                //            {
                //                ConC_STD1 = double.Parse(row["ConC"].ToString());

                //                OD_STD1 = double.Parse(row["OD"].ToString());

                //                B_Bo_STD1 = (OD_STD1 / OD_STD1) * 100;
                //            }

                //            OBJLines.Acronym = row["Acronym"].ToString();
                //            OBJLines.ID = int.Parse(row["MYCOTOXIN_RESULT_Lines_LAB_ID"].ToString());
                //            OBJLines.KHMau = row["KHMau"].ToString();
                //            OBJLines.Row = row["Row"].ToString();
                //            OBJLines.Col = double.Parse(row["Col"].ToString());
                //            OBJLines.CTXN_ID = (int)row["CTXN_ID"];
                //            //STD
                //            if (OBJLines.KHMau.Substring(0, 3) == "STD")
                //            {
                //                OBJLines.OD = double.Parse(row["OD"].ToString());
                //                //--------------B/Bo-----------------------------------------------
                //                OBJLines.B_Bo = OBJLines.OD * 100 / OD_STD1;

                //                switch (OBJLines.KHMau)
                //                {
                //                    case "STD1":
                //                        OBJLines.Conc_ng_ml = 0;
                //                        //--------------logit(B/Bo)-----------------------------------------------
                //                        OBJLines.LogitB_Bo = 0;
                //                        //--------------Log(Conc)-----------------------------------------------
                //                        OBJLines.LogConc = 0;
                //                        break;

                //                    default:
                //                        OBJLines.Conc_ng_ml = double.Parse(row["ConC"].ToString());
                //                        //--------------logit(B/Bo)-----------------------------------------------
                //                        OBJLines.LogitB_Bo = Math.Log10((OBJLines.B_Bo) / (B_Bo_STD1 - OBJLines.B_Bo));
                //                        //--------------Log(Conc)-----------------------------------------------
                //                        OBJLines.LogConc = Math.Log10(OBJLines.Conc_ng_ml);
                //                        //---------------Equation y= ax + b-----------------------------------------
                //                        Lst.Add(OBJLines.LogitB_Bo);
                //                        Lst.Add(OBJLines.LogConc);
                //                        break;
                //                }
                //                //--------------HSoPhaLoang-----------------------------------------------
                //                OBJLines.HsoPhaLoang = 1;
                //                OBJLines.Conc_ng_g = 0;
                //                //Update line STD
                //                BUSLines.MYCOTOXIN_RESULT_Lines_UPDATE(OBJLines);
                //                STD_Row_Count++;
                //            }
                //        }
                //    }
                //    //XtraMessageBox.Show(B_Bo_STD1.ToString());
                //    OBJSCurve.MYCOTOXIN_RESULT_Header_ID = OBJHeader.ID;
                //    OBJSCurve = EQ.calcValues(Arc, Lst);
                //    OBJSCurve.MYCOTOXIN_RESULT_Header_ID = OBJHeader.ID;
                //    BUSSCurve.MYCOTOXIN_RESULT_StandardCurve_INSERT(OBJSCurve);
                //    //i se chay tu dong STD_Row_Count+1 den het
                //    //Muc dich giam thoi gian duyet va xu ly
                //    for (int i = STD_Row_Count + 1; i < gridView1.DataRowCount; i++)
                //    {
                //        DataRow row = gridView1.GetDataRow(i);
                //        if (row["Acronym"].ToString() == Arc)
                //        {
                //            if (row["KHMau"].ToString() == "STD1")
                //            {
                //                ConC_STD1 = double.Parse(row["ConC"].ToString());

                //                OD_STD1 = double.Parse(row["OD"].ToString());

                //                B_Bo_STD1 = (OD_STD1 / OD_STD1) * 100;
                //            }

                //            OBJLines.Acronym = row["Acronym"].ToString();
                //            OBJLines.ID = int.Parse(row["MYCOTOXIN_RESULT_Lines_LAB_ID"].ToString());
                //            OBJLines.KHMau = row["KHMau"].ToString();
                //            OBJLines.Row = row["Row"].ToString();
                //            OBJLines.Col = double.Parse(row["Col"].ToString());
                //            OBJLines.CTXN_ID = (int)row["CTXN_ID"];

                //            if (OBJLines.KHMau.Substring(0, 3) != "STD")
                //            {
                //                //Gia tri ConC(ng/ml) se an ko cho hien
                //                //Chi hien gia tri Conc(ng/g)
                //                //Khai bao he so y cua y=ax + b
                //                double y = 0;
                //                //--------------HSoPhaLoang-----------------------------------------------
                //                OBJLines.HsoPhaLoang = double.Parse(row["HsoPhaLoang"].ToString());
                //                //--------------B/Bo-----------------------------------------------
                //                OBJLines.B_Bo = double.Parse(row["OD"].ToString()) * 100 / OD_STD1;
                //                //--------------logit(B/Bo)-----------------------------------------------
                //                OBJLines.LogitB_Bo = Math.Log10((OBJLines.B_Bo) / (B_Bo_STD1 - OBJLines.B_Bo));
                //                //--------------Tinh y tuong ung voi tung B/Bo ben tren-----------------------------------------------
                //                y = OBJLines.LogitB_Bo * OBJSCurve.a_SLOPE + OBJSCurve.b_INTERCEPT;
                //                //XtraMessageBox.Show(y.ToString());
                //                //--------------Conc(ng/ml) gia tri nay se bi an -----------------------------------------------
                //                OBJLines.Conc_ng_ml = Math.Pow(10, y);
                //                //--------------Conc(ng/g)-----------------------------------------------
                //                OBJLines.LogConc = 0;

                //                OBJLines.Conc_ng_g = OBJLines.Conc_ng_ml * OBJLines.HsoPhaLoang * 10;
                //                //Update line <> STD
                //                BUSLines.MYCOTOXIN_RESULT_Lines_UPDATE(OBJLines);
                //                this.tbl_MYCOTOXIN_RESULT_Lines_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB, OBJHeader.ID);
                //            }
                //        }
                //    }

                //    splashScreenManager1.CloseWaitForm();
                //}

                ////XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                ////args.AutoCloseOptions.Delay = 2000;
                ////args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                ////args.DefaultButtonIndex = 0;
                ////args.Caption = "Thông tin ";
                ////args.Text = "Lưu thành công . Thông báo này sẽ tự đóng sau 2 giây .";
                ////args.Buttons = new DialogResult[] { DialogResult.OK };
                ////XtraMessageBox.Show(args).ToString();
                //tbl_MYCOTOXIN_RESULT_Lines_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB, OBJHeader.ID);
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

        private void ItemClickEventHandler_Close3(object sender, ItemClickEventArgs e)
        {
            this.Is_close = true;
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

        private void ItemClickEventHandler_Add3(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
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

        public void Set4Controls_Details()
        {
            ///////////////////////////////////////////////////////////////
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

        public void Set4Object_Details()
        {
            //KHMAUCTXNOBJ
            if (isAction == "Edit" && gridView1.DataRowCount > 0)
            {
                OBJLines.ID = int.Parse(gridView1.GetFocusedRowCellValue("MYCOTOXIN_RESULT_Lines_LAB_ID").ToString());
            }
        }

        public void ResetControl()
        {
            cmbKhoa.Text = "";
            txtNote.Text = "";
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

        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_HUYETTHANHHOC_STD_VALUE' table. You can move, or remove it, as needed.
            this.tbl_HUYETTHANHHOC_STD_VALUETableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_HUYETTHANHHOC_STD_VALUE);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB' table. You can move, or remove it, as needed.
            this.tbl_IBD_RESULT_Lines_LABTableAdapter.FillBy_IBD_RESULT_Header_LAB_ID(this.sYNC_NUTRICIELDataSet.tbl_IBD_RESULT_Lines_LAB, OBJHeader.ID);
        }
        
    }
}