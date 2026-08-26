using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalDB_mdf
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseInitializer.Initialize();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Impossibile inizializzare il database demo. Verificare che SQL Server Express LocalDB sia installato.\n\n" + exception.Message,
                    "LocalDB CRUD Demo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            FormLogin login = new FormLogin();

            // Se il login restituisce OK, allora avviamo l'app principale
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
