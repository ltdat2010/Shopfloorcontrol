using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using DevExpress.XtraEditors;

namespace Production.Class
{
    public class OFDAO
    {
        //public DataTable Branch_SelectAll()
        //{            
        //    return Sql.ExecuteDataTable("Branch_SelectAll", CommandType.StoredProcedure);            
        //}

        //public DataTable Branch_GetByID(string BranchID)
        //{
        //    return Sql.ExecuteDataTable("Branch_GetByID", CommandType.StoredProcedure, "BranchID", BranchID);
        //}

        public DataTable OF_List()
        {
            
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP",    "SELECT [ASIALAND].dbo.OWOR.DocNum as CD_OF,"+
                                                "[ASIALAND].dbo.OWOR.ItemCode as CD_MAT,"+
                                                "[ASIALAND].dbo.OITM.ItemName as LB_MAT,"+
                                                "[ASIALAND].dbo.OWOR.PostDate,"+
                                                "[ASIALAND].dbo.OWOR.DueDate as DT_PREV ,"+
                                                "[SYNC_NUTRICIEL].dbo.tbl_OF_Finished.DT_DEB as ProductionStartDate," +
                                                "[SYNC_NUTRICIEL].dbo.tbl_OF_Finished.DT_FIN as ProductionEndDate," +
                                                "[SYNC_NUTRICIEL].dbo.tbl_OF_Finished.QT_LOT as ManufacturedQty " +
                                                "from [ASIALAND].dbo.OWOR "+
                                                "inner join [ASIALAND].dbo.OITM "+
                                                "on [ASIALAND].dbo.OWOR.ItemCode = [ASIALAND].dbo.OITM.ItemCode "+
                                                "LEFT JOIN [SYNC_NUTRICIEL].dbo.tbl_OF_Finished "+
                                                "on [ASIALAND].dbo.OWOR.DocNum = [SYNC_NUTRICIEL].dbo.tbl_OF_Finished.CD_OF " +
                                                "WHERE [SYNC_NUTRICIEL].dbo.tbl_OF_Finished.CD_OF IS NULL " +
                                                "Order by [ASIALAND].dbo.OWOR.DocNum DESC"
                                                , CommandType.Text);
            return dt;
        }

