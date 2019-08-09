using System;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace Production.Class
{
    public partial class F_PO_List : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        bool gridViewRowClick = false;

        PO_Header OBJ = new PO_Header();

        PO_Header_BUS BUS = new PO_Header_BUS();

        PO_Header PTUH_OBJ = new PO_Header();
        PO_Lines PTUL_OBJ = new PO_Lines();

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

        public F_PO_List()
        {       
            
            InitializeComponent();
            Load += (s, e) =>
                {
                    //btnGiaoMau.Enabled = false;
                    // 1 Lấy thông tin user login
                    OBJ.CreatedBy = user.Username;

                    GridColumn colCounter = gridView1.Columns.AddVisible("STT");
                    colCounter.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                    colCounter.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    colCounter.VisibleIndex = 0;

                    tbl_PO_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PO_Header_LAB);
                  
                    gridControl1.DataSource = tbl_PO_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PO_Header_LAB);                    
                    
                    gridView1.BestFitColumns();

                    

                };

            gridView1.CustomUnboundColumnData += (sender, e) =>
            {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "STT" && e.IsGetData)
                    e.Value = view.GetRowHandle(e.ListSourceRowIndex) + 1;
            };

            gridView1.CellValueChanged += (s, e) =>
            {
                e.Column.BestFit();
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


                //btnGiaoMau.Click += (s, e) =>
                //{
                //    if (gridViewRowClick == true)
                //    {
                //        //Disable
                //        this.Enabled = false;
                //        //
                //        R_PGM_LAB FRM = new Class.R_PGM_LAB();
                //        FRM.OBJ = this.OBJ;
                //        FRM.Show();
                //    }
                //    else
                //        XtraMessageBox.Show("Vui lòng click vào đầu dòng cần giao mẫu ");
                //};
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
            string filePath = @"D:\PNM_Created_"+DateTime.Now.ToShortDateString().Replace("/","_")+".xlsx";
            gridView1.ExportToXlsx(filePath);
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
            F_PO_LAB_Details FRM = new F_PO_LAB_Details();
            FRM.isAction = this.isAction;
            //F_LOC_Dtl.OBJ = this.OBJ;
            FRM.myFinished += this.finished ;
            FRM.Show();
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
                F_PO_LAB_Details FRM = new F_PO_LAB_Details();
                FRM.OBJ_POH = this.OBJ;
                //XtraMessageBox.Show("After set object");
                FRM.isAction = this.isAction;
                FRM.myFinished += this.finished;
                FRM.Show();
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
                BUS.PO_Header_INSERT(OBJ);
            // 29 Khong la tao moi thi update
            else
                BUS.PO_Header_UPDATE(OBJ);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_PO_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PO_Header_LAB);

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
            F_PO_LAB_Details FRM = new F_PO_LAB_Details();
            FRM.isAction = this.isAction;
            FRM.OBJ_POH = this.OBJ;
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
                R_PO_LAB FRM = new R_PO_LAB();
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
                OBJ.SoPO = gridView1.GetFocusedRowCellValue("SoPO").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa phiếu xét nghiệm số : " + OBJ.SoPO + " ?. Lưu ý là tất cả thông tin bao gồm cả kết quả, liên quan đến phiếu xét nghiệm này sẽ bị xóa. Bạn chắc chắn vẫn muốn xóa ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    BUS.PO_Header_DELETE(OBJ.ID);                  
                }
                // 18 Load lại datasource cho grid
                
                gridControl1.DataSource = tbl_PO_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PO_Header_LAB);

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
     
        public void Set4Object()
        {
            OBJ.ID                  = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            OBJ.SoPO                = gridView1.GetFocusedRowCellValue("SoPO").ToString();
            OBJ.NgayGiaoHang        = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayGiaoHang").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.NgayLapPO           = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayLapPO").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.PaymentTerm         = gridView1.GetFocusedRowCellValue("PaymentTerm").ToString();
            OBJ.VENDCode            = gridView1.GetFocusedRowCellValue("VENDCode").ToString();
            OBJ.VENDName            = gridView1.GetFocusedRowCellValue("VENDName").ToString();
            OBJ.DiaChiGiaoHang      = gridView1.GetFocusedRowCellValue("DiaChiGiaoHang").ToString();            
            OBJ.Locked              = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            OBJ.Discount            = gridView1.GetFocusedRowCellValue("Discount").ToString();
        }

        public void finished(object sender)
        {
            //Disable
            this.Enabled = true;
            
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            // Step 2 : Load lại data tren grid sau khi Add
            gridControl1.DataSource = tbl_PO_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PO_Header_LAB);

            gridView1.BestFitColumns();

        }


    }
}
