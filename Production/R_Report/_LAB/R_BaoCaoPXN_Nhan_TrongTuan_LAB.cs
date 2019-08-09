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
using DevExpress.XtraBars;

namespace Production.Class
{
    public partial class R_BaoCaoPXN_Nhan_LAB : frm_Base
    {
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

        PXN_HeaderBUS BUS = new PXN_HeaderBUS();
        public DateTime FrDate ;
        public DateTime ToDate;
        DataTable dt = new DataTable();
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        
        string Path = Directory.GetCurrentDirectory();        
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_BaoCaoPXN_Nhan_LAB()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                txtFrDate.Text = FrDate.ToString();
                txtToDate.Text = ToDate.ToString();

                dt = BUS.BaoCaoPXN_Nhan(FrDate, ToDate);
                //XtraMessageBox.Show("dt.Rows.Count" + dt.Rows.Count.ToString());
                if (dt.Rows.Count > 0)
                    dt.WriteXml(Path + "/Xml/BaocaoPXN_Nhan_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                //dt.WriteXml(Path + "/../../Xml/BaocaoPXN_Nhan_TrongTuan_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);

                rpt.Load(Path + "/RPT/Rpt_BaoCaoPXN_Nhan_LAB.rpt");
                //rpt.Load(Path + "/../../RPT/Rpt_BaoCaoPXN_Nhan_TrongTuan_LAB");
                rpt.SetParameterValue("P_FrDate", FrDate);
                rpt.SetParameterValue("P_ToDate", ToDate);
                crvReport.ReportSource = rpt;
                
            };

            action1.Print(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Print));
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
        }

        private void ItemClickEventHandler_Close(object sender, ItemClickEventArgs e)
        {
            Is_close = true;
            this.Close();
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Print(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog1 = new PrintDialog();
                PrintDocument pd = new PrintDocument();

                printDialog1.Document = pd;
                printDialog1.ShowNetwork = true;
                printDialog1.AllowSomePages = true;
                printDialog1.AllowSelection = false;
                printDialog1.AllowCurrentPage = false;
                printDialog1.PrinterSettings.Copies = 1; // (short)int.Parse(TotalBatchNb);
                //printDialog1.PrinterSettings.PrinterName = this.PrinterToPrint;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PrintReport(pd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       

        private void PrintReport(PrintDocument pd)
        {
            ReportDocument rDoc = (ReportDocument)crvReport.ReportSource;
            // This line helps, in case user selects a different printer 
            // other than the default selected.
            rDoc.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
            // In place of Frompage and ToPage put 0,0 to print all pages,
            // however in that case user wont be able to choose selection.
            rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage,
               pd.PrinterSettings.ToPage);
        }
    }
}
