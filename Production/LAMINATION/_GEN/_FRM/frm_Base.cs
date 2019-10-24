using DevExpress.XtraLayout;

namespace Production.Class
{
    public partial class frm_Base : DevExpress.XtraEditors.XtraForm
    {
        public User user = new User();

        //PC Name
        public string PCname = System.Environment.MachineName;

        //path
        public string path = string.Empty;

        //CHo dãy nút Action full
        public string isAction = "";

        // Cho dãy nút Action rút gọn
        public string isActionMini = "";

        public MenuState state = new MenuState();

        /// <summary>
        /// DELEGATE
        /// </summary>
        ///

        //public delegate void MyAdd(object sender);
        //public event MyAdd myFinished;

        //public bool Is_close
        //{
        //    set
        //    {
        //        if (value)
        //        {
        //            if (myFinished != null) myFinished(sender: this);
        //        }
        //    }
        //}

        //END DELEGATE////////////////////////////////////////////////////////////////////////////

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

        public frm_Base()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            InitializeComponent();

            Load += (s, e) =>
            {
                foreach (LayoutControl LC in this.Controls)
                    LC.AllowCustomization = false;
            };
            
        }
    }
}