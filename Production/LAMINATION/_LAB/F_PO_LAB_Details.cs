using System;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Data;
using DevExpress.XtraBars;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.Data;

namespace Production.Class
{
    public partial class F_PO_LAB_Details : frm_Base
    {
        public DateTime ngaynhanmau;
        string Path = Directory.GetCurrentDirectory();
        public string isAction = "";
        public string str_KHMau = "";
        bool gridViewRowClick = false;

        float value1, value2;
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
        //public KHMau_LAB KHMAUOBJ = new KHMau_LAB();
        //KHMau_CTXN_LAB KHMAUCTXNOBJ = new KHMau_CTXN_LAB();
        //KHMau_LABBUS BUS1 = new KHMau_LABBUS();
        //KHMau_CTXN_LABBUS BUS2 = new KHMau_CTXN_LABBUS();        
        public PO_Header OBJ_POH = new PO_Header();
        PO_Lines OBJ_POL = new PO_Lines();


        PO_Header_BUS BUS_POH = new PO_Header_BUS();
        PO_Lines_BUS BUS_POL = new PO_Lines_BUS();

        public F_PO_LAB_Details()
        {
            InitializeComponent();
            Load += (s,e) =>
            {                
                this.Width                      = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
                this.Height                     = Screen.PrimaryScreen.Bounds.Height - 30;

                //XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //args.AutoCloseOptions.Delay = 3000;
                //args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //args.DefaultButtonIndex = 0;
                //args.Caption = "Lưu ý ";
                //args.Text = "Vui lòng click vào dòng cần chỉnh sửa . Thông báo này sẽ tự đóng sau 3 giây.";
                //args.Buttons = new DialogResult[] { DialogResult.OK };
                //XtraMessageBox.Show(args).ToString();

                action_EndForm1.Add_Status(false);
                action_EndForm1.Delete_Status(false);
                action_EndForm1.Update_Status(false);
                action_EndForm1.Save_Status(true);
                action_EndForm1.View_Status(true);
                action_EndForm1.Close_Status(false);

                action_EndForm2.Add_Status(true);
                action_EndForm2.Delete_Status(true);
                action_EndForm2.Update_Status(true);
                action_EndForm2.Save_Status(false);
                action_EndForm2.View_Status(false);
                action_EndForm2.Close_Status(false);

                action_EndForm3.Add_Status(false);
                action_EndForm3.Delete_Status(false);
                action_EndForm3.Update_Status(false);
                action_EndForm3.Save_Status(true);
                action_EndForm3.View_Status(false);
                action_EndForm3.Close_Status(true);
                                
                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);
                //XtraMessageBox.Show("Action : " + isAction);

                if (isAction == "Edit")
                {
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;                    
                    txtSoPO.ReadOnly = true;
                    Set4Controls_Header();
                    Set4Controls_Details();
                    this.tbl_PO_Lines_LABTableAdapter.FillBy(sYNC_NUTRICIELDataSet.tbl_PO_Lines_LAB, txtSoPO.Text);

                    //GridSummaryItem groupSummaryItem0 = gridView1.
                    //XtraMessageBox.Show(groupSummaryItem0.SummaryValue.ToString());
                    //GridSummaryItem groupSummaryItem1 = gridView1.GroupSummary[1];                    
                    //XtraMessageBox.Show(groupSummaryItem1.SummaryValue.ToString());
                }
                else if (isAction == "Add")
                {
                    Set4Controls_Header();
                    txtSoPO.ReadOnly = true;
                    int suff_SoPO = int.Parse((BUS_POH.Issued_SoPO().Substring(3,3)));
                    if(suff_SoPO == 0)
                        txtSoPO.Text = DateTime.Now.Year.ToString().Substring(2, 2) + "."+"001";
                    else if (suff_SoPO <= 9 && suff_SoPO >0)
                    {
                        suff_SoPO = suff_SoPO + 1;
                        txtSoPO.Text = DateTime.Now.Year.ToString().Substring(2,2) + "." + "00"+ suff_SoPO.ToString();
                    }
                    else if (suff_SoPO <= 99 && suff_SoPO > 9)
                    {
                        suff_SoPO = suff_SoPO + 1;
                        txtSoPO.Text = DateTime.Now.Year.ToString().Substring(2, 2) + "." + "0" + suff_SoPO.ToString();
                    }
                    else if (suff_SoPO <= 999 && suff_SoPO > 99)
                    {
                        suff_SoPO = suff_SoPO + 1;
                        txtSoPO.Text = DateTime.Now.Year.ToString().Substring(2, 2) + "." + suff_SoPO.ToString();
                    }                    
                    txtID.ReadOnly = true;
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //btnCancel.Enabled = false;
                }
                //Khong tao moi thi huy form
                //btnSave.Enabled = true;
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


            gridView1.CustomSummaryCalculate += (sender, e) =>
            {
                //GridView View = sender as GridView;
                if (e.IsGroupSummary)
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Start)
                    {
                        value1 = value2 = 0;
                    }
                    if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                    {
                        value1 += (float)gridView1.GetRowCellValue(e.RowHandle, "ThanhTien");
                        value2 += float.Parse(OBJ_POH.Discount.ToString());
                    }
                    if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                    {
                        float result = value1 - value2;
                        //result = float.Round(result, 4, MidpointRounding.AwayFromZero);
                        e.TotalValue = result;
                    }
                }
            };

