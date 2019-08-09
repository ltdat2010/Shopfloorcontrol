namespace Production.Class
{
    partial class frm_ChangePass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChangePass));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pictureEdit1);
            this.layoutControl1.Controls.Add(this.textEdit3);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Location = new System.Drawing.Point(57, 33);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(238, 95);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(44, 71);
            this.pictureEdit1.StyleController = this.layoutControl1;
            this.pictureEdit1.TabIndex = 5;
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(140, 60);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.PasswordChar = '*';
            this.textEdit3.Size = new System.Drawing.Size(86, 20);
            this.textEdit3.StyleController = this.layoutControl1;
            this.textEdit3.TabIndex = 4;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(140, 36);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.PasswordChar = '*';
            this.textEdit2.Size = new System.Drawing.Size(86, 20);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 2;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(140, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.PasswordChar = '*';
            this.textEdit1.Size = new System.Drawing.Size(86, 20);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(238, 95);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(48, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(170, 24);
            this.layoutControlItem1.Text = "Old Password :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(48, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(170, 24);
            this.layoutControlItem2.Text = "New Password :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit3;
            this.layoutControlItem3.CustomizationFormText = "Nhập lại :";
            this.layoutControlItem3.Location = new System.Drawing.Point(48, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(170, 27);
            this.layoutControlItem3.Text = "Repeat :";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.pictureEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(48, 75);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(150, 121);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(64, 39);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Save";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton2.Location = new System.Drawing.Point(223, 121);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(61, 39);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "Cancel";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // frm_ChangePass
            // 
            this.AcceptButton = this.simpleButton1;
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 178);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: Login ::";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}