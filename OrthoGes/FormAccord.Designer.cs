namespace OrthoGes
{
    partial class FormAccord
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
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccord));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxelevesrecherche = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbxRecherche = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvElevesListe = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2CheckBox2 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2DateTimePicker2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxFiliere = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbxNiveau = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnAjouteraugroup = new System.Windows.Forms.Button();
            this.btnAjouterEleve = new System.Windows.Forms.Button();
            this.lblnmbrEleves = new System.Windows.Forms.Label();
            this.guna2TileButton2 = new Guna.UI2.WinForms.Guna2TileButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElevesListe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.lblnmbrEleves);
            this.panel1.Controls.Add(this.guna2TileButton2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxelevesrecherche);
            this.panel1.Controls.Add(this.cmbxRecherche);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 55);
            this.panel1.TabIndex = 22;
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
            // tbxelevesrecherche
            // 
            this.tbxelevesrecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxelevesrecherche.BorderColor = System.Drawing.Color.Black;
            this.tbxelevesrecherche.BorderRadius = 5;
            this.tbxelevesrecherche.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxelevesrecherche.DefaultText = "";
            this.tbxelevesrecherche.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxelevesrecherche.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxelevesrecherche.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxelevesrecherche.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxelevesrecherche.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxelevesrecherche.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxelevesrecherche.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxelevesrecherche.Location = new System.Drawing.Point(368, 12);
            this.tbxelevesrecherche.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxelevesrecherche.Name = "tbxelevesrecherche";
            this.tbxelevesrecherche.PlaceholderText = "";
            this.tbxelevesrecherche.SelectedText = "";
            this.tbxelevesrecherche.Size = new System.Drawing.Size(418, 36);
            this.tbxelevesrecherche.TabIndex = 22;
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
            this.cmbxRecherche.Location = new System.Drawing.Point(949, 11);
            this.cmbxRecherche.Name = "cmbxRecherche";
            this.cmbxRecherche.Size = new System.Drawing.Size(187, 36);
            this.cmbxRecherche.StartIndex = 0;
            this.cmbxRecherche.TabIndex = 20;
            // 
            // dgvElevesListe
            // 
            this.dgvElevesListe.AllowUserToAddRows = false;
            this.dgvElevesListe.AllowUserToDeleteRows = false;
            this.dgvElevesListe.AllowUserToResizeColumns = false;
            this.dgvElevesListe.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvElevesListe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvElevesListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvElevesListe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvElevesListe.ColumnHeadersHeight = 40;
            this.dgvElevesListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvElevesListe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvElevesListe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvElevesListe.GridColor = System.Drawing.Color.LightGray;
            this.dgvElevesListe.Location = new System.Drawing.Point(16, 122);
            this.dgvElevesListe.Name = "dgvElevesListe";
            this.dgvElevesListe.ReadOnly = true;
            this.dgvElevesListe.RowHeadersVisible = false;
            this.dgvElevesListe.RowHeadersWidth = 51;
            this.dgvElevesListe.RowTemplate.Height = 50;
            this.dgvElevesListe.Size = new System.Drawing.Size(1334, 652);
            this.dgvElevesListe.TabIndex = 29;
            this.dgvElevesListe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvElevesListe.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvElevesListe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvElevesListe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvElevesListe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvElevesListe.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvElevesListe.ThemeStyle.GridColor = System.Drawing.Color.LightGray;
            this.dgvElevesListe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvElevesListe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvElevesListe.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvElevesListe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvElevesListe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvElevesListe.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvElevesListe.ThemeStyle.ReadOnly = true;
            this.dgvElevesListe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.dgvElevesListe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvElevesListe.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvElevesListe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvElevesListe.ThemeStyle.RowsStyle.Height = 50;
            this.dgvElevesListe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.dgvElevesListe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FillWeight = 30.65572F;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 10;
            // 
            // guna2CheckBox2
            // 
            this.guna2CheckBox2.AutoSize = true;
            this.guna2CheckBox2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox2.CheckedState.BorderRadius = 0;
            this.guna2CheckBox2.CheckedState.BorderThickness = 0;
            this.guna2CheckBox2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox2.Location = new System.Drawing.Point(836, 87);
            this.guna2CheckBox2.Name = "guna2CheckBox2";
            this.guna2CheckBox2.Size = new System.Drawing.Size(32, 20);
            this.guna2CheckBox2.TabIndex = 61;
            this.guna2CheckBox2.Text = " ";
            this.guna2CheckBox2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox2.UncheckedState.BorderRadius = 0;
            this.guna2CheckBox2.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox2.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // guna2DateTimePicker2
            // 
            this.guna2DateTimePicker2.BackColor = System.Drawing.Color.White;
            this.guna2DateTimePicker2.BorderRadius = 7;
            this.guna2DateTimePicker2.Checked = true;
            this.guna2DateTimePicker2.FillColor = System.Drawing.Color.White;
            this.guna2DateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker2.ForeColor = System.Drawing.Color.Black;
            this.guna2DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.guna2DateTimePicker2.Location = new System.Drawing.Point(695, 75);
            this.guna2DateTimePicker2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker2.Name = "guna2DateTimePicker2";
            this.guna2DateTimePicker2.Size = new System.Drawing.Size(131, 36);
            this.guna2DateTimePicker2.TabIndex = 60;
            this.guna2DateTimePicker2.Value = new System.DateTime(2025, 12, 25, 11, 13, 27, 636);
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
            this.label3.TabIndex = 59;
            this.label3.Text = "à";
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.BackColor = System.Drawing.Color.White;
            this.guna2DateTimePicker1.BorderRadius = 7;
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.White;
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.ForeColor = System.Drawing.Color.Black;
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(537, 75);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(132, 36);
            this.guna2DateTimePicker1.TabIndex = 58;
            this.guna2DateTimePicker1.Value = new System.DateTime(2025, 12, 25, 11, 23, 5, 953);
            // 
            // guna2CheckBox1
            // 
            this.guna2CheckBox1.AutoSize = true;
            this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.CheckedState.BorderRadius = 0;
            this.guna2CheckBox1.CheckedState.BorderThickness = 0;
            this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.Location = new System.Drawing.Point(468, 88);
            this.guna2CheckBox1.Name = "guna2CheckBox1";
            this.guna2CheckBox1.Size = new System.Drawing.Size(32, 20);
            this.guna2CheckBox1.TabIndex = 57;
            this.guna2CheckBox1.Text = " ";
            this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox1.UncheckedState.BorderRadius = 0;
            this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
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
            this.label1.TabIndex = 56;
            this.label1.Text = "De";
            // 
            // cmbxFiliere
            // 
            this.cmbxFiliere.BackColor = System.Drawing.Color.Transparent;
            this.cmbxFiliere.BorderColor = System.Drawing.Color.Black;
            this.cmbxFiliere.BorderRadius = 6;
            this.cmbxFiliere.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbxFiliere.DisabledState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxFiliere.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.cmbxFiliere.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxFiliere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFiliere.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxFiliere.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxFiliere.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbxFiliere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbxFiliere.ItemHeight = 30;
            this.cmbxFiliere.Items.AddRange(new object[] {
            "2025",
            "2026"});
            this.cmbxFiliere.Location = new System.Drawing.Point(346, 76);
            this.cmbxFiliere.Name = "cmbxFiliere";
            this.cmbxFiliere.Size = new System.Drawing.Size(116, 36);
            this.cmbxFiliere.TabIndex = 55;
            // 
            // cmbxNiveau
            // 
            this.cmbxNiveau.BackColor = System.Drawing.Color.Transparent;
            this.cmbxNiveau.BorderColor = System.Drawing.Color.Empty;
            this.cmbxNiveau.BorderRadius = 6;
            this.cmbxNiveau.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxNiveau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxNiveau.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxNiveau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxNiveau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbxNiveau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbxNiveau.ItemHeight = 30;
            this.cmbxNiveau.Items.AddRange(new object[] {
            "Janvier"});
            this.cmbxNiveau.Location = new System.Drawing.Point(204, 76);
            this.cmbxNiveau.Name = "cmbxNiveau";
            this.cmbxNiveau.Size = new System.Drawing.Size(132, 36);
            this.cmbxNiveau.StartIndex = 0;
            this.cmbxNiveau.TabIndex = 54;
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
            label2.TabIndex = 53;
            label2.Text = "    Filtre D\'affichage :";
            label2.UseCompatibleTextRendering = true;
            // 
            // btnModifier
            // 
            this.btnModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifier.BackColor = System.Drawing.Color.White;
            this.btnModifier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnModifier.ForeColor = System.Drawing.Color.Black;
            this.btnModifier.Image = global::OrthoGes.Properties.Resources.icons8_edit_property_32;
            this.btnModifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifier.Location = new System.Drawing.Point(1078, 780);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(135, 52);
            this.btnModifier.TabIndex = 28;
            this.btnModifier.Text = "     Modifier";
            this.btnModifier.UseCompatibleTextRendering = true;
            this.btnModifier.UseVisualStyleBackColor = false;
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
            this.btnSupprimer.Location = new System.Drawing.Point(921, 780);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(143, 52);
            this.btnSupprimer.TabIndex = 27;
            this.btnSupprimer.Text = "     Supprimer";
            this.btnSupprimer.UseCompatibleTextRendering = true;
            this.btnSupprimer.UseVisualStyleBackColor = false;
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
            this.btnDetails.Location = new System.Drawing.Point(1227, 778);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(122, 52);
            this.btnDetails.TabIndex = 26;
            this.btnDetails.Text = "     Détails";
            this.btnDetails.UseCompatibleTextRendering = true;
            this.btnDetails.UseVisualStyleBackColor = false;
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
            this.btnAjouteraugroup.Location = new System.Drawing.Point(683, 780);
            this.btnAjouteraugroup.Name = "btnAjouteraugroup";
            this.btnAjouteraugroup.Size = new System.Drawing.Size(224, 52);
            this.btnAjouteraugroup.TabIndex = 25;
            this.btnAjouteraugroup.Text = "         Imprimer";
            this.btnAjouteraugroup.UseCompatibleTextRendering = true;
            this.btnAjouteraugroup.UseVisualStyleBackColor = false;
            // 
            // btnAjouterEleve
            // 
            this.btnAjouterEleve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjouterEleve.BackColor = System.Drawing.Color.White;
            this.btnAjouterEleve.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.btnAjouterEleve.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAjouterEleve.ForeColor = System.Drawing.Color.Black;
            this.btnAjouterEleve.Image = global::OrthoGes.Properties.Resources.icons8_new_copy_48;
            this.btnAjouterEleve.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAjouterEleve.Location = new System.Drawing.Point(1136, 63);
            this.btnAjouterEleve.Name = "btnAjouterEleve";
            this.btnAjouterEleve.Size = new System.Drawing.Size(213, 53);
            this.btnAjouterEleve.TabIndex = 24;
            this.btnAjouterEleve.Text = "     Ajouter un Accord ";
            this.btnAjouterEleve.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAjouterEleve.UseCompatibleTextRendering = true;
            this.btnAjouterEleve.UseVisualStyleBackColor = false;
            // 
            // lblnmbrEleves
            // 
            this.lblnmbrEleves.AutoSize = true;
            this.lblnmbrEleves.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblnmbrEleves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblnmbrEleves.Image = global::OrthoGes.Properties.Resources.icons8_signing_a_document_48;
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
            this.guna2TileButton2.Location = new System.Drawing.Point(792, 11);
            this.guna2TileButton2.Name = "guna2TileButton2";
            this.guna2TileButton2.Size = new System.Drawing.Size(39, 36);
            this.guna2TileButton2.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Image = global::OrthoGes.Properties.Resources.icons8_filter_24__3_;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(853, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "     Filtre :";
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
            this.label6.TabIndex = 62;
            this.label6.Text = "etat :";
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderColor = System.Drawing.Color.Black;
            this.guna2ComboBox1.BorderRadius = 6;
            this.guna2ComboBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2ComboBox1.DisabledState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ComboBox1.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Items.AddRange(new object[] {
            "En attente",
            "Semi fini",
            "Prêt"});
            this.guna2ComboBox1.Location = new System.Drawing.Point(934, 75);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(116, 36);
            this.guna2ComboBox1.TabIndex = 63;
            // 
            // FormAccord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1362, 842);
            this.Controls.Add(this.guna2ComboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.guna2CheckBox2);
            this.Controls.Add(this.guna2DateTimePicker2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.guna2CheckBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxFiliere);
            this.Controls.Add(this.cmbxNiveau);
            this.Controls.Add(label2);
            this.Controls.Add(this.dgvElevesListe);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnAjouteraugroup);
            this.Controls.Add(this.btnAjouterEleve);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAccord";
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.FormFactures_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElevesListe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblnmbrEleves;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox tbxelevesrecherche;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxRecherche;
        private System.Windows.Forms.Button btnAjouterEleve;
        private System.Windows.Forms.Button btnAjouteraugroup;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private Guna.UI2.WinForms.Guna2DataGridView dgvElevesListe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox2;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxFiliere;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxNiveau;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
    }
}