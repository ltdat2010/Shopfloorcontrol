﻿using System.Data;

namespace Production.Class
{
    public class BATCHBUS
    {
        public static BATCHDAO OFD = new BATCHDAO();

        public DataTable BATCH_Find(string BATCH)
        {
            return OFD.BATCH_Find(BATCH);
        }

        public DataTable BATCH_View()
        {
            return OFD.BATCH_View();
        }

        public void BATCH_INSERT(DataRow dr)
        {
            OFD.BATCH_INSERT(dr);
        }

        public DataTable MINStart_MAXEnd_Date(string CD_OF)
        {
            return OFD.MINStart_MAXEnd_Date(CD_OF);
        }
    }
}