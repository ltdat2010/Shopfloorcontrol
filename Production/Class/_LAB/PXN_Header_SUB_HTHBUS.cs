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
    public class PXN_Header_SUB_HTHBUS
    {
        PXN_Header_SUB_HTHDAO DAO = new PXN_Header_SUB_HTHDAO();

        public void PXN_Header_SUB_HTHBUS_INSERT(PXN_Header_SUB_HTH OBJ)
        {
            DAO.PXN_Header_SUB_HTHDAO_INSERT(OBJ);        
        }

        public void PXN_Header_SUB_HTHBUS_UPDATE(PXN_Header_SUB_HTH OBJ)
        {
            DAO.PXN_Header_SUB_HTHDAO_UPDATE(OBJ);
        }

        public void PXN_Header_SUB_HTHBUS_DELETE(PXN_Header_SUB_HTH OBJ)
        {
            DAO.PXN_Header_SUB_HTHDAO_DELETE(OBJ);
        }

        public int MAX_PXN_Header_SUB_HTHBUS_ID()
        {
            return DAO.MAX_PXN_Header_SUB_HTHDAO_ID();
        }
    }

}


