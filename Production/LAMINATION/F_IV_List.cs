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
    public partial class F_IV_List : UC_Base
    {
        ItemBUS ITB = new ItemBUS();        
        public F_IV_List()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    gridControl1.DataSource = sP_tbl_ItemTableAdapter.Fill(sYNC_NUTRICIELDataSet.SP_tbl_Item);
                    gridControl2.DataSource = sP_OITM_tbl_ItemTableAdapter.Fill(sYNC_NUTRICIELDataSet.SP_OITM_tbl_Item);
                    //gridView2.OptionsBehavior.Editable = false;                    
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.BestFitColumns();
                    gridView2.BestFitColumns();
                };
            action1.Forward(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Forward));
            action1.Preverse(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Preverse));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            gridView1.RowClick += (s, e) =>
                {                    
                };
            gridView2.InitNewRow += (s, e) =>
                {                    
                    ////Gán PRNO cho dòng đầu tiên trên grid
                    //gridView2.SetRowCellValue(e.RowHandle, "PRNO", txtPRNO.Text);
                    ////MessageBox.Show("gridView2.GetRowCellValue : " + gridView2.GetRowCellValue(e.RowHandle, "PRNO").ToString());
                    ////Gán line số 1
                    //ln = ln + 1;
                    //gridView2.SetRowCellValue(e.RowHandle, "Line", ln.ToString());
                    ////MessageBox.Show("ln : " + ln.ToString());
                    ////MessageBox.Show("gridView2.GetRowCellValue : " + gridView2.GetRowCellValue(e.RowHandle, "Line").ToString());
                    
                             
                };
            gridView2.CellValueChanged += (s, e) =>
                {
                    //if (e.Column.Caption == "ItemCode")
                    //{
                    //    //MessageBox.Show("AAAA");
                    //    e.Column.BestFit();                        
                    //    //(s as GridView).BestFitColumns();
                    //    //MessageBox.Show("BBBB");
                    //}

                    ////GridView view = sender as GridView;
                    ////if (view == null) return;
                    ////if (e.Column.Caption != "FirstName") return;
                    ////string cellValue = e.Value.ToString() + " " + view.GetRowCellValue(e.RowHandle, view.Columns["LastName"]).ToString();
                    ////view.SetRowCellValue(e.RowHandle, view.Columns["FullName"], cellValue);
                };
            BtnAdd.Click += (s, e) =>
                {
                    ITB.Item_INSERT(gridView2.GetFocusedRowCellValue("ItemCode").ToString(),
                        gridView2.GetFocusedRowCellValue("ItemName").ToString(),
                        gridView2.GetFocusedRowCellValue("FrgnName").ToString(),
                        gridView2.GetFocusedRowCellValue("InvntryUom").ToString(),
                        gridView2.GetFocusedRowCellValue("ItemCode").ToString().Substring(3,5)                 
                        );
                    //InvntryUom
                    //FrgnName
                    //ItemName
                    gridControl1.DataSource = sP_tbl_ItemTableAdapter.Fill(sYNC_NUTRICIELDataSet.SP_tbl_Item);
                    gridControl2.DataSource = sP_OITM_tbl_ItemTableAdapter.Fill(sYNC_NUTRICIELDataSet.SP_OITM_tbl_Item);
                };
            BtnRemove.Click += (s, e) =>
            {
                if(gridView1.DataRowCount > 0 )
                {
                    ITB.Item_DELETE(gridView1.GetFocusedRowCellValue("ItemCode").ToString());

                    gridControl1.DataSource = sP_tbl_ItemTableAdapter.Fill(sYNC_NUTRICIELDataSet.SP_tbl_Item);
                    gridControl2.DataSource = sP_OITM_tbl_ItemTableAdapter.Fill(sYNC_NUTRICIELDataSet.SP_OITM_tbl_Item);
       
                }
            };

            gridView1.CustomDrawEmptyForeground += (s, e) =>
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = s as DevExpress.XtraGrid.Views.Grid.GridView;

                if (view.RowCount != 0) return;

                StringFormat drawFormat = new StringFormat();

                drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString("Vui lòng chọn Item bên trái. Sau đó nhấn nút Add ", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);

            };
            
        }
        private void ItemClickEventHandler_Forward(object sender, EventArgs e)
        {
            
        }

        private void ItemClickEventHandler_Preverse(object sender, EventArgs e)
        {
            
        }
        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            R_Production_Item RPI = new R_Production_Item();
            RPI.Show();
        }
        
        
        

               
    }
}
