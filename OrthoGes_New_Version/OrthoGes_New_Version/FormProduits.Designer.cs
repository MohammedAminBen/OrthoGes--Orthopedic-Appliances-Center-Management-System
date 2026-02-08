namespace OrthoGes_New_Version
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
            Label label2;
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProduits));
            panel1 = new Panel();
            lblnmbrEleves = new Label();
            guna2TileButton2 = new Guna.UI2.WinForms.Guna2TileButton();
            label4 = new Label();
            tbxProduitrecherche = new Guna.UI2.WinForms.Guna2TextBox();
            cmbxRecherche = new Guna.UI2.WinForms.Guna2ComboBox();
            label5 = new Label();
            dgvProduitsListe = new Guna.UI2.WinForms.Guna2DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            cmbxCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            btnAjouterProduit = new Button();
            btnModifier = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduitsListe).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(60, 75, 94);
            label2.Image = Properties.Resources.icons8_filter_24__3_;
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(8, 82);
            label2.Name = "label2";
            label2.Size = new Size(199, 33);
            label2.TabIndex = 53;
            label2.Text = "    Filtre D'affichage :";
            label2.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(lblnmbrEleves);
            panel1.Controls.Add(guna2TileButton2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(tbxProduitrecherche);
            panel1.Controls.Add(cmbxRecherche);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1362, 55);
            panel1.TabIndex = 22;
            // 
            // lblnmbrEleves
            // 
            lblnmbrEleves.AutoSize = true;
            lblnmbrEleves.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblnmbrEleves.ForeColor = Color.FromArgb(51, 102, 204);
            lblnmbrEleves.Image = Properties.Resources.icons8_electric_wheelchair_48;
            lblnmbrEleves.ImageAlign = ContentAlignment.MiddleRight;
            lblnmbrEleves.Location = new Point(20, 7);
            lblnmbrEleves.Name = "lblnmbrEleves";
            lblnmbrEleves.Size = new Size(159, 42);
            lblnmbrEleves.TabIndex = 25;
            lblnmbrEleves.Text = "    ------       ";
            lblnmbrEleves.UseCompatibleTextRendering = true;
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
            guna2TileButton2.Location = new Point(792, 11);
            guna2TileButton2.Name = "guna2TileButton2";
            guna2TileButton2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TileButton2.Size = new Size(39, 36);
            guna2TileButton2.TabIndex = 24;
            guna2TileButton2.Click += guna2TileButton2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.Black;
            label4.ImageAlign = ContentAlignment.MiddleLeft;
            label4.Location = new Point(257, 11);
            label4.Name = "label4";
            label4.Size = new Size(105, 28);
            label4.TabIndex = 23;
            label4.Text = "Recherche ";
            // 
            // tbxProduitrecherche
            // 
            tbxProduitrecherche.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbxProduitrecherche.BorderColor = Color.Black;
            tbxProduitrecherche.BorderRadius = 5;
            tbxProduitrecherche.Cursor = Cursors.IBeam;
            tbxProduitrecherche.CustomizableEdges = customizableEdges3;
            tbxProduitrecherche.DefaultText = "";
            tbxProduitrecherche.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbxProduitrecherche.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbxProduitrecherche.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbxProduitrecherche.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbxProduitrecherche.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxProduitrecherche.Font = new Font("Segoe UI", 10F);
            tbxProduitrecherche.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbxProduitrecherche.Location = new Point(368, 12);
            tbxProduitrecherche.Margin = new Padding(3, 4, 3, 4);
            tbxProduitrecherche.Name = "tbxProduitrecherche";
            tbxProduitrecherche.PlaceholderText = "";
            tbxProduitrecherche.SelectedText = "";
            tbxProduitrecherche.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbxProduitrecherche.Size = new Size(418, 36);
            tbxProduitrecherche.TabIndex = 22;
            tbxProduitrecherche.TextChanged += tbxProduitrecherche_TextChanged;
            tbxProduitrecherche.KeyDown += tbxProduitrecherche_KeyDown;
            // 
            // cmbxRecherche
            // 
            cmbxRecherche.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbxRecherche.BackColor = Color.Transparent;
            cmbxRecherche.BorderColor = Color.Empty;
            cmbxRecherche.BorderRadius = 6;
            cmbxRecherche.CustomizableEdges = customizableEdges5;
            cmbxRecherche.DrawMode = DrawMode.OwnerDrawFixed;
            cmbxRecherche.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxRecherche.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbxRecherche.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbxRecherche.Font = new Font("Segoe UI", 10F);
            cmbxRecherche.ForeColor = Color.FromArgb(68, 88, 112);
            cmbxRecherche.ItemHeight = 30;
            cmbxRecherche.Items.AddRange(new object[] { "Référence", "Désignation" });
            cmbxRecherche.Location = new Point(949, 11);
            cmbxRecherche.Name = "cmbxRecherche";
            cmbxRecherche.ShadowDecoration.CustomizableEdges = customizableEdges6;
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
            label5.Location = new Point(853, 13);
            label5.Name = "label5";
            label5.Size = new Size(90, 28);
            label5.TabIndex = 21;
            label5.Text = "     Filtre :";
            // 
            // dgvProduitsListe
            // 
            dgvProduitsListe.AllowUserToAddRows = false;
            dgvProduitsListe.AllowUserToDeleteRows = false;
            dgvProduitsListe.AllowUserToResizeColumns = false;
            dgvProduitsListe.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvProduitsListe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProduitsListe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.GhostWhite;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.GhostWhite;
            dataGridViewCellStyle2.SelectionForeColor = Color.DimGray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProduitsListe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProduitsListe.ColumnHeadersHeight = 40;
            dgvProduitsListe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProduitsListe.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProduitsListe.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProduitsListe.GridColor = Color.LightGray;
            dgvProduitsListe.Location = new Point(16, 122);
            dgvProduitsListe.Name = "dgvProduitsListe";
            dgvProduitsListe.ReadOnly = true;
            dgvProduitsListe.RowHeadersVisible = false;
            dgvProduitsListe.RowHeadersWidth = 51;
            dgvProduitsListe.RowTemplate.Height = 50;
            dgvProduitsListe.Size = new Size(1334, 697);
            dgvProduitsListe.TabIndex = 29;
            dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvProduitsListe.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvProduitsListe.ThemeStyle.BackColor = Color.White;
            dgvProduitsListe.ThemeStyle.GridColor = Color.LightGray;
            dgvProduitsListe.ThemeStyle.HeaderStyle.BackColor = Color.White;
            dgvProduitsListe.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProduitsListe.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgvProduitsListe.ThemeStyle.HeaderStyle.ForeColor = Color.DimGray;
            dgvProduitsListe.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProduitsListe.ThemeStyle.HeaderStyle.Height = 40;
            dgvProduitsListe.ThemeStyle.ReadOnly = true;
            dgvProduitsListe.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(240, 244, 248);
            dgvProduitsListe.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProduitsListe.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvProduitsListe.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvProduitsListe.ThemeStyle.RowsStyle.Height = 50;
            dgvProduitsListe.ThemeStyle.RowsStyle.SelectionBackColor = Color.LightGray;
            dgvProduitsListe.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column1.FillWeight = 30.65572F;
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 10;
            // 
            // cmbxCategory
            // 
            cmbxCategory.BackColor = Color.Transparent;
            cmbxCategory.BorderColor = Color.Empty;
            cmbxCategory.BorderRadius = 6;
            cmbxCategory.CustomizableEdges = customizableEdges7;
            cmbxCategory.DrawMode = DrawMode.OwnerDrawFixed;
            cmbxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxCategory.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbxCategory.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbxCategory.Font = new Font("Segoe UI", 10F);
            cmbxCategory.ForeColor = Color.FromArgb(68, 88, 112);
            cmbxCategory.ItemHeight = 30;
            cmbxCategory.Items.AddRange(new object[] { "Category" });
            cmbxCategory.Location = new Point(218, 80);
            cmbxCategory.Name = "cmbxCategory";
            cmbxCategory.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cmbxCategory.Size = new Size(476, 36);
            cmbxCategory.TabIndex = 54;
            cmbxCategory.SelectedIndexChanged += cmbxCategory_SelectedIndexChanged;
            // 
            // btnAjouterProduit
            // 
            btnAjouterProduit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAjouterProduit.BackColor = Color.White;
            btnAjouterProduit.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnAjouterProduit.Font = new Font("Segoe UI", 11F);
            btnAjouterProduit.ForeColor = Color.Black;
            btnAjouterProduit.ImageAlign = ContentAlignment.MiddleLeft;
            btnAjouterProduit.Location = new Point(1170, 67);
            btnAjouterProduit.Name = "btnAjouterProduit";
            btnAjouterProduit.Size = new Size(180, 49);
            btnAjouterProduit.TabIndex = 55;
            btnAjouterProduit.Text = "Ajouter un produit";
            btnAjouterProduit.UseCompatibleTextRendering = true;
            btnAjouterProduit.UseVisualStyleBackColor = false;
            btnAjouterProduit.Click += btnAjouterProduit_Click;
            // 
            // btnModifier
            // 
            btnModifier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModifier.BackColor = Color.White;
            btnModifier.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            btnModifier.Font = new Font("Segoe UI", 11F);
            btnModifier.ForeColor = Color.Black;
            btnModifier.ImageAlign = ContentAlignment.MiddleLeft;
            btnModifier.Location = new Point(974, 67);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(180, 49);
            btnModifier.TabIndex = 56;
            btnModifier.Text = "Modifier produit";
            btnModifier.UseCompatibleTextRendering = true;
            btnModifier.UseVisualStyleBackColor = false;
            btnModifier.Click += btnModifier_Click;
            // 
            // FormProduits
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(1362, 842);
            Controls.Add(btnModifier);
            Controls.Add(btnAjouterProduit);
            Controls.Add(cmbxCategory);
            Controls.Add(label2);
            Controls.Add(dgvProduitsListe);
            Controls.Add(panel1);
            ForeColor = Color.CornflowerBlue;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormProduits";
            ShowInTaskbar = false;
            Text = "Form2";
            TransparencyKey = Color.WhiteSmoke;
            Load += FormFactures_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduitsListe).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private Button btnAjouterProduit;
        private Button btnModifier;
    }
}