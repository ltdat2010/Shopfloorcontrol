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
    public partial class frm_COA : frm_Base
    {
        COABUS COB = new COABUS();        
        public string CD_OF ;
        public string LB_MAT;
        public string ActStatus ;
        public string SoCOA ;                              
        public frm_COA()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                //XtraMessageBox.Show("WO : "+CD_OF.ToString());
                gridControl1.DataSource = COB.KQCOA_Search_COAID(0, "null");
                gridControl2.DataSource = COB.KQCOA_Search_COAID(0, "null");
                        
                action1.Add_Status(false);
                action1.Edit_Status(false);
                //controlReadonly(true);                
                tbl_COATableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA_Template_Header);
                //if (COB.TDCOA_Visible(CD_OF).Rows.Count > 0)
                //    ActStatus = "E";
                //else
                //    ActStatus = "N";
                //XtraMessageBox.Show(ActStatus);
                if (ActStatus == "E")
                {
                    //XtraMessageBox.Show(SoCOA.ToString());
                    DataTable dt                            = new DataTable();
                    //dt                                      = COB.TDCOA_Search(CD_OF);
                    dt                                      = COB.TDCOA_Search(SoCOA);
                    DataRow dr                              = dt.Rows[0];
                    //XtraMessageBox.Show(dr["SoPNK"].ToString());
                    txtSoCOA.Text = dr["SoCOA"].ToString();
                    txtWO.EditValue = dr["WO"].ToString();                   
                    //txtSolo.EditValue                       = dr["Solo"].ToString();
                    //txtSLNhan.Text                          = dr["SLNhan"].ToString();
                    lkeTemplate.EditValue = dr["COATemplateID"].ToString();
                    txtManfBy.Text = dr["ManfBy"].ToString();
                    dteSmpDate.Text = dr["SmpDate"].ToString();
                    dteAnlDate.Text = dr["AnlDate"].ToString();
                    dteManfDate.Text = dr["ManfDate"].ToString();
                    dteExpDate.Text = dr["ExpDate"].ToString();                    
                    gridControl1.DataSource = COB.KQCOA_Search(dr["SoCOA"].ToString(),"Physical");
                    gridView1.BestFitColumns();
                    gridControl2.DataSource = COB.KQCOA_Search(dr["SoCOA"].ToString(), "Chemical");
                    gridView2.BestFitColumns();
                }
                else if (ActStatus == "N")
                {
                    KQcontrolReadonly(true);
                    
                    //PKN
                    txtSoCOA.Text = COB.COA_Template_Max_COAID().ToString();
                    //PNK
                    //txtSoPNK.Properties.DataSource          = RCB.F_RECEIPT_List();
                    //txtSoPNK.Properties.SearchMode          = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                    //txtSoPNK.Properties.DisplayMember       = "ECH_RECEPS";
                    //txtSoPNK.Properties.ValueMember         = "ECH_RECEPS";
                    //txtSoPNK.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    txtWO.Text = CD_OF.ToString();
                }
                else if (ActStatus == "V")
                {
                    
                    DataTable dt = new DataTable();
                    dt = COB.TDCOA_Search(SoCOA);
                    //XtraMessageBox.Show(dt.Rows.Count.ToString());
                    DataRow dr = dt.Rows[0];
                    //XtraMessageBox.Show(dr["SoPNK"].ToString());
                    txtSoCOA.Text = dr["SoCOA"].ToString();
                    txtWO.EditValue = dr["WO"].ToString();
                    //txtSoPNK.EditValue = dr["SoPNK"].ToString();
                    //txtSolo.EditValue = dr["Solo"].ToString();
                    //txtSLNhan.Text = dr["SLNhan"].ToString();
                    txtManfBy.Text = dr["ManfBy"].ToString();
                    dteSmpDate.Text = dr["SmpDate"].ToString();
                    dteAnlDate.Text = dr["AnlDate"].ToString();
                    dteManfDate.Text = dr["ManfDate"].ToString();
                    dteExpDate.Text = dr["ExpDate"].ToString();

                    gridControl1.DataSource = COB.KQCOA_Search(dr["SoCOA"].ToString(), "Physical");
                    gridView1.BestFitColumns();
                    gridControl2.DataSource = COB.KQCOA_Search(dr["SoCOA"].ToString(), "Chemical");
                    gridView2.BestFitColumns();
                    TDcontrolReadonly(true);
                    KQcontrolReadonly(true);
                    
                }
                    


                //txtWO.Properties.DataSource       = PKB.PKN_Template_View();
                //txtWO.Properties.SearchMode       = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                //txtWO.Properties.DisplayMember    = "KQKN";
                //txtWO.Properties.ValueMember      = "ID";
                //txtWO.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                //txtSoPNK.Text = SoPNK;
                //txtSolo.Text = SoLo;
                //txtQCDG.Text = QCDG;
                //dteNSX.Text = NSX;
                //dteHSD.Text = HSD;
                //if(PKB.KQPKN_Visible(SoPNK,SoLo).Rows.Count > 0)

                //else

            };
            lkeTemplate.TextChanged += (s, e) =>
            {
                gridControl1.DataSource = COB.KQCOA_Search_COAID(int.Parse(lkeTemplate.EditValue.ToString()), "Physical");
                gridControl2.DataSource = COB.KQCOA_Search_COAID(int.Parse(lkeTemplate.EditValue.ToString()), "Chemical");
            };

            gridView1.CellValueChanged += (s, e) =>
            {
                if (e.Column.FieldName == "Result")
                {
                    //XtraMessageBox.Show(gridView1.GetFocusedRowCellValue("Result").ToString());

                    //XtraMessageBox.Show(gridView1.GetFocusedRowCellValue("COATemplateID").ToString());
                    COB.KQCOA_Update(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()), gridView1.GetFocusedRowCellValue("Result").ToString());
                }
                    
            };

            gridView2.CellValueChanged += (s, e) =>
            {
                if (e.Column.FieldName == "Result")
                    COB.KQCOA_Update(int.Parse(gridView2.GetFocusedRowCellValue("ID").ToString()), gridView2.GetFocusedRowCellValue("Result").ToString());
            };

            //txtSoPNK.TextChanged += (s, e) =>
            //    {
            //        //XtraMessageBox.Show(txtSoPNK.EditValue.ToString());
            //        //Lot
            //        txtSolo.Properties.DataSource           = RCB.RECEIPT_Lot(txtSoPNK.EditValue.ToString());
            //        txtSolo.Properties.SearchMode           = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            //        txtSolo.Properties.DisplayMember        = "NO_LOT";
            //        txtSolo.Properties.ValueMember          = "NO_LOT";
            //        txtSolo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //    };

            //txtSolo.TextChanged += (s, e) =>
            //{
            //    //Exp Date
            //    dteHSD.Text = RCB.RECEIPT_ExpDate(txtSoPNK.EditValue.ToString(), txtSolo.EditValue.ToString()).Rows[0]["DP_PEREMP"].ToString(); 
            //};
            ///////////////////////////////
            // 0 : Fail
            // 1 : Pass
            // 2 : Unchecked all
            ///////////////////////////////
            //chkPass.CheckedChanged += (s, e) =>
            //{
            //    if (chkPass.CheckState == CheckState.Checked)
            //    {
            //        PassFail = "1";
            //        chkFail.CheckState = CheckState.Unchecked;
            //    }                    
            //    else
            //    {
            //        PassFail = "0";
            //        chkFail.CheckState = CheckState.Checked;
            //    }                   

            //};

            //chkFail.CheckedChanged += (s, e) =>
            //{
            //    if (chkFail.CheckState == CheckState.Checked)
            //    {
            //        PassFail = "0";
            //        chkPass.CheckState = CheckState.Unchecked;
            //    }
            //    else
            //    {
            //        PassFail = "1";
            //        chkPass.CheckState = CheckState.Checked;
            //    }
            //};

            btnSave.Click += (s, e) =>
                {
                    //XtraMessageBox.Show(dteSmpDate.Text.Length == 0 ? DateTime.Today.ToString() : DateTime.Parse(dteSmpDate.Text, CultureInfo.CreateSpecificCulture("en-GB")).ToString());
                    if (COB.TDCOA_Visible(txtWO.Text.ToString()).Rows.Count <= 0)
                    {
                        COB.TDCOA_Insert(int.Parse(txtSoCOA.Text.ToString())
                            ,int.Parse(lkeTemplate.EditValue.ToString())
                            ,txtWO.Text
                            ,txtManfBy.Text
                            , dteSmpDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteSmpDate.Text.ToString())
                            , dteExpDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteExpDate.Text.ToString())
                            , dteAnlDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteAnlDate.Text.ToString())
                            , dteManfDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteManfDate.Text.ToString())
                            ,LB_MAT);
                        //XtraMessageBox.Show(dteNgayNhan.Text.Length == 0 ? DateTime.Today.ToString() : DateTime.Parse(dteNgayNhan.Text, CultureInfo.CreateSpecificCulture("en-GB")).ToString());
                        //Insert TieuDe PKN
                        //PKB.TDPKN_Insert(
                        //                txtSoCOA.Text,
                        //                int.Parse(lkeKQKNTemplate.EditValue.ToString()),
                        //                //txtSoPNK.EditValue.ToString(),
                        //                txtQCDG.Text,
                        //                //txtSLNhan.Text,
                        //                dteNgayNhan.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhan.Text, CultureInfo.CreateSpecificCulture("en-GB")),
                        //                //txtSolo.EditValue.ToString(),
                        //                dteNgaySX.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgaySX.Text, CultureInfo.CreateSpecificCulture("en-GB")),
                        //                dteHSD.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteHSD.Text, CultureInfo.CreateSpecificCulture("en-GB")),
                        //                //dteNgayPT.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayPT.Text, CultureInfo.CreateSpecificCulture("en-GB"))
                        //                );
                        //Insert template -> KQPKN
                        //foreach (DataRow dr in COB.COA_Template_Search(int.Parse(txtWO.EditValue.ToString())).Rows)
                            //COB.KQCOA_Insert(int.Parse(txtSoCOA.Text), dr);
                        for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
                            COB.KQCOA_Insert(int.Parse(txtSoCOA.Text), gridView1.GetDataRow(i));

                        for (int i = 0; i <= gridView2.DataRowCount - 1; i++)
                            COB.KQCOA_Insert(int.Parse(txtSoCOA.Text), gridView2.GetDataRow(i));

                        gridControl1.DataSource = COB.KQCOA_Search(txtSoCOA.Text.ToString(), "Physical");
                        gridControl2.DataSource = COB.KQCOA_Search(txtSoCOA.Text.ToString(), "Chemical");
                        //PKB.KLPKN_Insert(int.Parse(txtSoCOA.Text.ToString()), txtKL.Text, PassFail);                        
                        gridView1.BestFitColumns();                        
                        gridView2.BestFitColumns();
                        TDcontrolReadonly(true);
                        btnSave.Enabled = false;
                        KQcontrolReadonly(false);
                        
                    }
                };
            //btnSave2.Click += (s, e) =>
            //    {
            //        PKB.KLPKN_Update(int.Parse(txtSoCOA.Text.ToString()),txtKL.Text,PassFail);
            //    };

            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
            //action1.Cancel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Cancel));
            gridView1.CellValueChanged += (s, e) =>
                {
                    if (e.Column.FieldName == "Result")
                        //XtraMessageBox.Show("cell changed");
                        COB.KQCOA_Update(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()),gridView1.GetFocusedRowCellValue("Result").ToString());
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
            R_COA RCOA = new R_COA();
            RCOA.SoCOA = txtSoCOA.Text.ToString();
            RCOA.Show();
            //for (int i = 0; i < gridView1.RowCount - 1; i++ )
            //    PKB.KQPKN_Update(gridView1.GetDataRow(i));
        }

        private void ItemClickEventHandler_Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            //for (int i = 0; i < gridView1.RowCount - 1; i++ )
            //    PKB.KQPKN_Update(gridView1.GetDataRow(i));
        }

        public void TDcontrolReadonly(bool bl)
        {
            this.txtWO.Properties.ReadOnly              = bl;
            txtManfBy.ReadOnly                          = bl;
            lkeTemplate.Properties.ReadOnly             = bl;
            txtManfBy.ReadOnly                          = bl;
            dteAnlDate.ReadOnly                         = bl;
            dteExpDate.ReadOnly                         = bl;
            dteManfDate.ReadOnly                        = bl;
            dteSmpDate.ReadOnly                         = bl;   
            

        }
        public void KQcontrolReadonly(bool bl)
        {
            gridView1.OptionsBehavior.ReadOnly = bl;
            gridView2.OptionsBehavior.ReadOnly = bl;
        }        

        private void frm_COA_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_Control' table. You can move, or remove it, as needed.
            this.tbl_ControlTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_Control);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_COA' table. You can move, or remove it, as needed.
            this.tbl_COATableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_COA_Template_Header);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KQCOA' table. You can move, or remove it, as needed.
            //this.tbl_KQCOATableAdapter.FillBySoPKN(this.sYNC_NUTRICIELDataSet.tbl_KQCOA);

        }
        /////////////////////
        //Set popup width for LookupEdit
        /////////////////////
                
    }
}
