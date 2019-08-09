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
    public partial class F_Scheduling_Details : frm_Base
    {

        public PXN_Header OBJ = new PXN_Header();
        ResourcesBUS BUS = new ResourcesBUS();
        int ID1, ID2, ID3, ID4, ID5, ID6, ID7;
        /// <summary>
        /// DELEGATE
        /// </summary>        
        public delegate void MyAdd(object sender);
        public event MyAdd myFinished;

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this);
                }
            }
        }

        public F_Scheduling_Details()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                txtSoPXN.Text = OBJ.SoPXN;

                DataTable dt = new DataTable();
                dt = BUS.Appointments_SELECT(OBJ.SoPXN);
                if (dt.Rows[0]["StartDate"].ToString() != "1900-01-01 00:00:00.000")
                    btnNext1.Enabled = false;
                if (dt.Rows[1]["StartDate"].ToString() != "1900-01-01 00:00:00.000")
                    btnNext2.Enabled = false;
                if (dt.Rows[2]["StartDate"].ToString() != "1900-01-01 00:00:00.000")
                    btnNext3.Enabled = false;
                if (dt.Rows[3]["StartDate"].ToString() != "1900-01-01 00:00:00.000")
                    btnNext4.Enabled = false;
                if (dt.Rows[4]["StartDate"].ToString() != "1900-01-01 00:00:00.000")
                    btnNext5.Enabled = false;
                if (dt.Rows[5]["StartDate"].ToString() != "1900-01-01 00:00:00.000")
                    btnNext6.Enabled = false;
                if (dt.Rows[6]["StartDate"].ToString() != "1900-01-01 00:00:00.000")
                    btnNext7.Enabled = false;

                //if (dt.Rows[0]["StartDate"].ToString()!= "1900-01-01 00:00:00.000")
                //{
                //    txtID1.Text = dt.Rows[0]["UniqueId"].ToString();
                //    dteStartDate1.Text = dt.Rows[0]["StartDate"].ToString().Substring(0, 10);
                //    tmeStartTime1.Text = dt.Rows[0]["StartDate"].ToString().Substring(12, 8);
                //}
                //else if (dt.Rows[1]["StartDate"].ToString() != "1900-01-01 00:00:00.000")
                //{
                //    txtID2.Text = dt.Rows[1]["UniqueId"].ToString();
                //    dteStartDate2.Text = dt.Rows[1]["StartDate"].ToString().Substring(0, 10);
                //    tmeStartTime2.Text = dt.Rows[1]["StartDate"].ToString().Substring(12, 8);
                //}

                //else if (dt.Rows[2]["StartDate"].ToString() != "1900-01-01 00:00:00.000")
                //{
                //    txtID3.Text = dt.Rows[2]["UniqueId"].ToString();
                //    dteStartDate3.Text = dt.Rows[2]["StartDate"].ToString().Substring(0, 10);
                //    tmeStartTime3.Text = dt.Rows[2]["StartDate"].ToString().Substring(12, 8);
                //}

                ID1 = int.Parse(dt.Rows[0]["UniqueId"].ToString());
                dteStartDate1.Text = dt.Rows[0]["StartDate"].ToString().Substring(0, 10);
                tmeStartTime1.Text = dt.Rows[0]["StartDate"].ToString().Substring(12, 8);
                textEdit1.Text = dt.Rows[0]["Description"].ToString();

                ID2 = int.Parse(dt.Rows[1]["UniqueId"].ToString());
                dteStartDate2.Text = dt.Rows[1]["StartDate"].ToString().Substring(0, 10);
                tmeStartTime2.Text = dt.Rows[1]["StartDate"].ToString().Substring(12, 8);
                textEdit2.Text = dt.Rows[1]["Description"].ToString();

                ID3 = int.Parse(dt.Rows[2]["UniqueId"].ToString());
                dteStartDate3.Text = dt.Rows[2]["StartDate"].ToString().Substring(0, 10);
                tmeStartTime3.Text = dt.Rows[2]["StartDate"].ToString().Substring(12, 8);
                textEdit3.Text = dt.Rows[2]["Description"].ToString();

                ID4 = int.Parse(dt.Rows[3]["UniqueId"].ToString());
                dteStartDate4.Text = dt.Rows[3]["StartDate"].ToString().Substring(0, 10);
                tmeStartTime4.Text = dt.Rows[3]["StartDate"].ToString().Substring(12, 8);
                textEdit4.Text = dt.Rows[3]["Description"].ToString();

                ID5 = int.Parse(dt.Rows[4]["UniqueId"].ToString());
                dteStartDate5.Text = dt.Rows[4]["StartDate"].ToString().Substring(0, 10);
                tmeStartTime5.Text = dt.Rows[4]["StartDate"].ToString().Substring(12, 8);
                textEdit5.Text = dt.Rows[4]["Description"].ToString();

                ID6 = int.Parse(dt.Rows[5]["UniqueId"].ToString());
                dteStartDate6.Text = dt.Rows[5]["StartDate"].ToString().Substring(0, 10);
                tmeStartTime6.Text = dt.Rows[5]["StartDate"].ToString().Substring(12, 8);
                textEdit6.Text = dt.Rows[5]["Description"].ToString();

                ID7 = int.Parse(dt.Rows[6]["UniqueId"].ToString());
                dteStartDate7.Text = dt.Rows[6]["StartDate"].ToString().Substring(0, 10);
                tmeStartTime7.Text = dt.Rows[6]["StartDate"].ToString().Substring(12, 8);
                textEdit7.Text = dt.Rows[6]["Description"].ToString();

                //txtID8.Text = dt.Rows[7]["UniqueId"].ToString();
                //dteStartDate8.Text = dt.Rows[7]["StartDate"].ToString().Substring(0, 10);
                //tmeStartTime8.Text = dt.Rows[7]["StartDate"].ToString().Substring(12, 8);
            };
            btnNext1.Click += (s, e) =>
            {
                if (dteStartDate1.EditValue.ToString().Substring(0, 10) == "1900-01-01")
                    MessageBox.Show("Ngày tiến hành không đúng. Vui lòng chọn ngày tiến hành");
                else
                {
                    DialogResult dlDel = XtraMessageBox.Show(" Lưu và chuyển tới bước kế tiếp ? Bạn sẽ không thể trở lại và chỉnh sửa !!! ", "Lưu ý ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        BUS.Appointments_UPDATE(dteStartDate1.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime1.Time.ToLongTimeString(), dteStartDate1.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime1.Time.ToLongTimeString(), ID1);
                        btnNext1.Enabled = false;
                        dteStartDate1.ReadOnly = true;
                        tmeStartTime1.ReadOnly = true;

                        btnNext2.Enabled = true;
                        dteStartDate2.ReadOnly = false;
                        tmeStartTime2.ReadOnly = false;
                    }
                }
                
                //MessageBox.Show(tmeStartTime1.Time.ToLongTimeString());
                //BUS.Appointments_UPDATE((dteStartDate1.DateTime.ToShortDateString() +" "+ tmeStartTime1.Time.ToShortTimeString()) , DateTime.Now.ToString(), int.Parse(txtID1.Text));
                
            };
            btnNext2.Click += (s, e) =>
            {
                if (dteStartDate2.EditValue.ToString().Substring(0, 10) == "1900-01-01")
                    MessageBox.Show("Ngày tiến hành không đúng. Vui lòng chọn ngày tiến hành");
                else
                {
                    DialogResult dlDel = XtraMessageBox.Show(" Lưu và chuyển tới bước kế tiếp ? Bạn sẽ không thể trở lại và chỉnh sửa !!! ", "Lưu ý ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        BUS.Appointments_UPDATE(dteStartDate2.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime2.Time.ToLongTimeString(), dteStartDate2.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime2.Time.ToLongTimeString(), ID2);
                        btnNext2.Enabled = false;
                        dteStartDate2.ReadOnly = true;
                        tmeStartTime2.ReadOnly = true;

                        btnNext3.Enabled = true;
                        dteStartDate3.ReadOnly = false;
                        tmeStartTime3.ReadOnly = false;
                    }
                }
                //MessageBox.Show(tmeStartTime1.Time.ToLongTimeString());
                //BUS.Appointments_UPDATE((dteStartDate1.DateTime.ToShortDateString() +" "+ tmeStartTime1.Time.ToShortTimeString()) , DateTime.Now.ToString(), int.Parse(txtID1.Text));
                
            };
            btnNext3.Click += (s, e) =>
            {
                if (dteStartDate3.EditValue.ToString().Substring(0, 10) == "1900-01-01")
                    MessageBox.Show("Ngày tiến hành không đúng. Vui lòng chọn ngày tiến hành");
                else
                {
                    DialogResult dlDel = XtraMessageBox.Show(" Lưu và chuyển tới bước kế tiếp ? Bạn sẽ không thể trở lại và chỉnh sửa !!! ", "Lưu ý ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        BUS.Appointments_UPDATE(dteStartDate3.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime3.Time.ToLongTimeString(), dteStartDate3.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime3.Time.ToLongTimeString(), ID3);
                        btnNext3.Enabled = false;
                        dteStartDate3.ReadOnly = true;
                        tmeStartTime3.ReadOnly = true;

                        btnNext4.Enabled = true;
                        dteStartDate4.ReadOnly = false;
                        tmeStartTime4.ReadOnly = false;

                    }
                }
                //MessageBox.Show(tmeStartTime1.Time.ToLongTimeString());
                //BUS.Appointments_UPDATE((dteStartDate1.DateTime.ToShortDateString() +" "+ tmeStartTime1.Time.ToShortTimeString()) , DateTime.Now.ToString(), int.Parse(txtID1.Text));
                
            };
            btnNext4.Click += (s, e) =>
            {
                if (dteStartDate4.EditValue.ToString().Substring(0, 10) == "1900-01-01")
                    MessageBox.Show("Ngày tiến hành không đúng. Vui lòng chọn ngày tiến hành");
                else
                {
                    DialogResult dlDel = XtraMessageBox.Show(" Lưu và chuyển tới bước kế tiếp ? Bạn sẽ không thể trở lại và chỉnh sửa !!! ", "Lưu ý ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        BUS.Appointments_UPDATE(dteStartDate4.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime4.Time.ToLongTimeString(), dteStartDate4.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime4.Time.ToLongTimeString(), ID4);
                        btnNext4.Enabled = false;
                        dteStartDate4.ReadOnly = true;
                        tmeStartTime4.ReadOnly = true;

                        btnNext5.Enabled = true;
                        dteStartDate5.ReadOnly = false;
                        tmeStartTime5.ReadOnly = false;
                    }
                }
                //MessageBox.Show(tmeStartTime1.Time.ToLongTimeString());
                //BUS.Appointments_UPDATE((dteStartDate1.DateTime.ToShortDateString() +" "+ tmeStartTime1.Time.ToShortTimeString()) , DateTime.Now.ToString(), int.Parse(txtID1.Text));
                
            };
            btnNext5.Click += (s, e) =>
            {
                if (dteStartDate5.EditValue.ToString().Substring(0, 10) == "1900-01-01")
                    MessageBox.Show("Ngày tiến hành không đúng. Vui lòng chọn ngày tiến hành");
                else
                {
                    DialogResult dlDel = XtraMessageBox.Show(" Lưu và chuyển tới bước kế tiếp ? Bạn sẽ không thể trở lại và chỉnh sửa !!! ", "Lưu ý ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        BUS.Appointments_UPDATE(dteStartDate5.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime5.Time.ToLongTimeString(), dteStartDate5.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime5.Time.ToLongTimeString(), ID5);
                        btnNext5.Enabled = false;
                        dteStartDate5.ReadOnly = true;
                        tmeStartTime5.ReadOnly = true;

                        btnNext6.Enabled = true;
                        dteStartDate6.ReadOnly = false;
                        tmeStartTime6.ReadOnly = false;
                    }
                }
                //MessageBox.Show(tmeStartTime1.Time.ToLongTimeString());
                //BUS.Appointments_UPDATE((dteStartDate1.DateTime.ToShortDateString() +" "+ tmeStartTime1.Time.ToShortTimeString()) , DateTime.Now.ToString(), int.Parse(txtID1.Text));
                
            };
            btnNext6.Click += (s, e) =>
            {
                if (dteStartDate6.EditValue.ToString().Substring(0, 10) == "1900-01-01")
                    MessageBox.Show("Ngày tiến hành không đúng. Vui lòng chọn ngày tiến hành");
                else
                {
                    DialogResult dlDel = XtraMessageBox.Show(" Lưu và chuyển tới bước kế tiếp ? Bạn sẽ không thể trở lại và chỉnh sửa !!! ", "Lưu ý ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        BUS.Appointments_UPDATE(dteStartDate6.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime6.Time.ToLongTimeString(), dteStartDate6.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime6.Time.ToLongTimeString(), ID6);
                        btnNext6.Enabled = false;
                        dteStartDate6.ReadOnly = true;
                        tmeStartTime6.ReadOnly = true;

                        btnNext6.Enabled = true;
                        dteStartDate6.ReadOnly = false;
                        tmeStartTime6.ReadOnly = false;
                    }
                }
                //MessageBox.Show(tmeStartTime1.Time.ToLongTimeString());
                //BUS.Appointments_UPDATE((dteStartDate1.DateTime.ToShortDateString() +" "+ tmeStartTime1.Time.ToShortTimeString()) , DateTime.Now.ToString(), int.Parse(txtID1.Text));
                
            };
            btnNext7.Click += (s, e) =>
            {
                if (dteStartDate7.EditValue.ToString().Substring(0, 10) == "1900-01-01")
                    MessageBox.Show("Ngày tiến hành không đúng. Vui lòng chọn ngày tiến hành");
                else
                {
                    DialogResult dlDel = XtraMessageBox.Show(" Lưu và chuyển tới bước kế tiếp ? Bạn sẽ không thể trở lại và chỉnh sửa !!! ", "Lưu ý ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        BUS.Appointments_UPDATE(dteStartDate7.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime7.Time.ToLongTimeString(), dteStartDate7.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime7.Time.ToLongTimeString(), ID7);
                        btnNext7.Enabled = false;
                        dteStartDate7.ReadOnly = true;
                        tmeStartTime7.ReadOnly = true;
                    }
                }
                //MessageBox.Show(tmeStartTime1.Time.ToLongTimeString());
                //BUS.Appointments_UPDATE((dteStartDate1.DateTime.ToShortDateString() +" "+ tmeStartTime1.Time.ToShortTimeString()) , DateTime.Now.ToString(), int.Parse(txtID1.Text));
                
            };
            //btnNext8.Click += (s, e) =>
            //{
            //    //MessageBox.Show(tmeStartTime1.Time.ToLongTimeString());
            //    //BUS.Appointments_UPDATE((dteStartDate1.DateTime.ToShortDateString() +" "+ tmeStartTime1.Time.ToShortTimeString()) , DateTime.Now.ToString(), int.Parse(txtID1.Text));
            //    BUS.Appointments_UPDATE(dteStartDate8.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime8.Time.ToLongTimeString(), dteStartDate8.EditValue.ToString().Substring(0, 10) + " " + tmeStartTime8.Time.ToLongTimeString(), int.Parse(txtID8.Text));
            //    btnNext8.Enabled = false;
            //    dteStartDate8.ReadOnly = true;
            //    tmeStartTime8.ReadOnly = true;
            //};


        }    
        
        void Set4Object()
        {
            

        }  

        void Set4Controls()
        {


        }
                
    }
}
