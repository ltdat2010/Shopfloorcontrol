using System;
using System.Threading;
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
            //try
            //{
            //    const string APPGUID = "{9F6F0AC4-B9A1-90AB-DE0F-72F04E6BDE8F}";
            //    using (Mutex mutex = new Mutex(false, APPGUID))
            //    {
            //        if (!mutex.WaitOne(0, false))
            //        {
            //            MessageBox.Show("Already Running Application!", "An instance of the application is already running...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            return;
            //        }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    DevExpress.Skins.SkinManager.EnableFormSkins();
                    Application.Run(new frm_Main());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            
            //Application.Run(new frm_Main());
        }
    }
}