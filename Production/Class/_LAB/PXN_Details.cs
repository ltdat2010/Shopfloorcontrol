using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    public class PXN_Details
    {
        public PXN_Details(
            int ID,
            string SoPXN,
            int CTXNID,
            string SLMau,
            string GhiChu,
            string DonGia,
            string ThanhTien,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._SoPXN = SoPXN;
            this._CTXNID = CTXNID;
            this._SLMau = SLMau;
            this._GhiChu = GhiChu;
            this._DonGia = DonGia;
            this._ThanhTien = ThanhTien;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;

        }
        public PXN_Details()
        {

        }
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }        

        private string _SoPXN;

        public string SoPXN
        {
            get { return _SoPXN; }
            set { _SoPXN = value; }
        }

        private int _CTXNID;

        public int CTXNID
        {
            get { return _CTXNID; }
            set { _CTXNID = value; }
        }

        private string _SLMau;

        public string SLMau
        {
            get { return _SLMau; }
            set { _SLMau = value; }
        }

        private string _PPXNID;

        public string PPXNID
        {
            get { return _PPXNID; }
            set { _PPXNID = value; }
        }

        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }

        private string _DonGia;

        public string DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }

        private string _ThanhTien;

        public string ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
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
