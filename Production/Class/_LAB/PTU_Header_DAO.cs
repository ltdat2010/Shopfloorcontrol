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
    public class PTU_Header_DAO
    {
        public void PTU_Header_INSERT(PTU_Header OBJ)
        {

            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PTU_Header_LAB] " +
           " ([SoPTU] " +
           " ,[VENDCode] " +
           " ,[VENDName] " +
           " ,[NgayLapPhieu] " +
           " ,[NgayTamUng] " +
           " ,[NoiDung] " +
           " ,[SoTienTamUng] " +
           " ,[SoTienDaTamUng] " +
           " ,[SoTienDeNghiThanhToan] " +
           " ,[PaymentTerm] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.SoPTU +
           "',N'" + OBJ.VENDCode +
           "',N'" + OBJ.VENDName +
           "',CONVERT(datetime,'" + OBJ.NgayLapPhieu +
           "',103),CONVERT(datetime,'" + OBJ.NgayTamUng +
           "',103),N'" + OBJ.NoiDung +
           "'," + OBJ.SoTienTamUng +
           "," + OBJ.SoTienDaTamUng +
           "," + OBJ.SoTienDeNghiThanhToan +
           ",'" + OBJ.PaymentTerm +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void PTU_Header_UPDATE(PTU_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PTU_Header_LAB] SET " +
           "[SoPTU]                                              = N'" + OBJ.SoPTU + "'" +
           "[VENDCode]                                          = N'" + OBJ.VENDCode + "'" +
           ",[VENDName]                                         = N'" + OBJ.VENDName + "'" +
           ",[NgayLapPhieu]                                     = CONVERT(datetime,'" + OBJ.NgayLapPhieu + "',103)" +
           ",[NgayTamUng]                                     = CONVERT(datetime,'" + OBJ.NgayTamUng + "',103)" +
           ",[NoiDung]                                   = N'" + OBJ.NoiDung + "'" +
           ",[PaymentTerm]                                      = N'" + OBJ.PaymentTerm + "'" +
           ",[SoTienTamUng]                                      = " + OBJ.SoTienTamUng +
           ",[SoTienDaTamUng]                                      = " + OBJ.SoTienDaTamUng +
           ",[SoTienDeNghiThanhToan]                                      = " + OBJ.SoTienDeNghiThanhToan + 
           ",[CreatedDate]                                      = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]                                        = N'" + OBJ.CreatedBy + "' " +
           ",[Note]                                             = N'" + OBJ.Note + "' " +
           ",[Locked]                                           = '" + OBJ.Locked + "' " +
           " WHERE [ID]                                         = " + OBJ.ID, CommandType.Text);
        }

        public void PTU_Header_DELETE(int ID)
        {
            Sql.ExecuteNonQuery("SAP", "   DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PTU_Header_LAB] " +
                                        " WHERE [ID]=" + ID, CommandType.Text);
        }

        public DataTable PTU_Header_SELECT(string SoPTU)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_PTU_Header_LAB] " +
                                                " WHERE [SoPTU]='" + SoPTU + "'", CommandType.Text);
        }

        public string Issued_SoPTU()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(RIGHT(SoPTU,4)) as SoPTU FROM [SYNC_NUTRICIEL].[dbo].[tbl_PTU_Header_LAB] ", CommandType.Text);
            return dt.Rows[0]["SoPTU"].ToString().Length == 0 ? "0000" : dt.Rows[0]["SoPTU"].ToString() ;
        }

        //public void Update_SoPO(string SoPO)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Info] SET PONumber = '" + SoPO + "'", CommandType.Text);
        //}

    }

}


