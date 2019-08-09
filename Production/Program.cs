using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace Production.Class
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                        DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            //XpoDefault.Session.ConnectionString = @"XpoProvider=MSSqlServer;data source=vnhoc-5034;user id=sa;password=bunjibus;initial catalog=200;Persist Security Info=true";
            //UserLookAndFeel.Default.SetSkinStyle("Office 2013 Light Gray");
            UserLookAndFeel.Default.SetSkinStyle("Caramel");
            Application.Run(new frm_Main());
        }
    }
}