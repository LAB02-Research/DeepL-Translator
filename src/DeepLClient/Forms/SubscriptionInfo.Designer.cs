﻿namespace DeepLClient.Forms
{
    partial class SubscriptionInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubscriptionInfo));
            BtnYes = new Syncfusion.WinForms.Controls.SfButton();
            PbCost = new PictureBox();
            LblSourceLanguage = new Label();
            label1 = new Label();
            label2 = new Label();
            LblLimitReached = new Label();
            LblCharacterLimit = new Label();
            LblCharactersUsed = new Label();
            LblCharactersLeft = new Label();
            LblCost = new Label();
            label4 = new Label();
            LblSubscriptionPage = new Label();
            ToolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)PbCost).BeginInit();
            SuspendLayout();
            // 
            // BtnYes
            // 
            BtnYes.AccessibleDescription = "";
            BtnYes.AccessibleName = "";
            BtnYes.AccessibleRole = AccessibleRole.PushButton;
            BtnYes.BackColor = Color.FromArgb(63, 63, 70);
            BtnYes.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnYes.ForeColor = Color.FromArgb(241, 241, 241);
            BtnYes.ImageSize = new Size(24, 24);
            BtnYes.Location = new Point(115, 193);
            BtnYes.Name = "BtnYes";
            BtnYes.Size = new Size(501, 31);
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
            // PbCost
            // 
            PbCost.Image = Properties.Resources.price_icon_64;
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
            LblSourceLanguage.Size = new Size(153, 19);
            LblSourceLanguage.TabIndex = 67;
            LblSourceLanguage.Text = "character monthly limit:";
            // 
            // label1
            // 
            label1.AccessibleDescription = "";
            label1.AccessibleName = "";
            label1.AccessibleRole = AccessibleRole.StaticText;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(403, 28);
            label1.Name = "label1";
            label1.Size = new Size(107, 19);
            label1.TabIndex = 68;
            label1.Text = "characters used:";
            // 
            // label2
            // 
            label2.AccessibleDescription = "";
            label2.AccessibleName = "";
            label2.AccessibleRole = AccessibleRole.StaticText;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(115, 73);
            label2.Name = "label2";
            label2.Size = new Size(97, 19);
            label2.TabIndex = 69;
            label2.Text = "characters left:";
            // 
            // LblLimitReached
            // 
            LblLimitReached.AccessibleDescription = "";
            LblLimitReached.AccessibleName = "";
            LblLimitReached.AccessibleRole = AccessibleRole.StaticText;
            LblLimitReached.AutoSize = true;
            LblLimitReached.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblLimitReached.ForeColor = Color.FromArgb(255, 128, 128);
            LblLimitReached.Location = new Point(115, 121);
            LblLimitReached.Name = "LblLimitReached";
            LblLimitReached.Size = new Size(0, 17);
            LblLimitReached.TabIndex = 70;
            // 
            // LblCharacterLimit
            // 
            LblCharacterLimit.AccessibleDescription = "";
            LblCharacterLimit.AccessibleName = "";
            LblCharacterLimit.AccessibleRole = AccessibleRole.StaticText;
            LblCharacterLimit.AutoSize = true;
            LblCharacterLimit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblCharacterLimit.Location = new Point(311, 28);
            LblCharacterLimit.Name = "LblCharacterLimit";
            LblCharacterLimit.Size = new Size(17, 19);
            LblCharacterLimit.TabIndex = 71;
            LblCharacterLimit.Text = "0";
            // 
            // LblCharactersUsed
            // 
            LblCharactersUsed.AccessibleDescription = "";
            LblCharactersUsed.AccessibleName = "";
            LblCharactersUsed.AccessibleRole = AccessibleRole.StaticText;
            LblCharactersUsed.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblCharactersUsed.Location = new Point(519, 28);
            LblCharactersUsed.Name = "LblCharactersUsed";
            LblCharactersUsed.Size = new Size(97, 19);
            LblCharactersUsed.TabIndex = 72;
            LblCharactersUsed.Text = "0";
            LblCharactersUsed.TextAlign = ContentAlignment.TopRight;
            // 
            // LblCharactersLeft
            // 
            LblCharactersLeft.AccessibleDescription = "";
            LblCharactersLeft.AccessibleName = "";
            LblCharactersLeft.AccessibleRole = AccessibleRole.StaticText;
            LblCharactersLeft.AutoSize = true;
            LblCharactersLeft.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblCharactersLeft.Location = new Point(312, 74);
            LblCharactersLeft.Name = "LblCharactersLeft";
            LblCharactersLeft.Size = new Size(15, 17);
            LblCharactersLeft.TabIndex = 73;
            LblCharactersLeft.Text = "0";
            // 
            // LblCost
            // 
            LblCost.AccessibleDescription = "";
            LblCost.AccessibleName = "";
            LblCost.AccessibleRole = AccessibleRole.StaticText;
            LblCost.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblCost.Location = new Point(519, 74);
            LblCost.Name = "LblCost";
            LblCost.Size = new Size(97, 19);
            LblCost.TabIndex = 75;
            LblCost.Text = "€ 0,00";
            LblCost.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AccessibleDescription = "";
            label4.AccessibleName = "";
            label4.AccessibleRole = AccessibleRole.StaticText;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(403, 73);
            label4.Name = "label4";
            label4.Size = new Size(101, 19);
            label4.TabIndex = 74;
            label4.Text = "estimated cost:";
            // 
            // LblSubscriptionPage
            // 
            LblSubscriptionPage.AccessibleDescription = "Created by link. Opens the LAB02 Research webpage.";
            LblSubscriptionPage.AccessibleName = "Created by";
            LblSubscriptionPage.AccessibleRole = AccessibleRole.Link;
            LblSubscriptionPage.AutoSize = true;
            LblSubscriptionPage.Cursor = Cursors.Hand;
            LblSubscriptionPage.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            LblSubscriptionPage.Location = new Point(115, 160);
            LblSubscriptionPage.Name = "LblSubscriptionPage";
            LblSubscriptionPage.Size = new Size(177, 19);
            LblSubscriptionPage.TabIndex = 76;
            LblSubscriptionPage.Text = "open subscription webpage";
            LblSubscriptionPage.Click += LblSubscriptionPage_Click;
            // 
            // ToolTip
            // 
            ToolTip.AutoPopDelay = 5000;
            ToolTip.BackColor = Color.FromArgb(241, 241, 241);
            ToolTip.ForeColor = Color.FromArgb(45, 45, 48);
            ToolTip.InitialDelay = 1000;
            ToolTip.ReshowDelay = 100;
            // 
            // SubscriptionInfo
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            CaptionBarColor = Color.FromArgb(63, 63, 70);
            CaptionFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CaptionForeColor = Color.FromArgb(241, 241, 241);
            ClientSize = new Size(627, 231);
            Controls.Add(LblSubscriptionPage);
            Controls.Add(LblCost);
            Controls.Add(label4);
            Controls.Add(LblCharactersLeft);
            Controls.Add(LblCharactersUsed);
            Controls.Add(LblCharacterLimit);
            Controls.Add(LblLimitReached);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LblSourceLanguage);
            Controls.Add(PbCost);
            Controls.Add(BtnYes);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MetroColor = Color.FromArgb(63, 63, 70);
            Name = "SubscriptionInfo";
            ShowMaximizeBox = false;
            ShowMinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subscription Information";
            Load += SubscriptionInfo_Load;
            KeyUp += SubscriptionInfo_KeyUp;
            ((System.ComponentModel.ISupportInitialize)PbCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnYes;
        private PictureBox PbCost;
        private Label LblSourceLanguage;
        private Label label1;
        private Label label2;
        private Label LblLimitReached;
        private Label LblCharacterLimit;
        private Label LblCharactersUsed;
        private Label LblCharactersLeft;
        private Label LblCost;
        private Label label4;
        private Label LblSubscriptionPage;
        private ToolTip ToolTip;
    }
}