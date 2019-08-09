using DevExpress.XtraBars;

namespace Production.Class
{
    public partial class Action_Function : UC_Base  //DevExpress.XtraEditors.XtraUserControl
    {
        //public event EventHandler Add;
        //public event EventHandler Edit;
        //public event EventHandler Delete;
        //public event EventHandler Save;
        //public event EventHandler Cancel;
        //public event EventHandler Report;
        public string btn = "";
        public Action_Function()
        {
            InitializeComponent();
        
        
        }
        public void PKN(ItemClickEventHandler handle)
        {
            BtnPKN.ItemClick += handle;
        }
        
        public void COA(ItemClickEventHandler handle)
        {
            BtnCOA.ItemClick += handle;
        }

        public void TRACE(ItemClickEventHandler handle)
        {
            BtnTrace.ItemClick += handle;
        }

                       
        private Class.MenuState State;

        public Class.MenuState StateMenu
        {
            get { return State; }
            set 
            { 
                State = value;
                if (value == Class.MenuState.Update)
                {
                    BtnPKN.Enabled = false;
                    BtnCOA.Enabled = false;
                    BtnTrace.Enabled = true;
                    
                    
                      
                }
                else if (value == Class.MenuState.Full)
                {
                    //BtnPKN.Enabled = true;
                    BtnPKN.Enabled = false;
                    BtnCOA.Enabled = false;
                    BtnTrace.Enabled = true;

                }

                else if (value == Class.MenuState.Insert)
                {
                    //BtnPKN.Enabled = true;
                    BtnPKN.Enabled = false;
                    BtnCOA.Enabled = false;
                    BtnTrace.Enabled = true;

                }
                else if (value == Class.MenuState.View)
                {
                    //BtnPKN.Enabled = true;
                    BtnPKN.Enabled = false;
                    BtnCOA.Enabled = false;
                    BtnTrace.Enabled = true;

                }
                else if (value == Class.MenuState.NotView)
                {
                    //BtnPKN.Enabled = true;
                    BtnPKN.Enabled = false;
                    BtnCOA.Enabled = false;
                    BtnTrace.Enabled = false;

                }
                
            }
        }       
        
    }
}
