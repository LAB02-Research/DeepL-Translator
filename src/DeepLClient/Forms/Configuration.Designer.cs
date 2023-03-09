namespace DeepLClient.Forms
{
    partial class Configuration
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            PbCost = new PictureBox();
            LblSourceLanguage = new Label();
            TbUser = new TextBox();
            label1 = new Label();
            TbAPIKey = new TextBox();
            label2 = new Label();
            CbLaunchHidden = new CheckBox();
            CbStoreLastUsedSourceLanguage = new CheckBox();
            CbStoreLastUsedTargetLanguage = new CheckBox();
            label3 = new Label();
            CbDefaultFormality = new ComboBox();
            CbCopyTranslationToClipboard = new CheckBox();
            BtnCancel = new Syncfusion.WinForms.Controls.SfButton();
            LblDomainInfo = new Label();
            LblFormalityInfo = new Label();
            CbDomain = new ComboBox();
            CbLaunchOnWindows = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)PbCost).BeginInit();
            SuspendLayout();
            // 
            // BtnStore
            // 
            BtnStore.AccessibleDescription = "";
            BtnStore.AccessibleName = "";
            BtnStore.AccessibleRole = AccessibleRole.PushButton;
            BtnStore.BackColor = Color.FromArgb(63, 63, 70);
            BtnStore.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnStore.ForeColor = Color.FromArgb(241, 241, 241);
            BtnStore.ImageSize = new Size(24, 24);
            BtnStore.Location = new Point(196, 369);
            BtnStore.Name = "BtnStore";
            BtnStore.Size = new Size(518, 34);
            BtnStore.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnStore.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnStore.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnStore.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnStore.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnStore.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnStore.Style.Image = Properties.Resources.save_icon_24;
            BtnStore.Style.PressedForeColor = Color.Black;
            BtnStore.TabIndex = 0;
            BtnStore.UseVisualStyleBackColor = false;
            BtnStore.Click += BtnStore_Click;
            // 
            // PbCost
            // 
            PbCost.Image = Properties.Resources.config_icon_64;
            PbCost.Location = new Point(22, 28);
            PbCost.Name = "PbCost";
            PbCost.Size = new Size(64, 64);
            PbCost.SizeMode = PictureBoxSizeMode.AutoSize;
            PbCost.TabIndex = 6;
            PbCost.TabStop = false;
            // 
            // LblSourceLanguage
            // 
            LblSourceLanguage.AccessibleDescription = "";
            LblSourceLanguage.AccessibleName = "";
            LblSourceLanguage.AccessibleRole = AccessibleRole.StaticText;
            LblSourceLanguage.AutoSize = true;
            LblSourceLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblSourceLanguage.Location = new Point(115, 28);
            LblSourceLanguage.Name = "LblSourceLanguage";
            LblSourceLanguage.Size = new Size(214, 19);
            LblSourceLanguage.TabIndex = 67;
            LblSourceLanguage.Text = "your name (for logging purposes)";
            // 
            // TbUser
            // 
            TbUser.AccessibleDescription = "";
            TbUser.AccessibleName = "";
            TbUser.AccessibleRole = AccessibleRole.Text;
            TbUser.BackColor = Color.FromArgb(63, 63, 70);
            TbUser.BorderStyle = BorderStyle.FixedSingle;
            TbUser.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TbUser.ForeColor = Color.FromArgb(241, 241, 241);
            TbUser.Location = new Point(115, 50);
            TbUser.Name = "TbUser";
            TbUser.Size = new Size(310, 25);
            TbUser.TabIndex = 68;
            // 
            // label1
            // 
            label1.AccessibleDescription = "";
            label1.AccessibleName = "";
            label1.AccessibleRole = AccessibleRole.StaticText;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(115, 103);
            label1.Name = "label1";
            label1.Size = new Size(98, 19);
            label1.TabIndex = 69;
            label1.Text = "DeepL domain";
            // 
            // TbAPIKey
            // 
            TbAPIKey.AccessibleDescription = "";
            TbAPIKey.AccessibleName = "";
            TbAPIKey.AccessibleRole = AccessibleRole.Text;
            TbAPIKey.BackColor = Color.FromArgb(63, 63, 70);
            TbAPIKey.BorderStyle = BorderStyle.FixedSingle;
            TbAPIKey.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TbAPIKey.ForeColor = Color.FromArgb(241, 241, 241);
            TbAPIKey.Location = new Point(115, 209);
            TbAPIKey.Name = "TbAPIKey";
            TbAPIKey.Size = new Size(310, 25);
            TbAPIKey.TabIndex = 72;
            // 
            // label2
            // 
            label2.AccessibleDescription = "";
            label2.AccessibleName = "";
            label2.AccessibleRole = AccessibleRole.StaticText;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(115, 187);
            label2.Name = "label2";
            label2.Size = new Size(98, 19);
            label2.TabIndex = 71;
            label2.Text = "DeepL API key";
            // 
            // CbLaunchHidden
            // 
            CbLaunchHidden.AccessibleDescription = "";
            CbLaunchHidden.AccessibleName = "";
            CbLaunchHidden.AccessibleRole = AccessibleRole.CheckButton;
            CbLaunchHidden.AutoSize = true;
            CbLaunchHidden.Checked = true;
            CbLaunchHidden.CheckState = CheckState.Checked;
            CbLaunchHidden.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CbLaunchHidden.Location = new Point(115, 268);
            CbLaunchHidden.Name = "CbLaunchHidden";
            CbLaunchHidden.Size = new Size(114, 23);
            CbLaunchHidden.TabIndex = 73;
            CbLaunchHidden.Text = "launch hidden";
            CbLaunchHidden.UseVisualStyleBackColor = true;
            // 
            // CbStoreLastUsedSourceLanguage
            // 
            CbStoreLastUsedSourceLanguage.AccessibleDescription = "";
            CbStoreLastUsedSourceLanguage.AccessibleName = "";
            CbStoreLastUsedSourceLanguage.AccessibleRole = AccessibleRole.CheckButton;
            CbStoreLastUsedSourceLanguage.AutoSize = true;
            CbStoreLastUsedSourceLanguage.Checked = true;
            CbStoreLastUsedSourceLanguage.CheckState = CheckState.Checked;
            CbStoreLastUsedSourceLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CbStoreLastUsedSourceLanguage.Location = new Point(493, 125);
            CbStoreLastUsedSourceLanguage.Name = "CbStoreLastUsedSourceLanguage";
            CbStoreLastUsedSourceLanguage.Size = new Size(221, 23);
            CbStoreLastUsedSourceLanguage.TabIndex = 74;
            CbStoreLastUsedSourceLanguage.Text = "store last used source language";
            CbStoreLastUsedSourceLanguage.UseVisualStyleBackColor = true;
            // 
            // CbStoreLastUsedTargetLanguage
            // 
            CbStoreLastUsedTargetLanguage.AccessibleDescription = "";
            CbStoreLastUsedTargetLanguage.AccessibleName = "";
            CbStoreLastUsedTargetLanguage.AccessibleRole = AccessibleRole.CheckButton;
            CbStoreLastUsedTargetLanguage.AutoSize = true;
            CbStoreLastUsedTargetLanguage.Checked = true;
            CbStoreLastUsedTargetLanguage.CheckState = CheckState.Checked;
            CbStoreLastUsedTargetLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CbStoreLastUsedTargetLanguage.Location = new Point(493, 164);
            CbStoreLastUsedTargetLanguage.Name = "CbStoreLastUsedTargetLanguage";
            CbStoreLastUsedTargetLanguage.Size = new Size(218, 23);
            CbStoreLastUsedTargetLanguage.TabIndex = 75;
            CbStoreLastUsedTargetLanguage.Text = "store last used target language";
            CbStoreLastUsedTargetLanguage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AccessibleDescription = "";
            label3.AccessibleName = "";
            label3.AccessibleRole = AccessibleRole.StaticText;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(493, 28);
            label3.Name = "label3";
            label3.Size = new Size(109, 19);
            label3.TabIndex = 77;
            label3.Text = "default formality";
            // 
            // CbDefaultFormality
            // 
            CbDefaultFormality.AccessibleDescription = "";
            CbDefaultFormality.AccessibleName = "";
            CbDefaultFormality.AccessibleRole = AccessibleRole.DropList;
            CbDefaultFormality.BackColor = Color.FromArgb(63, 63, 70);
            CbDefaultFormality.DrawMode = DrawMode.OwnerDrawFixed;
            CbDefaultFormality.DropDownHeight = 300;
            CbDefaultFormality.DropDownStyle = ComboBoxStyle.DropDownList;
            CbDefaultFormality.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CbDefaultFormality.ForeColor = Color.FromArgb(241, 241, 241);
            CbDefaultFormality.FormattingEnabled = true;
            CbDefaultFormality.IntegralHeight = false;
            CbDefaultFormality.Location = new Point(493, 50);
            CbDefaultFormality.Name = "CbDefaultFormality";
            CbDefaultFormality.Size = new Size(218, 26);
            CbDefaultFormality.TabIndex = 76;
            // 
            // CbCopyTranslationToClipboard
            // 
            CbCopyTranslationToClipboard.AccessibleDescription = "";
            CbCopyTranslationToClipboard.AccessibleName = "";
            CbCopyTranslationToClipboard.AccessibleRole = AccessibleRole.CheckButton;
            CbCopyTranslationToClipboard.AutoSize = true;
            CbCopyTranslationToClipboard.Checked = true;
            CbCopyTranslationToClipboard.CheckState = CheckState.Checked;
            CbCopyTranslationToClipboard.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CbCopyTranslationToClipboard.Location = new Point(493, 209);
            CbCopyTranslationToClipboard.Name = "CbCopyTranslationToClipboard";
            CbCopyTranslationToClipboard.Size = new Size(226, 23);
            CbCopyTranslationToClipboard.TabIndex = 78;
            CbCopyTranslationToClipboard.Text = "copy translated text to clipboard";
            CbCopyTranslationToClipboard.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            BtnCancel.AccessibleDescription = "";
            BtnCancel.AccessibleName = "";
            BtnCancel.AccessibleRole = AccessibleRole.PushButton;
            BtnCancel.BackColor = Color.FromArgb(63, 63, 70);
            BtnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnCancel.ForeColor = Color.FromArgb(241, 241, 241);
            BtnCancel.ImageSize = new Size(16, 16);
            BtnCancel.Location = new Point(22, 369);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(157, 34);
            BtnCancel.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnCancel.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnCancel.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnCancel.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnCancel.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnCancel.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnCancel.Style.Image = Properties.Resources.no_icon_16;
            BtnCancel.Style.PressedForeColor = Color.Black;
            BtnCancel.TabIndex = 79;
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // LblDomainInfo
            // 
            LblDomainInfo.AccessibleDescription = "";
            LblDomainInfo.AccessibleName = "";
            LblDomainInfo.AccessibleRole = AccessibleRole.PushButton;
            LblDomainInfo.AutoSize = true;
            LblDomainInfo.Cursor = Cursors.Hand;
            LblDomainInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LblDomainInfo.Location = new Point(431, 127);
            LblDomainInfo.Name = "LblDomainInfo";
            LblDomainInfo.Size = new Size(17, 21);
            LblDomainInfo.TabIndex = 104;
            LblDomainInfo.Text = "?";
            LblDomainInfo.Click += LblDomainInfo_Click;
            // 
            // LblFormalityInfo
            // 
            LblFormalityInfo.AccessibleDescription = "";
            LblFormalityInfo.AccessibleName = "";
            LblFormalityInfo.AccessibleRole = AccessibleRole.PushButton;
            LblFormalityInfo.AutoSize = true;
            LblFormalityInfo.Cursor = Cursors.Hand;
            LblFormalityInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LblFormalityInfo.Location = new Point(694, 28);
            LblFormalityInfo.Name = "LblFormalityInfo";
            LblFormalityInfo.Size = new Size(17, 21);
            LblFormalityInfo.TabIndex = 105;
            LblFormalityInfo.Text = "?";
            LblFormalityInfo.Click += LblFormalityInfo_Click;
            // 
            // CbDomain
            // 
            CbDomain.AccessibleDescription = "";
            CbDomain.AccessibleName = "";
            CbDomain.AccessibleRole = AccessibleRole.DropList;
            CbDomain.BackColor = Color.FromArgb(63, 63, 70);
            CbDomain.DrawMode = DrawMode.OwnerDrawFixed;
            CbDomain.DropDownHeight = 300;
            CbDomain.DropDownStyle = ComboBoxStyle.DropDownList;
            CbDomain.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CbDomain.ForeColor = Color.FromArgb(241, 241, 241);
            CbDomain.FormattingEnabled = true;
            CbDomain.IntegralHeight = false;
            CbDomain.Location = new Point(115, 124);
            CbDomain.Name = "CbDomain";
            CbDomain.Size = new Size(310, 26);
            CbDomain.TabIndex = 106;
            // 
            // CbLaunchOnWindows
            // 
            CbLaunchOnWindows.AccessibleDescription = "";
            CbLaunchOnWindows.AccessibleName = "";
            CbLaunchOnWindows.AccessibleRole = AccessibleRole.CheckButton;
            CbLaunchOnWindows.AutoSize = true;
            CbLaunchOnWindows.Checked = true;
            CbLaunchOnWindows.CheckState = CheckState.Checked;
            CbLaunchOnWindows.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CbLaunchOnWindows.Location = new Point(115, 308);
            CbLaunchOnWindows.Name = "CbLaunchOnWindows";
            CbLaunchOnWindows.Size = new Size(179, 23);
            CbLaunchOnWindows.TabIndex = 107;
            CbLaunchOnWindows.Text = "launch on windows login";
            CbLaunchOnWindows.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            CaptionBarColor = Color.FromArgb(63, 63, 70);
            CaptionFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CaptionForeColor = Color.FromArgb(241, 241, 241);
            ClientSize = new Size(731, 408);
            Controls.Add(CbLaunchOnWindows);
            Controls.Add(CbDomain);
            Controls.Add(LblFormalityInfo);
            Controls.Add(LblDomainInfo);
            Controls.Add(BtnCancel);
            Controls.Add(CbCopyTranslationToClipboard);
            Controls.Add(label3);
            Controls.Add(CbDefaultFormality);
            Controls.Add(CbStoreLastUsedTargetLanguage);
            Controls.Add(CbStoreLastUsedSourceLanguage);
            Controls.Add(CbLaunchHidden);
            Controls.Add(TbAPIKey);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TbUser);
            Controls.Add(LblSourceLanguage);
            Controls.Add(PbCost);
            Controls.Add(BtnStore);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MetroColor = Color.FromArgb(63, 63, 70);
            Name = "Configuration";
            ShowMaximizeBox = false;
            ShowMinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuration   |   LAB02 Research";
            Load += Configuration_Load;
            ((System.ComponentModel.ISupportInitialize)PbCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private PictureBox PbCost;
        private Label LblSourceLanguage;
        internal TextBox TbUser;
        private Label label1;
        internal TextBox TbAPIKey;
        private Label label2;
        internal CheckBox CbLaunchHidden;
        internal CheckBox CbStoreLastUsedSourceLanguage;
        internal CheckBox CbStoreLastUsedTargetLanguage;
        private Label label3;
        private ComboBox CbDefaultFormality;
        internal CheckBox CbCopyTranslationToClipboard;
        private Syncfusion.WinForms.Controls.SfButton BtnCancel;
        private Label LblDomainInfo;
        private Label LblFormalityInfo;
        private ComboBox CbDomain;
        internal CheckBox CbLaunchOnWindows;
    }
}