using CodeSourceLayer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoGes_New_Version
{
    public partial class FormModifierPatient : Form
    {
        private int PersonID = -1;
        private string Numero_Patient = null;
        Person person;
        Patient patient;
        Assure assure;
        DataTable dtCaisse;
        bool begin = true;

        private bool _suppressSearch = false;
        DataTable communes;
        public FormModifierPatient(string numero_patient)
        {
            InitializeComponent();
            Numero_Patient = numero_patient;
        }
        private void FillCmbxWithData()
        {
            cmbxCaisseAssure.Items.Clear();
            cmbxCaissePatient.Items.Clear();
            dtCaisse = Patient.GetAllCaisses();
            foreach (DataRow dr in dtCaisse.Rows)
            {
                cmbxCaisseAssure.Items.Add(dr["Nom_Caisse"]);
                cmbxCaissePatient.Items.Add(dr["Nom_Caisse"]);
            }
        }
        private void LoadData()
        {
            patient = Patient.FindByNumeroPatient(Numero_Patient);
            if (patient == null)
            {
                MessageBox.Show("Error when trying to identify the patient");
                return;
            }

            if (patient.est_Assure == 1)
            {
                AssureCheckedConfig();
                person = Person.Find(patient.PersonID);
                assure = Assure.FindByID(patient.AssureID);
                tbxNomPatient.Text = person.Nom;
                tbxPrenomPatient.Text = person.Prenom;
                tbxDateNaiPatient.Text = person.DateNaissance.ToString("d");
                tbxNumAssPatient.Text = assure.NumeroAssurance.ToString();
                cmbxCaissePatient.Text = assure.CaisseNom;

                // FIX: Use the same string comparison as in save code
                if (person.Genre == 0)
                {
                    rdbFemellePatiente.Checked = true;
                }
                else
                {
                    rdbMalePatient.Checked = true;
                }

                tbxARNomPatient.Text = person.NomArabe;
                tbxARPrenomPatient.Text = person.PrenomArabe;

                tbxEmail.Text = person.Email;
                tbxadresse.Text = person.Adresse;
                tbxWilaya.Text = person.Wilaya;
                tbxCommune.Text = person.Commune;
                begin = false;

                tbxTele1.Text = person.Telephones[0];
                if (person.Telephones.Length > 1)
                {
                    tbxTele2.Text = person.Telephones[1];
                    if (person.Telephones.Length > 2) tbxTele3.Text = person.Telephones[2];
                }
            }
            else
            {
                person = Person.Find(patient.PersonID);
                assure = Assure.FindByID(patient.AssureID);
                Person personassure = Person.Find(assure.PersonID);

                tbxNomPatient.Text = person.Nom;
                tbxPrenomPatient.Text = person.Prenom;
                tbxARNomPatient.Text = person.NomArabe;
                tbxARPrenomPatient.Text = person.PrenomArabe;
                tbxDateNaiPatient.Text = person.DateNaissance.ToString("d");

                // FIX: Use the same string comparison as in save code
                if (person.Genre == 0)
                {
                    rdbFemellePatiente.Checked = true;
                }
                else
                {
                    rdbMalePatient.Checked = true;
                }

                tbxNomAssure.Text = personassure.Nom;
                tbxPrenomAssure.Text = personassure.Prenom;
                tbxARNomAssure.Text = personassure.NomArabe;
                tbxARPrenomAssure.Text = personassure.PrenomArabe;
                tbxDateNaiAssure.Text = personassure.DateNaissance.ToString("d");

                // FIX: Use the same string comparison as in save code
                if (personassure.Genre == 0)
                {
                    rdbFemelleAssure.Checked = true;
                }
                else
                {
                    rdbMaleAssure.Checked = true;
                }

                tbxNumAssAssure.Text = assure.NumeroAssurance.ToString();
                cmbxCaisseAssure.Text = assure.CaisseNom;

                tbxEmail.Text = person.Email;
                tbxadresse.Text = person.Adresse;
                tbxWilaya.Text = person.Wilaya;
                tbxCommune.Text = person.Commune;
                begin = false;
                tbxTele1.Text = person.Telephones[0];

                // FIX: Check for null/empty strings instead of array length
                if (person.Telephones.Length > 1 && !string.IsNullOrEmpty(person.Telephones[1]))
                    tbxTele2.Text = person.Telephones[1];
                if (person.Telephones.Length > 2 && !string.IsNullOrEmpty(person.Telephones[2]))
                    tbxTele3.Text = person.Telephones[2];
            }
        }

        private void tbxNumAct_TextChanged(object sender, EventArgs e)
        {

        }
        private void AssureCheckedConfig()
        {
            cbxAssure.Checked = true;
            gbxpatient.Size = new System.Drawing.Size(766, 364);
            lblnum.Visible = true;
            tbxNumAssPatient.Visible = true;
            gbxAssure.Visible = false;
            gbxContact.Location = new System.Drawing.Point(18, 423);
            btnEnregistrer.Location = new System.Drawing.Point(463, 740);
            btnAnnuler.Location = new System.Drawing.Point(628, 740);

        }

        private void FormAjouterPatient_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(830, 845);
            LoadData();
            FillCmbxWithData();
        }

        private void cbxAssure_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxAssure.Checked)
            {
                gbxpatient.Size = new System.Drawing.Size(766, 285);
                lblnum.Visible = false;
                tbxNumAssPatient.Visible = false;
                gbxAssure.Visible = true;
                gbxContact.Location = new System.Drawing.Point(18, 721);
                btnEnregistrer.Location = new System.Drawing.Point(488, 1031);
                btnAnnuler.Location = new System.Drawing.Point(653, 1031);
            }
            else AssureCheckedConfig();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (cbxAssure.Checked)
            {
                if (tbxNomPatient.Text == string.Empty) { tbxNomPatient.BorderColor = Color.Red; lblNom.ForeColor = Color.Red; return; } else { tbxNomPatient.BorderColor = Color.Black; lblNom.ForeColor = Color.Black; }
                if (tbxPrenomPatient.Text == string.Empty) { tbxPrenomPatient.BorderColor = Color.Red; lblprenom.ForeColor = Color.Red; return; } else { tbxPrenomPatient.BorderColor = Color.Black; lblprenom.ForeColor = Color.Black; }
                if (tbxDateNaiPatient.Text == string.Empty) { tbxDateNaiPatient.BorderColor = Color.Red; lbldate.ForeColor = Color.Red; return; } else { tbxDateNaiPatient.BorderColor = Color.Black; lbldate.ForeColor = Color.Black; }
                if (tbxNumAssPatient.Text == string.Empty) { tbxNumAssPatient.BorderColor = Color.Red; lblnum.ForeColor = Color.Red; return; } else { tbxNumAssPatient.BorderColor = Color.Black; lblnum.ForeColor = Color.Black; }
                if (cmbxCaissePatient.Text == string.Empty) { cmbxCaissePatient.BorderColor = Color.Red; lblnum.ForeColor = Color.Red; return; } else { cmbxCaissePatient.BorderColor = Color.Black; lblnum.ForeColor = Color.Black; }

                person.Nom = tbxNomPatient.Text;
                person.Prenom = tbxPrenomPatient.Text;
                person.Adresse = tbxadresse.Text;
                person.Wilaya = tbxWilaya.Text;
                person.Commune = tbxCommune.Text;
                person.Email = tbxEmail.Text;

                var telephones = new List<string>();

                if (!string.IsNullOrWhiteSpace(tbxTele1.Text))
                    telephones.Add(tbxTele1.Text);

                if (!string.IsNullOrWhiteSpace(tbxTele2.Text))
                    telephones.Add(tbxTele2.Text);

                if (!string.IsNullOrWhiteSpace(tbxTele3.Text))
                    telephones.Add(tbxTele3.Text);

                person.Telephones = telephones.ToArray();

                person.DateNaissance = DateTime.Parse(tbxDateNaiPatient.Text);
                person.NomArabe = tbxARNomPatient.Text;
                person.PrenomArabe = tbxARPrenomPatient.Text;
                if (rdbMalePatient.Checked)
                {
                    person.Genre = 1;
                }
                else person.Genre = 0;

                if (!person.UpdatePerson())
                {
                    MessageBox.Show("Erreur : les données du patient p n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                patient.est_Assure = 1;
                patient.PersonID = person.PersonID;
                assure.PersonID = person.PersonID;
                assure.NumeroAssurance = tbxNumAssPatient.Text;
                assure.CaisseID = (int)dtCaisse.Rows[cmbxCaissePatient.SelectedIndex]["Caisse_ID"];
                assure.CaisseNom = cmbxCaissePatient.Text;
                assure.RelationPatient = "Self";

                if (!assure.UpdateAssure())
                {
                    MessageBox.Show("Erreur : les données de l'assuré n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                patient.AssureID = assure.AssureID;
                if (!patient.UpdatePatient())
                {
                    MessageBox.Show("Erreur : les données du patient n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                if (Utilisateur.AddActivité(Global.utilisateurActuel.Utilisateur_ID, $"Modifier le patient {Numero_Patient}", "Modification"))
                {
                    MessageBox.Show("Données enregistrées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                if (tbxNomPatient.Text == string.Empty) { tbxNomPatient.BorderColor = Color.Red; lblNom.ForeColor = Color.Red; return; } else { tbxNomPatient.BorderColor = Color.Black; lblNom.ForeColor = Color.Black; }
                if (tbxPrenomPatient.Text == string.Empty) { tbxPrenomPatient.BorderColor = Color.Red; lblprenom.ForeColor = Color.Red; return; } else { tbxPrenomPatient.BorderColor = Color.Black; lblprenom.ForeColor = Color.Black; }
                if (tbxDateNaiPatient.Text == string.Empty) { tbxDateNaiPatient.BorderColor = Color.Red; lbldate.ForeColor = Color.Red; return; } else { tbxDateNaiPatient.BorderColor = Color.Black; lbldate.ForeColor = Color.Black; }

                if (tbxNomAssure.Text == string.Empty) { tbxNomAssure.BorderColor = Color.Red; lblNom.ForeColor = Color.Red; return; } else { tbxNomAssure.BorderColor = Color.Black; lblNom.ForeColor = Color.Black; }
                if (tbxPrenomAssure.Text == string.Empty) { tbxPrenomAssure.BorderColor = Color.Red; lblprenom.ForeColor = Color.Red; return; } else { tbxPrenomAssure.BorderColor = Color.Black; lblprenom.ForeColor = Color.Black; }
                if (tbxDateNaiAssure.Text == string.Empty) { tbxDateNaiAssure.BorderColor = Color.Red; lbldate.ForeColor = Color.Red; return; } else { tbxDateNaiAssure.BorderColor = Color.Black; lbldate.ForeColor = Color.Black; }
                if (tbxNumAssAssure.Text == string.Empty) { tbxNumAssAssure.BorderColor = Color.Red; lblnum.ForeColor = Color.Red; return; } else { tbxNumAssAssure.BorderColor = Color.Black; lblnum.ForeColor = Color.Black; }
                if (cmbxCaisseAssure.Text == string.Empty) { cmbxCaisseAssure.BorderColor = Color.Red; lblnum.ForeColor = Color.Red; return; } else { cmbxCaisseAssure.BorderColor = Color.Black; lblnum.ForeColor = Color.Black; }

                Person personAssure = Person.Find(assure.PersonID);
                personAssure.Nom = tbxNomAssure.Text;
                personAssure.Prenom = tbxPrenomAssure.Text;
                personAssure.Adresse = tbxadresse.Text;
                personAssure.Wilaya = tbxWilaya.Text;
                personAssure.Commune = tbxCommune.Text;
                personAssure.Email = tbxEmail.Text;
                if (rdbMaleAssure.Checked)
                {
                    personAssure.Genre = 1;
                }
                else personAssure.Genre = 0;

                // Phones for ASSURE
                var assurePhones = new List<string>();

                if (!string.IsNullOrWhiteSpace(tbxTele1.Text))
                    assurePhones.Add(tbxTele1.Text);

                if (!string.IsNullOrWhiteSpace(tbxTele2.Text))
                    assurePhones.Add(tbxTele2.Text);

                if (!string.IsNullOrWhiteSpace(tbxTele3.Text))
                    assurePhones.Add(tbxTele3.Text);

                personAssure.Telephones = assurePhones.ToArray();

                personAssure.DateNaissance = DateTime.Parse(tbxDateNaiAssure.Text);
                personAssure.NomArabe = tbxARNomAssure.Text;
                personAssure.PrenomArabe = tbxARPrenomAssure.Text;

                if (!personAssure.UpdatePerson())
                {
                    MessageBox.Show("Erreur : les données du Assure p n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                person.Nom = tbxNomPatient.Text;
                person.Prenom = tbxPrenomPatient.Text;
                person.Adresse = tbxadresse.Text;
                person.Wilaya = tbxWilaya.Text;
                person.Commune = tbxCommune.Text;
                person.Email = tbxEmail.Text;

                var telephones = new List<string>();

                if (!string.IsNullOrWhiteSpace(tbxTele1.Text))
                    telephones.Add(tbxTele1.Text);

                if (!string.IsNullOrWhiteSpace(tbxTele2.Text))
                    telephones.Add(tbxTele2.Text);

                if (!string.IsNullOrWhiteSpace(tbxTele3.Text))
                    telephones.Add(tbxTele3.Text);
                person.Telephones = telephones.ToArray();
                person.DateNaissance = DateTime.Parse(tbxDateNaiPatient.Text);
                person.NomArabe = tbxARNomPatient.Text;
                person.PrenomArabe = tbxARPrenomPatient.Text;
                if (rdbMalePatient.Checked)
                {
                    person.Genre = 1;
                }
                else person.Genre = 0;
                if (!person.UpdatePerson())
                {
                    MessageBox.Show("Erreur : les données du patient p n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                assure.PersonID = personAssure.PersonID;
                assure.NumeroAssurance = tbxNumAssAssure.Text;
                assure.CaisseID = (int)dtCaisse.Rows[cmbxCaissePatient.SelectedIndex]["Caisse_ID"];
                assure.CaisseNom = cmbxCaisseAssure.Text;
                assure.RelationPatient = tbxRelationAssure.Text;

                if (!assure.UpdateAssure())
                {
                    MessageBox.Show("Erreur : les données de l'assuré n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                patient.est_Assure = 0;
                patient.PersonID = person.PersonID;
                patient.AssureID = assure.AssureID;
                if (!patient.UpdatePatient())
                {
                    MessageBox.Show("Erreur : les données du patient n'ont pas été enregistrées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                MessageBox.Show("Données enregistrées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            //18 348  744 364 465, 781  630, 781
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tbxWilaya_TextChanged(object sender, EventArgs e)
        {
            if(begin) return;
            if (_suppressSearch) return;

            if (string.IsNullOrWhiteSpace(tbxWilaya.Text))
            {
                dgvWilayas.Visible = false;
                return;
            }

            DataTable wilayas = Centre_Appareillage.GetAllWillaya();

            DataView dv = wilayas.DefaultView;
            dv.RowFilter = $"wilaya_name_latin LIKE '%{tbxWilaya.Text}%'";

            if (dv.Count == 0)
            {
                dgvWilayas.Visible = false;
                return;
            }

            dgvWilayas.Visible = true;
            dgvWilayas.DataSource = dv;

            // Hide ID
            dgvWilayas.Columns["wilaya_id"].Visible = false;

            // Show ONLY the wilaya name
            foreach (DataGridViewColumn col in dgvWilayas.Columns)
                col.Visible = false;

            dgvWilayas.Columns["wilaya_name_latin"].Visible = true;
        }

        private void dgvWilayas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch = true;

            tbxWilaya.Text = dgvWilayas.CurrentRow.Cells["wilaya_name_latin"].Value.ToString();
            communes = Centre_Appareillage.GetAllCommuneDeWillaya((int)dgvWilayas.CurrentRow.Cells["wilaya_id"].Value);

            dgvWilayas.Visible = false;

            _suppressSearch = false;
        }

        private void tbxCommune_TextChanged(object sender, EventArgs e)
        {
            if (begin) return;
            if (_suppressSearch) return;

            if (tbxCommune.Text.Length == 0)
            {
                dgvCommunes.Visible = false;
                return;
            }

            dgvCommunes.Visible = true;

            dgvCommunes.DataSource = communes;

            for (int i = 1; i < dgvCommunes.Columns.Count; i++)
                dgvCommunes.Columns[i].Visible = false;

            DataView dv = communes.DefaultView;
            dv.RowFilter = $"commune_name_latin LIKE '%{tbxCommune.Text}%'";

            if (dv.Count == 0)
                dgvCommunes.Visible = false;
        }

        private void dgvCommunes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _suppressSearch = true;

            tbxCommune.Text = dgvCommunes.CurrentRow.Cells[0].Value.ToString();

            dgvCommunes.Visible = false;

            _suppressSearch = false;
        }

        private void dgvWilayas_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                _suppressSearch = true;
                e.Handled = true;
                e.SuppressKeyPress = true;
                tbxWilaya.Text = dgvWilayas.CurrentRow.Cells["wilaya_name_latin"].Value.ToString();
                communes = Centre_Appareillage.GetAllCommuneDeWillaya((int)dgvWilayas.CurrentRow.Cells["wilaya_id"].Value);

                dgvWilayas.Visible = false;

                _suppressSearch = false;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Optional: keep full-row selection clean
                e.Handled = false; // let DataGridView handle navigation
            }
        }

        private void dgvCommunes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _suppressSearch = true;

                tbxCommune.Text = dgvCommunes.CurrentRow.Cells[0].Value.ToString();

                dgvCommunes.Visible = false;

                _suppressSearch = false;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Optional: keep full-row selection clean
                e.Handled = false; // let DataGridView handle navigation
            }
        }
    }
}
