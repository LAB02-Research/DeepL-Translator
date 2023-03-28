namespace DeepLClient.Controls
{
    partial class TextPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextPage));
            BtnTranslate = new Syncfusion.WinForms.Controls.SfButton();
            CbSourceLanguage = new ComboBox();
            CbTargetLanguage = new ComboBox();
            CbTargetFormality = new ComboBox();
            LblSourceLanguage = new Label();
            LblTargetFormality = new Label();
            LblTargetLanguage = new Label();
            LblCost = new Label();
            LblDetectedInfo = new Label();
            LblDetected = new Label();
            label1 = new Label();
            TbSource = new TextBox();
            BtnCopyClipboard = new Syncfusion.WinForms.Controls.SfButton();
            LblClipboardCopied = new Label();
            label2 = new Label();
            LblCharacters = new Label();
            LblFormalityInfo = new Label();
            BtnClean = new Syncfusion.WinForms.Controls.SfButton();
            BtnSave = new Syncfusion.WinForms.Controls.SfButton();
            BtnPrint = new Syncfusion.WinForms.Controls.SfButton();
            TbTranslated = new TextBox();
            TbSourceScroller = new Syncfusion.WinForms.Controls.SfScrollFrame();
            TbTranslatedScroller = new Syncfusion.WinForms.Controls.SfScrollFrame();
            ToolTip = new ToolTip(components);
            BtnSwitchLanguage = new Syncfusion.WinForms.Controls.SfButton();
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
            BtnTranslate.ImageSize = new Size(48, 48);
            BtnTranslate.Location = new Point(450, 199);
            BtnTranslate.Name = "BtnTranslate";
            BtnTranslate.Size = new Size(93, 190);
            BtnTranslate.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnTranslate.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnTranslate.Style.Image = Properties.Resources.book_icon_48;
            BtnTranslate.Style.PressedForeColor = Color.Black;
            BtnTranslate.TabIndex = 1;
            ToolTip.SetToolTip(BtnTranslate, "Translate the source text into the selected language");
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
            CbSourceLanguage.Location = new Point(14, 35);
            CbSourceLanguage.Name = "CbSourceLanguage";
            CbSourceLanguage.Size = new Size(204, 26);
            CbSourceLanguage.TabIndex = 3;
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
            CbTargetLanguage.Location = new Point(549, 35);
            CbTargetLanguage.Name = "CbTargetLanguage";
            CbTargetLanguage.Size = new Size(204, 26);
            CbTargetLanguage.TabIndex = 4;
            CbTargetLanguage.SelectedValueChanged += CbTargetLanguage_SelectedValueChanged;
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
            CbTargetFormality.Location = new Point(805, 35);
            CbTargetFormality.Name = "CbTargetFormality";
            CbTargetFormality.Size = new Size(172, 26);
            CbTargetFormality.TabIndex = 5;
            CbTargetFormality.Visible = false;
            // 
            // LblSourceLanguage
            // 
            LblSourceLanguage.AccessibleDescription = "";
            LblSourceLanguage.AccessibleName = "";
            LblSourceLanguage.AccessibleRole = AccessibleRole.StaticText;
            LblSourceLanguage.AutoSize = true;
            LblSourceLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblSourceLanguage.Location = new Point(14, 13);
            LblSourceLanguage.Name = "LblSourceLanguage";
            LblSourceLanguage.Size = new Size(109, 19);
            LblSourceLanguage.TabIndex = 66;
            LblSourceLanguage.Text = "source language";
            // 
            // LblTargetFormality
            // 
            LblTargetFormality.AccessibleDescription = "";
            LblTargetFormality.AccessibleName = "";
            LblTargetFormality.AccessibleRole = AccessibleRole.StaticText;
            LblTargetFormality.AutoSize = true;
            LblTargetFormality.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblTargetFormality.Location = new Point(805, 13);
            LblTargetFormality.Name = "LblTargetFormality";
            LblTargetFormality.Size = new Size(104, 19);
            LblTargetFormality.TabIndex = 67;
            LblTargetFormality.Text = "target formality";
            LblTargetFormality.Visible = false;
            // 
            // LblTargetLanguage
            // 
            LblTargetLanguage.AccessibleDescription = "";
            LblTargetLanguage.AccessibleName = "";
            LblTargetLanguage.AccessibleRole = AccessibleRole.StaticText;
            LblTargetLanguage.AutoSize = true;
            LblTargetLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblTargetLanguage.Location = new Point(549, 13);
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
            LblCost.Location = new Point(367, 625);
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
            LblDetectedInfo.Location = new Point(235, 13);
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
            LblDetected.Location = new Point(235, 38);
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
            label1.Location = new Point(266, 624);
            label1.Name = "label1";
            label1.Size = new Size(101, 19);
            label1.TabIndex = 72;
            label1.Text = "estimated cost:";
            // 
            // TbSource
            // 
            TbSource.BackColor = Color.FromArgb(63, 63, 70);
            TbSource.BorderStyle = BorderStyle.FixedSingle;
            TbSource.ForeColor = Color.FromArgb(241, 241, 241);
            TbSource.Location = new Point(14, 80);
            TbSource.Multiline = true;
            TbSource.Name = "TbSource";
            TbSource.ScrollBars = ScrollBars.Vertical;
            TbSource.Size = new Size(430, 535);
            TbSource.TabIndex = 0;
            TbSource.TextChanged += TbSource_TextChanged;
            TbSource.KeyDown += TbSource_KeyDown;
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
            BtnCopyClipboard.Location = new Point(725, 621);
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
            BtnCopyClipboard.TabIndex = 75;
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
            LblClipboardCopied.Location = new Point(589, 624);
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
            LblCharacters.Location = new Point(94, 625);
            LblCharacters.Name = "LblCharacters";
            LblCharacters.Size = new Size(17, 19);
            LblCharacters.TabIndex = 77;
            LblCharacters.Text = "0";
            LblCharacters.TextAlign = ContentAlignment.TopRight;
            // 
            // LblFormalityInfo
            // 
            LblFormalityInfo.AccessibleDescription = "";
            LblFormalityInfo.AccessibleName = "";
            LblFormalityInfo.AccessibleRole = AccessibleRole.PushButton;
            LblFormalityInfo.AutoSize = true;
            LblFormalityInfo.Cursor = Cursors.Hand;
            LblFormalityInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LblFormalityInfo.Location = new Point(960, 13);
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
            BtnClean.Location = new Point(450, 567);
            BtnClean.Name = "BtnClean";
            BtnClean.Size = new Size(93, 48);
            BtnClean.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnClean.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnClean.Style.Image = Properties.Resources.clean_icon_32;
            BtnClean.Style.PressedForeColor = Color.Black;
            BtnClean.TabIndex = 107;
            ToolTip.SetToolTip(BtnClean, "Clear everything and prepare for a new translation");
            BtnClean.UseVisualStyleBackColor = false;
            BtnClean.Click += BtnClean_Click;
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
            BtnSave.TabIndex = 116;
            ToolTip.SetToolTip(BtnSave, "Save the translated text");
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
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
            BtnPrint.TabIndex = 115;
            ToolTip.SetToolTip(BtnPrint, "Print the translated text");
            BtnPrint.UseVisualStyleBackColor = false;
            BtnPrint.Click += BtnPrint_Click;
            // 
            // TbTranslated
            // 
            TbTranslated.BackColor = Color.FromArgb(63, 63, 70);
            TbTranslated.BorderStyle = BorderStyle.FixedSingle;
            TbTranslated.ForeColor = Color.FromArgb(241, 241, 241);
            TbTranslated.Location = new Point(549, 80);
            TbTranslated.Multiline = true;
            TbTranslated.Name = "TbTranslated";
            TbTranslated.ReadOnly = true;
            TbTranslated.ScrollBars = ScrollBars.Vertical;
            TbTranslated.Size = new Size(428, 535);
            TbTranslated.TabIndex = 117;
            // 
            // TbSourceScroller
            // 
            TbSourceScroller.Control = TbSource;
            TbSourceScroller.Style.HorizontalScrollBar.ScrollBarBackColor = Color.FromArgb(45, 45, 48);
            TbSourceScroller.Style.VerticalScrollBar.ArrowButtonBackColor = Color.FromArgb(63, 63, 70);
            TbSourceScroller.Style.VerticalScrollBar.ArrowButtonBorderColor = Color.FromArgb(63, 63, 70);
            TbSourceScroller.Style.VerticalScrollBar.ArrowButtonForeColor = Color.FromArgb(241, 241, 241);
            TbSourceScroller.Style.VerticalScrollBar.ArrowButtonHoverBackColor = Color.FromArgb(241, 241, 241);
            TbSourceScroller.Style.VerticalScrollBar.ArrowButtonHoverForeColor = Color.FromArgb(63, 63, 70);
            TbSourceScroller.Style.VerticalScrollBar.ArrowButtonPressedBackColor = Color.FromArgb(241, 241, 241);
            TbSourceScroller.Style.VerticalScrollBar.ArrowButtonPressedForeColor = Color.FromArgb(63, 63, 70);
            TbSourceScroller.Style.VerticalScrollBar.ScrollBarBackColor = Color.FromArgb(63, 63, 70);
            TbSourceScroller.Style.VerticalScrollBar.ThumbBorderColor = SystemColors.WindowFrame;
            TbSourceScroller.Style.VerticalScrollBar.ThumbColor = Color.FromArgb(63, 63, 70);
            TbSourceScroller.Style.VerticalScrollBar.ThumbHoverBorderColor = Color.FromArgb(241, 241, 241);
            TbSourceScroller.Style.VerticalScrollBar.ThumbHoverColor = Color.FromArgb(63, 63, 70);
            TbSourceScroller.Style.VerticalScrollBar.ThumbPressedBorderColor = Color.FromArgb(241, 241, 241);
            TbSourceScroller.Style.VerticalScrollBar.ThumbPressedColor = Color.FromArgb(63, 63, 70);
            TbSourceScroller.ThemeName = "";
            // 
            // TbTranslatedScroller
            // 
            TbTranslatedScroller.Control = TbTranslated;
            TbTranslatedScroller.Style.HorizontalScrollBar.ScrollBarBackColor = Color.FromArgb(45, 45, 48);
            TbTranslatedScroller.Style.VerticalScrollBar.ArrowButtonBackColor = Color.FromArgb(63, 63, 70);
            TbTranslatedScroller.Style.VerticalScrollBar.ArrowButtonBorderColor = Color.FromArgb(63, 63, 70);
            TbTranslatedScroller.Style.VerticalScrollBar.ArrowButtonForeColor = Color.FromArgb(241, 241, 241);
            TbTranslatedScroller.Style.VerticalScrollBar.ArrowButtonHoverBackColor = Color.FromArgb(241, 241, 241);
            TbTranslatedScroller.Style.VerticalScrollBar.ArrowButtonHoverForeColor = Color.FromArgb(63, 63, 70);
            TbTranslatedScroller.Style.VerticalScrollBar.ArrowButtonPressedBackColor = Color.FromArgb(241, 241, 241);
            TbTranslatedScroller.Style.VerticalScrollBar.ArrowButtonPressedForeColor = Color.FromArgb(63, 63, 70);
            TbTranslatedScroller.Style.VerticalScrollBar.ScrollBarBackColor = Color.FromArgb(63, 63, 70);
            TbTranslatedScroller.Style.VerticalScrollBar.ThumbBorderColor = SystemColors.WindowFrame;
            TbTranslatedScroller.Style.VerticalScrollBar.ThumbColor = Color.FromArgb(63, 63, 70);
            TbTranslatedScroller.Style.VerticalScrollBar.ThumbHoverBorderColor = Color.FromArgb(241, 241, 241);
            TbTranslatedScroller.Style.VerticalScrollBar.ThumbHoverColor = Color.FromArgb(63, 63, 70);
            TbTranslatedScroller.Style.VerticalScrollBar.ThumbPressedBorderColor = Color.FromArgb(241, 241, 241);
            TbTranslatedScroller.Style.VerticalScrollBar.ThumbPressedColor = Color.FromArgb(63, 63, 70);
            TbTranslatedScroller.ThemeName = "";
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
            BtnSwitchLanguage.BackColor = Color.FromArgb(63, 63, 70);
            BtnSwitchLanguage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BtnSwitchLanguage.ForeColor = Color.FromArgb(241, 241, 241);
            BtnSwitchLanguage.ImageSize = new Size(32, 32);
            BtnSwitchLanguage.Location = new Point(450, 35);
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
            BtnSwitchLanguage.TabIndex = 118;
            ToolTip.SetToolTip(BtnSwitchLanguage, "Switch source and target language.");
            BtnSwitchLanguage.UseVisualStyleBackColor = false;
            BtnSwitchLanguage.Click += BtnSwitchLanguage_Click;
            // 
            // TextPage
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(BtnSwitchLanguage);
            Controls.Add(TbTranslated);
            Controls.Add(BtnSave);
            Controls.Add(BtnPrint);
            Controls.Add(BtnClean);
            Controls.Add(LblFormalityInfo);
            Controls.Add(label2);
            Controls.Add(LblCharacters);
            Controls.Add(LblClipboardCopied);
            Controls.Add(BtnCopyClipboard);
            Controls.Add(TbSource);
            Controls.Add(label1);
            Controls.Add(LblDetected);
            Controls.Add(LblDetectedInfo);
            Controls.Add(LblCost);
            Controls.Add(LblTargetLanguage);
            Controls.Add(LblTargetFormality);
            Controls.Add(LblSourceLanguage);
            Controls.Add(CbTargetFormality);
            Controls.Add(CbTargetLanguage);
            Controls.Add(CbSourceLanguage);
            Controls.Add(BtnTranslate);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            Name = "TextPage";
            Size = new Size(993, 654);
            Load += TextPage_Load;
            DragDrop += TextPage_DragDrop;
            DragEnter += TextPage_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox CbSourceLanguage;
        private ComboBox CbTargetLanguage;
        private ComboBox CbTargetFormality;
        private Label LblSourceLanguage;
        private Label LblTargetFormality;
        private Label LblTargetLanguage;
        private Label LblCost;
        private Label LblDetectedInfo;
        private Label LblDetected;
        private Label label1;
        private Syncfusion.WinForms.Controls.SfButton BtnCopyClipboard;
        private Label LblClipboardCopied;
        private Label label2;
        private Label LblCharacters;
        private Label LblFormalityInfo;
        internal TextBox TbSource;
        private Syncfusion.WinForms.Controls.SfButton BtnClean;
        internal Syncfusion.WinForms.Controls.SfButton BtnTranslate;
        private Syncfusion.WinForms.Controls.SfButton BtnSave;
        private Syncfusion.WinForms.Controls.SfButton BtnPrint;
        internal TextBox TbTranslated;
        private Syncfusion.WinForms.Controls.SfScrollFrame TbSourceScroller;
        private Syncfusion.WinForms.Controls.SfScrollFrame TbTranslatedScroller;
        private ToolTip ToolTip;
        private Syncfusion.WinForms.Controls.SfButton BtnSwitchLanguage;
    }
}
