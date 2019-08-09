using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.ClsDry;
using DevExpress.ClsUser;
using DevExpress.ClsLog;
using DevExpress.ClsSQL;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Base;
using System.Threading;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Security.Principal;
using System.Windows.Data;

namespace Production.LAMINATION
{
    public partial class Dry_Detail : UC_Base
    {
        #region declare
        public delegate void RefreshItemDelegate(object sender, bool bol);
        public event RefreshItemDelegate RefreshItem;
        public delegate void Dryrecord(string str);
        public delegate void PassData(string value);
        public PassData passData;

        BackgroundWorker bg = new BackgroundWorker();
        CultureInfo culture;
        //tranh truong hop form close insert hay update lai
        int action = 0;
        //bat su kien user change thong tin
        int act_change = 0;
        //bat su kien nut save dc click lan dau tien -- false chua dc bam luu
        bool btnsave = false;
        //khai bao form load lan dau -- true  la mo lan dau
        bool first_load = true;
        //bien tam dung de tinh gia tri lenght,... khi user thay doi gia tri tren luoi
        float sum_tmp;
        //type = delete,update,insert
        string type = "";

        int i = 0;
        //name_ : BLL 
        Dry_ dry_ = new Dry_();
        UNW2_ unw2_ = new UNW2_();
        Error_ error_ = new Error_();
        Raw_ raw_ = new Raw_();
        UNW1_ unw1_ = new UNW1_();
        REW_ rew_ = new REW_();
        User_ userld_ = new User_();
        Log_ log_ = new Log_();
        Sql sql = new Sql();
        //name : DAO
        Log log = new Log();
        Dry dry = new Dry();
        UNW2 unw2 = new UNW2();
        //User user = new User();
        Error error = new Error();
        Raw raw = new Raw();
        UNW1 unw1 = new UNW1();
        REW rew = new REW();
        User userld = new User();
        private bool Is_Refresh
        {
            set
            {
                if (value)
                {
                    if (RefreshItem != null) RefreshItem(sender: this, bol: btnsave);
                }
            }
        }
        public bool Is_Reload
        {
            set
            {
                if (value)
                {
                    dry = dry_.Search(dry._DryRecordNo);
                    //setvalue4controls();                    
                    gridControl1.DataSource = UNW2bindingSource.DataSource = unw2_.Search(unw2._DryRecordNo);
                }
            }
        }
        public bool Is_Reload_Tab4
        {
            set
            {
                if (value)
                {
                    gridControl2.DataSource = error_.Search(error._DryRecordNo);
                    gridControl3.DataSource = raw_.Search(raw._DryRecordNo);
                }
            }
        }

        #endregion
        public Dry_Detail()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //XtraMessageBox.Show("language :" + user._Language);    
                setLanguage(user._Language);
                //XtraMessageBox.Show("DryJobRecord : " + dry._DryRecordNo.ToString()); 
                textEdit7.Properties.DataSource = textEdit12.Properties.DataSource = textEdit13.Properties.DataSource = textEdit14.Properties.DataSource = textEdit15.Properties.DataSource = textEdit17.Properties.DataSource = userld_.View();
                textEdit7.Properties.DisplayMember = textEdit12.Properties.DisplayMember = textEdit13.Properties.DisplayMember = textEdit14.Properties.DisplayMember = textEdit15.Properties.DisplayMember = textEdit17.Properties.DisplayMember = "Name";
                textEdit7.Properties.ValueMember = textEdit12.Properties.ValueMember = textEdit13.Properties.ValueMember = textEdit14.Properties.ValueMember = textEdit15.Properties.ValueMember = textEdit17.Properties.ValueMember = "Name";
                //repositoryItemLookUpEdit2.DataSource = error_.View(user._Dept);
                switch (user._GroupID)
                {
                    case 1:
                        simpleButton6.Enabled = false;
                        textEdit18.Properties.ReadOnly = true;
                        simpleButton7.Enabled = false;
                        toolStripButton2.Enabled = false;
                        repositoryItemLookUpEdit2.DataSource = error_.View(user._Dept);
                        break;
                    case 2:
                        simpleButton6.Enabled = true;
                        //textEdit18.Properties.ReadOnly = true;
                        simpleButton7.Enabled = false;
                        toolStripButton2.Enabled = false;
                        //XtraMessageBox.Show("chay toi day : " + user._Dept.ToString());   
                        repositoryItemLookUpEdit2.DataSource = error_.View(user._Dept);
                        break;
                    case 3:
                        simpleButton6.Enabled = false;
                        //textEdit18.Properties.ReadOnly = false;
                        simpleButton7.Enabled = true;
                        toolStripButton2.Enabled = false;
                        repositoryItemLookUpEdit2.DataSource = error_.View(user._Dept);
                        break;
                    case 4:
                        simpleButton6.Enabled = true;
                        //textEdit18.Properties.ReadOnly = false;
                        simpleButton7.Enabled = true;
                        toolStripButton2.Enabled = true;
                        repositoryItemLookUpEdit2.DataSource = error_.View_All();
                        break;
                    case 5:
                        simpleButton6.Enabled = true;
                        //textEdit18.Properties.ReadOnly = false;
                        simpleButton7.Enabled = true;
                        toolStripButton2.Enabled = true;
                        //XtraMessageBox.Show("chay toi day : " + user._Dept.ToString()); 
                        repositoryItemLookUpEdit2.DataSource = error_.View_All();
                        break;
                }
                switch (action)
                {
                    //Them 
                    case 0:
                        //Gan ngay khi tao moi tranh ngay 1/1/2000
                        textEdit1.Text = DateTime.Today.ToString();
                        //Them moi khoa Xtratab de buoc user luu moi cho nhap thong tin ben duoi
                        //Sau khi luu thi moi cho nhap
                        xtraTabControl1.Enabled = false;
                        //luu y nho lay JobRecordNo
                        //XtraMessageBox.Show("Them moi");
                        break;
                    //Sua
                    case 1:
                        //XtraMessageBox.Show("DryRecordno = " + dry._DryRecordNo.ToString());
                        dry = dry_.Search(dry._DryRecordNo);
                        LoadtoGrid();
                        //XtraMessageBox.Show("SumWaste = " + dry._SumWaste.ToString());
                        //XtraMessageBox.Show("JobName : " + dry._JobName);
                        setvalue4controls();
                        break;
                }

