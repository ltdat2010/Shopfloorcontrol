using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using DevExpress.XtraGrid;
using System.Globalization;

namespace Production.Class
{
    public partial class frm_PKN : frm_Base
    {
        RECEIPTBUS RCB = new RECEIPTBUS();
        PKNBUS PKB = new PKNBUS();
        public string PassFail                                  ="2";//Unchecked all
        public string ActStatus;
        public int ID;
        public int KQKNTemplateID;
        public string SoPKN;
        public string SoPNK                                     = "";
        public string QCDG                                      = "";
        public string SLNhan                                    = "";
        public string NgayNhan                                  = "";
        public string SoLo                                      = "";
        public string NSX                                       = "";
        public string HSD                                       = "";
        public int Lan = 0;
        public frm_PKN()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                action1.Add_Status(false);
                action1.Edit_Status(false);
                //controlReadonly(true);                


                if (ActStatus == "E")
                {
                    
                    DataTable dt                            = new DataTable();
                    dt                                      = PKB.TDPKN_Search(SoPKN, Lan);
                    DataRow dr                              = dt.Rows[0];
                    //XtraMessageBox.Show(dr["SoPNK"].ToString());
                    txtSoPKN.Text                           = dr["SoPKN"].ToString();
                    lkeKQKNTemplate.EditValue               = dr["KQKNTemplateID"].ToString();
                    txtSoPNK.EditValue                      = dr["SoPNK"].ToString();
                    txtSolo.EditValue                       = dr["Solo"].ToString();
                    txtSLNhan.Text                          = dr["SLNhan"].ToString();
                    txtQCDG.Text                            = dr["QCDG"].ToString();
                    dteNgaySX.Text                          = dr["NgaySX"].ToString();
                    dteHSD.Text                             = dr["HSD"].ToString();
                    dteNgayNhan.Text                        = dr["NgayNhan"].ToString();
                    dteNgayPT.Text                          = dr["NgayPT"].ToString();
                    txtLan.Text                             = dr["Lan"].ToString();
                    gridControl1.DataSource = PKB.KQPKN_Search(dr["SoPKN"].ToString());
                    gridView1.BestFitColumns();
                }
                else if (ActStatus == "N")
                {
                    KQcontrolReadonly(true);
                    KLcontrolEnabled(false);
                    //PKN
                    txtSoPKN.Text                           = PKB.PKN_Template_Max_KQKNID().ToString();
                    
                    
                }
                else if (ActStatus == "V")
                {
                    //XtraMessageBox.Show("SoPKN : " + SoPKN.ToString());
                    //XtraMessageBox.Show("SoPNK : " + SoPNK.ToString());
                    DataTable dt = new DataTable();
                    //dt = PKB.TDPKN_Search(SoPKN, Lan);
                    dt = PKB.TDPKN_Search(SoPKN, 1);
                    DataRow dr = dt.Rows[0];
                    //XtraMessageBox.Show(dr["SoPNK"].ToString());
                    txtSoPKN.Text = dr["SoPKN"].ToString();
                    lkeKQKNTemplate.EditValue = dr["KQKNTemplateID"].ToString();
                    txtSoPNK.EditValue = dr["SoPNK"].ToString();
                    txtSolo.EditValue = dr["Solo"].ToString();
                    txtSLNhan.Text = dr["SLNhan"].ToString();
                    txtQCDG.Text = dr["QCDG"].ToString();
                    dteNgaySX.Text = dr["NgaySX"].ToString();
                    dteHSD.Text = dr["HSD"].ToString();
                    dteNgayNhan.Text = dr["NgayNhan"].ToString();
                    dteNgayPT.Text = dr["NgayPT"].ToString();
                    txtLan.Text = dr["Lan"].ToString();
                    //XtraMessageBox.Show("1");
                    gridControl1.DataSource = PKB.KQPKN_Search(dr["SoPKN"].ToString());
                    gridView1.BestFitColumns();
                    TDcontrolReadonly(true);
                    KQcontrolReadonly(true);
                    KLcontrolEnabled(false);
                    //XtraMessageBox.Show("2");
                }

                //PNK
                txtSoPNK.Properties.DataSource = RCB.F_RECEIPT_List();
                txtSoPNK.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                txtSoPNK.Properties.DisplayMember = "ECH_RECEPS";
                txtSoPNK.Properties.ValueMember = "ECH_RECEPS";
                txtSoPNK.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                //TC
                lkeKQKNTemplate.Properties.DataSource       = PKB.PKN_Template_View();
                lkeKQKNTemplate.Properties.SearchMode       = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                lkeKQKNTemplate.Properties.DisplayMember    = "KQKN";
                lkeKQKNTemplate.Properties.ValueMember      = "ID";
                lkeKQKNTemplate.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                //txtSoPNK.Text = SoPNK;
                //txtSolo.Text = SoLo;
                //txtQCDG.Text = QCDG;
                //dteNSX.Text = NSX;
                //dteHSD.Text = HSD;
                //if(PKB.KQPKN_Visible(SoPNK,SoLo).Rows.Count > 0)

                //else

            };
            txtSoPNK.TextChanged += (s, e) =>
                {
                    //XtraMessageBox.Show(txtSoPNK.EditValue.ToString());
                    //Lot
                    txtSolo.Properties.DataSource           = RCB.RECEIPT_Lot(txtSoPNK.EditValue.ToString());
                    txtSolo.Properties.SearchMode           = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                    txtSolo.Properties.DisplayMember        = "NO_LOT";
                    txtSolo.Properties.ValueMember          = "NO_LOT";
                    txtSolo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                };

