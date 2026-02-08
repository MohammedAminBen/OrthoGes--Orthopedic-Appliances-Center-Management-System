namespace OrthoGes_New_Version
{
    partial class FormEntrerMotDePasse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntrerMotDePasse));
            label8 = new Label();
            btnAnnuler = new Button();
            tbxMotDePasse = new Guna.UI2.WinForms.Guna2TextBox();
            btnEnregistrer = new Button();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(10, 7);
            label8.Name = "label8";
            label8.Size = new Size(133, 25);
            label8.TabIndex = 34;
            label8.Text = "Mot de passe :";
            // 
            // btnAnnuler
            // 
            btnAnnuler.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnnuler.BackColor = Color.White;
            btnAnnuler.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnAnnuler.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAnnuler.Location = new Point(200, 106);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(113, 43);
            btnAnnuler.TabIndex = 33;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = false;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // tbxMotDePasse
            // 
            tbxMotDePasse.BorderColor = Color.Black;
            tbxMotDePasse.BorderRadius = 8;
            tbxMotDePasse.Cursor = Cursors.IBeam;
            tbxMotDePasse.CustomizableEdges = customizableEdges1;
            tbxMotDePasse.DefaultText = "";
            tbxMotDePasse.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbxMotDePasse.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbxMotDePasse.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbxMotDePasse.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbxMotDePasse.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxMotDePasse.Font = new Font("Segoe UI", 9F);
            tbxMotDePasse.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxMotDePasse.IconLeft = Properties.Resources.icons8_password_48;
            tbxMotDePasse.Location = new Point(15, 39);
            tbxMotDePasse.Margin = new Padding(3, 4, 3, 4);
            tbxMotDePasse.MaxLength = 10;
            tbxMotDePasse.Name = "tbxMotDePasse";
            tbxMotDePasse.PlaceholderText = "";
            tbxMotDePasse.SelectedText = "";
            tbxMotDePasse.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbxMotDePasse.Size = new Size(298, 52);
            tbxMotDePasse.TabIndex = 35;
            tbxMotDePasse.UseSystemPasswordChar = true;
            tbxMotDePasse.KeyDown += tbxMotDePasse_KeyDown;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEnregistrer.BackColor = Color.White;
            btnEnregistrer.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnEnregistrer.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnregistrer.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnregistrer.Location = new Point(90, 107);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(104, 42);
            btnEnregistrer.TabIndex = 32;
            btnEnregistrer.Text = "Confirmer";
            btnEnregistrer.UseCompatibleTextRendering = true;
            btnEnregistrer.UseVisualStyleBackColor = false;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // FormEntrerMotDePasse
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(325, 158);
            Controls.Add(tbxMotDePasse);
            Controls.Add(label8);
            Controls.Add(btnAnnuler);
            Controls.Add(btnEnregistrer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormEntrerMotDePasse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Entrer le mot de passe";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnEnregistrer;
        private Guna.UI2.WinForms.Guna2TextBox tbxMotDePasse;
    }
}