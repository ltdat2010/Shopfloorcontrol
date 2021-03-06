﻿using DevExpress.XtraBars;

namespace Production.Class
{
    public partial class Action_EndForm : UC_Base //DevExpress.XtraEditors.XtraUserControl
    {
        //public event EventHandler Add;
        //public event EventHandler Edit;
        //public event EventHandler Delete;
        //public event EventHandler Save;
        //public event EventHandler Cancel;
        //public event EventHandler Report;
        public string btn = "";

        public Action_EndForm()
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
        public void Update(ItemClickEventHandler handle)
        {
            BtnEdit.ItemClick += handle;
        }

        public void Update_Status(bool bl)
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

        //FORWARD
        public void Forward(ItemClickEventHandler handle)
        {
            BtnFrd.ItemClick += handle;
        }

        public void Forward_Status(bool bl)
        {
            BtnFrd.Enabled = bl;
        }

        //PREVERSE
        public void Preverse(ItemClickEventHandler handle)
        {
            BtnPrv.ItemClick += handle;
        }

        public void Preverse_Status(bool bl)
        {
            BtnPrv.Enabled = bl;
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

                    BtnFrd.Enabled = false;
                    BtnPrv.Enabled = false;
                }
                else if (value == Class.MenuState.Full)
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnClose.Enabled = true;
                    BtnFrd.Enabled = false;
                    BtnPrv.Enabled = false;
                }
                else if (value == Class.MenuState.Insert)
                {
                    BtnAdd.Enabled = false;
                    BtnEdit.Enabled = false;
                    BtnDelete.Enabled = false;
                    BtnSave.Enabled = true;
                    BtnClose.Enabled = true;
                    BtnFrd.Enabled = false;
                    BtnPrv.Enabled = false;
                }
                else if (value == Class.MenuState.Delete)
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = true;
                    BtnClose.Enabled = true;
                    BtnFrd.Enabled = true;
                    BtnPrv.Enabled = true;
                }
                else if (value == Class.MenuState.Cancel)
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = true;
                    BtnClose.Enabled = true;
                    BtnFrd.Enabled = true;
                    BtnPrv.Enabled = true;
                }
            }
        }
    }
}