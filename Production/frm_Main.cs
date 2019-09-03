using System;
using System.Data;
using System.Net;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class frm_Main : DevExpress.XtraEditors.XtraForm
    //public partial class frm_Main : //frm_Base
    {
        public User user = new User();
        private UC_Base uc = new UC_Base();

        public frm_Main()
        {
            OFBUS OFB = new OFBUS();
            //UC_Base uc = new UC_Base();
            InitializeComponent();

            Load += (s, e) =>
            {
                //barStaticItem5.Caption = "IP Address : " + GetIP();
                //barStaticItem6.Caption = "Login time :" + DateTime.Now.ToString();
                this.Enabled = false;
                //var frm = new frm_Login();
                frm_Login frm = new frm_Login();
                frm.Show();
                frm.mylogin += logined;
                frm.myclose += closed;

                //2018-09-25
                //Kiem tra va load OF d9a3 finished tu Oracle vao SQL
                //De Mr Tarng nhap so luong sau khi dong goi va cac thogn tin khac
                //Vi du : so bao bo de trang nhiem cheo, khoi luong bao cuoi cung
                DataTable dt2 = new DataTable();
                dt2 = OFB.F_OF_Finished();
                //Kiem tra OF co trong Resource chua
                for (int i = 0; i < OFB.F_OF_Finished().Rows.Count; i++)
                {
                    //XtraMessageBox.Show("i :" + i.ToString());
                    //Lay Max gia tri IdSort
                    int Max_IdSort = OFB.MAX_IdSort();
                    //XtraMessageBox.Show("CD_OF :" + OFB.CD_OF_Visible(dt2.Rows[i]["CD_OF"].ToString()).ToString());
                    if (OFB.CD_OF_Visible(dt2.Rows[i]["CD_OF"].ToString()) <= 0)
                    {
                        string dcr = dt2.Rows[i]["CD_MAT"].ToString() + "       " +
                            dt2.Rows[i]["LB_MAT"].ToString() + "      " +
                            "Planned QTY. : " + dt2.Rows[i]["QT_LOT"].ToString() + "      " +
                            "Pakaged QTY. : " + dt2.Rows[i]["TOL_QTY_PAK"].ToString();
                        //Khong co thi insert
                        OFB.OF_Resources_INSERT(dt2.Rows[i], Max_IdSort);
                        //Lay so ResourceId
                        int ResourceId = OFB.GET_ResourceId(dt2.Rows[i]["CD_OF"].ToString());
                        //Insert vao Appointments
                        OFB.OF_Appointments_INSERT(dt2.Rows[i]["DT_DEB"].ToString(),
                            dt2.Rows[i]["DT_FIN"].ToString(),
                            ResourceId,
                            dcr);
                    }
                }

                //ribbonPage1.Visible = false;
                //ribbonPage2.Visible = false;
                //ribbonPage3.Visible = false;
                //ribbonPage4.Visible = false;
                //ribbonPage5.Visible = false;
                //ribbonPage6.Visible = false;
                //ribbonPage7.Visible = false;
                //ribbonPage15.Visible = false;
                ////Check User_Dept
                ////Production_ID
                //if (user._DeptID == 5)
                //{
                //    ribbonPage2.Visible = true;
                //    ribbonPage3.Visible = true;
                //    ribbonPage4.Visible = true;
                //    ribbonPage5.Visible = true;
                //    ribbonPage6.Visible = true;
                //}
                ////QC_ID
                //else if (user._DeptID == 4)
                //{
                //    ribbonPage7.Visible = true;
                //    ribbonPage3.Visible = true;
                //}
                ////LAB_ID
                //else if (user._DeptID == 7)
                //{
                //    ribbonPage15.Visible = true;
                //}
            };

            FormClosing += (s, e) => { uc.Close(); };

            //CM.LinkClicked += (s, e) =>
            //{
            //};
            //EmployeeList.LinkClicked += (s, e) =>
            //{
            //};
            //OFList.LinkClicked += (s, e) =>
            //{
            //    //
            //    foreach (Control x in this.gc1.Controls)
            //    {
            //        if (x is DevExpress.XtraEditors.XtraUserControl)
            //            x.Dispose();
            //    }
            //    //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            //    uc = new F_OF_List();
            //    uc.user = this.user;
            //    uc.BringToFront();
            //    uc.Visible = true;
            //    uc.Enabled = true;
            //    gc1.Controls.Add(uc);
            //    uc.Dock = DockStyle.Fill;
            //};
            //RECEIPTLIST.LinkClicked += (s, e) =>
            //{
            //    //
            //    foreach (Control x in this.gc1.Controls)
            //    {
            //        if (x is DevExpress.XtraEditors.XtraUserControl)
            //            x.Dispose();
            //    }
            //    //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            //    uc = new F_RECEIPT_List();
            //    uc.user = this.user;
            //    uc.BringToFront();
            //    uc.Visible = true;
            //    uc.Enabled = true;
            //    gc1.Controls.Add(uc);
            //    uc.Dock = DockStyle.Fill;
            //};
            //navBarItem4.LinkClicked += (s, e) =>
            //{
            //};

            //GA.LinkClicked += (s, e) => {
            //};

            //Schedule.LinkClicked += (s, e) =>
            //{
            //};
            //PL.LinkClicked += (s, e) =>
            //{
            //};
            //CMWH.LinkClicked += (s, e) =>
            //{
            //};

            barButtonItem12.ItemClick += (s, e) =>
            {
                uc.Close();
                this.Dispose();
            };
            barButtonItem13.ItemClick += (s, e) =>
                {
                    foreach (Control x in this.gc1.Controls)
                    {
                        if (x is DevExpress.XtraEditors.XtraUserControl)
                            x.Dispose();
                    }
                    //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    uc = new F_OF_List();
                    uc.user = this.user;
                    uc.BringToFront();
                    uc.Visible = true;
                    uc.Enabled = true;
                    gc1.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                };
            barButtonItem14.ItemClick += (s, e) =>
            {
                //
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }
                //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                uc = new F_RECEIPT_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem11.ItemClick += (s, e) =>
            {
                //
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }
                //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                uc = new F_BATCH();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            barButtonItem15.ItemClick += (s, e) =>
            {
                R_FrDate_ToDate RFGDate = new R_FrDate_ToDate();
                RFGDate.Show();
            };

            barButtonItem17.ItemClick += (s, e) =>
            {
                R_by_FG RFGFG = new R_by_FG();
                RFGFG.Show();
            };

            barButtonItem18.ItemClick += (s, e) =>
            {
                R_FrDate_ToDate_Batch RFGDate = new R_FrDate_ToDate_Batch();
                RFGDate.Show();
            };

            barButtonItem21.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }
                //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                uc = new F_PR_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem22.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }
                //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                uc = new F_IV_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem23.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }
                //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                uc = new F_OABatch_Issued();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            barButtonItem25.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_KQKN_Result_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem26.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_KQKN_Template_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem27.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_QCDG_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem28.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_PPT_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem29.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_CTPT_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem30.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_TC_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem31.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_COA_Result_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem32.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_COA_Template_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem33.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_HMKT_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            barButtonItem35.ItemClick += (s, e) =>
            {
                R_RMUsed_SelectPrefixRM RMPre = new R_RMUsed_SelectPrefixRM();
                RMPre.Show();
            };

            barButtonItem36.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_DashBoard_Pro();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            barButtonItem37.ItemClick += (s, e) =>
            {
                F_OFScheduling_Pro RMPre = new F_OFScheduling_Pro();
                RMPre.Show();
            };

            barButtonItem38.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_FC_IMP_EXCEL();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //Internal transfer Finished Goods
            barButtonItem39.ItemClick += (s, e) =>
            {
                //F_InternalTranfer_List
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_InternalTranfer_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //Internal transfer Raw Material
            barButtonItem40.ItemClick += (s, e) =>
            {
                //F_InternalTranfer_List
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_InternalTranferRM_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            barButtonItem41.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_BOM_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            ////DS Nhan vien
            barButtonItem67.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_EMPLOYEE();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            ////DS Khu vuc
            barButtonItem68.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_LOCATION();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            ////DS Khach hang
            barButtonItem69.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_CUSTOMER();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            ////DS Loai KH
            barButtonItem70.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_CUSTOMERTYPE();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            barButtonItem46.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_Tracerbility();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            //CTXN
            barButtonItem47.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_PXN_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            ////PPXN
            barButtonItem48.ItemClick += (s, e) =>
            {
                F_DashBoard_LAB FRM = new Class.F_DashBoard_LAB();
                FRM.Show();
            };

            //Price List
            barButtonItem49.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_PRICELIST_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            ////N CTXN
            //barButtonItem50.ItemClick += (s, e) =>
            //{
            //    foreach (Control x in this.gc1.Controls)
            //    {
            //        if (x is DevExpress.XtraEditors.XtraUserControl)
            //            x.Dispose();
            //    }

            //    uc = new F_NCTXN_List();
            //    uc.user = this.user;
            //    uc.BringToFront();
            //    uc.Visible = true;
            //    uc.Enabled = true;
            //    gc1.Controls.Add(uc);
            //    uc.Dock = DockStyle.Fill;
            //};

            //CTXN
            barButtonItem51.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_CHITIEUXETNGHIEM();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //N CTXN
            barButtonItem52.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_NCTXN_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //N CTXN
            barButtonItem53.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_PPXN_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //PXN nhan
            barButtonItem54.ItemClick += (s, e) =>
            {
                R_FrDate_ToDate_BaoCaoPXN_Nhan_LAB FRM = new Class.R_FrDate_ToDate_BaoCaoPXN_Nhan_LAB();
                FRM.Show();
            };

            //PXN Chua tra
            barButtonItem55.ItemClick += (s, e) =>
            {
                F_DashBoard_LAB FRM = new Class.F_DashBoard_LAB();
                FRM.Show();
            };

            //Danh sach PXN Excel
            barButtonItem56.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_BaocaoPXN_EXCEL();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //Dich te chung Excel
            barButtonItem57.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_BaocaoDichTeDan_EXCEL();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //Bao cao doanh so thang
            barButtonItem58.ItemClick += (s, e) =>
            {
                R_FrDate_ToDate_BaoCaoDoanhSo_Thang FRM = new Class.R_FrDate_ToDate_BaoCaoDoanhSo_Thang();
                FRM.Show();
            };

            //Bao cao cong no
            barButtonItem59.ItemClick += (s, e) =>
            {
                R_FrDate_ToDate_BaoCaoCongNo FRM = new Class.R_FrDate_ToDate_BaoCaoCongNo();
                FRM.Show();
            };

            ////MDW Result
            //barButtonItem65.ItemClick += (s, e) =>
            //{
            //    foreach (Control x in this.gc1.Controls)
            //    {
            //        if (x is DevExpress.XtraEditors.XtraUserControl)
            //            x.Dispose();
            //    }

            //    uc = new F_MDW_RESULT_LOAD();
            //    uc.user = this.user;
            //    uc.BringToFront();
            //    uc.Visible = true;
            //    uc.Enabled = true;
            //    gc1.Controls.Add(uc);
            //    uc.Dock = DockStyle.Fill;
            //};

            //PO List
            barButtonItem72.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_PO_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //Bao cao PO
            barButtonItem73.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_BaocaoPO_EXCEL();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //Cash for Advnaced List
            barButtonItem74.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_PTU_List();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };
            //Ket qua MYCOTOCXIN : barButtonItem76
            barButtonItem81.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_MYCOTOXIN_RESULT_LIST();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //barButtonItem76 : Bao cao huyet thanh hoc
            barButtonItem76.ItemClick += (s, e) =>
            {
                R_BaoCaoHTH_CTXN FRM = new R_BaoCaoHTH_CTXN();
                FRM.Show();
            };

            //barButtonItem82 -- Đọc kết quả AI
            barButtonItem82.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_AI_RESULT_LIST();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            //barButtonItem83 -- Đọc kết quả IBD
            barButtonItem83.ItemClick += (s, e) =>
            {
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                        x.Dispose();
                }

                uc = new F_IBD_RESULT_LIST();
                uc.user = this.user;
                uc.BringToFront();
                uc.Visible = true;
                uc.Enabled = true;
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
            };

            #region action controls

            //Them
            barButtonItem1.ItemClick += (s, e) =>
            {
                //Dis-En -able controls
                //
                if (user._GroupID < 4)
                {
                    barButtonItem1.Enabled = false;
                    barButtonItem2.Enabled = false;
                    barButtonItem3.Enabled = false;
                    barButtonItem4.Enabled = true;
                    barButtonItem10.Enabled = true;
                    Timeline_rpt.Enabled = false;
                    Details_rpt.Enabled = false;
                }
                else
                {
                    barButtonItem1.Enabled = false;
                    barButtonItem2.Enabled = false;
                    barButtonItem3.Enabled = false;
                    barButtonItem4.Enabled = false;
                    barButtonItem10.Enabled = false;
                    Timeline_rpt.Enabled = false;
                    Timeline_rpt.Enabled = false;
                }
                //
                //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                uc = uc.Add();
                uc.Visible = true;
                uc.Enabled = true;
                uc.BringToFront();
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                    {
                        if (x.Name == "Dry_List" || x.Name == "Exs_List")
                            x.Dispose();
                    }
                }
            };
            //Sua
            barButtonItem2.ItemClick += (s, e) =>
            {
                //Dis-En -able controls
                //
                if (user._GroupID < 4)
                {
                    barButtonItem1.Enabled = false;
                    barButtonItem2.Enabled = false;
                    barButtonItem3.Enabled = false;
                    barButtonItem4.Enabled = true;
                    barButtonItem10.Enabled = true;
                    Timeline_rpt.Enabled = false;
                    Details_rpt.Enabled = false;
                }
                else
                {
                    barButtonItem1.Enabled = false;
                    barButtonItem2.Enabled = false;
                    barButtonItem3.Enabled = false;
                    barButtonItem4.Enabled = false;
                    barButtonItem10.Enabled = true;
                    Timeline_rpt.Enabled = false;
                    Details_rpt.Enabled = false;
                }

                //uc = uc.Modify();
                //uc.Visible = true;
                //uc.Enabled = true;
                //uc.BringToFront();
                //gc1.Controls.Add(uc);
                //uc.Dock = DockStyle.Fill;
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                    {
                        //if (x.Name == "CM")//|| x.Name == "Exs_List")
                        //{
                        //    //x.Dispose();
                        //    frm_CM frm = new frm_CM();
                        //    frm.Show();
                        //}
                        switch (x.Name)
                        {
                        }
                    }
                }
            };
            //Luu
            barButtonItem4.ItemClick += (s, e) =>
            {
                //barButtonItem1.Enabled = false;
                //barButtonItem2.Enabled = false;
                //barButtonItem3.Enabled = false;
                barButtonItem4.Enabled = true;
                //barButtonItem10.Enabled = true;
                //barButtonItem11.Enabled = false;
                uc.Save();
            };
            //Xoa
            barButtonItem3.ItemClick += (s, e) =>
            {
                uc.Delete();
            };
            //Thoat
            barButtonItem10.ItemClick += (s, e) =>
            {
                //En_Dis able Controls
                if (user._GroupID < 4)
                {
                    barButtonItem1.Enabled = false;
                    barButtonItem2.Enabled = false;
                    barButtonItem3.Enabled = false;
                    barButtonItem4.Enabled = false;
                    barButtonItem10.Enabled = false;
                    Timeline_rpt.Enabled = false;
                    Details_rpt.Enabled = false;
                }
                else
                {
                    barButtonItem1.Enabled = false;
                    barButtonItem2.Enabled = false;
                    barButtonItem3.Enabled = false;
                    barButtonItem4.Enabled = false;
                    barButtonItem10.Enabled = false;
                    Timeline_rpt.Enabled = false;
                    Details_rpt.Enabled = false;
                }
                //
                uc.Close();
            };
            //Next
            barButtonItem8.ItemClick += (s, e) =>
            {
            };
            //Prev
            barButtonItem7.ItemClick += (s, e) =>
            {
            };
            //Last
            barButtonItem9.ItemClick += (s, e) =>
            {
            };
            //First
            barButtonItem6.ItemClick += (s, e) =>
            {
            };
            //Chart
            barButtonItem5.ItemClick += (s, e) =>
            {
                //gc1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                uc = uc.Chart();
                uc.Visible = true;
                uc.Enabled = true;
                uc.BringToFront();
                gc1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                foreach (Control x in this.gc1.Controls)
                {
                    if (x is DevExpress.XtraEditors.XtraUserControl)
                    {
                        if (x.Name == "Dry_List" || x.Name == "Exs_List")
                            x.Dispose();
                    }
                }
            };

            //Report
            Timeline_rpt.ItemClick += (s, e) =>
            {
                //if (user._GroupID < 4)
                //{
                //    barButtonItem1.Enabled = false;
                //    barButtonItem2.Enabled = false;
                //    barButtonItem3.Enabled = false;
                //    barButtonItem4.Enabled = false;
                //    barButtonItem10.Enabled = true;
                //    //barButtonItem11.Enabled = false;
                //    //barButtonItem20.Enabled = false;
                //}
                //else
                //{
                //    barButtonItem1.Enabled = false;
                //    barButtonItem2.Enabled = false;
                //    barButtonItem3.Enabled = false;
                //    barButtonItem4.Enabled = false;
                //    barButtonItem10.Enabled = false;
                //    //barButtonItem11.Enabled = false;
                //    //barButtonItem11.Enabled = false;
                //}
                //frm_Rpt_Timeline frm = new frm_Rpt_Timeline();
                //frm.Show();
            };
            //Report Lite
            Details_rpt.ItemClick += (s, e) =>
            {
                //if (user._GroupID < 4)
                //{
                //    barButtonItem1.Enabled = false;
                //    barButtonItem2.Enabled = false;
                //    barButtonItem3.Enabled = false;
                //    barButtonItem4.Enabled = false;
                //    barButtonItem10.Enabled = true;
                //    //barButtonItem11.Enabled = false;
                //    //barButtonItem20.Enabled = false;
                //}
                //else
                //{
                //    barButtonItem1.Enabled = false;
                //    barButtonItem2.Enabled = false;
                //    barButtonItem3.Enabled = false;
                //    barButtonItem4.Enabled = false;
                //    barButtonItem10.Enabled = false;
                //    //barButtonItem11.Enabled = false;
                //    //barButtonItem11.Enabled = false;
                //}

                //frm_Rpt_FollowDate frm = new frm_Rpt_FollowDate();
                //frm.Show();
            };

            GA_report.ItemClick += (s, e) =>
            {
                //frm_Rpt_GA frm = new frm_Rpt_GA();
                //frm.user = this.user;
                //frm.Show();
            };

            PL_report.ItemClick += (s, e) =>
            {
                //frm_Rpt_PL frm = new frm_Rpt_PL();
                //frm.user = this.user;
                //frm.Show();
            };

            CMWH_report.ItemClick += (s, e) =>
            {
                //frm_Rpt_CM_WH frm = new frm_Rpt_CM_WH();
                //frm.user = this.user;
                //frm.Show();
            };

            CM_report.ItemClick += (s, e) =>
            {
            };

            #endregion action controls
        }

        public void closed(object sender, bool isDashboardEnabled)
        {
            //Dong form login
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;

            //Kiem tra xem bo phan nao login
            //A Trang Production -  Load dashnoard production
            //Production_ID
            //if (this.user._UserName == "dat1" || this.user._UserName == "trang")
            if (this.user._DeptID == 5)
            {
                //
                ribbonPage2.Visible = true;
                ribbonPage3.Visible = true;
                ribbonPage4.Visible = true;
                ribbonPage5.Visible = true;
                ribbonPage6.Visible = true;
                //
                if (isDashboardEnabled == true)
                {
                    uc = new F_DashBoard_Pro();
                    uc.user = this.user;
                    uc.BringToFront();
                    uc.Visible = true;
                    uc.Enabled = true;
                    gc1.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                }
            }
            //QC_ID
            //else if (this.user._UserName == "dat2" || this.user._UserName == "tuyet")
            else if (this.user._DeptID == 4)
            {
                //
                ribbonPage7.Visible = true;
                ribbonPage3.Visible = true;
                //
                if (isDashboardEnabled == true)
                {
                    uc = new F_DashBoard_QC();
                    uc.user = this.user;
                    uc.BringToFront();
                    uc.Visible = true;
                    uc.Enabled = true;
                    gc1.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                }
            }
            //LAB_ID
            else if (user._DeptID == 7)
            {
                ribbonPage15.Visible = true;
            }

            frm.Close();

            //Chi tuyet QC - Load dashboard QC
            //uc = new F_DashBoard_QC();
            //uc.user = this.user;
            //uc.BringToFront();
            //uc.Visible = true;
            //uc.Enabled = true;
            //gc1.Controls.Add(uc);
            //uc.Dock = DockStyle.Fill;
        }

        public void logined(User usr, bool status)
        {
            this.Enabled = status;
            user = usr;
            switch (user._GroupID)
            {
                //Admin
                case 16:
                    //GA.Enabled = true;
                    //PL.Enabled = true;
                    //CM.Enabled = true;
                    //CMWH.Enabled = true;
                    //Schedule.Enabled = true;
                    ////----------------------------
                    //GA_report.Enabled = true;
                    //CM_report.Enabled = true;
                    //PL_report.Enabled = true;
                    //CMWH_report.Enabled = true;
                    ////----------------------------
                    //Details_rpt.Enabled = true;
                    //Timeline_rpt.Enabled = true;
                    break;
                //Manager
                case 8:

                    //Dept_Code	Dept_Name
                    //    1	        IT
                    //    2	        GA
                    //    3	        PL
                    //    4	        CM
                    //    5	        CMWH
                    //    6	        Other

                    switch (user.DeptID)
                    {
                        case 1:
                            //GA.Enabled = true;
                            //PL.Enabled = true;
                            //CM.Enabled = true;
                            //CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            //GA_report.Enabled = true;
                            //CM_report.Enabled = true;
                            //PL_report.Enabled = true;
                            //CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 2:
                            //GA.Enabled = true;
                            ////PL.Enabled = true;
                            ////CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            //GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 3:
                            //GA.Enabled = true;
                            //PL.Enabled = true;
                            ////CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            ////GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            //PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 4:
                            ////GA.Enabled = true;
                            ////PL.Enabled = true;
                            //CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            ////GA_report.Enabled = true;
                            //CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 5:
                            ////GA.Enabled = true;
                            ////PL.Enabled = true;
                            ////CM.Enabled = true;
                            //CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            ////GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            //CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 6:
                            //GA.Enabled = true;
                            //PL.Enabled = true;
                            //CM.Enabled = true;
                            //CMWH.Enabled = true;
                            ////----------------------------
                            //GA_report.Enabled = true;
                            //CM_report.Enabled = true;
                            //PL_report.Enabled = true;
                            //CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;
                    }
                    break;
                //Supervisor
                case 4:
                    switch (user.DeptID)
                    {
                        case 1:
                            //GA.Enabled = true;
                            //PL.Enabled = true;
                            //CM.Enabled = true;
                            //CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            //GA_report.Enabled = true;
                            //CM_report.Enabled = true;
                            //PL_report.Enabled = true;
                            //CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 2:
                            //GA.Enabled = true;
                            ////PL.Enabled = true;
                            ////CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            //GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 3:
                            ////GA.Enabled = true;
                            //PL.Enabled = true;
                            ////CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            ////GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            //PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 4:
                            ////GA.Enabled = true;
                            ////PL.Enabled = true;
                            //CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            ////GA_report.Enabled = true;
                            //CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 5:
                            ////GA.Enabled = true;
                            ////PL.Enabled = true;
                            ////CM.Enabled = true;
                            //CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            ////GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            //CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 6:
                            //GA.Enabled = true;
                            //PL.Enabled = true;
                            //CM.Enabled = true;
                            //CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            //GA_report.Enabled = true;
                            //CM_report.Enabled = true;
                            //PL_report.Enabled = true;
                            //CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;
                    }

                    break;
                //Employee
                case 2:
                    switch (user.DeptID)
                    {
                        case 1:
                            //GA.Enabled = true;
                            //PL.Enabled = true;
                            //CM.Enabled = true;
                            //CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            //GA_report.Enabled = true;
                            //CM_report.Enabled = true;
                            //PL_report.Enabled = true;
                            //CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 2:
                            //GA.Enabled = true;
                            ////PL.Enabled = true;
                            ////CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            //GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 3:
                            ////GA.Enabled = true;
                            //PL.Enabled = true;
                            ////CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            ////GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            //PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 4:
                            ////GA.Enabled = true;
                            ////PL.Enabled = true;
                            //CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            ////GA_report.Enabled = true;
                            //CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 5:
                            ////GA.Enabled = true;
                            ////PL.Enabled = true;
                            ////CM.Enabled = true;
                            //CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            ////----------------------------
                            ////GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            //CMWH_report.Enabled = true;
                            ////----------------------------
                            //Details_rpt.Enabled = true;
                            //Timeline_rpt.Enabled = true;
                            break;

                        case 6:
                            ////GA.Enabled = true;
                            ////PL.Enabled = true;
                            ////CM.Enabled = true;
                            ////CMWH.Enabled = true;
                            //Schedule.Enabled = true;
                            //////----------------------------
                            ////GA_report.Enabled = true;
                            ////CM_report.Enabled = true;
                            ////PL_report.Enabled = true;
                            ////CMWH_report.Enabled = true;
                            //////----------------------------
                            ////Details_rpt.Enabled = true;
                            ////Timeline_rpt.Enabled = true;
                            break;
                    }

                    break;
                //View
                case 0:

                    break;
            }
            labelControl1.Caption = user.Username;
            labelControl5.Caption = user.Language;
        }

        private String GetIP()
        {
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;
            return addr[1].ToString();
        }
    }
}