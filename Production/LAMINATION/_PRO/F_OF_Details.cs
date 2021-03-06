﻿using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_OF_Details : frm_Base //DevExpress.XtraEditors.XtraForm
    {
        private OF of = new OF();
        private OFBUS OFB = new OFBUS();
        public string CDOF = "";

        public F_OF_Details()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                OFB.F_OF_Detail_View(gridControl1, CDOF);
            };

            btnRevert.Click += (s, e) =>
            {
                if (OFB.F_OF_Find(CDOF).Rows.Count > 0)
                {
                    DialogResult res = MessageBox.Show("Bạn muốn bỏ OF đã xuất ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        OFB.OF_REVERT(CDOF);
                        MessageBox.Show("Gỡ OF thành công");
                    }
                }
                else
                    MessageBox.Show("OF :" + CDOF + " chưa xuất CSV, không cần revert");
            };

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (OFB.F_OF_Find(CDOF).Rows.Count <= 0)
            {
                DialogResult dlDel = XtraMessageBox.Show(" Update formular version ? " , "Formular version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    txtVersion.ReadOnly = false;
                    txtVersion.Focus();
                    simpleButton1.Enabled = false;
                }
                else
                {
                    // Export to CSV
                    OFB.F_OF_DetailsCSV(CDOF);

                    //Save to OF
                    OFB.OF_INSERT(gridView1);

                    //Save to OF_Detail
                    OFB.OF_Detail_INSERT(gridView1);

                    MessageBox.Show("Export to OF :" + CDOF + " CSV successfully.");
                }
                
            }
            else
                MessageBox.Show("Warning : OF :" + CDOF + " has been exported in the past.");

            //this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
                gridView1.SetRowCellValue(i, "CD_VER", txtVersion.Text);

            simpleButton1.Enabled = true;
            txtVersion.ReadOnly = true;
        }
    }
}