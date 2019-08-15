using System;
using System.Data;

namespace Production.Class
{
    public class PKNBUS
    {
        //public static OF of = new OF();
        public static PKNDAO PKB = new PKNDAO();

        public DataTable PKN_Template(int ID)
        {
            return PKB.PKN_Template(ID);
        }

        public DataTable PKN_List()
        {
            return PKB.PKN_List();
        }

        public int PKN_Template_Max_KQKNID()
        {
            return PKB.PKN_Template_Max_KQKNID();
        }

        public void PKN_Template_Insert(DataRow dr)
        {
            PKB.PKN_Template_Insert(dr);
        }

        public int PKN_Template_Visible(int KQKNID, int STT)
        {
            return PKB.PKN_Template_Visible(KQKNID, STT);
        }

        public DataTable PKN_Template_Search(int ID)
        {
            return PKB.PKN_Template_Search(ID);
        }

        public DataTable KQPKN_Search(string ID)
        {
            return PKB.KQPKN_Search(ID);
        }

        public DataTable TDPKN_Search(string SoPKN, int Lan)
        {
            return PKB.TDPKN_Search(SoPKN, Lan);
        }

        public DataTable KLPKN_Search(string SoPKN)
        {
            return PKB.KLPKN_Search(SoPKN);
        }

        public DataTable PKN_Template_View()
        {
            return PKB.PKN_Template_View();
        }

        public void PKN_Template_Delete(int ID)
        {
            PKB.PKN_Template_Delete(ID);
        }

        public void KQPKN_Insert(int SoPKNID, DataRow dr)
        {
            PKB.KQPKN_Insert(SoPKNID, dr);
        }

        public DataTable TDPKN_Visible(string SoPNK, string Solo)
        {
            return PKB.TDPKN_Visible(SoPNK, Solo);
        }

        public DataTable TDPKN_Search_Lan(string SoPKN)
        {
            return PKB.TDPKN_Search_Lan(SoPKN);
        }

        //public void KQPKN_Update(DataRow dr)
        //{
        //    PKB.KQPKN_Update(dr);
        //}

        public void KQPKN_Update(int ID, float KQTT)
        {
            PKB.KQPKN_Update(ID, KQTT);
        }

        public void TDPKN_Insert(string SoPKN
            , int KQKNTemplateID
            , string SoPNK
            , string QCDG
            , string SLNhan
            , DateTime NgayNhan
            , string Solo
            , DateTime NgaySX
            , DateTime HSD
            , DateTime NgayPT
            , string TenNL
            , int Lan
            )
        {
            PKB.TDPKN_Insert(SoPKN
            , KQKNTemplateID
            , SoPNK
            , QCDG
            , SLNhan
            , NgayNhan
            , Solo
            , NgaySX
            , HSD
            , NgayPT
            , TenNL
            , Lan
            );
        }

        public void KLPKN_Insert(int SoPKN, string KL, string PassFail, int Lan)
        {
            PKB.KLPKN_Insert(SoPKN, KL, PassFail, Lan);
        }

        public void KLPKN_Update(int SoPKN, string KL, string PassFail)
        {
            PKB.KLPKN_Update(SoPKN, KL, PassFail);
        }

        public int PKN_Lan(string Solo)
        {
            return PKB.PKN_Lan(Solo);
        }
    }
}