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
    public partial class FormLogin : Form
    {       
        // Costruttore del form di login
        public FormLogin()
        {
            InitializeComponent();

            // Impedisce il ridimensionamento manuale
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        // Evento di caricamento del form
        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        // Evento di click sul pulsante di login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utility.connStringUtenti))
            {
                // 1. Recuperiamo l'hash salvato e il sale per quell'utente
                string query = "SELECT Password, Salt FROM Utenti WHERE Username = @user";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", txtUser.Text);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string savedHash = reader["Password"].ToString();
                    string savedSalt = reader["Salt"].ToString();

                    // 2. Calcoliamo l'hash della password inserita usando il sale recuperato
                    string inputHash = Utility.ComputeHashWithSalt(txtPass.Text, savedSalt);

                    // 3. Confronto
                    if (inputHash == savedHash)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password errata!");
                    }
                }
                else
                {
                    MessageBox.Show("Utente non trovato!");
                }
            }
        }

        // Evento di click sul pulsante di annullamento
        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Evento del tasto GESTIONE UTENTI
        private void btnGestioneUtenti_Click(object sender, EventArgs e)
        {
            FormUtenti frm = new FormUtenti();
            frm.ShowDialog(); // Apre la finestra come modale
        }
    }
}