        public DataTable OF_Details(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP",    " SELECT [ASIALAND].dbo.OWOR.DocNum as CD_OF,"+
                                                " FG_STATUS = '1', CONVERT(varchar(10),"+
                                                " [ASIALAND].dbo.OWOR.DueDate,103) as DT_PREV,"+
                                                " CD_DEPOT='891',[ASIALAND].dbo.OWOR.ItemCode as CD_MAT,"+
                                                " [ASIALAND].dbo.OITM.ItemName as LB_MAT,"+
                                                " CAST([ASIALAND].dbo.OWOR.PlannedQty as numeric(18,4)) as QT_PREV, "+
                                                " [ASIALAND].dbo.OITM.InvntryUom as CD_UNIT,NO_ORDRE='1000',"+
                                                " T.CD_MAT1 AS CD_MAT1 ,"+
                                                " CAST(T.QT_DOSE as numeric(18,4)) AS QT_DOSE,"+
                                                " CD_VER ='89' from [ASIALAND].dbo.OWOR "+
                                                " inner join [ASIALAND].dbo.OITM "+
                                                " on [ASIALAND].dbo.OWOR.ItemCode = [ASIALAND].dbo.OITM.ItemCode "+
                                                " inner join (select [ASIALAND].dbo.WOR1.DocEntry,"+
                                                " [ASIALAND].dbo.WOR1.ItemCode as CD_MAT1,"+
                                                " CAST([ASIALAND].dbo.WOR1.PlannedQty as numeric(18,4)) as QT_DOSE, "+
                                                " [ASIALAND].dbo.WOR1.U_NBS_LossRow as LOSS_COMP "+
                                                " from [ASIALAND].dbo.WOR1 "+
                                                " inner join [ASIALAND].dbo.OITM "+
                                                " on [ASIALAND].dbo.WOR1.ItemCode = [ASIALAND].dbo.OITM.ItemCode "+
                                                " where OITM.InvntryUom ='KG' ) as T "+
                                                " on [ASIALAND].dbo.OWOR.DocNum = T.DocEntry "+
                                                " Where [ASIALAND].dbo.OWOR.DocNum = '" + CD_OF + "'"
                                                , CommandType.Text);
                                                return dt;
        }

        public DataTable OF_Find(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "select * "+
                "from [SYNC_NUTRICIEL].dbo.tbl_OF  "+
                "Where [SYNC_NUTRICIEL].dbo.tbl_OF.CD_OF = '" + CD_OF + "'", CommandType.Text);
            return dt;
        }

        public DataTable OF_Detail_View(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "select [ASIALAND].dbo.OWOR.DocNum as CD_OF,"+
                                            "FG_STATUS = '1', "+
                                            "CONVERT(varchar(10),[ASIALAND].dbo.OWOR.DueDate,103) as DT_PREV,"+
                                            "CD_DEPOT='891',[ASIALAND].dbo.OWOR.ItemCode as CD_MAT,"+
                                        "[ASIALAND].dbo.OITM.ItemName as LB_MAT,"+
                                        "CAST([ASIALAND].dbo.OWOR.PlannedQty as numeric(18,4)) as QT_PREV, "+
                                        "[ASIALAND].dbo.OITM.InvntryUom as CD_UNIT,NO_ORDRE='1000',"+
                                        "T.CD_MAT1 AS CD_MAT1 ,"+
                                        "CAST(T.QT_DOSE as numeric(18,4)) AS QT_DOSE,"+
                                        "CAST(T.LOSS_COMP as numeric(18,4)) AS LOSS_COMP,"+
                                        "CD_VER ='89' from [ASIALAND].dbo.OWOR "+
                                        "inner join [ASIALAND].dbo.OITM "+
                                        "on [ASIALAND].dbo.OWOR.ItemCode = [ASIALAND].dbo.OITM.ItemCode "+
                                        "inner join (select [ASIALAND].dbo.WOR1.DocEntry,"+
                                        "[ASIALAND].dbo.WOR1.ItemCode as CD_MAT1,"+
                                        "CAST([ASIALAND].dbo.WOR1.PlannedQty as numeric(18,4)) as QT_DOSE, "+
                                        "[ASIALAND].dbo.WOR1.U_NBS_LossRow as LOSS_COMP "+
                                        "from [ASIALAND].dbo.WOR1 inner join [ASIALAND].dbo.OITM "+
                                        "on [ASIALAND].dbo.WOR1.ItemCode = [ASIALAND].dbo.OITM.ItemCode "+
                                        "where OITM.InvntryUom ='KG' ) as T "+
                                        "on [ASIALAND].dbo.OWOR.DocNum = T.DocEntry "+
                                        "Where [ASIALAND].dbo.OWOR.DocNum = '" + CD_OF + "'", CommandType.Text);
                                        return dt;
        }

        public DataTable OF_Report(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "select * "+
                "from [SYNC_NUTRICIEL].dbo.tbl_OF  "+
                "Where [SYNC_NUTRICIEL].dbo.tbl_OF.CD_OF = '" + CD_OF + "'", CommandType.Text);
            return dt;
        }

        public DataTable OF_Report_OFHeader(string CD_OF)
        {
            //XtraMessageBox.Show("CD_OF : " + CD_OF);
            DataTable dt = new DataTable();
            //dt = Oracle.ExecuteDataTable(
            //                            " SELECT MIN(DT_DEB) as DT_DEB ,MAX(DT_FIN) as DT_FIN,"+
            //                            " CD_MAT,LB_MAT,CD_VER,SUM(QT_LOT) as QT_LOT,"+
            //                            " SUM(QT_FAB) as QT_FAB ,"+
            //                            " CD_DEST,"+
            //                            " CD_OF,COUNT(NB_LOT)as NB_LOT,"+
            //                            " CD_FORM "+
            //                            " FROM HISDOS "+
            //                            " WHERE REPLACE(CD_OF,chr(32),' ')= '"+CD_OF+"'" +
            //                            " GROUP by CD_MAT,LB_MAT,CD_VER,CD_DEST,CD_OF,CD_FORM " +
            //                            " ORDER by CD_MAT,LB_MAT,CD_VER,CD_DEST,CD_OF,CD_FORM "
            //                            , CommandType.Text);
            dt = Oracle.ExecuteDataTable(
            " SELECT   " +
                                        " MIN(hisdos.DT_DEB) as DT_DEB ,  " +
                                        " MAX(hisdos.DT_FIN) as DT_FIN, " +
                                         " hisdos.CD_MAT,hisdos.LB_MAT,  " +
                                         " hisdos.CD_VER,  " +
                                         " SUM(hisdos.QT_LOT) as QT_LOT,  " +
                                         " SUM(hisdos.QT_FAB) as QT_FAB ,  " +
                                         " hisdos.CD_DEST,  " +
                                         " hisdos.CD_OF,COUNT(hisdos.NB_LOT) as NB_LOT,  " +
                                         " hisdos.CD_FORM,  " +
                                         " paramauto.valeur  " +
                                          " FROM hisdos  " +
                                          " JOIN paramauto  " +
                                         " ON hisdos.cd_mat = paramauto.cd_mat   " +
                                         " WHERE REPLACE(CD_OF, chr(32),' ')= '" + CD_OF + "'" +
                                         " AND paramauto.lb_par = 'Mixing time'   " +
                                         " GROUP by hisdos.CD_MAT,hisdos.LB_MAT,hisdos.CD_VER,hisdos.CD_DEST,hisdos.CD_OF,hisdos.CD_FORM,paramauto.valeur   " +
                                         " ORDER by hisdos.CD_MAT,hisdos.LB_MAT,hisdos.CD_VER,hisdos.CD_DEST,hisdos.CD_OF,hisdos.CD_FORM,paramauto.valeur   " 
            , CommandType.Text);
            return dt;
        }

        public bool OF_Report_OFHeader_Visible(string CD_OF)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "select * from [SYNC_NUTRICIEL].dbo.tbl_OF_Finished  Where [SYNC_NUTRICIEL].dbo.tbl_OF_Finished.CD_OF = '" + CD_OF + "'", CommandType.Text);
            return dt.Rows.Count > 0 ? true : false;
        }

        public DataTable CD_OF_Finished()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "select CD_OF,CD_MAT,LB_MAT from [SYNC_NUTRICIEL].dbo.tbl_OF_Finished  ", CommandType.Text);
            return dt;
        }

        public void OF_Report_OFHeader_Insert(DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_OF_Finished] " +
           " ([CD_OF] " +
           " ,[CD_MAT] " +
           " ,[LB_MAT] " +
           " ,[DT_DEB] " +
           " ,[DT_FIN] " +
           " ,[CD_FORM] " +
           " ,[QT_LOT] " +
           " ,[CD_DEST] " +
           " ,[NB_LOT]) " +
     " VALUES " +
           "('" + dr["CD_OF"].ToString() +
           "','" + dr["CD_MAT"].ToString() +
           "','" + dr["LB_MAT"].ToString() +
           "',Convert(datetime,'" + dr["DT_DEB"].ToString() +
           "',103),Convert(datetime,'" + dr["DT_FIN"].ToString() +
           "',103),'" + dr["CD_FORM"].ToString() +
           "'," + float.Parse(dr["QT_LOT"].ToString()) +
           ",'" + dr["CD_DEST"].ToString() +
           "','" + dr["NB_LOT"].ToString() +
            "')", CommandType.Text);
        }

        public DataTable OF_Report_OFListComponents(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Oracle.ExecuteDataTable(" = '" + CD_OF + "'", CommandType.Text);
            return dt;
        }

        //public DataTable OF_Report_OFListBatchs(string CD_OF)
        //{
        //    DataTable dt = new DataTable();
        //    dt = Oracle.ExecuteDataTable("select * from HISDOS where REPLACE(CD_OF,chr(32),' ')='"+CD_OF+"'", CommandType.Text);
        //    return dt;
        //}

        public DataTable OF_Report_OFListBatchDetails(string CD_OF)
        {
            DataTable dt = new DataTable();
            //dt = Oracle.ExecuteDataTable(" select HISDOS.NO_LOT,V1.DT_MVMT , V1.CD_LOTORG, V1.NO_LOTORG,V1.CD_MAT,V1.LB_MAT,V1.QT_PREV,V1.QT_MVMT" +
            //" from HISDOS," +
            //            "(" +
            //              " SELECT *  " +
            //              " FROM MOUVEMENT," +
            //                            "(" +
            //                              "SELECT NO_LOT,NO_LOTORG  " +
            //                              "FROM HISTRANSLOTORG      " +
            //                            ") V" +
            //              " WHERE  CD_ZONE not like 'TR%' AND MOUVEMENT.CD_LOTORG = V.NO_LOT" +
            //            ") V1" +
            //" where HISDOS.NO_LOT = V1.CD_LOTDEST  AND   REPLACE(HISDOS.CD_OF,chr(32),'')= '" + CD_OF + "'  ORDER BY HISDOS.NO_LOT, V1.CD_LOTORG,V1.NO_LOTORG", CommandType.Text);
            dt = Oracle.ExecuteDataTable("select HISDOS.NO_LOT as NO_LOT,SUBSTR(V1.DT_MVMT,0,10) as DT_MVMT, V1.NO_LOTORG,V1.CD_MAT,V1.LB_MAT,SUM(V1.QT_PREV) as QT_PREV,SUM(V1.QT_MVMT) as QT_MVMT,V1.CD_LINC,V1.TOL_KG,V1.TOL_PER  " +
                                           " from HISDOS, " +
                                                         " ( " +
                                                            // " SELECT  MOUVEMENT.CD_LINC as CD_LINC,MOUVEMENT.CD_LOTDEST as CD_LOTDEST, " +
                                                            // //" CASE WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' THEN 'HT1' ELSE MOUVEMENT.CD_ZONE END as CD_ZONE,  "+
                                                            // " CASE WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' and CD_PROC <> 'Prepare' THEN 'HT1'   " + 
                                                            // "  WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' and CD_PROC = 'Prepare' THEN 'PRE' ELSE MOUVEMENT.CD_ZONE END as CD_ZONE,  " +
                                                            // " MOUVEMENT.DT_MVMT as DT_MVMT, " +
                                                            // " MOUVEMENT.CD_LOTORG as CD_LOTORG, " +
                                                            // " MOUVEMENT.QT_PREV as QT_PREV, " +
                                                            // " MOUVEMENT.CD_MAT as CD_MAT, " +
                                                            // " MOUVEMENT.QT_MVMT as QT_MVMT, " +
                                                            // " MOUVEMENT.LB_MAT  as LB_MAT, " +
                                                            // " HISTRANSLOTORG .NO_LOT as NO_LOT, " +
                                                            // //" CASE  "+ 
                                                            // //"     WHEN HISTRANSLOTORG.NO_LOTORG IS null THEN MOUVEMENT.CD_LOTORG  "+
                                                            // //"     ELSE HISTRANSLOTORG.NO_LOTORG   " + 
                                                            // //"     END as NO_LOTORG  "+ 
                                                            // " HISTRANSLOTORG.NO_LOTORG as NO_LOTORG" +
                                                            // " FROM MOUVEMENT  " +
                                                            // " LEFT JOIN  HISTRANSLOTORG  " +
                                                            //"  ON  MOUVEMENT.CD_LOTORG = HISTRANSLOTORG.NO_LOT " +
                                                            ////" WHERE MOUVEMENT.CD_MAT NOT LIKE 'F%'  and MOUVEMENT.CD_ZONE NOT LIKE 'TR%' ) V1 " +
                                                            //" WHERE ( MOUVEMENT.CD_MAT LIKE 'R%' OR MOUVEMENT.CD_MAT LIKE '%F_SP%')  AND MOUVEMENT.CD_ZONE NOT LIKE 'TR%' "+
                                                            //2019-06-26
                                                            //" SELECT  MOUVEMENT.CD_LINC, MOUVEMENT.CD_LOTDEST as CD_LOTDEST,   " +
                                                            //" CASE WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' and CD_PROC <> 'Prepare' THEN 'HT1'  " +
                                                            //" WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' and CD_PROC = 'Prepare' THEN 'PRE' ELSE MOUVEMENT.CD_ZONE END as CD_ZONE,  " +
                                                            //" MOUVEMENT.DT_MVMT as DT_MVMT,  " +
                                                            //" MOUVEMENT.CD_LOTORG as CD_LOTORG,  " +
                                                            //" MOUVEMENT.QT_PREV as QT_PREV,  " +
                                                            //" MOUVEMENT.CD_MAT as CD_MAT,  " +
                                                            //" MOUVEMENT.QT_MVMT as QT_MVMT,  " +
                                                            //" MOUVEMENT.LB_MAT as LB_MAT,  " +
                                                            //" HISTRANSLOTORG.NO_LOT as NO_LOT,  " +
                                                            //" HISTRANSLOTORG.NO_LOTORG as NO_LOTORG,  " +
                                                            //" v2.TOL_KG as TOL_KG,  " +
                                                            //" V2.TOL_PER as TOL_PER  " +
                                                            //" FROM MOUVEMENT  " +
                                                            //" LEFT JOIN  HISTRANSLOTORG  " +
                                                            //" ON  MOUVEMENT.CD_LOTORG = HISTRANSLOTORG.NO_LOT  " +
                                                            //" LEFT JOIN(SELECT MATLIEU.CD_MAT, MATIERE.LB_MAT, MATLIEU.CD_LINC, MATLIEU.QT_MIN AS TOL_KG, MATLIEU.QT_MAX as TOL_PER  " +
                                                            //               "  FROM ERESIS.MATIERE MATIERE, ERESIS.MATLIEU MATLIEU  " +
                                                            //                " WHERE MATIERE.CD_MAT = MATLIEU.CD_MAT) V2  " +
                                                            //" ON MOUVEMENT.CD_MAT = v2.cd_mat and mouvement.cd_linc = v2.cd_linc  " +
                                                            //" WHERE(MOUVEMENT.CD_MAT LIKE 'R%' OR MOUVEMENT.CD_MAT LIKE '%F_SP%')  AND MOUVEMENT.CD_ZONE NOT LIKE 'TR%'  " +
                                                            //" AND MOUVEMENT.CD_LINC is not null  " +
                                                            //New
                                                            " SELECT " +
                                                            " MOUVEMENT.CD_LINC, " +
                                                            " MOUVEMENT.CD_LOTDEST as CD_LOTDEST, " +
                                                            //--CASE WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' and CD_PROC <> 'Prepare' THEN 'HT1'
                                                            //--WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' and CD_PROC = 'Prepare' THEN 'PRE' ELSE MOUVEMENT.CD_ZONE END as CD_ZONE,
                                                            " MOUVEMENT.DT_MVMT as DT_MVMT, " +
                                                            //--MOUVEMENT.CD_LOTORG as CD_LOTORG,
                                                            " SUM(MOUVEMENT.QT_PREV) as QT_PREV, " +
                                                            " MOUVEMENT.CD_MAT as CD_MAT, " +
                                                            " SUM(MOUVEMENT.QT_MVMT) as QT_MVMT, " +
                                                            " MOUVEMENT.LB_MAT as LB_MAT, " +
                                                            //" HISTRANSLOTORG.NO_LOT as NO_LOT, " +
                                                            " HISTRANSLOTORG.NO_LOTORG as NO_LOTORG, " +
                                                            " v2.TOL_KG, " +
                                                            " V2.TOL_PER " +
                                                            " FROM MOUVEMENT " +
                                                            " LEFT JOIN  HISTRANSLOTORG " +
                                                            " ON  MOUVEMENT.CD_LOTORG = HISTRANSLOTORG.NO_LOT " +
                                                            " LEFT JOIN(SELECT MATLIEU.CD_MAT, MATIERE.LB_MAT, MATLIEU.CD_LINC, MATLIEU.QT_MIN AS TOL_KG, MATLIEU.QT_MAX as TOL_PER " +
                                                                            " FROM ERESIS.MATIERE MATIERE, ERESIS.MATLIEU MATLIEU " +
                                                                            " WHERE MATIERE.CD_MAT = MATLIEU.CD_MAT) V2 " +
                                                            " ON MOUVEMENT.CD_MAT = v2.cd_mat and mouvement.cd_linc = v2.cd_linc " +
                                                            " WHERE(MOUVEMENT.CD_MAT LIKE 'R%' OR MOUVEMENT.CD_MAT LIKE '%F_SP%')  AND MOUVEMENT.CD_ZONE NOT LIKE 'TR%' " +
                                                            " AND MOUVEMENT.CD_LINC is not null " +
                                                            " GROUP BY " +
                                                            " MOUVEMENT.CD_LINC, " +
                                                            " MOUVEMENT.CD_LOTDEST, " +
                                                            //--CASE WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' and CD_PROC <> 'Prepare' THEN 'HT1'
                                                            //--WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' and CD_PROC = 'Prepare' THEN 'PRE' ELSE MOUVEMENT.CD_ZONE END as CD_ZONE,
                                                            " MOUVEMENT.DT_MVMT, " +
                                                            //--MOUVEMENT.CD_LOTORG,
                                                            //--SUM(MOUVEMENT.QT_PREV) as QT_PREV,
                                                            " MOUVEMENT.CD_MAT, " +
                                                            //--SUM(MOUVEMENT.QT_MVMT),
                                                            " MOUVEMENT.LB_MAT, " +
                                                            //" HISTRANSLOTORG.NO_LOT, " +
                                                            " HISTRANSLOTORG.NO_LOTORG, " +
                                                            " v2.TOL_KG, " +
                                                            " V2.TOL_PER " +
                                                ") V1 " +
                                             ////" ) V1 " +
                                             " where HISDOS.NO_LOT = V1.CD_LOTDEST  AND   REPLACE(HISDOS.CD_OF,chr(32),'')='" + CD_OF + "'" +
                                             "GROUP By HISDOS.NO_LOT ,SUBSTR(V1.DT_MVMT,0,10) , V1.NO_LOTORG,V1.CD_MAT,V1.LB_MAT,V1.CD_LINC,V1.TOL_KG,V1.TOL_PER" +
                                             " ORDER BY HISDOS.NO_LOT, V1.NO_LOTORG", CommandType.Text);
            return dt;


        }

        public DataTable OF_Report_OFListBatchDetails_PREP(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Oracle.ExecuteDataTable(" " +
                                            //"select HISDOSLIG.CD_MAT as CD_MAT, " +
                                            //                        " HISDOSLIG.LB_MAT as LB_MAT, " +
                                            //                        " HISDOSLIG.CD_LINC as CD_LINC, " +
                                            //                        " HISDOSLIG.CD_ZONE, " +
                                            //                        " HISDOSLIG.QT_DOS as QT_DOS, " +
                                            //                        " HISDOSLIG.QT_INC  as QT_INC " +
                                            //                           " from HISDOS INNER JOIN HISDOSLIG  " +
                                            //                             " ON HISDOS.NO_LOT = HISDOSLIG.NO_LOT " +
                                            //                             " where REPLACE(HISDOS.CD_OF,chr(32),'')='" + CD_OF + "'  AND HISDOSLIG.CD_LINC='PREP'  " +
                                            //                             //" GROUP BY HISDOSLIG.CD_MAT,HISDOSLIG.LB_MAT ,HISDOSLIG.CD_LINC , HISDOSLIG.CD_ZONE, HISDOSLIG.QT_DOS, HISDOSLIG.QT_INC " +
                                            //                             " ORDER BY HISDOSLIG.CD_MAT,HISDOSLIG.LB_MAT  "

                                            " select HISDOSLIG.CD_MAT as CD_MAT,  " +
                                            " HISDOSLIG.LB_MAT as LB_MAT,  " +
                                            " HISDOSLIG.CD_LINC as CD_LINC,  " +
                                            " HISDOSLIG.CD_ZONE,  " +
                                            " HISDOSLIG.QT_DOS as QT_DOS,  " +
                                            " HISDOSLIG.QT_INC as QT_INC,  " +
                                            " v2.tol_kg as TOL_KG,  " +
                                            " v2.tol_per as TOL_PER  " +
                                            " from HISDOSLIG INNER JOIN HISDOS  " +
                                              " ON HISDOSLIG.NO_LOT = HISDOS.NO_LOT  " +
                                              " LEFT JOIN(SELECT MATLIEU.CD_MAT, MATIERE.LB_MAT, MATLIEU.CD_LINC, MATLIEU.QT_MIN AS TOL_KG, MATLIEU.QT_MAX as TOL_PER  " +
                                                                             " FROM ERESIS.MATIERE MATIERE, ERESIS.MATLIEU MATLIEU  " +
                                                                             " WHERE MATIERE.CD_MAT = MATLIEU.CD_MAT) V2  " +
                                                             " ON HISDOSLIG.CD_MAT = v2.cd_mat and HISDOSLIG.cd_linc = v2.cd_linc  " +
                                              " where REPLACE(HISDOS.CD_OF, chr(32), '')='" + CD_OF + "'  AND HISDOSLIG.CD_LINC = 'PREP'  " +
                                               " ORDER BY HISDOSLIG.CD_MAT, HISDOSLIG.LB_MAT  "
                                             , CommandType.Text);
            return dt;


        }

        public DataTable OF_Report_OFSummary_PREP(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Oracle.ExecuteDataTable(" select HISDOSLIG.CD_MAT as CD_MAT,  " +
                                            " HISDOSLIG.LB_MAT as LB_MAT, " +
                                            " HISDOSLIG.CD_LINC as CD_LINC, " +
                                            " HISDOSLIG.CD_ZONE, SUM(HISDOSLIG.QT_DOS) as QT_DOS, " +
                                            " SUM(HISDOSLIG.QT_INC) as QT_INC  " +
                                           " from HISDOS INNER JOIN HISDOSLIG  " +
                                             " ON HISDOS.NO_LOT = HISDOSLIG.NO_LOT " +
                                             " where REPLACE(HISDOS.CD_OF,chr(32),'')='" + CD_OF + "'  AND HISDOSLIG.CD_LINC='PREP'  "+
                                             " GROUP BY HISDOSLIG.CD_MAT,HISDOSLIG.LB_MAT ,HISDOSLIG.CD_LINC , HISDOSLIG.CD_ZONE, HISDOSLIG.QT_DOS " +
                                             //" GROUP BY HISDOSLIG.CD_MAT,HISDOSLIG.LB_MAT ,HISDOSLIG.CD_LINC , HISDOSLIG.CD_ZONE " +
                                             " ORDER BY HISDOSLIG.CD_MAT,HISDOSLIG.LB_MAT  ", CommandType.Text);
            return dt;


        }

        public DataTable OF_Report_OFSummary(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Oracle.ExecuteDataTable("select " +
                //"V1.DT_MVMT as DT_MVMT, "+
                "V1.NO_LOTORG,V1.CD_MAT,V1.LB_MAT,SUM(V1.QT_MVMT) as QT_MVMT,SUM(V1.QT_PREV) as QT_PREV  " +
                                           " from HISDOS, " +
                                                         " ( " +
                                                           " SELECT  MOUVEMENT.CD_LOTDEST as CD_LOTDEST, " +
                                                           //" CASE WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' THEN 'HT1' ELSE MOUVEMENT.CD_ZONE END as CD_ZONE,  " +
                                                           " MOUVEMENT.DT_MVMT as DT_MVMT, " +
                                                           //" MOUVEMENT.CD_LOTORG as CD_LOTORG, " +
                                                           " MOUVEMENT.QT_PREV as QT_PREV, " +
                                                           " MOUVEMENT.CD_MAT as CD_MAT, " +
                                                           " MOUVEMENT.QT_MVMT as QT_MVMT, " +
                                                           " MOUVEMENT.LB_MAT  as LB_MAT, " +
                                                           " HISTRANSLOTORG .NO_LOT as NO_LOT, " +
                                                           " CASE  " +
                                                           "     WHEN HISTRANSLOTORG.NO_LOTORG IS null THEN MOUVEMENT.CD_LOTORG  " +
                                                           "     ELSE HISTRANSLOTORG.NO_LOTORG   " +
                                                           "     END as NO_LOTORG  " +
                                                           " FROM MOUVEMENT  " +
                                                           " FULL OUTER JOIN  HISTRANSLOTORG  " +
                                                          "  ON  MOUVEMENT.CD_LOTORG = HISTRANSLOTORG.NO_LOT " +
                                                         " WHERE ( MOUVEMENT.CD_MAT LIKE 'R%' OR MOUVEMENT.CD_MAT LIKE '%F_SP%') and MOUVEMENT.CD_ZONE NOT LIKE 'TR%' ) V1 " +
                                              " where HISDOS.NO_LOT = V1.CD_LOTDEST  AND   REPLACE(HISDOS.CD_OF,chr(32),'')='" + CD_OF + "'" +
                                              " GROUP BY V1.NO_LOTORG,V1.CD_MAT,V1.LB_MAT" +
                                              " ORDER BY V1.CD_MAT DESC", CommandType.Text);
            return dt;
            //dt = Oracle.ExecuteDataTable("select hisdos.no_lot, " +
            //                                //" hisdoslig.no_lot, mouvement.cd_lotorg, no_lotorg, "+ 
            //                                " hisdoslig.cd_zone, " +
            //                                " MOUVEMENT.CD_LOTDEST as CD_LOTDEST, " +
            //                                " MOUVEMENT.DT_MVMT as DT_MVMT, " +
            //                                " MOUVEMENT.QT_PREV as QT_PREV, " +
            //                                " hisdoslig.CD_MAT as CD_MAT, " +
            //                                " Sum(MOUVEMENT.QT_MVMT) as QT_MVMT, " +
            //                                " hisdoslig.LB_MAT as LB_MAT, " +
            //                                " HISTRANSLOTORG.NO_LOT as NO_LOT, " +
            //                                " HISTRANSLOTORG.NO_LOTORG as NO_LOTORG " +
            //                                " from hisdos " +
            //                                " JOIN hisdoslig " +
            //                                " ON hisdos.no_lot = hisdoslig.no_lot " +
            //                                " join mouvement " +
            //                                " on hisdos.no_lot = mouvement.cd_lotdest " +
            //                                " join histranslotorg " +
            //                                " on mouvement.cd_lotorg = histranslotorg.no_lot " +
            //                                " WHERE REPLACE(HISDOS.CD_OF, chr(32), '') = '"+CD_OF+"'" +
            //                                //" and hisdos.no_lot = '30901100010110' " +
            //                                " group by hisdos.no_lot, " +
            //                                " hisdoslig.no_lot, mouvement.cd_lotorg, no_lotorg, hisdoslig.cd_zone, " +
            //                                " MOUVEMENT.CD_LOTDEST, " +
            //                                " MOUVEMENT.DT_MVMT, " +
            //                                " MOUVEMENT.QT_PREV, " +
            //                                " hisdoslig.CD_MAT, " +
            //                                " hisdoslig.LB_MAT, " +
            //                                " HISTRANSLOTORG.NO_LOT, " +
            //                                " HISTRANSLOTORG.NO_LOTORG ", CommandType.Text);
        }

        public DataTable OF_ListBatch(string CD_OF)
        {
            DataTable dt = new DataTable();
            //dt = Oracle.ExecuteDataTable(" select HISDOS.NO_LOT,V1.DT_MVMT , V1.CD_LOTORG, V1.NO_LOTORG,V1.CD_MAT,V1.LB_MAT,V1.QT_PREV,V1.QT_MVMT"+
            //" from HISDOS,"+
            //            "("+
            //              " SELECT *  "+
            //              " FROM MOUVEMENT,"+
            //                            "("+
            //                              "SELECT NO_LOT,NO_LOTORG  "+ 
            //                              "FROM HISTRANSLOTORG      "+                       
            //                            ") V"+
            //              " WHERE  CD_ZONE not like 'TR%' AND MOUVEMENT.CD_LOTORG = V.NO_LOT"+
            //            ") V1" +
            //" where HISDOS.NO_LOT = V1.CD_LOTDEST  AND   REPLACE(HISDOS.CD_OF,chr(32),'')= '" + CD_OF + "'  ORDER BY HISDOS.NO_LOT, V1.CD_LOTORG,V1.NO_LOTORG", CommandType.Text);
            dt = Sql.ExecuteDataTable("SAP", "  SELECT [CD_MAT],[LB_MAT],[NO_LOTORG] , " +
	                                        " Case T1.SoPKN  " +
		                                        " WHEN ISNULL(T1.SoPKN,'') THEN T1.SoPKN   " +
		                                        " else '' " +
                                            //" else 'Invalid' " +
	                                        " End as SoPKN " +
                                            " FROM [SYNC_NUTRICIEL].[dbo].[tbl_OF_Detail_Finished]  " +
                                                " left join (  "+
                                                " Select [SYNC_NUTRICIEL].[dbo].[tbl_OABatch].[OA BATCH] as [OA BATCH], " +
                                                " [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD].SoPKN as SoPKN " +
				                                " FROM [SYNC_NUTRICIEL].[dbo].[tbl_OABatch] " +
                                                " LEFT join [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD] " +
                                                " on [SYNC_NUTRICIEL].[dbo].[tbl_OABatch].[Lot number] = [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD].[Solo]   " +
                                                //Mới thêm vào theo yeu cau cua QC
                                                " and [SYNC_NUTRICIEL].[dbo].[tbl_OABatch].[Received date] = [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD].[NgayNhan]   " +
				                                " ) as T1 " +
	                                        " on [SYNC_NUTRICIEL].[dbo].[tbl_OF_Detail_Finished].[NO_LOTORG] =  T1.[OA BATCH]   " +
                                            " WHERE CD_OF='" + CD_OF + "' AND (CD_MAT LIKE 'R%' OR CD_MAT LIKE '%F_SP%')  " +
                                            " GROUP BY [CD_OF],[NO_LOTORG],[CD_MAT],[LB_MAT],T1.SoPKN ", CommandType.Text);
            return dt;
        }

        public void OF_Report_OFListBatchDetails_Insert(string OF,DataRow dr)
        {
            //XtraMessageBox.Show(dr["NO_LOT"].ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_OF_Detail_Finished] " +
           "([CD_OF] " +
           ",[NO_LOT] " +
           ",[DT_MVMT] " +
           ",[CD_LOTORG] " +
           ",[NO_LOTORG] " +
           ",[CD_MAT] " +
           ",[LB_MAT] " +
           ",[QT_PREV] " +
           ",[QT_MVMT] " +
           ",[CD_ZONE]) " +
     " VALUES " +
           "('" + OF +
            "','" + dr["NO_LOT"].ToString() +
            "',Convert(datetime,'" + dr["DT_MVMT"].ToString() +
            "',103),'" + dr["CD_LOTORG"].ToString() +
            "','" + dr["NO_LOTORG"].ToString() +
            "','" + dr["CD_MAT"].ToString() +
            "','" + dr["LB_MAT"].ToString() +
            "','" + float.Parse(dr["QT_PREV"].ToString()) +
            "','" + float.Parse(dr["QT_MVMT"].ToString()) +
            "','" + dr["CD_ZONE"].ToString() +
            "')", CommandType.Text);
        }
        public DataTable OF_Finished()
        {
            DataTable dt = new DataTable();
            //CHuyen qua laod tu SQL
            //2018-09-25          
            //dt = Oracle.ExecuteDataTable("select HISDOS.CD_OF as CD_OF ,MIN(HISDOS.DT_DEB) as DT_DEB  , " +
            //                               " MAX(HISDOS.DT_FIN) as DT_FIN, " +
            //                               " HISDOS.CD_MAT as CD_MAT, " +
            //                               " HISDOS.LB_MAT as LB_MAT , " +
            //                               " HISDOS.CD_VER as CD_VER , " +
            //                               " HISDOS.CD_DEST as CD_DEST , " +                                           
            //                               " COUNT(HISDOS.NB_LOT)as NB_LOT, " +
            //                               //" HISDOS.NB_LOT as NB_LOT, " +
            //                               " HISDOS.CD_FORM as CD_FORM, " +
            //                               " SUM(V1.QT_PREV) as QT_PREV, " +
            //                               " SUM(V1.QT_MVMT) as QT_MVMT  " +
            //                               " from HISDOS, " +
            //                                           " (  " +
            //                                             " SELECT CD_LOTDEST,QT_PREV,QT_MVMT " +
            //                                             " FROM MOUVEMENT " +
            //                                             " WHERE  CD_ZONE not like 'TR%' " +
            //                                             " ) V1 " +
            //                               " where HISDOS.NO_LOT = V1.CD_LOTDEST  " +
            //                               " GROUP by CD_MAT,LB_MAT,CD_VER,CD_DEST,CD_OF,CD_FORM ORDER BY CD_OF DESC ", CommandType.Text);
            //Load tu table SQL

            //dt = Sql.ExecuteDataTable("SAP", "select * " +            
            //    "from [SYNC_NUTRICIEL].dbo.tbl_OF_Finished  " +
            //    "ORDER BY CD_OF DESC ", CommandType.Text);

            dt = Sql.ExecuteDataTable("SAP", " SELECT    "+
                                                " tbl_OF_Finished.ID, " +
                                                " tbl_OF_Finished.CD_OF, " +
                                                " tbl_OF_Finished.CD_MAT, " +
                                                " tbl_OF_Finished.LB_MAT, " +
                                                " (tbl_OF_Finished.CD_MAT + ' : ' + tbl_OF_Finished.LB_MAT) as CD_MAT_LB_MAT, " +
                                                " tbl_OF_Finished.DT_DEB, " +
                                                " tbl_OF_Finished.DT_FIN, " +
                                                " tbl_OF_Finished.CD_FORM, " +
                                                " tbl_OF_Finished.QT_LOT, " +
                                                " tbl_OF_Finished.CD_DEST, " +
                                                " tbl_OF_Finished.NB_LOT, " +
                                                " tbl_OF_Finished.TOL_QTY_PAK, " +
                                                " tbl_OF_Finished.FUL_PAK_TYPE, " +
                                                " tbl_OF_Finished.FUL_PAK_BAG, " +
                                                " tbl_OF_Finished.LST_PAK_TYPE, " +
                                                " tbl_OF_Finished.LST_PAK_BAG, " +
                                                " tbl_OF_Finished.CONTAMINATION_PAK, " +
                                                " tbl_OF_Finished.FRM_CD_OF, " +
                                                " tbl_OF_Finished.REMAIN_PREV_CD_OF_QTY, " +
                                                " SUM(tbl_OF_Detail_Finished.QT_PREV) AS QT_PREV, " +
                                                " SUM(tbl_OF_Detail_Finished.QT_MVMT) AS QT_MVMT, " +
                                                " tbl_OF_Finished.REMAIN_PREV_CD_OF_QTY AS Expr1 " +
                                                " FROM            tbl_OF_Finished INNER JOIN " +
                                                " tbl_OF_Detail_Finished ON tbl_OF_Finished.CD_OF = tbl_OF_Detail_Finished.CD_OF " +
                                                " GROUP BY tbl_OF_Finished.ID, " +
                                                " tbl_OF_Finished.CD_OF, " +
                                                " tbl_OF_Finished.CD_MAT, " +
                                                " tbl_OF_Finished.LB_MAT, " +
                                                " tbl_OF_Finished.DT_DEB, " +
                                                " tbl_OF_Finished.DT_FIN, " +
                                                " tbl_OF_Finished.CD_FORM, " +
                                                " tbl_OF_Finished.QT_LOT, " +
                                                " tbl_OF_Finished.CD_DEST, " +
                                                " tbl_OF_Finished.NB_LOT, " +
                                                " tbl_OF_Finished.TOL_QTY_PAK, " +
                                                " tbl_OF_Finished.FUL_PAK_TYPE, " +
                                                " tbl_OF_Finished.FUL_PAK_BAG, " +
                                                " tbl_OF_Finished.LST_PAK_TYPE, " +
                                                " tbl_OF_Finished.LST_PAK_BAG, " +
                                                " tbl_OF_Finished.CONTAMINATION_PAK, " +
                                                " tbl_OF_Finished.FRM_CD_OF, " +
                                                " tbl_OF_Finished.REMAIN_PREV_CD_OF_QTY " +
                                                " ORDER BY tbl_OF_Finished.CD_OF DESC " , CommandType.Text);

            return dt;
        }

        public DataTable FG_Finished()
        {
            DataTable dt = new DataTable();
            dt = Oracle.ExecuteDataTable("select HISDOS.CD_MAT as CD_MAT, " +
                                           " HISDOS.LB_MAT as LB_MAT , " +                                           
                                           " SUM(V1.QT_PREV) as QT_PREV, " +
                                           " SUM(V1.QT_MVMT) as QT_MVMT  " +
                                           " from HISDOS, " +
                                                       " (  " +
                                                         " SELECT CD_LOTDEST,QT_PREV,QT_MVMT " +
                                                         " FROM MOUVEMENT " +
                                                         " WHERE  CD_ZONE not like 'TR%' " +
                                                         " ) V1 " +
                                           " where HISDOS.NO_LOT = V1.CD_LOTDEST  " +
                                           " GROUP by CD_MAT,LB_MAT ORDER BY CD_MAT DESC ", CommandType.Text);
            return dt;
        }

        public DataTable OF_Report_ByFG(string FG)
        {
            //XtraMessageBox.Show("FG" + FG);
            DataTable dt = new DataTable();
            dt = Oracle.ExecuteDataTable("select MIN(HISDOS.DT_DEB) as DT_DEB  , " +
                                           " MAX(HISDOS.DT_FIN) as DT_FIN, " +
                                           " HISDOS.CD_MAT as CD_MAT, " +
                                           " HISDOS.LB_MAT as LB_MAT , " +
                                           " HISDOS.CD_VER as CD_VER , " +
                                           " HISDOS.CD_DEST as CD_DEST , " +
                                           " HISDOS.CD_OF as CD_OF , " +
                                           " COUNT(HISDOS.NB_LOT)as NB_LOT, " +
                                           " HISDOS.CD_FORM as CD_FORM, " +
                                           " SUM(V1.QT_PREV) as QT_PREV, " +
                                           " SUM(V1.QT_MVMT) as QT_MVMT  " +
                                           " from HISDOS, " +
                                                       " (  " +
                                                         " SELECT CD_LOTDEST,QT_PREV,QT_MVMT " +
                                                         " FROM MOUVEMENT " +
                                                         " WHERE  CD_ZONE not like 'TR%' " +
                                                         " ) V1 " +
                                           " where HISDOS.NO_LOT = V1.CD_LOTDEST AND HISDOS.CD_MAT ='"+ FG +"' " +
                                           " GROUP by CD_MAT,LB_MAT,CD_VER,CD_DEST,CD_OF,CD_FORM ", CommandType.Text);
            return dt;
        }

        public DataTable OF_Report_ByDate(string startdate, string endate)
        {
            //XtraMessageBox.Show("startdate : " + startdate);
            DataTable dt = new DataTable();
            dt = Oracle.ExecuteDataTable("select MIN(HISDOS.DT_DEB) as DT_DEB  , " +
                                           " MAX(HISDOS.DT_FIN) as DT_FIN, " +
                                           " HISDOS.CD_MAT as CD_MAT, " +
                                           " HISDOS.LB_MAT as LB_MAT , " +
                                           " HISDOS.CD_VER as CD_VER , " +
                                           " HISDOS.CD_DEST as CD_DEST , " +
                                           " HISDOS.CD_OF as CD_OF , " +
                                           " COUNT(HISDOS.NB_LOT)as NB_LOT, " +
                                           " HISDOS.CD_FORM as CD_FORM, " +
                                           " SUM(V1.QT_PREV) as QT_PREV, " +
                                           " SUM(V1.QT_MVMT) as QT_MVMT  " +
                                           " from HISDOS, " +
                                                       " (  " +
                                                         " SELECT CD_LOTDEST,QT_PREV,QT_MVMT " +
                                                         " FROM MOUVEMENT " +
                                                         " WHERE  CD_ZONE not like 'TR%' " +
                                                         " ) V1 " +
                                           " where HISDOS.NO_LOT = V1.CD_LOTDEST AND HISDOS.DT_DEB >= to_date('" + startdate + "','MM/dd/yyyy') and HISDOS.DT_FIN <= to_date('" + endate + "','MM/dd/yyyy')  " +
                                           " GROUP by CD_MAT,LB_MAT,CD_VER,CD_DEST,CD_OF,CD_FORM ", CommandType.Text);
            return dt;
        }

        public void OF_Detail_INSERT(DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_OF_Detail]" +
           "([CD_OF]" +
           ",[FG_STATUS]" +
           ",[DT_PREV]" +
           ",[CD_DEPOT]" +
           ",[CD_MAT]" +
           ",[LB_MAT]" +
           ",[QT_PREV]" +
           ",[CD_UNIT]" +
           ",[NO_ORDRE]" +
           ",[CD_MAT1]" +
           ",[QT_DOSE]" +
           ",[CD_VER]" +
           ",[LOSS_COMP])" +
     "VALUES" +
           "(" + dr["CD_OF"] +
           ",'" + 1 +
           //"','" + DateTime.Parse(dr["DT_PREV"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
           "',Convert(datetime,'" + dr["DT_PREV"].ToString() +
           "',103),'" + 891 +
           "','" + dr["CD_MAT"].ToString() +
           "','" + dr["LB_MAT"].ToString() +
           "'," + dr["QT_PREV"] +
           ",'" + dr["CD_UNIT"].ToString() +
           "','" + 1000 +
           "','" + dr["CD_MAT1"].ToString() +
           "'," + dr["QT_DOSE"] +
           ",'" + 89 +
           "'," + dr["LOSS_COMP"]+
           ")", CommandType.Text);
        }
        public void OF_INSERT(DataRow dr)
        {
            //XtraMessageBox.Show("DT_PREV : " + dr["DT_PREV"].ToString());
            //XtraMessageBox.Show("DT_PREV : " + DateTime.Parse(dr["DT_PREV"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")));
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_OF]" +
           "([CD_OF]" +           
           ",[DT_PREV]" +           
           ",[CD_MAT]" +
           ",[LB_MAT]" +
           ",[QT_PREV]" +
           ")" +
     "VALUES" +
           "('" + dr["CD_OF"].ToString() +
           //"','" + DateTime.Parse(dr["DT_PREV"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
           "',Convert(datetime,'" + dr["DT_PREV"].ToString() +
           "',103),'" + dr["CD_MAT"].ToString() +
           "','" + dr["LB_MAT"].ToString() +
           "'," + dr["QT_PREV"] +           
           ")", CommandType.Text);
        }

        public void OF_UPDATE(string CD_OF, float ManufacturedQty, string MINStart, string MAXEnd, string Formula, int TotalBatch)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_OF] SET" +
           "[ManufacturedQty] = " + ManufacturedQty  +
           ",[Start] = Convert(datetime,'" + MINStart + "',103) " +
           ",[End] = Convert(datetime,'" + MAXEnd + "',103) " +
           ",[Formula] = '" + Formula + "' " +
           ",[TotalBatch] = " + TotalBatch +
           " WHERE [CD_OF]='"+CD_OF+"'", CommandType.Text);
        }

        public void OF_Resources_INSERT(DataRow dr, int IdSort)
        {
            //XtraMessageBox.Show("DT_PREV : " + dr["DT_PREV"].ToString());
            //XtraMessageBox.Show("DT_PREV : " + DateTime.Parse(dr["DT_PREV"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")));
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[Resources]" +
           "([IdSort]" +           
           ",[Description]" +           
           ")" +
     "VALUES" +
           "(" + IdSort +           
           //",'"+ dr["CD_OF"].ToString() + dr["CD_MAT"].ToString()+ dr["LB_MAT"].ToString()+"')", CommandType.Text);
            ",'"+ dr["CD_OF"].ToString() +"')", CommandType.Text);
        }

        public int MAX_IdSort()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT MAX([IdSort]) as IdSort  FROM [SYNC_NUTRICIEL].[dbo].[Resources]", CommandType.Text);
            return (int.Parse(dt.Rows[0]["IdSort"].ToString().Length == 0 ? "10" : dt.Rows[0]["IdSort"].ToString()) + 10);
        }

        public int CD_OF_Visible(string CD_OF)
        {
            DataTable dt = new DataTable();
            //dt = Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[Resources] Where LEFT(Description,4) ='" + CD_OF + "'", CommandType.Text);
            dt = Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[Resources] Where Description ='" + CD_OF + "'", CommandType.Text);
            return dt.Rows.Count ;
        }

        public int GET_ResourceId(string CD_OF)
        {
            DataTable dt = new DataTable();
            //dt = Sql.ExecuteDataTable("SAP", "SELECT [Id]  FROM [SYNC_NUTRICIEL].[dbo].[Resources] WHERE LEFT(Description,4)='" + CD_OF + "'", CommandType.Text);
            dt = Sql.ExecuteDataTable("SAP", "SELECT [Id]  FROM [SYNC_NUTRICIEL].[dbo].[Resources] WHERE Description ='" + CD_OF + "'", CommandType.Text);
            return int.Parse(dt.Rows[0]["Id"].ToString());
        }

        public void OF_Appointments_INSERT(string DT_DEB, string DT_FIN, int ResourceId, string Description)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[Appointments]" +
           "([Type]" +
           ",[StartDate]" +
           ",[EndDate]" +
           ",[AllDay]" +
           ",[Status]" +
           ",[Label]" +
           ",[ResourceId]" +
           ",[PercentComplete]" +
           ",[TimeZoneId]" +
           ",[Description]" +
           ")" +
     "VALUES" +
           "(" + 0 +
           //",'" + DateTime.Parse(DT_DEB, CultureInfo.CreateSpecificCulture("en-GB")) +
           //"','" + DateTime.Parse(DT_FIN, CultureInfo.CreateSpecificCulture("en-GB")) +
           ",Convert(datetime,'" + DT_DEB +
           "',103),Convert(datetime,'" + DT_FIN +
           "',103)," + 0 +
           "," + 2 +
           "," + 0 +
           "," + ResourceId +
           "," + 100 +
           ",'SE Asia Standard Time'"+
           ",'" + Description + "')", CommandType.Text);
        }


        public void OF_Finished_UPDATE(string CD_OF,
            float TOL_QTY_PAK, 
            string FUL_PAK_TYPE, 
            float FUL_PAK_BAG, 
            string LST_PAK_TYPE, 
            float LST_PAK_BAG, 
            float CONTAMINATION_PAK,
            string FRM_CD_OF,
            float REMAIN_PREV_CD_OF_QTY
            )
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_OF_Finished] SET" +
           "[TOL_QTY_PAK]= " + TOL_QTY_PAK +
           ",[FUL_PAK_TYPE] = '" + FUL_PAK_TYPE + "' " +
           ",[FUL_PAK_BAG]= " + FUL_PAK_BAG +
           ",[LST_PAK_TYPE] = '" + LST_PAK_TYPE + "' " +
           ",[LST_PAK_BAG]= " + LST_PAK_BAG +
           ",[CONTAMINATION_PAK]= " + CONTAMINATION_PAK +
           ",[FRM_CD_OF] = '" + FRM_CD_OF + "' " +
           ",[REMAIN_PREV_CD_OF_QTY]= " + REMAIN_PREV_CD_OF_QTY +
           " WHERE [CD_OF]='" + CD_OF + "'", CommandType.Text);
        }

        public void OF_REVERT(string CD_OF)
        {
            //Delete CDOF tbl_OF_Lines
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_OF_Detail] " +           
           " WHERE [CD_OF]='" + CD_OF + "'", CommandType.Text);
            //Delete CDOF tbl_OF
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_OF] " +
           " WHERE [CD_OF]='" + CD_OF + "'", CommandType.Text);
        }


    }

}


