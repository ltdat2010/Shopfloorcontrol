using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    //public class SUPPLIER
    public class PTU_Header
    {
        public PTU_Header(
            int ID,            
            string SoPTU, 
            string VENDCode,
            string VENDName,
            DateTime NgayLapPhieu,
            DateTime NgayTamUng,            
            string NoiDung,
            string DeptCode,
            string PaymentTerm,
            DateTime CreatedDate, 
            string CreatedBy, 
            bool Locked,
            string Note,
            float SoTienDaTamUng,
            float SoTienDeNghiThanhToan,
            float SoTienTamUng

            )
        {
            this._ID = ID;
            this._SoPTU = SoPTU;            
            this._VENDCode = VENDCode;
            this._VENDName = VENDName;
            this._NgayLapPhieu = NgayLapPhieu;
            this._NgayTamUng = NgayTamUng;
            this._NoiDung = NoiDung;
            this._PaymentTerm = PaymentTerm;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;     
            this._SoTienDaTamUng = SoTienDaTamUng;
            this._SoTienDeNghiThanhToan = SoTienDeNghiThanhToan;
            this._SoTienTamUng = SoTienTamUng;
            this._Note = Note;
        }
        public PTU_Header()
        {

        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _SoPTU;
        public string SoPTU
        {
            get { return _SoPTU; }
            set { _SoPTU = value; }
        }

        private string _VENDCode;
        public string VENDCode
        {
            get { return _VENDCode; }
            set { _VENDCode = value; }
        }

        private string _VENDName;
        public string VENDName
        {
            get { return _VENDName; }
            set { _VENDName = value; }
        }

        private DateTime _NgayLapPhieu;
        public DateTime NgayLapPhieu
        {
            get { return _NgayLapPhieu; }
            set { _NgayLapPhieu = value; }
        }        

        private DateTime _NgayTamUng;
        public DateTime NgayTamUng
        {
            get { return _NgayTamUng; }
            set { _NgayTamUng = value; }
        }

        private string _NoiDung;
        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }

        private string _PaymentTerm;
        public string PaymentTerm
        {
            get { return _PaymentTerm; }
            set { _PaymentTerm = value; }
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

        private float _SoTienDaTamUng;

        public float SoTienDaTamUng
        {
            get { return _SoTienDaTamUng; }
            set { _SoTienDaTamUng = value; }
        }

        private float _SoTienDeNghiThanhToan;

        public float SoTienDeNghiThanhToan
        {
            get { return _SoTienDeNghiThanhToan; }
            set { _SoTienDeNghiThanhToan = value; }
        }

        private float _SoTienTamUng;

        public float SoTienTamUng
        {
            get { return _SoTienTamUng; }
            set { _SoTienTamUng = value; }
        }


    }
}
