using System;

namespace Production.Class
{
    public class RECEIPT
    {
        private string _ECH_RECEPS;

        public string ECH_RECEPS
        {
            get { return _ECH_RECEPS; }
            set { _ECH_RECEPS = value; }
        }

        private string _ECH_RECEP;

        public string ECH_RECEP
        {
            get { return _ECH_RECEP; }
            set { _ECH_RECEP = value; }
        }

        private DateTime _DT_ENT;

        public DateTime DT_ENT
        {
            get { return _DT_ENT; }
            set { _DT_ENT = value; }
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

        private float _NO_LOT;

        public float NO_LOT
        {
            get { return _NO_LOT; }
            set { _NO_LOT = value; }
        }

        private string _QT_NET;

        public string QT_NET
        {
            get { return _QT_NET; }
            set { _QT_NET = value; }
        }

        private string _CD_UNIT;

        public string CD_UNIT
        {
            get { return _CD_UNIT; }
            set { _CD_UNIT = value; }
        }

        private DateTime _DP_PEREMP;

        public DateTime DP_PEREMP
        {
            get { return _DP_PEREMP; }
            set { _DP_PEREMP = value; }
        }
    }
}