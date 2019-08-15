using System;

namespace Production.Class
{
    public partial class R_COA_SelectLanguage : frm_Base
    {
        public string CD_OF;
        public string SoCOA;

        public R_COA_SelectLanguage()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
            };
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            R_COA RCOA = new R_COA();
            RCOA.CD_OF = this.CD_OF;
            RCOA.SoCOA = this.SoCOA;
            RCOA.ReportLanguage = this.cmbReportLanguage.SelectedText.ToString();
            RCOA.Show();
            this.Close();
        }
    }
}