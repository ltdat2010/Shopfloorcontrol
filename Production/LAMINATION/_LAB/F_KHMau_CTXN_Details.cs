using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_KHMau_CTXN_Details : frm_Base
    {
        public DateTime ngaynhanmau;
        private string Path = Directory.GetCurrentDirectory();
        public string isAction = "";
        private bool gridViewRowClick = false;
        public ArrayList rows = new ArrayList();
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

        //NEW : Phan khai bao cho KH Mau
        public KHMau_LAB KHMAUOBJ = new KHMau_LAB();

        public KHMau_CTXN_LAB KHMAUCTXNOBJ = new KHMau_CTXN_LAB();
        public KHMau_CTXN_RESULT_DETAILS_LAB KHMAUCTXNRESULT = new KHMau_CTXN_RESULT_DETAILS_LAB();

        private KHMau_LABBUS BUS1 = new KHMau_LABBUS();
        private KHMau_CTXN_LABBUS BUS2 = new KHMau_CTXN_LABBUS();
        private KHMau_CTXN_RESULT_DETAILS_LABBUS BUS3 = new KHMau_CTXN_RESULT_DETAILS_LABBUS();

        public F_KHMau_CTXN_Details()
        {
            InitializeComponent();

            Load += (s, e) =>
            {
                this.priceList_ChiTieuXetNghiemTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.PriceList_ChiTieuXetNghiem, ngaynhanmau.ToString(), KHMAUOBJ.SoPXN.Substring(0, 3));

                this.Width = Screen.PrimaryScreen.Bounds.Width * 5 / 6;
                this.Height = Screen.PrimaryScreen.Bounds.Height * 9 / 10;

                action_EndForm1.Add_Status(false);
                action_EndForm1.Delete_Status(false);
                action_EndForm1.Update_Status(false);
                action_EndForm1.Save_Status(true);
                action_EndForm1.View_Status(false);
                action_EndForm1.Close_Status(true);

                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);

                txtSoLuongXN.Text = KHMAUOBJ.SoLuongKHMau;

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
                //if (lkeCTXN.Text.Length > 0 && lkeCTXN.Text != "...")
                //{
                if (KHMAUOBJ.SoLuongKHMau == null)
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Lưu ý ";
                    args.Text = "Vui lòng nhập số lượng mẫu đã nhận . Thông báo này sẽ tự đóng sau 2 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                else
                {

                    if (gridView1.SelectedRowsCount > 0)
                    {
                        foreach (int _SelectedRows in gridView1.GetSelectedRows())
                        {
                            DataRow dr = gridView1.GetDataRow(_SelectedRows);
                            //rows.Add(gridView1.GetDataRow(i));
                            if (txtSoLuongXN.Text == null)
                                txtSoLuongXN.Text = KHMAUOBJ.SoLuongKHMau;
                            KHMAUCTXNOBJ.DonGia = float.Parse(dr["DonGia"].ToString()); //float.Parse(txtDonGia.Text.ToString());
                            KHMAUCTXNOBJ.VAT = float.Parse(dr["VAT"].ToString()); //float.Parse(txtVAT.Text.ToString());
                            KHMAUCTXNOBJ.DonGiaMuaNgoai = float.Parse(dr["DonGiaMuaNgoai"].ToString()); //float.Parse(txtDonGiaMuaNgoai.Text.ToString());
                            KHMAUCTXNOBJ.DonGiaSauDiscount = float.Parse(dr["DonGia"].ToString());
                            if (KHMAUCTXNOBJ.DonGiaSauDiscount != 0)
                                KHMAUCTXNOBJ.ThanhTien = (KHMAUCTXNOBJ.DonGiaSauDiscount * float.Parse(txtSoLuongXN.Text) * (100 + KHMAUCTXNOBJ.VAT) / 100);//(KHMAUCTXNOBJ.DonGiaSauDiscount * float.Parse(txtSoLuongXN.Text) * (100 + KHMAUCTXNOBJ.VAT) / 100);
                            else
                                KHMAUCTXNOBJ.ThanhTien = 0;

                            KHMAUCTXNOBJ.KHMau = txtKHMau.Text; //txtKHMau.Text;
                            KHMAUCTXNOBJ.KHMau_ID = int.Parse(txtID.Text); //int.Parse(txtID.Text);
                            KHMAUCTXNOBJ.PriceList_Details_LAB_Id = int.Parse(dr["PriceList_Details_LAB_Id"].ToString());//int.Parse(txtPriceList_Details_LAB_Id.Text);
                            KHMAUCTXNOBJ.KHMau_ID = KHMAUOBJ.ID;
                            KHMAUCTXNOBJ.CTXNID = int.Parse(dr["CTXNID"].ToString()); //int.Parse(txtCTXNID.Text.ToString());
                            KHMAUCTXNOBJ.SoLuongXN = txtSoLuongXN.Text; //txtSoLuongXN.Text;
                            KHMAUCTXNOBJ.DaTraKetQua = false;
                            KHMAUCTXNOBJ.GoiYCXuatHD = false;
                            KHMAUCTXNOBJ.KetQua = false;
                            BUS2.KHMau_CTXN_LABBUS_INSERT(KHMAUCTXNOBJ);

                            if (float.Parse(KHMAUCTXNOBJ.SoLuongXN) >= 1)
                            {
                                for (int i = 0; i < int.Parse(KHMAUCTXNOBJ.SoLuongXN); i++)
                                {
                                    //KHMAUCTXNRESULT.KHMau_CTXN_ID = KHMAUCTXNOBJ.ID;
                                    KHMAUCTXNRESULT.KHMau_CTXN_ID = BUS3.MAX_KHMau_CTXN_LABDAO_ID();
                                    KHMAUCTXNRESULT.LineNo = i;
                                    BUS3.KHMau_CTXN_LABDAO_INSERT(KHMAUCTXNRESULT);
                                }
                            }
                            else
                            {
                                KHMAUCTXNRESULT.KHMau_CTXN_ID = BUS3.MAX_KHMau_CTXN_LABDAO_ID();
                                KHMAUCTXNRESULT.LineNo = 0;
                                BUS3.KHMau_CTXN_LABDAO_INSERT(KHMAUCTXNRESULT);
                            }
                        }
                        Is_close = true;
                    }

                    else
                    {
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 2000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Thông báo ";
                        args.Text = "Không có chỉ tiêu xét nghiệm nào được chọn. Thông báo này sẽ tự đóng sau 2 giây.";
                        args.Buttons = new DialogResult[] { DialogResult.OK };
                        XtraMessageBox.Show(args).ToString();
                    }
                }
                
            }
            else if (isAction == "Edit")
            {
                Set4Object_Details();
                BUS2.KHMau_CTXN_LABDAO_UPDATE(KHMAUCTXNOBJ);
                //XtraMessageBox.Show("Cập nhật thành công");
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 2000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo ";
                args.Text = "Cập nhật thành công . Thông báo này sẽ tự đóng sau 2 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
                Is_close = true;
            }
            //throw new NotImplementedException();
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
            BUS2.KHMau_CTXN_LABDAO_UPDATE(KHMAUCTXNOBJ);
            //XtraMessageBox.Show("Cập nhật thành công");
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 2000;
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            args.DefaultButtonIndex = 0;
            args.Caption = "Thông báo ";
            args.Text = "Cập nhật thành công . Thông báo này sẽ tự đóng sau 2 giây.";
            args.Buttons = new DialogResult[] { DialogResult.OK };
            XtraMessageBox.Show(args).ToString();
            Is_close = true;
            //}
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Set4Controls_Header()
        {
            txtID.Text = KHMAUOBJ.ID.ToString();
            txtKHMau.Text = KHMAUOBJ.KHMau;
            txtSoPXN.Text = KHMAUOBJ.SoPXN;
            txtSoLuongKHMau.Text = KHMAUOBJ.SoLuongKHMau;
            //if (isAction == "Edit")
        }

        public void Set4Controls_Details()
        {
            if (isAction == "Edit")
            {
                txtKHMau_CTXN_Id.Text = KHMAUCTXNOBJ.ID.ToString();
                txtSoLuongXN.Text = KHMAUCTXNOBJ.SoLuongXN;
                //txtDonGia.Text = KHMAUCTXNOBJ.DonGia.ToString();
                //txtDonGiaSauDiscount.Text = KHMAUCTXNOBJ.DonGia.ToString();//KHMAUCTXNOBJ.DonGiaSauDiscount.ToString();
                //txtDiscount.Text                    = KHMAUCTXNOBJ.Discount.ToString();
                //cmbLoaiDiscount.Text                = KHMAUCTXNOBJ.LoaiDiscount.ToString();
                //txtDonGiaMuaNgoai.Text = KHMAUCTXNOBJ.DonGiaMuaNgoai.ToString();
                //txtVAT.Text = KHMAUCTXNOBJ.VAT.ToString();
                txtPriceList_Details_LAB_Id.Text = KHMAUCTXNOBJ.PriceList_Details_LAB_Id.ToString();
            }
        }

        public void Set4Object_Header()
        {
            KHMAUOBJ.KHMau = txtKHMau.Text;
            if (isAction == "Edit")
                KHMAUOBJ.ID = int.Parse(txtID.Text.ToString());
            KHMAUOBJ.SoPXN = txtSoPXN.Text;
        }

        public void Set4Object_Details()
        {
            if (isAction == "Edit")
                KHMAUCTXNOBJ.ID = int.Parse(txtKHMau_CTXN_Id.Text.ToString());
            KHMAUCTXNOBJ.SoLuongXN = txtSoLuongXN.Text;
            //KHMAUCTXNOBJ.CTXNID = int.Parse(txtCTXNID.Text.ToString());
            //KHMAUOBJ.CreatedBy = user.Username;
            //KHMAUCTXNOBJ.DonGia = float.Parse(txtDonGia.Text.ToString());
            //KHMAUCTXNOBJ.LoaiDiscount = cmbLoaiDiscount.SelectedText;
            //KHMAUCTXNOBJ.Discount = float.Parse(txtDiscount.Text.ToString());
            //KHMAUCTXNOBJ.DonGiaSauDiscount = float.Parse(txtDonGiaSauDiscount.Text.ToString());
            //KHMAUCTXNOBJ.DonGiaMuaNgoai = float.Parse(txtDonGiaMuaNgoai.Text.ToString());
            //KHMAUCTXNOBJ.VAT = float.Parse(txtVAT.Text.ToString());
            // KHMAUCTXNOBJ.PriceList_Details_LAB_Id = int.Parse(txtPriceList_Details_LAB_Id.Text);
            //KHMAUCTXNOBJ.KHMau_ID = KHMAUOBJ.ID;
        }

        public void ResetControl()
        {
            txtKHMau.Text = "";
        }

        //
        public void ControlsReadOnly(bool bl)
        {
            txtKHMau.ReadOnly = bl;
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
            this.priceList_ChiTieuXetNghiemTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.PriceList_ChiTieuXetNghiem, ngaynhanmau.ToString(), KHMAUOBJ.SoPXN.Substring(0, 3));
        }              

        
    }
}