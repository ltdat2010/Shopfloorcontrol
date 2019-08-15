using System.Data;

namespace Production.Class
{
    public class LabTestingDAO
    {
        //----------------------------------------LabTesting---------------------------------------------
        //SELECT CODE
        public DataTable LabTesting_Select(string Testing_Code)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT [ID] " +
                                      ",[Testing_Code] " +
                                      ",[Customer_Code] " +
                                      ",[Testing_Name] " +
                                      ",[Created_Date] " +
                                      ",[Created_By] " +
                                      ",[Testing_Period_Time] " +
                                      ",[Testing_Result_Receive_Time] " +
                                      "FROM [SYNC_NUTRICIEL].[dbo].[tbl_LabTesting]" +
                                      " WHERE  [Testing_Code]= '" + Testing_Code + "'", CommandType.Text);
            return dt;
        }

        //SELECT ID
        public int LabTesting_ID(string Testing_Code)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT [ID] " +
                                      ",[Testing_Code] " +
                                      ",[Customer_Code] " +
                                      ",[Testing_Name] " +
                                      ",[Created_Date] " +
                                      ",[Created_By] " +
                                      ",[Testing_Period_Time] " +
                                      ",[Testing_Result_Receive_Time] " +
                                      "FROM [SYNC_NUTRICIEL].[dbo].[tbl_LabTesting]" +
                                      " WHERE  [Testing_Code]= '" + Testing_Code + "'", CommandType.Text);

            return int.Parse(dt.Rows[0]["ID"].ToString());
        }

        //SELECT ALL
        public DataTable LabTesting_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT [ID] " +
                                      ",[Testing_Code] " +
                                      ",[Customer_Code] " +
                                      ",[Testing_Name] " +
                                      ",[Created_Date] " +
                                      ",[Created_By] " +
                                      ",[Testing_Period_Time] " +
                                      ",[Testing_Result_Receive_Time] " +
                                  "FROM [SYNC_NUTRICIEL].[dbo].[tbl_LabTesting]", CommandType.Text);
            return dt;
        }

        //INSERT
        public void LabTesting_Insert(LabTesting Lab)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_LabTesting]" +
                "([Testing_Code] " +
           ",[Customer_Code] " +
           ",[Testing_Name] " +
           ",[Created_Date] " +
           ",[Created_By] " +
           ",[Testing_Period_Time] " +
           ",[Testing_Result_Receive_Time]) " +
           "VALUES " +
           "('" + Lab.Testing_Code.ToString() + "'" +
           ",'" + Lab.Customer_Code.ToString() + "'" +
           ",'" + Lab.Testing_Name.ToString() + "'" +
           ",'" + Lab.Created_Date.ToString() + "'" +
           ",'" + Lab.Created_By.ToString() + "'" +
           ",'" + Lab.Testing_Period_Time.ToString() + "'" +
           ",'" + Lab.Testing_Result_Receive_Time.ToString() + "')", CommandType.Text);
        }

        //UPDATE
        public void LabTesting_Update(LabTesting Lab)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_LabTesting]" +
                                        " SET " +
                                        "[Testing_Code] ='" + Lab.Testing_Code.ToString() + "'" +
                                        ",[Customer_Code] = '" + Lab.Customer_Code.ToString() + "' " +
                                        ",[Testing_Name] = '" + Lab.Testing_Name.ToString() + "' " +
                                        ",[Created_Date] = '" + Lab.Created_Date.ToString() + "' " +
                                        ",[Created_By] = '" + Lab.Created_By.ToString() + "' " +
                                        ",[Testing_Period_Time] = '" + Lab.Testing_Period_Time.ToString() + "' " +
                                        ",[Testing_Result_Receive_Time] = '" + Lab.Testing_Result_Receive_Time.ToString() + "' " +
                                        "WHERE ID=" + int.Parse(Lab.ID.ToString()), CommandType.Text);
        }

        //DELETE

        public DataTable TC_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select ID, TC From [SYNC_NUTRICIEL].[dbo].tbl_TieuChuan WHERE ID>1", CommandType.Text);
            return dt;
        }

        //public void TC_Insert(TieuChuan tc)
        //{
        //    Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan] " +
        //                                           "([TC] " +
        //                                           ",[TCDG]) " +
        //                                     "VALUES " +
        //                                           "('" + tc.TC +
        //                                           "','" + tc.TCDG + "'", CommandType.Text);
        //    //return dt;
        //}
        public void TC_Update(DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan]" +
                                        " SET [TC] ='" + dr["TC"].ToString() + "'" +
                                        ",[TCDG] = '" + dr["TC"].ToString() + "' " +
                                        "WHERE ID=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
            //return dt;
        }
    }
}