using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    
    public class InternalTransfer
    {
        //public InternalTransfer(
        //    string CD_OF,
        //    float TOL_QTY_PAK, 
        //    string FUL_PAK_TYPE, 
        //    float FUL_PAK_BAG, 
        //    string LST_PAK_TYPE, 
        //    float LST_PAK_BAG, 
        //    float CONTAMINATION_PAK_BAG,
        //    string FRM_CD_OF, 
        //    float REMAIN_PREV_CD_OF_QTY           
        //    )
        //{
        //    this._CD_OF = CD_OF;
        //    this._TOL_QTY_PAK = TOL_QTY_PAK;
        //    this._FUL_PAK_TYPE = FUL_PAK_TYPE;
        //    this._FUL_PAK_BAG = FUL_PAK_BAG;
        //    this._LST_PAK_TYPE = LST_PAK_TYPE;
        //    this._LST_PAK_BAG = LST_PAK_BAG;
        //    this._CONTAMINATION_PAK = CONTAMINATION_PAK;
        //this._FRM_CD_OF = FRM_CD_OF;
        //this._REMAIN_PREV_CD_OF_QTY = REMAIN_PREV_CD_OF_QTY;

        //}
        public InternalTransfer()
        {
        }
        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _DocNum;

        public string DocNum
        {
            get { return _DocNum; }
            set { _DocNum = value; }
        }
        private DateTime? _DocDate;

        public DateTime? DocDate
        {
            get { return _DocDate; }
            set { _DocDate = value; }
        }
        
        
        
    }
}
