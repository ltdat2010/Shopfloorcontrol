﻿using DevExpress.XtraBars;

namespace Production.Class
{
    public partial class ActionMini : UC_Base //DevExpress.XtraEditors.XtraUserControl
    {
        //public event EventHandler Add;
        //public event EventHandler Edit;
        //public event EventHandler Delete;
        //public event EventHandler Save;
        //public event EventHandler Cancel;
        //public event EventHandler Report;
        public string btn = "";

        public ActionMini()
        {
            InitializeComponent();
        }

        //ADD - NEW
        public void Add(ItemClickEventHandler handle)
        {
            BtnAdd.ItemClick += handle;
        }

        public void Add_Status(bool bl)
        {
            BtnAdd.Enabled = bl;
        }

        //DELETE
        public void Delete(ItemClickEventHandler handle)
        {
            BtnDelete.ItemClick += handle;
        }

        public void Delete_Status(bool bl)
        {
            BtnDelete.Enabled = bl;
        }

        //EDIT
        public void Edit(ItemClickEventHandler handle)
        {
            BtnEdit.ItemClick += handle;
        }

        public void Edit_Status(bool bl)
        {
            BtnEdit.Enabled = bl;
        }

        // SAVE
        public void Save(ItemClickEventHandler handle)
        {
            BtnSave.ItemClick += handle;
        }

        public void Save_Status(bool bl)
        {
            BtnSave.Enabled = bl;
        }

        //REPORT
        public void Report(ItemClickEventHandler handle)
        {
            BtnReport.ItemClick += handle;
        }

        public void Report_Status(bool bl)
        {
            BtnReport.Enabled = bl;
        }

        //PRINT
        public void Print(ItemClickEventHandler handle)
        {
            BtnPrint.ItemClick += handle;
        }

        public void Print_Status(bool bl)
        {
            BtnPrint.Enabled = bl;
        }

        //VIEW
        public void View(ItemClickEventHandler handle)
        {
            BtnView.ItemClick += handle;
        }

        public void View_Status(bool bl)
        {
            BtnView.Enabled = bl;
        }

        //CLOSE
        public void Close(ItemClickEventHandler handle)
        {
            BtnClose.ItemClick += handle;
        }

        public void Close_Status(bool bl)
        {
            BtnClose.Enabled = bl;
        }

        /// <summary>
        ///
        /// </summary>
        private Class.MenuState State;

        public Class.MenuState StateMenu
        {
            get { return State; }
            set
            {
                State = value;
                if (value == Class.MenuState.Update)
                {
                    BtnAdd.Enabled = false;
                    BtnEdit.Enabled = false;
                    BtnDelete.Enabled = false;
                    BtnSave.Enabled = true;
                    BtnClose.Enabled = true;
                }
                else if (value == Class.MenuState.Full)
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnClose.Enabled = true;
                }
                else if (value == Class.MenuState.Insert)
                {
                    BtnAdd.Enabled = false;
                    BtnEdit.Enabled = false;
                    BtnDelete.Enabled = false;
                    BtnSave.Enabled = true;
                    BtnClose.Enabled = true;
                }
                else if (value == Class.MenuState.Delete)
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = true;
                    BtnClose.Enabled = true;
                }
                else if (value == Class.MenuState.Cancel)
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = true;
                    BtnClose.Enabled = true;
                }
            }
        }
    }
}