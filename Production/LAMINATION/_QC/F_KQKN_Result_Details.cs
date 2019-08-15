using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_KQKN_Result_Details : frm_Base
    {
        public Result_KQKN_TD OBJTD = new Result_KQKN_TD();
        private Result_KQKN_KQTT OBJKQTT = new Result_KQKN_KQTT();
        private Result_KQKN_KL OBJKL = new Result_KQKN_KL();

        private Result_KQKN_TDBUS BUSTD = new Result_KQKN_TDBUS();
        private Result_KQKN_KQTTBUS BUSKQTT = new Result_KQKN_KQTTBUS();
        private Result_KQKN_KLBUS BUSKL = new Result_KQKN_KLBUS();
        private KQKN_Template_Details_RowBUS BUSDetailRow = new KQKN_Template_Details_RowBUS();

        private string ArticleType = "";

        public delegate void MyAdd(object sender, string isActionReturn);

        public event MyAdd myFinished;

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this, isActionReturn: isAction);
                }
            }
        }

        private RECEIPTBUS RCB = new RECEIPTBUS();
        private PKNBUS PKB = new PKNBUS();
        public string PassFail = "2";//Unchecked all
        public string ActStatus;
        public int ID;
        public int KQKNTemplateID;
        public int SoPKN;
        public string SoPNK = "";
        public string QCDG = "";
        public string SLNhan = "";
        public string NgayNhan = "";
        public string SoLo = "";
        public string NSX = "";
        public string HSD = "";
        public int Lan;

        public F_KQKN_Result_Details()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Header' table. You can move, or remove it, as needed.
                this.tbl_KQKN_Template_HeaderTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Header);
                // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Header' table. You can move, or remove it, as needed.
                this.tbl_OF_FinishedTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_OF_Finished);

                //this.result_KQKN_Detail_RowTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.Result_KQKN_Detail_Row);

                if (isAction == "Edit")
                {
                    btnSave.Enabled = false;
                    Set4Controls();
                    TDcontrolReadonly(true);
                }
                else if (isAction == "Add")
                {
                    TDcontrolReadonly(true);
                    KQcontrolReadonly(true);
                    KLcontrolEnabled(false);

                    //Set4Controls();

                    chkFG.ReadOnly = false;
                    chkRM.ReadOnly = false;

                    gridControl1.Enabled = false;
                }
                else if (isAction == "View")
                {
                    btnSave.Enabled = false;

                    Set4Controls();

                    TDcontrolReadonly(true);
                    KQcontrolReadonly(true);
                    KLcontrolEnabled(false);

                    btnSave2.Enabled = false;
                }
            };

            btnSave.Click += (s, e) =>
            {
                try
                {
                    btnSave.Enabled = false;

                    if (isAction == "Add")
                    {
                        Set4Object_TDKQKN();

                        BUSTD.Result_KQKN_TD_INSERT(OBJTD);

                        gridControl1.Enabled = true;
                        //--actionMini1.Enabled = true;
                        //Gan gia tri ID moi insert vo table tbl_KQKN_Template_Hedaer cho form
                        OBJTD.ID = BUSTD.MAX_Result_KQKB_TD_ID();

                        //Insert template -> KQPKN
                        foreach (DataRow dr in BUSDetailRow.KQKN_Template_Details_Row_SELECT(OBJTD).Rows)
                        {
                            Set4Object_KQKQKN(dr);
                            BUSKQTT.Result_KQKN_KQTTBUS_INSERT(OBJKQTT);
                        }

                        Set4Object_KLKQKN();
                        BUSKL.Result_KQKN_KLBUS_INSERT(OBJKL);
                    }
                    else if (isAction == "Edit")
                    {
                        btnSave.Enabled = false;

                        Set4Object_KLKQKN();

                        //BUSTD.Result_KQKN_TD_UPDATE(OBJTD);
                    }
                    //MessageBox.Show(OBJTD.SoPKN);
                    gridControl1.DataSource = result_KQKN_Detail_RowTableAdapter.FillBySoPKN(sYNC_NUTRICIELDataSet.Result_KQKN_Detail_Row, OBJTD.SoPKN);

                    Is_close = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };

            lkeKQKNTemplate.TextChanged += (s, e) =>
                {
                    txtSoMRA.Text = lkeKQKNTemplate.GetColumnValue("SoMRA").ToString();
                };
            lkeSoPNK.TextChanged += (s, e) =>
            {
                lkeSoloPNK.Properties.DataSource = RCB.RECEIPT_Lot(lkeSoPNK.EditValue.ToString());
                lkeSoloPNK.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                lkeSoloPNK.Properties.DisplayMember = "NO_LOT";
                lkeSoloPNK.Properties.ValueMember = "NO_LOT";
                lkeSoloPNK.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            };

            lkeSoloPNK.TextChanged += (s, e) =>
            {
                if (isAction == "Add")
                {
                    if (chkRM.CheckState == CheckState.Checked)
                    {
                        DataTable dt = RCB.RECEIPT_ExpDate_ItemName(lkeSoPNK.EditValue.ToString(), lkeSoloPNK.Text.ToString());
                        dteHSD.Text = dt.Rows[0]["DP_PEREMP"].ToString();
                        dteHSD.ReadOnly = true;

                        txtTenNL.Text = dt.Rows[0]["LB_MAT"].ToString();
                        txtTenNL.ReadOnly = true;

                        txtLan.Text = PKB.PKN_Lan(lkeSoloPNK.SelectedText.ToString()).ToString();
                        txtLan.ReadOnly = true;
                    }
                }
            };

            lkeWO.TextChanged += (s, e) =>
            {
                if (isAction == "Add")
                {
                    if (chkFG.CheckState == CheckState.Checked)
                    {
                        //Exp Date
                        //dteHSD.Text = RCB.RECEIPT_ExpDate_ItemName(lkeSoPNK.EditValue.ToString(), lkeSolo.EditValue.ToString()).Rows[0]["DP_PEREMP"].ToString();
                        txtSoloWO.Text = lkeWO.GetColumnValue("CD_OF").ToString();
                        txtSoloWO.ReadOnly = true;

                        txtTenNL.Text = lkeWO.GetColumnValue("LB_MAT").ToString();
                        txtTenNL.ReadOnly = true;

                        txtLan.Text = "1"; //PKB.PKN_Lan(lkeSolo.EditValue.ToString()).ToString();
                        txtLan.ReadOnly = true;

                        if (chkFG.CheckState == CheckState.Checked)
                        {
                            txtSLNhan.Text = lkeWO.GetColumnValue("TOL_QTY_PAK").ToString();
                            txtSLNhan.ReadOnly = true;
                        }
                    }
                }
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

            chkRM.CheckedChanged += (s, e) =>
            {
                if (chkRM.CheckState == CheckState.Checked)
                {
                    lkeSoPNK.Properties.DataSource = "";
                    ////PNK
                    lkeSoPNK.Properties.DataSource = RCB.F_RECEIPT_List();
                    lkeSoPNK.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                    lkeSoPNK.Properties.DisplayMember = "ECH_RECEPS";
                    lkeSoPNK.Properties.ValueMember = "ECH_RECEPS";
                    lkeSoPNK.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

                    chkFG.CheckState = CheckState.Unchecked;
                    cmbSX.SelectedText = "";

                    layoutControlSoMRA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlWO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlSoloWO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlSoPNK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlSoloPNK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    TDcontrolReadonly(true);
                    KQcontrolReadonly(true);
                    KLcontrolEnabled(false);

                    chkFG.ReadOnly = false;
                    chkRM.ReadOnly = false;

                    gridControl1.Enabled = false;
                    txtSoPKN.Text = "";
                    ArticleType = "";
                    ArticleType = "RM";
                }
                else if (chkRM.CheckState == CheckState.Unchecked)
                {
                    chkFG.CheckState = CheckState.Checked;
                    cmbSX.SelectedText = "";
                    TDcontrolReadonly(true);
                    KQcontrolReadonly(true);
                    KLcontrolEnabled(false);

                    layoutControlSoMRA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlWO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlSoloWO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlSoPNK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlSoloPNK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    chkFG.ReadOnly = false;
                    chkRM.ReadOnly = false;

                    gridControl1.Enabled = false;
                    txtSoPKN.Text = "";
                    ArticleType = "";
                    ArticleType = "FP";
                }

                cmbSX.Properties.ReadOnly = false;
            };

            chkFG.CheckedChanged += (s, e) =>
            {
                if (chkFG.CheckState == CheckState.Checked)
                {
                    lkeWO.Properties.DataSource = this.sYNC_NUTRICIELDataSet.tbl_OF_Finished;
                    lkeWO.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
                    lkeWO.Properties.DisplayMember = "CD_OF";
                    lkeWO.Properties.ValueMember = "CD_OF";
                    lkeWO.Properties.Columns.Add(new LookUpColumnInfo("CD_OF"));
                    lkeWO.Properties.Columns.Add(new LookUpColumnInfo("CD_MAT"));
                    lkeWO.Properties.Columns.Add(new LookUpColumnInfo("LB_MAT"));
                    lkeWO.Properties.Columns.Add(new LookUpColumnInfo("TOL_QTY_PAK"));
                    lkeWO.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

                    chkRM.CheckState = CheckState.Unchecked;
                    cmbSX.SelectedText = "";
                    TDcontrolReadonly(true);
                    KQcontrolReadonly(true);
                    KLcontrolEnabled(false);

                    layoutControlSoMRA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlWO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlSoloWO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlSoPNK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlSoloPNK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    chkFG.ReadOnly = false;
                    chkRM.ReadOnly = false;

                    gridControl1.Enabled = false;
                    txtSoPKN.Text = "";
                    ArticleType = "";
                    ArticleType = "FP";
                }
                else if (chkFG.CheckState == CheckState.Unchecked)
                {
                    chkRM.CheckState = CheckState.Checked;
                    cmbSX.SelectedText = "";
                    TDcontrolReadonly(true);
                    KQcontrolReadonly(true);
                    KLcontrolEnabled(false);

                    layoutControlSoMRA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlWO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlSoloWO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlSoPNK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlSoloPNK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    chkFG.ReadOnly = false;
                    chkRM.ReadOnly = false;

                    gridControl1.Enabled = false;
                    txtSoPKN.Text = "";
                    ArticleType = "";
                    ArticleType = "RM";
                }

                cmbSX.Properties.ReadOnly = false;
            };

            cmbSX.EditValueChanged += (s, e) =>
            {
                ArticleType = "";
                if (chkRM.CheckState == CheckState.Checked)
                {
                    ArticleType = "RM";
                }
                else if (chkFG.CheckState == CheckState.Checked)
                {
                    ArticleType = "FP";
                }

                if (cmbSX.EditValue.ToString() == "Nhà máy NPT")
                    ArticleType += "NPT";

                //Sau khi chọn sx tại đâu thì show số PKN
                txtSoPKN.Text = Func_SoPKN(BUSTD.Result_KQKB_TD_SoPNK(ArticleType), ArticleType);
            };
            cmbSX.MouseClick += (s, e) =>
            {
                TDcontrolReadonly(false);
            };
            btnSave2.Click += (s, e) =>
            {
                DialogResult Dlg = XtraMessageBox.Show(" Bạn có muốn lưu lại nội dung vừa thay đổi ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Dlg == DialogResult.No)
                    this.Close();
                else
                {
                    Set4Object_KLKQKN();
                    BUSKL.Result_KQKN_KLBUS_UPDATE(OBJKL);
                }
            };

            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            gridView1.CellValueChanged += (s, e) =>
                {
                    if (e.Column.FieldName == "KQTT")
                    //XtraMessageBox.Show("cell changed");
                    {
                        //PKB.KQPKN_Update(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()), float.Parse(gridView1.GetFocusedRowCellValue("KQTT").ToString()));
                        OBJKQTT.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                        OBJKQTT.KQTT = gridView1.GetFocusedRowCellValue("KQTT").ToString();
                        BUSKQTT.Result_KQKN_KQTTDAO_UPDATE_KQTT_VALUE(OBJKQTT);
                    }
                };

            txtKL.TextChanged += (s, e) =>
            {
                if (isAction == "Edit" || isAction == "Changed")
                {
                    isAction = "Changed";
                    btnSave2.Enabled = true;
                }
            };
            chkFail.CheckStateChanged += (s, e) =>
            {
                if (isAction == "Edit" || isAction == "Changed")
                {
                    isAction = "Changed";
                    btnSave2.Enabled = true;
                }
            };
            chkPass.CheckStateChanged += (s, e) =>
            {
                if (isAction == "Edit" || isAction == "Changed")
                {
                    isAction = "Changed";
                    btnSave2.Enabled = true;
                }
            };
            btnSave2.Click += (s, e) =>
            {
                isAction = "Edit";
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
            RPKN.Lan = 1;//Mac dinh la lay lan 1 --- int.Parse(txtLan.Text.ToString());
            RPKN.Show();
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            //for (int i = 0; i < gridView1.RowCount - 1; i++ )
            //    PKB.KQPKN_Update(gridView1.GetDataRow(i));
        }

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
            if (isAction != "Changed")
                this.Close();
            else
            {
                DialogResult Dlg = XtraMessageBox.Show(" Bạn đã thay đổi nội dung kết luận. Bạn có muốn lưu lại ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Dlg == DialogResult.No)
                    this.Close();
                else
                {
                    Set4Object_KLKQKN();
                    BUSKL.Result_KQKN_KLBUS_UPDATE(OBJKL);
                    this.Close();
                }
            }
        }

        public void TDcontrolReadonly(bool bl)
        {
            this.lkeKQKNTemplate.Properties.ReadOnly = bl;
            txtQCDG.ReadOnly = bl;
            txtSLNhan.ReadOnly = bl;
            lkeSoloPNK.ReadOnly = bl;
            lkeSoPNK.ReadOnly = bl;
            lkeWO.ReadOnly = bl;
            txtSoloWO.ReadOnly = bl;
            dteNgayNhan.ReadOnly = bl;
            dteNgaySX.ReadOnly = bl;
            dteHSD.ReadOnly = bl;
            dteNgayPT.ReadOnly = bl;
            txtTenNL.ReadOnly = bl;
            txtLan.ReadOnly = bl;
            cmbUoM1.Properties.ReadOnly = bl;
            cmbUoM2.Properties.ReadOnly = bl;
            chkRM.ReadOnly = bl;
            chkFG.ReadOnly = bl;
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
        //TextEditChanged
        /////////////////////

        public void Set4Object_TDKQKN()
        {
            //if (isAction == "Edit")
            //    OBJTD.SoPKN = int.Parse(txtSoPKN.Text) ;
            if (isAction == "Add")
                OBJTD.SoPKN = txtSoPKN.Text;

            OBJTD.KQKNTemplateID = int.Parse(lkeKQKNTemplate.EditValue.ToString());
            if (chkRM.CheckState == CheckState.Checked)
            {
                OBJTD.SoPNK = lkeSoPNK.EditValue.ToString();
                OBJTD.Solo = lkeSoloPNK.EditValue.ToString();
            }
            else if (chkFG.CheckState == CheckState.Checked)
            {
                OBJTD.SoMRA = txtSoMRA.Text;
                OBJTD.SoPNK = lkeWO.EditValue.ToString();
                OBJTD.Solo = txtSoloWO.Text.ToString();
            }
            OBJTD.QCDG = txtQCDG.Text + " " + cmbUoM1.Text + "/" + cmbUoM2.Text;
            OBJTD.SLNhan = txtSLNhan.Text;
            OBJTD.NgayNhan = dteNgayNhan.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhan.Text, CultureInfo.CreateSpecificCulture("en-GB"));

            OBJTD.NgaySX = dteNgaySX.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgaySX.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJTD.HSD = dteHSD.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteHSD.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJTD.NgayPT = dteNgayPT.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayPT.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJTD.TenNL = txtTenNL.Text;
            OBJTD.Lan = int.Parse(txtLan.Text.ToString());
            //Details thi ko co note va lock
        }

        public void Set4Object_KQKQKN(DataRow dr)
        {
            OBJKQTT.KQKN_Detail_ID = int.Parse(dr["KQKNTemplateID"].ToString());
            if (isAction == "Edit")
            {
                OBJKQTT.ID = int.Parse(dr["ID"].ToString());
                OBJKQTT.KQTT = dr["KQTT"].ToString();
                OBJKQTT.KQKN_Detail_ID = int.Parse(dr["KQKN_Detail_ID"].ToString());
            }
            else if (isAction == "Add")
                OBJKQTT.KQKN_Detail_ID = int.Parse(dr["ID"].ToString());

            OBJKQTT.Lan = int.Parse(txtLan.Text.ToString());
            OBJKQTT.SoPKN = txtSoPKN.Text;
        }

        public void Set4Object_KLKQKN()
        {
            OBJKL.SoPKN = txtSoPKN.Text;
            OBJKL.KL = txtKL.Text;
            OBJKL.PassFail = chkFail.CheckState == CheckState.Checked ? "Failed" : "Passed";
        }

        public void Set4Controls()
        {
            //TD
            if (isAction == "Edit")
                txtSoPKN.Text = OBJTD.SoPKN;

            lkeKQKNTemplate.EditValue = OBJTD.KQKNTemplateID;
            //lkeSoPNK.Text = OBJTD.SoPNK;
            //lkeSoloPNK.Text = OBJTD.Solo;
            if (chkRM.CheckState == CheckState.Checked)
            {
                lkeSoPNK.Text = OBJTD.SoPNK;
                lkeSoloPNK.Text = OBJTD.Solo;
            }
            else if (chkFG.CheckState == CheckState.Checked)
            {
                txtSoMRA.Text = OBJTD.SoMRA;
                lkeWO.Text = OBJTD.SoPNK;
                txtSoloWO.Text = OBJTD.Solo;
            }

            txtQCDG.Text = OBJTD.QCDG;
            //txtQCDG.Text = OBJTD.QCDG.Substring(0, OBJTD.QCDG.LastIndexOf(" "));
            cmbUoM1.Text = OBJTD.UoM1;
            cmbUoM2.Text = OBJTD.UoM2;
            txtSLNhan.Text = OBJTD.SLNhan;
            dteNgayNhan.Text = OBJTD.NgayNhan.ToString().Substring(0, 10);
            dteNgaySX.Text = OBJTD.NgaySX.ToString().Substring(0, 10);
            dteHSD.Text = OBJTD.HSD.ToString().Substring(0, 10);
            dteNgayPT.Text = OBJTD.NgayPT.ToString().Substring(0, 10);
            txtTenNL.Text = OBJTD.TenNL;
            txtLan.Text = OBJTD.Lan.ToString();

            //KQTT
            gridControl1.DataSource = result_KQKN_Detail_RowTableAdapter.FillBySoPKN(sYNC_NUTRICIELDataSet.Result_KQKN_Detail_Row, OBJTD.SoPKN);

            //KL

            OBJKL = BUSKL.Result_KQKN_KLBUS_SELECT_SoPKN(OBJTD);
            txtKL.Text = OBJKL.KL;
            if (OBJKL.PassFail == "Failed")
            {
                chkFail.CheckState = CheckState.Checked;
                chkPass.CheckState = CheckState.Unchecked;
            }
            else
            {
                chkFail.CheckState = CheckState.Unchecked;
                chkPass.CheckState = CheckState.Checked;
            }

            ////PNK
            //lkeSoPNK.Properties.DataSource = RCB.F_RECEIPT_List();
            //lkeSoPNK.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            //lkeSoPNK.Properties.DisplayMember = "ECH_RECEPS";
            //lkeSoPNK.Properties.ValueMember = "ECH_RECEPS";
            //lkeSoPNK.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }

        public string Func_SoPKN(int SoPKN, string ArtTpe)
        {
            string SoPKN_Text = "";

            switch (SoPKN.ToString().Length)
            {
                case (1):
                    SoPKN_Text = ArtTpe + DateTime.Now.Year.ToString().Substring(2, 2) + "000" + BUSTD.Result_KQKB_TD_SoPNK(ArtTpe).ToString();
                    break;

                case (2):
                    SoPKN_Text = ArtTpe + DateTime.Now.Year.ToString().Substring(2, 2) + "00" + BUSTD.Result_KQKB_TD_SoPNK(ArtTpe).ToString();
                    break;

                case (3):
                    SoPKN_Text = ArtTpe + DateTime.Now.Year.ToString().Substring(2, 2) + "0" + BUSTD.Result_KQKB_TD_SoPNK(ArtTpe).ToString();
                    break;

                case (4):
                    SoPKN_Text = ArtTpe + DateTime.Now.Year.ToString().Substring(2, 2) + BUSTD.Result_KQKB_TD_SoPNK(ArtTpe).ToString();
                    break;
            }
            return SoPKN_Text;
        }
    }
}