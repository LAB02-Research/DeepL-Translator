namespace DeepLClient.Forms
{
    partial class ConfirmDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmDocument));
            BtnNo = new Syncfusion.WinForms.Controls.SfButton();
            BtnYes = new Syncfusion.WinForms.Controls.SfButton();
            PbCost = new PictureBox();
            LblIntro = new Label();
            LblTxt = new Label();
            LblDocument = new Label();
            LblCostInfo = new Label();
            LblConfirm = new Label();
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
            BtnNo.Location = new Point(115, 288);
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
            BtnYes.Location = new Point(278, 288);
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
            // LblIntro
            // 
            LblIntro.AccessibleDescription = "";
            LblIntro.AccessibleName = "";
            LblIntro.AccessibleRole = AccessibleRole.StaticText;
            LblIntro.AutoSize = true;
            LblIntro.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblIntro.Location = new Point(115, 28);
            LblIntro.Name = "LblIntro";
            LblIntro.Size = new Size(105, 19);
            LblIntro.TabIndex = 71;
            LblIntro.Text = "You've selected:";
            // 
            // LblTxt
            // 
            LblTxt.AccessibleDescription = "";
            LblTxt.AccessibleName = "";
            LblTxt.AccessibleRole = AccessibleRole.StaticText;
            LblTxt.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            LblTxt.Location = new Point(115, 252);
            LblTxt.Name = "LblTxt";
            LblTxt.Size = new Size(487, 33);
            LblTxt.TabIndex = 77;
            LblTxt.Text = "Tip: you're trying to translate a small .txt file. Did you know you can just drag and drop them onto the text page? That way it'll use up less characters.";
            LblTxt.Visible = false;
            // 
            // LblDocument
            // 
            LblDocument.AccessibleDescription = "";
            LblDocument.AccessibleName = "";
            LblDocument.AccessibleRole = AccessibleRole.StaticText;
            LblDocument.AutoSize = true;
            LblDocument.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblDocument.Location = new Point(115, 72);
            LblDocument.Name = "LblDocument";
            LblDocument.Size = new Size(13, 17);
            LblDocument.TabIndex = 78;
            LblDocument.Text = "-";
            // 
            // LblCostInfo
            // 
            LblCostInfo.AccessibleDescription = "";
            LblCostInfo.AccessibleName = "";
            LblCostInfo.AccessibleRole = AccessibleRole.StaticText;
            LblCostInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblCostInfo.Location = new Point(115, 114);
            LblCostInfo.Name = "LblCostInfo";
            LblCostInfo.Size = new Size(487, 87);
            LblCostInfo.TabIndex = 79;
            LblCostInfo.Text = "It contains {0} characters, and will probably cost around {1}.";
            // 
            // LblConfirm
            // 
            LblConfirm.AccessibleDescription = "";
            LblConfirm.AccessibleName = "";
            LblConfirm.AccessibleRole = AccessibleRole.StaticText;
            LblConfirm.AutoSize = true;
            LblConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LblConfirm.Location = new Point(115, 208);
            LblConfirm.Name = "LblConfirm";
            LblConfirm.Size = new Size(288, 19);
            LblConfirm.TabIndex = 80;
            LblConfirm.Text = "Are you sure you want to use this document?";
            // 
            // ConfirmDocument
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            CaptionBarColor = Color.FromArgb(63, 63, 70);
            CaptionFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CaptionForeColor = Color.FromArgb(241, 241, 241);
            ClientSize = new Size(626, 330);
            Controls.Add(LblConfirm);
            Controls.Add(LblCostInfo);
            Controls.Add(LblDocument);
            Controls.Add(LblTxt);
            Controls.Add(PbCost);
            Controls.Add(BtnYes);
            Controls.Add(BtnNo);
            Controls.Add(LblIntro);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(241, 241, 241);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MetroColor = Color.FromArgb(63, 63, 70);
            Name = "ConfirmDocument";
            ShowMaximizeBox = false;
            ShowMinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cost Confirmation";
            Load += ConfirmDocument_Load;
            KeyUp += ConfirmDocument_KeyUp;
            ((System.ComponentModel.ISupportInitialize)PbCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnNo;
        private Syncfusion.WinForms.Controls.SfButton BtnYes;
        private PictureBox PbCost;
        private Label LblIntro;
        private Label LblTxt;
        private Label LblDocument;
        private Label LblCostInfo;
        private Label LblConfirm;
    }
}