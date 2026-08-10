using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalDB_mdf
{
    public partial class FormUtenti : Form
    {
        public FormUtenti()
        {
            InitializeComponent();

            // Impedisce il ridimensionamento manuale
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            CaricaUtenti();
        }

        private void FormUtenti_Load(object sender, EventArgs e)
        {

        }

        private void CaricaUtenti()
        {
            using (SqlConnection con = new SqlConnection(Utility.connStringUtenti))
            {
                // Selezioniamo solo Id e Username. 
                // Mai mostrare Password e Salt nella griglia!
                string query = "SELECT Id, Username FROM Utenti";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUtenti.DataSource = dt;

                // Opzionale: Rendere le colonne più carine
                dgvUtenti.Columns["Id"].Width = 50;
                dgvUtenti.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnAggiungiUtente_Click(object sender, EventArgs e)
        {
            string salt = Utility.GenerateSalt();
            string hash = Utility.ComputeHashWithSalt(txtNuovaPass.Text, salt);

            using (SqlConnection con = new SqlConnection(Utility.connStringUtenti))
            {
                string query = "INSERT INTO Utenti (Username, Password, Salt) VALUES (@user, @pass, @salt)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", txtNuovoUser.Text);
                cmd.Parameters.AddWithValue("@pass", hash);
                cmd.Parameters.AddWithValue("@salt", salt);

                con.Open();
                cmd.ExecuteNonQuery();
                CaricaUtenti();
                //MessageBox.Show("Utente registrato con Salt!");
            }
        }

        private void btnEliminaUtente_Click(object sender, EventArgs e)
        {
            if (dgvUtenti.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvUtenti.CurrentRow.Cells["Id"].Value);
                // Evitiamo di far cancellare l'utente con cui siamo loggati (opzionale)

                using (SqlConnection con = new SqlConnection(Utility.connStringUtenti))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Utenti WHERE Id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    CaricaUtenti();
                }
            }
        }
    }
}
