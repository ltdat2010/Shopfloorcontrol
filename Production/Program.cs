using DevExpress.LookAndFeel;
using System;
using System.Windows.Forms;

namespace Production.Class
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //2019-08-28
            DevExpress.Skins.SkinManager.EnableFormSkins();
            //DevExpress.UserSkins.OfficeSkins.Register();
            //DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;            
            //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
             Application.Run(new frm_Main());
        }
    }
}