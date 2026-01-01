namespace OrthoGes
{
    partial class FormProduits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProduits));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblnmbrEleves = new System.Windows.Forms.Label();
            this.guna2TileButton2 = new Guna.UI2.WinForms.Guna2TileButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxProduitrecherche = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbxRecherche = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvProduitsListe = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbxCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduitsListe)).BeginInit();
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
            label2.Location = new System.Drawing.Point(8, 82);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(199, 33);
            label2.TabIndex = 53;
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
            this.panel1.Controls.Add(this.tbxProduitrecherche);
            this.panel1.Controls.Add(this.cmbxRecherche);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 55);
            this.panel1.TabIndex = 22;
            // 
            // lblnmbrEleves
            // 
            this.lblnmbrEleves.AutoSize = true;
            this.lblnmbrEleves.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblnmbrEleves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblnmbrEleves.Image = global::OrthoGes.Properties.Resources.icons8_electric_wheelchair_48;
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
            // tbxProduitrecherche
            // 
            this.tbxProduitrecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxProduitrecherche.BorderColor = System.Drawing.Color.Black;
            this.tbxProduitrecherche.BorderRadius = 5;
            this.tbxProduitrecherche.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxProduitrecherche.DefaultText = "";
            this.tbxProduitrecherche.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxProduitrecherche.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxProduitrecherche.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxProduitrecherche.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxProduitrecherche.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxProduitrecherche.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxProduitrecherche.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxProduitrecherche.Location = new System.Drawing.Point(368, 12);
            this.tbxProduitrecherche.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxProduitrecherche.Name = "tbxProduitrecherche";
            this.tbxProduitrecherche.PlaceholderText = "";
            this.tbxProduitrecherche.SelectedText = "";
            this.tbxProduitrecherche.Size = new System.Drawing.Size(418, 36);
            this.tbxProduitrecherche.TabIndex = 22;
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
            "Référence",
            "Désignation"});
            this.cmbxRecherche.Location = new System.Drawing.Point(949, 11);
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
            this.label5.Location = new System.Drawing.Point(853, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "     Filtre :";
            // 
            // dgvProduitsListe
            // 
            this.dgvProduitsListe.AllowUserToAddRows = false;
            this.dgvProduitsListe.AllowUserToDeleteRows = false;
            this.dgvProduitsListe.AllowUserToResizeColumns = false;
            this.dgvProduitsListe.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvProduitsListe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduitsListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduitsListe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduitsListe.ColumnHeadersHeight = 40;
            this.dgvProduitsListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvProduitsListe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduitsListe.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProduitsListe.GridColor = System.Drawing.Color.LightGray;
            this.dgvProduitsListe.Location = new System.Drawing.Point(16, 122);
            this.dgvProduitsListe.Name = "dgvProduitsListe";
            this.dgvProduitsListe.ReadOnly = true;
            this.dgvProduitsListe.RowHeadersVisible = false;
            this.dgvProduitsListe.RowHeadersWidth = 51;
            this.dgvProduitsListe.RowTemplate.Height = 50;
            this.dgvProduitsListe.Size = new System.Drawing.Size(1334, 697);
            this.dgvProduitsListe.TabIndex = 29;
            this.dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvProduitsListe.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduitsListe.ThemeStyle.GridColor = System.Drawing.Color.LightGray;
            this.dgvProduitsListe.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvProduitsListe.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProduitsListe.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProduitsListe.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvProduitsListe.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvProduitsListe.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvProduitsListe.ThemeStyle.ReadOnly = true;
            this.dgvProduitsListe.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.dgvProduitsListe.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProduitsListe.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProduitsListe.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvProduitsListe.ThemeStyle.RowsStyle.Height = 50;
            this.dgvProduitsListe.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.dgvProduitsListe.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
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
            // cmbxCategory
            // 
            this.cmbxCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbxCategory.BorderColor = System.Drawing.Color.Empty;
            this.cmbxCategory.BorderRadius = 6;
            this.cmbxCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbxCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbxCategory.ItemHeight = 30;
            this.cmbxCategory.Items.AddRange(new object[] {
            "Category"});
            this.cmbxCategory.Location = new System.Drawing.Point(218, 80);
            this.cmbxCategory.Name = "cmbxCategory";
            this.cmbxCategory.Size = new System.Drawing.Size(476, 36);
            this.cmbxCategory.TabIndex = 54;
            this.cmbxCategory.SelectedIndexChanged += new System.EventHandler(this.cmbxCategory_SelectedIndexChanged);
            // 
            // FormProduits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1362, 842);
            this.Controls.Add(this.cmbxCategory);
            this.Controls.Add(label2);
            this.Controls.Add(this.dgvProduitsListe);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProduits";
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.FormFactures_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduitsListe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblnmbrEleves;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox tbxProduitrecherche;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxRecherche;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProduitsListe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxCategory;
    }
}