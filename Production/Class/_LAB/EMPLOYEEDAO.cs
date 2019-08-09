using System;
using System.Data;

namespace Production.Class
{
    public class EMPLOYEEDAO
    {
        public void EMPLOYEE_INSERT(EMPLOYEE EMP)
        {     
            Sql.ExecuteNonQuery("SAP", "INSERT INTO[SYNC_NUTRICIEL].[dbo].[tbl_EMPLOYEE_LAB] " +
                                       " ([EMPCode] " +
                                       " ,[EMPName] " +
                                       " ,[EMPMobile] " +
                                       " ,[EMPEmail] " +
                                       " ,[CreatedDate] " +
                                       " ,[CreatedBy] " +
                                       " ,[Note] " +
                                       " ,[Locked]) " +
                                 " VALUES " +
                                       "('" + EMP.EMPCode +
                                       "',N'" + EMP.EMPName +
                                       "',N'" + EMP.EMPMobile +
                                       "',N'" + EMP.EMPEmail +
                                       "',Convert(datetime,'" + DateTime.Now +
                                       "',103),'" + EMP.CreatedBy +
                                       "',N'" + EMP.Note +
                                       "','" + EMP.Locked +
                                        "')", CommandType.Text);
        }

        public void EMPLOYEE_UPDATE(EMPLOYEE EMP)
        {		            
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_EMPLOYEE_LAB] SET" +
                                       " [EMPCode] = N'" + EMP.EMPCode + "'" +
                                       ",[EMPName] = N'" + EMP.EMPName + "'" +
                                       ",[EMPMobile] = N'" + EMP.EMPMobile + "'" +
                                       ",[EMPEmail] = N'" + EMP.EMPEmail + "'" +
                                       ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
                                       ",[CreatedBy] = '" + EMP.CreatedBy + "' " +
                                       ",[Note] = N'" + EMP.Note + "' " +
                                       ",[Locked] = '" + EMP.Locked + "' " +
                                       " WHERE [Id]='" + EMP.Id + 
                                       "'", CommandType.Text);
        }

        public void EMPLOYEE_DELETE(EMPLOYEE EMP)
        {
           Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_EMPLOYEE_LAB] " +
                                       " WHERE [EMPCode]='" + EMP.EMPCode + 
                                       "'", CommandType.Text);
        }
    }
}


