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
    public class LOCATIONBUS
    {
        LOCATIONDAO LOCDAO = new LOCATIONDAO();
        public void LOCATION_INSERT(LOCATION LOC)
        {
            LOCDAO.LOCATION_INSERT(LOC);
        }

        public void LOCATION_UPDATE(LOCATION LOC)
        {
            LOCDAO.LOCATION_UPDATE(LOC);
        }

        public void LOCATION_DELETE(LOCATION LOC)
        {
            LOCDAO.LOCATION_DELETE(LOC);
        }


    }

}


