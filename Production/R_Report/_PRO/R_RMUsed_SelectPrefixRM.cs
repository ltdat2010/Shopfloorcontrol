using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_RMUsed_SelectPrefixRM : frm_Base
    {
        private string RptType = "";
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";

        private string Path = Directory.GetCurrentDirectory();
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_RMUsed_SelectPrefixRM()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
            };
            simpleButton1.Click += (s, e) =>
                {
                    R_RM_Used RMU = new R_RM_Used();

                    if (chkRptType.CheckState == CheckState.Checked)
                        RMU.RptType = "D";
                    else
                        RMU.RptType = "S";

                    RMU.Prefix_RM = DEFrDate.SelectedText.ToString();
                    RMU.Show();
                    this.Close();
                };
        }
    }
}