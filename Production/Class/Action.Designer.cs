namespace Production.LAMINATION
{
    partial class Action
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Action));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.BtnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.BtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.BtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.BtnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BtnAdd,
            this.BtnEdit,
            this.BtnDelete,
            this.BtnSave,
            this.BtnCancel,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barStaticItem3,
            this.barStaticItem4});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.bar2.BarAppearance.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.bar2.BarAppearance.Normal.ForeColor = System.Drawing.Color.Black;
            this.bar2.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar2.BarAppearance.Normal.Options.UseBorderColor = true;
            this.bar2.BarAppearance.Normal.Options.UseForeColor = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.BtnCancel)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Caption = "Add";
            this.BtnAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Glyph")));
            this.BtnAdd.Id = 0;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "|";
            this.barStaticItem1.Id = 5;
            this.barStaticItem1.ItemClickFireMode = DevExpress.XtraBars.BarItemEventFireMode.Postponed;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BtnEdit
            // 
            this.BtnEdit.Caption = "Edit";
            this.BtnEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnEdit.Glyph")));
            this.BtnEdit.Id = 1;
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "|";
            this.barStaticItem2.Id = 6;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Caption = "Delete";
            this.BtnDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Glyph")));
            this.BtnDelete.Id = 2;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "|";
            this.barStaticItem3.Id = 7;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BtnSave
            // 
            this.BtnSave.Caption = "Save";
            this.BtnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnSave.Glyph")));
            this.BtnSave.Id = 3;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Caption = "|";
            this.barStaticItem4.Id = 8;
            this.barStaticItem4.Name = "barStaticItem4";
            this.barStaticItem4.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Caption = "Cancel";
            this.BtnCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Glyph")));
            this.BtnCancel.Id = 4;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(930, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 24);
            this.barDockControlBottom.Size = new System.Drawing.Size(930, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(930, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // Action
            // 
            this.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Money Twins";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Action";
            this.Size = new System.Drawing.Size(930, 24);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem BtnAdd;
        private DevExpress.XtraBars.BarButtonItem BtnEdit;
        private DevExpress.XtraBars.BarButtonItem BtnDelete;
        private DevExpress.XtraBars.BarButtonItem BtnSave;
        private DevExpress.XtraBars.BarButtonItem BtnCancel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;

    }
}
