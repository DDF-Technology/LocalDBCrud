using ClosedXML.Excel;
using iText.Kernel.Pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;

namespace LocalDB_mdf
{
    public partial class Form1 : Form
    {
        // Variabile per tenere traccia dell'ID selezionato nella GridView
        int idSelezionato = 0;

        //-----------------------------

        // Costruttore del form
        public Form1()
        {
            InitializeComponent();

            // Impedisce il ridimensionamento manuale
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Inizializzazione UI
            cmbOrdinamento.SelectedIndex = 0; // Seleziona il primo elemento
            AggiornaFiltri(); // Carica i dati iniziali
        }

        // Evento di caricamento del form
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Evento del tasto INSERISCI
        private void btnInserisci_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Utility.connStringProdotti))
            {
                string percorsoEffettivo = AppDomain.CurrentDomain.BaseDirectory;
                Console.WriteLine("Il database deve trovarsi qui: " + percorsoEffettivo);

                con.Open();

                string query = "INSERT INTO Prodotti (Nome, Prezzo) VALUES (@nome, @prezzo)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@prezzo", numPrezzo.Value);

                    cmd.ExecuteNonQuery();
                }

                //MessageBox.Show("Prodotto inserito con successo!");
                CaricaDati(); // Rinfresca la griglia
                SvuotaCampi(); // Pulisce i campi di input
            }
        }

        // Evento del tasto MODIFICA
        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (idSelezionato == 0)
            {
                MessageBox.Show("Seleziona prima un prodotto dalla lista!");
                return;
            }

            using (SqlConnection con = new SqlConnection(Utility.connStringProdotti))
            {
                string query = "UPDATE Prodotti SET Nome = @nome, Prezzo = @prezzo WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, con);

                // Parametri per la sicurezza
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@prezzo", numPrezzo.Value);
                cmd.Parameters.AddWithValue("@id", idSelezionato);

                con.Open();
                int righeCoinvolte = cmd.ExecuteNonQuery();

                if (righeCoinvolte > 0)
                {
                    MessageBox.Show("Dati aggiornati correttamente!");
                    AggiornaFiltri(); // Ricarica la griglia con i nuovi dati
                    SvuotaCampi();    // Funzione opzionale per pulire le TextBox
                }
            }
        }

        // Evento del tasto AGGIORNA (ricarica i dati)
        private void btnAggiorna_Click(object sender, EventArgs e)
        {
            CaricaDati();
        }

        // Evento del tasto ELIMINA (basato sulla riga selezionata nella griglia)
        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (dgvDati.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvDati.CurrentRow.Cells["Id"].Value);

                using (SqlConnection con = new SqlConnection(Utility.connStringProdotti))
                {
                    string query = "DELETE FROM Prodotti WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    CaricaDati();
                }
            }
        }

        // Evento del tasto Cerca
        private void btnCerca_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRicerca.Text))
            {
                CercaDati(txtRicerca.Text);
            }
            else
            {
                CaricaDati(); // Se il campo è vuoto, mostra tutto
            }
        }

        // Evento del tasto Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRicerca.Clear();
            CaricaDati();
        }

        // Evento del tasto ESPORTA CSV
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (dgvDati.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File (*.csv)|*.csv";
            sfd.FileName = "Esportazione_Prodotti.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                // 1. Intestazioni delle colonne
                string[] columnNames = dgvDati.Columns.Cast<DataGridViewColumn>()
                                        .Select(column => column.HeaderText).ToArray();
                sb.AppendLine(string.Join(";", columnNames));

                // 2. Righe dei dati
                foreach (DataGridViewRow row in dgvDati.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string[] cells = row.Cells.Cast<DataGridViewCell>()
                                         .Select(cell => cell.Value?.ToString() ?? "").ToArray();
                        sb.AppendLine(string.Join(";", cells));
                    }
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Esportazione CSV completata!");
            }
        }

        // Evento del tasto ESPORTA EXCEL
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvDati.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            sfd.FileName = "Esportazione_Prodotti.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    // Creiamo un foglio di lavoro partendo dalla DataTable del DataGridView
                    var dataTable = (DataTable)dgvDati.DataSource;
                    var worksheet = workbook.Worksheets.Add(dataTable, "Prodotti");

                    // Applichiamo un po' di stile (opzionale)
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(sfd.FileName);
                }
                MessageBox.Show("Esportazione Excel completata!");
            }
        }

        // Evento del tasto ESPORTA PDF
        private void btnEsportaPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF File (*.pdf)|*.pdf";
            sfd.FileName = "Report_Prodotti.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (PdfWriter writer = new PdfWriter(sfd.FileName))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);

                        // Aggiungiamo un titolo al report
                        Paragraph header = new Paragraph("REPORT PRODOTTI")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(20);
                        document.Add(header);

                        // Creiamo una tabella con lo stesso numero di colonne della DataGridView
                        Table table = new Table(dgvDati.Columns.Count).UseAllAvailableWidth();

                        // Aggiungiamo le intestazioni delle colonne
                        foreach (DataGridViewColumn col in dgvDati.Columns)
                        {
                            // Creare il Paragraph e applicare SetBold() al Paragraph (non a Cell)
                            Paragraph headerText = new Paragraph(col.HeaderText);
                            Cell headerCell = new Cell().Add(headerText);
                            headerCell.SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                            table.AddHeaderCell(headerCell);
                        }

                        // Aggiungiamo i dati delle righe
                        foreach (DataGridViewRow row in dgvDati.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    table.AddCell(new Paragraph(cell.Value?.ToString() ?? ""));
                                }
                            }
                        }

                        document.Add(table);
                        document.Close();
                    }
                }
                MessageBox.Show("Report PDF generato con successo!");
            }
        }

        // Evento quando l'utente clicca su una cella della griglia
        private void dgvDati_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifichiamo che l'utente abbia cliccato su una riga valida (non l'intestazione)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow riga = dgvDati.Rows[e.RowIndex];

                // Riempiamo i campi con i valori della riga selezionata
                txtNome.Text = riga.Cells["Nome"].Value.ToString();
                numPrezzo.Value = Convert.ToDecimal(riga.Cells["Prezzo"].Value);

                // Suggerimento: puoi salvare l'ID in una variabile globale per l'Update
                idSelezionato = Convert.ToInt32(riga.Cells["Id"].Value);
            }
        }

        // Evento quando l'utente cambia selezione nel ComboBox
        private void cmbOrdinamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AggiornaFiltri();
        }

        // Evento quando l'utente cambia il testo nella TextBox di ricerca
        private void txtRicerca_TextChanged(object sender, EventArgs e)
        {
            // Cerca automaticamente ogni volta che cambia il testo
            AggiornaFiltri();
        }

        // Evento del tasto GESTIONE UTENTI
        private void btnGestioneUtenti_Click(object sender, EventArgs e)
        {
            FormUtenti frm = new FormUtenti();
            frm.ShowDialog(); // Apre la finestra come modale
        }

        //-----------------------------

        // Funzione per leggere i dati e mostrarli nella griglia
        private void CaricaDati()
        {
            using (SqlConnection con = new SqlConnection(Utility.connStringProdotti))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Prodotti", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDati.DataSource = dt;

                // Opzionale: Rendere le colonne più carine
                dgvDati.Columns["Id"].Width = 50;
                dgvDati.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDati.Columns["Prezzo"].Width = 50;
            }
        }

        // Funzione per svuotare i campi di input
        private void SvuotaCampi()
        {
            txtNome.Clear();
            numPrezzo.Value = 0;
            idSelezionato = 0;
        }

        // Funzione per cercare dati specifici
        private void CercaDati(string termineRicerca)
        {
            using (SqlConnection con = new SqlConnection(Utility.connStringProdotti))
            {
                // La query usa LIKE con % per cercare ovunque nel testo
                string query = "SELECT * FROM Prodotti WHERE Nome LIKE @ricerca OR Prezzo LIKE @ricerca"; //"SELECT * FROM Prodotti WHERE Nome LIKE @ricerca";
                SqlDataAdapter da = new SqlDataAdapter(query, con);

                // Aggiungiamo i simboli % al parametro
                da.SelectCommand.Parameters.AddWithValue("@ricerca", "%" + termineRicerca + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDati.DataSource = dt;
            }
        }

        // Funzione per aggiornare i filtri di ricerca e ordinamento
        private void AggiornaFiltri()
        {
            using (SqlConnection con = new SqlConnection(Utility.connStringProdotti))
            {
                // 1. Base della query
                string query = "SELECT * FROM Prodotti WHERE Nome LIKE @ricerca";

                // 2. Aggiunta dell'ordinamento in base alla ComboBox
                string ordine = cmbOrdinamento.SelectedItem?.ToString();
                switch (ordine)
                {
                    case "Nome (A-Z)":
                        query += " ORDER BY Nome ASC";
                        break;
                    case "Prezzo (Crescente)":
                        query += " ORDER BY Prezzo ASC";
                        break;
                    case "Prezzo (Decrescente)":
                        query += " ORDER BY Prezzo DESC";
                        break;
                    default:
                        query += " ORDER BY Id DESC"; // Ordinamento predefinito (ultimi inseriti)
                        break;
                }

                SqlCommand cmd = new SqlCommand(query, con);
                // 3. Parametro per la ricerca (usa il valore della TextBox)
                cmd.Parameters.AddWithValue("@ricerca", "%" + txtRicerca.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDati.DataSource = dt;
            }
        }
    }
}
