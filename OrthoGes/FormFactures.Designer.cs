namespace OrthoGes
{
    partial class FormFactures
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFactures));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblnmbrEleves = new System.Windows.Forms.Label();
            this.guna2TileButton2 = new Guna.UI2.WinForms.Guna2TileButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxfacturesrecherche = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbxRecherche = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvFactureListe = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnAjouteraugroup = new System.Windows.Forms.Button();
            this.cmbxEtat = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxDate = new Guna.UI2.WinForms.Guna2CheckBox();
            this.DateA = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DateDe = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbxMoisAnnée = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxAnnee = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbxMois = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnModifier = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactureListe)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(75)))), ((int)(((byte)(94)))));
            label2.Image = global::OrthoGes.Properties.Resources.icons8_filter_24__3_;
            label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label2.Location = new System.Drawing.Point(2, 78);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(199, 33);
            label2.TabIndex = 64;
            label2.Text = "    Filtre D\'affichage :";
            label2.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.lblnmbrEleves);
            this.panel1.Controls.Add(this.guna2TileButton2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxfacturesrecherche);
            this.panel1.Controls.Add(this.cmbxRecherche);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1483, 55);
            this.panel1.TabIndex = 22;
            // 
            // lblnmbrEleves
            // 
            this.lblnmbrEleves.AutoSize = true;
            this.lblnmbrEleves.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblnmbrEleves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblnmbrEleves.Image = global::OrthoGes.Properties.Resources.icons8_bill_48;
            this.lblnmbrEleves.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblnmbrEleves.Location = new System.Drawing.Point(20, 7);
            this.lblnmbrEleves.Name = "lblnmbrEleves";
            this.lblnmbrEleves.Size = new System.Drawing.Size(159, 42);
            this.lblnmbrEleves.TabIndex = 25;
            this.lblnmbrEleves.Text = "    ------       ";
            this.lblnmbrEleves.UseCompatibleTextRendering = true;
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
            this.guna2TileButton2.Location = new System.Drawing.Point(913, 11);
            this.guna2TileButton2.Name = "guna2TileButton2";
            this.guna2TileButton2.Size = new System.Drawing.Size(39, 36);
            this.guna2TileButton2.TabIndex = 24;
            this.guna2TileButton2.Click += new System.EventHandler(this.guna2TileButton2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(257, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 28);
            this.label4.TabIndex = 23;
            this.label4.Text = "Recherche ";
            // 
            // tbxfacturesrecherche
            // 
            this.tbxfacturesrecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxfacturesrecherche.BorderColor = System.Drawing.Color.Black;
            this.tbxfacturesrecherche.BorderRadius = 5;
            this.tbxfacturesrecherche.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxfacturesrecherche.DefaultText = "";
            this.tbxfacturesrecherche.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxfacturesrecherche.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxfacturesrecherche.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxfacturesrecherche.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxfacturesrecherche.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxfacturesrecherche.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxfacturesrecherche.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxfacturesrecherche.Location = new System.Drawing.Point(368, 12);
            this.tbxfacturesrecherche.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxfacturesrecherche.Name = "tbxfacturesrecherche";
            this.tbxfacturesrecherche.PlaceholderText = "";
            this.tbxfacturesrecherche.SelectedText = "";
            this.tbxfacturesrecherche.Size = new System.Drawing.Size(539, 36);
            this.tbxfacturesrecherche.TabIndex = 22;
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
            "Numéro Facture"});
            this.cmbxRecherche.Location = new System.Drawing.Point(1070, 11);
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
            this.label5.Location = new System.Drawing.Point(974, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "     Filtre :";
            // 
            // dgvFactureListe
            // 
            this.dgvFactureListe.AllowUserToAddRows = false;
            this.dgvFactureListe.AllowUserToDeleteRows = false;
            this.dgvFactureListe.AllowUserToResizeColumns = false;
            this.dgvFactureListe.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvFactureListe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFactureListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFactureListe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFactureListe.ColumnHeadersHeight = 40;
            this.dgvFactureListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvFactureListe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFactureListe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFactureListe.GridColor = System.Drawing.Color.LightGray;
            this.dgvFactureListe.Location = new System.Drawing.Point(16, 132);
            this.dgvFactureListe.Name = "dgvFactureListe";
            this.dgvFactureListe.RowHeadersVisible = false;
            this.dgvFactureListe.RowHeadersWidth = 51;
            this.dgvFactureListe.RowTemplate.Height = 50;
            this.dgvFactureListe.Size = new System.Drawing.Size(1455, 642);
            this.dgvFactureListe.TabIndex = 29;
            this.dgvFactureListe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFactureListe.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvFactureListe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvFactureListe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvFactureListe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvFactureListe.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvFactureListe.ThemeStyle.GridColor = System.Drawing.Color.LightGray;
            this.dgvFactureListe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvFactureListe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFactureListe.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFactureListe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvFactureListe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvFactureListe.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvFactureListe.ThemeStyle.ReadOnly = false;
            this.dgvFactureListe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.dgvFactureListe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFactureListe.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFactureListe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvFactureListe.ThemeStyle.RowsStyle.Height = 50;
            this.dgvFactureListe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.dgvFactureListe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFactureListe.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFactureListe_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FillWeight = 30.65572F;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 10;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimer.BackColor = System.Drawing.Color.White;
            this.btnSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSupprimer.ForeColor = System.Drawing.Color.Black;
            this.btnSupprimer.Image = global::OrthoGes.Properties.Resources.icons8_delete_321;
            this.btnSupprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupprimer.Location = new System.Drawing.Point(1021, 780);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(143, 52);
            this.btnSupprimer.TabIndex = 27;
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
            this.btnDetails.Image = global::OrthoGes.Properties.Resources.icons8_view_details_32;
            this.btnDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetails.Location = new System.Drawing.Point(1348, 778);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(122, 52);
            this.btnDetails.TabIndex = 26;
            this.btnDetails.Text = "     Détails";
            this.btnDetails.UseCompatibleTextRendering = true;
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnAjouteraugroup
            // 
            this.btnAjouteraugroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjouteraugroup.BackColor = System.Drawing.Color.White;
            this.btnAjouteraugroup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnAjouteraugroup.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAjouteraugroup.ForeColor = System.Drawing.Color.Black;
            this.btnAjouteraugroup.Image = global::OrthoGes.Properties.Resources.icons8_print_48;
            this.btnAjouteraugroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjouteraugroup.Location = new System.Drawing.Point(791, 780);
            this.btnAjouteraugroup.Name = "btnAjouteraugroup";
            this.btnAjouteraugroup.Size = new System.Drawing.Size(224, 52);
            this.btnAjouteraugroup.TabIndex = 25;
            this.btnAjouteraugroup.Text = "         Imprimer la Facture";
            this.btnAjouteraugroup.UseCompatibleTextRendering = true;
            this.btnAjouteraugroup.UseVisualStyleBackColor = false;
            // 
            // cmbxEtat
            // 
            this.cmbxEtat.BackColor = System.Drawing.Color.Transparent;
            this.cmbxEtat.BorderColor = System.Drawing.Color.Black;
            this.cmbxEtat.BorderRadius = 6;
            this.cmbxEtat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbxEtat.DisabledState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxEtat.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.cmbxEtat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxEtat.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxEtat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxEtat.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbxEtat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbxEtat.ItemHeight = 30;
            this.cmbxEtat.Items.AddRange(new object[] {
            "tous",
            "Payé avec chèque",
            "Payé sans chèque",
            "Pas payé avec chèque",
            "Pas payé sans chèque"});
            this.cmbxEtat.Location = new System.Drawing.Point(934, 75);
            this.cmbxEtat.Name = "cmbxEtat";
            this.cmbxEtat.Size = new System.Drawing.Size(236, 36);
            this.cmbxEtat.TabIndex = 74;
            this.cmbxEtat.SelectedIndexChanged += new System.EventHandler(this.cmbxEtat_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(873, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 28);
            this.label6.TabIndex = 73;
            this.label6.Text = "etat :";
            // 
            // cbxDate
            // 
            this.cbxDate.AutoSize = true;
            this.cbxDate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxDate.CheckedState.BorderRadius = 0;
            this.cbxDate.CheckedState.BorderThickness = 0;
            this.cbxDate.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxDate.Location = new System.Drawing.Point(836, 87);
            this.cbxDate.Name = "cbxDate";
            this.cbxDate.Size = new System.Drawing.Size(32, 20);
            this.cbxDate.TabIndex = 72;
            this.cbxDate.Text = " ";
            this.cbxDate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbxDate.UncheckedState.BorderRadius = 0;
            this.cbxDate.UncheckedState.BorderThickness = 0;
            this.cbxDate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbxDate.CheckedChanged += new System.EventHandler(this.cbxDate_CheckedChanged);
            // 
            // DateA
            // 
            this.DateA.BackColor = System.Drawing.Color.White;
            this.DateA.BorderRadius = 7;
            this.DateA.Checked = true;
            this.DateA.Enabled = false;
            this.DateA.FillColor = System.Drawing.Color.White;
            this.DateA.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateA.ForeColor = System.Drawing.Color.Black;
            this.DateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateA.Location = new System.Drawing.Point(695, 75);
            this.DateA.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateA.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateA.Name = "DateA";
            this.DateA.Size = new System.Drawing.Size(131, 36);
            this.DateA.TabIndex = 71;
            this.DateA.Value = new System.DateTime(2025, 12, 25, 11, 13, 27, 636);
            this.DateA.ValueChanged += new System.EventHandler(this.DateA_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(672, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 28);
            this.label3.TabIndex = 70;
            this.label3.Text = "à";
            // 
            // DateDe
            // 
            this.DateDe.BackColor = System.Drawing.Color.White;
            this.DateDe.BorderRadius = 7;
            this.DateDe.Checked = true;
            this.DateDe.Enabled = false;
            this.DateDe.FillColor = System.Drawing.Color.White;
            this.DateDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateDe.ForeColor = System.Drawing.Color.Black;
            this.DateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateDe.Location = new System.Drawing.Point(537, 75);
            this.DateDe.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateDe.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateDe.Name = "DateDe";
            this.DateDe.Size = new System.Drawing.Size(132, 36);
            this.DateDe.TabIndex = 69;
            this.DateDe.Value = new System.DateTime(2025, 12, 25, 11, 23, 5, 953);
            this.DateDe.ValueChanged += new System.EventHandler(this.DateDe_ValueChanged);
            // 
            // cbxMoisAnnée
            // 
            this.cbxMoisAnnée.AutoSize = true;
            this.cbxMoisAnnée.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxMoisAnnée.CheckedState.BorderRadius = 0;
            this.cbxMoisAnnée.CheckedState.BorderThickness = 0;
            this.cbxMoisAnnée.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxMoisAnnée.Location = new System.Drawing.Point(468, 88);
            this.cbxMoisAnnée.Name = "cbxMoisAnnée";
            this.cbxMoisAnnée.Size = new System.Drawing.Size(32, 20);
            this.cbxMoisAnnée.TabIndex = 68;
            this.cbxMoisAnnée.Text = " ";
            this.cbxMoisAnnée.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbxMoisAnnée.UncheckedState.BorderRadius = 0;
            this.cbxMoisAnnée.UncheckedState.BorderThickness = 0;
            this.cbxMoisAnnée.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbxMoisAnnée.CheckedChanged += new System.EventHandler(this.guna2CheckBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(501, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 28);
            this.label1.TabIndex = 67;
            this.label1.Text = "De";
            // 
            // cmbxAnnee
            // 
            this.cmbxAnnee.BackColor = System.Drawing.Color.Transparent;
            this.cmbxAnnee.BorderColor = System.Drawing.Color.Black;
            this.cmbxAnnee.BorderRadius = 6;
            this.cmbxAnnee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbxAnnee.DisabledState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxAnnee.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.cmbxAnnee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxAnnee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAnnee.Enabled = false;
            this.cmbxAnnee.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxAnnee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxAnnee.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbxAnnee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbxAnnee.ItemHeight = 30;
            this.cmbxAnnee.Items.AddRange(new object[] {
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035"});
            this.cmbxAnnee.Location = new System.Drawing.Point(346, 76);
            this.cmbxAnnee.Name = "cmbxAnnee";
            this.cmbxAnnee.Size = new System.Drawing.Size(116, 36);
            this.cmbxAnnee.TabIndex = 66;
            this.cmbxAnnee.SelectedIndexChanged += new System.EventHandler(this.cmbxAnnee_SelectedIndexChanged);
            // 
            // cmbxMois
            // 
            this.cmbxMois.BackColor = System.Drawing.Color.Transparent;
            this.cmbxMois.BorderColor = System.Drawing.Color.Empty;
            this.cmbxMois.BorderRadius = 6;
            this.cmbxMois.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxMois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxMois.Enabled = false;
            this.cmbxMois.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxMois.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxMois.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbxMois.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbxMois.ItemHeight = 30;
            this.cmbxMois.Items.AddRange(new object[] {
            "Janvier",
            "Février",
            "Mars",
            "Avril",
            "Mai",
            "Juin",
            "Juillet",
            "Août",
            "Septembre",
            "Octobre",
            "Novembre",
            "Décembre"});
            this.cmbxMois.Location = new System.Drawing.Point(204, 76);
            this.cmbxMois.Name = "cmbxMois";
            this.cmbxMois.Size = new System.Drawing.Size(132, 36);
            this.cmbxMois.StartIndex = 0;
            this.cmbxMois.TabIndex = 65;
            this.cmbxMois.SelectedIndexChanged += new System.EventHandler(this.cmbxMois_SelectedIndexChanged);
            // 
            // btnModifier
            // 
            this.btnModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifier.BackColor = System.Drawing.Color.White;
            this.btnModifier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnModifier.ForeColor = System.Drawing.Color.Black;
            this.btnModifier.Image = global::OrthoGes.Properties.Resources.icons8_user_menu_male_321;
            this.btnModifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifier.Location = new System.Drawing.Point(1170, 780);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(172, 52);
            this.btnModifier.TabIndex = 75;
            this.btnModifier.Text = "     Patient details";
            this.btnModifier.UseCompatibleTextRendering = true;
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // FormFactures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1483, 842);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.cmbxEtat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxDate);
            this.Controls.Add(this.DateA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateDe);
            this.Controls.Add(this.cbxMoisAnnée);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxAnnee);
            this.Controls.Add(this.cmbxMois);
            this.Controls.Add(label2);
            this.Controls.Add(this.dgvFactureListe);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnAjouteraugroup);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFactures";
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.FormFactures_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactureListe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblnmbrEleves;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox tbxfacturesrecherche;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxRecherche;
        private System.Windows.Forms.Button btnAjouteraugroup;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnSupprimer;
        private Guna.UI2.WinForms.Guna2DataGridView dgvFactureListe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxEtat;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2CheckBox cbxDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateA;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateDe;
        private Guna.UI2.WinForms.Guna2CheckBox cbxMoisAnnée;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxAnnee;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxMois;
        private System.Windows.Forms.Button btnModifier;
    }
}