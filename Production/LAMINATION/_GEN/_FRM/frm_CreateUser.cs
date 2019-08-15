using DevExpress.XtraEditors;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class frm_CreateUser : frm_Base
    {
        public bool ischkDashBoardEnabled;

        //User user = new User();
        private User_ user_ = new User_();

        private UserBUS BUS = new UserBUS();

        private CultureInfo culture;
        public RijndaelManaged key = null;

        private string path = @"D:\pkl.xml";

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

        public frm_CreateUser()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                btnSave.Enabled = false;

                //XmlDocument document = new XmlDocument();
                //if (File.Exists(path))
                //{
                //    document.Load(path);
                //    //Decrypt(document, key);
                //    //duyet qua XML
                //    XmlNodeList nodes = document.DocumentElement.ChildNodes;
                //    foreach (XmlNode childnode in nodes)
                //    {
                //        foreach (XmlNode node in childnode.ChildNodes)
                //        {
                //            if (node.Name == "user")
                //            {
                //                txtUser.Text = Production.Class._GEN.EncryptKey.Decrypt(node.InnerText,true);
                //            }
                //            if (node.Name == "pass")
                //            {
                //                txtPassword.Text = Production.Class._GEN.EncryptKey.Decrypt(node.InnerText,true);
                //            }
                //        }
                //    }
                //}
            };
            btnSave.Click += (s, e) =>
            {
                if (txtUser.Text != "")
                {
                    if (txtPassword.Text != "")
                    {
                        user = user_.Login(txtUser.Text, txtPassword.Text);
                        if (user.Username != "" && user.Password != null)
                        {
                            //Login thanh cong
                            //Kiem tra checkbox o day xem co check hay user da go ra
                            //neu check thi save ra file pkl
                            user.Username = Production.Class._GEN.EncryptKey.Encrypt(txtUser.Text, true);
                            user.Password = Production.Class._GEN.EncryptKey.Encrypt(txtPassword.Text, true);
                            user.FullName = txtFullName.Text;
                            user.DeptID = int.Parse(lkeDept.EditValue.ToString());
                            user.GroupID = int.Parse(lkeGroup.EditValue.ToString());
                            user.Language = cmbLan.ToString();

                            BUS.User_INSERT(user);

                            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                            args.AutoCloseOptions.Delay = 1000;
                            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                            args.DefaultButtonIndex = 0;
                            args.Caption = " Thông báo ";
                            args.Text = " Tạo mới user thành công. Thông báo này sẽ tự đóng sau 1 giây.";
                            args.Buttons = new DialogResult[] { DialogResult.OK };
                            XtraMessageBox.Show(args).ToString();

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
                            args.Text = "[Tên đăng nhập] hoặc [Mật khẩu] không được bỏ trống. Vui lòng nhập lại. Thông báo này sẽ tự đóng sau 2 giây.";
                            args.Buttons = new DialogResult[] { DialogResult.OK };
                            XtraMessageBox.Show(args).ToString();
                            txtUser.Text = "";
                            txtPassword.Text = "";
                            txtUser.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 2000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Lỗi đăng nhập. ";
                        args.Text = "[Mật khẩu] không được bỏ trống. Vui lòng nhập lại. Thông báo này sẽ tự đóng sau 2 giây.";
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
                    args.Text = "[Tên đăng nhập] không được bỏ trống. Vui lòng nhập lại. Thông báo này sẽ tự đóng sau 2 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                    txtUser.Focus();
                }
            };
            btnCancel.Click += (s, e) => { Application.Exit(); };
        }

        private void textEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtUser.Text == "")
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 2000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Lỗi đổi mật khẩu. ";
                args.Text = "Vui lòng điền tên đăng nhập trước khi đổi mật khẩu. Thông báo này sẽ tự đóng sau 2 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
                txtUser.Focus();
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
                    if (user_.CheckUser(txtUser.Text.ToString().Trim(), txtPassword.Text.ToString().Trim()) == true)
                    {
                        frm_ChangePass frm = new frm_ChangePass();
                        frm.user.Username = txtUser.Text;
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
    }
}