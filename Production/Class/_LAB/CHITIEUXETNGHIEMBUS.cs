using System;
using System.Data;

namespace Production.Class
{
    public class CHITIEUXETNGHIEMBUS
    {
        private CHITIEUXETNGHIEMDAO CTXNDAO = new CHITIEUXETNGHIEMDAO();

        public void CHITIEUXETNGHIEM_INSERT(CHITIEUXETNGHIEM CTXN)
        {
            CTXNDAO.CHITIEUXETNGHIEM_INSERT(CTXN);
        }

        public void CHITIEUXETNGHIEM_UPDATE(CHITIEUXETNGHIEM CTXN)
        {
            CTXNDAO.CHITIEUXETNGHIEM_UPDATE(CTXN);
        }

        public void CHITIEUXETNGHIEM_DELETE(CHITIEUXETNGHIEM CTXN)
        {
            CTXNDAO.CHITIEUXETNGHIEM_DELETE(CTXN);
        }

        //public DataTable CUSTOMER_LIST_SAPB1()
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "Select CardCode,CardName,Address from [VIPHAVET].[dbo].[OCRD] where CardType ='S' ", CommandType.Text);
        //    return dt;

        public DataRow TINHGIA_CTXN(DateTime NgayLapPXN, int CTXNID)
        {
            return CTXNDAO.TINHGIA_CTXN(NgayLapPXN, CTXNID);
        }

        public int CTXN_CTXNID_SELECT(string acr)
        {
            return CTXNDAO.CTXN_CTXNID_SELECT(acr);
        }

        public int CTXN_INDENTITY_SELECT()
        {
            return CTXNDAO.CTXN_INDENTITY_SELECT();
        }
    }
}