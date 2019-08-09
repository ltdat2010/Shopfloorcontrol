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
    public class ResourcesBUS
    {
        ResourcesDAO DAO = new ResourcesDAO();
        public int MAX_IdSort()
        {
            return DAO.MAX_IdSort();
        }
        //OFDAO
        //ResourcesDAO
        public int Resources_Visible(string description)
        {
            return DAO.Resources_Visible(description);
        }

        public int GET_ResourceId(string description)
        {
            return DAO.GET_ResourceId(description);
        }
        //INSERT
        public void Resources_INSERT(Resources resources)
        {
            DAO.Resources_INSERT(resources);
        }


        //UPDATE
        public void Resources_UPDATE(Resources resources)
        {
            DAO.Resources_UPDATE(resources);
        }
        //
        //

        public void Appointments_INSERT(string DT_DEB, string DT_FIN, int ResourceId, string Description, string CustField1, int label)
        {
            DAO.Appointments_INSERT( DT_DEB,  DT_FIN,  ResourceId, Description, CustField1, label);
        }

        //public void Appointments_UPDATE(DateTime DT_DEB, DateTime DT_FIN, int UniqueId)
        //{
        //    DAO.Appointments_UPDATE(DT_DEB, DT_FIN, UniqueId);
        //}

        public void Appointments_UPDATE(string DT_DEB, string DT_FIN, int UniqueId)
        {
            DAO.Appointments_UPDATE(DT_DEB, DT_FIN, UniqueId);
        }

        public DataTable Appointments_SELECT(string SoPXN)
        {
            return DAO.Appointments_SELECT(SoPXN);
        }


    }

}