            lkeNhaCungCap.EditValueChanged += (s, e) =>
            {
                DataRowView row = lkeNhaCungCap.GetSelectedDataRow() as DataRowView;
                //OBJ_POL.CTXNDG = row["CTXNDG"].ToString();
                OBJ_POH.VENDCode= row["VENDCode"].ToString();
                OBJ_POH.VENDName= row["VENDName"].ToString();                
            };

            gridView1.RowClick += (s, e) =>
            {
                //KHMAUCTXNOBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                gridViewRowClick = true;
                Set4Object_Details();
            };            

            lkeNhaCungCap.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    
                }
             };
            txtDiscount.Leave += (s, e) =>
            {
                XtraMessageBox.Show(gridView1.DataRowCount.ToString());
            };

                //Action_EndForm
                action_EndForm1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action_EndForm1.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update));
            action_EndForm1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action_EndForm1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
            //Action_EndForm
            action_EndForm2.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add2));
            action_EndForm2.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update2));
            action_EndForm2.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close2));
            action_EndForm2.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save2));
            action_EndForm2.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete2));
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
                ////BUS2.KHMau_CTXN_LABDAO_UPDATE(KHMAUCTXNOBJ);
                Is_close = true;
                ////throw new NotImplementedException();
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
            if (gridView1.RowCount > 0)
            {
                Set4Object_Details();
            }
            else
            {
                //this.Close();
            }
            Is_close = true;
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Update3(object sender, ItemClickEventArgs e)
        {
            Set4Object_Details();
            

            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 3000;
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            args.DefaultButtonIndex = 0;
            args.Caption = "Thông báo ";
            args.Text = "Cập nhật thành công. Thông báo này sẽ tự đóng sau 5 giây.";
            args.Buttons = new DialogResult[] { DialogResult.OK };
            XtraMessageBox.Show(args).ToString();

            Is_close = true;
            ////}
            ////throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add3(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Delete2(object sender, ItemClickEventArgs e)
        {
            if (gridViewRowClick == true)
            {
                //BUS2.KHMau_CTXN_LABDAO_DELETE(KHMAUCTXNOBJ.ID);
                gridViewRowClick = false;
                ////XtraMessageBox.Show("Xóa thành công ");
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo ";
                args.Text = "Xóa thành công. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
                //gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, txtKHMau.Text);
            }
            else
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo ";
                args.Text = "Vui lòng click vào đầu dòng cần xóa. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }
            ////throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Save2(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Close2(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Update2(object sender, ItemClickEventArgs e)
        {
            if (gridViewRowClick == true)
            {
                isAction = "Edit";

                state = MenuState.Insert;
                
                this.Enabled = false;
                
                F_PO_Lines_Added_Row FRM = new F_PO_Lines_Added_Row();
                FRM.isAction = this.isAction;
                FRM.ngaynhanmau = this.ngaynhanmau;
                Set4Object_Details();
                FRM.OBJ_POH = this.OBJ_POH;
                FRM.OBJ_POL = this.OBJ_POL;
                FRM.myFinished += this.finished;
                FRM.Show();
            }
            else
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo tự đóng ";
                args.Text = "Vui lòng click chọn dòng cần cập nhật. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }            
        }

        private void ItemClickEventHandler_Add2(object sender, ItemClickEventArgs e)
        {            
            state = MenuState.Insert;            
            this.Enabled = false;            
            F_PO_Lines_Added_Row FRM = new F_PO_Lines_Added_Row();
            FRM.isAction = "Add";
            FRM.ngaynhanmau = this.ngaynhanmau;
            Set4Object_Details();
            FRM.OBJ_POH = this.OBJ_POH;
            FRM.OBJ_POL = this.OBJ_POL;
            FRM.myFinished += this.finished;
            FRM.Show();
        }

        private void ItemClickEventHandler_Save(object sender, ItemClickEventArgs e)
        {
            try
            {
                Set4Object_Header();
                BUS_POH.PO_Header_INSERT(OBJ_POH);
                BUS_POH.Update_SoPO(OBJ_POH.SoPO);
                
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 2000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo ";
                args.Text = "Lưu thành công . Thông báo này sẽ tự đóng sau 1 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();

                //Is_close = true;

                
            }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
            
        }

        private void ItemClickEventHandler_Close(object sender, ItemClickEventArgs e)
        {
            Is_close = true;
            //this.Close();
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Update(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void Set4Controls_Header()
        {     
            txtSoPO.Text                    = OBJ_POH.SoPO;            
            if (isAction                    == "Edit")
            {
                txtID.Text                  = OBJ_POH.ID.ToString();
                txtDiscount.Text            = OBJ_POH.Discount.ToString();
            }          
        }

        public void Set4Controls_Details()
        {
            if (isAction                    == "Edit")
                txtID.Text                  = OBJ_POH.ID.ToString();
            cmbKhoa.Text                    = OBJ_POH.Locked.ToString();
            txtNote.Text                    = OBJ_POH.Note; 
            if (txtSoPO.Text.Substring(0,3) == "H2O")
            {
                lkeNhaCungCap.Text = "";
            }
            else if (txtSoPO.Text.Substring(0, 3) == "GEN" || txtSoPO.Text.Substring(0, 3) == "HTH" || txtSoPO.Text.Substring(0, 3) == "MDW")
            {
                
            }            
            dteNgayLapPO.Text = OBJ_POH.NgayLapPO.ToString().Substring(0, 10);            
        }

        public void Set4Object_Header()
        {
            //KHMAUOBJ.KHMau = txtKHMau.Text;
            //XtraMessageBox.Show(isAction);
            if( isAction == "Edit")
                OBJ_POH.ID = int.Parse(txtID.Text.ToString()) ;

            OBJ_POH.SoPO= txtSoPO.Text;

            if (dteNgayLapPO.Text.ToString() == null || dteNgayLapPO.Text.Length == 0)
                OBJ_POH.NgayLapPO = DateTime.Parse("2019-01-01");
            else
                OBJ_POH.NgayLapPO = DateTime.Parse(dteNgayLapPO.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

            if (dteNgayGiaoHang.Text.ToString() == null || dteNgayGiaoHang.Text.Length == 0)
                OBJ_POH.NgayGiaoHang = DateTime.Parse("2019-01-01");
            else
                OBJ_POH.NgayGiaoHang = DateTime.Parse(dteNgayGiaoHang.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ_POH.Discount = txtDiscount.Text;
            OBJ_POH.PaymentTerm = "CK/TM";
            OBJ_POH.DiaChiGiaoHang = "Số 24, Đường 26, KCN Sóng Thần 2, Dĩ An, Bình Dương";
            OBJ_POH.CreatedBy = user.Username; 
            OBJ_POH.Note = txtNote.Text ; OBJ_POH.Locked = cmbKhoa.Text.ToString() == "True" ? true : false;
        }

        public void Set4Object_Details()
        {            
            if (isAction == "Edit" && gridView1.DataRowCount > 0)
            {
                OBJ_POL.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                OBJ_POL.MaCTXN = gridView1.GetFocusedRowCellValue("MaCTXN").ToString();               
            }
            

            OBJ_POH.CreatedBy = user.Username;
            
            OBJ_POH.Locked = cmbKhoa.Text.ToString() == "True" ? true : false;
            OBJ_POH.Note = txtNote.Text;
            
            OBJ_POH.Note                   = txtNote.Text;
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
            this.Enabled = true;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();
            this.Visible = true;
            GridColumn colCounter = gridView1.Columns.AddVisible("STT");
            colCounter.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            colCounter.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            colCounter.VisibleIndex = 0;

            this.tbl_PO_Lines_LABTableAdapter.FillBy(sYNC_NUTRICIELDataSet.tbl_PO_Lines_LAB, txtSoPO.Text);

            gridView1.BestFitColumns();
        }
        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.V_VENDOR' table. You can move, or remove it, as needed.
            this.v_VENDORTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.V_VENDOR);            
        }
    }
    
}
