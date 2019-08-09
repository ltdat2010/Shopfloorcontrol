namespace Production.Class
{
    partial class frm_CreateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CreateUser));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lkeDept = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lkeGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cmbLan = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(250, 275);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 42);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(96, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(271, 37);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "CREATE NEW USER";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(338, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cmbLan);
            this.layoutControl1.Controls.Add(this.lkeGroup);
            this.layoutControl1.Controls.Add(this.lkeDept);
            this.layoutControl1.Controls.Add(this.txtFullName);
            this.layoutControl1.Controls.Add(this.textEdit4);
            this.layoutControl1.Controls.Add(this.txtUser);
            this.layoutControl1.Controls.Add(this.txtPassword);
            this.layoutControl1.Location = new System.Drawing.Point(176, 93);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(265, 179);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEdit4
            // 
            this.textEdit4.Location = new System.Drawing.Point(70, 147);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.NullText = "ASL-SAP";
            this.textEdit4.Properties.NullValuePrompt = "ASL-SAP";
            this.textEdit4.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEdit4.Size = new System.Drawing.Size(192, 20);
            this.textEdit4.StyleController = this.layoutControl1;
            this.textEdit4.TabIndex = 4;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(70, 3);
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUser.Properties.Appearance.Options.UseBackColor = true;
            this.txtUser.Size = new System.Drawing.Size(192, 20);
            this.txtUser.StyleController = this.layoutControl1;
            this.txtUser.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(70, 27);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 20);
            this.txtPassword.StyleController = this.layoutControl1;
            this.txtPassword.TabIndex = 2;
            this.txtPassword.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.textEdit2_ButtonClick);
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
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(265, 179);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHtmlStringInCaption = true;
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.txtUser;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem1.Text = "UserName :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.txtPassword;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem2.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem2.Text = "Password :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit4;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(263, 33);
            this.layoutControlItem3.Text = "Server :";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 13);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(79, 93);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(90, 74);
            this.pictureEdit1.TabIndex = 5;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(70, 51);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(192, 20);
            this.txtFullName.StyleController = this.layoutControl1;
            this.txtFullName.TabIndex = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtFullName;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem4.Text = "Full Name :";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lkeDept
            // 
            this.lkeDept.Location = new System.Drawing.Point(70, 75);
            this.lkeDept.Name = "lkeDept";
            this.lkeDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeDept.Size = new System.Drawing.Size(192, 20);
            this.lkeDept.StyleController = this.layoutControl1;
            this.lkeDept.TabIndex = 6;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkeDept;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem5.Text = "Department :";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lkeGroup
            // 
            this.lkeGroup.Location = new System.Drawing.Point(70, 99);
            this.lkeGroup.Name = "lkeGroup";
            this.lkeGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeGroup.Size = new System.Drawing.Size(192, 20);
            this.lkeGroup.StyleController = this.layoutControl1;
            this.lkeGroup.TabIndex = 7;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lkeGroup;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem6.Text = "Group :";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(64, 13);
            // 
            // cmbLan
            // 
            this.cmbLan.Location = new System.Drawing.Point(70, 123);
            this.cmbLan.Name = "cmbLan";
            this.cmbLan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLan.Properties.Items.AddRange(new object[] {
            "VN",
            "EN"});
            this.cmbLan.Size = new System.Drawing.Size(192, 20);
            this.cmbLan.StyleController = this.layoutControl1;
            this.cmbLan.TabIndex = 8;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cmbLan;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem7.Text = "Language :";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(64, 13);
            // 
            // frm_CreateUser
            // 
            this.AcceptButton = this.btnSave;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 332);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Caramel";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_CreateUser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: Login ::";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkeGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.ButtonEdit txtPassword;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit lkeGroup;
        private DevExpress.XtraEditors.LookUpEdit lkeDept;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}