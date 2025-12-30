namespace OrthoGes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatients));
            this.dgvPatientsListe = new Guna.UI2.WinForms.Guna2DataGridView();
            this.clmn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2TileButton2 = new Guna.UI2.WinForms.Guna2TileButton();
            this.lblnmbrEnseignants = new System.Windows.Forms.Label();
            this.cmbxRecherche = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxRecherche = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnAjouterPatient = new System.Windows.Forms.Button();
            this.btnCreationBonLiv = new System.Windows.Forms.Button();
            this.btnCreationFacture = new System.Windows.Forms.Button();
            this.btnCreationDevis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientsListe)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPatientsListe
            // 
            this.dgvPatientsListe.AllowUserToAddRows = false;
            this.dgvPatientsListe.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPatientsListe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatientsListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientsListe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatientsListe.ColumnHeadersHeight = 40;
            this.dgvPatientsListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPatientsListe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmn1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatientsListe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatientsListe.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvPatientsListe.Location = new System.Drawing.Point(12, 117);
            this.dgvPatientsListe.Name = "dgvPatientsListe";
            this.dgvPatientsListe.ReadOnly = true;
            this.dgvPatientsListe.RowHeadersVisible = false;
            this.dgvPatientsListe.RowHeadersWidth = 51;
            this.dgvPatientsListe.RowTemplate.Height = 50;
            this.dgvPatientsListe.Size = new System.Drawing.Size(1339, 657);
            this.dgvPatientsListe.TabIndex = 38;
            this.dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPatientsListe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPatientsListe.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPatientsListe.ThemeStyle.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvPatientsListe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvPatientsListe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPatientsListe.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPatientsListe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvPatientsListe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPatientsListe.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvPatientsListe.ThemeStyle.ReadOnly = true;
            this.dgvPatientsListe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPatientsListe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPatientsListe.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPatientsListe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvPatientsListe.ThemeStyle.RowsStyle.Height = 50;
            this.dgvPatientsListe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.dgvPatientsListe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPatientsListe.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatientsListe_CellContentDoubleClick);
            // 
            // clmn1
            // 
            this.clmn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmn1.FillWeight = 26.73797F;
            this.clmn1.HeaderText = "";
            this.clmn1.MinimumWidth = 6;
            this.clmn1.Name = "clmn1";
            this.clmn1.ReadOnly = true;
            this.clmn1.Width = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.guna2TileButton2);
            this.panel1.Controls.Add(this.lblnmbrEnseignants);
            this.panel1.Controls.Add(this.cmbxRecherche);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxRecherche);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 55);
            this.panel1.TabIndex = 32;
            // 
            // guna2TileButton2
            // 
            this.guna2TileButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TileButton2.BorderRadius = 7;
            this.guna2TileButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton2.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2TileButton2.ForeColor = System.Drawing.Color.White;
            this.guna2TileButton2.Image = global::OrthoGes.Properties.Resources.icons8_search_32;
            this.guna2TileButton2.Location = new System.Drawing.Point(762, 12);
            this.guna2TileButton2.Name = "guna2TileButton2";
            this.guna2TileButton2.Size = new System.Drawing.Size(39, 36);
            this.guna2TileButton2.TabIndex = 26;
            this.guna2TileButton2.Click += new System.EventHandler(this.guna2TileButton2_Click);
            // 
            // lblnmbrEnseignants
            // 
            this.lblnmbrEnseignants.AutoSize = true;
            this.lblnmbrEnseignants.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblnmbrEnseignants.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblnmbrEnseignants.Image = global::OrthoGes.Properties.Resources.icons8_wheelchair_48;
            this.lblnmbrEnseignants.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblnmbrEnseignants.Location = new System.Drawing.Point(8, 10);
            this.lblnmbrEnseignants.Name = "lblnmbrEnseignants";
            this.lblnmbrEnseignants.Size = new System.Drawing.Size(159, 42);
            this.lblnmbrEnseignants.TabIndex = 25;
            this.lblnmbrEnseignants.Text = "    ------       ";
            this.lblnmbrEnseignants.UseCompatibleTextRendering = true;
            // 
            // cmbxRecherche
            // 
            this.cmbxRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxRecherche.BackColor = System.Drawing.Color.Transparent;
            this.cmbxRecherche.BorderColor = System.Drawing.Color.Empty;
            this.cmbxRecherche.BorderRadius = 6;
            this.cmbxRecherche.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxRecherche.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxRecherche.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxRecherche.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbxRecherche.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbxRecherche.ItemHeight = 30;
            this.cmbxRecherche.Items.AddRange(new object[] {
            "Nom et Prénom",
            "Numéro Patient"});
            this.cmbxRecherche.Location = new System.Drawing.Point(942, 12);
            this.cmbxRecherche.Name = "cmbxRecherche";
            this.cmbxRecherche.Size = new System.Drawing.Size(187, 36);
            this.cmbxRecherche.StartIndex = 0;
            this.cmbxRecherche.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Image = global::OrthoGes.Properties.Resources.icons8_filter_24__3_;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(846, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "     Filtre :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(286, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 28);
            this.label4.TabIndex = 23;
            this.label4.Text = "Recherche ";
            // 
            // tbxRecherche
            // 
            this.tbxRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRecherche.BorderColor = System.Drawing.Color.Black;
            this.tbxRecherche.BorderRadius = 5;
            this.tbxRecherche.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxRecherche.DefaultText = "";
            this.tbxRecherche.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxRecherche.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxRecherche.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxRecherche.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxRecherche.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxRecherche.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxRecherche.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxRecherche.Location = new System.Drawing.Point(397, 11);
            this.tbxRecherche.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxRecherche.Name = "tbxRecherche";
            this.tbxRecherche.PlaceholderText = "";
            this.tbxRecherche.SelectedText = "";
            this.tbxRecherche.Size = new System.Drawing.Size(359, 36);
            this.tbxRecherche.TabIndex = 22;
            this.tbxRecherche.Enter += new System.EventHandler(this.tbxRecherche_Enter);
            this.tbxRecherche.Leave += new System.EventHandler(this.tbxRecherche_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(75)))), ((int)(((byte)(94)))));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(12, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 47);
            this.label6.TabIndex = 84;
            this.label6.Text = "Liste des Patients  :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // btnModifier
            // 
            this.btnModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifier.BackColor = System.Drawing.Color.White;
            this.btnModifier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnModifier.ForeColor = System.Drawing.Color.Black;
            this.btnModifier.Image = global::OrthoGes.Properties.Resources.icons8_registration_32;
            this.btnModifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifier.Location = new System.Drawing.Point(1072, 782);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(143, 50);
            this.btnModifier.TabIndex = 37;
            this.btnModifier.Text = "     Modifier";
            this.btnModifier.UseCompatibleTextRendering = true;
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimer.BackColor = System.Drawing.Color.White;
            this.btnSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btnSupprimer.Image = global::OrthoGes.Properties.Resources.icons8_delete_32;
            this.btnSupprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupprimer.Location = new System.Drawing.Point(917, 782);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(143, 50);
            this.btnSupprimer.TabIndex = 36;
            this.btnSupprimer.Text = "     Supprimer";
            this.btnSupprimer.UseCompatibleTextRendering = true;
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.BackColor = System.Drawing.Color.White;
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDetails.ForeColor = System.Drawing.Color.Black;
            this.btnDetails.Image = global::OrthoGes.Properties.Resources.icons8_user_menu_male_32;
            this.btnDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetails.Location = new System.Drawing.Point(1227, 780);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(128, 50);
            this.btnDetails.TabIndex = 35;
            this.btnDetails.Text = "      Détails";
            this.btnDetails.UseCompatibleTextRendering = true;
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnAjouterPatient
            // 
            this.btnAjouterPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjouterPatient.BackColor = System.Drawing.Color.White;
            this.btnAjouterPatient.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnAjouterPatient.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAjouterPatient.ForeColor = System.Drawing.Color.Black;
            this.btnAjouterPatient.Image = global::OrthoGes.Properties.Resources.icons8_add_user_32;
            this.btnAjouterPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjouterPatient.Location = new System.Drawing.Point(1151, 62);
            this.btnAjouterPatient.Name = "btnAjouterPatient";
            this.btnAjouterPatient.Size = new System.Drawing.Size(200, 49);
            this.btnAjouterPatient.TabIndex = 33;
            this.btnAjouterPatient.Text = "      Ajouter un Patient";
            this.btnAjouterPatient.UseCompatibleTextRendering = true;
            this.btnAjouterPatient.UseVisualStyleBackColor = false;
            this.btnAjouterPatient.Click += new System.EventHandler(this.btnAjouterPatient_Click);
            // 
            // btnCreationBonLiv
            // 
            this.btnCreationBonLiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreationBonLiv.BackColor = System.Drawing.Color.White;
            this.btnCreationBonLiv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnCreationBonLiv.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCreationBonLiv.ForeColor = System.Drawing.Color.Black;
            this.btnCreationBonLiv.Image = global::OrthoGes.Properties.Resources.icons8_receipt_48;
            this.btnCreationBonLiv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreationBonLiv.Location = new System.Drawing.Point(309, 782);
            this.btnCreationBonLiv.Name = "btnCreationBonLiv";
            this.btnCreationBonLiv.Size = new System.Drawing.Size(248, 50);
            this.btnCreationBonLiv.TabIndex = 87;
            this.btnCreationBonLiv.Text = "       Créer bon de livraison";
            this.btnCreationBonLiv.UseCompatibleTextRendering = true;
            this.btnCreationBonLiv.UseVisualStyleBackColor = false;
            this.btnCreationBonLiv.Click += new System.EventHandler(this.btnCreationBonLiv_Click);
            // 
            // btnCreationFacture
            // 
            this.btnCreationFacture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreationFacture.BackColor = System.Drawing.Color.White;
            this.btnCreationFacture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnCreationFacture.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCreationFacture.ForeColor = System.Drawing.Color.Black;
            this.btnCreationFacture.Image = global::OrthoGes.Properties.Resources.icons8_create_order_48;
            this.btnCreationFacture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreationFacture.Location = new System.Drawing.Point(569, 782);
            this.btnCreationFacture.Name = "btnCreationFacture";
            this.btnCreationFacture.Size = new System.Drawing.Size(169, 50);
            this.btnCreationFacture.TabIndex = 86;
            this.btnCreationFacture.Text = "        Créer facture";
            this.btnCreationFacture.UseCompatibleTextRendering = true;
            this.btnCreationFacture.UseVisualStyleBackColor = false;
            this.btnCreationFacture.Click += new System.EventHandler(this.btnCreationFacture_Click);
            // 
            // btnCreationDevis
            // 
            this.btnCreationDevis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreationDevis.BackColor = System.Drawing.Color.White;
            this.btnCreationDevis.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnCreationDevis.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCreationDevis.ForeColor = System.Drawing.Color.Black;
            this.btnCreationDevis.Image = global::OrthoGes.Properties.Resources.icons8_new_copy_48__1_;
            this.btnCreationDevis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreationDevis.Location = new System.Drawing.Point(750, 782);
            this.btnCreationDevis.Name = "btnCreationDevis";
            this.btnCreationDevis.Size = new System.Drawing.Size(155, 50);
            this.btnCreationDevis.TabIndex = 85;
            this.btnCreationDevis.Text = "        Créer devis";
            this.btnCreationDevis.UseCompatibleTextRendering = true;
            this.btnCreationDevis.UseVisualStyleBackColor = false;
            this.btnCreationDevis.Click += new System.EventHandler(this.btnCreationDevis_Click);
            // 
            // FormPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1362, 842);
            this.Controls.Add(this.btnCreationBonLiv);
            this.Controls.Add(this.btnCreationFacture);
            this.Controls.Add(this.btnCreationDevis);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvPatientsListe);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnAjouterPatient);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPatients";
            this.Text = "FormPatients";
            this.Load += new System.EventHandler(this.FormPatients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientsListe)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}