using System;

namespace Production.Class
{
    public class SUPPLIER
    {
        private string _CD_OF;

        public string CD_OF
        {
            get { return _CD_OF; }
            set { _CD_OF = value; }
        }

        private string _FG_STATUS;

        public string FG_STATUS
        {
            get { return _FG_STATUS; }
            set { _FG_STATUS = value; }
        }

        private DateTime? _DT_PREV;

        public DateTime? DT_PREV
        {
            get { return _DT_PREV; }
            set { _DT_PREV = value; }
        }

        private string _CD_DEPOT;

        public string CD_DEPOT
        {
            get { return _CD_DEPOT; }
            set { _CD_DEPOT = value; }
        }

        private string _CD_MAT;

        public string CD_MAT
        {
            get { return _CD_MAT; }
            set { _CD_MAT = value; }
        }

        private string _LB_MAT;

        public string LB_MAT
        {
            get { return _LB_MAT; }
            set { _LB_MAT = value; }
        }

        private float _QT_PREV;

        public float QT_PREV
        {
            get { return _QT_PREV; }
            set { _QT_PREV = value; }
        }

        private string _CD_UNIT;

        public string CD_UNIT
        {
            get { return _CD_UNIT; }
            set { _CD_UNIT = value; }
        }

        private string _NO_ORDRE;

        public string NO_ORDRE
        {
            get { return _NO_ORDRE; }
            set { _NO_ORDRE = value; }
        }

        private string _CD_MAT1;

        public string CD_MAT1
        {
            get { return _CD_MAT1; }
            set { _CD_MAT1 = value; }
        }

        private float _QT_DOSE;

        public float QT_DOSE
        {
            get { return _QT_DOSE; }
            set { _QT_DOSE = value; }
        }

        private string _CD_VER;

        public string CD_VER
        {
            get { return _CD_VER; }
            set { _CD_VER = value; }
        }
    }
}