namespace DeepLClient.Controls
{
    partial class UrlPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrlPage));
            BtnTranslate = new Syncfusion.WinForms.Controls.SfButton();
            CbSourceLanguage = new ComboBox();
            CbTargetLanguage = new ComboBox();
            LblSourceLanguage = new Label();
            LblTargetLanguage = new Label();
            LblCost = new Label();
            LblDetectedInfo = new Label();
            LblDetected = new Label();
            label1 = new Label();
            BtnCopyClipboard = new Syncfusion.WinForms.Controls.SfButton();
            LblClipboardCopied = new Label();
            label2 = new Label();
            LblCharacters = new Label();
            BtnClean = new Syncfusion.WinForms.Controls.SfButton();
            TbUrl = new TextBox();
            LblSourceDocument = new Label();
            WebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            PnlWebView = new Panel();
            LblState = new Label();
            PbWarning = new PictureBox();
            BtnPrint = new Syncfusion.WinForms.Controls.SfButton();
            BtnSave = new Syncfusion.WinForms.Controls.SfButton();
            BtnOpenInBrowser = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)WebView).BeginInit();
            PnlWebView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbWarning).BeginInit();
            SuspendLayout();
            // 
            // BtnTranslate
            // 
            BtnTranslate.AccessibleDescription = "";
            BtnTranslate.AccessibleName = "";
            BtnTranslate.AccessibleRole = AccessibleRole.PushButton;
            BtnTranslate.BackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnTranslate.ForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.ImageSize = new Size(24, 24);
            BtnTranslate.Location = new Point(14, 78);
            BtnTranslate.Name = "BtnTranslate";
            BtnTranslate.Size = new Size(865, 44);
            BtnTranslate.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.Image = Properties.Resources.book_icon_24;
            BtnTranslate.Style.PressedForeColor = Color.Black;
            BtnTranslate.TabIndex = 3;
            BtnTranslate.UseVisualStyleBackColor = false;
            BtnTranslate.Click += BtnTranslate_Click;
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
            CbSourceLanguage.Location = new Point(403, 35);
            CbSourceLanguage.Name = "CbSourceLanguage";
            CbSourceLanguage.Size = new Size(204, 26);
            CbSourceLanguage.TabIndex = 1;
            CbSourceLanguage.SelectedValueChanged += CbSourceLanguage_SelectedValueChanged;
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
            CbTargetLanguage.Location = new Point(773, 35);
            CbTargetLanguage.Name = "CbTargetLanguage";
            CbTargetLanguage.Size = new Size(204, 26);
            CbTargetLanguage.TabIndex = 2;
            // 
            // LblSourceLanguage
            // 
            LblSourceLanguage.AccessibleDescription = "";
            LblSourceLanguage.AccessibleName = "";
            LblSourceLanguage.AccessibleRole = AccessibleRole.StaticText;
            LblSourceLanguage.AutoSize = true;
            LblSourceLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblSourceLanguage.Location = new Point(403, 13);
            LblSourceLanguage.Name = "LblSourceLanguage";
            LblSourceLanguage.Size = new Size(109, 19);
            LblSourceLanguage.TabIndex = 66;
            LblSourceLanguage.Text = "source language";
            // 
            // LblTargetLanguage
            // 
            LblTargetLanguage.AccessibleDescription = "";
            LblTargetLanguage.AccessibleName = "";
            LblTargetLanguage.AccessibleRole = AccessibleRole.StaticText;
            LblTargetLanguage.AutoSize = true;
            LblTargetLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblTargetLanguage.Location = new Point(773, 13);
            LblTargetLanguage.Name = "LblTargetLanguage";
            LblTargetLanguage.Size = new Size(106, 19);
            LblTargetLanguage.TabIndex = 68;
            LblTargetLanguage.Text = "target language";
            // 
            // LblCost
            // 
            LblCost.AccessibleDescription = "";
            LblCost.AccessibleName = "";
            LblCost.AccessibleRole = AccessibleRole.StaticText;
            LblCost.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblCost.Location = new Point(302, 624);
            LblCost.Name = "LblCost";
            LblCost.Size = new Size(77, 22);
            LblCost.TabIndex = 69;
            LblCost.Text = "€ 0,00";
            LblCost.TextAlign = ContentAlignment.TopRight;
            // 
            // LblDetectedInfo
            // 
            LblDetectedInfo.AccessibleDescription = "";
            LblDetectedInfo.AccessibleName = "";
            LblDetectedInfo.AccessibleRole = AccessibleRole.StaticText;
            LblDetectedInfo.AutoSize = true;
            LblDetectedInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblDetectedInfo.Location = new Point(624, 13);
            LblDetectedInfo.Name = "LblDetectedInfo";
            LblDetectedInfo.Size = new Size(122, 19);
            LblDetectedInfo.TabIndex = 70;
            LblDetectedInfo.Text = "detected language";
            LblDetectedInfo.Visible = false;
            // 
            // LblDetected
            // 
            LblDetected.AccessibleDescription = "";
            LblDetected.AccessibleName = "";
            LblDetected.AccessibleRole = AccessibleRole.StaticText;
            LblDetected.AutoSize = true;
            LblDetected.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblDetected.Location = new Point(624, 38);
            LblDetected.Name = "LblDetected";
            LblDetected.Size = new Size(0, 19);
            LblDetected.TabIndex = 71;
            LblDetected.Visible = false;
            // 
            // label1
            // 
            label1.AccessibleDescription = "";
            label1.AccessibleName = "";
            label1.AccessibleRole = AccessibleRole.StaticText;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(204, 624);
            label1.Name = "label1";
            label1.Size = new Size(101, 19);
            label1.TabIndex = 72;
            label1.Text = "estimated cost:";
            // 
            // BtnCopyClipboard
            // 
            BtnCopyClipboard.AccessibleDescription = "";
            BtnCopyClipboard.AccessibleName = "";
            BtnCopyClipboard.AccessibleRole = AccessibleRole.PushButton;
            BtnCopyClipboard.BackColor = Color.FromArgb(63, 63, 70);
            BtnCopyClipboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnCopyClipboard.ForeColor = Color.FromArgb(241, 241, 241);
            BtnCopyClipboard.ImageSize = new Size(16, 16);
            BtnCopyClipboard.Location = new Point(639, 621);
            BtnCopyClipboard.Name = "BtnCopyClipboard";
            BtnCopyClipboard.Size = new Size(80, 24);
            BtnCopyClipboard.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnCopyClipboard.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnCopyClipboard.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnCopyClipboard.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnCopyClipboard.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnCopyClipboard.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnCopyClipboard.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnCopyClipboard.Style.Image = Properties.Resources.clipboard_icon_16;
            BtnCopyClipboard.Style.PressedForeColor = Color.Black;
            BtnCopyClipboard.TabIndex = 4;
            BtnCopyClipboard.UseVisualStyleBackColor = false;
            BtnCopyClipboard.Click += BtnCopyClipboard_Click;
            // 
            // LblClipboardCopied
            // 
            LblClipboardCopied.AccessibleDescription = "";
            LblClipboardCopied.AccessibleName = "";
            LblClipboardCopied.AccessibleRole = AccessibleRole.StaticText;
            LblClipboardCopied.AutoSize = true;
            LblClipboardCopied.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblClipboardCopied.Location = new Point(503, 624);
            LblClipboardCopied.Name = "LblClipboardCopied";
            LblClipboardCopied.Size = new Size(130, 19);
            LblClipboardCopied.TabIndex = 76;
            LblClipboardCopied.Text = "copied to clipboard!";
            LblClipboardCopied.Visible = false;
            // 
            // label2
            // 
            label2.AccessibleDescription = "";
            label2.AccessibleName = "";
            label2.AccessibleRole = AccessibleRole.StaticText;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(14, 624);
            label2.Name = "label2";
            label2.Size = new Size(74, 19);
            label2.TabIndex = 78;
            label2.Text = "characters:";
            // 
            // LblCharacters
            // 
            LblCharacters.AccessibleDescription = "";
            LblCharacters.AccessibleName = "";
            LblCharacters.AccessibleRole = AccessibleRole.StaticText;
            LblCharacters.AutoSize = true;
            LblCharacters.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblCharacters.Location = new Point(94, 624);
            LblCharacters.Name = "LblCharacters";
            LblCharacters.Size = new Size(17, 19);
            LblCharacters.TabIndex = 77;
            LblCharacters.Text = "0";
            LblCharacters.TextAlign = ContentAlignment.TopRight;
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
            BtnClean.Location = new Point(884, 78);
            BtnClean.Name = "BtnClean";
            BtnClean.Size = new Size(93, 44);
            BtnClean.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.Style.Image = Properties.Resources.clean_icon_32;
            BtnClean.Style.PressedForeColor = Color.Black;
            BtnClean.TabIndex = 5;
            BtnClean.UseVisualStyleBackColor = false;
            BtnClean.Click += BtnClean_Click;
            // 
            // TbUrl
            // 
            TbUrl.AccessibleDescription = "";
            TbUrl.AccessibleName = "";
            TbUrl.AccessibleRole = AccessibleRole.Text;
            TbUrl.BackColor = Color.FromArgb(63, 63, 70);
            TbUrl.BorderStyle = BorderStyle.FixedSingle;
            TbUrl.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TbUrl.ForeColor = Color.FromArgb(241, 241, 241);
            TbUrl.Location = new Point(17, 35);
            TbUrl.Name = "TbUrl";
            TbUrl.Size = new Size(368, 25);
            TbUrl.TabIndex = 0;
            TbUrl.KeyUp += TbUrl_KeyUp;
            // 
            // LblSourceDocument
            // 
            LblSourceDocument.AccessibleDescription = "";
            LblSourceDocument.AccessibleName = "";
            LblSourceDocument.AccessibleRole = AccessibleRole.StaticText;
            LblSourceDocument.AutoSize = true;
            LblSourceDocument.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblSourceDocument.Location = new Point(14, 13);
            LblSourceDocument.Name = "LblSourceDocument";
            LblSourceDocument.Size = new Size(25, 19);
            LblSourceDocument.TabIndex = 109;
            LblSourceDocument.Text = "url";
            // 
            // WebView
            // 
            WebView.AllowExternalDrop = true;
            WebView.BackColor = Color.FromArgb(63, 63, 70);
            WebView.CreationProperties = null;
            WebView.DefaultBackgroundColor = Color.FromArgb(63, 63, 70);
            WebView.Dock = DockStyle.Fill;
            WebView.Location = new Point(0, 0);
            WebView.Name = "WebView";
            WebView.Size = new Size(961, 482);
            WebView.TabIndex = 110;
            WebView.ZoomFactor = 1D;
            // 
            // PnlWebView
            // 
            PnlWebView.BackColor = Color.FromArgb(63, 63, 70);
            PnlWebView.BorderStyle = BorderStyle.FixedSingle;
            PnlWebView.Controls.Add(LblState);
            PnlWebView.Controls.Add(WebView);
            PnlWebView.Location = new Point(14, 128);
            PnlWebView.Name = "PnlWebView";
            PnlWebView.Size = new Size(963, 484);
            PnlWebView.TabIndex = 111;
            // 
            // LblState
            // 
            LblState.AccessibleDescription = "";
            LblState.AccessibleName = "";
            LblState.AccessibleRole = AccessibleRole.StaticText;
            LblState.BackColor = Color.FromArgb(63, 63, 70);
            LblState.BorderStyle = BorderStyle.FixedSingle;
            LblState.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblState.ForeColor = Color.FromArgb(241, 241, 241);
            LblState.Location = new Point(0, 0);
            LblState.Name = "LblState";
            LblState.Size = new Size(962, 482);
            LblState.TabIndex = 111;
            LblState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PbWarning
            // 
            PbWarning.Cursor = Cursors.Hand;
            PbWarning.Image = (Image)resources.GetObject("PbWarning.Image");
            PbWarning.Location = new Point(473, 621);
            PbWarning.Name = "PbWarning";
            PbWarning.Size = new Size(24, 24);
            PbWarning.SizeMode = PictureBoxSizeMode.AutoSize;
            PbWarning.TabIndex = 112;
            PbWarning.TabStop = false;
            PbWarning.Visible = false;
            PbWarning.Click += PbWarning_Click;
            // 
            // BtnPrint
            // 
            BtnPrint.AccessibleDescription = "";
            BtnPrint.AccessibleName = "";
            BtnPrint.AccessibleRole = AccessibleRole.PushButton;
            BtnPrint.BackColor = Color.FromArgb(63, 63, 70);
            BtnPrint.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnPrint.ForeColor = Color.FromArgb(241, 241, 241);
            BtnPrint.ImageSize = new Size(16, 16);
            BtnPrint.Location = new Point(811, 621);
            BtnPrint.Name = "BtnPrint";
            BtnPrint.Size = new Size(80, 24);
            BtnPrint.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnPrint.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnPrint.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnPrint.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnPrint.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnPrint.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnPrint.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnPrint.Style.Image = (Image)resources.GetObject("resource.Image");
            BtnPrint.Style.PressedForeColor = Color.Black;
            BtnPrint.TabIndex = 113;
            BtnPrint.UseVisualStyleBackColor = false;
            BtnPrint.Click += BtnPrint_Click;
            // 
            // BtnSave
            // 
            BtnSave.AccessibleDescription = "";
            BtnSave.AccessibleName = "";
            BtnSave.AccessibleRole = AccessibleRole.PushButton;
            BtnSave.BackColor = Color.FromArgb(63, 63, 70);
            BtnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnSave.ForeColor = Color.FromArgb(241, 241, 241);
            BtnSave.ImageSize = new Size(16, 16);
            BtnSave.Location = new Point(897, 621);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(80, 24);
            BtnSave.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnSave.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnSave.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnSave.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnSave.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnSave.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnSave.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnSave.Style.Image = Properties.Resources.save_icon_24;
            BtnSave.Style.PressedForeColor = Color.Black;
            BtnSave.TabIndex = 114;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnOpenInBrowser
            // 
            BtnOpenInBrowser.AccessibleDescription = "";
            BtnOpenInBrowser.AccessibleName = "";
            BtnOpenInBrowser.AccessibleRole = AccessibleRole.PushButton;
            BtnOpenInBrowser.BackColor = Color.FromArgb(63, 63, 70);
            BtnOpenInBrowser.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnOpenInBrowser.ForeColor = Color.FromArgb(241, 241, 241);
            BtnOpenInBrowser.ImageSize = new Size(16, 16);
            BtnOpenInBrowser.Location = new Point(725, 621);
            BtnOpenInBrowser.Name = "BtnOpenInBrowser";
            BtnOpenInBrowser.Size = new Size(80, 24);
            BtnOpenInBrowser.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnOpenInBrowser.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnOpenInBrowser.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnOpenInBrowser.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnOpenInBrowser.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnOpenInBrowser.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnOpenInBrowser.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnOpenInBrowser.Style.Image = Properties.Resources.globe_icon_24;
            BtnOpenInBrowser.Style.PressedForeColor = Color.Black;
            BtnOpenInBrowser.TabIndex = 115;
            BtnOpenInBrowser.UseVisualStyleBackColor = false;
            BtnOpenInBrowser.Click += BtnOpenInBrowser_Click;
            // 
            // UrlPage
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(BtnOpenInBrowser);
            Controls.Add(BtnSave);
            Controls.Add(BtnPrint);
            Controls.Add(PbWarning);
            Controls.Add(PnlWebView);
            Controls.Add(TbUrl);
            Controls.Add(LblSourceDocument);
            Controls.Add(BtnClean);
            Controls.Add(label2);
            Controls.Add(LblCharacters);
            Controls.Add(LblClipboardCopied);
            Controls.Add(BtnCopyClipboard);
            Controls.Add(label1);
            Controls.Add(LblDetected);
            Controls.Add(LblDetectedInfo);
            Controls.Add(LblCost);
            Controls.Add(LblTargetLanguage);
            Controls.Add(LblSourceLanguage);
            Controls.Add(CbTargetLanguage);
            Controls.Add(CbSourceLanguage);
            Controls.Add(BtnTranslate);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            Name = "UrlPage";
            Size = new Size(993, 654);
            Load += UrlPage_Load;
            DragDrop += UrlPage_DragDrop;
            DragEnter += UrlPage_DragEnter;
            ((System.ComponentModel.ISupportInitialize)WebView).EndInit();
            PnlWebView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PbWarning).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox CbSourceLanguage;
        private ComboBox CbTargetLanguage;
        private Label LblSourceLanguage;
        private Label LblTargetLanguage;
        private Label LblCost;
        private Label LblDetectedInfo;
        private Label LblDetected;
        private Label label1;
        private Syncfusion.WinForms.Controls.SfButton BtnCopyClipboard;
        private Label LblClipboardCopied;
        private Label label2;
        private Label LblCharacters;
        private Syncfusion.WinForms.Controls.SfButton BtnClean;
        internal Syncfusion.WinForms.Controls.SfButton BtnTranslate;
        internal TextBox TbUrl;
        private Label LblSourceDocument;
        private Microsoft.Web.WebView2.WinForms.WebView2 WebView;
        private Panel PnlWebView;
        private Label LblState;
        private PictureBox PbWarning;
        private Syncfusion.WinForms.Controls.SfButton BtnPrint;
        private Syncfusion.WinForms.Controls.SfButton BtnSave;
        private Syncfusion.WinForms.Controls.SfButton BtnOpenInBrowser;
    }
}
