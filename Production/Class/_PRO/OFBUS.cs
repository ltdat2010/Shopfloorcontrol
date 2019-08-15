using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.IO;

namespace Production.Class
{
    public class OFBUS
    {
        public static OF of = new OF();
        public static OFDAO OFD = new OFDAO();

        public static bool Checkbool(String x)
        {
            return bool.Parse(x.Length > 0 ? x : "False");
        }

        public static DateTime? CheckEmtdE(DateEdit x)
        {
            return (string.IsNullOrEmpty(x.Text) ? (DateTime?)null : DateTime.Parse(x.Text));
        }

        public void F_OF_List(GridControl gc1)
        {
            gc1.DataSource = OFD.OF_List();
        }

        public DataTable OF_ListBatch(string CD_OF)
        {
            return OFD.OF_ListBatch(CD_OF);
        }

        public void F_OF_Details(GridControl gc1, string CDOF)
        {
            gc1.DataSource = OFD.OF_Details(CDOF);
        }

        public void F_OF_DetailsCSV(string CD_OF)
        {
            CreateCSVFile(OFD.OF_Details(CD_OF), @"D:\\Eresis\\EXCHANGES\\IN\\OF.csv");
        }

        public DataTable F_OF_Find(string CD_OF)
        {
            return OFD.OF_Find(CD_OF);
        }

        public DataTable F_OF_Finished()
        {
            return OFD.OF_Finished();
        }

        public DataTable F_FG_Finished()
        {
            return OFD.FG_Finished();
        }

        public DataTable F_OF_Report(string CD_OF)
        {
            return OFD.OF_Report(CD_OF);
        }

        //Report .rpt
        public DataTable OF_Report_OFHeader(string CD_OF)
        {
            return OFD.OF_Report_OFHeader(CD_OF);
        }

        public void OF_Report_OFHeader_Insert(DataRow dr)
        {
            OFD.OF_Report_OFHeader_Insert(dr);
        }

        public bool OF_Report_OFHeader_Visible(string CD_OF)
        {
            return OFD.OF_Report_OFHeader_Visible(CD_OF);
        }

        //public DataTable OF_Report_OFListBatchs(string CD_OF)
        //{
        //    return OFD.OF_Report_OFListBatchs(CD_OF);
        //}

        public DataTable OF_Report_OFListBatchDetails(string CD_OF)
        {
            return OFD.OF_Report_OFListBatchDetails(CD_OF);
        }

        public DataTable OF_Report_OFSummary(string CD_OF)
        {
            return OFD.OF_Report_OFSummary(CD_OF);
        }

        public void OF_Report_OFListBatchDetails_Insert(string OF, DataRow dr)
        {
            OFD.OF_Report_OFListBatchDetails_Insert(OF, dr);
        }

        public DataTable OF_Report_ByFG(string FG)
        {
            return OFD.OF_Report_ByFG(FG);
        }

        public DataTable OF_Report_ByDate(string startdate, string endate)
        {
            return OFD.OF_Report_ByDate(startdate, endate);
        }

        public void F_OF_Detail_View(GridControl gc1, string CD_OF)
        {
            gc1.DataSource = OFD.OF_Detail_View(CD_OF);
        }

        public void OF_INSERT(GridView gv1)
        {
            OFD.OF_INSERT(gv1.GetDataRow(0));
        }

        public void OF_UPDATE(string CD_OF, float ManufacturedQty, String MINStart, string MAXEnd, string Formula, int TotalBatch)
        {
            OFD.OF_UPDATE(CD_OF, ManufacturedQty, MINStart, MAXEnd, Formula, TotalBatch);
        }

        public void OF_Detail_INSERT(GridView gv1)
        {
            for (int i = 0; i <= gv1.DataRowCount - 1; i++)
            {
                OFD.OF_Detail_INSERT(gv1.GetDataRow(i));
                //MessageBox.Show("OF_Detail_INSERT" + i.ToString());
            }
        }

        public void OF_Resources_INSERT(DataRow dr, int IdSort)
        {
            OFD.OF_Resources_INSERT(dr, IdSort);
        }

        public int MAX_IdSort()
        {
            return OFD.MAX_IdSort();
        }

