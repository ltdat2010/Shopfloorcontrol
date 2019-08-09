using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using System.Drawing;

namespace Production.Class
{
    public partial class F_Tracerbility : UC_Base
    {
        OF of = new OF();
        OFBUS OFB = new OFBUS();
        COABUS COB = new COABUS();
        CSVFromToDataTable CSV = new CSVFromToDataTable();
        RMUSEDBUS RMB = new RMUSEDBUS();

        //Luu du lieu edit vao list
        //class UserVal
        //{
        //    public UserVal(string col, int row, float value)
        //    {
        //        this.Col = col;
        //        this.Row = row;
        //        this.Value = value;

        //    }
        //    public string Col;
        //    public int Row;
        //    public float Value;
        //}

        //List<OF> OFList = new List<OF>();

        public F_Tracerbility()
        {           
            InitializeComponent();
            
            Load += (s, e) =>
            {
                tbl_OF_FinishedTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_OF_Finished);
                //gridControl1.DataSource = tbl_OF_FinishedTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_OF_Finished);
                ControlsReadOnly(true);
            };



            //action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));
            //action1.CSV(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_CSV));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));


            lkeCD_OF.EditValueChanged += (s, e) =>
            {
                if (lkeCD_OF.EditValue.ToString().Length > 0)
                {
                    gridControl3.DataSource = OFB.OF_ListBatch(lkeCD_OF.EditValue.ToString());
                    gridView3.BestFitColumns();

                    gridControl4.DataSource = COB.COA_Search_ByWO(lkeCD_OF.EditValue.ToString());
                    gridView4.BestFitColumns();

                    txtFGName.Text = lkeCD_OF.GetColumnValue("LB_MAT").ToString();
                    txtFGCode.Text = lkeCD_OF.GetColumnValue("CD_MAT").ToString();
                    txtFnhDte.Text = lkeCD_OF.GetColumnValue("DT_FIN").ToString();
                    txtMnfQty.Text = lkeCD_OF.GetColumnValue("QT_MVMT").ToString();
                    txtPlnQty.Text = lkeCD_OF.GetColumnValue("QT_PREV").ToString();
                    txtStdDte.Text = lkeCD_OF.GetColumnValue("DT_DEB").ToString();
                }

            };

            repositoryItemButtonEdit1.ButtonClick += (s, e) =>
            {
                if(e.Button.Caption == "PNK Number")
                {
                    if (gridView3.GetFocusedRowCellValue("SoPKN").ToString().Length > 0)
                    {
                        frm_PKN PKN = new frm_PKN();
                        PKN.ActStatus = "V";
                        PKN.SoPKN = gridView3.GetFocusedRowCellValue("SoPKN").ToString();
                        PKN.SoLo = gridView3.GetFocusedRowCellValue("NO_LOTORG").ToString();
                        PKN.Lan = 1;
                        PKN.Show();
                    }
                    else
                        XtraMessageBox.Show("Your PKN is blank. Please contact QA for more information");
                }
                
            };

            repositoryItemButtonEdit2.ButtonClick += (s, e) =>
            {
                if (e.Button.Caption == "COA Number")
                {
                    if (gridView4.GetFocusedRowCellValue("SoCOA").ToString().Length > 0)
                    {
                        frm_COA COA = new frm_COA();
                        COA.SoCOA = gridView4.GetFocusedRowCellValue("SoCOA").ToString();
                        COA.ActStatus = "V";
                        COA.CD_OF = gridView4.GetFocusedRowCellValue("WO").ToString();
                        COA.Show();
                    }
                    else
                        XtraMessageBox.Show("Your COA is blank. Please contact QA for more information");
                }
                    
            };



            //gridView4.RowClick += (s, e) =>
            //{

            //    frm_COA COA = new frm_COA();
            //    COA.SoCOA = gridView4.GetFocusedRowCellValue("SoCOA").ToString();
            //    COA.ActStatus = "V";
            //    COA.CD_OF = gridView4.GetFocusedRowCellValue("WO").ToString();                
            //    COA.Show();
            //};

            gridView3.CustomDrawEmptyForeground += (s, e) =>
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = s as DevExpress.XtraGrid.Views.Grid.GridView;

                if (view.RowCount != 0) return;

                StringFormat drawFormat = new StringFormat();

                drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(" No Analysis Report founded ", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);

            };

            gridView4.CustomDrawEmptyForeground += (s, e) =>
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = s as DevExpress.XtraGrid.Views.Grid.GridView;

                if (view.RowCount != 0) return;

                StringFormat drawFormat = new StringFormat();

                drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(" No Analysis Report founded ", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);

            };
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
                     
        }

        private void ItemClickEventHandler_CSV(object sender, EventArgs e)
        {
            
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            if(lkeCD_OF.EditValue.ToString() != "[Please click and select Production Order]")
            {
                try
                {
                    R_OF_Tracebility RTR = new R_OF_Tracebility();
                    RTR.OF = lkeCD_OF.EditValue.ToString();
                    RTR.Show();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                                  
            }            
        }

        private void ItemClickEventHandler_PKN(object sender, EventArgs e)
        {    
            
        }

        private void ItemClickEventHandler_COA(object sender, EventArgs e)
        {
            
        }
        private void ItemClickEventHandler_TRACE(object sender, EventArgs e)
        {
            
        }

        private void ControlsReadOnly(bool bl)
        {
            //lkeCD_OF.ReadOnly = bl;
            txtFGName.ReadOnly = bl;
            txtFGCode.ReadOnly = bl;
            txtFnhDte.ReadOnly = bl;
            txtMnfQty.ReadOnly = bl;
            txtPlnQty.ReadOnly = bl;
            txtStdDte.ReadOnly = bl;
        }

        //private void gridView2_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        //{
        //    PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
        //    pb.PageSettings.Landscape = true;
        //    pb.PageSettings.LeftMargin = 5;
        //    pb.PageSettings.RightMargin = 0;
        //    pb.PageSettings.BottomMargin = 0;
        //    pb.PageSettings.TopMargin = 5;
        //}  
    }
}