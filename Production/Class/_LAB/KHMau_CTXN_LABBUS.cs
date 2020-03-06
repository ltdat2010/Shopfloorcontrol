using System.Data;

namespace Production.Class
{
    public class KHMau_CTXN_LABBUS
    {
        private KHMau_CTXN_LABDAO DAO = new KHMau_CTXN_LABDAO();

        public void KHMau_CTXN_LABBUS_INSERT(KHMau_CTXN_LAB OBJ)
        {
            DAO.KHMau_CTXN_LABDAO_INSERT(OBJ);
        }

        public void KHMau_CTXN_LABDAO_UPDATE(KHMau_CTXN_LAB OBJ)
        {
            DAO.KHMau_CTXN_LABDAO_UPDATE(OBJ);
        }

        public void KHMau_CTXN_LABDAO_UPDATE_CoKetQua(string KHMau_GiaoMau)
        {
            DAO.KHMau_CTXN_LABDAO_UPDATE_CoKetQua(KHMau_GiaoMau);
        }

        public void KHMau_CTXN_LABBUS_UPDATE_TraKetQua(KHMau_CTXN_LAB OBJ)
        {
            DAO.KHMau_CTXN_LABDAO_UPDATE_TraKetQua(OBJ);
        }

        public void KHMau_CTXN_LABBUS_UPDATE_GoiYCXuatHD(string KHMau, int CTXNID)
        {
            DAO.KHMau_CTXN_LABDAO_UPDATE_GoiYCXuatHD(KHMau, CTXNID);
        }

        public void KHMau_CTXN_LABDAO_DELETE(int ID)
        {
            DAO.KHMau_CTXN_LABDAO_DELETE(ID);
        }

        public void KHMau_CTXN_LABDAO_DELETE_ByKHMau(string KHMau)
        {
            DAO.KHMau_CTXN_LABDAO_DELETE_ByKHMau(KHMau);
        }

        public DataTable KHMau_CTXN_LABDAO_SELECT(int KHMau_ID)
        {
            return DAO.KHMau_CTXN_LABDAO_SELECT(KHMau_ID);
        }

        public int MAX_KHMau_CTXN_LABDAO_ID()
        {
            return DAO.MAX_KHMau_CTXN_LABDAO_ID();
        }

        public int MAX_KHMau_CTXN_LABDAO_SoLuongXN(string KHMau_BanGiao)
        {
            return DAO.MAX_KHMau_CTXN_LABDAO_SoLuongXN(KHMau_BanGiao);
        }
    }
}