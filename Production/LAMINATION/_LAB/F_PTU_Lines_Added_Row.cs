using System;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Data;
using DevExpress.XtraBars;

namespace Production.Class
{
    public partial class F_PTU_Lines_Added_Row : DevExpress.XtraEditors.XtraForm
    {
        public DateTime ngaynhanmau;
        string Path = Directory.GetCurrentDirectory();
        public string isAction = "";
        bool gridViewRowClick = false;
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
        
        public PTU_Header OBJ_PTUH                                  = new PTU_Header();
        public PTU_Lines OBJ_PTUL                                   = new PTU_Lines();
       
        PTU_Lines_BUS BUS_PTUL                                      = new PTU_Lines_BUS();    

        public F_PTU_Lines_Added_Row()
        {
            InitializeComponent();
            Load += (s,e) =>
            {              
                this.Width                                          = Screen.PrimaryScreen.Bounds.Width * 2 / 3;
                this.Height                                         = Screen.PrimaryScreen.Bounds.Height * 1 / 2;

                action_EndForm1.Add_Status(false);
                action_EndForm1.Delete_Status(false);
                action_EndForm1.Update_Status(false);
                action_EndForm1.Save_Status(true);
                action_EndForm1.View_Status(false);
                action_EndForm1.Close_Status(true);

                this.Location                                       = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);
                  
                if (isAction                                        == "Edit")
                {
                    layoutControlGroup4.Visibility                  = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                                        
                    //KH_Mau                    
                    Set4Controls_Header();
                    Set4Controls_Details();
                }
                else if (isAction                                   == "Add")
                {                    
                    layoutControlGroup4.Visibility                  = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                                        
                    Set4Controls_Header();
                    Set4Controls_Details();                   
                }
            };

            lkeSoPO.EditValueChanged                                += (s, e) =>
            {
                DataRowView row                                     = lkeSoPO.GetSelectedDataRow() as DataRowView;                
                txtNote.Text                                        = row["SoPO"].ToString();
                txtNoiDung.Text                                     = "THANH TOÁN PO: "+ row["SoPO"].ToString();
                txtSoTien.Text                                      = row["TONGCONG"].ToString();
            };           
              
            //Action_EndForm
            action_EndForm1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action_EndForm1.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update));
            action_EndForm1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action_EndForm1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
        }
        private void ItemClickEventHandler_Save(object sender, ItemClickEventArgs e)
        {
            if (isAction == "Add")
            {
                if (lkeSoPO.Text.Length > 0 && lkeSoPO.Text != "...")
                {
                    Set4Object_Details();
                    //XtraMessageBox.Show("Set object xong");
                    BUS_PTUL.PTU_Lines_INSERT(OBJ_PTUL);
                    //XtraMessageBox.Show("INSERT xong");
                    XtraMessageBoxArgs args                         = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay                     = 1000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton  = true;
                    args.DefaultButtonIndex                         = 0;
                    args.Caption                                    = "Thông tin ";
                    args.Text                                       = "Lưu thành công . Thông báo này sẽ tự đóng .";
                    args.Buttons                                    = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                    Is_close                                        = true;                    
                }

            }

            else if (isAction                                       == "Edit")
            {
                Set4Object_Details();
                XtraMessageBoxArgs args                             = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay                         = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton      = true;
                args.DefaultButtonIndex                             = 0;
                args.Caption                                        = "Thông báo ";
                args.Text                                           = "Cập nhật thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons                                        = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
                Is_close                                            = true;
            }
        }

        private void ItemClickEventHandler_Close(object sender, ItemClickEventArgs e)
        {
            Is_close = true;
        }

        private void ItemClickEventHandler_Update(object sender, ItemClickEventArgs e)
        {
            Set4Object_Details();
            XtraMessageBoxArgs args                                 = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay                             = 2000;
            args.AutoCloseOptions.ShowTimerOnDefaultButton          = true;
            args.DefaultButtonIndex                                 = 0;
            args.Caption                                            = "Thông báo ";
            args.Text                                               = "Cập nhật thành công . Thông báo này sẽ tự đóng sau 2 giây.";
            args.Buttons                                            = new DialogResult[] { DialogResult.OK };
            XtraMessageBox.Show(args).ToString();
            Is_close                                                = true;
        }

        private void ItemClickEventHandler_Add(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Set4Controls_Header()
        {
            txtTAMUNG_ID.Text                                       = OBJ_PTUH.ID.ToString() ;
            txtSoPTU.Text                                           = OBJ_PTUH.SoPTU;
            if (isAction                                            == "Edit")
                txtID.Text                                          = OBJ_PTUL.ID.ToString();                                           

        }

        public void Set4Controls_Details()
        {
            OBJ_PTUL.SoPTU                                          = txtSoPTU.Text;
            if (isAction                                            == "Edit")
            {
                txtID.Text                                          = OBJ_PTUL.ID.ToString();
            }

            txtNote.Text                                            = OBJ_PTUL.Note ;
            txtNoiDung.Text                                         = OBJ_PTUL.NoiDung;
            txtSoTien.Text                                          = OBJ_PTUL.SoTien.ToString();
            txtTAMUNG_ID.Text                                       = OBJ_PTUL.TAMUNG_ID.ToString();
        }

        public void Set4Object_Header()
        {
            if( isAction                                            == "Edit")
                OBJ_PTUH.ID                                         = int.Parse(txtID.Text.ToString()) ;
            OBJ_PTUH.SoPTU                                          = txtSoPTU.Text;
        }

        public void Set4Object_Details()
        {
            OBJ_PTUL.SoPTU                                          = txtSoPTU.Text;
            if (isAction                                            == "Edit")
            {
                OBJ_PTUL.ID                                         = int.Parse(txtID.Text);
            }

            OBJ_PTUL.Note                                           = txtNote.Text;
            OBJ_PTUL.NoiDung                                        = "THANH TOÁN " + lkeSoPO.Text.ToString();
            OBJ_PTUL.SoTien                                         = float.Parse(txtSoTien.Text);
            OBJ_PTUL.TAMUNG_ID                                      = int.Parse(txtTAMUNG_ID.Text);
        }        

        public void finished(object sender)
        {
            //Disable
            this.Enabled                                            = true;
            //
            //Dong form DELEGATE
            var frm                                                 = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();
            //this.v_NTP_SoPXNTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.V_NTP_SoPXN);
            //this.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMauTableAdapter.FillBy_NgayNhanMau_Note(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMau, KHMAUOBJ.SoPXN.Substring(0, 3), ngaynhanmau.ToString());

        }

        private void F_PO_Lines_Added_Row_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PO_Header_LAB' table. You can move, or remove it, as needed.
            this.tbl_PO_Header_LABTableAdapter.FillBy_ChuaLamCash4Adv(this.sYNC_NUTRICIELDataSet.tbl_PO_Header_LAB);           

        }
    }
    
}
