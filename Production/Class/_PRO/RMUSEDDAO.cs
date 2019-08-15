using System.Data;

namespace Production.Class
{
    public class RMUSEDDAO
    {
        public DataTable RMUSED_Find(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_RMUsed] Where [CD_OF] =  '" + CD_OF + "'", CommandType.Text);
            return dt;
        }

        public DataTable RMUSED_View()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_RMUsed] ORDER BY [Step] DESC", CommandType.Text);
            return dt;
        }

        public void RMUSED_INSERT(DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_RMUsed] " +
           "([CD_OF] " +
           ",[Step] " +
           ",[RMCode] " +
           ",[RMUsed] " +
           ",[NUBatch]) " +
     "VALUES " +
           "('" + dr["0"].ToString() +
           "','" + dr["4"].ToString() +
           "','" + dr["5"].ToString() +
           "'," + dr["7"] +
           ",'" + dr["14"].ToString() + "')", CommandType.Text);
            //       Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_OF_Detail]" +
            //      "([CD_OF]" +
            //      ",[FG_STATUS]" +
            //      ",[DT_PREV]" +
            //      ",[CD_DEPOT]" +
            //      ",[CD_MAT]" +
            //      ",[LB_MAT]" +
            //      ",[QT_PREV]" +
            //      ",[CD_UNIT]" +
            //      ",[NO_ORDRE]" +
            //      ",[CD_MAT1]" +
            //      ",[QT_DOSE]" +
            //      ",[CD_VER]" +
            //      ",[LOSS_COMP])" +
            //"VALUES" +
            //      "(" + dr["CD_OF"] +
            //      ",'" + 1 +
            //      "','" + DateTime.Parse(dr["DT_PREV"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
            //      "','" + 891 +
            //      "','" + dr["CD_MAT"].ToString() +
            //      "','" + dr["LB_MAT"].ToString() +
            //      "'," + dr["QT_PREV"] +
            //      ",'" + dr["CD_UNIT"].ToString() +
            //      "','" + 1000 +
            //      "','" + dr["CD_MAT1"].ToString() +
            //      "'," + dr["QT_DOSE"] +
            //      ",'" + 89 +
            //      "'," + dr["LOSS_COMP"]+
            //      ")", CommandType.Text);
        }

        //   public void OF_INSERT(DataRow dr)
        //   {
        //       Sql.ExecuteNonQuery("SAP", "INSERT INTO [dbo].[tbl_OF]" +
        //      "([CD_OF]" +
        //      ",[DT_PREV]" +
        //      ",[CD_MAT]" +
        //      ",[LB_MAT]" +
        //      ",[QT_PREV]" +
        //      ")" +
        //"VALUES" +
        //      "('" + dr["CD_OF"].ToString() +
        //      "','" + DateTime.Parse(dr["DT_PREV"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
        //      "','" + dr["CD_MAT"].ToString() +
        //      "','" + dr["LB_MAT"].ToString() +
        //      "'," + dr["QT_PREV"] +
        //      ")", CommandType.Text);
        //   }
        public DataTable RMUsed_Report(string Prefix_RM)
        {
            DataTable dt = new DataTable();
            dt = Oracle.ExecuteDataTable("select HISDOS.NO_LOT as NO_LOT,V1.DT_MVMT as DT_MVMT, V1.CD_LOTORG, V1.NO_LOTORG,V1.CD_MAT,V1.LB_MAT,V1.QT_PREV,V1.QT_MVMT,V1.CD_ZONE " +
                                           " from HISDOS, " +
                                                         " ( " +
                                                           " SELECT  MOUVEMENT.CD_LOTDEST as CD_LOTDEST, " +
                                                           " CASE WHEN MOUVEMENT.CD_ZONE = 'RM WHSE' THEN 'HT1' ELSE MOUVEMENT.CD_ZONE END as CD_ZONE,  " +
                                                           " MOUVEMENT.DT_MVMT as DT_MVMT, " +
                                                           " MOUVEMENT.CD_LOTORG as CD_LOTORG, " +
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
                                                         " WHERE MOUVEMENT.CD_MAT LIKE '%" + Prefix_RM + "%' AND MOUVEMENT.CD_MAT not LIKE 'F%' AND MOUVEMENT.QT_MVMT > 0 ) V1 " + //and MOUVEMENT.CD_ZONE NOT LIKE 'TR%' ) V1 " +
                                             " where HISDOS.NO_LOT = V1.CD_LOTDEST " +
                                             " ORDER BY V1.CD_ZONE,HISDOS.NO_LOT, V1.CD_LOTORG,V1.NO_LOTORG", CommandType.Text);
            return dt;
        }

        public DataTable RMUsed_Report_Simple(string Prefix_RM)
        {
            DataTable dt = new DataTable();
            dt = Oracle.ExecuteDataTable("select  V1.CD_LOTORG, V1.NO_LOTORG, V1.CD_MAT, V1.LB_MAT, SUM(V1.QT_MVMT) as QT_MVMT " +
                                           " from HISDOS, " +
                                                         " ( " +
                                                           " SELECT  MOUVEMENT.CD_LOTDEST as CD_LOTDEST, " +
                                                           " MOUVEMENT.CD_LOTORG as CD_LOTORG, " +
                                                           " MOUVEMENT.CD_MAT as CD_MAT, " +
                                                           " MOUVEMENT.QT_MVMT as QT_MVMT, " +
                                                           " MOUVEMENT.LB_MAT  as LB_MAT, " +
                                                           " CASE  " +
                                                           "     WHEN HISTRANSLOTORG.NO_LOTORG IS null THEN MOUVEMENT.CD_LOTORG  " +
                                                           "     ELSE HISTRANSLOTORG.NO_LOTORG   " +
                                                           "     END as NO_LOTORG  " +
                                                           " FROM MOUVEMENT  " +
                                                           " FULL OUTER JOIN  HISTRANSLOTORG  " +
                                                          "  ON  MOUVEMENT.CD_LOTORG = HISTRANSLOTORG.NO_LOT " +
                                                         " WHERE MOUVEMENT.CD_MAT LIKE '%" + Prefix_RM + "%' AND MOUVEMENT.CD_MAT not LIKE 'F%' AND MOUVEMENT.QT_MVMT > 0 ) V1 " +
                                             " where HISDOS.NO_LOT = V1.CD_LOTDEST " +
            " GROUP BY V1.CD_LOTORG, V1.NO_LOTORG, V1.CD_MAT, V1.LB_MAT ", CommandType.Text);
            return dt;
        }
    }
}