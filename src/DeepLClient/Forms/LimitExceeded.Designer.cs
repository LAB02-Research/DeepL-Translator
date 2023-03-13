namespace DeepLClient.Forms
{
    partial class LimitExceeded
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LimitExceeded));
            BtnNo = new Syncfusion.WinForms.Controls.SfButton();
            BtnYes = new Syncfusion.WinForms.Controls.SfButton();
            PbCost = new PictureBox();
            LblLoading = new Label();
            LblIntro = new Label();
            LblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)PbCost).BeginInit();
            SuspendLayout();
            // 
            // BtnNo
            // 
            BtnNo.AccessibleDescription = "";
            BtnNo.AccessibleName = "";
            BtnNo.AccessibleRole = AccessibleRole.PushButton;
            BtnNo.BackColor = Color.FromArgb(63, 63, 70);
            BtnNo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            BtnNo.ForeColor = Color.FromArgb(241, 241, 241);
            BtnNo.ImageSize = new Size(16, 16);
            BtnNo.Location = new Point(115, 227);
            BtnNo.Name = "BtnNo";
            BtnNo.Size = new Size(157, 31);
            BtnNo.Style.BackColor = Color.FromArgb(63, 63, 70);
            BtnNo.Style.FocusedBackColor = Color.FromArgb(63, 63, 70);
            BtnNo.Style.FocusedForeColor = Color.FromArgb(241, 241, 241);
            BtnNo.Style.ForeColor = Color.FromArgb(241, 241, 241);
            BtnNo.Style.HoverBackColor = Color.FromArgb(63, 63, 70);
            BtnNo.Style.HoverForeColor = Color.FromArgb(241, 241, 241);
            BtnNo.Style.Image = Properties.Resources.no_icon_16;
            BtnNo.Style.PressedForeColor = Color.Black;
            BtnNo.TabIndex = 1;
            BtnNo.UseVisualStyleBackColor = false;
            BtnNo.Click += BtnNo_Click;
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
            BtnYes.Location = new Point(278, 227);
            BtnYes.Name = "BtnYes";
            BtnYes.Size = new Size(324, 31);
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
            // LblLoading
            // 
            LblLoading.AccessibleDescription = "";
            LblLoading.AccessibleName = "";
            LblLoading.AccessibleRole = AccessibleRole.StaticText;
            LblLoading.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblLoading.Location = new Point(115, 28);
            LblLoading.Name = "LblLoading";
            LblLoading.Size = new Size(487, 183);
            LblLoading.TabIndex = 71;
            LblLoading.Text = "Please hold while we're gathering info ..";
            // 
            // LblIntro
            // 
            LblIntro.AccessibleDescription = "";
            LblIntro.AccessibleName = "";
            LblIntro.AccessibleRole = AccessibleRole.StaticText;
            LblIntro.AutoSize = true;
            LblIntro.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblIntro.ForeColor = Color.FromArgb(255, 128, 128);
            LblIntro.Location = new Point(115, 28);
            LblIntro.Name = "LblIntro";
            LblIntro.Size = new Size(0, 17);
            LblIntro.TabIndex = 72;
            LblIntro.Visible = false;
            // 
            // LblInfo
            // 
            LblInfo.AccessibleDescription = "";
            LblInfo.AccessibleName = "";
            LblInfo.AccessibleRole = AccessibleRole.StaticText;
            LblInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblInfo.Location = new Point(115, 71);
            LblInfo.Name = "LblInfo";
            LblInfo.Size = new Size(487, 140);
            LblInfo.TabIndex = 73;
            LblInfo.Visible = false;
            // 
            // LimitExceeded
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            CaptionBarColor = Color.FromArgb(63, 63, 70);
            CaptionFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CaptionForeColor = Color.FromArgb(241, 241, 241);
            ClientSize = new Size(626, 266);
            Controls.Add(LblInfo);
            Controls.Add(LblIntro);
            Controls.Add(PbCost);
            Controls.Add(BtnYes);
            Controls.Add(BtnNo);
            Controls.Add(LblLoading);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MetroColor = Color.FromArgb(63, 63, 70);
            Name = "LimitExceeded";
            ShowMaximizeBox = false;
            ShowMinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Limit Warning   |   LAB02 Research";
            Load += LimitExceeded_Load;
            ((System.ComponentModel.ISupportInitialize)PbCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnNo;
        private Syncfusion.WinForms.Controls.SfButton BtnYes;
        private PictureBox PbCost;
        private Label LblLoading;
        private Label LblIntro;
        private Label LblInfo;
    }
}