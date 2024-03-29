﻿using System;

namespace Production.Class
{
    public partial class F_PKN_List : UC_Base
    {
        private PKNBUS PKB = new PKNBUS();

        public F_PKN_List()
        {
            InitializeComponent();

            Load += (s, e) =>
            {
                gridControl1.DataSource = PKB.PKN_List();
            };
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            //MessageBox.Show("click");
            frm_PKN PKN = new frm_PKN();
            PKN.ActStatus = "N";
            PKN.Show();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            //MessageBox.Show("click");
            frm_PKN PKN = new frm_PKN();
            PKN.KQKNTemplateID = int.Parse(gridView1.GetFocusedRowCellValue("KQKNTemplateID").ToString());
            PKN.ActStatus = "E";
            PKN.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            PKN.SoPKN = gridView1.GetFocusedRowCellValue("SoPKN").ToString();
            PKN.SoPNK = gridView1.GetFocusedRowCellValue("SoPNK").ToString();
            PKN.Lan = int.Parse(gridView1.GetFocusedRowCellValue("Lan").ToString());
            PKN.Show();
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            //MessageBox.Show("click");
            frm_PKN PKN = new frm_PKN();
            PKN.KQKNTemplateID = int.Parse(gridView1.GetFocusedRowCellValue("KQKNTemplateID").ToString());
            PKN.ActStatus = "V";
            PKN.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            PKN.SoPKN = gridView1.GetFocusedRowCellValue("SoPKN").ToString();
            PKN.SoPNK = gridView1.GetFocusedRowCellValue("SoPNK").ToString();
            PKN.Lan = int.Parse(gridView1.GetFocusedRowCellValue("Lan").ToString());
            PKN.Show();
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            R_PKN RPKN = new R_PKN();
            RPKN.SoPKN = gridView1.GetFocusedRowCellValue("SoPKN").ToString();
            RPKN.Lan = int.Parse(gridView1.GetFocusedRowCellValue("Lan").ToString());
            RPKN.Show();
        }
    }
}