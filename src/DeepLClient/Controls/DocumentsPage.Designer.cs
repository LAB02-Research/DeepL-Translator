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
            BtnBrowse = new Syncfusion.WinForms.Controls.SfButton();
            TbSourceDocument = new TextBox();
            LblSourceDocument = new Label();
            BtnTranslate = new Syncfusion.WinForms.Controls.SfButton();
            LblState = new Label();
            TbOpenTranslatedFolder = new Syncfusion.WinForms.Controls.SfButton();
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
            SuspendLayout();
            // 
            // BtnBrowse
            // 
            BtnBrowse.AccessibleDescription = "";
            BtnBrowse.AccessibleName = "";
            BtnBrowse.AccessibleRole = AccessibleRole.PushButton;
            BtnBrowse.BackColor = Color.FromArgb(63, 63, 70);
            BtnBrowse.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnBrowse.ForeColor = Color.FromArgb(241, 241, 241);
            BtnBrowse.Location = new Point(821, 45);
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
            BtnBrowse.TabIndex = 64;
            BtnBrowse.Text = "browse";
            BtnBrowse.UseVisualStyleBackColor = false;
            BtnBrowse.Click += BtnBrowse_Click;
            // 
            // TbSourceDocument
            // 
            TbSourceDocument.AccessibleDescription = "";
            TbSourceDocument.AccessibleName = "";
            TbSourceDocument.AccessibleRole = AccessibleRole.Text;
            TbSourceDocument.BackColor = Color.FromArgb(63, 63, 70);
            TbSourceDocument.BorderStyle = BorderStyle.FixedSingle;
            TbSourceDocument.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TbSourceDocument.ForeColor = Color.FromArgb(241, 241, 241);
            TbSourceDocument.Location = new Point(38, 45);
            TbSourceDocument.Name = "TbSourceDocument";
            TbSourceDocument.Size = new Size(777, 25);
            TbSourceDocument.TabIndex = 63;
            TbSourceDocument.DoubleClick += TbSourceDocument_DoubleClick;
            // 
            // LblSourceDocument
            // 
            LblSourceDocument.AccessibleDescription = "";
            LblSourceDocument.AccessibleName = "";
            LblSourceDocument.AccessibleRole = AccessibleRole.StaticText;
            LblSourceDocument.AutoSize = true;
            LblSourceDocument.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblSourceDocument.Location = new Point(35, 23);
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
            BtnTranslate.BackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnTranslate.ForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.ImageSize = new Size(48, 48);
            BtnTranslate.Location = new Point(38, 214);
            BtnTranslate.Name = "BtnTranslate";
            BtnTranslate.Size = new Size(822, 77);
            BtnTranslate.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.Image = Properties.Resources.book_icon_48;
            BtnTranslate.Style.PressedForeColor = Color.Black;
            BtnTranslate.TabIndex = 66;
            BtnTranslate.UseVisualStyleBackColor = false;
            BtnTranslate.Click += BtnTranslate_Click;
            // 
            // LblState
            // 
            LblState.AccessibleDescription = "Custom browser incognito arguments textbox description.";
            LblState.AccessibleName = "Custom browser incognito arguments info";
            LblState.AccessibleRole = AccessibleRole.StaticText;
            LblState.BorderStyle = BorderStyle.FixedSingle;
            LblState.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblState.Location = new Point(38, 314);
            LblState.Name = "LblState";
            LblState.Size = new Size(921, 134);
            LblState.TabIndex = 67;
            LblState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TbOpenTranslatedFolder
            // 
            TbOpenTranslatedFolder.AccessibleDescription = "";
            TbOpenTranslatedFolder.AccessibleName = "";
            TbOpenTranslatedFolder.AccessibleRole = AccessibleRole.PushButton;
            TbOpenTranslatedFolder.BackColor = Color.FromArgb(63, 63, 70);
            TbOpenTranslatedFolder.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TbOpenTranslatedFolder.ForeColor = Color.FromArgb(241, 241, 241);
            TbOpenTranslatedFolder.Location = new Point(821, 517);
            TbOpenTranslatedFolder.Name = "TbOpenTranslatedFolder";
            TbOpenTranslatedFolder.Size = new Size(138, 25);
            TbOpenTranslatedFolder.Style.BackColor = Color.FromArgb(63, 63, 70);
            TbOpenTranslatedFolder.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            TbOpenTranslatedFolder.Style.DisabledForeColor = Color.FromArgb(241, 241, 241);
            TbOpenTranslatedFolder.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            TbOpenTranslatedFolder.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            TbOpenTranslatedFolder.Style.ForeColor = Color.FromArgb(241, 241, 241);
            TbOpenTranslatedFolder.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            TbOpenTranslatedFolder.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            TbOpenTranslatedFolder.Style.PressedForeColor = Color.Black;
            TbOpenTranslatedFolder.TabIndex = 69;
            TbOpenTranslatedFolder.Text = "open folder";
            TbOpenTranslatedFolder.UseVisualStyleBackColor = false;
            TbOpenTranslatedFolder.Click += TbOpenTranslatedFolder_Click;
            // 
            // TbTranslatedDocument
            // 
            TbTranslatedDocument.AccessibleDescription = "";
            TbTranslatedDocument.AccessibleName = "";
            TbTranslatedDocument.AccessibleRole = AccessibleRole.Text;
            TbTranslatedDocument.BackColor = Color.FromArgb(63, 63, 70);
            TbTranslatedDocument.BorderStyle = BorderStyle.FixedSingle;
            TbTranslatedDocument.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TbTranslatedDocument.ForeColor = Color.FromArgb(241, 241, 241);
            TbTranslatedDocument.Location = new Point(38, 517);
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
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(35, 495);
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
            LblTargetLanguage.AutoSize = true;
            LblTargetLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblTargetLanguage.Location = new Point(433, 98);
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
            LblTargetFormality.AutoSize = true;
            LblTargetFormality.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblTargetFormality.Location = new Point(643, 98);
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
            LblSourceLanguage.AutoSize = true;
            LblSourceLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblSourceLanguage.Location = new Point(35, 98);
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
            CbTargetFormality.BackColor = Color.FromArgb(63, 63, 70);
            CbTargetFormality.DrawMode = DrawMode.OwnerDrawFixed;
            CbTargetFormality.DropDownHeight = 300;
            CbTargetFormality.DropDownStyle = ComboBoxStyle.DropDownList;
            CbTargetFormality.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CbTargetFormality.ForeColor = Color.FromArgb(241, 241, 241);
            CbTargetFormality.FormattingEnabled = true;
            CbTargetFormality.IntegralHeight = false;
            CbTargetFormality.Location = new Point(643, 120);
            CbTargetFormality.Name = "CbTargetFormality";
            CbTargetFormality.Size = new Size(172, 26);
            CbTargetFormality.TabIndex = 73;
            CbTargetFormality.Visible = false;
            // 
            // CbTargetLanguage
            // 
            CbTargetLanguage.AccessibleDescription = "";
            CbTargetLanguage.AccessibleName = "";
            CbTargetLanguage.AccessibleRole = AccessibleRole.DropList;
            CbTargetLanguage.BackColor = Color.FromArgb(63, 63, 70);
            CbTargetLanguage.DrawMode = DrawMode.OwnerDrawFixed;
            CbTargetLanguage.DropDownHeight = 300;
            CbTargetLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            CbTargetLanguage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CbTargetLanguage.ForeColor = Color.FromArgb(241, 241, 241);
            CbTargetLanguage.FormattingEnabled = true;
            CbTargetLanguage.IntegralHeight = false;
            CbTargetLanguage.Location = new Point(433, 120);
            CbTargetLanguage.Name = "CbTargetLanguage";
            CbTargetLanguage.Size = new Size(204, 26);
            CbTargetLanguage.TabIndex = 72;
            CbTargetLanguage.SelectedValueChanged += CbTargetLanguage_SelectedValueChanged;
            // 
            // CbSourceLanguage
            // 
            CbSourceLanguage.AccessibleDescription = "";
            CbSourceLanguage.AccessibleName = "";
            CbSourceLanguage.AccessibleRole = AccessibleRole.DropList;
            CbSourceLanguage.BackColor = Color.FromArgb(63, 63, 70);
            CbSourceLanguage.DrawMode = DrawMode.OwnerDrawFixed;
            CbSourceLanguage.DropDownHeight = 300;
            CbSourceLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            CbSourceLanguage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CbSourceLanguage.ForeColor = Color.FromArgb(241, 241, 241);
            CbSourceLanguage.FormattingEnabled = true;
            CbSourceLanguage.IntegralHeight = false;
            CbSourceLanguage.Location = new Point(35, 120);
            CbSourceLanguage.Name = "CbSourceLanguage";
            CbSourceLanguage.Size = new Size(204, 26);
            CbSourceLanguage.TabIndex = 71;
            // 
            // LblFormalityInfo
            // 
            LblFormalityInfo.AccessibleDescription = "";
            LblFormalityInfo.AccessibleName = "";
            LblFormalityInfo.AccessibleRole = AccessibleRole.PushButton;
            LblFormalityInfo.AutoSize = true;
            LblFormalityInfo.Cursor = Cursors.Hand;
            LblFormalityInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LblFormalityInfo.Location = new Point(798, 95);
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
            BtnClean.BackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClean.ForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.ImageSize = new Size(32, 32);
            BtnClean.Location = new Point(866, 214);
            BtnClean.Name = "BtnClean";
            BtnClean.Size = new Size(93, 77);
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
            BtnClean.UseVisualStyleBackColor = false;
            BtnClean.Click += BtnClean_Click;
            // 
            // DocumentsPage
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(BtnClean);
            Controls.Add(LblFormalityInfo);
            Controls.Add(LblTargetLanguage);
            Controls.Add(LblTargetFormality);
            Controls.Add(LblSourceLanguage);
            Controls.Add(CbTargetFormality);
            Controls.Add(CbTargetLanguage);
            Controls.Add(CbSourceLanguage);
            Controls.Add(TbOpenTranslatedFolder);
            Controls.Add(TbTranslatedDocument);
            Controls.Add(label1);
            Controls.Add(LblState);
            Controls.Add(BtnTranslate);
            Controls.Add(BtnBrowse);
            Controls.Add(TbSourceDocument);
            Controls.Add(LblSourceDocument);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            Name = "DocumentsPage";
            Size = new Size(993, 589);
            Load += DocumentsPage_Load;
            DragDrop += DocumentsPage_DragDrop;
            DragEnter += DocumentsPage_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Syncfusion.WinForms.Controls.SfButton BtnBrowse;
        internal TextBox TbSourceDocument;
        private Label LblSourceDocument;
        private Syncfusion.WinForms.Controls.SfButton BtnTranslate;
        private Label LblState;
        internal Syncfusion.WinForms.Controls.SfButton TbOpenTranslatedFolder;
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
    }
}
