﻿namespace DeepLClient.Forms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            BtnYes = new Syncfusion.WinForms.Controls.SfButton();
            PbLogo = new PictureBox();
            PbPayPal = new PictureBox();
            PbBMAC = new PictureBox();
            LblByteSize = new Label();
            LblInfo6 = new Label();
            LblLab02Research = new Label();
            LblInfo2 = new Label();
            LblInfo5 = new Label();
            LblSyncfusion = new Label();
            LblSerilog = new Label();
            LblSmartReader = new Label();
            LblWebView2 = new Label();
            LblDeepLnet = new Label();
            LblInfo3 = new Label();
            LblInfo1 = new Label();
            LblDeepLProject = new Label();
            LblVersion = new Label();
            LblHotkeyListener = new Label();
            LblNewtonsoftJson = new Label();
            label1 = new Label();
            LblDeepL = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)PbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbPayPal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbBMAC).BeginInit();
            SuspendLayout();
            // 
            // BtnYes
            // 
            BtnYes.AccessibleDescription = "";
            BtnYes.AccessibleName = "";
            BtnYes.AccessibleRole = AccessibleRole.PushButton;
            BtnYes.BackColor = Color.FromArgb(63, 63, 70);
            BtnYes.Dock = DockStyle.Bottom;
            BtnYes.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnYes.ForeColor = Color.FromArgb(241, 241, 241);
            BtnYes.ImageSize = new Size(24, 24);
            BtnYes.Location = new Point(0, 499);
            BtnYes.Name = "BtnYes";
            BtnYes.Size = new Size(686, 36);
            BtnYes.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnYes.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnYes.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnYes.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnYes.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnYes.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnYes.Style.Image = Properties.Resources.yes_icon_24;
            BtnYes.Style.PressedForeColor = Color.Black;
            BtnYes.TabIndex = 0;
            BtnYes.UseVisualStyleBackColor = false;
            BtnYes.Click += BtnYes_Click;
            // 
            // PbLogo
            // 
            PbLogo.Cursor = Cursors.Hand;
            PbLogo.Image = Properties.Resources.logo_notext;
            PbLogo.Location = new Point(12, 12);
            PbLogo.Name = "PbLogo";
            PbLogo.Size = new Size(117, 144);
            PbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            PbLogo.TabIndex = 6;
            PbLogo.TabStop = false;
            PbLogo.Click += PbLogo_Click;
            // 
            // PbPayPal
            // 
            PbPayPal.AccessibleDescription = "";
            PbPayPal.AccessibleName = "";
            PbPayPal.AccessibleRole = AccessibleRole.PushButton;
            PbPayPal.Cursor = Cursors.Hand;
            PbPayPal.Image = (Image)resources.GetObject("PbPayPal.Image");
            PbPayPal.Location = new Point(450, 437);
            PbPayPal.Name = "PbPayPal";
            PbPayPal.Size = new Size(152, 43);
            PbPayPal.SizeMode = PictureBoxSizeMode.AutoSize;
            PbPayPal.TabIndex = 71;
            PbPayPal.TabStop = false;
            PbPayPal.Click += PbPayPal_Click;
            // 
            // PbBMAC
            // 
            PbBMAC.AccessibleDescription = "";
            PbBMAC.AccessibleName = "";
            PbBMAC.AccessibleRole = AccessibleRole.PushButton;
            PbBMAC.Cursor = Cursors.Hand;
            PbBMAC.Image = (Image)resources.GetObject("PbBMAC.Image");
            PbBMAC.Location = new Point(145, 437);
            PbBMAC.Name = "PbBMAC";
            PbBMAC.Size = new Size(153, 43);
            PbBMAC.SizeMode = PictureBoxSizeMode.AutoSize;
            PbBMAC.TabIndex = 68;
            PbBMAC.TabStop = false;
            PbBMAC.Click += PbBMAC_Click;
            // 
            // LblByteSize
            // 
            LblByteSize.AccessibleDescription = "";
            LblByteSize.AccessibleName = "";
            LblByteSize.AccessibleRole = AccessibleRole.Link;
            LblByteSize.AutoSize = true;
            LblByteSize.Cursor = Cursors.Hand;
            LblByteSize.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblByteSize.Location = new Point(142, 186);
            LblByteSize.Name = "LblByteSize";
            LblByteSize.Size = new Size(59, 19);
            LblByteSize.TabIndex = 67;
            LblByteSize.Text = "ByteSize";
            LblByteSize.Click += LblByteSize_Click;
            // 
            // LblInfo6
            // 
            LblInfo6.AccessibleDescription = "Donating for HASS.Agent message.";
            LblInfo6.AccessibleName = "Donating info";
            LblInfo6.AccessibleRole = AccessibleRole.StaticText;
            LblInfo6.AutoSize = true;
            LblInfo6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblInfo6.Location = new Point(142, 404);
            LblInfo6.Name = "LblInfo6";
            LblInfo6.Size = new Size(460, 19);
            LblInfo6.TabIndex = 63;
            LblInfo6.Text = "Like this tool? Support us (read: keep us awake) by buying a cup of coffee:";
            LblInfo6.TextAlign = ContentAlignment.BottomLeft;
            // 
            // LblLab02Research
            // 
            LblLab02Research.AccessibleDescription = "";
            LblLab02Research.AccessibleName = "";
            LblLab02Research.AccessibleRole = AccessibleRole.Link;
            LblLab02Research.AutoSize = true;
            LblLab02Research.Cursor = Cursors.Hand;
            LblLab02Research.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblLab02Research.Location = new Point(328, 102);
            LblLab02Research.Name = "LblLab02Research";
            LblLab02Research.Size = new Size(107, 19);
            LblLab02Research.TabIndex = 60;
            LblLab02Research.Text = "LAB02 Research";
            LblLab02Research.Click += LblLab02Research_Click;
            // 
            // LblInfo2
            // 
            LblInfo2.AccessibleDescription = "Created info.";
            LblInfo2.AccessibleName = "Created info";
            LblInfo2.AccessibleRole = AccessibleRole.StaticText;
            LblInfo2.AutoSize = true;
            LblInfo2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblInfo2.Location = new Point(142, 102);
            LblInfo2.Name = "LblInfo2";
            LblInfo2.Size = new Size(135, 19);
            LblInfo2.TabIndex = 59;
            LblInfo2.Text = "Created with love by";
            // 
            // LblInfo5
            // 
            LblInfo5.AccessibleDescription = "Home Assistant thanks message.";
            LblInfo5.AccessibleName = "HA thanks";
            LblInfo5.AccessibleRole = AccessibleRole.StaticText;
            LblInfo5.AutoSize = true;
            LblInfo5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblInfo5.Location = new Point(142, 285);
            LblInfo5.Name = "LblInfo5";
            LblInfo5.Size = new Size(159, 19);
            LblInfo5.TabIndex = 58;
            LblInfo5.Text = "And of course; thanks to";
            // 
            // LblSyncfusion
            // 
            LblSyncfusion.AccessibleDescription = "";
            LblSyncfusion.AccessibleName = "";
            LblSyncfusion.AccessibleRole = AccessibleRole.Link;
            LblSyncfusion.AutoSize = true;
            LblSyncfusion.Cursor = Cursors.Hand;
            LblSyncfusion.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblSyncfusion.Location = new Point(510, 216);
            LblSyncfusion.Name = "LblSyncfusion";
            LblSyncfusion.Size = new Size(74, 19);
            LblSyncfusion.TabIndex = 56;
            LblSyncfusion.Text = "Syncfusion";
            LblSyncfusion.Click += LblSyncfusion_Click;
            // 
            // LblSerilog
            // 
            LblSerilog.AccessibleDescription = "";
            LblSerilog.AccessibleName = "";
            LblSerilog.AccessibleRole = AccessibleRole.Link;
            LblSerilog.AutoSize = true;
            LblSerilog.Cursor = Cursors.Hand;
            LblSerilog.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblSerilog.Location = new Point(328, 246);
            LblSerilog.Name = "LblSerilog";
            LblSerilog.Size = new Size(50, 19);
            LblSerilog.TabIndex = 55;
            LblSerilog.Text = "Serilog";
            LblSerilog.Click += LblSerilog_Click;
            // 
            // LblSmartReader
            // 
            LblSmartReader.AccessibleDescription = "";
            LblSmartReader.AccessibleName = "";
            LblSmartReader.AccessibleRole = AccessibleRole.Link;
            LblSmartReader.AutoSize = true;
            LblSmartReader.Cursor = Cursors.Hand;
            LblSmartReader.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblSmartReader.Location = new Point(510, 186);
            LblSmartReader.Name = "LblSmartReader";
            LblSmartReader.Size = new Size(87, 19);
            LblSmartReader.TabIndex = 53;
            LblSmartReader.Text = "SmartReader";
            LblSmartReader.Click += LblSmartReader_Click;
            // 
            // LblWebView2
            // 
            LblWebView2.AccessibleDescription = "";
            LblWebView2.AccessibleName = "";
            LblWebView2.AccessibleRole = AccessibleRole.Link;
            LblWebView2.AutoSize = true;
            LblWebView2.Cursor = Cursors.Hand;
            LblWebView2.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblWebView2.Location = new Point(142, 246);
            LblWebView2.Name = "LblWebView2";
            LblWebView2.Size = new Size(164, 19);
            LblWebView2.TabIndex = 52;
            LblWebView2.Text = "Microsoft.Web.WebView2";
            LblWebView2.Click += LblWebView2_Click;
            // 
            // LblDeepLnet
            // 
            LblDeepLnet.AccessibleDescription = "";
            LblDeepLnet.AccessibleName = "";
            LblDeepLnet.AccessibleRole = AccessibleRole.Link;
            LblDeepLnet.AutoSize = true;
            LblDeepLnet.Cursor = Cursors.Hand;
            LblDeepLnet.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblDeepLnet.Location = new Point(142, 216);
            LblDeepLnet.Name = "LblDeepLnet";
            LblDeepLnet.Size = new Size(71, 19);
            LblDeepLnet.TabIndex = 47;
            LblDeepLnet.Text = "DeepL.net";
            LblDeepLnet.Click += LblDeepLnet_Click;
            // 
            // LblInfo3
            // 
            LblInfo3.AccessibleDescription = "Used components information.";
            LblInfo3.AccessibleName = "Components info";
            LblInfo3.AccessibleRole = AccessibleRole.StaticText;
            LblInfo3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblInfo3.Location = new Point(142, 134);
            LblInfo3.Name = "LblInfo3";
            LblInfo3.Size = new Size(536, 38);
            LblInfo3.TabIndex = 46;
            LblInfo3.Text = "This application is open source and completely free, please check the project pages of \r\nthe used components for their individual licenses:";
            // 
            // LblInfo1
            // 
            LblInfo1.AccessibleDescription = "Application description.";
            LblInfo1.AccessibleName = "Description";
            LblInfo1.AccessibleRole = AccessibleRole.StaticText;
            LblInfo1.AutoSize = true;
            LblInfo1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblInfo1.Location = new Point(142, 70);
            LblInfo1.Name = "LblInfo1";
            LblInfo1.Size = new Size(429, 19);
            LblInfo1.TabIndex = 45;
            LblInfo1.Text = "Windows GUI client for the DeepL translation API, both free and pro.";
            // 
            // LblDeepLProject
            // 
            LblDeepLProject.AccessibleDescription = "";
            LblDeepLProject.AccessibleName = "";
            LblDeepLProject.AccessibleRole = AccessibleRole.StaticText;
            LblDeepLProject.AutoSize = true;
            LblDeepLProject.Cursor = Cursors.Hand;
            LblDeepLProject.Font = new Font("Segoe UI Semibold", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            LblDeepLProject.Location = new Point(135, 10);
            LblDeepLProject.Name = "LblDeepLProject";
            LblDeepLProject.Size = new Size(287, 47);
            LblDeepLProject.TabIndex = 44;
            LblDeepLProject.Text = "DeepL Translator";
            LblDeepLProject.Click += LblDeepLProject_Click;
            // 
            // LblVersion
            // 
            LblVersion.AccessibleDescription = "HASS.Agent's current version.";
            LblVersion.AccessibleName = "Version";
            LblVersion.AccessibleRole = AccessibleRole.StaticText;
            LblVersion.AutoSize = true;
            LblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            LblVersion.Location = new Point(12, 465);
            LblVersion.Name = "LblVersion";
            LblVersion.Size = new Size(12, 15);
            LblVersion.TabIndex = 73;
            LblVersion.Text = "-";
            // 
            // LblHotkeyListener
            // 
            LblHotkeyListener.AccessibleDescription = "";
            LblHotkeyListener.AccessibleName = "";
            LblHotkeyListener.AccessibleRole = AccessibleRole.Link;
            LblHotkeyListener.AutoSize = true;
            LblHotkeyListener.Cursor = Cursors.Hand;
            LblHotkeyListener.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblHotkeyListener.Location = new Point(328, 216);
            LblHotkeyListener.Name = "LblHotkeyListener";
            LblHotkeyListener.Size = new Size(101, 19);
            LblHotkeyListener.TabIndex = 50;
            LblHotkeyListener.Text = "HotkeyListener";
            LblHotkeyListener.Click += LblHotkeyListener_Click;
            // 
            // LblNewtonsoftJson
            // 
            LblNewtonsoftJson.AccessibleDescription = "";
            LblNewtonsoftJson.AccessibleName = "";
            LblNewtonsoftJson.AccessibleRole = AccessibleRole.Link;
            LblNewtonsoftJson.AutoSize = true;
            LblNewtonsoftJson.Cursor = Cursors.Hand;
            LblNewtonsoftJson.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblNewtonsoftJson.Location = new Point(328, 186);
            LblNewtonsoftJson.Name = "LblNewtonsoftJson";
            LblNewtonsoftJson.Size = new Size(110, 19);
            LblNewtonsoftJson.TabIndex = 54;
            LblNewtonsoftJson.Text = "Newtonsoft.Json";
            LblNewtonsoftJson.Click += LblNewtonsoftJson_Click;
            // 
            // label1
            // 
            label1.AccessibleDescription = "Application description.";
            label1.AccessibleName = "Description";
            label1.AccessibleRole = AccessibleRole.StaticText;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(145, 332);
            label1.Name = "label1";
            label1.Size = new Size(509, 34);
            label1.TabIndex = 74;
            label1.Text = "LAB02 Research is not in any way affiliated with DeepL, and does not receive any\r\ncommisions or other payment for developing this application.";
            // 
            // LblDeepL
            // 
            LblDeepL.AccessibleDescription = "";
            LblDeepL.AccessibleName = "";
            LblDeepL.AccessibleRole = AccessibleRole.Link;
            LblDeepL.AutoSize = true;
            LblDeepL.Cursor = Cursors.Hand;
            LblDeepL.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblDeepL.Location = new Point(301, 285);
            LblDeepL.Name = "LblDeepL";
            LblDeepL.Size = new Size(48, 19);
            LblDeepL.TabIndex = 75;
            LblDeepL.Text = "DeepL";
            LblDeepL.Click += LblDeepL_Click;
            // 
            // label2
            // 
            label2.AccessibleDescription = "Home Assistant thanks message.";
            label2.AccessibleName = "HA thanks";
            label2.AccessibleRole = AccessibleRole.StaticText;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(347, 285);
            label2.Name = "label2";
            label2.Size = new Size(285, 19);
            label2.TabIndex = 76;
            label2.Text = "for providing such a great translation service!";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            CaptionBarColor = Color.FromArgb(63, 63, 70);
            CaptionFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CaptionForeColor = Color.FromArgb(241, 241, 241);
            ClientSize = new Size(686, 535);
            Controls.Add(label2);
            Controls.Add(LblDeepL);
            Controls.Add(label1);
            Controls.Add(LblVersion);
            Controls.Add(PbPayPal);
            Controls.Add(PbBMAC);
            Controls.Add(LblByteSize);
            Controls.Add(LblInfo6);
            Controls.Add(LblLab02Research);
            Controls.Add(LblInfo2);
            Controls.Add(LblInfo5);
            Controls.Add(LblSyncfusion);
            Controls.Add(LblSerilog);
            Controls.Add(LblNewtonsoftJson);
            Controls.Add(LblSmartReader);
            Controls.Add(LblWebView2);
            Controls.Add(LblHotkeyListener);
            Controls.Add(LblDeepLnet);
            Controls.Add(LblInfo3);
            Controls.Add(LblInfo1);
            Controls.Add(LblDeepLProject);
            Controls.Add(PbLogo);
            Controls.Add(BtnYes);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MetroColor = Color.FromArgb(63, 63, 70);
            Name = "About";
            ShowMaximizeBox = false;
            ShowMinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            Load += About_Load;
            KeyUp += About_KeyUp;
            ((System.ComponentModel.ISupportInitialize)PbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbPayPal).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbBMAC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnYes;
        private PictureBox PbLogo;
        private PictureBox PbPayPal;
        private PictureBox PbBMAC;
        private Label LblByteSize;
        private Label LblInfo6;
        private Label LblLab02Research;
        private Label LblInfo2;
        private Label LblInfo5;
        private Label LblSyncfusion;
        private Label LblSerilog;
        private Label LblSmartReader;
        private Label LblWebView2;
        private Label LblDeepLnet;
        private Label LblInfo3;
        private Label LblInfo1;
        private Label LblDeepLProject;
        private Label LblVersion;
        private Label LblHotkeyListener;
        private Label LblNewtonsoftJson;
        private Label label1;
        private Label LblDeepL;
        private Label label2;
    }
}