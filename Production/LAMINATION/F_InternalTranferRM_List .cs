using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Resources;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Threading;
using Production.LAN;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using Production.Class;
using DevExpress.XtraPrinting;


namespace Production.Class
{
    public partial class F_InternalTranferRM_List : UC_Base
    {

        string Path = Directory.GetCurrentDirectory();
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        DataTable dt_InternalTransfer_Header,
                  dt_InternalTransfer_Detail = new DataTable();

        ASIALANDDataSetTableAdapters.Internal_Transfer_DetailTableAdapter internal_Transfer_DetailTableAdapter = new ASIALANDDataSetTableAdapters.Internal_Transfer_DetailTableAdapter(); 

        public F_InternalTranferRM_List()
        {           
            InitializeComponent();
            
            Load += (s, e) =>
            {
                warehouseTableAdapter.Fill(aSIALANDDataSet.Warehouse);               
                
            };            
            //};
            
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));
            action1.CSV(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_CSV));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            lkEWarehouse.EditValueChanged += (s, e) =>
            {
                gridControl4.DataSource = internal_TransferTableAdapter.Fill(aSIALANDDataSet.Internal_Transfer,lkEWarehouse.EditValue.ToString());
            };
            gridView4.DoubleClick += (s, e) =>
            {
                //Luu lai truoc khi xuat report
                ////Kiem tra co OF nay chua

                //////Chua co thi luu moi

                //////Co roi thi khong luu nua
                dt_InternalTransfer_Header = internal_TransferTableAdapter.GetDataBy(int.Parse(gridView4.GetFocusedRowCellValue("DocNum").ToString()));
                dt_InternalTransfer_Detail = internal_Transfer_DetailTableAdapter.GetDataBy(int.Parse(gridView4.GetFocusedRowCellValue("DocNum").ToString()));

                //
                //if (dt_InternalTransfer_Header.Rows.Count > 0)
                //{
                dt_InternalTransfer_Header.WriteXml(Path + "/Xml/dt_InternalTransfer_Header.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_InternalTransfer_Detail.WriteXml(Path + "/Xml/dt_InternalTransfer_Details.xml", System.Data.XmlWriteMode.IgnoreSchema);
                //}
                rpt.Load(Path + "/RPT/Rpt_InternalTransfer.rpt");
                crvReport.ReportSource = rpt;

            };

            

            gridView4.CustomDrawEmptyForeground += (s, e) =>
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = s as DevExpress.XtraGrid.Views.Grid.GridView;

                if (view.RowCount != 0) return;

                StringFormat drawFormat = new StringFormat();

                drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString("Vui lòng chọn WO bên trên ", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);

            };
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            //MessageBox.Show("click");            
        }

        private void ItemClickEventHandler_CSV(object sender, EventArgs e)
        {
            
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            
        }

        private void ItemClickEventHandler_PKN(object sender, EventArgs e)
        {
            //MessageBox.Show("click");     
            
        }

        private void ItemClickEventHandler_COA(object sender, EventArgs e)
        {
            
        }
        private void ItemClickEventHandler_TRACE(object sender, EventArgs e)
        {
            
        }        
        
        
        
    }
}