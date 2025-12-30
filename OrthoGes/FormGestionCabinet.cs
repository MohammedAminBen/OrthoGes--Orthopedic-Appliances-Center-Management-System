using CodeSourceLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes
{
    public partial class FormGestionCabinet : Form
    {
        public FormGestionCabinet()
        {
            InitializeComponent();
        }

        //private void guna2Button1_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //    {
        //        openFileDialog.Title = "Sélectionner une image";
        //        openFileDialog.Filter = "Fichiers image (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Tous les fichiers (*.*)|*.*";

        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {

        //            string filePath = openFileDialog.FileName;
        //            Globale.ecole.ImagePath = filePath; // Enregistrer le chemin de l'image dans l'objet utilisateur

        //            picbxImage.Image = Image.FromFile(filePath);
        //        }
        //    }
        //}
        //private void FillData()
        //{
        //    if (Globale.ecole == null) { return; }

        //    tbxAddress.Text = Globale.ecole.Address;
        //    tbxContact.Text = Globale.ecole.Contact;
        //    tbxEcole.Text = Globale.ecole.NomEcole;

        //    if (!string.IsNullOrEmpty(Globale.ecole.ImagePath) && File.Exists(Globale.ecole.ImagePath))
        //    {
        //        picbxImage.Image = Image.FromFile(Globale.ecole.ImagePath);
        //    }
        //    FillSallesInFlowLayoutPanel();
        //}
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    var controls = FLWSalles.Controls.OfType<TbxSallesUserControl>().ToList();

        //    // ✅ Update existing salles
        //    foreach (var ctrl in controls.Where(c => !c.IsNewAdded))
        //    {
        //        if (!ctrl.UpdateSalle(ctrl.SalleID))
        //            return;
        //    }

        //    // ✅ Add new salles
        //    foreach (var ctrl in controls.Where(c => c.IsNewAdded))
        //    {
        //        if (!ctrl.AddSalle())
        //            return;
        //        ctrl.IsNewAdded = false;
        //    }

        //    Globale.ecole.NomEcole = tbxEcole.Text;
        //    Globale.ecole.Contact = tbxContact.Text;
        //    Globale.ecole.Address = tbxAddress.Text;
        //    if (Globale.ecole.Dimarage == 0)
        //    {
        //        if (Globale.ecole.insertEcoleData())
        //        {
        //            MessageBox.Show($"Données enregistrées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            this.Close();
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        if (Globale.ecole.UpdateEcoleData())
        //        {
        //            this.Close();
        //            return;
        //        }
        //    }


        //}

        //private void FormGestionScolaire_Load(object sender, EventArgs e)
        //{
        //    FillData();
        //}

        //private void guna2GroupBox4_Click(object sender, EventArgs e)
        //{

        //}

        //public void FillSallesInFlowLayoutPanel()
        //{
        //    FLWSalles.Controls.Clear();
        //    DataTable SallesDT = Salle.GetAllSalles();

        //    if (SallesDT.Rows.Count == 0)
        //    {
        //        return;
        //    }
        //    foreach (DataRow row in SallesDT.Rows)
        //    {
        //        string Nom = row["SaleNom"]?.ToString() ?? "";
        //        int ID = (int)row["SaleID"];
        //        TbxSallesUserControl userControl = new TbxSallesUserControl();
        //        userControl.FillData(ID, Nom);
        //        userControl.IsNewAdded = false;
        //        FLWSalles.Controls.Add(userControl);
        //    }
        //}

        //private void button5_Click_1(object sender, EventArgs e)
        //{
        //    TbxSallesUserControl tbxUserControl = new TbxSallesUserControl();
        //    tbxUserControl.IsNewAdded = true;
        //    FLWSalles.Controls.Add(tbxUserControl);
        //}

        //private void button4_Click_1(object sender, EventArgs e)
        //{
        //    if (FLWSalles.Controls.Count <= 1)
        //        return;

        //    bool IsThereSelected = false;


        //    var selectedControls = FLWSalles.Controls
        //        .OfType<TbxSallesUserControl>()
        //        .Where(c => c.IsSelected)
        //        .ToList();

        //    int counter = 0;
        //    foreach (var control in selectedControls)
        //    {
        //        counter++;
        //        if (FLWSalles.Controls.Count == 1)
        //        {
        //            break;
        //        }
        //        if (FLWSalles.Controls.Count == 2)
        //        {
        //            control.DeleteSalle();
        //            FLWSalles.Controls.Remove(control);
        //            control.Dispose();
        //            break;
        //        }
        //        control.DeleteSalle();
        //        FLWSalles.Controls.Remove(control);
        //        control.Dispose();

        //        IsThereSelected = true;
        //    }

        //    if (!IsThereSelected && FLWSalles.Controls.Count > 1)
        //    {
        //        Control last = FLWSalles.Controls[FLWSalles.Controls.Count - 1];
        //        if (last is TbxSallesUserControl uc)
        //        {
        //            uc.DeleteSalle();
        //        }
        //        FLWSalles.Controls.Remove(last);
        //        last.Dispose();
        //    }
        //}

        //private void btnAjouterEleve_Click(object sender, EventArgs e)
        //{
        //    var frm = new FormEntrerMotDePasse();
        //    frm.ShowDialog();

        //    if (frm.isHim == true)
        //    {
        //        DataTable dt = Groupe.GetAllGroupes();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            string groupeId = dr[0].ToString();  // or Convert.ToInt32(dr[0]) if it's numeric
        //            Groupe.DeleteGroupe(groupeId);
        //        }
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var frm = new FormEntrerMotDePasse();
        //    frm.ShowDialog();

        //    if (frm.isHim == true)
        //    {
        //        DataTable dt = Enseignant.GetAllEnseignants();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            string enseignantId = dr[0].ToString();// or Convert.ToInt32(dr[0]) if it's numeric
        //            Enseignant.DeleteEnseignant(enseignantId);
        //        }
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    var frm = new FormEntrerMotDePasse();
        //    frm.ShowDialog();

        //    if (frm.isHim == true)
        //    {
        //        DataTable dt = Eleve.GetAllEleves();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            string eleveid = dr[0].ToString();  // or Convert.ToInt32(dr[0]) if it's numeric
        //            Eleve.DeleteEleve(eleveid);
        //        }
        //    }
        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    FormUploadToGoogleDrive form = new FormUploadToGoogleDrive();
        //    form.ShowDialog();

        //}
    }
}
