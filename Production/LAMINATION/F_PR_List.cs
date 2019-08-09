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
    public partial class F_PR_List : UC_Base
    {
        PRBUS PRB = new PRBUS();
        int ln = 0;
        public F_PR_List()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    oITMTableAdapter.Fill(aSIALANDDataSet.OITM);                    
                    gridControl1.DataSource = tbl_PRTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PR);                    
                    //this.repositoryItemLookUpEdit1.DataSource = aSIALANDDataSet.OITM;
                    gridView1.BestFitColumns();
                    ControlsReadOnly(true);
                    gridView2.OptionsBehavior.Editable = false;
                };
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));
            action1.CSV(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_CSV));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            gridView1.RowClick += (s, e) =>
                {
                    gridControl2.DataSource = PRB.SP_PR_Detail_parms(gridView1.GetFocusedRowCellValue("PRNO").ToString());
                };
            gridView2.InitNewRow += (s, e) =>
                {                    
                    //Gán PRNO cho dòng đầu tiên trên grid
                    gridView2.SetRowCellValue(e.RowHandle, "PRNO", txtPRNO.Text);
                    //MessageBox.Show("gridView2.GetRowCellValue : " + gridView2.GetRowCellValue(e.RowHandle, "PRNO").ToString());
                    //Gán line số 1
                    ln = ln + 1;
                    gridView2.SetRowCellValue(e.RowHandle, "Line", ln.ToString());
                    //MessageBox.Show("ln : " + ln.ToString());
                    //MessageBox.Show("gridView2.GetRowCellValue : " + gridView2.GetRowCellValue(e.RowHandle, "Line").ToString());
                    
                             
                };
            gridView2.CellValueChanged += (s, e) =>
                {
                    if (e.Column.Caption == "ItemCode")
                    {
                        //MessageBox.Show("AAAA");
                        e.Column.BestFit();                        
                        //(s as GridView).BestFitColumns();
                        //MessageBox.Show("BBBB");
                    }

                    //GridView view = sender as GridView;
                    //if (view == null) return;
                    //if (e.Column.Caption != "FirstName") return;
                    //string cellValue = e.Value.ToString() + " " + view.GetRowCellValue(e.RowHandle, view.Columns["LastName"]).ToString();
                    //view.SetRowCellValue(e.RowHandle, view.Columns["FullName"], cellValue);
                };
            simpleButton1.Click += (s, e) =>
                {
                    ItemClickEventHandler_Save(s,e);
                };
        }
        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            //COntrols
            ControlsReadOnly(false);
            gridView2.OptionsBehavior.Editable = true;

            //Assign or set MAX value for PR
            txtPRNO.Text                = PRB.SP_MAX_PRNO().Rows[0]["PRNO"].ToString();
            //Assign datatable struct for Gird ------ Is a must ------
            gridControl2.DataSource     = PRB.SP_PR_Detail_parms(null);              
            cmbDept.Text                = "";
            dteRequestDate.Text         = DateTime.Today.ToShortDateString();
            dteDueDate.Text             = DateTime.Today.ToShortDateString();
            txtReason.Text              = "";
            txtApprovedBy.Text          = "";
            dteCheckedDate.Text         = DateTime.Today.ToShortDateString();
            txtCreatedBy.Text           = user.Username;
            txtCheckedBy.Text           = "";
            dteApprovalDate.Text        = DateTime.Today.ToShortDateString();
            dteCreatedDate.Text         = DateTime.Today.ToShortDateString();
            txtCreatedBy.Text           = "";

            //Add new row
            //For fire InitNewRow event
            gridView2.AddNewRow();
        }
        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            //MessageBox.Show("txtPRNO : " + txtPRNO.Text.ToString());
            //MessageBox.Show("txtPRNO solved:" + txtPRNO.Text.ToString("yyyy-mm-dd") ;
            PRB.PR_INSERT(
                txtPRNO.Text.ToString()
                , cmbDept.Text.ToString()
                , DateTime.Parse(dteRequestDate.Text.ToString())
                , DateTime.Parse(dteDueDate.Text.ToString())
                , txtReason.Text.ToString()
                , txtCreatedBy.Text.ToString()
                , DateTime.Parse(dteCreatedDate.Text.ToString())
                , txtCheckedBy.Text.ToString()
                , DateTime.Parse(dteCheckedDate.Text.ToString())
                , txtApprovedBy.Text.ToString()
                , DateTime.Parse(dteApprovalDate.Text.ToString())
                );
            for ( int i = 0; i <= gridView2.DataRowCount-1; i ++)
            {
                DataRow row = (gridView2.GetRow(i) as DataRowView).Row;
                PRB.PR_Detail_INSERT(row);
            }

            XtraMessageBox.Show("Lưu PR số :" + txtPRNO.Text.ToString() + " thành công ");
            ResetControl();
            ControlsReadOnly(true);
            gridView2.OptionsBehavior.Editable = false;
        }
        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            //gridControl2.DataSource = PRB.SP_PR_Detail_parms(gridView1.GetFocusedRowCellValue("PRNO").ToString());
            gridControl2.DataSource = tbl_PR_DetailTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PR_Detail);
        }
        private void ItemClickEventHandler_CSV(object sender, EventArgs e)
        {
        }
        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            R_PR RPR = new R_PR();
            RPR.PRNO = gridView1.GetFocusedRowCellValue("PRNO").ToString();
            RPR.Show();
        }

        private void repositoryItemLookUpEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //gridView2.SetFocusedRowCellValue("InStock", repositoryItemLookUpEdit1.GetDataSourceValue("OnHand", repositoryItemLookUpEdit1.GetDataSourceRowIndex().ToString()); 
            //DataRowView row = repositoryItemLookUpEdit1.GetDataSourceRowByDisplayValue(repositoryItemLookUpEdit1.DisplayMember) as DataRowView;
            //object OnHand = row["OnHand"];
            //gridView2.SetFocusedRowCellValue("InStock", OnHand);
        }

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string ItemCode = (sender as LookUpEdit).EditValue.ToString();
            
            DataRowView row = repositoryItemLookUpEdit1.GetDataSourceRowByKeyValue(ItemCode) as DataRowView;
            object OnHand = row["OnHand"];
            object InvntryUom = row["InvntryUom"];
            gridView2.SetFocusedRowCellValue("InStock", OnHand);
            gridView2.SetFocusedRowCellValue("UoM", InvntryUom);
        }        
       
        public void ResetControl()
        {
            
            //grid
            oITMTableAdapter.Fill(aSIALANDDataSet.OITM);
            gridControl1.DataSource = tbl_PRTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PR);
            //this.repositoryItemLookUpEdit1.DataSource = aSIALANDDataSet.OITM;
            //gridView1.BestFitColumns();            
            //Assign or set MAX value for PR
            txtPRNO.Text = "";
            //Assign datatable struct for Gird ------ Is a must ------
            //gridControl2.DataSource = PRB.SP_PR_Detail_parms(null);
            cmbDept.Text = "";
            dteRequestDate.Text = DateTime.Today.ToShortDateString();
            dteDueDate.Text = DateTime.Today.ToShortDateString();
            txtReason.Text = "";
            txtApprovedBy.Text = "";
            dteCheckedDate.Text = DateTime.Today.ToShortDateString();
            txtCreatedBy.Text = user.Username;
            txtCheckedBy.Text = "";
            dteApprovalDate.Text = DateTime.Today.ToShortDateString();
            dteCreatedDate.Text = DateTime.Today.ToShortDateString();
            txtCreatedBy.Text = "";
        }

        public void ControlsReadOnly(bool bl)
        {
            txtPRNO.ReadOnly                = bl;
            cmbDept.ReadOnly                = bl;
            dteRequestDate.ReadOnly         = bl;
            dteDueDate.ReadOnly             = bl;
            txtReason.ReadOnly              = bl;
            txtApprovedBy.ReadOnly          = bl;
            dteCheckedDate.ReadOnly         = bl;
            txtCreatedBy.ReadOnly           = bl;
            txtCheckedBy.ReadOnly           = bl;
            dteApprovalDate.ReadOnly        = bl;
            dteCreatedDate.ReadOnly         = bl;
            txtCreatedBy.ReadOnly           = bl;
            //gridView2.OptionsBehavior.Editable = bl;
        }

        private void chkOtherItem_CheckedChanged(object sender, EventArgs e)
        {
            if(chkOtherItem.CheckState.Equals(CheckState.Checked) == true)
                XtraMessageBox.Show("Checked");
            else
                this.repositoryItemLookUpEdit1.DataSource = aSIALANDDataSet.OITM;

        }

               
    }
}
