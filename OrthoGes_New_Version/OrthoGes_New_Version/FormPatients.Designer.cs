namespace OrthoGes_New_Version
{
    partial class FormPatients
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatients));
            dgvPatientsListe = new Guna.UI2.WinForms.Guna2DataGridView();
            clmn1 = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            guna2TileButton2 = new Guna.UI2.WinForms.Guna2TileButton();
            lblnmbrEnseignants = new Label();
            cmbxRecherche = new Guna.UI2.WinForms.Guna2ComboBox();
            label5 = new Label();
            label4 = new Label();
            tbxRecherche = new Guna.UI2.WinForms.Guna2TextBox();
            label6 = new Label();
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnDetails = new Button();
            btnAjouterPatient = new Button();
            btnCreationBonLiv = new Button();
            btnCreationFacture = new Button();
            btnCreationDevis = new Button();
            btnCreerAccord = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatientsListe).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPatientsListe
            // 
            dgvPatientsListe.AllowUserToAddRows = false;
            dgvPatientsListe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvPatientsListe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPatientsListe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.BackColor = Color.GhostWhite;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = Color.DimGray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPatientsListe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPatientsListe.ColumnHeadersHeight = 40;
            dgvPatientsListe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvPatientsListe.Columns.AddRange(new DataGridViewColumn[] { clmn1 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPatientsListe.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPatientsListe.GridColor = Color.Gainsboro;
            dgvPatientsListe.Location = new Point(12, 117);
            dgvPatientsListe.Name = "dgvPatientsListe";
            dgvPatientsListe.ReadOnly = true;
            dgvPatientsListe.RowHeadersVisible = false;
            dgvPatientsListe.RowHeadersWidth = 51;
            dgvPatientsListe.RowTemplate.Height = 50;
            dgvPatientsListe.Size = new Size(1339, 657);
            dgvPatientsListe.TabIndex = 38;
            dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvPatientsListe.ThemeStyle.BackColor = Color.White;
            dgvPatientsListe.ThemeStyle.GridColor = Color.Gainsboro;
            dgvPatientsListe.ThemeStyle.HeaderStyle.BackColor = Color.White;
            dgvPatientsListe.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPatientsListe.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvPatientsListe.ThemeStyle.HeaderStyle.ForeColor = Color.DimGray;
            dgvPatientsListe.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvPatientsListe.ThemeStyle.HeaderStyle.Height = 40;
            dgvPatientsListe.ThemeStyle.ReadOnly = true;
            dgvPatientsListe.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvPatientsListe.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPatientsListe.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvPatientsListe.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvPatientsListe.ThemeStyle.RowsStyle.Height = 50;
            dgvPatientsListe.ThemeStyle.RowsStyle.SelectionBackColor = Color.LightGray;
            dgvPatientsListe.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            dgvPatientsListe.CellContentDoubleClick += dgvPatientsListe_CellContentDoubleClick;
            // 
            // clmn1
            // 
            clmn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            clmn1.FillWeight = 26.73797F;
            clmn1.HeaderText = "";
            clmn1.MinimumWidth = 6;
            clmn1.Name = "clmn1";
            clmn1.ReadOnly = true;
            clmn1.Width = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(guna2TileButton2);
            panel1.Controls.Add(lblnmbrEnseignants);
            panel1.Controls.Add(cmbxRecherche);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(tbxRecherche);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1362, 55);
            panel1.TabIndex = 32;
            // 
            // guna2TileButton2
            // 
            guna2TileButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2TileButton2.BorderRadius = 7;
            guna2TileButton2.CustomizableEdges = customizableEdges1;
            guna2TileButton2.DisabledState.BorderColor = Color.DarkGray;
            guna2TileButton2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2TileButton2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2TileButton2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2TileButton2.FillColor = Color.Transparent;
            guna2TileButton2.Font = new Font("Segoe UI", 10F);
            guna2TileButton2.ForeColor = Color.White;
            guna2TileButton2.Image = Properties.Resources.icons8_search_32;
            guna2TileButton2.Location = new Point(762, 12);
            guna2TileButton2.Name = "guna2TileButton2";
            guna2TileButton2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TileButton2.Size = new Size(39, 36);
            guna2TileButton2.TabIndex = 26;
            guna2TileButton2.Click += guna2TileButton2_Click;
            // 
            // lblnmbrEnseignants
            // 
            lblnmbrEnseignants.AutoSize = true;
            lblnmbrEnseignants.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblnmbrEnseignants.ForeColor = Color.FromArgb(51, 102, 204);
            lblnmbrEnseignants.Image = Properties.Resources.icons8_wheelchair_48;
            lblnmbrEnseignants.ImageAlign = ContentAlignment.MiddleRight;
            lblnmbrEnseignants.Location = new Point(8, 10);
            lblnmbrEnseignants.Name = "lblnmbrEnseignants";
            lblnmbrEnseignants.Size = new Size(159, 42);
            lblnmbrEnseignants.TabIndex = 25;
            lblnmbrEnseignants.Text = "    ------       ";
            lblnmbrEnseignants.UseCompatibleTextRendering = true;
            // 
            // cmbxRecherche
            // 
            cmbxRecherche.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbxRecherche.BackColor = Color.Transparent;
            cmbxRecherche.BorderColor = Color.Empty;
            cmbxRecherche.BorderRadius = 6;
            cmbxRecherche.CustomizableEdges = customizableEdges3;
            cmbxRecherche.DrawMode = DrawMode.OwnerDrawFixed;
            cmbxRecherche.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxRecherche.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbxRecherche.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbxRecherche.Font = new Font("Segoe UI", 10F);
            cmbxRecherche.ForeColor = Color.FromArgb(68, 88, 112);
            cmbxRecherche.ItemHeight = 30;
            cmbxRecherche.Items.AddRange(new object[] { "Nom et Prénom", "Numéro Patient" });
            cmbxRecherche.Location = new Point(942, 12);
            cmbxRecherche.Name = "cmbxRecherche";
            cmbxRecherche.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbxRecherche.Size = new Size(187, 36);
            cmbxRecherche.StartIndex = 0;
            cmbxRecherche.TabIndex = 20;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.ForeColor = Color.Black;
            label5.Image = Properties.Resources.icons8_filter_24__3_;
            label5.ImageAlign = ContentAlignment.MiddleLeft;
            label5.Location = new Point(846, 15);
            label5.Name = "label5";
            label5.Size = new Size(90, 28);
            label5.TabIndex = 21;
            label5.Text = "     Filtre :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.Black;
            label4.ImageAlign = ContentAlignment.MiddleLeft;
            label4.Location = new Point(286, 13);
            label4.Name = "label4";
            label4.Size = new Size(105, 28);
            label4.TabIndex = 23;
            label4.Text = "Recherche ";
            // 
            // tbxRecherche
            // 
            tbxRecherche.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxRecherche.BorderColor = Color.Black;
            tbxRecherche.BorderRadius = 5;
            tbxRecherche.Cursor = Cursors.IBeam;
            tbxRecherche.CustomizableEdges = customizableEdges5;
            tbxRecherche.DefaultText = "";
            tbxRecherche.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbxRecherche.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbxRecherche.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbxRecherche.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbxRecherche.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxRecherche.Font = new Font("Segoe UI", 10F);
            tbxRecherche.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxRecherche.Location = new Point(397, 11);
            tbxRecherche.Margin = new Padding(3, 4, 3, 4);
            tbxRecherche.Name = "tbxRecherche";
            tbxRecherche.PlaceholderText = "";
            tbxRecherche.SelectedText = "";
            tbxRecherche.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbxRecherche.Size = new Size(359, 36);
            tbxRecherche.TabIndex = 22;
            tbxRecherche.Enter += tbxRecherche_Enter;
            tbxRecherche.KeyDown += tbxRecherche_KeyDown;
            tbxRecherche.Leave += tbxRecherche_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(60, 75, 94);
            label6.ImageAlign = ContentAlignment.MiddleRight;
            label6.Location = new Point(12, 62);
            label6.Name = "label6";
            label6.Size = new Size(287, 47);
            label6.TabIndex = 84;
            label6.Text = "Liste des Patients  :";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.UseCompatibleTextRendering = true;
            // 
            // btnModifier
            // 
            btnModifier.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnModifier.BackColor = Color.White;
            btnModifier.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnModifier.Font = new Font("Segoe UI", 11F);
            btnModifier.ForeColor = Color.Black;
            btnModifier.Image = Properties.Resources.icons8_registration_32;
            btnModifier.ImageAlign = ContentAlignment.MiddleLeft;
            btnModifier.Location = new Point(1072, 782);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(143, 50);
            btnModifier.TabIndex = 37;
            btnModifier.Text = "     Modifier";
            btnModifier.UseCompatibleTextRendering = true;
            btnModifier.UseVisualStyleBackColor = false;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSupprimer.BackColor = Color.White;
            btnSupprimer.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnSupprimer.Font = new Font("Segoe UI", 11F);
            btnSupprimer.ForeColor = Color.Black;
            btnSupprimer.Image = Properties.Resources.icons8_delete_32;
            btnSupprimer.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupprimer.Location = new Point(917, 782);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(143, 50);
            btnSupprimer.TabIndex = 36;
            btnSupprimer.Text = "     Supprimer";
            btnSupprimer.UseCompatibleTextRendering = true;
            btnSupprimer.UseVisualStyleBackColor = false;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnDetails
            // 
            btnDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDetails.BackColor = Color.White;
            btnDetails.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnDetails.Font = new Font("Segoe UI", 11F);
            btnDetails.ForeColor = Color.Black;
            btnDetails.Image = Properties.Resources.icons8_user_menu_male_32;
            btnDetails.ImageAlign = ContentAlignment.MiddleLeft;
            btnDetails.Location = new Point(1227, 780);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(128, 50);
            btnDetails.TabIndex = 35;
            btnDetails.Text = "      Détails";
            btnDetails.UseCompatibleTextRendering = true;
            btnDetails.UseVisualStyleBackColor = false;
            btnDetails.Click += btnDetails_Click;
            // 
            // btnAjouterPatient
            // 
            btnAjouterPatient.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAjouterPatient.BackColor = Color.White;
            btnAjouterPatient.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnAjouterPatient.Font = new Font("Segoe UI", 11F);
            btnAjouterPatient.ForeColor = Color.Black;
            btnAjouterPatient.Image = Properties.Resources.icons8_add_user_32;
            btnAjouterPatient.ImageAlign = ContentAlignment.MiddleLeft;
            btnAjouterPatient.Location = new Point(1151, 62);
            btnAjouterPatient.Name = "btnAjouterPatient";
            btnAjouterPatient.Size = new Size(200, 49);
            btnAjouterPatient.TabIndex = 33;
            btnAjouterPatient.Text = "      Ajouter un Patient";
            btnAjouterPatient.UseCompatibleTextRendering = true;
            btnAjouterPatient.UseVisualStyleBackColor = false;
            btnAjouterPatient.Click += btnAjouterPatient_Click;
            // 
            // btnCreationBonLiv
            // 
            btnCreationBonLiv.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCreationBonLiv.BackColor = Color.White;
            btnCreationBonLiv.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnCreationBonLiv.Font = new Font("Segoe UI", 11F);
            btnCreationBonLiv.ForeColor = Color.Black;
            btnCreationBonLiv.Image = Properties.Resources.icons8_receipt_48;
            btnCreationBonLiv.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreationBonLiv.Location = new Point(309, 782);
            btnCreationBonLiv.Name = "btnCreationBonLiv";
            btnCreationBonLiv.Size = new Size(248, 50);
            btnCreationBonLiv.TabIndex = 87;
            btnCreationBonLiv.Text = "       Créer bon de livraison";
            btnCreationBonLiv.UseCompatibleTextRendering = true;
            btnCreationBonLiv.UseVisualStyleBackColor = false;
            btnCreationBonLiv.Click += btnCreationBonLiv_Click;
            // 
            // btnCreationFacture
            // 
            btnCreationFacture.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCreationFacture.BackColor = Color.White;
            btnCreationFacture.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnCreationFacture.Font = new Font("Segoe UI", 11F);
            btnCreationFacture.ForeColor = Color.Black;
            btnCreationFacture.Image = Properties.Resources.icons8_create_order_48;
            btnCreationFacture.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreationFacture.Location = new Point(569, 782);
            btnCreationFacture.Name = "btnCreationFacture";
            btnCreationFacture.Size = new Size(169, 50);
            btnCreationFacture.TabIndex = 86;
            btnCreationFacture.Text = "        Créer facture";
            btnCreationFacture.UseCompatibleTextRendering = true;
            btnCreationFacture.UseVisualStyleBackColor = false;
            btnCreationFacture.Click += btnCreationFacture_Click;
            // 
            // btnCreationDevis
            // 
            btnCreationDevis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCreationDevis.BackColor = Color.White;
            btnCreationDevis.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnCreationDevis.Font = new Font("Segoe UI", 11F);
            btnCreationDevis.ForeColor = Color.Black;
            btnCreationDevis.Image = Properties.Resources.icons8_new_copy_48__1_;
            btnCreationDevis.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreationDevis.Location = new Point(750, 782);
            btnCreationDevis.Name = "btnCreationDevis";
            btnCreationDevis.Size = new Size(155, 50);
            btnCreationDevis.TabIndex = 85;
            btnCreationDevis.Text = "        Créer devis";
            btnCreationDevis.UseCompatibleTextRendering = true;
            btnCreationDevis.UseVisualStyleBackColor = false;
            btnCreationDevis.Click += btnCreationDevis_Click;
            // 
            // btnCreerAccord
            // 
            btnCreerAccord.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCreerAccord.BackColor = Color.White;
            btnCreerAccord.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnCreerAccord.Font = new Font("Segoe UI", 11F);
            btnCreerAccord.ForeColor = Color.Black;
            btnCreerAccord.Image = Properties.Resources.icons8_signing_a_document_481;
            btnCreerAccord.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreerAccord.Location = new Point(130, 782);
            btnCreerAccord.Name = "btnCreerAccord";
            btnCreerAccord.Size = new Size(169, 50);
            btnCreerAccord.TabIndex = 88;
            btnCreerAccord.Text = "        Créer accord";
            btnCreerAccord.UseCompatibleTextRendering = true;
            btnCreerAccord.UseVisualStyleBackColor = false;
            btnCreerAccord.Click += btnCreerAccord_Click;
            // 
            // FormPatients
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(1362, 842);
            Controls.Add(btnCreerAccord);
            Controls.Add(btnCreationBonLiv);
            Controls.Add(btnCreationFacture);
            Controls.Add(btnCreationDevis);
            Controls.Add(label6);
            Controls.Add(dgvPatientsListe);
            Controls.Add(btnModifier);
            Controls.Add(btnSupprimer);
            Controls.Add(btnDetails);
            Controls.Add(btnAjouterPatient);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPatients";
            Text = "FormPatients";
            Load += FormPatients_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPatientsListe).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvPatientsListe;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnAjouterPatient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblnmbrEnseignants;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox tbxRecherche;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxRecherche;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmn1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreationBonLiv;
        private System.Windows.Forms.Button btnCreationFacture;
        private System.Windows.Forms.Button btnCreationDevis;
        private Button btnCreerAccord;
    }
}