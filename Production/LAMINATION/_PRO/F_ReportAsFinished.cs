using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_ReportAsFinished : frm_Base //DevExpress.XtraEditors.XtraForm
    {
        private OF _oF = new OF();
        private OFBUS _oFBUS = new OFBUS();
        public string CD_OF = "";

        DataTable dt_OFHeader, dt_OFListBatchDetails;


        public F_ReportAsFinished()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                lkeWO.Properties.DataSource = _oFBUS.F_OF_List();

                //dt_OFHeader = _oFBUS.OF_Report_OFHeader(gridView1.GetFocusedRowCellValue("CD_OF").ToString());
                dt_OFHeader = _oFBUS.OF_Report_OFHeader(this.CD_OF);
                //dt_OFListBatchDetails = _oFBUS.OF_Report_OFListBatchDetails(gridView1.GetFocusedRowCellValue("CD_OF").ToString());
                dt_OFListBatchDetails = _oFBUS.OF_Report_OFListBatchDetails(this.CD_OF);
            };
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (_oFBUS.F_OF_Find(CD_OF).Rows.Count <= 0)
            {
                DialogResult dlDel = XtraMessageBox.Show(" Update formular version ? " , "Formular version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    //txtVersion.ReadOnly = false;
                    //txtVersion.Focus();
                    btnClose.Enabled = false;
                }
                else
                {
                    // Export to CSV
                    _oFBUS.F_OF_DetailsCSV(CD_OF);

                    //Save to OF
                    //OFB.OF_INSERT(gridView1);

                    //Save to OF_Detail
                    //OFB.OF_Detail_INSERT(gridView1);

                    MessageBox.Show("Export to OF :" + CD_OF + " CSV successfully.");
                }                
            }
            else
                MessageBox.Show("Warning : OF :" + CD_OF + " has been exported in the past.");

            //this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < gridView1.RowCount; i++)
            //    gridView1.SetRowCellValue(i, "CD_VER", txtVersion.Text);

            //simpleButton1.Enabled = true;
            //txtVersion.ReadOnly = true;
        }        
    }
}