using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Text;
using Production.Class;
using System.IO;
using System.Data;
using System.Security.Principal;
using DevExpress.XtraGrid.Columns;
using System.Globalization;

namespace Production.Class
{
    public class RECEIPTBUS
    {
        public static RECEIPT RC = new RECEIPT();
        public static RECEIPTDAO RCD = new RECEIPTDAO();
        
        public static bool Checkbool(String x)
        {
            
            return bool.Parse(x.Length > 0 ? x : "False");
        }

        public static DateTime? CheckEmtdE(DateEdit x)
        {
            return (string.IsNullOrEmpty(x.Text) ? (DateTime?)null : DateTime.Parse(x.Text));
        }

        public DataTable F_RECEIPT_List()
        {
            return RCD.RECEIPT_List();
        }
        public void F_RECEIPT_Detail(GridControl gc1, string ECHRECEPS)
        {
            gc1.DataSource = RCD.RECEIPT_Detail(ECHRECEPS);
        }

        public DataTable RECEIPT_Detail_Reload(string ECH_RECEPS)
        {
            return RCD.RECEIPT_Detail_Reload(ECH_RECEPS);
        }

        public DataTable RECEIPT_Lot(string ECH_RECEPS)
        {
            return RCD.RECEIPT_Lot(ECH_RECEPS);
        }
        public DataTable RECEIPT_ExpDate_ItemName(string ECH_RECEPS, string NO_LOT)
        {
            return RCD.RECEIPT_ExpDate_ItemName(ECH_RECEPS, NO_LOT);
        }
        public DataTable F_RECEIPT_Find(string ECH_RECEPS)
        {
            return RCD.RECEIPT_Find(ECH_RECEPS);
        }

        public void F_RECEIPT_DetailsCSV(GridView gridview1)
        {
            
            CreateCSVFile(GridView2DataTable(gridview1), @"D:\\Eresis\\EXCHANGES\\IN\\RECEIPT.csv");
        }

        public void RECEIPT_INSERT(GridView gv1)
        {            
                RCD.OF_INSERT(gv1.GetDataRow(0));           

        }

        //public void RECEIPT_Detail_INSERT(GridView gv1)
        //{
        //    for (int i = 0; i <= gv1.DataRowCount - 1; i++)
        //    {
        //        XtraMessageBox.Show(gv1.GetRowCellValue(i,"XHL").ToString());
        //        RCD.OF_Detail_INSERT(gv1.GetDataRow(i));
        //    }

        //}
        public void RECEIPT_Detail_INSERT(DataTable dt)
        {         
            foreach(DataRow dr in dt.Rows)
                RCD.OF_Detail_INSERT(dr);
        }
        public int MAX_XHL(string ECH_RECEPS)
        {
            return RCD.MAX_XHL(ECH_RECEPS);
        }
        public void OF_Detail_DELETE(string ECH_RECEPS)
        {
            RCD.OF_Detail_DELETE(ECH_RECEPS);
        }

        public void OF_DELETE(string ECH_RECEPS)
        {
            RCD.OF_DELETE(ECH_RECEPS);
        }
        public void CreateCSVFile(DataTable dt, string strFilePath)
        {

            #region Export Grid to CSV
            //AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            //WindowsIdentity idnt = new WindowsIdentity("Administrator", "eresis44$");
            //WindowsImpersonationContext context = idnt.Impersonate();
            // Create the CSV file to which grid data will be exported.
            StreamWriter sw = new StreamWriter(strFilePath, false);

            // First we will write the headers.

            //DataTable dt = m_dsProducts.Tables[0];

            int iColCount = dt.Columns.Count-1;

            for (int i = 0; i < iColCount; i++)
            {

                //sw.Write(dt.Columns[i]);
                sw.Write('"' + dt.Columns[i].ToString() + '"');

                if (i <= iColCount - 1)
                {
                    sw.Write(";");

                }

            }

            sw.Write(sw.NewLine);

            // Now write all the rows.
            //foreach (DataRow dr in dt.Rows)
            int tmp_line = 0;

            for (int j = 0; j <= dt.Rows.Count - 1; j++)
            {
                //XtraMessageBox.Show("Số XHL : " + XHL.ToString());
                //if (dt.Rows[j]["XHL"].ToString() == XHL.ToString())
                //{                    
                    //if(tmp_line == 0 )
                    //{
                        //if (int.Parse(dt.Rows[j]["ECH_RECEP"].ToString()) != 1000)
                        //{
                            //tmp_line = 1000;
                            //dt.Rows[j]["ECH_RECEP"] = tmp_line;
                        //}
                        //else
                            //tmp_line = int.Parse(dt.Rows[j]["ECH_RECEP"].ToString());                        
                    //}
                    //else
                    //{
                        //tmp_line = tmp_line + 1000;
                        //dt.Rows[j]["ECH_RECEP"] = tmp_line;
                    //}

                    //XtraMessageBox.Show("Số XHL của cột : " + dt.Rows[j]["XHL"].ToString());
                    //if (j <= dt.Rows.Count - 1)
                    //{
                    for (int i = 0; i < iColCount ; i++)
                    {
                        
                        if (i == 0)
                        {
                            
                            if (!Convert.IsDBNull(dt.Rows[j][i]))
                            {
                                sw.Write('"' + dt.Rows[j][i].ToString() + '"');
                                
                            }
                        }
                        else if (i == 1 || i == 6)
                        {
                            if (!Convert.IsDBNull(dt.Rows[j][i]))
                            {
                                sw.Write(dt.Rows[j][i].ToString());
                            }
                        }
                        else
                        {
                            if (!Convert.IsDBNull(dt.Rows[j][i]))
                            {
                                sw.Write('"' + dt.Rows[j][i].ToString() + '"');
                            }
                        }
                        if (i < iColCount)
                        {
                            sw.Write(";");
                        }
                    }

                    //}
                    //Move len day
                    sw.Write(sw.NewLine);
                //}
                    //Move len tren do gay ra loi line bi trong
                    //sw.Write(sw.NewLine);
                    //test doi len day
                    //sw.Close();

                //}
                //An dong duoi de test
                //sw.Close();

             }
            //tmp_line = 0;
            sw.Close();    
        } 

