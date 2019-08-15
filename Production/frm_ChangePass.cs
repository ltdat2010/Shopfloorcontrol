using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class frm_ChangePass : frm_Base
    {
        private User_ user_ = new User_();

        public frm_ChangePass()
        {
            InitializeComponent();
            simpleButton2.Click += (s, e) => { this.Close(); };
            simpleButton1.Click += (s, e) =>
            {
                if (textEdit1.Text == "")
                {
                    if (user.Language == "vi-VN")
                        XtraMessageBox.Show("Vui lòng nhập Password hiện tại ... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        XtraMessageBox.Show("Please input current Password ... ", " Warming ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    textEdit1.Focus();
                }
                else
                {
                    if (textEdit2.Text == "")
                    {
                        if (user.Language == "vi-VN")
                            XtraMessageBox.Show("Vui lòng nhập ô Password cần đổi ... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            XtraMessageBox.Show("Please input new Password ... ", " Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        textEdit2.Focus();
                    }
                    else
                    {
                        if (textEdit3.Text == "")
                        {
                            if (user.Language == "vi-VN")
                                XtraMessageBox.Show("Vui lòng nhập ô Password lần 2 ... ", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                                XtraMessageBox.Show("Please re-input new Password ... ", " Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            textEdit3.Focus();
                        }
                        else
                        {
                            if (textEdit3.Text != textEdit2.Text)
                            {
                                if (user.Language == "vi-VN")
                                    XtraMessageBox.Show("Mật khẩu không khớp. Vui lòng nhập lại ...", " Lưu ý ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    XtraMessageBox.Show("Password does not match ... ", " Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                textEdit3.Text = "";
                                textEdit2.Text = "";
                                textEdit2.Focus();
                            }
                            else if (textEdit3.Text == textEdit2.Text)
                            {
                                user._Password = textEdit3.Text;
                                user_.UpdatePass(user);
                                this.Close();
                            }
                        }
                    }
                }
            };
        }
    }
}