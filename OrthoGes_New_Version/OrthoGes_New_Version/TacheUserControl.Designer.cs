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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlComponents = new Guna.UI2.WinForms.Guna2Panel();
            tbxText = new Guna.UI2.WinForms.Guna2TextBox();
            button1 = new Button();
            btnFini = new Button();
            picboxIsCanceled = new Guna.UI2.WinForms.Guna2PictureBox();
            picboxIsDone = new Guna.UI2.WinForms.Guna2PictureBox();
            btnAnnuler = new Button();
            lblDate = new Label();
            lblD = new Label();
            lblT = new Label();
            pnlComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picboxIsCanceled).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picboxIsDone).BeginInit();
            SuspendLayout();
            // 
            // pnlComponents
            // 
            pnlComponents.BorderRadius = 11;
            pnlComponents.Controls.Add(tbxText);
            pnlComponents.Controls.Add(button1);
            pnlComponents.Controls.Add(btnFini);
            pnlComponents.Controls.Add(picboxIsCanceled);
            pnlComponents.Controls.Add(picboxIsDone);
            pnlComponents.Controls.Add(btnAnnuler);
            pnlComponents.Controls.Add(lblDate);
            pnlComponents.Controls.Add(lblD);
            pnlComponents.Controls.Add(lblT);
            pnlComponents.CustomizableEdges = customizableEdges7;
            pnlComponents.Dock = DockStyle.Fill;
            pnlComponents.FillColor = Color.AliceBlue;
            pnlComponents.Location = new Point(0, 0);
            pnlComponents.Name = "pnlComponents";
            pnlComponents.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlComponents.Size = new Size(391, 194);
            pnlComponents.TabIndex = 0;
            pnlComponents.Paint += pnlComponents_Paint;
            // 
            // tbxText
            // 
            tbxText.BackColor = Color.Transparent;
            tbxText.BorderColor = Color.Transparent;
            tbxText.BorderRadius = 6;
            tbxText.BorderThickness = 0;
            tbxText.Cursor = Cursors.IBeam;
            tbxText.CustomizableEdges = customizableEdges1;
            tbxText.DefaultText = "";
            tbxText.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbxText.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbxText.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbxText.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbxText.FillColor = Color.AliceBlue;
            tbxText.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxText.ForeColor = Color.FromArgb(64, 64, 64);
            tbxText.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxText.Location = new Point(0, 40);
            tbxText.Margin = new Padding(4, 5, 4, 5);
            tbxText.Multiline = true;
            tbxText.Name = "tbxText";
            tbxText.PlaceholderText = "";
            tbxText.ScrollBars = ScrollBars.Vertical;
            tbxText.SelectedText = "";
            tbxText.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbxText.Size = new Size(424, 102);
            tbxText.TabIndex = 87;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = OrthoGes_New_Version.Properties.Resources.delete;
            button1.Location = new Point(231, 144);
            button1.Name = "button1";
            button1.Size = new Size(47, 44);
            button1.TabIndex = 86;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnFini
            // 
            btnFini.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFini.FlatAppearance.BorderSize = 0;
            btnFini.FlatStyle = FlatStyle.Flat;
            btnFini.Image = OrthoGes_New_Version.Properties.Resources.check__1_;
            btnFini.Location = new Point(337, 144);
            btnFini.Name = "btnFini";
            btnFini.Size = new Size(47, 44);
            btnFini.TabIndex = 85;
            btnFini.UseVisualStyleBackColor = true;
            btnFini.Click += btnFini_Click;
            // 
            // picboxIsCanceled
            // 
            picboxIsCanceled.CustomizableEdges = customizableEdges3;
            picboxIsCanceled.Image = OrthoGes_New_Version.Properties.Resources.cancel1;
            picboxIsCanceled.ImageRotate = 0F;
            picboxIsCanceled.Location = new Point(356, 4);
            picboxIsCanceled.Name = "picboxIsCanceled";
            picboxIsCanceled.ShadowDecoration.CustomizableEdges = customizableEdges4;
            picboxIsCanceled.Size = new Size(30, 30);
            picboxIsCanceled.SizeMode = PictureBoxSizeMode.Zoom;
            picboxIsCanceled.TabIndex = 84;
            picboxIsCanceled.TabStop = false;
            picboxIsCanceled.Visible = false;
            // 
            // picboxIsDone
            // 
            picboxIsDone.CustomizableEdges = customizableEdges5;
            picboxIsDone.Image = OrthoGes_New_Version.Properties.Resources.check1;
            picboxIsDone.ImageRotate = 0F;
            picboxIsDone.Location = new Point(356, 4);
            picboxIsDone.Name = "picboxIsDone";
            picboxIsDone.ShadowDecoration.CustomizableEdges = customizableEdges6;
            picboxIsDone.Size = new Size(30, 30);
            picboxIsDone.SizeMode = PictureBoxSizeMode.Zoom;
            picboxIsDone.TabIndex = 83;
            picboxIsDone.TabStop = false;
            picboxIsDone.Visible = false;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnnuler.FlatAppearance.BorderSize = 0;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.Image = OrthoGes_New_Version.Properties.Resources.cross;
            btnAnnuler.Location = new Point(284, 144);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(47, 44);
            btnAnnuler.TabIndex = 81;
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click_1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(77, 153);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(60, 28);
            lblDate.TabIndex = 78;
            lblDate.Text = "------";
            // 
            // lblD
            // 
            lblD.AutoSize = true;
            lblD.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblD.Location = new Point(3, 154);
            lblD.Name = "lblD";
            lblD.Size = new Size(65, 28);
            lblD.TabIndex = 75;
            lblD.Text = "Date :";
            // 
            // lblT
            // 
            lblT.AutoSize = true;
            lblT.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblT.Location = new Point(3, 7);
            lblT.Name = "lblT";
            lblT.Size = new Size(91, 31);
            lblT.TabIndex = 73;
            lblT.Text = "Tâche : ";
            // 
            // TacheUserControl
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Transparent;
            Controls.Add(pnlComponents);
            Name = "TacheUserControl";
            Size = new Size(391, 194);
            pnlComponents.ResumeLayout(false);
            pnlComponents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picboxIsCanceled).EndInit();
            ((System.ComponentModel.ISupportInitialize)picboxIsDone).EndInit();
            ResumeLayout(false);

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
