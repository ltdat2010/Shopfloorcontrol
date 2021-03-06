﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_PO_Lines_Added_Row : DevExpress.XtraEditors.XtraForm
    {
        public DateTime ngaynhanmau;
        private string Path = Directory.GetCurrentDirectory();
        public string isAction = "";
        private bool gridViewRowClick = false;

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

        //NEW : Phan khai bao cho KH Mau
        public PO_Header OBJ_POH = new PO_Header();

        public PO_Lines OBJ_POL = new PO_Lines();

        //public KHMau_LAB KHMAUOBJ = new KHMau_LAB();
        //public KHMau_CTXN_LAB KHMAUCTXNOBJ = new KHMau_CTXN_LAB();
        //public KHMau_CTXN_RESULT_DETAILS_LAB KHMAUCTXNRESULT = new KHMau_CTXN_RESULT_DETAILS_LAB();

        private PO_Lines_BUS BUS_POL = new PO_Lines_BUS();
        //KHMau_LABBUS BUS1 = new KHMau_LABBUS();
        //KHMau_CTXN_LABBUS BUS2 = new KHMau_CTXN_LABBUS();
        //KHMau_CTXN_RESULT_DETAILS_LABBUS BUS3 = new KHMau_CTXN_RESULT_DETAILS_LABBUS();

        public F_PO_Lines_Added_Row()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //XtraMessageBox.Show(OBJ_POH.VENDCode);
                //v_PO_InfoTableAdapter.FillByVENDCODE(sYNC_NUTRICIELDataSet.V_PO_Info, OBJ_POH.VENDCode);
                //v_PO_InfoTableAdapter.Fill(sYNC_NUTRICIELDataSet.V_PO_Info);
                v_NTP_SoPXNTableAdapter.FillBy_VENDCode(sYNC_NUTRICIELDataSet.V_NTP_SoPXN, OBJ_POH.VENDCode);

                this.Width = Screen.PrimaryScreen.Bounds.Width * 2 / 3;
                this.Height = Screen.PrimaryScreen.Bounds.Height * 1 / 2;

                action_EndForm1.Add_Status(false);
                action_EndForm1.Delete_Status(false);
                action_EndForm1.Update_Status(false);
                action_EndForm1.Save_Status(true);
                action_EndForm1.View_Status(false);
                action_EndForm1.Close_Status(true);

                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);

                //txtSoLuongXN.Text = KHMAUOBJ.SoLuongKHMau;

                if (isAction == "Edit")
                {
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    //txtSoLuongXN.Text = KHMAUOBJ.SoLuongKHMau;
                    //KH_Mau
                    Set4Controls_Header();
                    Set4Controls_Details();
                }
                else if (isAction == "Add")
                {
                    //Set4Controls_Header();

                    ////Nut Luu khi Tao moi KH_Mau
                    //btnSave.Enabled = true;

                    ////Luu khi cap nhat thong tin KH_Mau
                    //btnUpdate.Enabled = false;

                    ////KH_Mau
                    //txtKHMau.ReadOnly = false;
                    //txtSoPXN.ReadOnly = true;
                    //txtID.ReadOnly = true;
                    //layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //btnCancel.Enabled = false;
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    //txtSoLuongXN.Text = KHMAUOBJ.SoLuongKHMau;
                    //KH_Mau
                    Set4Controls_Header();
                    Set4Controls_Details();
                }
            };

            lkeSoPXN.EditValueChanged += (s, e) =>
            {
                //XtraMessageBox.Show("Change : " + lkeSoPXN.Text.ToString());
                //XtraMessageBox.Show("OBJ_POH.VENDCode : " + OBJ_POH.VENDCode);
                this.v_PO_InfoTableAdapter.FillBy_VENDCODE_SoPXN(sYNC_NUTRICIELDataSet.V_PO_Info, OBJ_POH.VENDCode, lkeSoPXN.Text.ToString());
            };

            lkeCTXN.EditValueChanged += (s, e) =>
            {
                //if(isAction == "Add")
                //{
                DataRowView row = lkeCTXN.GetSelectedDataRow() as DataRowView;
                OBJ_POL.CTXN = row["CTXN"].ToString();
                OBJ_POL.DonGia = float.Parse(row["DonGia"].ToString());
                //OBJ_POL.GhiChu                          = row["GhiChu"].ToString();
                OBJ_POL.KHMau_CTXN_LAB_Id = int.Parse(row["KHMau_CTXN_LAB_Id"].ToString());
                OBJ_POL.MaCTXN = row["MaCTXN"].ToString();
                OBJ_POL.PriceList_Details_LAB_Id = int.Parse(row["PriceList_Details_LAB_Id"].ToString());
                OBJ_POL.SoPO = txtSoPO.Text;
                OBJ_POL.ThanhTien = float.Parse(row["ThanhTien"].ToString());
                OBJ_POL.UoM = row["UoM"].ToString();
                OBJ_POL.SoLuongXN = row["SoLuongXN"].ToString();
                OBJ_POL.VAT = float.Parse(row["VAT"].ToString());

                //OBJ_POL.CreatedBy = row["CreatedBy"].ToString();
                //OBJ_POL.CreatedDate              = row["CreatedDate"].ToString();
                //OBJ_POL.Locked = row["Locked"].ToString() == "True" ? true : false; ;
                //OBJ_POL.Note = row["Note"].ToString();

                //txtDonGia.Text              = (row as DataRowView)["DonGia"].ToString();
                //txtDonGiaMuaNgoai.Text      = (row as DataRowView)["DonGiaMuaNgoai"].ToString();
                //txtVAT.Text                 = (row as DataRowView)["VAT"].ToString();
                //txtDonGiaSauDiscount.Text   = (row as DataRowView)["DonGia"].ToString();
                //txtDVMuaNgoai.Text          = (row as DataRowView)["DVMuaNgoaiName"].ToString();
                //txtPriceList_Details_LAB_Id.Text = (row as DataRowView)["PriceList_Details_LAB_Id"].ToString();

                //}
            };

            //lkeCTXN.ButtonClick += (s, e) =>
            //{
            //    if (e.Button.Index == 1)
            //    {
            //        //Disable
            //        this.Enabled = false;
            //        //
            //        F_CHITIEUXETNGHIEM_Details FRM = new F_CHITIEUXETNGHIEM_Details();
            //        FRM.myFinished += this.finished ;
            //        FRM.Show();
            //    }
            //};
            //txtDiscount.TextChanged += (s, e) =>
            // {
            //     if (txtDiscount.Text != "0")
            //     {
            //         if (cmbLoaiDiscount.SelectedText == "%")
            //         {
            //             //KHMAUCTXNOBJ.DonGiaSauDiscount = KHMAUCTXNOBJ.DonGia * (1 - KHMAUCTXNOBJ.Discount / 100);
            //             txtDonGiaSauDiscount.Text = (float.Parse(txtDonGia.Text) * (1 - float.Parse(txtDiscount.Text)/100)).ToString();
            //         }
            //         //Neu discount tien
            //         else if (cmbLoaiDiscount.SelectedText == "VND")
            //         {
            //             //KHMAUCTXNOBJ.DonGiaSauDiscount = KHMAUCTXNOBJ.DonGia - KHMAUCTXNOBJ.Discount;
            //             txtDonGiaSauDiscount.Text = (float.Parse(txtDonGia.Text) - float.Parse(txtDiscount.Text)).ToString();
            //         }
            //     }
            //     else
            //         txtDonGiaSauDiscount.Text = (float.Parse(txtDonGia.Text)).ToString();
            //         //KHMAUCTXNOBJ.DonGiaSauDiscount = KHMAUCTXNOBJ.DonGia;

            // };

            //Action_EndForm
            action_EndForm1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action_EndForm1.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update));
            action_EndForm1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action_EndForm1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
        }

        private void ItemClickEventHandler_Save(object sender, ItemClickEventArgs e)
        {
            if (isAction == "Add")
            {
                if (lkeCTXN.Text.Length > 0 && lkeCTXN.Text != "...")
                {
                    Set4Object_Details();
                    //XtraMessageBox.Show("Set object xong");
                    BUS_POL.PO_Lines_INSERT(OBJ_POL);
                    //XtraMessageBox.Show("INSERT xong");
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 1000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông tin ";
                    args.Text = "Lưu thành công . Thông báo này sẽ tự đóng .";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                    Is_close = true;
                    //if (KHMAUOBJ.SoLuongKHMau == null)
                    //{
                    //    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    //    args.AutoCloseOptions.Delay = 3000;
                    //    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    //    args.DefaultButtonIndex = 0;
                    //    args.Caption = "Lưu ý ";
                    //    args.Text = "Vui lòng nhập số lượng mẫu đã nhận . Thông báo này sẽ tự đóng sau 3 giây.";
                    //    args.Buttons = new DialogResult[] { DialogResult.OK };
                    //    XtraMessageBox.Show(args).ToString();

                    //}
                    //else
                    //{
                    //    if (txtSoLuongXN.Text == null)
                    //        txtSoLuongXN.Text = KHMAUOBJ.SoLuongKHMau;
                    //    //
                    //    KHMAUCTXNOBJ.DonGia = float.Parse(txtDonGia.Text.ToString());
                    //    KHMAUCTXNOBJ.VAT = float.Parse(txtVAT.Text.ToString());
                    //    KHMAUCTXNOBJ.DonGiaMuaNgoai = float.Parse(txtDonGiaMuaNgoai.Text.ToString());
                    //    //KHMAUCTXNOBJ.Discount = float.Parse((row as DataRowView)["Discount"].ToString());
                    //    //KHMAUCTXNOBJ.LoaiDiscount = (row as DataRowView)["LoaiDiscount"].ToString();
                    //    KHMAUCTXNOBJ.DonGiaSauDiscount = float.Parse(txtDonGiaSauDiscount.Text.ToString());
                    //    //Dongiasaudiscount
                    //    //Neu discount %

                    //    //ThanhTien
                    //    if (KHMAUCTXNOBJ.DonGiaSauDiscount != 0)
                    //        KHMAUCTXNOBJ.ThanhTien = (KHMAUCTXNOBJ.DonGiaSauDiscount * float.Parse(txtSoLuongXN.Text) * (100 + KHMAUCTXNOBJ.VAT) / 100);
                    //    else
                    //        KHMAUCTXNOBJ.ThanhTien = 0;

                    //    KHMAUCTXNOBJ.KHMau = txtKHMau.Text;
                    //    //DevExpress.XtraGrid.Views.Grid.GridView view = lkeCTXN.Properties.View as DevExpress.XtraGrid.Views.Grid.GridView;
                    //    //KHMAUCTXNOBJ.KHMau_ID = int.Parse(view.GetRowCellValue(view.FocusedRowHandle, "KHMau_ID").ToString());
                    //    KHMAUCTXNOBJ.KHMau_ID = int.Parse(txtID.Text);
                    //    KHMAUCTXNOBJ.PriceList_Details_LAB_Id = int.Parse(txtPriceList_Details_LAB_Id.Text);
                    //    //XtraMessageBox.Show(KHMAUCTXNOBJ.KHMau_ID.ToString());
                    //    KHMAUCTXNOBJ.CTXNID = int.Parse(lkeCTXN.EditValue.ToString());
                    //    //XtraMessageBox.Show(lkeCTXN.EditValue.ToString());
                    //    KHMAUCTXNOBJ.SoLuongXN = txtSoLuongXN.Text;

                    //    BUS2.KHMau_CTXN_LABBUS_INSERT(KHMAUCTXNOBJ);

                    //    if (float.Parse(KHMAUCTXNOBJ.SoLuongXN) >= 1)
                    //    {
                    //        for (int i = 0; i < int.Parse(KHMAUCTXNOBJ.SoLuongXN); i++)
                    //        {
                    //            //KHMAUCTXNRESULT.KHMau_CTXN_ID = KHMAUCTXNOBJ.ID;
                    //            KHMAUCTXNRESULT.KHMau_CTXN_ID = BUS3.MAX_KHMau_CTXN_LABDAO_ID();
                    //            KHMAUCTXNRESULT.LineNo = i;
                    //            BUS3.KHMau_CTXN_LABDAO_INSERT(KHMAUCTXNRESULT);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        KHMAUCTXNRESULT.KHMau_CTXN_ID = BUS3.MAX_KHMau_CTXN_LABDAO_ID();
                    //        KHMAUCTXNRESULT.LineNo = 0;
                    //        BUS3.KHMau_CTXN_LABDAO_INSERT(KHMAUCTXNRESULT);
                    //    }
                    //    //XtraMessageBox.Show("Tạo mới thành công");

                    //}
                }
            }
            else if (isAction == "Edit")
            {
                Set4Object_Details();
                //BUS2.KHMau_CTXN_LABDAO_UPDATE(KHMAUCTXNOBJ);
                ////XtraMessageBox.Show("Cập nhật thành công");
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo ";
                args.Text = "Cập nhật thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
                Is_close = true;
            }
            ////throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Close(object sender, ItemClickEventArgs e)
        {
            Is_close = true;
            //this.Close();
            //Set4Object_Details();
            ////KHMau_LABBUS
            //BUS1.KHMau_LABBUS_UPDATE(KHMAUOBJ);

            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Update(object sender, ItemClickEventArgs e)
        {
            Set4Object_Details();
            //BUS2.KHMau_CTXN_LABDAO_UPDATE(KHMAUCTXNOBJ);
            ////XtraMessageBox.Show("Cập nhật thành công");
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 2000;
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            args.DefaultButtonIndex = 0;
            args.Caption = "Thông báo ";
            args.Text = "Cập nhật thành công . Thông báo này sẽ tự đóng sau 2 giây.";
            args.Buttons = new DialogResult[] { DialogResult.OK };
            XtraMessageBox.Show(args).ToString();
            Is_close = true;
            ////}
            ////throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Set4Controls_Header()
        {
            txtID.Text = OBJ_POH.ID.ToString();
            //txtKHMau.Text           = KHMAUOBJ.KHMau;
            txtSoPO.Text = OBJ_POH.SoPO;
            //txtSoLuongKHMau.Text    = KHMAUOBJ.SoLuongKHMau;
            if (isAction == "Edit")
                txtID.Text = OBJ_POL.ID.ToString();
        }

        public void Set4Controls_Details()
        {
            if (isAction == "Edit")
            {
                //txtSoLuongXN.Text           = KHMAUCTXNOBJ.SoLuongXN;
                //lkeCTXN.EditValue           = KHMAUCTXNOBJ.CTXNID;
                //txtDonGia.Text              = KHMAUCTXNOBJ.DonGia.ToString();
                //txtDonGiaSauDiscount.Text   = KHMAUCTXNOBJ.DonGiaSauDiscount.ToString();
                //txtDiscount.Text    = KHMAUCTXNOBJ.Discount.ToString();
                //cmbLoaiDiscount.Text = KHMAUCTXNOBJ.LoaiDiscount.ToString();
                //txtDonGiaMuaNgoai.Text      = KHMAUCTXNOBJ.DonGiaMuaNgoai.ToString();
                //txtVAT.Text                 = KHMAUCTXNOBJ.VAT.ToString();
                //txtPriceList_Details_LAB_Id.Text = KHMAUCTXNOBJ.PriceList_Details_LAB_Id.ToString();
            }
        }

        public void Set4Object_Header()
        {
            //OBJ_POH.KHMau = txtKHMau.Text;
            if (isAction == "Edit")
                OBJ_POH.ID = int.Parse(txtID.Text.ToString());
            OBJ_POH.SoPO = txtSoPO.Text;
        }

        public void Set4Object_Details()
        {
            //KHMAUCTXNOBJ.SoLuongXN = txtSoLuongXN.Text;
            //KHMAUCTXNOBJ.CTXNID = int.Parse(lkeCTXN.EditValue.ToString());
            //KHMAUOBJ.CreatedBy = user.Username;
            //KHMAUCTXNOBJ.DonGia = float.Parse(txtDonGia.Text.ToString());
            //KHMAUCTXNOBJ.LoaiDiscount = cmbLoaiDiscount.SelectedText;
            //KHMAUCTXNOBJ.Discount = float.Parse(txtDiscount.Text.ToString());
            //KHMAUCTXNOBJ.DonGiaSauDiscount = float.Parse(txtDonGiaSauDiscount.Text.ToString());
            //KHMAUCTXNOBJ.DonGiaMuaNgoai = float.Parse(txtDonGiaMuaNgoai.Text.ToString());
            //KHMAUCTXNOBJ.VAT = float.Parse(txtVAT.Text.ToString());
            //KHMAUCTXNOBJ.PriceList_Details_LAB_Id = int.Parse(txtPriceList_Details_LAB_Id.Text);
        }

        public void ResetControl()
        {
            //txtKHMau.Text = "";
            lkeCTXN.Text = "";
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            //txtKHMau.ReadOnly = bl;
            lkeCTXN.ReadOnly = bl;
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
            //this.v_NTP_SoPXNTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.V_NTP_SoPXN);
            //this.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMauTableAdapter.FillBy_NgayNhanMau_Note(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMau, KHMAUOBJ.SoPXN.Substring(0, 3), ngaynhanmau.ToString());
        }

        private void F_PO_Lines_Added_Row_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.V_NTP_SoPXN' table. You can move, or remove it, as needed.
            this.v_NTP_SoPXNTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.V_NTP_SoPXN);
        }
    }
}