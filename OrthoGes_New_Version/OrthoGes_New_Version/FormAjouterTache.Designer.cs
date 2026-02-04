namespace OrthoGes_New_Version
{
    partial class FormAjouterTache
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAjouterTache));
            tbxText = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            btnAnnuler = new Button();
            btnEnregistrer = new Button();
            SuspendLayout();
            // 
            // tbxText
            // 
            tbxText.AcceptsReturn = true;
            tbxText.AutoScroll = true;
            tbxText.BackColor = Color.White;
            tbxText.BorderColor = Color.Black;
            tbxText.BorderRadius = 6;
            tbxText.Cursor = Cursors.IBeam;
            tbxText.CustomizableEdges = customizableEdges1;
            tbxText.DefaultText = "";
            tbxText.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbxText.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbxText.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbxText.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbxText.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxText.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxText.ForeColor = Color.FromArgb(64, 64, 64);
            tbxText.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxText.Location = new Point(12, 55);
            tbxText.Margin = new Padding(3, 4, 3, 4);
            tbxText.Multiline = true;
            tbxText.Name = "tbxText";
            tbxText.PlaceholderText = "";
            tbxText.ScrollBars = ScrollBars.Vertical;
            tbxText.SelectedText = "";
            tbxText.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbxText.Size = new Size(389, 169);
            tbxText.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(51, 102, 204);
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(12, 4);
            label1.Name = "label1";
            label1.Size = new Size(239, 47);
            label1.TabIndex = 43;
            label1.Text = "Text du tâches :";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseCompatibleTextRendering = true;
            // 
            // btnAnnuler
            // 
            btnAnnuler.BackColor = Color.White;
            btnAnnuler.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnAnnuler.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAnnuler.ForeColor = Color.Black;
            btnAnnuler.Location = new Point(268, 242);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(133, 46);
            btnAnnuler.TabIndex = 45;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = false;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.BackColor = Color.White;
            btnEnregistrer.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnEnregistrer.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnregistrer.ForeColor = Color.Black;
            btnEnregistrer.Image = Properties.Resources.icons8_save_323;
            btnEnregistrer.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnregistrer.Location = new Point(102, 243);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(159, 46);
            btnEnregistrer.TabIndex = 44;
            btnEnregistrer.Text = "   Enregistrer";
            btnEnregistrer.UseCompatibleTextRendering = true;
            btnEnregistrer.UseVisualStyleBackColor = false;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // FormAjouterTache
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(409, 298);
            Controls.Add(btnEnregistrer);
            Controls.Add(btnAnnuler);
            Controls.Add(label1);
            Controls.Add(tbxText);
            ForeColor = Color.CornflowerBlue;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAjouterTache";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ajouter Tache";
            TransparencyKey = Color.WhiteSmoke;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbxText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}