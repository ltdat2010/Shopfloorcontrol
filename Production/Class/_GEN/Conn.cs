using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;

namespace Production.Class
{
    internal class Conn
    {
        //-------------------------------------MSSQL-------------------------------------------------------------------
        //public static string varConnect_S = "Data Source= 192.168.0.249;" +
        //                                       "Database= SYNC_NUTRICIEL;" +
        //                                       "User ID= netika;" +
        //                                       "password= bsvn";
        public static string varConnect_S = "Data Source= 192.168.0.251;" +
                                               "Database= SYNC_NUTRICIEL;" +
                                               "User ID= netika;" +
                                               "password= bsvn";

        public static SqlConnection conn_S = new SqlConnection(Conn.varConnect_S);

        //-------------------------------------ORACLE-------------------------------------------------------------------
        public static string varConnect_O = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.3.51"
                        + ")(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = NUTRASLV"
                        + ")));Password= olmix ;User ID= olmix ";

        public static OracleConnection conn_O = new OracleConnection(Conn.varConnect_O);
        //-------------------------------------END----------------------------------------------------------------------

        public static CrystalDecisions.Shared.ConnectionInfo connect_Info = new CrystalDecisions.Shared.ConnectionInfo();
    }
}