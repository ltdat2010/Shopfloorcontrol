using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_PXN_List : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        private bool gridViewRowClick = false;

        private PXN_Header OBJ = new PXN_Header();
        private PXN_HeaderBUS BUS = new PXN_HeaderBUS();
        private KHMau_LABBUS BUS1 = new KHMau_LABBUS();
        private KHMau_CTXN_LABBUS BUS2 = new KHMau_CTXN_LABBUS();
        private KHMau_CTXN_RESULT_DETAILS_LABBUS BUS3 = new KHMau_CTXN_RESULT_DETAILS_LABBUS();

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

        public F_PXN_List()
        {
            InitializeComponent();

            tbl_PXN_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PXN_Header);
            //tbl_KHMau_CTXN_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB);
            tbl_KHMau_LAB_ORGTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_KHMau_LAB_ORG);

            Load += (s, e) =>
                {
                    if (PCname == "vpv-lab-sample")
                        path = @"D:\PNM_Created" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
                    else
                        path = @"X:\PNM_Created" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

                    //btnGiaoMau.Enabled = false;
                    // 1 Lấy thông tin user login
                    OBJ.CreatedBy = user.Username;

                    //tbl_PXN_Header_ORGTableAdapter.Fill(sYNC_NUTRICIEL_ORIGINAL_TABLE.tbl_PXN_Header_ORG);

                    //gridControl1.DataSource = tbl_PXN_Header_ORGTableAdapter.Fill(sYNC_NUTRICIEL_ORIGINAL_TABLE.tbl_PXN_Header_ORG);

                    gridView1.BestFitColumns();    
                };            

            // 7 Add hoặc New
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));

            // 8 Lưu
            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));

            // 9 Edit hoặc Update
            action1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));

            // 10 Del
            action1.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete));

            // 10a View
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            // 10a Report
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));

            // 10B Cancel
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));

            // 10C Excel
            action1.Excel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Excel));

            gridView1.RowClick += (s, e) =>
            {
                gridViewRowClick = true;
                Set4Object();
                //if ((bool)gridView1.GetFocusedRowCellValue("BanGiaoMauStatus") == false)
                //btnGiaoMau.Enabled = true;
            };

            btnViewProcess.Click += (s, e) =>
             {
                 //Disable
                 this.Enabled = false;
                 //
                 F_Scheduling_Details FRM = new F_Scheduling_Details();
                 Set4Object();
                 FRM.isAction = this.isAction;
                 FRM.OBJ = this.OBJ;
                 FRM.Show();
             };

            btnGiaoMau.Click += (s, e) =>
            {
                if (gridViewRowClick == true)
                {
                    DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xuất phiếu giao mẫu cho mẫu số : " + OBJ.SoPXN + " ?. Lưu ý là tất cả thông tin bao gồm cả kết quả, liên quan đến phiếu xét nghiệm này sẽ bị xóa. Bạn chắc chắn vẫn muốn xóa ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        if(gridView1.GetFocusedRowCellValue("GiaoMau").ToString() == "false")
                            BUS.PXN_HeaderDAO_UPDATE_NgayGiaoMau(OBJ.ID, DateTime.Now, true, user.Username);
                        //Disable
                        this.Enabled = false;
                        //Update 20190822
                        //R_PGM_LAB FRM = new Class.R_PGM_LAB();
                        //FRM.OBJ = this.OBJ;
                        //FRM.Show();
                        F_GiaoMau_LAB FRM = new Class.F_GiaoMau_LAB();
                        FRM.OBJ = this.OBJ;
                        FRM.Show();
                    }                       
                    
                }
                else
                    XtraMessageBox.Show("Vui lòng click vào đầu dòng cần giao mẫu ");
            };

            //FOOTER
            gridView1.OptionsView.ShowFooter = true;
            gridView1.FooterPanelHeight = 70;

            Color highPriority = Color.Green;
            Color normalPriority = Color.Orange;
            Color lowPriority = Color.Red;
            int markWidth = 16;

            // Handle this event to paint the footer panel manually
            gridView1.CustomDrawFooter += (s, e) => {
                int offset = 5;
                e.DefaultDraw();
                Color color = highPriority;
                Rectangle markRectangle;
                string priorityText = " - High level";
                for (int i = 0; i < 3; i++)
                {
                    if (i == 1)
                    {
                        color = normalPriority;
                        priorityText = " - Normal level";
                    }
                    else if (i == 2)
                    {
                        color = lowPriority;
                        priorityText = " - Low level";
                    }
                    markRectangle = new Rectangle(e.Bounds.X + offset, e.Bounds.Y + offset + (markWidth + offset) * i, markWidth, markWidth);
                    e.Cache.FillEllipse(markRectangle.X, markRectangle.Y, markRectangle.Width, markRectangle.Height, color);
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    e.Appearance.Options.UseTextOptions = true;
                    e.Appearance.DrawString(e.Cache, priorityText, new Rectangle(markRectangle.Right + offset, markRectangle.Y, e.Bounds.Width, markRectangle.Height));
                }
            };

            gridView1.CustomDrawCell += (s, e) => {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                e.Appearance.Options.UseTextOptions = true;
                e.DefaultDraw();
                if (e.Column.FieldName == "ID")
                {
                    Color color;
                    int cellValue = Convert.ToInt32(e.CellValue);
                    if (cellValue < 3)
                        color = highPriority;
                    else if (cellValue > 2 && cellValue < 5)
                        color = normalPriority;
                    else
                        color = lowPriority;
                    e.Cache.FillEllipse(e.Bounds.X + 1, e.Bounds.Y + 1, markWidth, markWidth, color);
                }
            };


        }

        //public void SMTP_SEND(string parm_SmtpServer,
        //                        int parm_port,
        //                        string parm_Username,
        //                        string parm_Password,
        //                        string parm_From,
        //                        string parm_To,
        //                        string parm_Subject,
        //                        string parm_Body )
        //{
        //    //Send email
        //    //SMTP
        //    SmtpClient SmtpServer = new SmtpClient(parm_SmtpServer);
        //    SmtpServer.Port = parm_port;
        //    SmtpServer.Credentials = new System.Net.NetworkCredential(parm_Username, parm_Password);
        //    //SEND
        //    try
        //    {
        //        MailMessage mail = new MailMessage();
        //        //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

        //        mail.From = new MailAddress("dat.lt@olmixasia.com");
        //        //mail.To.Add("ltdat2010@gmail.com");
        //        mail.To.Add(parm_To);
        //        mail.Subject = "Test Mail";
        //        mail.IsBodyHtml = true;
        //        mail.Body = "This is for testing SMTP mail from DAT to TRUYEN";

        //        //SmtpServer.Port = 587;
        //        //SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
        //        //SmtpServer.EnableSsl = true;

        //        SmtpServer.Send(mail);
        //        MessageBox.Show("mail Send");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //public static string GetHtml(string parm_SoPXN,
        //    string parm_NgayNhanMau,
        //    string parm_NgayDuKienTra,
        //    string[] parm_CTXN)
        //{
        //    try
        //    {
        //        string messageBody = "<font>The following are the records: </font><br><br>";
        //        //if (grid.RowCount == 0) return messageBody;
        //        string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
        //        string htmlTableEnd = "</table>";
        //        string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
        //        string htmlHeaderRowEnd = "</tr>";
        //        string htmlTrStart = "<tr style=\"color:#555555;\">";
        //        string htmlTrEnd = "</tr>";
        //        string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
        //        string htmlTdEnd = "</td>";
        //        messageBody += htmlTableStart;
        //        messageBody += htmlHeaderRowStart;
        //        messageBody += htmlTdStart + "Student Name" + htmlTdEnd;
        //        messageBody += htmlTdStart + "DOB" + htmlTdEnd;
        //        messageBody += htmlTdStart + "Email" + htmlTdEnd;
        //        messageBody += htmlTdStart + "Mobile" + htmlTdEnd;
        //        messageBody += htmlHeaderRowEnd;
        //        //Loop all the rows from grid vew and added to html td
        //        //for (int i = 0; i <= grid.RowCount - 1; i++)
        //        //{
        //        //    messageBody = messageBody + htmlTrStart;
        //        //    messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[0].Value + htmlTdEnd; //adding student name
        //        //    messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[1].Value + htmlTdEnd; //adding DOB
        //        //    messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[2].Value + htmlTdEnd; //adding Email
        //        //    messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[3].Value + htmlTdEnd; //adding Mobile
        //        //    messageBody = messageBody + htmlTrEnd;
        //        //}
        //        for (int i = 0; i <= parm_CTXN.Length - 1; i++)
        //        {
        //            messageBody = messageBody + htmlTrStart;
        //            messageBody = messageBody + htmlTdStart + parm_CTXN[i].ToString() + htmlTdEnd; //adding student name
        //            //messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[1].Value + htmlTdEnd; //adding DOB
        //            //messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[2].Value + htmlTdEnd; //adding Email
        //            //messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[3].Value + htmlTdEnd; //adding Mobile
        //            messageBody = messageBody + htmlTrEnd;
        //        }
        //        messageBody = messageBody + htmlTableEnd;
        //        return messageBody; // return HTML Table as string from this function
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        private void ItemClickEventHandler_Excel(object sender, EventArgs e)
        {

            //string filePath = @"X:\PNM_Created_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            gridView1.ExportToXlsx(path);

            System.Diagnostics.Process.Start(path);
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isAction = "Add";

            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            //Disable
            this.Enabled = false;
            //
            F_PXN_Details F_LOC_Dtl = new F_PXN_Details();
            F_LOC_Dtl.isAction = this.isAction;
            //F_LOC_Dtl.OBJ = this.OBJ;
            F_LOC_Dtl.myFinished += this.finished;
            F_LOC_Dtl.Show();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            // 25 isEditting gan bang true
            //isEditting = true;
            isAction = "Edit";

            state = MenuState.Update;

            if (gridViewRowClick == true)
            {
                Set4Object();

                // Truyen object LOC to DELEGATE
                //Disable
                this.Enabled = false;
                //XtraMessageBox.Show("Started form");
                //
                F_PXN_Details F_LOC_Dtl = new Class.F_PXN_Details();
                F_LOC_Dtl.OBJ = this.OBJ;
                //XtraMessageBox.Show("After set object");
                F_LOC_Dtl.isAction = this.isAction;
                F_LOC_Dtl.myFinished += this.finished;
                F_LOC_Dtl.Show();
                //XtraMessageBox.Show("Showed");
            }
            else
                XtraMessageBox.Show("Vui lòng click vào đầu dòng cần chỉnh sửa ");
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            // 27 Gán dữ liệ trên control cho object
            Set4Object();

            // 28 Kiem tra xem co phai là tao moi khong thi insert
            //if (isNew == true)
            if (isAction == "Add")
                BUS.PXN_HeaderBUS_INSERT(OBJ);
            // 29 Khong la tao moi thi update
            else
                BUS.PXN_HeaderBUS_UPDATE(OBJ);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_PXN_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PXN_Header);

            gridView1.BestFitColumns();
            // 31 Tra lai trang thai ban dau cho IsNew
            //isNew = false;
            isAction = "";
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            // 23 Gán state UPdate cho tat ca cac nut
            state = MenuState.Update;

            //24  Edit hoặc update nên  isNew gán bằng false
            //isNew = false;

            // 25 isEditting gan bang true
            //isEditting = true;
            isAction = "View";

            // 26 COntrols gỡ bỏ trạng thái đọc cho phép nhập liệu
            //ControlsReadOnly(false);

            //Truyen object LOC to DELEGATE
            //Disable
            this.Enabled = false;
            //
            F_PXN_Details FRM = new Class.F_PXN_Details();
            FRM.isAction = this.isAction;
            FRM.OBJ = this.OBJ;
            FRM.myFinished += this.finished;
            FRM.Show();
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            if (gridViewRowClick == true)
            {
                //Disable
                this.Enabled = false;
                //
                R_PXN_LAB FRM = new Class.R_PXN_LAB();
                FRM.OBJ = this.OBJ;
                FRM.myFinished += this.finished;
                FRM.Show();
            }
            else
                XtraMessageBox.Show("Vui lòng click vào đầu dòng cần chỉnh sửa ");
        }

        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            // 14 Khai báo state cho các nút khi nhấn nút Del
            state = MenuState.Delete;

            if (gridViewRowClick == true)
            {
                OBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                OBJ.SoPXN = gridView1.GetFocusedRowCellValue("SoPXN").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa phiếu nhận mẫu số : " + OBJ.SoPXN + " ?. Lưu ý là tất cả thông tin bao gồm cả kết quả, liên quan đến phiếu xét nghiệm này sẽ bị xóa. Bạn chắc chắn vẫn muốn xóa ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    //Ẩn sau khi xét CASCADE trong SYNC_NUTRICIELDataset.xsd
                    //DataTable dt, dt1, dt2, dt3 = new DataTable();
                    ////Xoa tat ca ki hieu mau co trong phieu xet nghiem nay
                    //dt1 = BUS1.KHMau_LABBUS_SELECT(OBJ.SoPXN);
                    //foreach (DataRow dr1 in dt1.Rows)
                    //{
                    //    dt2 = BUS2.KHMau_CTXN_LABDAO_SELECT(int.Parse(dr1["ID"].ToString()));

                    //    foreach (DataRow dr2 in dt2.Rows)
                    //    {
                    //        //XtraMessageBox.Show("dt2.Rows : " + dt2.Rows.Count.ToString());
                    //        BUS3.KHMau_CTXN_LABDAO_DELETE_ByKHMau_CTXN_ID(int.Parse(dr2["ID"].ToString()));
                    //        //XtraMessageBox.Show("DELETE dr2[ID].ToString() : " + dr2["ID"].ToString());
                    //    }
                    //    //XtraMessageBox.Show("DELETE dr1[KHMau].ToString() : " + dr1["KHMau"].ToString());
                    //    BUS2.KHMau_CTXN_LABDAO_DELETE_ByKHMau(int.Parse(dr1["ID"].ToString()));
                    //}
                    ////XtraMessageBox.Show("DELETE OBJ.SoPXN : " + OBJ.SoPXN);
                    //BUS1.KHMau_LABBUS_DELETE_SoPXN(OBJ.SoPXN);

                    BUS.PXN_HeaderBUS_DELETE(OBJ);
                }
                // 18 Load lại datasource cho grid

                gridControl1.DataSource = tbl_PXN_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PXN_Header);

                gridView1.BestFitColumns();
                // 17 trả trạng thái cho các nút như ban đầu
                state = MenuState.Full;
            }
            else
                // 16 Xác nhận có muốn xoa không ?
                XtraMessageBox.Show("Vui lòng click vào đầu dòng cần chỉnh sửa ");
        }

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ItemClickEventHandler_Refresh(object sender, EventArgs e)
        {

            
        }
        public void Set4Object()
        {
            OBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            OBJ.SoPXN = gridView1.GetFocusedRowCellValue("SoPXN").ToString();
            OBJ.LoaiXN = gridView1.GetFocusedRowCellValue("LoaiXN").ToString();
            OBJ.NgayNhanMau = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayNhanMau").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.TenCoSoGuiMau = gridView1.GetFocusedRowCellValue("TenCoSoGuiMau").ToString();
            OBJ.DCCoSoGuiMau = gridView1.GetFocusedRowCellValue("DCCoSoGuiMau").ToString();
            OBJ.PhoneCoSoGuiMau = gridView1.GetFocusedRowCellValue("PhoneCoSoGuiMau").ToString();
            OBJ.FaxCoSoGuiMau = gridView1.GetFocusedRowCellValue("FaxCoSoGuiMau").ToString();
            OBJ.EmailCoSoGuiMau = gridView1.GetFocusedRowCellValue("EmailCoSoGuiMau").ToString();
            OBJ.MSTCoSoGuiMau = gridView1.GetFocusedRowCellValue("MSTCoSoGuiMau").ToString();
            OBJ.TenCoSoLayMau = gridView1.GetFocusedRowCellValue("TenCoSoLayMau").ToString();
            OBJ.DCCoSoLayMau = gridView1.GetFocusedRowCellValue("DCCoSoLayMau").ToString();
            OBJ.PhoneCoSoLayMau = gridView1.GetFocusedRowCellValue("PhoneCoSoLayMau").ToString();
            OBJ.FaxCoSoLayMau = gridView1.GetFocusedRowCellValue("FaxCoSoLayMau").ToString();
            OBJ.EmailCoSoLayMau = gridView1.GetFocusedRowCellValue("EmailCoSoLayMau").ToString();
            //OBJ.LoaiDVMauNuoc = gridView1.GetFocusedRowCellValue("LoaiDVMauNuoc").ToString();
            //OBJ.NgayLayMau = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayLayMau").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.NgayDuKienTra = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayDuKienTra").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            //OBJ.LoaiMauGui = gridView1.GetFocusedRowCellValue("LoaiMauGui").ToString();
            //OBJ.SLMauGui = gridView1.GetFocusedRowCellValue("SLMauGui").ToString();
            //OBJ.TTMauGui = gridView1.GetFocusedRowCellValue("TTMauGui").ToString();
            //OBJ.VTLayMauDayChuong = gridView1.GetFocusedRowCellValue("VTLayMauDayChuong").ToString();
            //OBJ.GioLayMauTuoi = gridView1.GetFocusedRowCellValue("GioLayMauTuoi").ToString();
            OBJ.KHMau = gridView1.GetFocusedRowCellValue("KHMau").ToString();
            //OBJ.Khac = gridView1.GetFocusedRowCellValue("Khac").ToString();
            OBJ.PTNThucHien = gridView1.GetFocusedRowCellValue("PTNThucHien").ToString() == "True" ? true : false;
            //OBJ.PL = txtTenmauCOA.Text;
            //OBJ.PL = txtDienGiai.Text;
            //OBJ.EffDate = dteEffDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteEffDate.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //OBJ.ExpDate = dteExpDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteExpDate.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            OBJ.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            //OBJ.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            //OBJ.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            OBJ.SendMail = gridView1.GetFocusedRowCellValue("SendMail").ToString();
            if (gridView1.GetFocusedRowCellValue("DonViXuatHoaDon_ID").ToString() == string.Empty)
                OBJ.DonViXuatHoaDon_ID = 0;
            else
                OBJ.DonViXuatHoaDon_ID = int.Parse(gridView1.GetFocusedRowCellValue("DonViXuatHoaDon_ID").ToString());
        }

        public void finished(object sender)
        {
            //Disable
            this.Enabled = true;
            //
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            // Step 2 : Load lại data tren grid sau khi Add        
            sYNC_NUTRICIELDataSet.EnforceConstraints = false;
            tbl_KHMau_LAB_ORGTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_KHMau_LAB_ORG);

            tbl_PXN_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PXN_Header);
            //tbl_KHMau_CTXN_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB);
            sYNC_NUTRICIELDataSet.EnforceConstraints = true;

            gridView1.BestFitColumns();
        }

        private void cardView1_CustomDrawCardCaption_1(object sender, CardCaptionCustomDrawEventArgs e)
        {
            CardView view = sender as CardView;
            bool isFocusedCard = e.RowHandle == view.FocusedRowHandle;
            //The brush to draw the background of card captions. 
            Brush backBrush, foreBrush;
            Color color1 = Color.FromArgb(142, 57, 80);
            Color color2 = Color.FromArgb(240, 140, 40);
            Color color3 = Color.FromArgb(70, 55, 94);
            Color color4 = Color.FromArgb(144, 84, 84);
            if (isFocusedCard)
            {
                backBrush = e.Cache.GetGradientBrush(e.Bounds, color1, color2, LinearGradientMode.ForwardDiagonal);
                foreBrush = Brushes.White;
            }
            else
            {
                backBrush = e.Cache.GetGradientBrush(e.Bounds, color3, color4, LinearGradientMode.ForwardDiagonal);
                foreBrush = Brushes.Coral;
            }
            //XtraMessageBox.Show(view.GetRowCellValue(e.RowHandle, "KHMau").ToString());
            //e.CardCaption = view.GetRowCellValue(e.RowHandle, "KHMau").ToString();
            Rectangle r = e.Bounds;
            r.Inflate(1, 0);
            e.Cache.FillRectangle(backBrush, r);
            // Draw the text. 
            e.Appearance.DrawString(e.Cache, view.GetRowCellValue(e.RowHandle, "KHMau").ToString(), r, foreBrush);
            // Disable default painting. 
            e.Handled = true;
        }
    }
}