                //form load act_change =1
                //chua sua du lieu gan lai act_change =0
                act_change = 0;
                //Load xong data len control gan first==true : De tranh event TextChanged hoac EditTextChanged
                first_load = false;
                if (dry._Reported == "1" || dry._Checked == "1")
                {
                    Disablecontrols();
                }
            };
            textEdit2.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F5)
                {
                    var frm = new frm_Search_Job();
                    frm.frm_name = this.Name;
                    frm.myEvent += frm_search;
                    frm.Show();
                }
            };
            textEdit8.CheckedChanged += (s, e) =>
            {
                switch (textEdit8.Checked)
                {
                    case true:
                        dry._Shift1 = "1";
                        break;
                    case false:
                        dry._Shift1 = "0";
                        break;
                }
            };
            textEdit9.CheckedChanged += (s, e) =>
            {
                switch (textEdit10.Checked)
                {
                    case true:
                        dry._Shift3 = "1";
                        break;
                    case false:
                        dry._Shift3 = "0";
                        break;
                }
            };
            textEdit10.CheckedChanged += (s, e) =>
            {
                switch (textEdit10.Checked)
                {
                    case true:
                        dry._Shift3 = "1";
                        break;
                    case false:
                        dry._Shift3 = "0";
                        break;
                }
            };
            //Reported by
            simpleButton6.Click += (s, e) =>
            {
                //XtraMessageBox.Show("user._UserName" + user._UserName);

                //act_change = 1;
                dry._Reported = "1";
                dry_.Update_Reported(dry, user._UserName);
                simpleButton6.Enabled = false;
                XtraMessageBox.Show("Report Completed ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            //Checked by            
            simpleButton7.Click += (s, e) =>
            {
                //XtraMessageBox.Show("reported :" + dry._ReportedBy);
                if (textEdit18.Text == "Complete")
                {
                    if (dry._Reported == "1")
                    {
                        //act_change = 1;                    
                        dry._Checked = "1";
                        dry_.Update_Checked(dry, user._UserName);
                        simpleButton7.Enabled = false;
                        XtraMessageBox.Show("Checked Completed ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        XtraMessageBox.Show("Machine Leader chưa report Job. Vui lòng report trước khi check ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    XtraMessageBox.Show("Job chưa hoàn tất. Vui lòng chọn Complete cho Job. ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            };

            #region catch user change text
            textEdit1.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit2.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit3.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit4.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit5.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit6.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit7.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit8.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit9.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit10.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit11.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit12.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit13.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit14.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit15.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit16.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit17.EditValueChanged += (s, e) => { act_change = 1; };
            textEdit18.EditValueChanged += (s, e) => { act_change = 1; };
            #endregion

            #region Sum
            //Sum UNW1
            //Forn load lan dau First_load == true---> khong thuc hien gi het
            //Form da duoc load --> kiem tra neu form cu update value
            //Form moi khong thuc hien
            textEdit28.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    textEdit29.Text = (float.Parse(textEdit31.Text.ToString()) - float.Parse(textEdit28.Text.ToString())).ToString();
                    setvalue4object_SumUNW1();
                    //setvalue4object_SumWaste(); 
                    dry_.UpdateSumUNW1(dry);
                }
            };
            textEdit30.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    textEdit33.Text = (float.Parse(textEdit32.Text.ToString()) - float.Parse(textEdit30.Text.ToString())).ToString();
                    setvalue4object_SumUNW1();
                    dry_.UpdateSumUNW1(dry);
                }
            };
            textEdit31.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    textEdit29.Text = (float.Parse(textEdit31.Text.ToString()) - float.Parse(textEdit28.Text.ToString())).ToString();
                    textEdit25.Text = (int.Parse(textEdit31.Text) - int.Parse(textEdit38.Text)).ToString();
                    setvalue4object_SumUNW1();
                    setvalue4object_SumWaste();
                    dry_.UpdateSumUNW1(dry);
                }
            };
            textEdit32.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    textEdit33.Text = (float.Parse(textEdit32.Text) - float.Parse(textEdit30.Text)).ToString();
                    textEdit43.Text = (int.Parse(textEdit32.Text) - int.Parse(textEdit42.Text)).ToString();
                    setvalue4object_SumUNW1();
                    setvalue4object_SumWaste();
                    dry_.UpdateSumUNW1(dry);
                }
            };
            textEdit36.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    setvalue4object_SumUNW1();
                    //setvalue4object_SumWaste(); 
                    dry_.UpdateSumUNW1(dry);
                }
            };

            //Sum  UNW2
            textEdit20.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    textEdit19.Text = (float.Parse(textEdit20.Text.ToString()) - float.Parse(textEdit21.Text.ToString())).ToString();
                    setvalue4object_SumUNW2();
                    dry_.UpdateSumUNW2(dry);
                }
            };
            textEdit23.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    textEdit22.Text = (float.Parse(textEdit23.Text.ToString()) - float.Parse(textEdit24.Text.ToString())).ToString();
                    setvalue4object_SumUNW2();
                    dry_.UpdateSumUNW2(dry);
                }
            };
            textEdit27.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    setvalue4object_SumUNW2();
                    dry_.UpdateSumUNW2(dry);
                }
            };
            textEdit21.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    textEdit19.Text = (float.Parse(textEdit20.Text.ToString()) - float.Parse(textEdit21.Text.ToString())).ToString();
                    setvalue4object_SumUNW2();
                    dry_.UpdateSumUNW2(dry);
                }
            };
            textEdit24.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    textEdit22.Text = (float.Parse(textEdit23.Text.ToString()) - float.Parse(textEdit24.Text.ToString())).ToString();
                    setvalue4object_SumUNW2();
                    dry_.UpdateSumUNW2(dry);
                }
            };

            //Sum REW
            textEdit38.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    //Theo theo yeu cau Dr Arnold ngay 05Apr2013
                    textEdit25.Text = (int.Parse(textEdit31.Text) - int.Parse(textEdit38.Text)).ToString();
                    setvalue4object_SumREW();
                    setvalue4object_SumWaste();
                    dry_.UpdateSumREW(dry);
                }
            };
            textEdit42.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    textEdit43.Text = (int.Parse(textEdit32.Text) - int.Parse(textEdit42.Text)).ToString();
                    setvalue4object_SumREW();
                    setvalue4object_SumWaste();
                    dry_.UpdateSumREW(dry);
                }
            };
            textEdit45.TextChanged += (s, e) =>
            {
                if (first_load == false)
                {
                    setvalue4object_SumREW();
                    dry_.UpdateSumREW(dry);
                }
            };
            textEdit26.TextChanged += (s, e) =>
            {

            };

            textEdit34.TextChanged += (s, e) =>
            {

            };
            //Tinh phe lieu khong can update khoi luong phe lieu
            #endregion

            #region UNW-2
            //xoa dong
            toolStripButton1.Click += (s, e) =>
            {
                if (gridView1.RowCount > 0 && gridView1.FocusedRowHandle >= 0)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["RCord_Sts"]).ToString() != "-1")
                    {
                        if (XtraMessageBox.Show("Bạn chắc muốn xóa dữ liệu Bảng UNW-2 không ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            //tinh toan lai truoc khi delete row
                            textEdit24.Text = Cal_SumDeleteRowOnGrid("Lenght", gridView1, textEdit24).ToString();
                            //XtraMessageBox.Show("lenght_0 = " + textEdit24.Text);
                            //delete
                            unw2_.Delete_row(int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ID"]).ToString()));
                            //Reload tab3 REW
                            gridControl1.DataSource = UNW2bindingSource.DataSource = unw2_.Search(unw2._DryRecordNo);
                            SumUNW2();
                        }
                    }
                    else
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể xóa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            };
            #region validate controls
            gridView1.ValidateRow += (s, e) =>
            {
                if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["LotNo"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView1.SetColumnError(gridView1.Columns["LotNo"], "Invalid value");
                }
                else if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Weight"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView1.SetColumnError(gridView1.Columns["Weight"], "Invalid value");
                }
                else if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Lenght"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView1.SetColumnError(gridView1.Columns["Lenght"], "Invalid value");
                }
                else if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Width"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView1.SetColumnError(gridView1.Columns["Width"], "Invalid value");
                }
                else if ((gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaOK"]).ToString() == "" && gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaNoOK"]).ToString() == "") || (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaOK"]).ToString() == "1" && gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaNoOK"]).ToString() == "1"))
                {
                    e.Valid = false;
                    gridView1.SetColumnError(gridView1.Columns["CoronaOK"], "Invalid value");
                    gridView1.SetColumnError(gridView1.Columns["CoronaNoOK"], "Invalid value");
                }

                else if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Flag"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView1.SetColumnError(gridView1.Columns["Flag"], "Invalid value");
                }
                //Kiem tra gia tri nhap co lon hon gia tri cuoi khong
                //Kiem tra neu dong dau tien thi ko check
                //Kiem tra gia tri nhap cua lenght so voi gia tri nhap ben tren, nhap nho hon se bao loi
                if (gridView1.RowCount >= 1)
                {
                    //Neu dang nhap dong dau tien thi so voi dong cuoi cung trong grid
                    if (gridView1.FocusedRowHandle == -2147483647)
                    {
                        if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["LotNo"]).ToString() == gridView1.GetRowCellValue(gridView1.RowCount - 1, gridView1.Columns["LotNo"]).ToString())
                        {
                            if (int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Lenght"]).ToString()) <= int.Parse(gridView1.GetRowCellValue(gridView1.RowCount - 1, gridView1.Columns["Lenght"]).ToString()))
                            {
                                e.Valid = false;
                                gridView1.SetColumnError(gridView1.Columns["Lenght"], "Giá trị bạn nhập không đúng. Vui lòng nhập lại");
                            }
                        }
                    }
                    //Neu la dong trong grid thi so voi dong phia tren no
                    else
                    {
                        //truong hop dong dau tien khong xet -- luu y : khogn can quan tam grid co bao nhieu dong
                        if (e.RowHandle > 0)
                        {
                            //Neu dong dang edit va dong ben tren cung lot thi gia tri nhap phai lon hon gia tri ben tren 
                            if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["LotNo"]).ToString() == gridView1.GetRowCellValue(e.RowHandle - 1, gridView1.Columns["LotNo"]).ToString())
                            {
                                if (int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Lenght"]).ToString()) <= int.Parse(gridView1.GetRowCellValue(e.RowHandle - 1, gridView1.Columns["Lenght"]).ToString()))
                                {
                                    e.Valid = false;
                                    gridView1.SetColumnError(gridView1.Columns["Lenght"], "Giá trị bạn sửa không đúng. Vui lòng nhập lại");
                                }
                            }
                        }
                    }
                }
                if (gridView1.FocusedRowHandle == -2147483647)
                {
                    if (e.Valid == true)
                    {
                        //Insert        
                        unw2_.Insert(unw2, user._UserName, i);
                        //Reload
                        //XtraMessageBox.Show("load len grid ");
                        gridControl1.DataSource = UNW2bindingSource.DataSource = unw2_.Search(unw2._DryRecordNo);
                        //tINH SAU CUNG
                        //XtraMessageBox.Show("lenght_1 TRUOC KHI TINH SUM = " + textEdit24.Text);
                        textEdit24.Text = Cal_SumInsertRowOnGrid("Lenght", gridView1, textEdit24).ToString();
                        //XtraMessageBox.Show("lenght_1 = " + textEdit24.Text);
                        SumUNW2();
                    }
                }
            };

            #endregion
            gridView1.InvalidRowException += (s, e) => { e.ExceptionMode = ExceptionMode.NoAction; };
            gridView1.RowCountChanged += (s, e) => { };
            gridView1.CellValueChanged += (s, e) =>
            {
                //XtraMessageBox.Show("row = " + e.RowHandle.ToString());
                if (e.RowHandle >= 0)
                {   //Kiem tra dong da duoc in chua
                    //neu in ra roi khong cho sua du lieu
                    unw2._LotNo = gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["LotNo"]).ToString();
                    unw2._Weight = float.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Weight"]).ToString());
                    unw2._Lenght = float.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Lenght"]).ToString());
                    unw2._Width = float.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Width"]).ToString());
                    unw2._CoronaOK = (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaOK"]).ToString() == "1" ? 1 : 0);
                    //XtraMessageBox.Show("CoronaOK " + gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaOK"]).ToString());
                    unw2._CoronaNoOK = (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaNoOK"]).ToString() == "1" ? 1 : 0);
                    //XtraMessageBox.Show("CoronaNoOK " + gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaNoOK"]).ToString());
                    unw2._Flag = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Flag"]).ToString());
                    unw2._UserName = user._UserName;
                    unw2._ID = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ID"]).ToString());
                    if (e.Column.Name == "Weight")
                    {
                        textEdit21.Text = Cal_Sum("Weight", gridView1).ToString();
                    }
                    else if (e.Column.Name == "Lenght")
                    {
                        //grid co 1 dong
                        if (gridView1.RowCount == 1)
                        {
                            //e.Cancel = false;
                            textEdit24.Text = (float.Parse(textEdit24.Text) - sum_tmp + float.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Lenght"]).ToString())).ToString();
                            //XtraMessageBox.Show("lenght_2 = " + textEdit24.Text);
                        }
                        //grid co nhieu dong
                        else if (gridView1.RowCount > 1)
                        {
                            //dong tren cung
                            if (gridView1.FocusedRowHandle == 0)
                            {
                                //so voi dong duoi khac lot
                                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["LotNo"]).ToString() != gridView1.GetRowCellValue(gridView1.FocusedRowHandle + 1, gridView1.Columns["LotNo"]).ToString())
                                {
                                    textEdit24.Text = (float.Parse(textEdit24.Text) - sum_tmp + float.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Lenght"]).ToString())).ToString();
                                    //XtraMessageBox.Show("lenght_3 = " + textEdit24.Text);
                                }

                            }
                            //dong o giua
                            else if (gridView1.FocusedRowHandle > 0 && gridView1.FocusedRowHandle < gridView1.RowCount - 1)
                            {
                                //so voi dong duoi khac lot
                                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["LotNo"]).ToString() != gridView1.GetRowCellValue(gridView1.FocusedRowHandle + 1, gridView1.Columns["LotNo"]).ToString())
                                {
                                    ///XtraMessageBox.Show("dong o giua khac lot voi dong duoi");
                                    textEdit24.Text = (float.Parse(textEdit24.Text) - sum_tmp + float.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Lenght"]).ToString())).ToString();
                                    //XtraMessageBox.Show("lenght_4 = " + textEdit24.Text);
                                }
                                //so voi dong duoi cung lot khong lam gi ca
                                else
                                {
                                    //XtraMessageBox.Show("dong o giua cung lot voi dong duoi");
                                    //e.Cancel = true;
                                    //XtraMessageBox.Show("Bạn không được thay đổi thông tin dòng này");
                                }
                            }
                            //dong cuoi cung
                            else if (gridView1.FocusedRowHandle == gridView1.RowCount - 1)
                            {
                                //so voi dong tren cung lot 

                                //XtraMessageBox.Show("textEdit42.Text" + textEdit42.Text);
                                //XtraMessageBox.Show("textEdit42.Text" + textEdit42.Text);
                                //XtraMessageBox.Show("sum_tmp" + sum_tmp.ToString());
                                textEdit24.Text = (float.Parse(textEdit24.Text) - sum_tmp + float.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Lenght"]).ToString())).ToString();
                                //XtraMessageBox.Show("lenght_5 = " + textEdit24.Text);
                                //so voi dong tren khac lot
                            }
                        }
                    }
                    //Insert        
                    unw2_.Update(unw2, user._UserName, i);
                    //Reload
                    gridControl1.DataSource = UNW2bindingSource.DataSource = unw2_.Search(unw2._DryRecordNo);
                    SumUNW2();
                }
                else
                {
                    switch (e.Column.Name)
                    {
                        case "LotNo":
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["CoronaOK"], 0);
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["CoronaNoOK"], 0);
                            unw2._LotNo = gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["LotNo"]).ToString();
                            break;
                        case "Weight":
                            unw2._Weight = float.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Weight"]).ToString());
                            break;
                        case "Lenght":
                            unw2._Lenght = float.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Lenght"]).ToString());
                            break;
                        case "Width":
                            unw2._Width = float.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Width"]).ToString());
                            break;
                        case "CoronaOK":
                            //XtraMessageBox.Show("CoronaOK " + gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaOK"]).ToString());
                            unw2._CoronaOK = (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaOK"]).ToString() == "1" ? 1 : 0);
                            break;
                        case "CoronaNoOK":
                            /*
                            if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaOK"]).ToString() == "1")
                            {
                                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["CoronaOK"], 0);
                            }
                            else if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaNoOK"]).ToString() == "0")
                            {
                                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["CoronaNoOK"], 1);
                            }*/
                            //XtraMessageBox.Show("CoronaNoOK " + gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaNoOK"]).ToString());
                            unw2._CoronaNoOK = (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["CoronaNoOK"]).ToString() == "1" ? 1 : 0);
                            break;
                        case "Flag":
                            unw2._Flag = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Flag"]).ToString());
                            break;
                    }
                    //reload
                }

            };
            gridView1.ShowingEditor += (s, e) =>
            {
                if (gridView1.FocusedRowHandle != -2147483647)
                {
                    sum_tmp = float.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Lenght"]).ToString());
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["RCord_Sts"]).ToString() == "-1")
                    {
                        e.Cancel = true;
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể sửa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            };

            #endregion

            #region UNW-1
            toolStripButton8.Click += (s, e) =>
            {
                if (gridView4.FocusedRowHandle >= 0)
                {
                    if (gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["RCord_Sts"]).ToString() != "-1")
                    {
                        if (XtraMessageBox.Show("Bạn chắc muốn xóa dữ liệu Bảng UNW-1 không ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            //tinh toan lai truoc khi delete row
                            textEdit33.Text = Cal_SumDeleteRowOnGrid("Lenght", gridView4, textEdit33).ToString();
                            //delete
                            unw1_.Delete_row(int.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["ID"]).ToString()));
                            //Reload tab3 REW
                            gridControl4.DataSource = unw1_.Search(unw1._DryRecordNo);
                            SumUNW1();
                        }
                    }
                    else
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể xóa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            #region validate controls
            gridView4.ValidateRow += (s, e) =>
            {
                if (gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["LotNo"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView4.SetColumnError(gridView4.Columns["LotNo"], "Invalid value");
                }
                else if (gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Weight"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView4.SetColumnError(gridView4.Columns["Weight"], "Invalid value");
                }
                else if (gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Lenght"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView4.SetColumnError(gridView4.Columns["Lenght"], "Invalid value");
                }
                else if (gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Width"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView4.SetColumnError(gridView4.Columns["Width"], "Invalid value");
                }
                else if (gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Flag"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView4.SetColumnError(gridView4.Columns["Flag"], "Invalid value");
                }
                //Kiem tra gia tri nhap co lon hon gia tri cuoi khong
                //Kiem tra neu dong dau tien thi ko check
                //Kiem tra gia tri nhap cua lenght so voi gia tri nhap ben tren, nhap nho hon se bao loi
                if (gridView4.RowCount >= 1)
                {
                    //Neu dang nhap dong dau tien thi so voi dong cuoi cung trong grid
                    if (gridView4.FocusedRowHandle == -2147483647)
                    {
                        if (gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["LotNo"]).ToString() == gridView4.GetRowCellValue(gridView4.RowCount - 1, gridView4.Columns["LotNo"]).ToString())
                        {
                            if (int.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Lenght"]).ToString()) <= int.Parse(gridView4.GetRowCellValue(gridView4.RowCount - 1, gridView4.Columns["Lenght"]).ToString()))
                            {
                                e.Valid = false;
                                gridView4.SetColumnError(gridView4.Columns["Lenght"], "Giá trị bạn nhập không đúng. Vui lòng nhập lại");
                            }
                        }
                    }
                    //Neu la dong trong grid thi so voi dong phia tren no
                    else
                    {
                        //truong hop dong dau tien khong xet -- luu y : khogn can quan tam grid co bao nhieu dong
                        if (e.RowHandle > 0)
                        {
                            //Neu dong dang edit va dong ben tren cung lot thi gia tri nhap phai lon hon gia tri ben tren 
                            if (gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["LotNo"]).ToString() == gridView4.GetRowCellValue(e.RowHandle - 1, gridView4.Columns["LotNo"]).ToString())
                            {
                                if (int.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Lenght"]).ToString()) <= int.Parse(gridView4.GetRowCellValue(e.RowHandle - 1, gridView4.Columns["Lenght"]).ToString()))
                                {
                                    e.Valid = false;
                                    gridView4.SetColumnError(gridView4.Columns["Lenght"], "Giá trị bạn sửa không đúng. Vui lòng nhập lại");
                                }
                            }
                        }
                    }
                }
                if (gridView4.FocusedRowHandle == -2147483647)
                {
                    if (e.Valid == true)
                    {
                        //Insert        
                        unw1_.Insert(unw1, user._UserName, i);
                        //Reload
                        gridControl4.DataSource = unw1_.Search(unw1._DryRecordNo);
                        //tINH SAU CUNG
                        textEdit33.Text = Cal_SumInsertRowOnGrid("Lenght", gridView4, textEdit33).ToString();
                        SumUNW1();
                    }
                }
            };
            gridView4.InvalidRowException += (s, e) => { e.ExceptionMode = ExceptionMode.NoAction; };
            gridView4.RowCountChanged += (s, e) => { };
            gridView4.CellValueChanged += (s, e) =>
            {
                //XtraMessageBox.Show("row = " + e.RowHandle.ToString());
                if (e.RowHandle >= 0)
                {

                    unw1._LotNo = gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["LotNo"]).ToString();
                    unw1._Weight = float.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Weight"]).ToString());
                    unw1._Lenght = float.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Lenght"]).ToString());
                    unw1._Width = float.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Width"]).ToString());
                    unw1._Flag = int.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Flag"]).ToString());
                    unw1._UserName = user._UserName;
                    unw1._ID = int.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["ID"]).ToString());
                    if (e.Column.Name == "Weight4")
                    {

                        textEdit29.Text = Cal_Sum("Weight", gridView4).ToString();

                        //case "Lenght4":
                        //textEdit33.Text = Cal_Sum("Lenght", gridView4).ToString();
                        //break;
                        //case "Width4":
                        //textEdit36.Text = Cal_Sum("Width", gridView4).ToString();
                        //break;
                    }
                    else if (e.Column.Name == "Lenght4")
                    {
                        //grid co 1 dong
                        if (gridView4.RowCount == 1)
                        {
                            //e.Cancel = false;
                            textEdit33.Text = (float.Parse(textEdit33.Text) - sum_tmp + float.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["Lenght"]).ToString())).ToString();
                        }
                        //grid co nhieu dong
                        else if (gridView4.RowCount > 1)
                        {
                            //dong tren cung
                            if (gridView4.FocusedRowHandle == 0)
                            {
                                //so voi dong duoi khac lot
                                if (gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["LotNo"]).ToString() != gridView4.GetRowCellValue(gridView4.FocusedRowHandle + 1, gridView4.Columns["LotNo"]).ToString())
                                {
                                    textEdit33.Text = (float.Parse(textEdit33.Text) - sum_tmp + float.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["Lenght"]).ToString())).ToString();
                                }

                            }
                            //dong o giua
                            else if (gridView4.FocusedRowHandle > 0 && gridView4.FocusedRowHandle < gridView4.RowCount - 1)
                            {
                                //so voi dong duoi khac lot
                                if (gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["LotNo"]).ToString() != gridView4.GetRowCellValue(gridView4.FocusedRowHandle + 1, gridView4.Columns["LotNo"]).ToString())
                                {
                                    ///XtraMessageBox.Show("dong o giua khac lot voi dong duoi");
                                    textEdit33.Text = (float.Parse(textEdit33.Text) - sum_tmp + float.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["Lenght"]).ToString())).ToString();
                                }
                                //so voi dong duoi cung lot
                                else
                                {
                                    //XtraMessageBox.Show("dong o giua cung lot voi dong duoi");
                                    //e.Cancel = true;
                                    //XtraMessageBox.Show("Bạn không được thay đổi thông tin dòng này");
                                }
                            }
                            //dong cuoi cung
                            else if (gridView4.FocusedRowHandle == gridView4.RowCount - 1)
                            {
                                //so voi dong tren cung lot 

                                //XtraMessageBox.Show("textEdit42.Text" + textEdit42.Text);
                                //XtraMessageBox.Show("textEdit42.Text" + textEdit42.Text);
                                //XtraMessageBox.Show("sum_tmp" + sum_tmp.ToString());
                                textEdit33.Text = (float.Parse(textEdit33.Text) - sum_tmp + float.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["Lenght"]).ToString())).ToString();
                                //so voi dong tren khac lot
                            }
                        }
                    }
                    //Insert        
                    unw1_.Update(unw1, user._UserName, i);
                    //Reload
                    gridControl4.DataSource = unw1_.Search(unw1._DryRecordNo);
                    //sau cung
                    //textEdit33.Text = Cal_SumEditValueOnGrid("Lenght", gridView4, textEdit33).ToString();
                    SumUNW1();

                }
                else
                {
                    switch (e.Column.Name)
                    {
                        case "LotNo4":
                            unw1._LotNo = gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["LotNo"]).ToString();
                            break;
                        case "Weight4":
                            unw1._Weight = float.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Weight"]).ToString());
                            break;
                        case "Lenght4":
                            unw1._Lenght = float.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Lenght"]).ToString());
                            break;
                        case "Width4":
                            unw1._Width = float.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Width"]).ToString());
                            break;
                        case "Flag4":
                            unw1._Flag = int.Parse(gridView4.GetRowCellValue(e.RowHandle, gridView4.Columns["Flag"]).ToString());
                            break;
                    }
                    //reload
                }
            };
            //bat gia tri cot Lenght truoc khi user thay doi gia tri
            gridView4.ShowingEditor += (s, e) =>
            {
                if (gridView4.FocusedRowHandle != -2147483647)
                {
                    sum_tmp = float.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["Lenght"]).ToString());
                    if (gridView4.GetRowCellValue(gridView4.FocusedRowHandle, gridView4.Columns["RCord_Sts"]).ToString() == "-1")
                    {
                        e.Cancel = true;
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể sửa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            };
            #endregion
            #endregion

            #region REW
            toolStripButton9.Click += (s, e) =>
            {
                if (gridView5.FocusedRowHandle >= 0)
                {
                    if (gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["RCord_Sts"]).ToString() != "-1")
                    {
                        if (XtraMessageBox.Show("Bạn chắc muốn xóa dữ liệu Bảng REW không ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            //tinh toan lai truoc khi delete row
                            textEdit42.Text = Cal_SumDeleteRowOnGrid("Lenght", gridView5, textEdit42).ToString();
                            //delete
                            rew_.Delete_row(int.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["ID"]).ToString()));
                            //Reload tab3 REW
                            gridControl5.DataSource = rew_.Search(rew._DryRecordNo);
                            SumREW();
                        }
                    }
                    else
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể xóa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            #region validate controls
            gridView5.ValidateRow += (s, e) =>
            {
                //Kiem tra validate
                if (gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["LotNo"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView5.SetColumnError(gridView5.Columns["LotNo"], "Invalid value");
                }
                else if (gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Weight"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView5.SetColumnError(gridView5.Columns["Weight"], "Invalid value");
                }
                else if (gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Lenght"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView5.SetColumnError(gridView5.Columns["Lenght"], "Invalid value");
                }
                else if (gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Width"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView5.SetColumnError(gridView5.Columns["Width"], "Invalid value");
                }
                else if (gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Flag"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView5.SetColumnError(gridView5.Columns["Flag"], "Invalid value");
                }
                else if (gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["NoteQuanlity"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView5.SetColumnError(gridView5.Columns["NoteQuanlity"], "Invalid value");
                }
                //Kiem tra gia tri nhap co lon hon gia tri cuoi khong
                //Kiem tra neu dong dau tien thi ko check
                //Kiem tra gia tri nhap cua lenght so voi gia tri nhap ben tren, nhap nho hon se bao loi
                if (gridView5.RowCount >= 1)
                {
                    //Neu dang nhap dong dau tien thi so voi dong cuoi cung trong grid
                    if (gridView5.FocusedRowHandle == -2147483647)
                    {
                        if (gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["LotNo"]).ToString() == gridView5.GetRowCellValue(gridView5.RowCount - 1, gridView5.Columns["LotNo"]).ToString())
                        {
                            if (int.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Lenght"]).ToString()) <= int.Parse(gridView5.GetRowCellValue(gridView5.RowCount - 1, gridView5.Columns["Lenght"]).ToString()))
                            {
                                e.Valid = false;
                                gridView5.SetColumnError(gridView5.Columns["Lenght"], "Giá trị bạn nhập không đúng. Vui lòng nhập lại");
                            }
                        }
                    }
                    //Neu la dong trong grid thi so voi dong phia tren no
                    else
                    {
                        //truong hop dong dau tien khong xet -- luu y : khogn can quan tam grid co bao nhieu dong
                        if (e.RowHandle > 0)
                        {
                            //Neu dong dang edit va dong ben tren cung lot thi gia tri nhap phai lon hon gia tri ben tren 
                            if (gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["LotNo"]).ToString() == gridView5.GetRowCellValue(e.RowHandle - 1, gridView5.Columns["LotNo"]).ToString())
                            {
                                if (int.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Lenght"]).ToString()) <= int.Parse(gridView5.GetRowCellValue(e.RowHandle - 1, gridView5.Columns["Lenght"]).ToString()))
                                {
                                    e.Valid = false;
                                    gridView5.SetColumnError(gridView5.Columns["Lenght"], "Giá trị bạn sửa không đúng. Vui lòng nhập lại");
                                }
                            }
                        }
                    }

                }
                if (gridView5.FocusedRowHandle == -2147483647)
                {
                    if (e.Valid == true)
                    {
                        //Insert        
                        rew_.Insert(rew, user._UserName, i);
                        //Reload
                        gridControl5.DataSource = rew_.Search(rew._DryRecordNo);
                        //tINH SAU CUNG
                        textEdit42.Text = Cal_SumInsertRowOnGrid("Lenght", gridView5, textEdit42).ToString();
                        SumREW();
                    }
                }
                //XtraMessageBox.Show("e.valid : " + e.Valid.ToString());               
            };
            gridView5.InvalidRowException += (s, e) => { e.ExceptionMode = ExceptionMode.NoAction; };
            gridView5.RowCountChanged += (s, e) =>
            {

            };
            gridView5.CellValueChanged += (s, e) =>
            {
                //XtraMessageBox.Show("row = " + e.RowHandle.ToString());
                if (e.RowHandle >= 0)
                {

                    rew._LotNo = gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["LotNo"]).ToString();
                    rew._Weight = float.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Weight"]).ToString());
                    rew._Lenght = float.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Lenght"]).ToString());
                    rew._Width = float.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Width"]).ToString());
                    rew._Flag = int.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Flag"]).ToString());
                    rew._NoteQuanlity = gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["NoteQuanlity"]).ToString();
                    rew._UserName = user._UserName;
                    rew._ID = int.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["ID"]).ToString());
                    if (e.Column.Name == "Weight5")
                    {
                        textEdit38.Text = Cal_Sum("Weight", gridView5).ToString();

                    }
                    else if (e.Column.Name == "Lenght5")
                    {
                        //grid co 1 dong
                        if (gridView5.RowCount == 1)
                        {
                            //e.Cancel = false;
                            textEdit42.Text = (float.Parse(textEdit42.Text) - sum_tmp + float.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Lenght"]).ToString())).ToString();
                        }
                        //grid co nhieu dong
                        else if (gridView5.RowCount > 1)
                        {
                            //dong tren cung
                            if (gridView5.FocusedRowHandle == 0)
                            {
                                //so voi dong duoi khac lot
                                if (gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["LotNo"]).ToString() != gridView5.GetRowCellValue(gridView5.FocusedRowHandle + 1, gridView5.Columns["LotNo"]).ToString())
                                {
                                    textEdit42.Text = (float.Parse(textEdit42.Text) - sum_tmp + float.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Lenght"]).ToString())).ToString();
                                }

                            }
                            //dong o giua
                            else if (gridView5.FocusedRowHandle > 0 && gridView5.FocusedRowHandle < gridView5.RowCount - 1)
                            {
                                //so voi dong duoi khac lot
                                if (gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["LotNo"]).ToString() != gridView5.GetRowCellValue(gridView5.FocusedRowHandle + 1, gridView5.Columns["LotNo"]).ToString())
                                {
                                    ///XtraMessageBox.Show("dong o giua khac lot voi dong duoi");
                                    textEdit42.Text = (float.Parse(textEdit42.Text) - sum_tmp + float.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Lenght"]).ToString())).ToString();
                                }
                                //so voi dong duoi cung lot
                                else
                                {
                                    //XtraMessageBox.Show("dong o giua cung lot voi dong duoi");
                                    //e.Cancel = true;
                                    //XtraMessageBox.Show("Bạn không được thay đổi thông tin dòng này");
                                }
                            }
                            //dong cuoi cung
                            else if (gridView5.FocusedRowHandle == gridView5.RowCount - 1)
                            {
                                //so voi dong tren cung lot 

                                //XtraMessageBox.Show("textEdit42.Text" + textEdit42.Text);
                                //XtraMessageBox.Show("textEdit42.Text" + textEdit42.Text);
                                //XtraMessageBox.Show("sum_tmp" + sum_tmp.ToString());
                                textEdit42.Text = (float.Parse(textEdit42.Text) - sum_tmp + float.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Lenght"]).ToString())).ToString();
                                //so voi dong tren khac lot
                            }
                        }
                    }
                    //Update    
                    rew_.Update(rew, user._UserName, i);
                    //Reload
                    gridControl5.DataSource = rew_.Search(rew._DryRecordNo);
                    //sau cung
                    //textEdit42.Text =Cal_SumEditValueOnGrid ("Lenght", gridView5, textEdit42).ToString();
                    SumREW();

                }
                else
                {
                    switch (e.Column.Name)
                    {
                        case "LotNo5":
                            rew._LotNo = gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["LotNo"]).ToString();
                            break;
                        case "Weight5":
                            rew._Weight = float.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Weight"]).ToString());
                            break;
                        case "Lenght5":
                            rew._Lenght = float.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Lenght"]).ToString());
                            break;
                        case "Width5":
                            rew._Width = float.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Width"]).ToString());
                            break;
                        case "Flag5":
                            rew._Flag = int.Parse(gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["Flag"]).ToString());
                            break;
                        case "NotQuantity5":
                            rew._NoteQuanlity = gridView5.GetRowCellValue(e.RowHandle, gridView5.Columns["NoteQuanlity"]).ToString();
                            break;
                    }
                    //reload
                }
            };
            //bat gia tri cot Lenght truoc khi user thay doi gia tri
            gridView5.ShowingEditor += (s, e) =>
            {
                if (gridView5.FocusedRowHandle != -2147483647)
                {
                    sum_tmp = float.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Lenght"]).ToString());
                    if (gridView5.GetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["RCord_Sts"]).ToString() == "-1")
                    {
                        e.Cancel = true;
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể sửa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                //gan gia tri cot lenght chua thay doi cho bien tam

                //chi xu ly khi khong phai la cot nhap

            };
            #endregion
            //Sum used input

            #endregion

            #region ERROR

            repositoryItemLookUpEdit1.EditValueChanged += (s, e) =>
            {
                LookUpEdit edit = s as LookUpEdit;
                object editValue = edit.EditValue;
                int index = edit.Properties.GetDataSourceRowIndex(edit.Properties.ValueMember, editValue);
                DataRowView row = edit.Properties.GetDataSourceRowByKeyValue(editValue) as DataRowView;
                //XtraMessageBox.Show("ErrorID = " + error._ErrorID.ToString());
                error._ErrorID = int.Parse(row["ErrorID"].ToString());
                //
            };
            //Xoa dong
            toolStripButton7.Click += (s, e) =>
            {
                if (gridView2.FocusedRowHandle >= 0)
                {
                    if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["RCord_Sts"]).ToString() != "-1")
                    {
                        if (XtraMessageBox.Show("Bạn chắc muốn xóa dữ liệu Bảng Lỗi Công Đoạn không ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            error_.Delete_row(int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["ID"]).ToString()));
                            //Reload
                            Is_Reload_Tab4 = true;
                        }
                    }
                    else
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể xóa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            gridView2.InvalidRowException += (s, e) => { e.ExceptionMode = ExceptionMode.NoAction; };
            gridView2.ValidateRow += (s, e) =>
            {
                if (gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Machine"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView2.SetColumnError(gridView2.Columns["Machine"], "Invalid value");
                }
                else if (gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Quantity"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView2.SetColumnError(gridView2.Columns["Quantity"], "Invalid value");
                }
                else if (gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["ErrorID"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView2.SetColumnError(gridView2.Columns["ErrorID"], "Invalid value");
                }

                if (e.Valid == true)
                {
                    if (gridView2.FocusedRowHandle == -2147483647)
                    {
                        //Insert
                        error_.Insert(error, user._UserName, i);
                        //Reload
                        Is_Reload_Tab4 = true;
                    }
                }
            };
            gridView2.CellValueChanged += (s, e) =>
            {
                //XtraMessageBox.Show("row = " + e.RowHandle.ToString());
                if (e.RowHandle >= 0)
                {

                    error._Machine = gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Machine"]).ToString();
                    //XtraMessageBox.Show("_Machine" + gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Machine"]).ToString());
                    error._Quantity = float.Parse(gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Quantity"]).ToString());
                    //XtraMessageBox.Show("_Quantity" + gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Quantity"]).ToString());
                    error._ErrorID = int.Parse(gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["ErrorID"]).ToString());
                    //XtraMessageBox.Show("ErrorCode" + gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["ErrorCode"]).ToString());
                    //Update Waste & Error
                    error_.Update(error, user._UserName, i);
                    //Reload
                    Is_Reload_Tab4 = true;
                }
                else
                {
                    switch (e.Column.Name)
                    {
                        case "Machine":
                            error._Machine = gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Machine"]).ToString();
                            //XtraMessageBox.Show("Machine = " + error._Machine.ToString());
                            break;
                        case "Quantity":
                            error._Quantity = float.Parse(gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Quantity"]).ToString());
                            //XtraMessageBox.Show("Quantity = " + error._Quantity.ToString());
                            break;
                        case "ErrorID": //chuyen len tinh khi Editvaluachange
                            error._ErrorID = int.Parse(gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["ErrorID"]).ToString());
                            //XtraMessageBox.Show("ErrorCode #" + gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["ErrorID"]).ToString());
                            break;
                    }
                }
            };
            //bat gia tri cot Lenght truoc khi user thay doi gia tri
            gridView2.ShowingEditor += (s, e) =>
            {
                if (gridView2.FocusedRowHandle != -2147483647)
                {
                    if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["RCord_Sts"]).ToString() == "-1")
                    {
                        e.Cancel = true;
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể sửa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                //gan gia tri cot lenght chua thay doi cho bien tam

                //chi xu ly khi khong phai la cot nhap

            };

            #endregion

            #region RAW
            //Xoa dong
            toolStripButton10.Click += (s, e) =>
            {
                if (gridView3.FocusedRowHandle >= 0)
                {
                    if (gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["RCord_Sts"]).ToString() != "-1")
                    {
                        //XtraMessageBox.Show("row = " + gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["ID"]).ToString());
                        if (XtraMessageBox.Show("Bạn chắc muốn xóa dữ liệu Bảng Nguyên Vật Liệu không ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            raw_.Delete_row(int.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["ID"]).ToString()));
                            //Reload
                            Is_Reload_Tab4 = true;
                        }
                    }
                    else
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể xóa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            gridView3.InvalidRowException += (s, e) => { e.ExceptionMode = ExceptionMode.NoAction; };
            gridView3.ValidateRow += (s, e) =>
            {
                /*
                if (gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["RawName"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView3.SetColumnError(gridView3.Columns["RawName"], "Invalid value");
                }
                else if (gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["RawCode"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView3.SetColumnError(gridView3.Columns["RawCode"], "Invalid value");
                }                 
                else if (gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["SupplierName"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView3.SetColumnError(gridView3.Columns["SupplierName"], "Invalid value");
                }
                else if (gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["RawUnit"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView3.SetColumnError(gridView3.Columns["RawUnit"], "Invalid value");
                }
              * */
                if (gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["Lot"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView3.SetColumnError(gridView3.Columns["Lot"], "Invalid value");
                }
                else if (gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["SizeLot"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView3.SetColumnError(gridView3.Columns["SizeLot"], "Invalid value");
                }

                else if (gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["RawQuantity"]).ToString() == "")
                {
                    e.Valid = false;
                    gridView3.SetColumnError(gridView3.Columns["RawQuantity"], "Invalid value");
                }
                if (e.Valid == true)
                {
                    if (gridView3.FocusedRowHandle == -2147483647)
                    {
                        //Insert
                        raw_.Insert(raw, user._UserName, i);
                        //Reload
                        Is_Reload_Tab4 = true;
                    }
                }
            };

            gridControl3.EditorKeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.F5)
                {
                    if (gridView3.FocusedColumn.Name == "RawName")
                    {
                        var frm = new frm_Search_Raw();
                        frm.myEvent += this.Raw;
                        frm.Show();
                    }
                }
                else if (e.KeyCode == Keys.F5)
                {
                    if (gridView3.FocusedColumn.Name == "RawName")
                    {
                        var frm = new frm_Search_Raw();
                        frm.myEvent += this.Raw;
                        frm.Show();
                    }
                }


            };
            gridView3.CellValueChanged += (s, e) =>
            {
                //XtraMessageBox.Show("row = " + e.RowHandle.ToString());
                if (e.RowHandle >= 0)
                {
                    raw._ID = int.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["ID"]).ToString());
                    raw._RawCode = gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["RawCode"]).ToString();
                    //XtraMessageBox.Show("_Machine" + gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Machine"]).ToString());
                    raw._RawName = gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["RawName"]).ToString();
                    raw._SupplierName = gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["SupplierName"]).ToString();
                    raw._Lot = gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["Lot"]).ToString();
                    raw._SizeLot = gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["SizeLot"]).ToString();
                    raw._RawUnit = gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["RawUnit"]).ToString();
                    raw._RawQuantity = float.Parse(gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["RawQuantity"]).ToString());
                    //Update Waste & Error
                    raw_.Update(raw, user._UserName, i);
                    //Reload
                    Is_Reload_Tab4 = true;
                }
                else
                {
                    switch (e.Column.Name)
                    {
                        case "SizeLot":
                            raw._SizeLot = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["SizeLot"]).ToString();
                            break;
                        case "RawQuantity":
                            raw._RawQuantity = float.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["RawQuantity"]).ToString());
                            break;
                    }
                }
            };
            //Display default value
            gridView3.CustomColumnDisplayText += (s, e) =>
            {
                if (e.RowHandle == -2147483647 && e.Column.FieldName == "RawName")
                    //e.RowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle && e.Column.FieldName == "FolderName"
                    e.DisplayText = raw._RawName;
                else if (e.RowHandle == -2147483647 && e.Column.FieldName == "RawCode")
                    e.DisplayText = raw._RawCode;
                else if (e.RowHandle == -2147483647 && e.Column.FieldName == "SupplierName")
                    e.DisplayText = raw._SupplierName;
                else if (e.RowHandle == -2147483647 && e.Column.FieldName == "RawUnit")
                    e.DisplayText = raw._RawUnit;
                else if (e.RowHandle == -2147483647 && e.Column.FieldName == "Lot")
                    e.DisplayText = raw._Lot;
            };

            gridView3.InitNewRow += (s, e) =>
            {
                gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["RawName"], raw._RawName);
                gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["RawCode"], raw._RawCode);
                gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["SupplierName"], raw._SupplierName);
                gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["RawUnit"], raw._RawUnit);
                gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Lot"], raw._Lot);
            };
            //bat gia tri cot Lenght truoc khi user thay doi gia tri
            gridView3.ShowingEditor += (s, e) =>
            {
                if (gridView3.FocusedRowHandle != -2147483647)
                {
                    if (gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["RCord_Sts"]).ToString() == "-1")
                    {
                        e.Cancel = true;
                        XtraMessageBox.Show("Dữ liệu đã được in. Bạn không thể sửa... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                //gan gia tri cot lenght chua thay doi cho bien tam

                //chi xu ly khi khong phai la cot nhap

            };
            #endregion
        }

        #region func delegate
        public void DryRecord(string str)
        {
            rew._DryRecordNo = unw1._DryRecordNo = raw._DryRecordNo = error._DryRecordNo = dry._DryRecordNo = unw2._DryRecordNo = int.Parse(str.ToString().Trim());
        }
        public void Action(int act)
        {
            action = act;
        }
        public void jobinfo(object sender, string number, string name)
        {
            textEdit2.Text = number;
            textEdit3.Text = name;
        }
        public void Raw(object sender, string s1, string s2, string s3, string s4, string s5)
        {
            raw._RawName = s1;
            raw._RawCode = s2;
            raw._SupplierName = s3;
            raw._RawUnit = s4;
            raw._Lot = s5;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Dispose();

        }
        public void frm_search(object sender, string data, string data2, string data3)
        {
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            textEdit2.Text = data;
            textEdit3.Text = data2;
            textEdit4.Focus();
            dry._FGCode = data3;
            //FGCode data3
            frm.Dispose();
        }
        #endregion
        #region language set
        private void setLanguage(string cultureName)
        {
            culture = CultureInfo.CreateSpecificCulture(cultureName);
            ResourceManager resource = new ResourceManager("Production.LAN.LAN", typeof(Dry_Detail_m).Assembly);
            //layoutControlItem1.Text = resource.GetString("Date", culture);            
            layoutControlItem3.Text = resource.GetString("Tensanpham", culture);
            layoutControlItem4.Text = resource.GetString("Langhep", culture);
            toolStripButton1.Text = resource.GetString("Xoadong", culture);
            toolStripButton8.Text = resource.GetString("Xoadong", culture);
            toolStripButton9.Text = resource.GetString("Xoadong", culture);
            toolStripButton7.Text = resource.GetString("Xoadong", culture);
            toolStripButton10.Text = resource.GetString("Xoadong", culture);
            //labelControl3.Text = resource.GetString("Ghichutrongquatrinhsanxuat", culture);
            layoutControlItem18.Text = resource.GetString("Ghichutrongquatrinhsanxuat", culture);
            toolStripButton2.Caption = resource.GetString("Xoa", culture);
            toolStripButton3.Caption = resource.GetString("Luu", culture);
            toolStripButton4.Caption = resource.GetString("Khongluu", culture);
            toolStripButton11.Caption = resource.GetString("Inbaocao", culture);
            toolStripButton5.Caption = resource.GetString("Dong", culture);
            labelControl4.Text = resource.GetString("Tong", culture);
            labelControl5.Text = resource.GetString("Soluongconlai", culture);
            labelControl6.Text = resource.GetString("Tonginput", culture);
            //labelControl7.Text = resource.GetString("Nang", culture);
            //labelControl9.Text = resource.GetString("Rong", culture);
            //labelControl8.Text = resource.GetString("Dai", culture);
            labelControl12.Text = resource.GetString("Tong", culture);
            labelControl11.Text = resource.GetString("Soluongconlai", culture);
            labelControl10.Text = resource.GetString("Tonginput", culture);
            //labelControl13.Text = resource.GetString("Nang", culture);
            //labelControl14.Text = resource.GetString("Dai", culture);
            //labelControl15.Text = resource.GetString("Rong", culture);
            //labelControl17.Text = resource.GetString("Tongphelieu", culture);
            labelControl1.Text = resource.GetString("Tongphelieu", culture);
            layoutControlItem24.Text = resource.GetString("Tongphelieudai", culture);
            layoutControlItem25.Text = resource.GetString("Tongphelieunang", culture);
            labelControl18.Text = resource.GetString("Tong", culture);
            //labelControl19.Text = resource.GetString("Nang", culture);
            //labelControl20.Text = resource.GetString("Dai", culture);
            //labelControl21.Text = resource.GetString("Rong", culture);
            //labelControl3.Text = resource.GetString("Ghichuvechatluong", culture);
            textEdit8.Text = resource.GetString("Ca1", culture);
            textEdit9.Text = resource.GetString("Ca2", culture);
            textEdit10.Text = resource.GetString("Ca3", culture);
        }
        #endregion

        #region control value
        public void setvalue4controls()
        {
            textEdit1.Text = dry._Date.ToString();
            textEdit2.Text = dry._JobOrder;
            //MessageBox.Show("_JobName " + dry._JobName);
            textEdit3.Text = dry._JobName;
            textEdit4.Text = dry._NoLaminate.ToString();
            textEdit5.Text = dry._UNW1;
            textEdit6.Text = dry._UNW2;
            textEdit7.Text = dry._MCLeader;
            //textEdit8.Text = dry._Shift1;
            //textEdit9.Text = dry._Shift2;
            //textEdit10.Text = dry._Shift3;
            switch (dry._Shift1)
            {
                case "1":
                    textEdit8.Checked = true;
                    break;
                case "0":
                    textEdit8.Checked = false;
                    break;
            }
            switch (dry._Shift2)
            {
                case "1":
                    textEdit9.Checked = true;
                    break;
                case "0":
                    textEdit9.Checked = false;
                    break;
            }
            switch (dry._Shift3)
            {
                case "1":
                    textEdit10.Checked = true;
                    break;
                case "0":
                    textEdit10.Checked = false;
                    break;
            }
            textEdit11.Text = dry._MachineNo;
            textEdit18.Text = dry._JobStatus;
            textEdit12.Text = dry._Employee1;
            textEdit13.Text = dry._Employee2;
            textEdit14.Text = dry._Employee3;
            textEdit15.Text = dry._Employee4;
            textEdit16.Text = dry._Note;
            textEdit17.Text = dry._Employee5;
            //UNW2
            /*
            //MessageBox.Show("dry._SumUNW2Weight.ToString() " + dry._SumUNW2Weight.ToString());
            textEdit19.Text = dry._SumUNW2Weight.ToString() ;
            //MessageBox.Show("textEdit19.Text " + textEdit19.Text);
            textEdit20.Text = dry._SumUNW2WeightRemaind.ToString();
            textEdit21.Text = dry._SumUNW2WeightInput.ToString();
            textEdit22.Text = dry._SumUNW2Lenght.ToString();
            textEdit23.Text = dry._SumUNW2LenghtRemaind.ToString();
            textEdit24.Text = dry._SumUNW2LenghtInput.ToString();
            textEdit25.Text = dry._SumUNW2Width.ToString();
            textEdit26.Text = dry._SumUNW2WidthRemaind.ToString();
            textEdit27.Text = dry._SumUNW2WidthInput.ToString();*/
            //MessageBox.Show("dry._SumUNW2Weight.ToString() " + dry._SumUNW2Weight.ToString());
            textEdit21.Text = dry._SumUNW2Weight.ToString();
            //MessageBox.Show("textEdit21.Text " + textEdit21.Text);
            textEdit19.Text = dry._SumUNW2WeightRemaind.ToString();
            textEdit20.Text = dry._SumUNW2WeightInput.ToString();
            textEdit24.Text = dry._SumUNW2Lenght.ToString();
            textEdit22.Text = dry._SumUNW2LenghtRemaind.ToString();
            textEdit23.Text = dry._SumUNW2LenghtInput.ToString();
            textEdit27.Text = dry._SumUNW2Width.ToString();
            //UNW1
            /*
            textEdit28.Text = dry._SumUNW1Weight.ToString();
            textEdit29.Text = dry._SumUNW1WeightInput.ToString();
            textEdit30.Text = dry._SumUNW1Lenght.ToString();
            textEdit31.Text = dry._SumUNW1WeightRemaind.ToString();
            textEdit32.Text = dry._SumUNW1LenghtRemaind.ToString();
            textEdit33.Text = dry._SumUNW1LenghtInput.ToString();
            textEdit34.Text = dry._SumUNW1Width.ToString();
            textEdit35.Text = dry._SumUNW1WidthRemaind.ToString();
            textEdit36.Text = dry._SumUNW1WidthInput.ToString();*/
            textEdit29.Text = dry._SumUNW1Weight.ToString();
            textEdit31.Text = dry._SumUNW1WeightInput.ToString();
            textEdit33.Text = dry._SumUNW1Lenght.ToString();
            textEdit28.Text = dry._SumUNW1WeightRemaind.ToString();
            textEdit30.Text = dry._SumUNW1LenghtRemaind.ToString();
            textEdit32.Text = dry._SumUNW1LenghtInput.ToString();
            textEdit36.Text = dry._SumUNW1Width.ToString();
            //textEdit34.Text = dry._SumUNW1WidthRemaind.ToString();
            //textEdit35.Text = dry._SumUNW1WidthInput.ToString(); 
            //REW            
            textEdit38.Text = dry._SumREWWeight.ToString();
            //XtraMessageBox.Show(" SumREWLenght " + dry._SumREWLenght.ToString());
            textEdit42.Text = dry._SumREWLenght.ToString();
            textEdit45.Text = dry._SumREWWidth.ToString();
            //Waste
            textEdit43.Text = dry._SumWasteLenght.ToString();
            textEdit25.Text = dry._SumWasteWeight.ToString();

            textEdit34.Text = dry._SumWasteLenghtInput.ToString();
            textEdit26.Text = dry._SumWasteWeightInput.ToString();
            switch (dry._Checked)
            {
                case "1":
                    //XtraMessageBox.Show("o day 1");
                    simpleButton7.Enabled = false;
                    break;
                case "0":
                    //XtraMessageBox.Show("o day 0");
                    if (user._GroupID >= 3)
                        simpleButton7.Enabled = true;
                    else
                        simpleButton7.Enabled = false;
                    break;
                case null:
                    //XtraMessageBox.Show("o day null");
                    if (user._GroupID >= 3)
                        simpleButton7.Enabled = true;
                    else
                        simpleButton7.Enabled = false;
                    break;
            }

            switch (dry._Reported)
            {
                case "1":
                    simpleButton6.Enabled = false;
                    break;
                case "0":
                    if (user._GroupID == 2)
                    {
                        simpleButton6.Enabled = true;
                        textEdit18.Properties.ReadOnly = false;
                    }
                    else
                        simpleButton6.Enabled = false;
                    break;
                case null:
                    if (user._GroupID == 2)
                    {

                        simpleButton6.Enabled = true;
                        textEdit18.Properties.ReadOnly = false;
                    }
                    else
                        simpleButton6.Enabled = false;
                    break;
            }
        }
        public void setvalue4object()
        {
            dry._Date = DateTime.Parse(textEdit1.Text);
            dry._JobOrder = textEdit2.Text;
            dry._JobName = textEdit3.Text;
            dry._NoLaminate = int.Parse(textEdit4.Text);
            dry._UNW1 = textEdit5.Text;
            dry._UNW2 = textEdit6.Text;
            dry._MCLeader = textEdit7.Text;
            switch (textEdit8.Checked)
            {
                case true:
                    dry._Shift1 = "1";
                    break;
                case false:
                    dry._Shift1 = "0";
                    break;
            }
            switch (textEdit9.Checked)
            {
                case true:
                    dry._Shift2 = "1";
                    break;
                case false:
                    dry._Shift2 = "0";
                    break;
            }
            switch (textEdit10.Checked)
            {
                case true:
                    dry._Shift3 = "1";
                    break;
                case false:
                    dry._Shift3 = "0";
                    break;
            }
            dry._MachineNo = textEdit11.Text;
            dry._JobStatus = textEdit18.Text;
            dry._Employee1 = textEdit12.Text;
            dry._Employee2 = textEdit13.Text;
            dry._Employee3 = textEdit14.Text;
            dry._Employee4 = textEdit15.Text;
            dry._Employee5 = textEdit17.Text;
            dry._Note = textEdit16.Text;
            if (action == 0)
            {
                dry._Checked = "0";
                dry._CheckedBy = "no";
                dry._Reported = "0";
                dry._ReportedBy = "no";
            }
            setvalue4object_SumUNW2();
            setvalue4object_SumUNW1();
            setvalue4object_SumREW();
            setvalue4object_SumWaste();
        }
        public void setvalue4object_SumUNW2()
        {
            //UNW2
            //XtraMessageBox.Show("textEdit19 = " + textEdit19.Text);
            dry._SumUNW2Weight = float.Parse(textEdit21.Text);
            dry._SumUNW2WeightRemaind = float.Parse(textEdit19.Text);
            dry._SumUNW2WeightInput = float.Parse(textEdit20.Text);
            dry._SumUNW2Lenght = float.Parse(textEdit24.Text);
            dry._SumUNW2LenghtRemaind = float.Parse(textEdit22.Text);
            dry._SumUNW2LenghtInput = float.Parse(textEdit23.Text);
            dry._SumUNW2Width = float.Parse(textEdit27.Text);
        }
        public void setvalue4object_SumUNW1()
        {
            //UNW1
            dry._SumUNW1Weight = float.Parse(textEdit29.Text);
            dry._SumUNW1WeightInput = float.Parse(textEdit31.Text);
            dry._SumUNW1Lenght = float.Parse(textEdit33.Text);
            dry._SumUNW1WeightRemaind = float.Parse(textEdit28.Text);
            dry._SumUNW1LenghtRemaind = float.Parse(textEdit30.Text);
            dry._SumUNW1LenghtInput = float.Parse(textEdit32.Text);
            dry._SumUNW1Width = float.Parse(textEdit36.Text);
            //dry._SumUNW1WidthRemaind = float.Parse(textEdit34.Text);
            //dry._SumUNW1WidthInput = float.Parse(textEdit35.Text); 
        }
        public void setvalue4object_SumREW()
        {
            //REW
            dry._SumREWWeight = float.Parse(textEdit38.Text);
            dry._SumREWLenght = float.Parse(textEdit42.Text);
            dry._SumREWWidth = float.Parse(textEdit45.Text);
        }
        public void setvalue4object_SumWaste()
        {
            //Waste - nho doi ten thanh SumWasteLenght
            dry._SumWasteLenght = float.Parse(textEdit43.Text);
            //Nho them SumWasteWeight
            dry._SumWasteWeight = float.Parse(textEdit25.Text);

            dry._SumWasteLenghtInput = float.Parse(textEdit34.Text);

            dry._SumWasteWeightInput = float.Parse(textEdit26.Text);
        }
        #endregion

        #region Load data to grid
        public void LoadtoGrid()
        {
            gridControl1.DataSource = UNW2bindingSource.DataSource = unw2_.Search(unw2._DryRecordNo);

            gridControl2.DataSource = error_.Search(error._DryRecordNo);

            //Waste
            gridControl3.DataSource = raw_.Search(raw._DryRecordNo);
            //UNW1                
            gridControl4.DataSource = unw1_.Search(unw1._DryRecordNo);
            //REW                
            gridControl5.DataSource = rew_.Search(rew._DryRecordNo);
        }
        #endregion

        #region Result
        //dung tinh sum khi them moi 1 dong tren grid
        public float Cal_Sum(string name, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            float SumInput = 0;
            for (int i = 0; i < view.RowCount; i++)
            {
                SumInput += float.Parse(view.GetRowCellValue(i, view.Columns[name]).ToString());
            }
            return SumInput;
        }
        public float Cal_SumInsertRowOnGrid(string name, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraEditors.TextEdit txt)
        {
            //XtraMessageBox.Show("kIEM TRA CO CHAY HAM SUM HAY KHONG ");
            float sum = 0;
            if (first_load != true)
            {
                float Sum = float.Parse(txt.Text);
                //truong hop moi nhap dong dau tien
                if (view.RowCount == 1)
                {
                    Sum = float.Parse(view.GetRowCellValue(view.RowCount - 1, view.Columns[name]).ToString());
                    //XtraMessageBox.Show("sum_0 = " + sum.ToString());
                }
                //truong hop update da co dong
                else if (view.RowCount > 1)
                {
                    if (view.GetRowCellValue(view.RowCount - 1, view.Columns["LotNo"]).ToString() == view.GetRowCellValue(view.RowCount - 2, view.Columns["LotNo"]).ToString())
                    {
                        Sum = Sum + float.Parse(view.GetRowCellValue(view.RowCount - 1, view.Columns[name]).ToString()) - float.Parse(view.GetRowCellValue(view.RowCount - 2, view.Columns[name]).ToString());
                        //XtraMessageBox.Show("sum_1 = " + sum.ToString());
                    }
                    else if (view.GetRowCellValue(view.RowCount - 1, view.Columns["LotNo"]).ToString() != view.GetRowCellValue(view.RowCount - 2, view.Columns["LotNo"]).ToString())
                    {
                        Sum = Sum + float.Parse(view.GetRowCellValue(view.RowCount - 1, view.Columns[name]).ToString());
                        //XtraMessageBox.Show("sum_2 = " + sum.ToString());
                    }
                }
                sum = Sum;
                //XtraMessageBox.Show("sum_3 = " + sum.ToString());
            }
            return sum;
        }
        //dung tinh sum khi edit gia tri tren grid
        public float Cal_SumEditValueOnGrid(string name, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraEditors.TextEdit txt)
        {
            float sum = 0;
            if (first_load != true)
            {
                float Sum = float.Parse(txt.Text);
                //Xoa dong dau tien Sum =0
                if (view.RowCount == 1)
                {
                    Sum = 0; //float.Parse(view.GetRowCellValue(view.RowCount - 1, view.Columns[name]).ToString());
                }
                //truong hop xoa dong trong nhieu dong da co
                //Kiem tra co hay khong co dong ben duoi
                else if (view.RowCount > 1)
                {
                    //truong hop co dong ben duoi
                    if (view.FocusedRowHandle < view.RowCount - 1 && view.FocusedRowHandle > 0)
                    {
                        //Kiem tra coi no co dong tren hay khong

                        //kiem tra co trung lot voi dong duoi hay khong
                        //neu trung lot thi ko tru chi delete dong
                        if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LotNo"]).ToString() == view.GetRowCellValue(view.FocusedRowHandle + 1, view.Columns["LotNo"]).ToString())
                        {
                            //XtraMessageBox.Show("cung lot");
                            Sum = Sum;
                        }
                        //nguoc lai tru va cong gia tri dong tren no( do tru no roi ket qua cua lot la dong tren cua no) va delete dong
                        else
                        {
                            Sum = Sum + float.Parse(view.GetRowCellValue(view.FocusedRowHandle - 1, view.Columns[name]).ToString()) - float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString());
                        }
                    }
                    else if (view.FocusedRowHandle == view.RowCount - 1)
                    //Nguoc lai neu la dong cuoi
                    //Kiem tra dong tren co trung lot hay khong
                    //neu trung tru roi cong dong tren
                    {
                        if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LotNo"]).ToString() == view.GetRowCellValue(view.FocusedRowHandle - 1, view.Columns["LotNo"]).ToString())
                        {
                            Sum = Sum - float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString()) + float.Parse(view.GetRowCellValue(view.FocusedRowHandle - 1, view.Columns[name]).ToString());
                        }
                        //nguoc lai tru thang khong cong
                        else
                        {
                            Sum = Sum - float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString());
                        }

                    }
                    //truong hop labelControl1 dong dau tien
                    else if (view.FocusedRowHandle == 0)
                    {
                        //Phia duoi co dong cung lot hay ko
                        //neu co thi chi xoa dong
                        if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LotNo"]).ToString() == view.GetRowCellValue(view.FocusedRowHandle + 1, view.Columns["LotNo"]).ToString())
                        {
                            Sum = Sum;
                        }
                        //nguoc lai tru gia tri cua no
                        else
                        {
                            Sum = Sum - float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString());
                        }


                    }

                }
                sum = Sum;
            }
            /*
                float Sum = float.Parse(txt.Text);
                // Khi edit value cot lenght 
                if (view.RowCount == 1)
                    Sum = float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString());
                else if (view.RowCount > 1)
                {
                    if (view.FocusedRowHandle < view.RowCount - 1)
                    {
                        //kiem tra co trung lot voi dong duoi hay khong
                        //neu khong trung lot thi moi update
                        if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LotNo"]).ToString() == view.GetRowCellValue(view.FocusedRowHandle + 1, view.Columns["LotNo"]).ToString())
                        {
                            Sum = Sum + float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString()) - sum_tmp;
                        }
                    }                                     
                }
                sum = Sum;
            }
             * */
            return sum;
        }
        public float Cal_SumDeleteRowOnGrid(string name, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraEditors.TextEdit txt)
        {
            float sum = 0;
            if (first_load != true)
            {
                float Sum = float.Parse(txt.Text);
                //Xoa dong dau tien Sum =0
                if (view.RowCount == 1)
                {
                    Sum = 0; //float.Parse(view.GetRowCellValue(view.RowCount - 1, view.Columns[name]).ToString());
                }
                //truong hop xoa dong trong nhieu dong da co
                //Kiem tra co hay khong co dong ben duoi
                else if (view.RowCount > 1)
                {
                    //truong hop co dong ben duoi
                    if (view.FocusedRowHandle < view.RowCount - 1 && view.FocusedRowHandle > 0)
                    {
                        //Kiem tra coi no co dong tren hay khong

                        //kiem tra co trung lot voi dong duoi hay khong
                        //neu trung lot thi ko tru chi delete dong
                        if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LotNo"]).ToString() == view.GetRowCellValue(view.FocusedRowHandle + 1, view.Columns["LotNo"]).ToString())
                        {
                            //XtraMessageBox.Show("cung lot");
                            Sum = Sum;
                        }
                        //kiem tra no co trung lot voi dong tren hay khong
                        else if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LotNo"]).ToString() != view.GetRowCellValue(view.FocusedRowHandle + 1, view.Columns["LotNo"]).ToString() && view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LotNo"]).ToString() == view.GetRowCellValue(view.FocusedRowHandle - 1, view.Columns["LotNo"]).ToString())
                        {
                            //XtraMessageBox.Show("cung lot");
                            Sum = Sum + float.Parse(view.GetRowCellValue(view.FocusedRowHandle - 1, view.Columns[name]).ToString()) - float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString());
                        }
                        //nguoc lai tru va cong gia tri dong tren no( do tru no roi ket qua cua lot la dong tren cua no) va delete dong
                        else
                        {
                            Sum = Sum - float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString());
                        }
                    }
                    else if (view.FocusedRowHandle == view.RowCount - 1)
                    //Nguoc lai neu la dong cuoi
                    //Kiem tra dong tren co trung lot hay khong
                    //neu trung tru roi cong dong tren
                    {
                        if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LotNo"]).ToString() == view.GetRowCellValue(view.FocusedRowHandle - 1, view.Columns["LotNo"]).ToString())
                        {
                            Sum = Sum - float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString()) + float.Parse(view.GetRowCellValue(view.FocusedRowHandle - 1, view.Columns[name]).ToString());
                        }
                        //nguoc lai tru thang khong cong
                        else
                        {
                            Sum = Sum - float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString());
                        }

                    }
                    //truong hop labelControl1 dong dau tien
                    else if (view.FocusedRowHandle == 0)
                    {
                        //Phia duoi co dong cung lot hay ko
                        //neu co thi chi xoa dong
                        if (view.GetRowCellValue(view.FocusedRowHandle, view.Columns["LotNo"]).ToString() == view.GetRowCellValue(view.FocusedRowHandle + 1, view.Columns["LotNo"]).ToString())
                        {
                            Sum = Sum;
                        }
                        //nguoc lai tru gia tri cua no
                        else
                        {
                            Sum = Sum - float.Parse(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[name]).ToString());
                        }


                    }

                }
                sum = Sum;
            }
            return sum;
        }
        public void SumUNW2()
        {
            textEdit21.Text = Cal_Sum("Weight", gridView1).ToString();
            //textEdit24.Text = Cal_Sum("Lenght", gridView1).ToString();
            //textEdit27.Text = Cal_SumInput("Width", gridView1).ToString();
        }
        public void SumUNW1()
        {
            textEdit29.Text = Cal_Sum("Weight", gridView4).ToString();
            //textEdit33.Text = Cal_Sum("Lenght", gridView4).ToString();
            //textEdit36.Text = Cal_SumInput("Width", gridView4).ToString();
        }
        public void SumREW()
        {
            textEdit38.Text = Cal_Sum("Weight", gridView5).ToString();
            //textEdit42 khong can tinh;
            //textEdit45.Text = Cal_SumInput("Width", gridView5).ToString();
        }
        #endregion

        #region action
        //Them
        public override UC_Base Add()
        {
            this.BringToFront();
            this.Enabled = false;
            this.Visible = false;
            //return base.Add();  
            Dry_Detail frm = new Dry_Detail();
            frm.user = this.user;
            //XtraMessageBox.Show("user language : " + user._Language);
            frm.action = 0;
            frm.Show();
            return frm;
        }
        //Sua

        //Luu
        public override void Save()
        {
            //base.Save();
            if (XtraMessageBox.Show("Bạn vừa chọn lưu thông tin ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (action == 0)
                {
                    #region Validate save
                    //Check validate
                    if (textEdit1.Text == "1/1/2000")
                    {
                        XtraMessageBox.Show("Vui lòng nhập chọn ngày sản xuất", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textEdit1.Focus();
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(textEdit2.Text) == true)
                        {
                            XtraMessageBox.Show("Vui lòng nhập Job Number", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textEdit2.Focus();

                        }
                        else
                        {
                            if (String.IsNullOrEmpty(textEdit3.Text) == true)
                            {
                                XtraMessageBox.Show("Vui lòng nhập Job Name", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textEdit3.Focus();

                            }
                            else
                            {
                                if (String.IsNullOrEmpty(textEdit4.Text) == true)
                                {
                                    XtraMessageBox.Show("Vui lòng nhập lần ghép", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    textEdit4.Focus();

                                }
                                else
                                {
                                    if (String.IsNullOrEmpty(textEdit5.Text) == true)
                                    {
                                        XtraMessageBox.Show("Vui lòng nhập UNW-1", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        textEdit5.Focus();

                                    }
                                    else
                                    {
                                        if (String.IsNullOrEmpty(textEdit6.Text) == true)
                                        {
                                            XtraMessageBox.Show("Vui lòng nhập UNW-2", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            textEdit6.Focus();

                                        }
                                        else
                                        {
                                            if (String.IsNullOrEmpty(textEdit7.Text) == true)
                                            {
                                                XtraMessageBox.Show("Vui lòng tên người đứng máy", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                textEdit7.Focus();

                                            }
                                            else
                                            {
                                                if (textEdit8.Checked == false && textEdit9.Checked == false && textEdit10.Checked == false)
                                                {
                                                    XtraMessageBox.Show("Vui lòng chọn ca làm việc", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    textEdit8.Focus();

                                                }
                                                else
                                                {
                                                    if (String.IsNullOrEmpty(textEdit11.Text) == true)
                                                    {
                                                        XtraMessageBox.Show("Vui lòng chọn tên máy", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        textEdit11.Focus();

                                                    }
                                                    else
                                                    {

                                                        if (String.IsNullOrEmpty(textEdit18.Text) == true)
                                                        {
                                                            XtraMessageBox.Show("Vui lòng chọn tình trạng của Job", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            textEdit18.Focus();

                                                        }
                                                        else
                                                        {
                                                            if (String.IsNullOrEmpty(textEdit12.Text) == true
                                                                && String.IsNullOrEmpty(textEdit13.Text) == true
                                                                && String.IsNullOrEmpty(textEdit14.Text) == true
                                                                && String.IsNullOrEmpty(textEdit15.Text) == true
                                                                && String.IsNullOrEmpty(textEdit17.Text) == true)
                                                            {
                                                                XtraMessageBox.Show("Vui lòng nhập chọn Người thao tác", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                textEdit11.Focus();

                                                            }
                                                            else
                                                            {
                                                                if (String.IsNullOrEmpty(textEdit18.Text) == true)
                                                                {
                                                                    XtraMessageBox.Show("Vui lòng chọn ghi chú trong quá trình làm việc", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    textEdit18.Focus();

                                                                }
                                                                else
                                                                {

                                                                    //thuc hien luu

                                                                    //if (XtraMessageBox.Show("Bạn có muốn lưu lại thông tin không ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                                                    //{
                                                                    setvalue4object();
                                                                    dry._Running = "1";
                                                                    if (action == 0)
                                                                    {
                                                                        if (btnsave == false)
                                                                        {
                                                                            //XtraMessageBox.Show("Luu truoc khi nut save chua bam ");
                                                                            //type = "Insert";
                                                                            dry_.Insert(dry, user._UserName);
                                                                            rew._DryRecordNo = unw1._DryRecordNo = raw._DryRecordNo = error._DryRecordNo = unw2._DryRecordNo = dry._DryRecordNo = dry_.Max_DryRecordHeader();
                                                                            LoadtoGrid();
                                                                            //XtraMessageBox.Show("DryRecordNo =" + dry._DryRecordNo.ToString());
                                                                            xtraTabControl1.Enabled = true;
                                                                            action = -1;
                                                                            Is_Refresh = true;
                                                                            btnsave = true;
                                                                        }
                                                                        else if (btnsave == true)
                                                                        {
                                                                            //XtraMessageBox.Show("Sql = " + Sql.content);

                                                                            //XtraMessageBox.Show("Luu truoc khi nut save dc bam chi update thoi ");
                                                                            dry_.Update(dry, user._UserName);
                                                                            //XtraMessageBox.Show("Sql sau khi update = " + Sql.content);
                                                                            //type = "Update";
                                                                            //log_.Insert(user._UserName, type, Sql.content);
                                                                            action = -1;
                                                                            Is_Refresh = true;
                                                                        }

                                                                    }
                                                                    //else if (action == 1)
                                                                    //{
                                                                    //setvalue4object();
                                                                    //dry_.Update(dry, user._UserName);
                                                                    //type = "Update";
                                                                    //log_.Insert(user._UserName, type, Sql.content);
                                                                    //XtraMessageBox.Show("Sql sau khi update = " + Sql.content);
                                                                    //action = -1;
                                                                    //Is_Refresh = true;
                                                                    //}



                                                                    //}


                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }



                            }

                        }

                    }
                    #endregion
                    //dry_.Insert(dry, user._UserName);
                }
                //Sua form da co
                //update thong tin
                else if (action == 1)
                {
                    dry_.Update(dry, user._UserName);
                    action = -1;
                    Is_Refresh = true;
                }
                //this.Dispose();
                //Gan lai trang thai cho act_change khi da bam luu
                act_change = 0;
            }
            else
            {
                Is_Refresh = true;
                //this.Dispose();
            }

        }
        //Xoa
        public override void Delete()
        {
            //base.Delete();
            if (dry._Active != -1)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa hết thông tin Job : " + dry._DryRecordNo.ToString().Trim() + " phải không ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (action == 1)
                    {
                        dry_.Delete(dry._DryRecordNo);
                        unw2_.Delete(dry._DryRecordNo);
                        unw1_.Delete(dry._DryRecordNo);
                        rew_.Delete(dry._DryRecordNo);
                        error_.Delete(dry._DryRecordNo);
                        raw_.Delete(dry._DryRecordNo);
                        action = -1;
                        Is_Refresh = true;
                        //this.Dispose();
                    }
                }
            }
            else
                XtraMessageBox.Show("Job đã được in. Bạn không thể xóa ...!", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }
        //Thoat
        public override void Close()
        {
            //base.Close();
            //XtraMessageBox.Show("act_change = " + act_change.ToString());
            if (act_change == 1)//&& action != -1) 
            {
                //XtraMessageBox.Show("Luu truoc khi dong form ne ");
                if (XtraMessageBox.Show("Bạn có muốn lưu lại thông tin vừa sửa không ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    setvalue4object();
                    //them moi form
                    //insert thong tin moi
                    if (action == 0)
                    {
                        if (btnsave == false)
                        {
                            dry._Running = "0";
                            dry_.Insert(dry, user._UserName);
                        }
                        else
                        {
                            dry_.Update(dry, user._UserName);
                            dry_.Update_Running(dry._DryRecordNo, "0");
                            //type = "Update";
                            //log_.Insert(user._UserName, type, Sql.content);
                        }
                    }
                    //Sua form da co
                    //update thong tin
                    else if (action == 1 || action == -1)
                    {
                        setvalue4object();
                        dry_.Update(dry, user._UserName);
                        dry_.Update_Running(dry._DryRecordNo, "0");
                        //type = "Update";
                        //log_.Insert(user._UserName, type, Sql.content);

                    }
                    Is_Refresh = true;
                    action = -2;
                }
                act_change = 0;
                this.Dispose();
                //this.Close();
            }
            else
            {
                dry_.Update_Running(dry._DryRecordNo, "0");
                this.Dispose();
                //this.Close();
            }
        }

        //Chart
        public override UC_Base Chart()
        {
            return base.Chart();
        }

        //Report
        public override UC_Base Report()
        {
            return base.Report();
        }
        #endregion

        public void Disablecontrols()
        {
            textEdit1.Properties.ReadOnly = true;
            textEdit2.Properties.ReadOnly = true;
            //MessageBox.Show("_JobName " + dry._JobName);
            textEdit3.Properties.ReadOnly = true;
            textEdit4.Properties.ReadOnly = true;
            textEdit5.Properties.ReadOnly = true;
            textEdit6.Properties.ReadOnly = true;
            textEdit7.Properties.ReadOnly = true;
            textEdit8.Properties.ReadOnly = true;
            textEdit9.Properties.ReadOnly = true;
            textEdit10.Properties.ReadOnly = true;
            textEdit11.Properties.ReadOnly = true;
            textEdit18.Properties.ReadOnly = true;
            textEdit12.Properties.ReadOnly = true;
            textEdit13.Properties.ReadOnly = true;
            textEdit14.Properties.ReadOnly = true;
            textEdit15.Properties.ReadOnly = true;
            textEdit16.Properties.ReadOnly = true;
            textEdit17.Properties.ReadOnly = true;
            textEdit21.Properties.ReadOnly = true;
            textEdit19.Properties.ReadOnly = true;
            textEdit20.Properties.ReadOnly = true;
            textEdit24.Properties.ReadOnly = true;
            textEdit22.Properties.ReadOnly = true;
            textEdit23.Properties.ReadOnly = true;
            textEdit27.Properties.ReadOnly = true;
            textEdit29.Properties.ReadOnly = true;
            textEdit31.Properties.ReadOnly = true;
            textEdit33.Properties.ReadOnly = true;
            textEdit28.Properties.ReadOnly = true;
            textEdit30.Properties.ReadOnly = true;
            textEdit32.Properties.ReadOnly = true;
            textEdit36.Properties.ReadOnly = true;
            textEdit38.Properties.ReadOnly = true;
            textEdit42.Properties.ReadOnly = true;
            textEdit45.Properties.ReadOnly = true;
            textEdit43.Properties.ReadOnly = true;
            //simpleButton7.Enabled = false;
            //simpleButton6.Enabled = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;
            gridView3.OptionsBehavior.Editable = false;
            gridView4.OptionsBehavior.Editable = false;
            gridView5.OptionsBehavior.Editable = false;
            bindingNavigator1.Enabled = false;
            bindingNavigator3.Enabled = false;
            bindingNavigator4.Enabled = false;
            bindingNavigator5.Enabled = false;
            bindingNavigator6.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;

        }
    }
}
