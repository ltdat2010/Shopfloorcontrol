using System;
using System.Data;

namespace Production.Class
{
    public class PRBUS
    {
        public static PRDAO PRA = new PRDAO();

        public DataTable SP_MAX_PRNO()
        {
            return PRA.SP_MAX_PRNO();
        }

        public DataTable SP_PR_Detail_parms(string PRNO)
        {
            return PRA.SP_PR_Detail_parms(PRNO);
        }

        public void PR_INSERT(string PRNO
           , string RequestDept
           , DateTime RequestDate
           , DateTime DueDate
           , string RequestReason
           , string CreatedBy
           , DateTime CreatedDate
           , string CheckedBy
           , DateTime CheckedDate
           , string ApprovedBy
           , DateTime ApprovedDate
            )
        {
            PRA.PR_INSERT(PRNO
           , RequestDept
           , RequestDate
           , DueDate
           , RequestReason
           , CreatedBy
           , CreatedDate
           , CheckedBy
           , CheckedDate
           , ApprovedBy
           , ApprovedDate
            );
        }

        public void PR_Detail_INSERT(DataRow dr)
        {
            PRA.PR_Detail_INSERT(dr);
        }
    }
}