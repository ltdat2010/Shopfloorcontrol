using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;

namespace Production.Class
{
    public partial class frm_Login : frm_Base
    {
        public bool ischkDashBoardEnabled;

        public delegate void MyLogin(User user, bool status);

        public event MyLogin mylogin;

        public delegate void MyClose(object sender, bool isDashboardEnabled);

        public event MyClose myclose;

        //User user = new User();
        private User_ user_ = new User_();

        private CultureInfo culture;
        public RijndaelManaged key = null;

        //private string path = @"X:\pkl" + txtUsername.Text + ".xml";

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myclose != null) myclose(sender: this, isDashboardEnabled: ischkDashBoardEnabled);
                }
            }
        }

        public bool Is_login
        {
            set
            {
                if (value)
                {
                    if (mylogin != null) mylogin(status: true, user: user);
                }
            }
        }

        public frm_Login()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                if (PCname == "vpv-lab-sample")
                    path = @"D:\pkl" + txtUsername.Text + ".xml";
                else
                    path = @"X:\pkl" + txtUsername.Text + ".xml";

                if (chkDashboard.CheckState == CheckState.Checked)
                    ischkDashBoardEnabled = true;
                else
                    ischkDashBoardEnabled = false;

                simpleButton1.Enabled = false;
                chkMSSQL.ReadOnly = true;
                chkORACLE.ReadOnly = true;
                //Kiểm tra kết nối
                //---------------------------------------MSSQL------------------------------------
                try
                {
                    Conn.conn_S.Open();
                    //XtraMessageBox.Show("MSSQL Successful Connection");
                    //lblMSSQL.Text = "MSSQL Successful Connection";
                    //Console.WriteLine(Conn.conn_S.ConnectionString, "MSSQL Successful Connection");
                    Conn.conn_S.Close();
                    chkMSSQL.CheckState = CheckState.Checked;
                }
                catch (Exception ex1)
                //catch (SqlException ex1)
                {
                    chkMSSQL.Visible = false;
                    lblMSSQL.ForeColor = Color.Red;
                    XtraMessageBox.Show(" Lỗi kết nối tới SQL server, vui lòng liên hệ người phụ trách. ## SQl connect ERROR : " + ex1.Message);
                    //XtraMessageBox.Show(" Lỗi kết nối tới SQL server, vui lòng liên hệ người phụ trách. ## SQl connect ERROR : " + ex1.ToString());
                    lblMSSQL.Text = "MSSQL ERROR: " + ex1.Message;
                    //XtraMessageBox.Show("## ERROR: " + ex.Message);
                    //Console.WriteLine("## ERROR: " + ex.Message);
                    //Console.Read();
                    return;
                }
                //---------------------------------------ORACLE------------------------------------
                try
                {
                    Conn.conn_O.Open();
                    //XtraMessageBox.Show("Oracle Successful Connection");
                    //Console.WriteLine(Conn.conn_O.ConnectionString, "Oracle Successful Connection");
                    //lblORACLE.Text = "Oracle Successful Connection";
                    // Cho phép login
                    simpleButton1.Enabled = true;
                    chkORACLE.CheckState = CheckState.Checked;
                    Conn.conn_O.Close();
                }
                catch (Exception ex2)
                {
                    chkORACLE.Visible = false;
                    lblORACLE.ForeColor = Color.Red;
                    lblORACLE.Text = " Lỗi kết nối tới ORACLE server, vui lòng liên hệ người phụ trách. ## ORACLE connect ERROR: " + ex2.Message;
                    //XtraMessageBox.Show("## ERROR: " + ex.Message);
                    //Console.WriteLine("## ERROR: " + ex.Message);
                    //Console.Read();
                    return;
                }
                //check pkl

                XmlDocument document = new XmlDocument();
                //if (File.Exists(@"X:\pkl" + txtUsername.Text + ".xml"))
                if (File.Exists(path))
                {
                    checkEdit1.Checked = true;
                    document.Load(path);
                    //Decrypt(document, key);
                    //duyet qua XML
                    XmlNodeList nodes = document.DocumentElement.ChildNodes;
                    foreach (XmlNode childnode in nodes)
                    {
                        foreach (XmlNode node in childnode.ChildNodes)
                        {
                            if (node.Name == "user")
                            {
                                txtUsername.Text = Production.Class._GEN.EncryptKey.Decrypt(node.InnerText, true);
                            }
                            if (node.Name == "pass")
                            {
                                txtPassword.Text = Production.Class._GEN.EncryptKey.Decrypt(node.InnerText, true);
                            }
                        }
                    }
                }
                else
                {
                    checkEdit1.Checked = false;
                }
            };
            simpleButton1.Click += (s, e) =>
            {
                if (txtUsername.Text != "")
                {
                    if (txtPassword.Text != "")
                    {
                        user.Username = txtUsername.Text;
                        user.Password = txtPassword.Text;

                        //user.Username = Production.Class._GEN.EncryptKey.Decrypt(txtUsername.Text, true);
                        //user.Password = Production.Class._GEN.EncryptKey.Decrypt(txtPassword.Text, true);

                        user = user_.Login(user.Username, user.Password);
                        if (user.Username != "" && user.Username != null)
                        {
                            //Login thanh cong
                            //Kiem tra checkbox o day xem co check hay user da go ra
                            //neu check thi save ra file pkl
                            if (checkEdit1.Checked)
                            {
                                if (File.Exists(path))
                                {
                                    File.Delete(path);
                                }
                                File.WriteAllText(path, "<xml><foo><user>" + Production.Class._GEN.EncryptKey.Encrypt(txtUsername.Text, true) + "</user> <pass>" + Production.Class._GEN.EncryptKey.Encrypt(txtPassword.Text, true) + "</pass></foo></xml>");
                            }
                            //khong checked luu thi thoi khong luu ra
                            else
                            {
                                if (File.Exists(path))                                
                                    File.Delete(path);
                                
                            }
                            ////////////////////////////////////////////////////////
                            user = user_.Login(txtUsername.Text, txtPassword.Text);
                            login_sts = true;
                            Is_login = true;
                            Is_close = true;
                        }
                        else
                        {
                            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                            args.AutoCloseOptions.Delay = 2000;
                            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                            args.DefaultButtonIndex = 0;
                            args.Caption = "Lỗi đăng nhập. ";
                            args.Text = "Tên đăng nhập hoặc Mật khẩu không đúng. Vui lòng nhập lại. Thông báo này sẽ tự đóng sau 2 giây.";
                            args.Buttons = new DialogResult[] { DialogResult.OK };
                            XtraMessageBox.Show(args).ToString();
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            txtUsername.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 2000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Lỗi đăng nhập. ";
                        args.Text = "Mật khẩu bỏ trống. Vui lòng nhập lại. Thông báo này sẽ tự đóng sau 2 giây.";
                        args.Buttons = new DialogResult[] { DialogResult.OK };
                        XtraMessageBox.Show(args).ToString();
                        txtPassword.Focus();
                    }
                }
                else
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Lỗi đăng nhập. ";
                    args.Text = "Tên đăng nhập bỏ trống. Vui lòng nhập lại. Thông báo này sẽ tự đóng sau 2 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                    txtUsername.Focus();
                }
            };
            simpleButton2.Click += (s, e) => { Application.Exit(); };

            hlkNewUser.Click += (s, e) =>
            {
                frm_CreateUser FRM = new frm_CreateUser();
                FRM.myFinished += this.finished;
                FRM.Show();
            };
        }

        private void textEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtUsername.Text == "")
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 2000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Lỗi đổi mật khẩu. ";
                args.Text = "Vui lòng điền tên đăng nhập trước khi đổi mật khẩu. Thông báo này sẽ tự đóng sau 2 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
                txtUsername.Focus();
            }
            else
            {
                if (txtPassword.Text == "")
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Lỗi đăng nhập ";
                    args.Text = "Vui lòng điền mật khẩu. Thông báo này sẽ tự đóng sau 2 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                    txtPassword.Focus();
                }
                else
                {
                    if (user_.CheckUser(txtUsername.Text.ToString().Trim(), txtPassword.Text.ToString().Trim()) == true)
                    {
                        frm_ChangePass frm = new frm_ChangePass();
                        frm.user.Username = txtUsername.Text;
                        frm.user.Password = txtPassword.Text;
                        frm.Show();
                    }
                    else
                    {
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 2000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Lỗi đăng nhập ";
                        args.Text = "Tên đăng nhập hoặc mật khẩu không đúng. Thông báo này sẽ tự đóng sau 2 giây.";
                        args.Buttons = new DialogResult[] { DialogResult.OK };
                        XtraMessageBox.Show(args).ToString();
                    }
                }
            }
        }

        //private void setLanguage(string cultureName)
        //{
        //    culture = CultureInfo.CreateSpecificCulture(cultureName);
        //    ResourceManager resource = new ResourceManager("Production.LAN.LAN", typeof(frm_Login).Assembly);
        //    //layoutControlItem1.Text = resource.GetString("Ten", culture);
        //    //layoutControlItem2.Text = resource.GetString("Matkhau", culture);
        //    //simpleButton1.Text = resource.GetString("Dangnhap", culture);
        //    //simpleButton2.Text = resource.GetString("Thoat", culture);
        //}

        public void finished(object sender)
        {
            //Enable
            this.Enabled = true;
            //
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();
            this.Visible = true;
        }
    }
}