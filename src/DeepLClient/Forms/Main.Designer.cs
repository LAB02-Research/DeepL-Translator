namespace DeepLClient.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            PnlTabs = new Panel();
            TranslationTabs = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            TabText = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            TabDocuments = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            BtnSubscription = new Syncfusion.WinForms.Controls.SfButton();
            BtnConfig = new Syncfusion.WinForms.Controls.SfButton();
            BtnHide = new Syncfusion.WinForms.Controls.SfButton();
            NotifyIcon = new NotifyIcon(components);
            CmTrayIcon = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            TsShow = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            TsExit = new ToolStripMenuItem();
            LblCharLimitReached = new Label();
            PnlTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TranslationTabs).BeginInit();
            TranslationTabs.SuspendLayout();
            CmTrayIcon.SuspendLayout();
            SuspendLayout();
            // 
            // PnlTabs
            // 
            PnlTabs.BorderStyle = BorderStyle.FixedSingle;
            PnlTabs.Controls.Add(TranslationTabs);
            PnlTabs.Dock = DockStyle.Top;
            PnlTabs.Location = new Point(0, 0);
            PnlTabs.Name = "PnlTabs";
            PnlTabs.Size = new Size(999, 634);
            PnlTabs.TabIndex = 0;
            // 
            // TranslationTabs
            // 
            TranslationTabs.AccessibleDescription = "Various tabs for configuring HASS.Agent.";
            TranslationTabs.AccessibleName = "Tabs";
            TranslationTabs.AccessibleRole = AccessibleRole.PageTabList;
            TranslationTabs.ActiveTabColor = Color.FromArgb(45, 45, 48);
            TranslationTabs.BackColor = Color.FromArgb(45, 45, 48);
            TranslationTabs.BeforeTouchSize = new Size(997, 632);
            TranslationTabs.BorderStyle = BorderStyle.None;
            TranslationTabs.Controls.Add(TabText);
            TranslationTabs.Controls.Add(TabDocuments);
            TranslationTabs.Dock = DockStyle.Fill;
            TranslationTabs.FixedSingleBorderColor = Color.FromArgb(241, 241, 241);
            TranslationTabs.FocusOnTabClick = false;
            TranslationTabs.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TranslationTabs.InactiveTabColor = Color.FromArgb(63, 63, 70);
            TranslationTabs.ItemSize = new Size(225, 40);
            TranslationTabs.Location = new Point(0, 0);
            TranslationTabs.Name = "TranslationTabs";
            TranslationTabs.RotateTextWhenVertical = true;
            TranslationTabs.Size = new Size(997, 632);
            TranslationTabs.SizeMode = Syncfusion.Windows.Forms.Tools.TabSizeMode.Fixed;
            TranslationTabs.TabIndex = 1;
            TranslationTabs.TabPanelBackColor = Color.FromArgb(45, 45, 48);
            TranslationTabs.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
            TranslationTabs.ThemeName = "TabRendererMetro";
            TranslationTabs.ThemesEnabled = true;
            TranslationTabs.ThemeStyle.PrimitiveButtonStyle.DisabledNextPageImage = null;
            // 
            // TabText
            // 
            TabText.AccessibleDescription = "";
            TabText.AccessibleName = "";
            TabText.AccessibleRole = AccessibleRole.PageTab;
            TabText.AutoScroll = true;
            TabText.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            TabText.Image = Properties.Resources.text_icon_18;
            TabText.ImageSize = new Size(18, 18);
            TabText.Location = new Point(2, 41);
            TabText.Name = "TabText";
            TabText.ShowCloseButton = false;
            TabText.Size = new Size(993, 589);
            TabText.TabBackColor = Color.FromArgb(45, 45, 48);
            TabText.TabFont = new Font("Consolas", 18F, FontStyle.Regular, GraphicsUnit.Point);
            TabText.TabForeColor = Color.FromArgb(241, 241, 241);
            TabText.TabIndex = 9;
            TabText.ThemesEnabled = false;
            // 
            // TabDocuments
            // 
            TabDocuments.AccessibleDescription = "";
            TabDocuments.AccessibleName = "";
            TabDocuments.AccessibleRole = AccessibleRole.PageTab;
            TabDocuments.AutoScroll = true;
            TabDocuments.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TabDocuments.Image = Properties.Resources.document_icon_18;
            TabDocuments.ImageSize = new Size(18, 18);
            TabDocuments.Location = new Point(2, 41);
            TabDocuments.Name = "TabDocuments";
            TabDocuments.ShowCloseButton = true;
            TabDocuments.Size = new Size(993, 589);
            TabDocuments.TabBackColor = Color.FromArgb(45, 45, 48);
            TabDocuments.TabFont = new Font("Consolas", 18F, FontStyle.Regular, GraphicsUnit.Point);
            TabDocuments.TabForeColor = Color.FromArgb(241, 241, 241);
            TabDocuments.TabIndex = 10;
            TabDocuments.ThemesEnabled = false;
            // 
            // BtnSubscription
            // 
            BtnSubscription.AccessibleDescription = "";
            BtnSubscription.AccessibleName = "";
            BtnSubscription.AccessibleRole = AccessibleRole.PushButton;
            BtnSubscription.BackColor = Color.FromArgb(63, 63, 70);
            BtnSubscription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnSubscription.ForeColor = Color.FromArgb(241, 241, 241);
            BtnSubscription.ImageSize = new Size(24, 24);
            BtnSubscription.Location = new Point(0, 640);
            BtnSubscription.Name = "BtnSubscription";
            BtnSubscription.Size = new Size(116, 31);
            BtnSubscription.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnSubscription.Style.DisabledBackColor = Color.FromArgb(63, 63, 70);
            BtnSubscription.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnSubscription.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnSubscription.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnSubscription.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnSubscription.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnSubscription.Style.Image = Properties.Resources.price_icon_24;
            BtnSubscription.Style.PressedForeColor = Color.Black;
            BtnSubscription.TabIndex = 4;
            BtnSubscription.UseVisualStyleBackColor = false;
            BtnSubscription.Click += BtnSubscriptionInfo_Click;
            // 
            // BtnConfig
            // 
            BtnConfig.AccessibleDescription = "";
            BtnConfig.AccessibleName = "";
            BtnConfig.AccessibleRole = AccessibleRole.PushButton;
            BtnConfig.BackColor = Color.FromArgb(63, 63, 70);
            BtnConfig.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnConfig.ForeColor = Color.FromArgb(241, 241, 241);
            BtnConfig.ImageSize = new Size(24, 24);
            BtnConfig.Location = new Point(122, 640);
            BtnConfig.Name = "BtnConfig";
            BtnConfig.Size = new Size(116, 31);
            BtnConfig.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnConfig.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnConfig.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnConfig.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnConfig.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnConfig.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnConfig.Style.Image = Properties.Resources.config_icon_24;
            BtnConfig.Style.PressedForeColor = Color.Black;
            BtnConfig.TabIndex = 5;
            BtnConfig.UseVisualStyleBackColor = false;
            BtnConfig.Click += BtnConfig_Click;
            // 
            // BtnHide
            // 
            BtnHide.AccessibleDescription = "";
            BtnHide.AccessibleName = "";
            BtnHide.AccessibleRole = AccessibleRole.PushButton;
            BtnHide.BackColor = Color.FromArgb(63, 63, 70);
            BtnHide.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnHide.ForeColor = Color.FromArgb(241, 241, 241);
            BtnHide.ImageSize = new Size(24, 24);
            BtnHide.Location = new Point(745, 640);
            BtnHide.Name = "BtnHide";
            BtnHide.Size = new Size(254, 31);
            BtnHide.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnHide.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnHide.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnHide.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnHide.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnHide.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnHide.Style.Image = Properties.Resources.hide_icon_24;
            BtnHide.Style.PressedForeColor = Color.Black;
            BtnHide.TabIndex = 6;
            BtnHide.UseVisualStyleBackColor = false;
            BtnHide.Click += BtnHide_Click;
            // 
            // NotifyIcon
            // 
            NotifyIcon.BalloonTipTitle = "DeepL Translator";
            NotifyIcon.ContextMenuStrip = CmTrayIcon;
            NotifyIcon.Icon = (Icon)resources.GetObject("NotifyIcon.Icon");
            NotifyIcon.Text = "DeepL Translator";
            NotifyIcon.Visible = true;
            NotifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            NotifyIcon.MouseClick += NotifyIcon_MouseClick;
            // 
            // CmTrayIcon
            // 
            CmTrayIcon.AccessibleRole = AccessibleRole.MenuPopup;
            CmTrayIcon.DropShadowEnabled = false;
            CmTrayIcon.ImageScalingSize = new Size(24, 24);
            CmTrayIcon.Items.AddRange(new ToolStripItem[] { TsShow, toolStripSeparator1, TsExit });
            CmTrayIcon.MetroColor = Color.FromArgb(204, 236, 249);
            CmTrayIcon.Name = "CmTrayIcon";
            CmTrayIcon.Size = new Size(218, 70);
            CmTrayIcon.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Metro;
            CmTrayIcon.ThemeName = "Office2016Black";
            // 
            // TsShow
            // 
            TsShow.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            TsShow.Image = Properties.Resources.show_icon_24;
            TsShow.Name = "TsShow";
            TsShow.Size = new Size(217, 30);
            TsShow.Text = "Show DeepL Translator";
            TsShow.Click += TsShow_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(214, 6);
            // 
            // TsExit
            // 
            TsExit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            TsExit.Image = Properties.Resources.exit_icon_24;
            TsExit.Name = "TsExit";
            TsExit.Size = new Size(217, 30);
            TsExit.Text = "Exit";
            TsExit.Click += TsExit_Click;
            // 
            // LblCharLimitReached
            // 
            LblCharLimitReached.AccessibleDescription = "";
            LblCharLimitReached.AccessibleName = "";
            LblCharLimitReached.AccessibleRole = AccessibleRole.StaticText;
            LblCharLimitReached.AutoSize = true;
            LblCharLimitReached.Cursor = Cursors.Hand;
            LblCharLimitReached.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            LblCharLimitReached.ForeColor = Color.FromArgb(255, 128, 128);
            LblCharLimitReached.Location = new Point(248, 645);
            LblCharLimitReached.Name = "LblCharLimitReached";
            LblCharLimitReached.Size = new Size(489, 20);
            LblCharLimitReached.TabIndex = 72;
            LblCharLimitReached.Text = "CHARACTER LIMIT REACHED, PLEASE REVIEW YOUR SUBSCRIPTION";
            LblCharLimitReached.Visible = false;
            LblCharLimitReached.Click += LblCharLimitReached_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            CaptionBarColor = Color.FromArgb(63, 63, 70);
            CaptionFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CaptionForeColor = Color.FromArgb(241, 241, 241);
            ClientSize = new Size(999, 671);
            Controls.Add(LblCharLimitReached);
            Controls.Add(BtnHide);
            Controls.Add(BtnConfig);
            Controls.Add(BtnSubscription);
            Controls.Add(PnlTabs);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MetroColor = Color.FromArgb(63, 63, 70);
            Name = "Main";
            ShowMaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DeepL Translator   |   LAB02 Research";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            KeyUp += Main_KeyUp;
            PnlTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TranslationTabs).EndInit();
            TranslationTabs.ResumeLayout(false);
            CmTrayIcon.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel PnlTabs;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv TranslationTabs;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabText;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabDocuments;
        private Syncfusion.WinForms.Controls.SfButton BtnSubscription;
        private Syncfusion.WinForms.Controls.SfButton BtnConfig;
        private Syncfusion.WinForms.Controls.SfButton BtnHide;
        private NotifyIcon NotifyIcon;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx CmTrayIcon;
        private ToolStripMenuItem TsShow;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem TsExit;
        private Label LblCharLimitReached;
    }
}