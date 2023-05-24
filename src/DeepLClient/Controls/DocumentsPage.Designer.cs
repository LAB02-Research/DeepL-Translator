namespace DeepLClient.Controls
{
    partial class DocumentsPage
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
            components = new System.ComponentModel.Container();
            BtnBrowse = new Syncfusion.WinForms.Controls.SfButton();
            TbSourceDocument = new TextBox();
            LblSourceDocument = new Label();
            BtnTranslate = new Syncfusion.WinForms.Controls.SfButton();
            LblState = new Label();
            BtnOpenTranslatedFolder = new Syncfusion.WinForms.Controls.SfButton();
            TbTranslatedDocument = new TextBox();
            label1 = new Label();
            LblTargetLanguage = new Label();
            LblTargetFormality = new Label();
            LblSourceLanguage = new Label();
            CbTargetFormality = new ComboBox();
            CbTargetLanguage = new ComboBox();
            CbSourceLanguage = new ComboBox();
            LblFormalityInfo = new Label();
            BtnClean = new Syncfusion.WinForms.Controls.SfButton();
            ToolTip = new ToolTip(components);
            BtnSwitchLanguage = new Syncfusion.WinForms.Controls.SfButton();
            SuspendLayout();
            // 
            // BtnBrowse
            // 
            BtnBrowse.AccessibleDescription = "";
            BtnBrowse.AccessibleName = "";
            BtnBrowse.AccessibleRole = AccessibleRole.PushButton;
            BtnBrowse.Anchor = AnchorStyles.Top;
            BtnBrowse.BackColor = Color.FromArgb(63, 63, 70);
            BtnBrowse.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnBrowse.ForeColor = Color.FromArgb(241, 241, 241);
            BtnBrowse.Location = new Point(821, 49);
            BtnBrowse.Name = "BtnBrowse";
            BtnBrowse.Size = new Size(138, 25);
            BtnBrowse.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnBrowse.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnBrowse.Style.DisabledForeColor = Color.FromArgb(241, 241, 241);
            BtnBrowse.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnBrowse.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnBrowse.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnBrowse.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnBrowse.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnBrowse.Style.PressedForeColor = Color.Black;
            BtnBrowse.TabIndex = 1;
            BtnBrowse.Text = "browse";
            ToolTip.SetToolTip(BtnBrowse, "Browse your local computer for the document you want to translate");
            BtnBrowse.UseVisualStyleBackColor = false;
            BtnBrowse.Click += BtnBrowse_Click;
            // 
            // TbSourceDocument
            // 
            TbSourceDocument.AccessibleDescription = "";
            TbSourceDocument.AccessibleName = "";
            TbSourceDocument.AccessibleRole = AccessibleRole.Text;
            TbSourceDocument.Anchor = AnchorStyles.Top;
            TbSourceDocument.BackColor = Color.FromArgb(63, 63, 70);
            TbSourceDocument.BorderStyle = BorderStyle.FixedSingle;
            TbSourceDocument.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TbSourceDocument.ForeColor = Color.FromArgb(241, 241, 241);
            TbSourceDocument.Location = new Point(38, 49);
            TbSourceDocument.Name = "TbSourceDocument";
            TbSourceDocument.Size = new Size(777, 25);
            TbSourceDocument.TabIndex = 0;
            TbSourceDocument.DoubleClick += TbSourceDocument_DoubleClick;
            // 
            // LblSourceDocument
            // 
            LblSourceDocument.AccessibleDescription = "";
            LblSourceDocument.AccessibleName = "";
            LblSourceDocument.AccessibleRole = AccessibleRole.StaticText;
            LblSourceDocument.Anchor = AnchorStyles.Top;
            LblSourceDocument.AutoSize = true;
            LblSourceDocument.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblSourceDocument.Location = new Point(35, 27);
            LblSourceDocument.Name = "LblSourceDocument";
            LblSourceDocument.Size = new Size(115, 19);
            LblSourceDocument.TabIndex = 65;
            LblSourceDocument.Text = "source document";
            // 
            // BtnTranslate
            // 
            BtnTranslate.AccessibleDescription = "Closes the window without saving your changes.";
            BtnTranslate.AccessibleName = "Close no save";
            BtnTranslate.AccessibleRole = AccessibleRole.PushButton;
            BtnTranslate.Anchor = AnchorStyles.Top;
            BtnTranslate.BackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnTranslate.ForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.ImageSize = new Size(48, 48);
            BtnTranslate.Location = new Point(38, 262);
            BtnTranslate.Name = "BtnTranslate";
            BtnTranslate.Size = new Size(841, 67);
            BtnTranslate.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.Image = Properties.Resources.book_icon_48;
            BtnTranslate.Style.PressedForeColor = Color.Black;
            BtnTranslate.TabIndex = 5;
            ToolTip.SetToolTip(BtnTranslate, "Translate the document text into the selected language");
            BtnTranslate.UseVisualStyleBackColor = false;
            BtnTranslate.Click += BtnTranslate_Click;
            // 
            // LblState
            // 
            LblState.AccessibleDescription = "Custom browser incognito arguments textbox description.";
            LblState.AccessibleName = "Custom browser incognito arguments info";
            LblState.AccessibleRole = AccessibleRole.StaticText;
            LblState.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LblState.BorderStyle = BorderStyle.FixedSingle;
            LblState.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblState.Location = new Point(35, 515);
            LblState.Name = "LblState";
            LblState.Size = new Size(924, 115);
            LblState.TabIndex = 67;
            LblState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnOpenTranslatedFolder
            // 
            BtnOpenTranslatedFolder.AccessibleDescription = "";
            BtnOpenTranslatedFolder.AccessibleName = "";
            BtnOpenTranslatedFolder.AccessibleRole = AccessibleRole.PushButton;
            BtnOpenTranslatedFolder.Anchor = AnchorStyles.Top;
            BtnOpenTranslatedFolder.BackColor = Color.FromArgb(63, 63, 70);
            BtnOpenTranslatedFolder.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnOpenTranslatedFolder.ForeColor = Color.FromArgb(241, 241, 241);
            BtnOpenTranslatedFolder.Location = new Point(821, 204);
            BtnOpenTranslatedFolder.Name = "BtnOpenTranslatedFolder";
            BtnOpenTranslatedFolder.Size = new Size(138, 25);
            BtnOpenTranslatedFolder.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnOpenTranslatedFolder.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnOpenTranslatedFolder.Style.DisabledForeColor = Color.FromArgb(241, 241, 241);
            BtnOpenTranslatedFolder.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnOpenTranslatedFolder.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnOpenTranslatedFolder.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnOpenTranslatedFolder.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnOpenTranslatedFolder.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnOpenTranslatedFolder.Style.PressedForeColor = Color.Black;
            BtnOpenTranslatedFolder.TabIndex = 6;
            BtnOpenTranslatedFolder.Text = "open folder";
            ToolTip.SetToolTip(BtnOpenTranslatedFolder, "Open the translated document's folder");
            BtnOpenTranslatedFolder.UseVisualStyleBackColor = false;
            BtnOpenTranslatedFolder.Click += BtnOpenTranslatedFolder_Click;
            // 
            // TbTranslatedDocument
            // 
            TbTranslatedDocument.AccessibleDescription = "";
            TbTranslatedDocument.AccessibleName = "";
            TbTranslatedDocument.AccessibleRole = AccessibleRole.Text;
            TbTranslatedDocument.Anchor = AnchorStyles.Top;
            TbTranslatedDocument.BackColor = Color.FromArgb(63, 63, 70);
            TbTranslatedDocument.BorderStyle = BorderStyle.FixedSingle;
            TbTranslatedDocument.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TbTranslatedDocument.ForeColor = Color.FromArgb(241, 241, 241);
            TbTranslatedDocument.Location = new Point(38, 204);
            TbTranslatedDocument.Name = "TbTranslatedDocument";
            TbTranslatedDocument.ReadOnly = true;
            TbTranslatedDocument.Size = new Size(777, 25);
            TbTranslatedDocument.TabIndex = 68;
            TbTranslatedDocument.DoubleClick += TbTranslatedDocument_DoubleClick;
            // 
            // label1
            // 
            label1.AccessibleDescription = "Custom browser incognito arguments textbox description.";
            label1.AccessibleName = "Custom browser incognito arguments info";
            label1.AccessibleRole = AccessibleRole.StaticText;
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(35, 182);
            label1.Name = "label1";
            label1.Size = new Size(136, 19);
            label1.TabIndex = 70;
            label1.Text = "translated document";
            // 
            // LblTargetLanguage
            // 
            LblTargetLanguage.AccessibleDescription = "";
            LblTargetLanguage.AccessibleName = "";
            LblTargetLanguage.AccessibleRole = AccessibleRole.StaticText;
            LblTargetLanguage.Anchor = AnchorStyles.Top;
            LblTargetLanguage.AutoSize = true;
            LblTargetLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblTargetLanguage.Location = new Point(433, 103);
            LblTargetLanguage.Name = "LblTargetLanguage";
            LblTargetLanguage.Size = new Size(106, 19);
            LblTargetLanguage.TabIndex = 76;
            LblTargetLanguage.Text = "target language";
            // 
            // LblTargetFormality
            // 
            LblTargetFormality.AccessibleDescription = "";
            LblTargetFormality.AccessibleName = "";
            LblTargetFormality.AccessibleRole = AccessibleRole.StaticText;
            LblTargetFormality.Anchor = AnchorStyles.Top;
            LblTargetFormality.AutoSize = true;
            LblTargetFormality.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblTargetFormality.Location = new Point(643, 103);
            LblTargetFormality.Name = "LblTargetFormality";
            LblTargetFormality.Size = new Size(104, 19);
            LblTargetFormality.TabIndex = 75;
            LblTargetFormality.Text = "target formality";
            LblTargetFormality.Visible = false;
            // 
            // LblSourceLanguage
            // 
            LblSourceLanguage.AccessibleDescription = "";
            LblSourceLanguage.AccessibleName = "";
            LblSourceLanguage.AccessibleRole = AccessibleRole.StaticText;
            LblSourceLanguage.Anchor = AnchorStyles.Top;
            LblSourceLanguage.AutoSize = true;
            LblSourceLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblSourceLanguage.Location = new Point(38, 103);
            LblSourceLanguage.Name = "LblSourceLanguage";
            LblSourceLanguage.Size = new Size(109, 19);
            LblSourceLanguage.TabIndex = 74;
            LblSourceLanguage.Text = "source language";
            // 
            // CbTargetFormality
            // 
            CbTargetFormality.AccessibleDescription = "";
            CbTargetFormality.AccessibleName = "";
            CbTargetFormality.AccessibleRole = AccessibleRole.DropList;
            CbTargetFormality.Anchor = AnchorStyles.Top;
            CbTargetFormality.BackColor = Color.FromArgb(63, 63, 70);
            CbTargetFormality.DrawMode = DrawMode.OwnerDrawFixed;
            CbTargetFormality.DropDownHeight = 300;
            CbTargetFormality.DropDownStyle = ComboBoxStyle.DropDownList;
            CbTargetFormality.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CbTargetFormality.ForeColor = Color.FromArgb(241, 241, 241);
            CbTargetFormality.FormattingEnabled = true;
            CbTargetFormality.IntegralHeight = false;
            CbTargetFormality.Location = new Point(643, 125);
            CbTargetFormality.Name = "CbTargetFormality";
            CbTargetFormality.Size = new Size(172, 26);
            CbTargetFormality.TabIndex = 4;
            CbTargetFormality.Visible = false;
            // 
            // CbTargetLanguage
            // 
            CbTargetLanguage.AccessibleDescription = "";
            CbTargetLanguage.AccessibleName = "";
            CbTargetLanguage.AccessibleRole = AccessibleRole.DropList;
            CbTargetLanguage.Anchor = AnchorStyles.Top;
            CbTargetLanguage.BackColor = Color.FromArgb(63, 63, 70);
            CbTargetLanguage.DrawMode = DrawMode.OwnerDrawFixed;
            CbTargetLanguage.DropDownHeight = 300;
            CbTargetLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            CbTargetLanguage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CbTargetLanguage.ForeColor = Color.FromArgb(241, 241, 241);
            CbTargetLanguage.FormattingEnabled = true;
            CbTargetLanguage.IntegralHeight = false;
            CbTargetLanguage.Location = new Point(433, 125);
            CbTargetLanguage.Name = "CbTargetLanguage";
            CbTargetLanguage.Size = new Size(204, 26);
            CbTargetLanguage.TabIndex = 3;
            CbTargetLanguage.SelectedValueChanged += CbTargetLanguage_SelectedValueChanged;
            // 
            // CbSourceLanguage
            // 
            CbSourceLanguage.AccessibleDescription = "";
            CbSourceLanguage.AccessibleName = "";
            CbSourceLanguage.AccessibleRole = AccessibleRole.DropList;
            CbSourceLanguage.Anchor = AnchorStyles.Top;
            CbSourceLanguage.BackColor = Color.FromArgb(63, 63, 70);
            CbSourceLanguage.DrawMode = DrawMode.OwnerDrawFixed;
            CbSourceLanguage.DropDownHeight = 300;
            CbSourceLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            CbSourceLanguage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CbSourceLanguage.ForeColor = Color.FromArgb(241, 241, 241);
            CbSourceLanguage.FormattingEnabled = true;
            CbSourceLanguage.IntegralHeight = false;
            CbSourceLanguage.Location = new Point(38, 125);
            CbSourceLanguage.Name = "CbSourceLanguage";
            CbSourceLanguage.Size = new Size(204, 26);
            CbSourceLanguage.TabIndex = 2;
            // 
            // LblFormalityInfo
            // 
            LblFormalityInfo.AccessibleDescription = "";
            LblFormalityInfo.AccessibleName = "";
            LblFormalityInfo.AccessibleRole = AccessibleRole.PushButton;
            LblFormalityInfo.Anchor = AnchorStyles.Top;
            LblFormalityInfo.AutoSize = true;
            LblFormalityInfo.Cursor = Cursors.Hand;
            LblFormalityInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LblFormalityInfo.Location = new Point(798, 100);
            LblFormalityInfo.Name = "LblFormalityInfo";
            LblFormalityInfo.Size = new Size(17, 21);
            LblFormalityInfo.TabIndex = 106;
            LblFormalityInfo.Text = "?";
            LblFormalityInfo.Visible = false;
            LblFormalityInfo.Click += LblFormalityInfo_Click;
            // 
            // BtnClean
            // 
            BtnClean.AccessibleDescription = "";
            BtnClean.AccessibleName = "";
            BtnClean.AccessibleRole = AccessibleRole.PushButton;
            BtnClean.Anchor = AnchorStyles.Top;
            BtnClean.BackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClean.ForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.ImageSize = new Size(32, 32);
            BtnClean.Location = new Point(885, 262);
            BtnClean.Name = "BtnClean";
            BtnClean.Size = new Size(74, 67);
            BtnClean.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.Style.Image = Properties.Resources.clean_icon_32;
            BtnClean.Style.PressedForeColor = Color.Black;
            BtnClean.TabIndex = 108;
            ToolTip.SetToolTip(BtnClean, "Clear everything and prepare for a new translation");
            BtnClean.UseVisualStyleBackColor = false;
            BtnClean.Click += BtnClean_Click;
            // 
            // ToolTip
            // 
            ToolTip.AutoPopDelay = 5000;
            ToolTip.BackColor = Color.FromArgb(241, 241, 241);
            ToolTip.ForeColor = Color.FromArgb(45, 45, 48);
            ToolTip.InitialDelay = 1000;
            ToolTip.ReshowDelay = 100;
            // 
            // BtnSwitchLanguage
            // 
            BtnSwitchLanguage.AccessibleDescription = "";
            BtnSwitchLanguage.AccessibleName = "";
            BtnSwitchLanguage.AccessibleRole = AccessibleRole.PushButton;
            BtnSwitchLanguage.Anchor = AnchorStyles.Top;
            BtnSwitchLanguage.BackColor = Color.FromArgb(63, 63, 70);
            BtnSwitchLanguage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnSwitchLanguage.ForeColor = Color.FromArgb(241, 241, 241);
            BtnSwitchLanguage.ImageSize = new Size(32, 32);
            BtnSwitchLanguage.Location = new Point(290, 125);
            BtnSwitchLanguage.Name = "BtnSwitchLanguage";
            BtnSwitchLanguage.Size = new Size(93, 26);
            BtnSwitchLanguage.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnSwitchLanguage.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnSwitchLanguage.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnSwitchLanguage.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnSwitchLanguage.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnSwitchLanguage.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnSwitchLanguage.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnSwitchLanguage.Style.Image = Properties.Resources.switch_icon_32;
            BtnSwitchLanguage.Style.PressedForeColor = Color.Black;
            BtnSwitchLanguage.TabIndex = 119;
            ToolTip.SetToolTip(BtnSwitchLanguage, "Switch source and target language.");
            BtnSwitchLanguage.UseVisualStyleBackColor = false;
            BtnSwitchLanguage.Click += BtnSwitchLanguage_Click;
            // 
            // DocumentsPage
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(BtnTranslate);
            Controls.Add(BtnSwitchLanguage);
            Controls.Add(BtnClean);
            Controls.Add(LblFormalityInfo);
            Controls.Add(LblTargetLanguage);
            Controls.Add(LblTargetFormality);
            Controls.Add(LblSourceLanguage);
            Controls.Add(CbTargetFormality);
            Controls.Add(CbTargetLanguage);
            Controls.Add(CbSourceLanguage);
            Controls.Add(BtnOpenTranslatedFolder);
            Controls.Add(TbTranslatedDocument);
            Controls.Add(label1);
            Controls.Add(LblState);
            Controls.Add(BtnBrowse);
            Controls.Add(TbSourceDocument);
            Controls.Add(LblSourceDocument);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            Name = "DocumentsPage";
            Size = new Size(993, 654);
            Load += DocumentsPage_Load;
            SizeChanged += DocumentsPage_SizeChanged;
            DragDrop += DocumentsPage_DragDrop;
            DragEnter += DocumentsPage_DragEnter;
            Resize += DocumentsPage_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Syncfusion.WinForms.Controls.SfButton BtnBrowse;
        internal TextBox TbSourceDocument;
        private Label LblSourceDocument;
        private Syncfusion.WinForms.Controls.SfButton BtnTranslate;
        private Label LblState;
        internal Syncfusion.WinForms.Controls.SfButton BtnOpenTranslatedFolder;
        internal TextBox TbTranslatedDocument;
        private Label label1;
        private Label LblTargetLanguage;
        private Label LblTargetFormality;
        private Label LblSourceLanguage;
        private ComboBox CbTargetFormality;
        private ComboBox CbTargetLanguage;
        private ComboBox CbSourceLanguage;
        private Label LblFormalityInfo;
        private Syncfusion.WinForms.Controls.SfButton BtnClean;
        private ToolTip ToolTip;
        private Syncfusion.WinForms.Controls.SfButton BtnSwitchLanguage;
    }
}
