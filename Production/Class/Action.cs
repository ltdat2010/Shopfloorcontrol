using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Production.LAMINATION
{
    public partial class Action : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler Add;
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event EventHandler Save;
        public event EventHandler Cancel;
        
        public Action()
        {
            InitializeComponent();
            BtnAdd.ItemClick += (s, e) => 
            {
                if (State == Class.MenuState.Insert)
                {
                    BtnAdd.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                }
                else
                {
                    BtnAdd.Enabled = false;
                    BtnSave.Enabled = true;
                    BtnCancel.Enabled = true;
                }
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
                

                this.Add(s, e); 
            };

            BtnSave.ItemClick += (s, e) => 
            { 
                this.Save(s, e);

                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
            };

            BtnEdit.ItemClick += (s, e) => 
            {
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                this.Edit(s, e);
            };

            BtnDelete.ItemClick += (s, e) => 
            {
                if (State == Class.MenuState.Insert)
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = false;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                }
                else
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                }
                this.Delete(s, e);
            };

            BtnCancel.ItemClick += (s, e) => 
            {
                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                this.Cancel(s, e);
            };
        }

        
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
                    BtnCancel.Enabled = true;
                      
                }
                else if (value == Class.MenuState.Full)
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = true;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;

                }

                else if (value == Class.MenuState.Insert)
                {
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = false;
                    BtnDelete.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;

                }
                
            }
        }
        
    }
}
