namespace OrthoGes_New_Version
{
    partial class FormUtilisateursActivitésHistorique
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUtilisateursActivitésHistorique));
            dgvHistorique = new Guna.UI2.WinForms.Guna2DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            label18 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistorique).BeginInit();
            SuspendLayout();
            // 
            // dgvHistorique
            // 
            dgvHistorique.AllowUserToAddRows = false;
            dgvHistorique.AllowUserToDeleteRows = false;
            dgvHistorique.AllowUserToResizeColumns = false;
            dgvHistorique.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvHistorique.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistorique.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(230, 230, 245);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(230, 230, 245);
            dataGridViewCellStyle2.SelectionForeColor = Color.DimGray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvHistorique.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHistorique.ColumnHeadersHeight = 40;
            dgvHistorique.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvHistorique.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHistorique.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHistorique.GridColor = Color.GhostWhite;
            dgvHistorique.Location = new Point(5, 46);
            dgvHistorique.Margin = new Padding(2);
            dgvHistorique.Name = "dgvHistorique";
            dgvHistorique.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(23, 24, 29);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvHistorique.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvHistorique.RowHeadersVisible = false;
            dgvHistorique.RowHeadersWidth = 51;
            dgvHistorique.RowTemplate.DividerHeight = 5;
            dgvHistorique.RowTemplate.Height = 40;
            dgvHistorique.Size = new Size(1343, 640);
            dgvHistorique.TabIndex = 45;
            dgvHistorique.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvHistorique.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvHistorique.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Black;
            dgvHistorique.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvHistorique.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvHistorique.ThemeStyle.BackColor = Color.White;
            dgvHistorique.ThemeStyle.GridColor = Color.GhostWhite;
            dgvHistorique.ThemeStyle.HeaderStyle.BackColor = Color.Silver;
            dgvHistorique.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistorique.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvHistorique.ThemeStyle.HeaderStyle.ForeColor = Color.Black;
            dgvHistorique.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvHistorique.ThemeStyle.HeaderStyle.Height = 40;
            dgvHistorique.ThemeStyle.ReadOnly = true;
            dgvHistorique.ThemeStyle.RowsStyle.BackColor = Color.WhiteSmoke;
            dgvHistorique.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistorique.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvHistorique.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(23, 24, 29);
            dgvHistorique.ThemeStyle.RowsStyle.Height = 40;
            dgvHistorique.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(50, 52, 60);
            dgvHistorique.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column1.FillWeight = 26.73797F;
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 10;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.GhostWhite;
            label18.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.FromArgb(51, 102, 204);
            label18.Image = Properties.Resources.online_presence1;
            label18.ImageAlign = ContentAlignment.MiddleRight;
            label18.Location = new Point(5, 2);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(371, 43);
            label18.TabIndex = 46;
            label18.Text = "Historique des activités     ";
            label18.UseCompatibleTextRendering = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.White;
            button3.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 245);
            button3.Font = new Font("Segoe UI", 11F);
            button3.ForeColor = Color.Black;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(1208, 692);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(142, 50);
            button3.TabIndex = 47;
            button3.Text = "Fermer";
            button3.UseCompatibleTextRendering = true;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // FormUtilisateursActivitésHistorique
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(1359, 754);
            Controls.Add(button3);
            Controls.Add(label18);
            Controls.Add(dgvHistorique);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "FormUtilisateursActivitésHistorique";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Activités Historique";
            Load += FormUtilisateursActivitésHistorique_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorique).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHistorique;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button button3;
    }
}