        public int CD_OF_Visible(string CD_OF)
        {
            return OFD.CD_OF_Visible(CD_OF);
        }

        public int GET_ResourceId(string CD_OF)
        {
            return OFD.GET_ResourceId(CD_OF);
        }

        public void OF_Appointments_INSERT(string DT_DEB, string DT_FIN, int ResourceId, string Description)
        {
            OFD.OF_Appointments_INSERT(DT_DEB, DT_FIN, ResourceId, Description);
        }

        public void CreateCSVFile(DataTable dt, string strFilePath)
        {
            #region Export Grid to CSV

            // Create the CSV file to which grid data will be exported.

            StreamWriter sw = new StreamWriter(strFilePath, false);

            // First we will write the headers.

            //DataTable dt = m_dsProducts.Tables[0];

            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);

                if (i < iColCount - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            // Now write all the rows.
            //foreach (DataRow dr in dt.Rows)

            for (int j = 0; j <= dt.Rows.Count - 1; j++)
            {
                if (j < dt.Rows.Count - 1)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (i == 6 || i == 8 || i == 10 || i == 11)
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
                        if (i < iColCount - 1)
                        {
                            sw.Write(";");
                        }
                    }
                }
                else if (j == dt.Rows.Count - 1)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (i == 6 || i == 8 || i == 10 || i == 11)
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
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        #endregion Export Grid to CSV

        //public static void Select_All(GridControl gc1, DataNavigator dn)
        //{
        //    cyn_.CM_Select_All(gc1, dn);
        //}
        public static void SetRow4Ob(OF ofv, GridView gridView1)
        {
            of.CD_OF = gridView1.GetFocusedRowCellValue("CD_OF").ToString();
            of.FG_STATUS = gridView1.GetFocusedRowCellValue("FG_STATUS").ToString();
            of.DT_PREV = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("DT_PREV").ToString());
            of.CD_DEPOT = gridView1.GetFocusedRowCellValue("CD_DEPOT").ToString();
            of.CD_MAT = gridView1.GetFocusedRowCellValue("CD_MAT").ToString();
            of.LB_MAT = gridView1.GetFocusedRowCellValue("LB_MAT").ToString();
            of.QT_PREV = float.Parse(gridView1.GetFocusedRowCellValue("QT_PREV").ToString());
            of.CD_UNIT = gridView1.GetFocusedRowCellValue("CD_UNIT").ToString();
            of.NO_ORDRE = gridView1.GetFocusedRowCellValue("NO_ORDRE").ToString();
            of.CD_MAT1 = gridView1.GetFocusedRowCellValue("CD_MAT1").ToString();
            of.QT_DOSE = float.Parse(gridView1.GetFocusedRowCellValue("QT_DOSE").ToString());
            of.CD_VER = gridView1.GetFocusedRowCellValue("CD_VER").ToString();
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

        public void OF_Finished_UPDATE(string CD_OF,
            float TOL_QTY_PAK,
            string FUL_PAK_TYPE,
            float FUL_PAK_BAG,
            string LST_PAK_TYPE,
            float LST_PAK_BAG,
            float CONTAMINATION_PAK_BAG,
            string FRM_CD_OF,
            float REMAIN_PREV_CD_OF_QTY
            )
        {
            OFD.OF_Finished_UPDATE(CD_OF,
            TOL_QTY_PAK,
            FUL_PAK_TYPE,
            FUL_PAK_BAG,
            LST_PAK_TYPE,
            LST_PAK_BAG,
            CONTAMINATION_PAK_BAG,
            FRM_CD_OF,
            REMAIN_PREV_CD_OF_QTY);
        }

        public DataTable CD_OF_Finished()
        {
            return OFD.CD_OF_Finished();
        }

        public DataTable OF_Report_OFListBatchDetails_PREP(string CD_OF)
        {
            return OFD.OF_Report_OFListBatchDetails_PREP(CD_OF);
        }

        public DataTable OF_Report_OFSummary_PREP(string CD_OF)
        {
            return OFD.OF_Report_OFSummary_PREP(CD_OF);
        }

        public void OF_REVERT(string CD_OF)
        {
            OFD.OF_REVERT(CD_OF);
        }
    }
}