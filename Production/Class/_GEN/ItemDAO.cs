using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;

namespace Production.Class
{
    public class ItemDAO
    {
        //public DataTable SP_MAX_PRNO()
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "SELECT MAX([SYNC_NUTRICIEL].dbo.tbl_PR.PRNO) + 1 as PRNO FROM [SYNC_NUTRICIEL].dbo.tbl_PR ", CommandType.Text);
        //    return dt;
        //}
        //public DataTable SP_PR_Detail_parms(string PRNO)
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "SELECT * 	FROM [SYNC_NUTRICIEL].dbo.tbl_PR_Detail  WHERE PRNO = '" + PRNO + "' ", CommandType.Text);
        //    return dt;
        //}

        public void Item_INSERT(
            string ItemCode,
            string ItemName,
            string FrgnName,
            string InvntryUom,
            string ItemCode4OA
           )
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_Item]"+
            "([ItemCode],"+
            "[ItemName],"+ 
            "[FrgnName],"+
            "[InvntryUom],"+
            "[ItemCode4OA]" + 
           ")" +
            "VALUES" +
           "('" + ItemCode +
           "','" + ItemName +
           "','" + FrgnName +
           "','" + InvntryUom +
           "','" + ItemCode4OA +
            "')", CommandType.Text);
        }

        public void Item_DELETE(
            string ItemCode
           )
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_Item] WHERE [ItemCode] = " +
            "'" + ItemCode +
            "'", CommandType.Text);
        }

        public void Item_UPDATE(
            string ItemCode
           )
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_Item] WHERE [ItemCode] = " +
            "'" + ItemCode +
            "'", CommandType.Text);
        }
    }

}


