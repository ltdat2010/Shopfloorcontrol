using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    //PTU : Phieu Tam Ung
    public class PTU_Lines
    {
        public PTU_Lines(
            int ID,  
            int TAMUNG_ID,
            string SoPTU,             
            string NoiDung,
            string SoHD,
            float SoTien,
            DateTime CreatedDate, 
            string CreatedBy, 
            bool Locked,
            string Note

            )
        {
            this._ID = ID;
            this._TAMUNG_ID = TAMUNG_ID;
            this._SoPTU = SoPTU;            
            this._NoiDung = NoiDung;
            this._SoHD = SoHD;
            this._SoTien = SoTien;            
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;     
            this._Note = Note;
        }
        public PTU_Lines()
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

        private int _TAMUNG_ID;
        public int TAMUNG_ID
        {
            get { return _TAMUNG_ID; }
            set { _TAMUNG_ID = value; }
        }

        private string _NoiDung;
        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }

        private string _SoHD;
        public string SoHD
        {
            get { return _SoHD; }
            set { _SoHD = value; }
        }        

        private float _SoTien;
        public float SoTien
        {
            get { return _SoTien; }
            set { _SoTien = value; }
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