            txtSolo.TextChanged += (s, e) =>
            {
                if (ActStatus != "V")
                {
                    dteHSD.Text = RCB.RECEIPT_ExpDate_ItemName(txtSoPNK.EditValue.ToString(), txtSolo.EditValue.ToString()).Rows[0]["DP_PEREMP"].ToString();
                    txtTenNL.Text = RCB.RECEIPT_ExpDate_ItemName(txtSoPNK.EditValue.ToString(), txtSolo.EditValue.ToString()).Rows[0]["LB_MAT"].ToString();

                }
                //Exp Date
                if (ActStatus == "N")
                    LayoutControlLan.Text                                 = PKB.PKN_Lan(txtSolo.EditValue.ToString()).ToString();
            };
            ///////////////////////////////
            // 0 : Fail
            // 1 : Pass
            // 2 : Unchecked all
            ///////////////////////////////
            chkPass.CheckedChanged += (s, e) =>
            {
                if (chkPass.CheckState == CheckState.Checked)
                {
                    PassFail = "1";
                    chkFail.CheckState = CheckState.Unchecked;
                }                    
                else
                {
                    PassFail = "0";
                    chkFail.CheckState = CheckState.Checked;
                }                   

            };

            chkFail.CheckedChanged += (s, e) =>
            {
                if (chkFail.CheckState == CheckState.Checked)
                {
                    PassFail = "0";
                    chkPass.CheckState = CheckState.Unchecked;
                }
                else
                {
                    PassFail = "1";
                    chkPass.CheckState = CheckState.Checked;
                }
            };

            btnSave.Click += (s, e) =>
                {
                    if (PKB.TDPKN_Visible(SoPNK, SoLo).Rows.Count <= 0)
                    {
                        //XtraMessageBox.Show(dteNgayNhan.Text.Length == 0 ? DateTime.Today.ToString() : DateTime.Parse(dteNgayNhan.Text, CultureInfo.CreateSpecificCulture("en-GB")).ToString());
                        //Insert TieuDe PKN
                        PKB.TDPKN_Insert(
                                        txtSoPKN.Text,
                                        int.Parse(lkeKQKNTemplate.EditValue.ToString()),
                                        txtSoPNK.EditValue.ToString(),
                                        txtQCDG.Text,
                                        txtSLNhan.Text,
                                        dteNgayNhan.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhan.Text, CultureInfo.CreateSpecificCulture("en-GB")),
                                        txtSolo.EditValue.ToString(),
                                        dteNgaySX.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgaySX.Text, CultureInfo.CreateSpecificCulture("en-GB")),
                                        dteHSD.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteHSD.Text, CultureInfo.CreateSpecificCulture("en-GB")),
                                        dteNgayPT.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayPT.Text, CultureInfo.CreateSpecificCulture("en-GB")),
                                        txtTenNL.Text,
                                        int.Parse(LayoutControlLan.Text.ToString()));
                        //Insert template -> KQPKN
                        foreach (DataRow dr in PKB.PKN_Template_Search(int.Parse(lkeKQKNTemplate.EditValue.ToString())).Rows)
                            PKB.KQPKN_Insert(int.Parse(txtSoPKN.Text), dr);
                        //
                        gridControl1.DataSource = PKB.KQPKN_Search(txtSoPKN.Text.ToString());

                        PKB.KLPKN_Insert(int.Parse(txtSoPKN.Text.ToString()), txtKL.Text, PassFail, int.Parse(LayoutControlLan.Text.ToString()));

                        KQcontrolReadonly(false);
                        KLcontrolEnabled(true);
                    }
                };
            btnSave2.Click += (s, e) =>
                {
                    PKB.KLPKN_Update(int.Parse(txtSoPKN.Text.ToString()),txtKL.Text,PassFail);
                };

            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
            //action1.Cancel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Cancel));
            gridView1.CellValueChanged += (s, e) =>
                {
                    if (e.Column.FieldName == "KQTT")
                        //XtraMessageBox.Show("cell changed");
                        PKB.KQPKN_Update(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()),float.Parse(gridView1.GetFocusedRowCellValue("KQTT").ToString()));
                };            
        }
        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            try
            {
                TDcontrolReadonly(false);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            R_PKN RPKN = new R_PKN();
            RPKN.SoPKN = txtSoPKN.Text.ToString();
            if( this.Lan == 1 )
                RPKN.Lan = 1; //Mặc định gán = 1 ---- int.Parse(txtLan.Text.ToString());
            else
                RPKN.Lan = int.Parse(txtLan.Text.ToString());
            RPKN.Show();
            //for (int i = 0; i < gridView1.RowCount - 1; i++ )
            //    PKB.KQPKN_Update(gridView1.GetDataRow(i));
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            //for (int i = 0; i < gridView1.RowCount - 1; i++ )
            //    PKB.KQPKN_Update(gridView1.GetDataRow(i));
        }

        private void ItemClickEventHandler_Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        public void TDcontrolReadonly(bool bl)
        {
            this.lkeKQKNTemplate.Properties.ReadOnly = bl;
            txtQCDG.ReadOnly = bl;
            txtSLNhan.ReadOnly = bl;
            txtSolo.ReadOnly = bl;
            txtSoPNK.ReadOnly = bl;            

        }
        public void KQcontrolReadonly(bool bl)
        {
            gridView1.OptionsBehavior.ReadOnly = bl;

        }
        public void KLcontrolEnabled(bool bl)
        {
            txtKL.Enabled = bl;
            chkFail.Enabled = bl;
            chkPass.Enabled = bl;
            btnSave2.Enabled = bl;

        }
        /////////////////////
        //Set popup width for LookupEdit
        /////////////////////
                
    }
}
