using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_PXN_Result : frm_Base
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
        public int gridRow = 0;

        /// <summary>
        /// DELEGATE
        /// </summary>
        public delegate void MyAdd(object sender);//, string isActionReturn);

        public event MyAdd myFinished;

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this);//, isActionReturn: isAction);
                }
            }
        }

        public PXN_Header OBJ = new PXN_Header();
        private PXN_Details OBJ1 = new PXN_Details();
        //public KQKN_Template_Details_Row OBJ1 = new KQKN_Template_Details_Row();

        private PXN_HeaderBUS BUS = new PXN_HeaderBUS();

        //Shcedule
        private Resources RSRC = new Resources();

        private ResourcesBUS RSRCBUS = new ResourcesBUS();

        public F_PXN_Result()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //MessageBox.Show(isAction);
                if (isAction == "Edit")
                {
                    Set4Controls();
                    TDControlsReadOnly(true);
                    gridControl1.DataSource = tbl_PXN_DetailsTableAdapter.FillBySoPXN(sYNC_NUTRICIELDataSet.tbl_PXN_Details, txtSoPXN.Text);
                }
                else if (isAction == "Add")
                {
                    TDControlsReadOnly(true);

                    gridControl1.Enabled = false;
                    actionMini1.Enabled = false;
                    txtID.ReadOnly = true;
                }
                gridRow = gridView1.DataRowCount;
                if (gridRow > 0)
                    dteNgayDukienTra.ReadOnly = false;
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
                        BUS.PXN_HeaderBUS_INSERT(OBJ);
                        gridControl1.Enabled = true;
                        actionMini1.Enabled = true;
                        //Gan gia tri ID moi insert vo table tbl_KQKN_Template_Hedaer cho form
                        OBJ.ID = BUS.MAX_PXN_HeaderBUS_ID();
                        //ParentResourcesId///////////////////////////////////////////////
                        int ParentResourcesId;
                        // Tao ResourcesId--cho Schedule
                        RSRC.Subject = txtSoPXN.Text;
                        RSRC.Description = txtSoPXN.Text;
                        RSRC.CustomField1 = "LAB";
                        //MessageBox.Show("1");
                        RSRCBUS.Resources_INSERT(RSRC);
                        //MessageBox.Show("2");
                        ParentResourcesId = RSRCBUS.GET_ResourceId(RSRC.Description);
                        RSRC.ParentId = ParentResourcesId;
                        //MessageBox.Show("3");
                        RSRCBUS.Appointments_INSERT(dteNgayNhanMau.SelectedText, dteNgayNhanMau.SelectedText, ParentResourcesId, "Code mẫu ( nhận mẫu )", "LAB", 1);
                        //MessageBox.Show("4" + dteNgayNhanMau.EditValue.ToString());
                        /////////////////////////////////////////////////////////////////

                        RSRC.Id = RSRCBUS.GET_ResourceId(RSRC.Description);

                        RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Chuyển đến phòng XN", "LAB", 2);
                        //////////////////////////////////////////////////////////////////
                        RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Thời gian bắt đầu XN", "LAB", 3);
                        //////////////////////////////////////////////////////////////////
                        RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "XN hoàn tất", "LAB", 4);
                        //////////////////////////////////////////////////////////////////
                        RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Bộ phận nhận kết quả", "LAB", 5);
                        //////////////////////////////////////////////////////////////////
                        RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Kiểm tra kết quả", "LAB", 6);
                        //////////////////////////////////////////////////////////////////
                        RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Trả kết quả cho khách hàng", "LAB", 7);
                        //////////////////////////////////////////////////////////////////
                    }
                    else if (isAction == "Edit")
                    {
                        Set4ObjectHeader();
                        Set4ObjectRow();
                        //Khong cho update Header
                        BUS.PXN_HeaderBUS_UPDATE(OBJ);
                        if (gridRow <= 0)
                        {
                            //Send email
                            //SMTP
                            SmtpClient SmtpServer = new SmtpClient("mail.olmixasia.com");
                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("dat.lt@olmixasia.com", "QwLmn090");
                            //SEND
                            try
                            {
                                MailMessage mail = new MailMessage();
                                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                                mail.From = new MailAddress("dat.lt@olmixasia.com");
                                mail.To.Add("ltdat2010@gmail.com");
                                //mail.To.Add("truyen.htb@viphavet.com");
                                //mail.To.Add("tuyet.ntb@olmixasia.com");
                                mail.CC.Add("dat.lt@olmixasia.com");
                                mail.Subject = "Vipha.Lab : Thông tin xét nghiệm số " + txtSoPXN.Text;
                                //1_Export to pdf

                                //2_Attach to Email
                                mail.Attachments.Add(new Attachment(@"X:\\" + txtSoPXN.Text + ".pdf"));
                                //mail.Body = "This is for testing SMTP mail from DAT to TRUYEN";
                                mail.IsBodyHtml = true;
                                //SmtpServer.Port = 587;
                                //SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                                //SmtpServer.EnableSsl = true;
                                string messageBody = "<font>Dear : " + lkeTenCoSoGuiMau.Text + "</font><br><br>";

                                //if (grid.RowCount == 0) return messageBody;
                                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                                string htmlTableEnd = "</table>";
                                string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
                                string htmlHeaderRowEnd = "</tr>";
                                string htmlTrStart = "<tr style=\"color:#555555;\">";
                                string htmlTrEnd = "</tr>";
                                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                                string htmlTdEnd = "</td>";
                                messageBody += "Vipha.Lab xin thông báo đã tạo code mẫu theo yêu cầu của Anh/Chị. Nội dung như sau : <br><br>";
                                messageBody += "Ngày nhận mẫu :" + dteNgayNhanMau.EditValue.ToString() + " <br><br>";
                                messageBody += "Ngày dự kiến trả mẫu :" + dteNgayDukienTra.EditValue.ToString() + " <br><br>";
                                messageBody += "Chỉ tiêu xét nghiệm bao gồm  <br><br>";
                                messageBody += htmlTableStart;
                                messageBody += htmlHeaderRowStart;
                                messageBody += htmlTdStart + "Chỉ tiêu xét nghiệm" + htmlTdEnd;
                                messageBody += htmlTdStart + "Số lượng mẫu" + htmlTdEnd;
                                messageBody += htmlHeaderRowEnd;
                                // messageBody += htmlTdStart + "Email" + htmlTdEnd;
                                //messageBody += htmlTdStart + "Mobile" + htmlTdEnd;
                                for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
                                {
                                    messageBody = messageBody + htmlTrStart;
                                    messageBody = messageBody + htmlTdStart + gridView1.GetRowCellValue(i, "CTXN").ToString() + htmlTdEnd; //adding student name
                                    messageBody = messageBody + htmlTdStart + gridView1.GetRowCellValue(i, "SLMau").ToString() + htmlTdEnd;
                                    //messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[1].Value + htmlTdEnd; //adding DOB
                                    //messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[2].Value + htmlTdEnd; //adding Email
                                    //messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[3].Value + htmlTdEnd; //adding Mobile
                                    messageBody = messageBody + htmlTrEnd;
                                }
                                messageBody += "Mọi thắc mắc và phản hồi nếu có xin vui lòng liên hệ số điện thoại 090-xxxx-xxx gặp Ms Truyền  <br><br>";
                                messageBody += "Xin cảm ơn đã sử dụng dịch vụ của chúng tôi. <br><br>";
                                messageBody = messageBody + htmlTableEnd;
                                mail.Body = messageBody;
                                SmtpServer.Send(mail);
                                MessageBox.Show("Email đã được gởi đến khách hàng.Trong trường hợp email bị lỗi bạn sẽ thấy thông báo lỗi trong mục Send của OutLook .");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        else
                        {
                            //Send email
                            //SMTP
                            SmtpClient SmtpServer = new SmtpClient("mail.olmixasia.com");
                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("dat.lt@olmixasia.com", "QwLmn090");
                            //SEND
                            try
                            {
                                MailMessage mail = new MailMessage();
                                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                                mail.From = new MailAddress("dat.lt@olmixasia.com");
                                mail.To.Add("ltdat2010@gmail.com");
                                //mail.To.Add("truyen.htb@viphavet.com");
                                mail.Subject = "Vipha.Lab : Cập nhật thông tin xét nghiệm số " + txtSoPXN.Text;
                                //mail.Body = "This is for testing SMTP mail from DAT to TRUYEN";
                                mail.IsBodyHtml = true;
                                //SmtpServer.Port = 587;
                                //SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                                //SmtpServer.EnableSsl = true;
                                string messageBody = "<font>Dear " + lkeTenCoSoGuiMau.Text + " </font><br><br>";
                                //if (grid.RowCount == 0) return messageBody;
                                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                                string htmlTableEnd = "</table>";
                                string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
                                string htmlHeaderRowEnd = "</tr>";
                                string htmlTrStart = "<tr style=\"color:#555555;\">";
                                string htmlTrEnd = "</tr>";
                                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                                string htmlTdEnd = "</td>";
                                messageBody += "Vipha.Lab xin thông báo đã tạo cập nhật code mẫu " + txtSoPXN.Text + " theo yêu cầu của Anh/Chị. Nội dung như sau :  <br><br>";
                                messageBody += "Ngày nhận mẫu :" + dteNgayNhanMau.EditValue.ToString() + " <br><br>";
                                messageBody += "Ngày dự kiến trả mẫu :" + dteNgayDukienTra.EditValue.ToString() + "  <br><br>";
                                messageBody += "Chỉ tiêu xét nghiệm bao gồm <br><br>";
                                messageBody += htmlTableStart;
                                messageBody += htmlHeaderRowStart;
                                messageBody += htmlTdStart + "Chỉ tiêu xét nghiệm" + htmlTdEnd;
                                messageBody += htmlTdStart + "Số lượng mẫu" + htmlTdEnd;
                                // messageBody += htmlTdStart + "Email" + htmlTdEnd;
                                //messageBody += htmlTdStart + "Mobile" + htmlTdEnd;
                                messageBody += htmlHeaderRowEnd;
                                for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
                                {
                                    messageBody = messageBody + htmlTrStart;
                                    messageBody = messageBody + htmlTdStart + gridView1.GetRowCellValue(i, "CTXN").ToString() + htmlTdEnd; //adding student name
                                    messageBody = messageBody + htmlTdStart + gridView1.GetRowCellValue(i, "SLMau").ToString() + htmlTdEnd;
                                    //messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[1].Value + htmlTdEnd; //adding DOB
                                    //messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[2].Value + htmlTdEnd; //adding Email
                                    //messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[3].Value + htmlTdEnd; //adding Mobile
                                    messageBody = messageBody + htmlTrEnd;
                                }
                                messageBody += "Mọi thắc mắc và phản hồi nếu có xin vui lòng liên hệ số điện thoại 090-xxxx-xxx gặp Ms Truyền  <br><br>";
                                messageBody += "Xin cảm ơn đã sử dụng dịch vụ của chúng tôi.  <br><br>";

                                messageBody = messageBody + htmlTableEnd;
                                mail.Body = messageBody;
                                SmtpServer.Send(mail);
                                MessageBox.Show("Đã gởi email thông báo cho khách hàng gởi mẫu.Trong trường hợp email bị lỗi bạn sẽ thấy thông báo lỗi trong mục Send của OutLook .");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
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

            gridView1.InitNewRow += (s, e) =>
            {
                gridViewRowClick = true;
            };

            btnCancel.Click += (s, e) =>
            {
                //this.Close();
            };
            //this.FormClosed += (s, e) =>
            //{
            //};

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

            chkGEN.CheckedChanged += (s, e) =>
             {
                 if (chkGEN.CheckState == CheckState.Checked)
                 {
                     dteNgayNhanMau.ReadOnly = false;
                     //TDControlsReadOnly(false);

                     chkH2O.CheckState = CheckState.Unchecked;
                     chkHTH.CheckState = CheckState.Unchecked;

                     //cmbLoaiDV
                     layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                     layoutControlItem30.Text = "Loại động vật";

                     //cmbMauNuoc
                     layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                     layoutControlItem39.Text = "Mẫu nước";
                 }
                 if (isAction == "Add")
                 {
                     OBJ.LoaiXN = "GEN";
                     txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
                 }
             };

            chkHTH.CheckedChanged += (s, e) =>
            {
                if (chkHTH.CheckState == CheckState.Checked)
                {
                    dteNgayNhanMau.ReadOnly = false;
                    //TDControlsReadOnly(false);

                    chkH2O.CheckState = CheckState.Unchecked;
                    chkGEN.CheckState = CheckState.Unchecked;

                    //cmbLoaiDV
                    layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem30.Text = "Loại động vật";

                    //cmbMauNuoc
                    layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem39.Text = "Mẫu nước";
                }

                if (isAction == "Add")
                {
                    OBJ.LoaiXN = "HTH";
                    txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
                }
            };

            chkH2O.CheckedChanged += (s, e) =>
            {
                if (chkH2O.CheckState == CheckState.Checked)
                {
                    dteNgayNhanMau.ReadOnly = false;
                    //TDControlsReadOnly(false);

                    chkGEN.CheckState = CheckState.Unchecked;
                    chkHTH.CheckState = CheckState.Unchecked;
                    //cmbLoaiDV
                    layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem30.Text = "Loại động vật";
                    //cmbMauNuoc
                    layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem39.Text = "Mẫu nước";
                }
                if (isAction == "Add")
                {
                    OBJ.LoaiXN = "H2O";
                    txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
                }
            };

            dteNgayNhanMau.EditValueChanged += (s, e) =>
            {
                dteNgayDukienTra.ReadOnly = false;
            };

            dteNgayDukienTra.EditValueChanged += (s, e) =>
            {
                TDControlsReadOnly(false);
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
            if (OBJ.LoaiXN == "GEN")
            {
                chkGEN.CheckState = CheckState.Checked;
                chkH2O.CheckState = CheckState.Unchecked;
                chkH2O.ReadOnly = true;
                chkHTH.CheckState = CheckState.Unchecked;
                chkHTH.ReadOnly = true;
            }
            else if (OBJ.LoaiXN == "H2O")
            {
                chkGEN.CheckState = CheckState.Unchecked;
                chkGEN.ReadOnly = true;
                chkH2O.CheckState = CheckState.Checked;
                chkHTH.CheckState = CheckState.Unchecked;
                chkHTH.ReadOnly = true;
            }
            else if (OBJ.LoaiXN == "H2O")
            {
                chkGEN.CheckState = CheckState.Unchecked;
                chkGEN.ReadOnly = true;
                chkH2O.CheckState = CheckState.Unchecked;
                chkH2O.ReadOnly = true;
                chkHTH.CheckState = CheckState.Checked;
            }

            dteNgayNhanMau.Text = OBJ.NgayNhanMau.ToString().Substring(0, 10);
            txtSoPXN.Text = OBJ.SoPXN;
            lkeTenCoSoGuiMau.Text = OBJ.TenCoSoGuiMau;
            txtDCCoSoGuiMau.Text = OBJ.DCCoSoGuiMau;
            txtPhoneCoSoGuiMau.Text = OBJ.PhoneCoSoGuiMau;
            txtFaxCoSoGuiMau.Text = OBJ.FaxCoSoGuiMau;
            txtEmailCoSoGuiMau.Text = OBJ.EmailCoSoGuiMau;
            txtMSTCoSoGuiMau.Text = OBJ.MSTCoSoGuiMau;
            txtTenCoSoLayMau.Text = OBJ.TenCoSoLayMau;
            txtDCCoSoLayMau.Text = OBJ.DCCoSoLayMau;
            txtPhoneCoSoLayMau.Text = OBJ.PhoneCoSoLayMau;
            txtFaxCoSoLayMau.Text = OBJ.FaxCoSoLayMau;
            txtEmailCoSoLayMau.Text = OBJ.EmailCoSoLayMau;
            //if (chkH2O.CheckState == CheckState.Checked)
            //{
            //    cmbLoaiDongVat.Text = "";
            //    cmbMauNuoc.Text = OBJ.LoaiDVMauNuoc;
            //}
            //else if (chkHTH.CheckState == CheckState.Checked || chkGEN.CheckState == CheckState.Checked)
            //{
            //    cmbLoaiDongVat.Text = OBJ.LoaiDVMauNuoc;
            //    cmbMauNuoc.Text = "";
            //}
            //dteNgayLayMau.Text = OBJ.NgayLayMau.ToString().Substring(0, 10);
            dteNgayDukienTra.Text = OBJ.NgayDuKienTra.ToString().Substring(0, 10);
            //cmbLoaiMauGui.Text = OBJ.LoaiMauGui;
            //txtSLMauGui.Text = OBJ.SLMauGui;
            //txtTTMauGui.Text = OBJ.TTMauGui;
            //txtVTMauDayChuong.Text = OBJ.VTLayMauDayChuong;
            //txtGioLayMauTuoi.Text = OBJ.GioLayMauTuoi;
            txtKHMau.Text = OBJ.KHMau;
            txtKhac.Text = OBJ.Khac;
            if (OBJ.PTNThucHien == true)
                chkPTN.CheckState = CheckState.Checked;
            else if (OBJ.PTNThucHien == false)
                chkNTP.CheckState = CheckState.Checked;

            //chkGEN
            //chkH2O
            //chkHTH
            //dteNgayNhanMau
            //txtSoPXN
            //txtTenCoSoGuiMau
            //txtDCCoSoGuiMau
            //txtPhoneCoSoGuiMau
            //txtFaxCoSoGuiMau
            //txtEmailCoSoGuiMau
            //txtMSTCoSoGuiMau
            //txtTenCoSoLayMau
            //txtDCCoSoLayMau
            //txtPhoneCoSoLayMau.Properties
            //txtFaxCoSoLayMau.Properties
            //txtEmailCoSoLayMau.Properties
            //dteExpDate
            //cmbLoaiDongVat
            //cmbMauNuoc
            //dteNgayLayMau
            //cmbLoaiMauGui
            //txtSLMauGui
            //txtTTMauGui
            //txtVTMauDayChuong
            //txtGioLayMauTuoi
            //txtKHMau
            //txtKhac
            //chkPTN
            //chkNTP

            ////txtTenmauCOA.Text = OBJ.PL.ToString();
            ////txtDienGiai.Text = OBJ.PL.ToString();
            ////txtNote.Text = OBJ.Note;
            ////cmbKhoa.Text = OBJ.Locked.ToString();
            ////dteEffDate.Text = OBJ.EffDate.ToString().Substring(0, 10);
            ////dteExpDate.Text = OBJ.ExpDate.ToString().Substring(0, 10);
        }

        public void Set4ObjectRow()
        {
            if (isAction == "Edit")
            {
                ////OBJ1
                ////MessageBox.Show("1");
                //OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                ////MessageBox.Show("2");
                //OBJ1.CTXNID = int.Parse(gridView1.GetFocusedRowCellValue("CTXNID").ToString());
                ////MessageBox.Show("3");
                //OBJ1.PLID = int.Parse(gridView1.GetFocusedRowCellValue("PLID").ToString());
                ////MessageBox.Show("4");
                //OBJ1.DonGia = gridView1.GetFocusedRowCellValue("DonGia").ToString();
                //OBJ1.Giam = gridView1.GetFocusedRowCellValue("Giam").ToString();
                //OBJ1.SoLuong = gridView1.GetFocusedRowCellValue("SoLuong").ToString();
                //OBJ1.UoM = gridView1.GetFocusedRowCellValue("UoM").ToString();
                //OBJ1.UoMGiam = gridView1.GetFocusedRowCellValue("UoMGiam").ToString();
                ////MessageBox.Show("5");
                //OBJ1.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
                ////MessageBox.Show("6");
                //OBJ1.CreatedBy = gridView1.GetFocusedRowCellValue("CreatedBy").ToString();
                ////MessageBox.Show("7");
                //OBJ1.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
                ////MessageBox.Show("8");
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
                //OBJ.Note = txtNote.Text;
                //OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            }

            //OBJ.ID = int.Parse(txtID.Text);

            if (chkGEN.CheckState == CheckState.Checked)
            {
                OBJ.LoaiXN = "GEN";
            }
            else if (chkH2O.CheckState == CheckState.Checked)
            {
                OBJ.LoaiXN = "H2O";
            }
            else if (chkHTH.CheckState == CheckState.Checked)
            {
                OBJ.LoaiXN = "H2O";
            }

            OBJ.NgayNhanMau = dteNgayNhanMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhanMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.SoPXN = txtSoPXN.Text;
            OBJ.TenCoSoGuiMau = lkeTenCoSoGuiMau.Text;
            OBJ.DCCoSoGuiMau = txtDCCoSoGuiMau.Text;
            OBJ.PhoneCoSoGuiMau = txtPhoneCoSoGuiMau.Text;
            OBJ.FaxCoSoGuiMau = txtFaxCoSoGuiMau.Text;
            OBJ.EmailCoSoGuiMau = txtEmailCoSoGuiMau.Text;
            OBJ.MSTCoSoGuiMau = txtMSTCoSoGuiMau.Text;
            OBJ.TenCoSoLayMau = txtTenCoSoLayMau.Text;
            OBJ.DCCoSoLayMau = txtDCCoSoLayMau.Text;
            OBJ.PhoneCoSoLayMau = txtPhoneCoSoLayMau.Text;
            OBJ.FaxCoSoLayMau = txtFaxCoSoLayMau.Text;
            OBJ.EmailCoSoLayMau = txtEmailCoSoLayMau.Text;

            //if (cmbLoaiDongVat.Text == "")
            //{
            //    OBJ.LoaiDVMauNuoc = cmbMauNuoc.Text;
            //}
            //else if (cmbMauNuoc.Text == "")
            //{
            //    OBJ.LoaiDVMauNuoc = cmbLoaiDongVat.Text;
            //}
            //OBJ.NgayLayMau = dteNgayLayMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayLayMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.NgayDuKienTra = dteNgayDukienTra.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayDukienTra.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //OBJ.LoaiMauGui = cmbLoaiMauGui.Text;
            //OBJ.SLMauGui = txtSLMauGui.Text;
            //OBJ.TTMauGui = txtTTMauGui.Text;
            //OBJ.VTLayMauDayChuong = txtVTMauDayChuong.Text;
            //OBJ.GioLayMauTuoi = txtGioLayMauTuoi.Text;
            OBJ.KHMau = txtKHMau.Text;
            OBJ.Khac = txtKhac.Text;

            if (chkPTN.CheckState == CheckState.Checked)
                OBJ.PTNThucHien = true;
            else if (chkNTP.CheckState == CheckState.Checked)
                OBJ.PTNThucHien = false;
            //OBJ.PL = txtTenmauCOA.Text;
            //OBJ.PL = txtDienGiai.Text;
            //OBJ.EffDate = dteEffDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteEffDate.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //OBJ.ExpDate = dteExpDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteExpDate.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.Note = txtNote.Text;
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }

        public void ResetControl()
        {
            txtID.Text = "";
            lkeTenCoSoGuiMau.Text = "";
            //lkeCTPT.Text = "";
            //lkeTC.Text = "";

            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        public void TDControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            //chkGEN.ReadOnly = bl;
            //chkH2O.ReadOnly = bl;
            //chkHTH.ReadOnly = bl;
            dteNgayNhanMau.ReadOnly = bl;
            txtSoPXN.ReadOnly = bl;
            lkeTenCoSoGuiMau.ReadOnly = bl;
            txtDCCoSoGuiMau.ReadOnly = bl;
            txtPhoneCoSoGuiMau.ReadOnly = bl;
            txtFaxCoSoGuiMau.ReadOnly = bl;
            txtEmailCoSoGuiMau.ReadOnly = bl;
            txtMSTCoSoGuiMau.ReadOnly = bl;
            txtTenCoSoLayMau.ReadOnly = bl;
            txtDCCoSoLayMau.ReadOnly = bl;
            txtPhoneCoSoLayMau.ReadOnly = bl;
            txtFaxCoSoLayMau.ReadOnly = bl;
            txtEmailCoSoLayMau.ReadOnly = bl;
            cmbLoaiDongVat.ReadOnly = bl;
            cmbMauNuoc.ReadOnly = bl;
            dteNgayLayMau.ReadOnly = bl;
            dteNgayDukienTra.ReadOnly = bl;
            cmbLoaiMauGui.ReadOnly = bl;
            txtSLMauGui.ReadOnly = bl;
            txtTTMauGui.ReadOnly = bl;
            txtVTMauDayChuong.ReadOnly = bl;
            txtGioLayMauTuoi.ReadOnly = bl;
            txtKHMau.ReadOnly = bl;
            txtKhac.ReadOnly = bl;
            chkPTN.ReadOnly = bl;
            chkNTP.ReadOnly = bl;
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            Set4ObjectHeader();

            isActionMini = "Add";
            //Riêng cho trường hợp tạo mới Row trên KQKN template
            //Truyen ID cua KQKN template cho Row
            OBJ1.ID = OBJ.ID;

            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            //Disable
            this.Enabled = false;
            //
            F_PXN_Details_Added_Row FRM = new F_PXN_Details_Added_Row();
            FRM.isAction = this.isActionMini;
            FRM.ngaynhanmau = dteNgayNhanMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhanMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ1.SoPXN = OBJ.SoPXN;
            FRM.OBJ = this.OBJ1;
            FRM.myFinished += this.finished;
            FRM.Show();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            //Luu y : Chỉ cho xóa ko ch edit

            //isActionMini = "Edit";
            ////Riêng cho trường hợp tạo mới Row trên KQKN template
            ////Truyen ID cua KQKN template cho Row
            //OBJ1.PLID = OBJ.ID;
            //OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            //OBJ1.PLID = int.Parse(gridView1.GetFocusedRowCellValue("PLID").ToString());
            //OBJ1.DonGia = gridView1.GetFocusedRowCellValue("DonGia").ToString();
            //OBJ1.VAT = gridView1.GetFocusedRowCellValue("VAT").ToString();
            //OBJ1.SoLuong = gridView1.GetFocusedRowCellValue("SoLuong").ToString();
            //OBJ1.UoM = gridView1.GetFocusedRowCellValue("UoM").ToString();
            //OBJ1.UoMGiam = gridView1.GetFocusedRowCellValue("UoMGiam").ToString();
            //OBJ1.Giam = gridView1.GetFocusedRowCellValue("Giam").ToString();
            //OBJ1.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            //OBJ1.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            //OBJ1.CTXNID = int.Parse(gridView1.GetFocusedRowCellValue("CTXNID").ToString());

            //state = MenuState.Update;
            ////Update :  DELEGATE
            //// Gọi form Details
            //F_PRICELIST_Details_Added_Row FRM = new F_PRICELIST_Details_Added_Row();
            //FRM.isAction = this.isActionMini;
            //FRM.OBJ = this.OBJ1;
            //FRM.myFinished += this.finished;
            //FRM.Show();
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            Set4ObjectHeader();
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
            //Disable
            this.Enabled = false;
            //
            F_PXN_Details_Added_Row FRM = new F_PXN_Details_Added_Row();
            FRM.isAction = this.isActionMini;
            FRM.ngaynhanmau = dteNgayNhanMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhanMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ1.SoPXN = OBJ.SoPXN;
            FRM.OBJ = this.OBJ1;
            FRM.myFinished += this.finished;
            FRM.Show();
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
                    //BUS1.PRICELIST_DELETE(OBJ1);
                }
                // 18 Load lại datasource cho grid

                gridControl1.DataSource = tbl_PXN_DetailsTableAdapter.FillBySoPXN(sYNC_NUTRICIELDataSet.tbl_PXN_Details, txtSoPXN.Text);

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
                DialogResult Dlg = XtraMessageBox.Show(" Bạn đã thay đổi nội dung . Bạn có muốn lưu lại ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Dlg == DialogResult.No)
                    this.Close();
                else
                {
                    Set4ObjectHeader();
                    //BUS.PRICELISTBUS_UPDATE(OBJ);
                    this.Close();
                }
            }
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

            //// Step 2 : Load lại data tren grid sau khi Add
            gridControl1.DataSource = tbl_PXN_DetailsTableAdapter.FillBySoPXN(sYNC_NUTRICIELDataSet.tbl_PXN_Details, txtSoPXN.Text);
            gridView1.BestFitColumns();
        }

        private void F_PRICELIST_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB' table. You can move, or remove it, as needed.
            this.tbl_EMPLOYEE_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PriceList_Details_LAB' table. You can move, or remove it, as needed.
            this.tbl_PXN_DetailsTableAdapter.FillBySoPXN(this.sYNC_NUTRICIELDataSet.tbl_PXN_Details, txtSoPXN.Text);
        }

        public string Func_SoPXN_NPT(int SoPXN)
        {
            string SoPXN_Text = "";

            switch (SoPXN.ToString().Length)
            {
                case (1):
                    SoPXN_Text = OBJ.LoaiXN + DateTime.Now.Year.ToString().Substring(2, 2) + "000" + BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN).ToString();
                    break;

                case (2):
                    SoPXN_Text = OBJ.LoaiXN + DateTime.Now.Year.ToString().Substring(2, 2) + "00" + BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN).ToString();
                    break;

                case (3):
                    SoPXN_Text = OBJ.LoaiXN + DateTime.Now.Year.ToString().Substring(2, 2) + "0" + BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN).ToString();
                    break;

                case (4):
                    SoPXN_Text = OBJ.LoaiXN + DateTime.Now.Year.ToString().Substring(2, 2) + BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN).ToString();
                    break;
            }
            return SoPXN_Text;
        }

        private void lkeTenCoSoGuiMau_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView row = lkeTenCoSoGuiMau.Properties.GetDataSourceRowByKeyValue(lkeTenCoSoGuiMau.EditValue) as DataRowView;
            txtDCCoSoGuiMau.Text = row["DCCoSoGuiMau"].ToString();
        }
    }
}