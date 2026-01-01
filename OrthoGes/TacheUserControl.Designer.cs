namespace SMS_UI
{
    partial class TacheUserControl
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
            this.pnlComponents = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.lblT = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFini = new System.Windows.Forms.Button();
            this.picboxIsCanceled = new Guna.UI2.WinForms.Guna2PictureBox();
            this.picboxIsDone = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.tbxText = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxIsCanceled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxIsDone)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlComponents
            // 
            this.pnlComponents.BorderRadius = 11;
            this.pnlComponents.Controls.Add(this.tbxText);
            this.pnlComponents.Controls.Add(this.button1);
            this.pnlComponents.Controls.Add(this.btnFini);
            this.pnlComponents.Controls.Add(this.picboxIsCanceled);
            this.pnlComponents.Controls.Add(this.picboxIsDone);
            this.pnlComponents.Controls.Add(this.btnAnnuler);
            this.pnlComponents.Controls.Add(this.lblDate);
            this.pnlComponents.Controls.Add(this.lblD);
            this.pnlComponents.Controls.Add(this.lblT);
            this.pnlComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComponents.FillColor = System.Drawing.Color.AliceBlue;
            this.pnlComponents.Location = new System.Drawing.Point(0, 0);
            this.pnlComponents.Name = "pnlComponents";
            this.pnlComponents.Size = new System.Drawing.Size(391, 194);
            this.pnlComponents.TabIndex = 0;
            this.pnlComponents.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlComponents_Paint);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(77, 153);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(60, 28);
            this.lblDate.TabIndex = 78;
            this.lblDate.Text = "------";
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD.Location = new System.Drawing.Point(3, 154);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(65, 28);
            this.lblD.TabIndex = 75;
            this.lblD.Text = "Date :";
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT.Location = new System.Drawing.Point(3, 7);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(91, 31);
            this.lblT.TabIndex = 73;
            this.lblT.Text = "Tache : ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::OrthoGes.Properties.Resources.delete;
            this.button1.Location = new System.Drawing.Point(231, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 44);
            this.button1.TabIndex = 86;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFini
            // 
            this.btnFini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFini.FlatAppearance.BorderSize = 0;
            this.btnFini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFini.Image = global::OrthoGes.Properties.Resources.check__1_;
            this.btnFini.Location = new System.Drawing.Point(337, 144);
            this.btnFini.Name = "btnFini";
            this.btnFini.Size = new System.Drawing.Size(47, 44);
            this.btnFini.TabIndex = 85;
            this.btnFini.UseVisualStyleBackColor = true;
            this.btnFini.Click += new System.EventHandler(this.btnFini_Click);
            // 
            // picboxIsCanceled
            // 
            this.picboxIsCanceled.Image = global::OrthoGes.Properties.Resources.cancel1;
            this.picboxIsCanceled.ImageRotate = 0F;
            this.picboxIsCanceled.Location = new System.Drawing.Point(356, 4);
            this.picboxIsCanceled.Name = "picboxIsCanceled";
            this.picboxIsCanceled.Size = new System.Drawing.Size(30, 30);
            this.picboxIsCanceled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxIsCanceled.TabIndex = 84;
            this.picboxIsCanceled.TabStop = false;
            this.picboxIsCanceled.Visible = false;
            // 
            // picboxIsDone
            // 
            this.picboxIsDone.Image = global::OrthoGes.Properties.Resources.check1;
            this.picboxIsDone.ImageRotate = 0F;
            this.picboxIsDone.Location = new System.Drawing.Point(356, 4);
            this.picboxIsDone.Name = "picboxIsDone";
            this.picboxIsDone.Size = new System.Drawing.Size(30, 30);
            this.picboxIsDone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picboxIsDone.TabIndex = 83;
            this.picboxIsDone.TabStop = false;
            this.picboxIsDone.Visible = false;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Image = global::OrthoGes.Properties.Resources.cross;
            this.btnAnnuler.Location = new System.Drawing.Point(284, 144);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(47, 44);
            this.btnAnnuler.TabIndex = 81;
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click_1);
            // 
            // tbxText
            // 
            this.tbxText.BackColor = System.Drawing.Color.Transparent;
            this.tbxText.BorderColor = System.Drawing.Color.Transparent;
            this.tbxText.BorderRadius = 6;
            this.tbxText.BorderThickness = 0;
            this.tbxText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxText.DefaultText = "";
            this.tbxText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxText.FillColor = System.Drawing.Color.AliceBlue;
            this.tbxText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbxText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxText.Location = new System.Drawing.Point(0, 40);
            this.tbxText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxText.Multiline = true;
            this.tbxText.Name = "tbxText";
            this.tbxText.PlaceholderText = "";
            this.tbxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxText.SelectedText = "";
            this.tbxText.Size = new System.Drawing.Size(424, 102);
            this.tbxText.TabIndex = 87;
            // 
            // TacheUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlComponents);
            this.Name = "TacheUserControl";
            this.Size = new System.Drawing.Size(391, 194);
            this.pnlComponents.ResumeLayout(false);
            this.pnlComponents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxIsCanceled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxIsDone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlComponents;
        private Guna.UI2.WinForms.Guna2PictureBox picboxIsCanceled;
        private Guna.UI2.WinForms.Guna2PictureBox picboxIsDone;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Button btnFini;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2TextBox tbxText;
    }
}
