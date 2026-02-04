namespace OrthoGes_New_Version
{
    partial class FormModifierEtatAccord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModifierEtatAccord));
            btnAnnuler = new Button();
            btnEnregistrer = new Button();
            cmbxetat = new Guna.UI2.WinForms.Guna2ComboBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // btnAnnuler
            // 
            btnAnnuler.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnnuler.BackColor = Color.White;
            btnAnnuler.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnAnnuler.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAnnuler.Location = new Point(181, 90);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(113, 43);
            btnAnnuler.TabIndex = 33;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = false;
            btnAnnuler.Click += btnAnnuler_Click_1;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEnregistrer.BackColor = Color.White;
            btnEnregistrer.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnEnregistrer.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnregistrer.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnregistrer.Location = new Point(71, 91);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(104, 42);
            btnEnregistrer.TabIndex = 32;
            btnEnregistrer.Text = "Confirmer";
            btnEnregistrer.UseCompatibleTextRendering = true;
            btnEnregistrer.UseVisualStyleBackColor = false;
            btnEnregistrer.Click += btnEnregistrer_Click_1;
            // 
            // cmbxetat
            // 
            cmbxetat.BackColor = Color.Transparent;
            cmbxetat.BorderColor = Color.Black;
            cmbxetat.BorderRadius = 6;
            cmbxetat.CustomizableEdges = customizableEdges1;
            cmbxetat.DisabledState.FillColor = Color.FromArgb(224, 224, 224);
            cmbxetat.DisabledState.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbxetat.DisabledState.ForeColor = Color.Black;
            cmbxetat.DrawMode = DrawMode.OwnerDrawFixed;
            cmbxetat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxetat.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbxetat.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbxetat.Font = new Font("Segoe UI", 10.2F);
            cmbxetat.ForeColor = Color.FromArgb(68, 88, 112);
            cmbxetat.ItemHeight = 30;
            cmbxetat.Items.AddRange(new object[] { "En attente", "Semi fini", "Prêt", "Livré" });
            cmbxetat.Location = new Point(72, 28);
            cmbxetat.Name = "cmbxetat";
            cmbxetat.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbxetat.Size = new Size(195, 36);
            cmbxetat.TabIndex = 65;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = Color.Black;
            label6.ImageAlign = ContentAlignment.MiddleLeft;
            label6.Location = new Point(11, 28);
            label6.Name = "label6";
            label6.Size = new Size(55, 28);
            label6.TabIndex = 64;
            label6.Text = "etat :";
            // 
            // FormModifierEtatAccord
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(306, 142);
            Controls.Add(cmbxetat);
            Controls.Add(label6);
            Controls.Add(btnAnnuler);
            Controls.Add(btnEnregistrer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormModifierEtatAccord";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modifier etat d'accord";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnEnregistrer;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxetat;
        private System.Windows.Forms.Label label6;
    }
}