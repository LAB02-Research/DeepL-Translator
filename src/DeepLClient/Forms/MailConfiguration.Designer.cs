namespace DeepLClient.Forms
{
    partial class MailConfiguration
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailConfiguration));
            BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            PbCost = new PictureBox();
            LblSourceLanguage = new Label();
            TbUser = new TextBox();
            CbLaunchHidden = new CheckBox();
            CbStoreLastUsedSourceLanguage = new CheckBox();
            CbStoreLastUsedTargetLanguage = new CheckBox();
            CbCopyTranslationToClipboard = new CheckBox();
            BtnCancel = new Syncfusion.WinForms.Controls.SfButton();
            CbLaunchOnWindows = new CheckBox();
            CbAlwaysOnTop = new CheckBox();
            LblNameInfo = new Label();
            ToolTip = new ToolTip(components);
            BtnConfigureLogging = new Syncfusion.WinForms.Controls.SfButton();
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
            BtnStore.Location = new Point(196, 467);
            BtnStore.Name = "BtnStore";
            BtnStore.Size = new Size(590, 34);
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
            LblSourceLanguage.Size = new Size(75, 19);
            LblSourceLanguage.TabIndex = 67;
            LblSourceLanguage.Text = "your name";
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
            // CbLaunchHidden
            // 
            CbLaunchHidden.AccessibleDescription = "";
            CbLaunchHidden.AccessibleName = "";
            CbLaunchHidden.AccessibleRole = AccessibleRole.CheckButton;
            CbLaunchHidden.AutoSize = true;
            CbLaunchHidden.Checked = true;
            CbLaunchHidden.CheckState = CheckState.Checked;
            CbLaunchHidden.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CbLaunchHidden.Location = new Point(115, 318);
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
            CbStoreLastUsedSourceLanguage.Location = new Point(530, 103);
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
            CbStoreLastUsedTargetLanguage.Location = new Point(530, 142);
            CbStoreLastUsedTargetLanguage.Name = "CbStoreLastUsedTargetLanguage";
            CbStoreLastUsedTargetLanguage.Size = new Size(218, 23);
            CbStoreLastUsedTargetLanguage.TabIndex = 75;
            CbStoreLastUsedTargetLanguage.Text = "store last used target language";
            CbStoreLastUsedTargetLanguage.UseVisualStyleBackColor = true;
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
            CbCopyTranslationToClipboard.Location = new Point(530, 200);
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
            BtnCancel.Location = new Point(22, 467);
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
            // CbLaunchOnWindows
            // 
            CbLaunchOnWindows.AccessibleDescription = "";
            CbLaunchOnWindows.AccessibleName = "";
            CbLaunchOnWindows.AccessibleRole = AccessibleRole.CheckButton;
            CbLaunchOnWindows.AutoSize = true;
            CbLaunchOnWindows.Checked = true;
            CbLaunchOnWindows.CheckState = CheckState.Checked;
            CbLaunchOnWindows.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CbLaunchOnWindows.Location = new Point(115, 358);
            CbLaunchOnWindows.Name = "CbLaunchOnWindows";
            CbLaunchOnWindows.Size = new Size(179, 23);
            CbLaunchOnWindows.TabIndex = 107;
            CbLaunchOnWindows.Text = "launch on windows login";
            CbLaunchOnWindows.UseVisualStyleBackColor = true;
            // 
            // CbAlwaysOnTop
            // 
            CbAlwaysOnTop.AccessibleDescription = "";
            CbAlwaysOnTop.AccessibleName = "";
            CbAlwaysOnTop.AccessibleRole = AccessibleRole.CheckButton;
            CbAlwaysOnTop.AutoSize = true;
            CbAlwaysOnTop.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CbAlwaysOnTop.Location = new Point(115, 399);
            CbAlwaysOnTop.Name = "CbAlwaysOnTop";
            CbAlwaysOnTop.Size = new Size(113, 23);
            CbAlwaysOnTop.TabIndex = 115;
            CbAlwaysOnTop.Text = "always on top";
            CbAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // LblNameInfo
            // 
            LblNameInfo.AccessibleDescription = "";
            LblNameInfo.AccessibleName = "";
            LblNameInfo.AccessibleRole = AccessibleRole.PushButton;
            LblNameInfo.AutoSize = true;
            LblNameInfo.Cursor = Cursors.Hand;
            LblNameInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LblNameInfo.Location = new Point(431, 52);
            LblNameInfo.Name = "LblNameInfo";
            LblNameInfo.Size = new Size(17, 21);
            LblNameInfo.TabIndex = 116;
            LblNameInfo.Text = "?";
            // 
            // ToolTip
            // 
            ToolTip.AutoPopDelay = 5000;
            ToolTip.BackColor = Color.FromArgb(241, 241, 241);
            ToolTip.ForeColor = Color.FromArgb(45, 45, 48);
            ToolTip.InitialDelay = 1000;
            ToolTip.ReshowDelay = 100;
            // 
            // BtnConfigureLogging
            // 
            BtnConfigureLogging.AccessibleDescription = "";
            BtnConfigureLogging.AccessibleName = "";
            BtnConfigureLogging.AccessibleRole = AccessibleRole.PushButton;
            BtnConfigureLogging.BackColor = Color.FromArgb(63, 63, 70);
            BtnConfigureLogging.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnConfigureLogging.ForeColor = Color.FromArgb(241, 241, 241);
            BtnConfigureLogging.ImageSize = new Size(24, 24);
            BtnConfigureLogging.Location = new Point(530, 392);
            BtnConfigureLogging.Name = "BtnConfigureLogging";
            BtnConfigureLogging.Size = new Size(256, 34);
            BtnConfigureLogging.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnConfigureLogging.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnConfigureLogging.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnConfigureLogging.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnConfigureLogging.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnConfigureLogging.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnConfigureLogging.Style.PressedForeColor = Color.Black;
            BtnConfigureLogging.TabIndex = 117;
            BtnConfigureLogging.Text = "configure usage logging";
            BtnConfigureLogging.UseVisualStyleBackColor = false;
            // 
            // MailConfiguration
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            CaptionBarColor = Color.FromArgb(63, 63, 70);
            CaptionFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CaptionForeColor = Color.FromArgb(241, 241, 241);
            ClientSize = new Size(808, 510);
            Controls.Add(BtnConfigureLogging);
            Controls.Add(LblNameInfo);
            Controls.Add(CbAlwaysOnTop);
            Controls.Add(CbLaunchOnWindows);
            Controls.Add(BtnCancel);
            Controls.Add(CbCopyTranslationToClipboard);
            Controls.Add(CbStoreLastUsedTargetLanguage);
            Controls.Add(CbStoreLastUsedSourceLanguage);
            Controls.Add(CbLaunchHidden);
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
            Name = "MailConfiguration";
            ShowMaximizeBox = false;
            ShowMinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mail";
            Load += MailConfiguration_Load;
            KeyUp += MailConfiguration_KeyUp;
            ((System.ComponentModel.ISupportInitialize)PbCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private PictureBox PbCost;
        private Label LblSourceLanguage;
        internal TextBox TbUser;
        internal CheckBox CbLaunchHidden;
        internal CheckBox CbStoreLastUsedSourceLanguage;
        internal CheckBox CbStoreLastUsedTargetLanguage;
        internal CheckBox CbCopyTranslationToClipboard;
        private Syncfusion.WinForms.Controls.SfButton BtnCancel;
        internal CheckBox CbLaunchOnWindows;
        internal CheckBox CbAlwaysOnTop;
        private Label LblNameInfo;
        private ToolTip ToolTip;
        private Syncfusion.WinForms.Controls.SfButton BtnConfigureLogging;
    }
}