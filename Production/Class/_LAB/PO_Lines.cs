using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    //public class SUPPLIER
    public class PO_Lines
    {
        public PO_Lines(
            int ID,            
            string SoPO, 
            int PriceList_Details_LAB_Id,
            string MaCTXN,
            string CTXN,
            string UoM,
            string SoLuongXN,
            float DonGia,
            float VAT,
            float ThanhTien,
            string GhiChu,
            int KHMau_CTXN_LAB_Id,
            DateTime CreatedDate, 
            string CreatedBy, 
            bool Locked,
            string Note

            )
        {
            this._ID = ID;
            this._SoPO = SoPO;            
            this._PriceList_Details_LAB_Id = PriceList_Details_LAB_Id;
            this._MaCTXN = MaCTXN;
            this._CTXN = CTXN;
            this._UoM = UoM;
            this._SoLuongXN = SoLuongXN;
            this._DonGia = DonGia;
            this._VAT = VAT;
            this._ThanhTien = ThanhTien;
            this._GhiChu = GhiChu;
            //KHMau_CTXN_LAB_Id
            this._KHMau_CTXN_LAB_Id = KHMau_CTXN_LAB_Id;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;     
            this._Note = Note;
        }
        public PO_Lines()
        {

        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _SoPO;
        public string SoPO
        {
            get { return _SoPO; }
            set { _SoPO = value; }
        }

        private int _PriceList_Details_LAB_Id;
        public int PriceList_Details_LAB_Id
        {
            get { return _PriceList_Details_LAB_Id; }
            set { _PriceList_Details_LAB_Id = value; }
        }

        private string _MaCTXN;
        public string MaCTXN
        {
            get { return _MaCTXN; }
            set { _MaCTXN = value; }
        }

        private string _CTXN;
        public string CTXN
        {
            get { return _CTXN; }
            set { _CTXN = value; }
        }        

        private string _UoM;
        public string UoM
        {
            get { return _UoM; }
            set { _UoM = value; }
        }

        private string _SoLuongXN;
        public string SoLuongXN
        {
            get { return _SoLuongXN; }
            set { _SoLuongXN = value; }
        }

        private float _DonGia;
        public float DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }

        private float _VAT;
        public float VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }

        private float _ThanhTien;
        public float ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }

        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }

        private int _KHMau_CTXN_LAB_Id;
        public int KHMau_CTXN_LAB_Id
        {
            get { return _KHMau_CTXN_LAB_Id; }
            set { _KHMau_CTXN_LAB_Id = value; }
        }

        private DateTime _CreatedDate;
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private string _CreatedBy;
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        private bool _Locked;
        public bool Locked
        {
            get { return _Locked; }
            set { _Locked = value; }
        }        

        private string _Note;

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        
    }
}
