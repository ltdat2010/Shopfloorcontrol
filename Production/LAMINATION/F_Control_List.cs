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
    public partial class F_Control_List : UC_Base
    {
        public bool isNew = false;
        ControlBUS CTB = new ControlBUS();
        int ln = 0;
        public F_Control_List()
        {                   
            InitializeComponent();
            Load += (s, e) =>
                {
                    ControlsReadOnly(true);                                        
                    gridControl1.DataSource = CTB.Control_List();
                };
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
            action1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));
            gridControl1.Click += (s, e) =>
                {
                    txtID.Text = gridView1.GetFocusedRowCellValue("ControlID").ToString();
                    txtControl.Text = gridView1.GetFocusedRowCellValue("Control").ToString();
                    txtControlVN.Text = gridView1.GetFocusedRowCellValue("ControlVN").ToString();
                    cmbChar.SelectedText = gridView1.GetFocusedRowCellValue("Characteristic").ToString();
                };
        }
        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isNew = true;
            ////COntrols
            ControlsReadOnly(false);
            ResetControl();            
            
        }
        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            isNew = false;
            ////COntrols
            ControlsReadOnly(false);            
        }
        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            //if (isNew == true && CTB.Control_Visible(txtControl.Text.ToString()) <= 0)
            //    tbl_ControlTableAdapter.Insert(txtControl.Text.ToString(), txtControlVN.Text.ToString(), cmbChar.SelectedText.ToString());                
            //else
            //{
            //    DataTable dt = new SYNC_NUTRICIELDataSet.tbl_ControlDataTable();
            //    DataRow dr = dt.NewRow();
            //    dr.SetField("ID", int.Parse(txtID.Text.ToString()));
            //    dr.SetField("Control", txtControl.Text.ToString());
            //    dr.SetField("ControlVN", txtControlVN.Text.ToString());
            //    dr.SetField("Characteristic", cmbChar.Text.ToString());                
            //    CTB.Control_Update(dr);              
            //}            
            //gridControl1.DataSource = tbl_ControlTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_Control);
            gridControl1.DataSource = CTB.Control_List();
            ResetControl();
            ControlsReadOnly(true);
        }    

        public void ResetControl()
        {
            txtID.Text = "";
            txtControl.Text = "";
            txtControlVN.Text = "";
            cmbChar.Text = "";
        }

        public void ControlsReadOnly(bool bl)
        {
            txtControl.ReadOnly = bl;
            txtControlVN.ReadOnly = bl;
            cmbChar.ReadOnly = bl;
        }     
                      
    }
}
