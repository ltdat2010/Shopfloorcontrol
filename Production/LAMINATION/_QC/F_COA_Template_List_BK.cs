using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Production.Class
{
    public partial class F_COA_Template_List_BK : UC_Base
    {
        COABUS COB                                                          = new COABUS();
        ControlBUS CTrB = new ControlBUS();
        //ChiTieuPhanTichBUS CTPTB                                            = new ChiTieuPhanTichBUS();
        //PhuongPhapThuBUS PPTB                                               = new PhuongPhapThuBUS();
        //QuiCachDongGoiBUS QCDGB                                             = new QuiCachDongGoiBUS();
        //TieuChuanBUS TCB                                                    = new TieuChuanBUS();
        int ln                                                              = 0;
        bool isNew = true;
        public F_COA_Template_List_BK()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    
                                 
                    gridControl1.DataSource = tbl_COATableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA_Template_Header);
                    repositoryItemLookUpEdit1.DataSource = CTrB.Control_List();
                    //repositoryItemLookUpEdit2.DataSource = TCB.TC_List();
                    //repositoryItemLookUpEdit3.DataSource = PPTB.PPT_List();   
                    gridControl2.DataSource = COB.COA_Template(0);
                   
                    gridView1.BestFitColumns();
                    ControlsReadOnly(true);
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView2.OptionsBehavior.Editable = false;
                };
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));
            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
            action1.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete));
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));
            action1.CSV(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_CSV));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            gridView1.RowClick += (s, e) =>
                {
                    txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                    txtCOA.Text = gridView1.GetFocusedRowCellValue("COA").ToString();
                    gridControl2.DataSource = COB.COA_Template(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()));
                };
            gridView2.InitNewRow += (s, e) =>
                {
                    //XtraMessageBox.Show("isNew" + isNew.ToString());
                    //Gán PRNO cho dòng đầu tiên trên grid
                    gridView2.SetRowCellValue(e.RowHandle, "COAID", int.Parse(txtID.Text.ToString()));
                    //if (isNew == false)
                    //    ln = int.Parse(gridView2.GetRowCellValue(gridView2.RowCount - 1, "STT").ToString()) + 1;
                    //else
                    //    //Gán line số 1
                    //    ln = ln + 1;
                    //gridView2.SetRowCellValue(e.RowHandle, "STT", ln);                                                     
                };
            //gridView2.CellValueChanged += (s, e) =>
            //    {
            //    };
            
        }
        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            txtID.Text = COB.COA_Template_Max_COAID().ToString();
            //Controls
            ControlsReadOnly(false);
            gridView2.OptionsBehavior.Editable = true;                    

            //Add new row
            //For fire InitNewRow event
            //gridView2.AddNewRow();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            isNew = false;
            if(txtID.Text.Length > 0)
            {
                //Controls
                ControlsReadOnly(false);
                gridView2.OptionsBehavior.Editable = true;
                
                //Add new row
                //For fire InitNewRow event
                //gridView2.AddNewRow();
            }
            
        }
        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            if (gridView2.DataRowCount > 0)
            {
                //Ko cho thay đổi
                //gridView2.OptionsBehavior.Editable = false;   
                //XtraMessageBox.Show(gridView2.DataRowCount.ToString());
                if(isNew == true)
                    //tbl_COATableAdapter.Insert(int.Parse(txtID.Text),txtCOA.Text);
                
                for (int i = 0; i <= gridView2.DataRowCount-1 ; i++)
                {
                    //XtraMessageBox.Show(gridView2.DataRowCount.ToString());
                    //XtraMessageBox.Show(gridView2.GetRowCellValue(i, "COAID").ToString());
                    //XtraMessageBox.Show(gridView2.GetRowCellValue(i, "ControlID").ToString());
                        if (COB.COA_Template_Visible(int.Parse(gridView2.GetRowCellValue(i, "COAID").ToString()), int.Parse(gridView2.GetRowCellValue(i, "ControlID").ToString())) <= 0)
                        {
                            COB.COA_Template_Insert((gridView2.GetRow(i) as DataRowView).Row);
                        }   
                }                        
                //Sau khi luu
                ResetControl();
                ControlsReadOnly(true);
                gridView2.OptionsBehavior.Editable = false;
            }
            else
                XtraMessageBox.Show("Vui lòng click OK, sau đó nhấn enter");
        }
        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            COB.COA_Template_Delete(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()));
            ResetControl();
            ControlsReadOnly(true);
            gridView2.OptionsBehavior.Editable = false;
        }
        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            //gridControl2.DataSource = PRB.SP_PR_Detail_parms(gridView1.GetFocusedRowCellValue("PRNO").ToString());
            //gridControl2.DataSource = tbl_KQKNTemplateTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_KQKNTemplate);
        }
        private void ItemClickEventHandler_CSV(object sender, EventArgs e)
        {
        }
        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            //R_PR RPR = new R_PR();
            //RPR.PRNO = gridView1.GetFocusedRowCellValue("PRNO").ToString();
            //RPR.Show();
        }

        

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //string ItemCode = (sender as LookUpEdit).EditValue.ToString();
            
            //DataRowView row = repositoryItemLookUpEdit1.GetDataSourceRowByKeyValue(ItemCode) as DataRowView;
            //object OnHand = row["OnHand"];
            //object InvntryUom = row["InvntryUom"];
            //gridView2.SetFocusedRowCellValue("InStock", OnHand);
            //gridView2.SetFocusedRowCellValue("UoM", InvntryUom);
        }        
       
        public void ResetControl()
        {
            
            //grid
            //oITMTableAdapter.Fill(aSIALANDDataSet.OITM);
            gridControl1.DataSource = tbl_COATableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA_Template_Header);
            //this.repositoryItemLookUpEdit1.DataSource = aSIALANDDataSet.OITM;
            //gridView1.BestFitColumns();            
            //Assign or set MAX value for PR
            txtID.Text = "";
            //Assign datatable struct for Gird ------ Is a must ------
            //gridControl2.DataSource = PRB.SP_PR_Detail_parms(null);
            //cmbDept.Text = "";
            //dteRequestDate.Text = DateTime.Today.ToShortDateString();
            //dteDueDate.Text = DateTime.Today.ToShortDateString();
            //txtReason.Text = "";
            //txtApprovedBy.Text = "";
            //dteCheckedDate.Text = DateTime.Today.ToShortDateString();
            //txtCreatedBy.Text = user._UserName;
            //txtCheckedBy.Text = "";
            //dteApprovalDate.Text = DateTime.Today.ToShortDateString();
            //dteCreatedDate.Text = DateTime.Today.ToShortDateString();
            //txtCreatedBy.Text = "";
        }

        public void ControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly                = bl;
            txtCOA.ReadOnly = bl;
            //cmbDept.ReadOnly                = bl;
            //dteRequestDate.ReadOnly         = bl;
            //dteDueDate.ReadOnly             = bl;
            //txtReason.ReadOnly              = bl;
            //txtApprovedBy.ReadOnly          = bl;
            //dteCheckedDate.ReadOnly         = bl;
            //txtCreatedBy.ReadOnly           = bl;
            //txtCheckedBy.ReadOnly           = bl;
            //dteApprovalDate.ReadOnly        = bl;
            //dteCreatedDate.ReadOnly         = bl;
            //txtCreatedBy.ReadOnly           = bl;
            //gridView2.OptionsBehavior.Editable = bl;
        }

        private void chkOtherItem_CheckedChanged(object sender, EventArgs e)
        {
            //if(chkOtherItem.CheckState.Equals(CheckState.Checked) == true)
            //    XtraMessageBox.Show("Checked");
            //else
            //    this.repositoryItemLookUpEdit1.DataSource = aSIALANDDataSet.OITM;

        }

               
    }
}
