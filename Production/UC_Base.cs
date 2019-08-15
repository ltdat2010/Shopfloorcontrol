using DevExpress.XtraSplashScreen;

namespace Production.Class
{
    public partial class UC_Base : DevExpress.XtraEditors.XtraUserControl
    {
        //Kiem tra xem click chon row tren grid chua
        public bool gridViewRowClick = false;

        public SplashScreenManager SSM = new SplashScreenManager();

        public User user = new User();

        public string isAction = "";

        public Mail mail = new Mail();

        public MenuState state = new MenuState();

        public string btn = "";

        public delegate void MyLogin(User user, bool login_sts);

        public event MyLogin mylogin;

        public bool login_sts;

        public bool Is_login

        {
            set
            {
                if (value)
                {
                    if (mylogin != null) mylogin(this.user, login_sts: true);
                }
            }
        }

        public UC_Base()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Caramel");
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Caramel";
            InitializeComponent();
        }

        //Them
        public virtual UC_Base Add()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }

        //Sua
        public virtual frm_Base Modify()
        {
            frm_Base frm = new frm_Base();
            return frm;
        }

        //Luu
        public virtual void Save()
        {
            this.Save();
        }

        //Report
        public virtual void Report()
        {
            this.Report();
        }

        //Xoa
        public virtual void Delete()
        {
            this.Delete();
        }

        //Thoat
        public virtual void Close()
        {
            this.Dispose();
        }

        //Next
        public virtual void Next()
        {
            this.Next();
        }

        //Prev
        public virtual void Prev()
        {
            this.Prev();
        }

        //Last
        public virtual void Last()
        {
            this.Last();
        }

        //First
        public virtual void First()
        {
            this.First();
        }

        //Chart
        public virtual UC_Base Chart()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }

        ////Report
        //public virtual UC_Base Report()
        //{
        //    UC_Base uc = new UC_Base();
        //    return uc;
        //}

        //Report Lite
        public virtual UC_Base ReportLite()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }

        //------------------------------------------------------------
        //Them

        //sua

        //Luu

        //Xoa

        //Thoat

        //Chart

        //Report
        //------------------------------------------------------------
        //Print
        public virtual UC_Base Print()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }

        //Rewind
        public virtual UC_Base Rewind()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }

        //Dry
        public virtual UC_Base Dry()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }

        //Exstrution
        public virtual UC_Base Exstrution()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }

        //Slit
        public virtual UC_Base Slit()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }

        //Bag
        public virtual UC_Base Bag()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }

        //Sort
        public virtual UC_Base Sort()
        {
            UC_Base uc = new UC_Base();
            return uc;
        }
    }
}