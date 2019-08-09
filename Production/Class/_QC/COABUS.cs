using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Text;
using Production.Class;
using System.IO;
using System.Data;
using System.Windows;

namespace Production.Class
{
    public class COABUS
    {
        //public static OF of = new OF();
        public static COADAO CAB = new COADAO();        
        public DataTable COA_Template(int ID)
        {
            return CAB.COA_Template(ID);
        }

        public DataTable COA_List()
        {
            return CAB.COA_List();
        }

        public DataTable COA_Search_ByWO(string WO)
        {
            return CAB.COA_Search_ByWO(WO);
        }

        public int COA_Template_Max_COAID()
        {
            return CAB.COA_Template_Max_COAID();
        }

        public DataTable COA_Template_Search(int ID)
        {
            return CAB.COA_Template_Search(ID);
        }

        public DataTable KQCOA_Search(string SoCOA, string Characteristic)
        {
            return CAB.KQCOA_Search(SoCOA, Characteristic);
        }

        public DataTable KQCOA_Search_COAID(int COAID, string Characteristic)
        {
            return CAB.KQCOA_Search_COAID(COAID, Characteristic);
        }
        public DataTable TDCOA_Search(string SoCOA)
        {
            return CAB.TDCOA_Search(SoCOA);
        }

        //public DataTable KLPKN_Search(int SoPKN)
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "SELECT * " +
        //                                        "FROM [SYNC_NUTRICIEL].[dbo].[tbl_KLPKN]  " +
        //                                        "WHERE [SYNC_NUTRICIEL].[dbo].[tbl_KLPKN].SoPKN =" + SoPKN, CommandType.Text);
        //    return dt;
        //}

        public DataTable TDCOA_Visible(string WO)
        {
            return CAB.TDCOA_Visible(WO);
        }

        public DataTable COA_Template_View()
        {
            return CAB.COA_Template_View();
        }
        public int COA_Template_Visible(int COAID, int STT)
        {
            return CAB.COA_Template_Visible(COAID, STT);
        }

        public void COA_Template_Delete(int ID)
        {            
            CAB.COA_Template_Delete(ID);  
        }


        public void COA_Template_Insert(DataRow dr)
        {
            CAB.COA_Template_Insert(dr);
        }

        public void KQCOA_Insert(int SoCOA,DataRow dr)
        {
            CAB.KQCOA_Insert(SoCOA,dr);
        }

     //   public void KLPKN_Insert(int SoPKN, string KL ,string PassFail)
     //   {
     //       Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KLPKN]" +
     //      "([SoPKN] " +
     //      ",[KL] " +
     //      ",[PassFail]) " +
     //"VALUES " +
     //      "(" + SoPKN +
     //      ",'" + KL +
     //      "','" + PassFail + "')", CommandType.Text);
     //   }

        //public void KLPKN_Update(int SoPKN, string KL, string PassFail)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [dbo].[tbl_KLPKN] " +
        //                               "SET [PassFail] = '" + PassFail +
        //                               "',[KL] = '" + KL +
        //                               "' WHERE [dbo].[tbl_KQPKN].[SoPKN]=" + SoPKN, CommandType.Text);
        //}


        //public void KQPKN_Update(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [dbo].[tbl_KQPKN] "+
        //                               "SET [KQTT] = "+ float.Parse(dr["KQTT"].ToString()) +                                      
        //                               "WHERE [dbo].[tbl_KQPKN].[ID]=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //}

        public void KQCOA_Update(int ID, string Result)
        {
            CAB.KQCOA_Update( ID, Result);
        }

        public void TDCOA_Insert(int SoCOA
            , int COATemplateID
            , string WO
            , string Manufacturedby            
            , DateTime SmpDate            
            , DateTime ExpDate
            , DateTime AnlDate
            , DateTime ManfDate
            ,string LB_MAT
            )
        {
            CAB.TDCOA_Insert(SoCOA
            , COATemplateID
            , WO
            , Manufacturedby            
            , SmpDate            
            , ExpDate
            , AnlDate
            , ManfDate
            ,LB_MAT
            );
        }       
    
    }
}
