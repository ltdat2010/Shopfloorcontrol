using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_COA_Result_Details : frm_Base
    {
        public Result_COA_TD OBJTD = new Result_COA_TD();
        private Result_COA_KQ OBJKQ = new Result_COA_KQ();

        private Result_COA_TDBUS BUSTD = new Result_COA_TDBUS();
        private Result_COA_KQBUS BUSKQ = new Result_COA_KQBUS();

        private COA_Template_DetailsBUS BUSDetail = new COA_Template_DetailsBUS();

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

        public F_COA_Result_Details()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Header' table. You can move, or remove it, as needed.
                //this.tbl_KQKN_Template_HeaderTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Header);

                if (isAction == "Edit")
                {
                    btnSave.Enabled = false;
                    Set4Controls();
                    TDcontrolReadonly(true);
                }
                else if (isAction == "Add")
                {
                    txtSoCOA.Text = Func_SoCOA_NPT(BUSTD.Result_COA_TD_SoCOA());
                    gridControl1.Enabled = false;
                }
                else if (isAction == "View")
                {
                    btnSave.Enabled = false;

                    Set4Controls();

                    TDcontrolReadonly(true);
                    KQcontrolReadonly(true);

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

                        BUSTD.Result_COA_TDBUS_INSERT(OBJTD);

                        gridControl1.Enabled = true;
                        //--actionMini1.Enabled = true;
                        //Gan gia tri ID moi insert vo table tbl_KQKN_Template_Hedaer cho form
                        OBJTD.ID = BUSTD.MAX_Result_COA_TD_ID();
                        //Insert template -> KQPKN
                        foreach (DataRow dr in BUSDetail.COA_Template_Details_SELECT(OBJTD).Rows)
                        {
                            Set4Object_KQCOA(dr);
                            BUSKQ.Result_COA_KQDAO_INSERT(OBJKQ);
                        }

                        btnSave2.Enabled = true;
                    }
                    else if (isAction == "Edit")
                    {
                        btnSave.Enabled = false;

                        //Set4Controls();

                        //BUSTD.Result_KQKN_TD_UPDATE(OBJTD);
                    }

                    gridControl1.DataSource = tbl_Result_COA_KQTableAdapter.FillBySoCOA(sYNC_NUTRICIELDataSet.tbl_Result_COA_KQ, OBJTD.SoCOA);

                    Is_close = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };

            //lkeSolo.TextChanged += (s, e) =>
            //{
            //    if (isAction == "Add")
            //    {
            //        //Exp Date
            //        dteHSD.Text = RCB.RECEIPT_ExpDate_ItemName(lkeSoPNK.EditValue.ToString(), lkeSolo.EditValue.ToString()).Rows[0]["DP_PEREMP"].ToString();
            //        txtTenNL.Text = RCB.RECEIPT_ExpDate_ItemName(lkeSoPNK.EditValue.ToString(), lkeSolo.EditValue.ToString()).Rows[0]["LB_MAT"].ToString();
            //        txtLan.Text = PKB.PKN_Lan(lkeSolo.EditValue.ToString()).ToString();
            //    }

            //};
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

            //btnSave.Click += (s, e) =>
            //    {
            //        if (PKB.TDPKN_Visible(SoPNK, SoLo).Rows.Count <= 0)
            //        {
            //            //XtraMessageBox.Show(dteNgayNhan.Text.Length == 0 ? DateTime.Today.ToString() : DateTime.Parse(dteNgayNhan.Text, CultureInfo.CreateSpecificCulture("en-GB")).ToString());
            //            //Insert TieuDe PKN
            //            //PKB.TDPKN_Insert(
            //            //                txtSoPKN.Text,
            //            //                int.Parse(lkeKQKNTemplate.EditValue.ToString()),
            //            //                txtSoPNK.EditValue.ToString(),
            //            //                txtQCDG.Text,
            //            //                txtSLNhan.Text,
            //            //                dteNgayNhan.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhan.Text, CultureInfo.CreateSpecificCulture("en-GB")),
            //            //                txtSolo.EditValue.ToString(),
            //            //                dteNgaySX.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgaySX.Text, CultureInfo.CreateSpecificCulture("en-GB")),
            //            //                dteHSD.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteHSD.Text, CultureInfo.CreateSpecificCulture("en-GB")),
            //            //                dteNgayPT.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayPT.Text, CultureInfo.CreateSpecificCulture("en-GB")),
            //            //                txtTenNL.Text,
            //            //                int.Parse(LayoutControlLan.Text.ToString()));
            //            //Insert template -> KQPKN
            //            //foreach (DataRow dr in BUS)
            //                //PKB.KQPKN_Insert(int.Parse(txtSoPKN.Text), dr);
            //            //
            //            gridControl1.DataSource = PKB.KQPKN_Search(int.Parse(txtSoPKN.Text.ToString()));

            //            PKB.KLPKN_Insert(int.Parse(txtSoPKN.Text.ToString()), txtKL.Text, PassFail, int.Parse(LayoutControlLan.Text.ToString()));

            //            KQcontrolReadonly(false);
            //            KLcontrolEnabled(true);
            //        }
            //    };
            btnSave2.Click += (s, e) =>
                {
                    DialogResult Dlg = XtraMessageBox.Show(" Bạn có muốn lưu lại nội dung vừa thay đổi ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Dlg == DialogResult.No)
                        this.Close();
                    else
                    {
                        //Set4Object_KLKQKN();
                        //BUSKL.Result_KQKN_KLBUS_UPDATE(OBJKL);
                    }
                };

            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            gridView1.CellValueChanged += (s, e) =>
                {
                    if (e.Column.FieldName == "Result")
                    //XtraMessageBox.Show("cell changed");
                    {
                        OBJKQ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                        OBJKQ.Result = gridView1.GetFocusedRowCellValue("Result").ToString();
                        BUSKQ.Result_COA_KQDAO_UPDATE_VALUE(OBJKQ);

                        //PKB.KQPKN_Update(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()), float.Parse(gridView1.GetFocusedRowCellValue("KQTT").ToString()));
                        //OBJKQTT.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                        //OBJKQTT.KQTT = gridView1.GetFocusedRowCellValue("KQTT").ToString();
                        //BUSKQTT.Result_KQKN_KQTTDAO_UPDATE_KQTT_VALUE(OBJKQTT);
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
            R_COA_SelectLanguage RPKN = new R_COA_SelectLanguage();
            RPKN.SoCOA = txtSoCOA.Text;
            //RPKN.Lan = 1; //Mac dinh la lay lan 1 --- int.Parse(txtLan.Text.ToString());
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
                    //Set4Object_KLKQKN();
                    //BUSKL.Result_KQKN_KLBUS_UPDATE(OBJKL);
                    this.Close();
                }
            }
        }

        public void TDcontrolReadonly(bool bl)
        {
            txtSoCOA.ReadOnly = bl;
            lkeSolo.ReadOnly = bl;
            dteNgayLayMau.ReadOnly = bl;
            dteNgaySX.ReadOnly = bl;
            dteHSD.ReadOnly = bl;
            dteNgayPT.ReadOnly = bl;
            lkeTenTP.ReadOnly = bl;
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
            if (isAction == "Edit")
            {
                OBJTD.ID = int.Parse(txtID.Text);
            }

            //if (isAction == "Add")
            //OBJTD.SoPKN = txtSoPKN.Text;

            //OBJTD.ID = int.Parse(lkeKQKNTemplate.EditValue.ToString());
            //OBJTD.SoCOA = int.Parse(lkeKQKNTemplate.EditValue.ToString());
            ////OBJTD.COATemplateID = lkeSoPNK.EditValue.ToString();
            //OBJTD.WO = txtQCDG.Text+ " "+ cmbUoM1.Text + "/" + cmbUoM2.Text;
            OBJTD.COATemplateID = int.Parse(lkeTenTP.EditValue.ToString());
            OBJTD.ManfBy = cmbSX.SelectedText.ToString();
            OBJTD.SmpDate = dteNgayLayMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayLayMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJTD.LB_MAT = lkeSolo.EditValue.ToString();
            OBJTD.AnlDate = dteNgaySX.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayPT.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJTD.ManfDate = dteHSD.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgaySX.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJTD.ExpDate = dteNgayPT.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteHSD.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJTD.SoCOA = txtSoCOA.Text;
            OBJTD.WO = lkeSolo.EditValue.ToString();
            //OBJTD.Note = txtTenNL.Text;
            //OBJTD.Lan = int.Parse(txtLan.Text.ToString());
            //OBJTD.Locked = ;
        }

        public void Set4Object_KQCOA(DataRow dr)
        {
            if (isAction == "Edit")
            {
                OBJKQ.ID = int.Parse(dr["ID"].ToString());
                OBJKQ.Result = dr["Result"].ToString();
            }
            else if (isAction == "Add")
                OBJKQ.COA_Template_Details_ID = int.Parse(dr["ID"].ToString());

            OBJKQ.SoCOA = txtSoCOA.Text;
        }

        public void Set4Controls()
        {
            //TD
            //if ( isAction == "Edit")
            //    txtSoPKN.Text = OBJTD.SoPKN;
            ////txtID.Text = OBJTD.ID;
            //lkeKQKNTemplate.EditValue = OBJTD.KQKNTemplateID ;
            //lkeSoPNK.Text = OBJTD.SoPNK;
            //txtQCDG.Text = OBJTD.QCDG;
            ////txtQCDG.Text = OBJTD.QCDG.Substring(0, OBJTD.QCDG.LastIndexOf(" "));
            //cmbUoM1.Text = OBJTD.UoM1;
            //cmbUoM2.Text = OBJTD.UoM2;
            //txtSLNhan.Text = OBJTD.SLNhan;
            //dteNgayNhan.Text = OBJTD.NgayNhan.ToString().Substring(0,10) ;
            //lkeSolo.Text = OBJTD.Solo;
            //dteNgaySX.Text = OBJTD.NgaySX.ToString().Substring(0, 10);
            //dteHSD.Text = OBJTD.HSD.ToString().Substring(0, 10);
            //dteNgayPT.Text  = OBJTD.NgayPT.ToString().Substring(0, 10);
            //txtTenNL.Text = OBJTD.TenNL ;
            //txtLan.Text = OBJTD.Lan.ToString();

            //KQTT
            //gridControl1.DataSource = result_KQKN_Detail_RowTableAdapter.FillBySoPKN(sYNC_NUTRICIELDataSet.Result_KQKN_Detail_Row, OBJTD.SoPKN);

            lkeTenTP.EditValue = OBJTD.COATemplateID;
            cmbSX.SelectedText = OBJTD.ManfBy;
            dteNgayLayMau.Text = OBJTD.SmpDate.ToString().Substring(0, 10);
            dteNgaySX.Text = OBJTD.AnlDate.ToString().Substring(0, 10);
            dteHSD.Text = OBJTD.ManfDate.ToString().Substring(0, 10);
            dteNgayPT.Text = OBJTD.ExpDate.ToString().Substring(0, 10);
            txtSoCOA.Text = OBJTD.SoCOA;
            //XtraMessageBox.Show(OBJTD.WO);
            lkeSolo.EditValue = OBJTD.WO;

            gridControl1.DataSource = tbl_Result_COA_KQTableAdapter.FillBySoCOA(sYNC_NUTRICIELDataSet.tbl_Result_COA_KQ, txtSoCOA.Text);
        }

        private void F_COA_Result_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_COA_Template_Header' table. You can move, or remove it, as needed.
            this.tbl_COA_Template_HeaderTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_COA_Template_Header);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_OF_Finished' table. You can move, or remove it, as needed.
            this.tbl_OF_FinishedTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_OF_Finished);
        }

        public string Func_SoCOA_NPT(int SoCOA)
        {
            string SoCOA_Text = "";

            switch (SoPKN.ToString().Length)
            {
                case (1):
                    SoCOA_Text = "VP-" + DateTime.Now.Year.ToString().Substring(2, 2) + "000" + BUSTD.Result_COA_TD_SoCOA().ToString();
                    break;

                case (2):
                    SoCOA_Text = "VP-" + DateTime.Now.Year.ToString().Substring(2, 2) + "00" + BUSTD.Result_COA_TD_SoCOA().ToString();
                    break;

                case (3):
                    SoCOA_Text = "VP-" + DateTime.Now.Year.ToString().Substring(2, 2) + "0" + BUSTD.Result_COA_TD_SoCOA().ToString();
                    break;

                case (4):
                    SoCOA_Text = "VP-" + DateTime.Now.Year.ToString().Substring(2, 2) + BUSTD.Result_COA_TD_SoCOA().ToString();
                    break;
            }
            return SoCOA_Text;
        }
    }
}