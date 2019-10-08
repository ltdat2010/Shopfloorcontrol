using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using Production.Class._GEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace Production.Class
{
    public partial class F_MYCOTOXIN_RESULT_Details : frm_Base
    {
        public DateTime ngaynhanmau;
        private string Path = System.IO.Directory.GetCurrentDirectory();
        public string isAction = "";
        public string str_KHMau = "";
        private bool gridViewRowClick = false;
        private Equation_Fomular EQ = new Equation_Fomular();

        //OBJECT
        private MYCOTOXIN_RESULT_Header OBJHeader = new MYCOTOXIN_RESULT_Header();

        private MYCOTOXIN_RESULT_Lines OBJLines = new MYCOTOXIN_RESULT_Lines();
        private MYCOTOXIN_RESULT_StandardCurve OBJSCurve = new MYCOTOXIN_RESULT_StandardCurve();

        //BUS
        private MYCOTOXIN_RESULT_HeaderBUS BUSHeader = new MYCOTOXIN_RESULT_HeaderBUS();

        private MYCOTOXIN_RESULT_LinesBUS BUSLines = new MYCOTOXIN_RESULT_LinesBUS();
        private MYCOTOXIN_RESULT_StandardCurveBUS BUSSCurve = new MYCOTOXIN_RESULT_StandardCurveBUS();
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

        public F_MYCOTOXIN_RESULT_Details()
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
                //if (dxValidationProvider1.Validate() == true)
                //{
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                Excel.Application app = new Excel.Application();
                Excel.Workbook wbook = null;
                Worksheet wsheet = null;
                Excel.Range range_tilte = null;
                Excel.Range range = null;
                string[] strArray = null;

                openFileDialog1.FileName = "*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //range
                    int row_min = 21, row_title = 21;
                    int row_data = 23;
                    int row_max = 30;

                    int col_min = 3, col_title = 3;
                    int col_max = 14;
                    int row_fixed = 22, col_fixed = 2;
                    int row, col;
                    //////////////////////////////////////////////////////////////////////////////////////////
                    wbook = app.Workbooks.Open(
                       openFileDialog1.FileName, 0, true, 5,
                        "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false,
                        0, true);
                    Sheets sheets = wbook.Worksheets;
                    Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);
                    //////////////////////////OBJHeader///////////////////////////////////////////////////////
                    OBJHeader.Name = txtTenXetNghiem.Text = openFileDialog1.SafeFileName;
                    OBJHeader.FilePath = (string)worksheet.Cells[4, 2].Value;
                    OBJHeader.PlateNumber = (string)worksheet.Cells[6, 2].Value;
                    OBJHeader.Date = Convert.ToDateTime(worksheet.Cells[7, 2].Value);
                    OBJHeader.Time = "12:00:01"; //(string)worksheet.Cells[8, 2].Value;
                    OBJHeader.ReaderType = (string)worksheet.Cells[9, 2].Value;
                    OBJHeader.ReadingType = (string)worksheet.Cells[11, 2].Value;
                    OBJHeader.PlateType = (string)worksheet.Cells[14, 2].Value;
                    OBJHeader.Read = (string)worksheet.Cells[15, 2].Value +
                                                    " " +
                                                    (string)worksheet.Cells[16, 2].Value;
                    OBJHeader.Wavelengths = (string)worksheet.Cells[17, 2].Value;
                    OBJHeader.ReadSpeed = (string)worksheet.Cells[18, 2].Value;
                    OBJHeader.ReadTimes = 1;
                    OBJHeader.ID = OBJLines.MYCOTOCXIN_RESULT_Header_LAB_ID
                                 = BUSHeader.MYCOTOXIN_RESULT_Header_INSERT(OBJHeader);
                    txtID.Text = OBJHeader.ID.ToString();
                    //OBJSCurve.MYCOTOXIN_RESULT_Header_ID = OBJHeader.ID;

                    //////////////////////////OBJLines////////////////////////////////////////////////////////
                    //List<MYCOTOXIN_RESULT_Lines> TLines = new List<MYCOTOXIN_RESULT_Lines>();
                    //this.splashScreenManager1.ShowWaitForm();
                    for (col = col_min; col <= col_max; col++)
                    {
                        //title
                        //check cell title empty
                        if ((string)worksheet.Cells[row_title, col].Value == null)
                        {
                            OBJLines.Acronym = (string)worksheet.Cells[row_title, col - 1].Value;
                        }
                        else
                        {
                            OBJLines.Acronym = (string)worksheet.Cells[row_title, col].Value;
                        }
                        for (row = row_data; row <= row_max; row++)
                        {
                            if (worksheet.Cells[row_data, col].Value > 0)
                            {
                                if (worksheet.Cells[row, col].Value > 0)
                                {
                                    OBJLines.OD = worksheet.Cells[row, col].Value;
                                    OBJLines.KHMau = worksheet.Cells[row, col + 13].Value.ToString();
                                    OBJLines.B_Bo = 0;
                                    OBJLines.HsoPhaLoang = 1;
                                    OBJLines.LogConc = 0;
                                    OBJLines.LogitB_Bo = 0;
                                    OBJLines.Conc_ng_ml = 0;
                                    OBJLines.Conc_ng_g = 0;
                                    OBJLines.Row = (string)worksheet.Cells[row, col_fixed].Value;
                                    OBJLines.Col = worksheet.Cells[row_fixed, col].Value;
                                    OBJLines.CreatedBy = user.Username;
                                    OBJLines.CTXN_ID = BUSCTXN.CTXN_CTXNID_SELECT(OBJLines.Acronym);
                                    BUSLines.MYCOTOXIN_RESULT_Lines_INSERT(OBJLines);
                                }
                            }
                        }
                    }
                    //splashScreenManager1.CloseWaitForm();
                }
                tbl_MYCOTOXIN_RESULT_Lines_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB, OBJHeader.ID);
                //}
                //DISPOSE EXCEL
                //wbook.Close(false, Type.Missing, Type.Missing);
            };

            btnCalc_Log.Click += (s, e) =>
            {
                List<string> List_Acronym = BUSLines.MYCOTOXIN_RESULT_Lines_List_Acronym(OBJHeader.ID);
                //foreach(string Arc in List_Acronym)
                //{
                //    double ConC_STD1 = double.Parse(gridView1.GetRowCellValue(0, "ConC").ToString());

                //    double OD_STD1 = double.Parse(gridView1.GetRowCellValue(0, "OD").ToString());

                //    double B_Bo_STD1 = (OD_STD1 / OD_STD1) * 100;

                //    List<double> Lst = new List<double>();
                //    splashScreenManager1.ShowWaitForm();
                //    for (int i = 0; i < gridView1.DataRowCount; i++)
                //    {
                //        DataRow row = gridView1.GetDataRow(i);
                //        if(row["Acronym"].ToString() == Arc)
                //        {
                //            OBJLines.Acronym = row["Acronym"].ToString();
                //            OBJLines.ID = int.Parse(row["MYCOTOXIN_RESULT_Lines_LAB_ID"].ToString());
                //            OBJLines.KHMau = row["KHMau"].ToString();
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
                //                BUSLines.MYCOTOXIN_RESULT_Lines_UPDATE(OBJLines);
                //            }
                //        }

                //    }
                //    //OBJSCurve.MYCOTOXIN_RESULT_Header_ID = OBJHeader.ID;
                //    //OBJSCurve = EQ.calcValues(Arc, Lst);
                //    //OBJSCurve.MYCOTOXIN_RESULT_Header_ID = OBJHeader.ID;
                //    //BUSSCurve.MYCOTOXIN_RESULT_StandardCurve_INSERT(OBJSCurve);

                //    //Tính calculation
                //    for (int i = 0; i < gridView1.DataRowCount; i++)
                //    {
                //        DataRow row = gridView1.GetDataRow(i);
                //        if (row["Acronym"].ToString() == Arc)
                //        {
                //            OBJLines.Acronym = row["Acronym"].ToString();
                //            OBJLines.ID = int.Parse(row["MYCOTOXIN_RESULT_Lines_LAB_ID"].ToString());
                //            OBJLines.KHMau = row["KHMau"].ToString();

                //            //Khac STD
                //            if (row["KHMau"].ToString().Substring(0, 3) != "STD")
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
                //                y = (double)OBJLines.LogitB_Bo * OBJHeader.a_SLOPE + OBJHeader.b_INTERCEPT;
                //                //--------------Conc(ng/ml) gia tri nay se bi an -----------------------------------------------
                //                OBJLines.Conc_ng_ml = Math.Pow(10, y);
                //                //--------------Conc(ng/g)-----------------------------------------------
                //                OBJLines.LogConc = 0;
                //                OBJLines.Conc_ng_g = OBJLines.Conc_ng_ml * OBJLines.HsoPhaLoang * 10;

                //                BUSLines.MYCOTOXIN_RESULT_Lines_UPDATE(OBJLines);
                //                this.tbl_MYCOTOXIN_RESULT_Lines_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB, OBJHeader.ID);

                //            }
                //        }

                //    }

                //    OBJSCurve.MYCOTOXIN_RESULT_Header_ID = OBJHeader.ID;
                //    OBJSCurve = EQ.calcValues(Arc, Lst);
                //    OBJSCurve.MYCOTOXIN_RESULT_Header_ID = OBJHeader.ID;
                //    BUSSCurve.MYCOTOXIN_RESULT_StandardCurve_INSERT(OBJSCurve);

                //    splashScreenManager1.CloseWaitForm();
                //}

                foreach (string Arc in List_Acronym)
                {
                    double ConC_STD1 = 0; //double.Parse(gridView1.GetRowCellValue(0, "ConC").ToString());

                    double OD_STD1 = 0;// double.Parse(gridView1.GetRowCellValue(0, "OD").ToString());

                    double B_Bo_STD1 = 0; // (OD_STD1 / OD_STD1) * 100;
                    //Dem so dong STD
                    int STD_Row_Count = 0;

                    List<double> Lst = new List<double>();
                    splashScreenManager1.ShowWaitForm();
                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        DataRow row = gridView1.GetDataRow(i);
                        if (row["Acronym"].ToString() == Arc)
                        {
                            if (row["KHMau"].ToString() == "STD1")
                            {
                                ConC_STD1 = 0; //double.Parse(row["ConC"].ToString());

                                OD_STD1 = double.Parse(row["OD"].ToString());

                                B_Bo_STD1 = (OD_STD1 / OD_STD1) * 100;
                            }

                            OBJLines.Acronym = row["Acronym"].ToString();
                            OBJLines.ID = int.Parse(row["MYCOTOXIN_RESULT_Lines_LAB_ID"].ToString());
                            OBJLines.KHMau = row["KHMau"].ToString();
                            OBJLines.Row = row["Row"].ToString();
                            OBJLines.Col = double.Parse(row["Col"].ToString());
                            OBJLines.CTXN_ID = (int)row["CTXN_ID"];
                            //STD
                            if (OBJLines.KHMau.Substring(0, 3) == "STD")
                            {
                                OBJLines.OD = double.Parse(row["OD"].ToString());
                                //--------------B/Bo-----------------------------------------------
                                OBJLines.B_Bo = OBJLines.OD * 100 / OD_STD1;

                                switch (OBJLines.KHMau)
                                {
                                    case "STD1":
                                        OBJLines.Conc_ng_ml = 0;
                                        //--------------logit(B/Bo)-----------------------------------------------
                                        OBJLines.LogitB_Bo = 0;
                                        //--------------Log(Conc)-----------------------------------------------
                                        OBJLines.LogConc = 0;
                                        break;

                                    default:
                                        OBJLines.Conc_ng_ml = double.Parse(row["ConC"].ToString());
                                        //--------------logit(B/Bo)-----------------------------------------------
                                        OBJLines.LogitB_Bo = Math.Log10((OBJLines.B_Bo) / (B_Bo_STD1 - OBJLines.B_Bo));
                                        //--------------Log(Conc)-----------------------------------------------
                                        OBJLines.LogConc = Math.Log10(OBJLines.Conc_ng_ml);
                                        //---------------Equation y= ax + b-----------------------------------------
                                        Lst.Add(OBJLines.LogitB_Bo);
                                        Lst.Add(OBJLines.LogConc);
                                        break;
                                }
                                //--------------HSoPhaLoang-----------------------------------------------
                                OBJLines.HsoPhaLoang = 1;
                                OBJLines.Conc_ng_g = 0;
                                //Update line STD
                                BUSLines.MYCOTOXIN_RESULT_Lines_UPDATE(OBJLines);
                                STD_Row_Count++;
                            }
                        }
                    }
                    //XtraMessageBox.Show(B_Bo_STD1.ToString());
                    OBJSCurve.MYCOTOXIN_RESULT_Header_ID = OBJHeader.ID;
                    OBJSCurve = EQ.calcValues(Arc, Lst);
                    OBJSCurve.MYCOTOXIN_RESULT_Header_ID = OBJHeader.ID;
                    BUSSCurve.MYCOTOXIN_RESULT_StandardCurve_INSERT(OBJSCurve);
                    //i se chay tu dong STD_Row_Count+1 den het
                    //Muc dich giam thoi gian duyet va xu ly
                    for (int i = STD_Row_Count; i < gridView1.DataRowCount; i++)
                    {
                        DataRow row = gridView1.GetDataRow(i);
                        if (row["Acronym"].ToString() == Arc)
                        {
                            if (row["KHMau"].ToString() == "STD1")
                            {
                                ConC_STD1 = double.Parse(row["ConC"].ToString());

                                OD_STD1 = double.Parse(row["OD"].ToString());

                                B_Bo_STD1 = (OD_STD1 / OD_STD1) * 100;
                            }

                            OBJLines.Acronym = row["Acronym"].ToString();
                            OBJLines.ID = int.Parse(row["MYCOTOXIN_RESULT_Lines_LAB_ID"].ToString());
                            OBJLines.KHMau = row["KHMau"].ToString();
                            OBJLines.Row = row["Row"].ToString();
                            OBJLines.Col = double.Parse(row["Col"].ToString());
                            OBJLines.CTXN_ID = (int)row["CTXN_ID"];

                            if (OBJLines.KHMau.Substring(0, 3) != "STD")
                            {
                                OBJLines.OD = double.Parse(row["OD"].ToString());
                                //Gia tri ConC(ng/ml) se an ko cho hien
                                //Chi hien gia tri Conc(ng/g)
                                //Khai bao he so y cua y=ax + b
                                double y = 0;
                                //--------------HSoPhaLoang-----------------------------------------------
                                OBJLines.HsoPhaLoang = double.Parse(row["HsoPhaLoang"].ToString());
                                //--------------B/Bo-----------------------------------------------
                                //OBJLines.B_Bo = double.Parse(row["OD"].ToString()) * 100 / OD_STD1;
                                //XtraMessageBox.Show("OD : " + OBJLines.OD.ToString());
                                //XtraMessageBox.Show("OD_STD1 : "+ OD_STD1.ToString());
                                OBJLines.B_Bo = OBJLines.OD * 100 / OD_STD1;
                                //--------------logit(B/Bo)-----------------------------------------------
                                OBJLines.LogitB_Bo = Math.Log10((OBJLines.B_Bo) / (B_Bo_STD1 - OBJLines.B_Bo));
                                //--------------Tinh y tuong ung voi tung B/Bo ben tren-----------------------------------------------
                                y = OBJLines.LogitB_Bo * OBJSCurve.a_SLOPE + OBJSCurve.b_INTERCEPT;
                                //XtraMessageBox.Show(y.ToString());
                                //--------------Conc(ng/ml) gia tri nay se bi an -----------------------------------------------
                                OBJLines.Conc_ng_ml = Math.Pow(10, y);
                                //--------------Conc(ng/g)-----------------------------------------------
                                OBJLines.LogConc = 0;
                                switch (row["Acronym"].ToString())
                                {
                                    case "FUMO":
                                        OBJLines.Conc_ng_g = OBJLines.Conc_ng_ml * OBJLines.HsoPhaLoang * 400;
                                        break;

                                    case "AFLA":
                                        OBJLines.Conc_ng_g = OBJLines.Conc_ng_ml * OBJLines.HsoPhaLoang * 5;
                                        break;

                                    case "ZEARA":
                                        OBJLines.Conc_ng_g = OBJLines.Conc_ng_ml * OBJLines.HsoPhaLoang * 25;
                                        break;

                                    case "DON":
                                        OBJLines.Conc_ng_g = OBJLines.Conc_ng_ml * OBJLines.HsoPhaLoang * 10;
                                        break;

                                    case "T2":
                                        OBJLines.Conc_ng_g = OBJLines.Conc_ng_ml * OBJLines.HsoPhaLoang * 10;
                                        break;

                                    case "OTA":
                                        OBJLines.Conc_ng_g = OBJLines.Conc_ng_ml * OBJLines.HsoPhaLoang * 4;
                                        break;
                                }
                                //Update line <> STD
                                BUSLines.MYCOTOXIN_RESULT_Lines_UPDATE(OBJLines);
                                this.tbl_MYCOTOXIN_RESULT_Lines_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB, OBJHeader.ID);
                            }
                        }
                    }

                    splashScreenManager1.CloseWaitForm();
                }

                //XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //args.AutoCloseOptions.Delay = 2000;
                //args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //args.DefaultButtonIndex = 0;
                //args.Caption = "Thông tin ";
                //args.Text = "Lưu thành công . Thông báo này sẽ tự đóng sau 2 giây .";
                //args.Buttons = new DialogResult[] { DialogResult.OK };
                //XtraMessageBox.Show(args).ToString();
                tbl_MYCOTOXIN_RESULT_Lines_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB, OBJHeader.ID);
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
                txtLan.Text = OBJHeader.ReadTimes.ToString();
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
            OBJHeader.ReadTimes = int.Parse(txtLan.Text);
            OBJHeader.Name = txtTenXetNghiem.Text;
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
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB' table. You can move, or remove it, as needed.
            this.tbl_MYCOTOXIN_RESULT_Lines_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB, 0);
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                DataRow row = gridView1.GetFocusedDataRow();
                OBJLines.Acronym = row["Acronym"].ToString();
                OBJLines.ID = int.Parse(row["MYCOTOXIN_RESULT_Lines_LAB_ID"].ToString());
                OBJLines.KHMau = row["KHMau"].ToString();
                //XtraMessageBox.Show(row["HsoPhaLoang"].ToString());
                //Khac STD
                if (row["KHMau"].ToString().Substring(0, 3) != "STD")
                {
                    //Gia tri ConC(ng/ml) se an ko cho hien
                    //Chi hien gia tri Conc(ng/g)
                    //Khai bao he so y cua y=ax + b
                    double y = 0;
                    //--------------HSoPhaLoang-----------------------------------------------
                    OBJLines.HsoPhaLoang = double.Parse(row["HsoPhaLoang"].ToString());
                    //--------------B/Bo-----------------------------------------------
                    OBJLines.B_Bo = double.Parse(row["B_Bo"].ToString());
                    //--------------logit(B/Bo)-----------------------------------------------
                    OBJLines.LogitB_Bo = double.Parse(row["LogitB_Bo"].ToString());
                    //--------------Tinh y tuong ung voi tung B/Bo ben tren-----------------------------------------------

                    //--------------Conc(ng/ml) gia tri nay se bi an -----------------------------------------------
                    OBJLines.Conc_ng_ml = double.Parse(row["Conc_ng_ml"].ToString());
                    //--------------Conc(ng/g)-----------------------------------------------
                    OBJLines.LogConc = 0;
                    OBJLines.Conc_ng_g = OBJLines.Conc_ng_ml * OBJLines.HsoPhaLoang * 10;

                    BUSLines.MYCOTOXIN_RESULT_Lines_UPDATE(OBJLines);

                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 1000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông báo ";
                    args.Text = "Cập nhật thành công. Thông báo này sẽ tự đóng sau 1 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                this.tbl_MYCOTOXIN_RESULT_Lines_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_RESULT_Lines_LAB, OBJHeader.ID);
            }
        }
    }
}