        #endregion


        //public static void Select_All(GridControl gc1, DataNavigator dn)
        //{
        //    cyn_.CM_Select_All(gc1, dn);
        //}

       
        public static void SetRow4Ob(OF ofv, GridView gridView1)
        {
            //of.CD_OF            =   gridView1.GetFocusedRowCellValue("CD_OF").ToString();
            //of.FG_STATUS        =   gridView1.GetFocusedRowCellValue("FG_STATUS").ToString();
            //of.DT_PREV          =   gridView1.GetFocusedRowCellValue("DT_PREV").ToString();
            //of.CD_DEPOT         =   gridView1.GetFocusedRowCellValue("CD_DEPOT").ToString();
            //of.CD_MAT           =   gridView1.GetFocusedRowCellValue("CD_MAT").ToString();
            //of.LB_MAT           =   gridView1.GetFocusedRowCellValue("LB_MAT").ToString();
            //of.QT_PREV          =   float.Parse(gridView1.GetFocusedRowCellValue("QT_PREV").ToString());
            //of.CD_UNIT          =   gridView1.GetFocusedRowCellValue("CD_UNIT").ToString();
            //of.NO_ORDRE         =   gridView1.GetFocusedRowCellValue("NO_ORDRE").ToString();
            //of.CD_MAT1          =   gridView1.GetFocusedRowCellValue("CD_MAT1").ToString();
            //of.QT_DOSE          =   float.Parse(gridView1.GetFocusedRowCellValue("QT_DOSE").ToString());
            //of.CD_VER           =   gridView1.GetFocusedRowCellValue("CD_VER").ToString();
            /*
            cyn.ID_                     = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            cyn.IDCM_                   = int.Parse(gridView1.GetFocusedRowCellValue("IDCM").ToString());
            cyn.ArtworkCode_            = gridView1.GetFocusedRowCellValue("ArtworkCode").ToString();
            cyn.FGCode_                 = gridView1.GetFocusedRowCellValue("FGCode").ToString();
            cyn.FGName_                 = gridView1.GetFocusedRowCellValue("FGName").ToString();
            cyn.CMID_                   = gridView1.GetFocusedRowCellValue("CMID").ToString();
            cyn.CynReadyforPlating_     = (DateTime?)(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("CynReadyforPlating").ToString()) ? null : gridView1.GetFocusedRowCellValue("CynReadyforPlating"));
            cyn.PlatingDate_            = (DateTime?)(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("PlatingDate").ToString()) ? null : gridView1.GetFocusedRowCellValue("PlatingDate"));
            cyn.CynReadyforEngraving_   = (DateTime?)(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("CynReadyforEngraving").ToString()) ? null : gridView1.GetFocusedRowCellValue("CynReadyforEngraving"));
            cyn.EngravingDate_          = (DateTime?)(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("EngravingDate").ToString()) ? null : gridView1.GetFocusedRowCellValue("EngravingDate"));
            cyn.CynReadyforProofing_    = (DateTime?)(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("CynReadyforProofing").ToString()) ? null : gridView1.GetFocusedRowCellValue("CynReadyforProofing"));
            cyn.ProofingDate_           = (DateTime?)(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("ProofingDate").ToString()) ? null : gridView1.GetFocusedRowCellValue("ProofingDate"));
            cyn.CynReadyforPrinting_    = (DateTime?)(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("CynReadyforPrinting").ToString()) ? null : gridView1.GetFocusedRowCellValue("CynReadyforPrinting"));
            cyn.UserIDCM_               = int.Parse(gridView1.GetFocusedRowCellValue("UserIDCM").ToString().Length > 0 ? gridView1.GetFocusedRowCellValue("UserIDCM").ToString() : "0");
            cyn.UserInputDateCM_        = (DateTime?)(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("UserInputDateCM").ToString()) ? null : gridView1.GetFocusedRowCellValue("UserInputDateCM"));
            cyn.SOCStatus_              = CM_bus.Checkbool(gridView1.GetFocusedRowCellValue("SOCStatus").ToString());
            cyn.RawmaterialStatus_      = CM_bus.Checkbool(gridView1.GetFocusedRowCellValue("RawmaterialStatus").ToString());
            cyn.ReceivedDocfromGA_      = (DateTime?)(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("ReceivedDocfromGA").ToString()) ? null : gridView1.GetFocusedRowCellValue("ReceivedDocfromGA"));
            cyn.NoteCM_                 = gridView1.GetFocusedRowCellValue("NoteCM").ToString();
            cyn.OverQuantity_           = CM_bus.Checkbool(gridView1.GetFocusedRowCellValue("OverQuantity").ToString());
        
             */
        }

        public DataTable GridView2DataTable(GridView gridView1)
        {
            DataTable dt = new DataTable();
            foreach (GridColumn column in gridView1.VisibleColumns)
            {
                dt.Columns.Add(column.FieldName, column.ColumnType);
            }
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                DataRow row = dt.NewRow();
                foreach (GridColumn column in gridView1.VisibleColumns)
                {
                    row[column.FieldName] = gridView1.GetRowCellValue(i, column);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}
