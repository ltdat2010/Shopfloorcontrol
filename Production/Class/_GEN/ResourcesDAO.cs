using System;
using System.Data;

namespace Production.Class
{
    public class ResourcesDAO
    {   
        public int MAX_IdSort()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT MAX([IdSort]) as IdSort  FROM [SYNC_NUTRICIEL].[dbo].[Resources]", CommandType.Text);
            return (int.Parse(dt.Rows[0]["IdSort"].ToString().Length == 0 ? "10" : dt.Rows[0]["IdSort"].ToString()) + 10);
        }
        //OFDAO
        //ResourcesDAO
        public int Resources_Visible(string description)
        {
            DataTable dt = new DataTable();
            //dt = Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[Resources] Where LEFT(Description,4) ='" + CD_OF + "'", CommandType.Text);
            dt = Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[Resources] Where Description =N'" + description + "'", CommandType.Text);
            return dt.Rows.Count ;
        }

        public int GET_ResourceId(string description)
        {
            DataTable dt = new DataTable();
            //dt = Sql.ExecuteDataTable("SAP", "SELECT [Id]  FROM [SYNC_NUTRICIEL].[dbo].[Resources] WHERE LEFT(Description,4)='" + CD_OF + "'", CommandType.Text);
            dt = Sql.ExecuteDataTable("SAP", "SELECT [Id]  FROM [SYNC_NUTRICIEL].[dbo].[Resources] WHERE Description =N'" + description + "'", CommandType.Text);
            return int.Parse(dt.Rows[0]["Id"].ToString());
        }
        //INSERT
        public void Resources_INSERT(Resources resources)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[Resources]" +
           "([IdSort]" +
           ",[ParentId]" +
           ",[Description]" +
           //",[Color]" +
           ",[Image]" +
           ",[CustomField1]" +
           ")" +
     "VALUES" +
           "(" + resources.IdSort +
                //",'" + DateTime.Parse(DT_DEB, CultureInfo.CreateSpecificCulture("en-GB")) +
                //"','" + DateTime.Parse(DT_FIN, CultureInfo.CreateSpecificCulture("en-GB")) +
           "," + resources.ParentId +           
           ",N'" + resources.Description +
           //"'," + resources.Color +
           "','null" +         
           "','"+ resources.CustomField1 +"')", CommandType.Text);
        }


        //UPDATE
        public void Resources_UPDATE(Resources resources)
        {          

           Sql.ExecuteNonQuery("SAP", " UPDATE [SYNC_NUTRICIEL].[dbo].[Resources] " +
                               "SET "+
                                  //"[IdSort] = resources.IdSort
                                  "[ParentId]       = "+ resources.ParentId +
                                  ",[Description]   = N'"+resources.Description +
                                  //"',[Color]        = "+ resources.Color +
                                  //",[Image] = <Image, image,>
                                  ",[CustomField1]  = '" + resources.CustomField1 +
                                  "' WHERE [Id]=" + resources.Id , CommandType.Text);
        }
        //
        //

        public void Appointments_INSERT(string DT_DEB, string DT_FIN, int ResourceId,string Description,string CustomField1,int label)
        {
           
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[Appointments]" +
                                       "([Type]" +
                                       ",[StartDate]" +
                                       ",[EndDate]" +
                                       ",[AllDay]" +
                                       ",[Status]" +
                                       ",[Label]" +
                                       ",[ResourceId]" +
                                       ",[Description]" +
                                       ",[PercentComplete]" +
                                       ",[CustomField1]" +
                                       ",[TimeZoneId]" +
                                       ")" +
                                 "VALUES" +
                                       "(" + 0 +
                                       //",'" + DateTime.Parse(DT_DEB, CultureInfo.CreateSpecificCulture("en-GB")) +
                                       //"','" + DateTime.Parse(DT_FIN, CultureInfo.CreateSpecificCulture("en-GB")) +
                                       ",CONVERT(datetime,'" + DT_DEB + "',103)" +
                                       ",CONVERT(datetime,'" + DT_FIN + "',103)" +
                                       "," + 0 +
                                       "," + 2 +
                                       "," + label +
                                       "," + ResourceId +
                                       ",N'" + Description +                                       
                                       "'," + 100 +
                                       ",N'" + CustomField1 +
                                       "','SE Asia Standard Time')", CommandType.Text);
        }
        public void Appointments_UPDATE(string DT_DEB, string DT_FIN, int UniqueId)
        {

            Sql.ExecuteNonQuery("SAP", " UPDATE [SYNC_NUTRICIEL].[dbo].[Appointments] " +
                              "SET " +
                                 //"[IdSort] = resources.IdSort
                                 "[StartDate]       = CONVERT(datetime,'" + DT_DEB + "',103)" +
                                 ",[EndDate]       = CONVERT(datetime,'" + DT_FIN + "',103)" +
                                 " WHERE [UniqueId]=" + UniqueId, CommandType.Text);
        }

        //public void Appointments_UPDATE(DateTime DT_DEB, DateTime DT_FIN, int UniqueId)
        //{

        //    Sql.ExecuteNonQuery("SAP", " UPDATE [SYNC_NUTRICIEL].[dbo].[Appointments] " +
        //                      "SET " +
        //                         //"[IdSort] = resources.IdSort
        //                         "[StartDate]       = '" + DT_DEB + "'" +
        //                         ",[EndDate]       = '" + DT_FIN + "'" +
        //                         "' WHERE [Id]=" + UniqueId, CommandType.Text);
        //}

        public DataTable Appointments_SELECT(string SoPXN)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", " Select * " +
                                                       " from Appointments  " +
                                                       " inner join Resources  " +
                                                       " on Appointments.ResourceId = Resources.Id  " +
                                                       " where Resources.Description = '" + SoPXN +"'", CommandType.Text);
            return dt;
        }



    }

}


