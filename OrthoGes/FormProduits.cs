//using CodeSourceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes
{
    public partial class FormProduits : Form
    {
        public FormProduits()
        {
          InitializeComponent();
            //InitializePlaceholder();
        }
        //private void InitializePlaceholder()
        //{
        //    tbxelevesrecherche.Text = "Taper ici...";
        //    tbxelevesrecherche.ForeColor = System.Drawing.Color.Gray;

        //    tbxelevesrecherche.Enter += tbxelevesrecherche_Enter;
        //    tbxelevesrecherche.Leave += tbxelevesrecherche_Leave;
        //}

        //private void Forméleves_Load(object sender, EventArgs e)
        //{
        //    FillNiveauAcademiqueInComboBox();
        //    ApplyFilters();
        //}
        //private void FillNiveauAcademiqueInComboBox()
        //{
        //    cmbxNiveau.Items.Clear();
        //    DataTable dtNiveaux = NiveauAcademique.GetAllNiveaux();
        //    cmbxNiveau.Items.Add("Tous");
        //    foreach (DataRow dr in dtNiveaux.Rows)
        //    {
        //        cmbxNiveau.Items.Add(dr["NiveauAcadémique"]);
        //    }
        //}
        //private void ApplyFilters()
        //{
        //    dtEleveList = Eleve.GetAllEleves();
        //    if (dtEleveList.Rows.Count == 0)
        //    {
        //        btnSupprimer.Enabled = false;
        //        btnModifier.Enabled = false;
        //        btnDetails.Enabled = false;
        //        btnAjouteraugroup.Enabled = false;
        //        return;
        //    }
        //    else
        //    {
        //        btnSupprimer.Enabled = true;
        //        btnModifier.Enabled = true;
        //        btnDetails.Enabled = true;
        //        btnAjouteraugroup.Enabled = true;
        //    }


        //    List<string> filters = new List<string>();

        //    // Niveau and Filiere filters
        //    string niveau = cmbxNiveau.Text.Trim();
        //    string filiere = cmbxFiliere.Text.Trim();
        //    if (!string.IsNullOrEmpty(niveau) && niveau!="Tous")
        //        filters.Add($"NiveauAcademique LIKE '%{niveau}%'");
        //    if (!string.IsNullOrEmpty(filiere) && filiere != "Tous")
        //        filters.Add($"NiveauAcademique LIKE '%{filiere}%'");

        //    // Search bar filters
        //    string searchValue = tbxelevesrecherche.Text.Trim();
        //    string searchFilter = cmbxRecherche.Text.Trim();
        //    if (!string.IsNullOrEmpty(searchValue) && searchValue != "Taper ici...")
        //    {
        //        if (searchFilter == "Nom Et Prénom")
        //            filters.Add($"NomEtPrenom LIKE '%{searchValue}%'");
        //        else if (searchFilter == "Identifiant")
        //            filters.Add($"EleveID LIKE '%{searchValue}%'");
        //    }

        //    // Combine all filters
        //    string filterString = string.Join(" AND ", filters);

        //    DataView dv = dtEleveList.DefaultView;
        //    dv.RowFilter = filterString;

        //    dgvElevesListe.DataSource = dv;
        //    dgvElevesListe.Columns[1].HeaderText = "Identifiant";
        //    dgvElevesListe.Columns[2].HeaderText = "Nom et Prénom";
        //    dgvElevesListe.Columns[3].HeaderText = "Niveau Académique";
        //    dgvElevesListe.Columns[4].HeaderText = "Contact (Téléphone/Email)";
            
        //    lblnmbrEleves.Text = dv.Count.ToString() + "  Élèves     ";
        //}


        //private void FiliereHandling(string Niveau)
        //{
        //    cmbxFiliere.Items.Clear();
        //    NiveauAcademique niveau = NiveauAcademique.Find(Niveau);

        //    DataTable dtFiliere = NiveauAcademique.GetAllFiliereDeNiveau(niveau.NiveauID);
        //    cmbxFiliere.Items.Add("Tous");
        //    foreach (DataRow dr in dtFiliere.Rows)
        //    {
        //        cmbxFiliere.Items.Add(dr["Filière"]);
        //    }
        //}

        //private void tbxelevesrecherche_Enter(object sender, EventArgs e)
        //{
        //    if (tbxelevesrecherche.Text == "Taper ici...")
        //    {
        //        tbxelevesrecherche.Text = "";
        //        tbxelevesrecherche.ForeColor = System.Drawing.Color.Black; // Change text color
        //    }
        //}

        //private void tbxelevesrecherche_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(tbxelevesrecherche.Text))
        //    {
        //        tbxelevesrecherche.Text = "Taper ici...";
        //        tbxelevesrecherche.ForeColor = System.Drawing.Color.Gray; 
        //    }
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FormAjouterélevecs frmAjouterEleve = new FormAjouterélevecs();
        //    if (frmAjouterEleve.ShowDialog() == DialogResult.OK)
        //    {
        //        RefreshEleveList();
        //    }

        //}

        //private void dgvElevesListe_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    FormElevesDetails frmEleves = new FormElevesDetails(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //    frmEleves.Show();
        //    RefreshEleveList();
        //}

        //private void btnModifier_Click(object sender, EventArgs e)
        //{
        //    FormModiferElevesInfo formModiferElevesInfo = new FormModiferElevesInfo(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //    formModiferElevesInfo.ShowDialog();
        //    RefreshEleveList();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (Globale.utilisateurActuel.PrivPayementEleve)
        //    {
        //        FormElevesDetails frmEleves = new FormElevesDetails(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //        frmEleves.ShowDialog();
        //        RefreshEleveList();
        //    }
        //    else
        //    {
        //        FormEleveDetailsSansFin frmEleves = new FormEleveDetailsSansFin(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //        frmEleves.ShowDialog();
        //        RefreshEleveList();
        //    }
        //}

        //private void btnAjouteraugroup_Click(object sender, EventArgs e)
        //{
        //    var Form = new FormGroupeAffectation(dgvElevesListe.CurrentRow.Cells[1].Value.ToString());
        //    Form.ShowDialog();
        //    RefreshEleveList();
        //}

        //private void cmbxNiveau_SelectedIndexChanged(object sender, EventArgs e)
        //{
          
        //        if (cmbxNiveau.SelectedItem != null)
        //        {
        //        if (cmbxNiveau.SelectedItem.ToString().Contains("Année Secondaire"))
        //        {
        //            cmbxFiliere.Visible = true;
        //            FiliereHandling(cmbxNiveau.SelectedItem.ToString());
        //        }
        //        else
        //        {
        //            cmbxFiliere.Items.Clear();
        //            cmbxFiliere.Visible = false;
        //        }
        //        }
        //        ApplyFilters();
        //}
        //private void cmbxRecherche_RightToLeftChanged(object sender, EventArgs e)
        //{

        //}

        //private void cmbxRecherche_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ApplyFilters();
        //}

        //private void guna2TileButton2_Click(object sender, EventArgs e)
        //{
        //    ApplyFilters();
        //}
        //private void RefreshEleveList()
        //{
        //    dtEleveList = Eleve.GetAllEleves();
        //    ApplyFilters();                     
        //}

        //private void cmbxFiliere_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ApplyFilters();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{ 
        //    string DeletedEleveID = dgvElevesListe.CurrentRow.Cells[1].Value.ToString();
        //    int DeletedPersonID = Eleve.FindByEleveID(DeletedEleveID).PersonID;

        //    if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer l'étudiant [ " + dgvElevesListe.CurrentRow.Cells[1].Value.ToString()+" ]", "confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        if (Eleve.CheckifEleveHasDette(DeletedEleveID)) 
        //        {
        //            if (MessageBox.Show("Cet élève a des dettes à payer, êtes-vous sûr de le supprimer ?", "Des dettes sont détectées !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        //            {
        //                return;
        //            }
        //        }
        //            if (Eleve.DeleteEleve(DeletedEleveID))
        //            {
        //              if (Person.DeletePerson(DeletedPersonID))
        //              {
        //                if(Utilisateurs.AddActivité(Globale.utilisateurActuel.UtilisateurID, "Supprimer l'étudiant " + DeletedEleveID + " du système"))
        //                {
        //                    MessageBox.Show("étudiant supprimé avec succès.", "Succés", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    dtEleveList = Eleve.GetAllEleves();
        //                    dgvElevesListe.DataSource = dtEleveList;
        //                    lblnmbrEleves.Text = dgvElevesListe.Rows.Count.ToString() + " Élèves";
        //                    ApplyFilters();
        //                }
        //              }
        //              else { MessageBox.Show("L'étudiant n'a pas été supprimé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                       
        //            }else MessageBox.Show("L'étudiant n'a pas été supprimé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    ApplyFilters();
        //}

        private void FormFactures_Load(object sender, EventArgs e)
        {

        }
    }
}
