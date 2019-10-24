using System;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using Production.Class;

namespace Production.LAMINATION._GEN._UC
{
    public partial class Filter_Vertical : UC_Base
    {
        public string cmbOption_SelectedText;
        public DateTime dteFrDateVal;
        public DateTime dteToDateVal;

        public Filter_Vertical()
        {
            InitializeComponent();            
        }

        public void Find(EventHandler BtnFind_Click)
        {
            btnFind.Click += BtnFind_Click;
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            
        }       

        public void Excel(EventHandler BtnExcel_Click)
        {
            btnExcel.Click += BtnExcel_Click;
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            
        }

        public void Exit(EventHandler BtnExit_Click)
        {
            btnExit.Click += BtnExit_Click;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            
        }
        private void cmbOption_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbOption_SelectedText = cmbOption.SelectedText.ToString();
            switch (cmbOption.SelectedText)
            {
                case ("From...to..."):
                    //dt = POH_BUS.PO_List_Report(DateTime.Parse(dteFrDate.Text), DateTime.Parse(dteToDate.Text));
                    dteFrDate.ReadOnly = false;
                    dteToDate.ReadOnly = false;
                    break;
                default:
                    //dt = POH_BUS.PO_List_Report_Daily();
                    dteFrDate.ReadOnly = true;
                    dteToDate.ReadOnly = true;
                    break;

            }
        }

        private void dteFrDate_EditValueChanged(object sender, EventArgs e)
        {
            dteFrDateVal = DateTime.Parse(dteFrDate.Text);
        }

        private void dteToDate_EditValueChanged(object sender, EventArgs e)
        {
            dteToDateVal = DateTime.Parse(dteToDate.Text);
        }
    }
}