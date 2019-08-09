using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Resources;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Threading;
using Production.LAN;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using Production.Class;


namespace Production.Class
{
    public partial class F_COA_List : UC_Base 
    {
        //COABUS COB = new COABUS();
        public F_COA_List()
        {           
            InitializeComponent();
            
            Load += (s, e) =>
            {
                //gridControl1.DataSource = COB.COA_List();
            };
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
              
            //frm_COA COA = new frm_COA();
            //COA.ActStatus = "N";
            //COA.Show();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {            
            //frm_COA COA = new frm_COA();
            //COA.SoCOA = gridView1.GetFocusedRowCellValue("SoCOA").ToString();
            //COA.ActStatus = "E";
            //COA.CD_OF = gridView1.GetFocusedRowCellValue("WO").ToString();
            //COA.Show();
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {            
            //frm_COA COA = new frm_COA();
            //COA.SoCOA = gridView1.GetFocusedRowCellValue("SoCOA").ToString();
            //COA.ActStatus = "V";
            //COA.CD_OF = gridView1.GetFocusedRowCellValue("WO").ToString();
            //COA.Show();

        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {            
            //R_COA_SelectLanguage RCOA = new R_COA_SelectLanguage();
            //RCOA.SoCOA = int.Parse(gridView1.GetFocusedRowCellValue("SoCOA").ToString());            
            //RCOA.CD_OF = gridView1.GetFocusedRowCellValue("WO").ToString(); 
            //RCOA.Show();
        }
    }
}