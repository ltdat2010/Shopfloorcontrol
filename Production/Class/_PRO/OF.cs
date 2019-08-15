using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class OF
    {
        public OF(
            string CD_OF,
            float TOL_QTY_PAK,
            string FUL_PAK_TYPE,
            float FUL_PAK_BAG,
            string LST_PAK_TYPE,
            float LST_PAK_BAG,
            float CONTAMINATION_PAK_BAG,
            string FRM_CD_OF,
            float REMAIN_PREV_CD_OF_QTY
            )
        {
            this._CD_OF = CD_OF;
            this._TOL_QTY_PAK = TOL_QTY_PAK;
            this._FUL_PAK_TYPE = FUL_PAK_TYPE;
            this._FUL_PAK_BAG = FUL_PAK_BAG;
            this._LST_PAK_TYPE = LST_PAK_TYPE;
            this._LST_PAK_BAG = LST_PAK_BAG;
            this._CONTAMINATION_PAK = CONTAMINATION_PAK;
            this._FRM_CD_OF = FRM_CD_OF;
            this._REMAIN_PREV_CD_OF_QTY = REMAIN_PREV_CD_OF_QTY;
        }

        public OF()
        {
        }

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

        private float _TOL_QTY_PAK;

        //Bo sung them 2018-29-05
        public float TOL_QTY_PAK
        {
            get { return _TOL_QTY_PAK; }
            set { _TOL_QTY_PAK = value; }
        }

        private string _FUL_PAK_TYPE;

        public string FUL_PAK_TYPE
        {
            get { return _FUL_PAK_TYPE; }
            set { _FUL_PAK_TYPE = value; }
        }

        private float _FUL_PAK_BAG;

        public float FUL_PAK_BAG
        {
            get { return _FUL_PAK_BAG; }
            set { _FUL_PAK_BAG = value; }
        }

        private string _LST_PAK_TYPE;

        public string LST_PAK_TYPE
        {
            get { return _LST_PAK_TYPE; }
            set { _LST_PAK_TYPE = value; }
        }

        private float _LST_PAK_BAG;

        public float LST_PAK_BAG
        {
            get { return _LST_PAK_BAG; }
            set { _LST_PAK_BAG = value; }
        }

        private float _CONTAMINATION_PAK;

        public float CONTAMINATION_PAK
        {
            get { return _CONTAMINATION_PAK; }
            set { _CONTAMINATION_PAK = value; }
        }

        private string _FRM_CD_OF;

        public string FRM_CD_OF
        {
            get { return _FRM_CD_OF; }
            set { _FRM_CD_OF = value; }
        }

        private float _REMAIN_PREV_CD_OF_QTY;

        public float REMAIN_PREV_CD_OF_QTY
        {
            get { return _REMAIN_PREV_CD_OF_QTY; }
            set { _REMAIN_PREV_CD_OF_QTY = value; }
        }
    }
}