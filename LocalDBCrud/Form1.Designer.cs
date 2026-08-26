namespace LocalDBCrud
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvDati = new System.Windows.Forms.DataGridView();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.numPrezzo = new System.Windows.Forms.NumericUpDown();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.btnAggiorna = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.txtRicerca = new System.Windows.Forms.TextBox();
            this.btnCerca = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbOrdinamento = new System.Windows.Forms.ComboBox();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnEsportaCSV = new System.Windows.Forms.Button();
            this.btnEsportaExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDati)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrezzo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDati
            // 
            this.dgvDati.AllowUserToAddRows = false;
            this.dgvDati.AllowUserToDeleteRows = false;
            this.dgvDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDati.Location = new System.Drawing.Point(13, 164);
            this.dgvDati.Name = "dgvDati";
            this.dgvDati.ReadOnly = true;
            this.dgvDati.Size = new System.Drawing.Size(776, 371);
            this.dgvDati.TabIndex = 0;
            this.dgvDati.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDati_CellClick);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(13, 138);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(355, 20);
            this.txtNome.TabIndex = 1;
            // 
            // numPrezzo
            // 
            this.numPrezzo.Location = new System.Drawing.Point(374, 138);
            this.numPrezzo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrezzo.Name = "numPrezzo";
            this.numPrezzo.Size = new System.Drawing.Size(83, 20);
            this.numPrezzo.TabIndex = 2;
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(471, 135);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(75, 23);
            this.btnInserisci.TabIndex = 3;
            this.btnInserisci.Text = "Inserisci";
            this.btnInserisci.UseVisualStyleBackColor = true;
            this.btnInserisci.Click += new System.EventHandler(this.btnInserisci_Click);
            // 
            // btnAggiorna
            // 
            this.btnAggiorna.Location = new System.Drawing.Point(633, 135);
            this.btnAggiorna.Name = "btnAggiorna";
            this.btnAggiorna.Size = new System.Drawing.Size(75, 23);
            this.btnAggiorna.TabIndex = 4;
            this.btnAggiorna.Text = "Aggiorna";
            this.btnAggiorna.UseVisualStyleBackColor = true;
            this.btnAggiorna.Click += new System.EventHandler(this.btnAggiorna_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(714, 135);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(75, 23);
            this.btnElimina.TabIndex = 5;
            this.btnElimina.Text = "Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // txtRicerca
            // 
            this.txtRicerca.Location = new System.Drawing.Point(13, 63);
            this.txtRicerca.Name = "txtRicerca";
            this.txtRicerca.Size = new System.Drawing.Size(444, 20);
            this.txtRicerca.TabIndex = 6;
            this.txtRicerca.TextChanged += new System.EventHandler(this.txtRicerca_TextChanged);
            // 
            // btnCerca
            // 
            this.btnCerca.Location = new System.Drawing.Point(632, 60);
            this.btnCerca.Name = "btnCerca";
            this.btnCerca.Size = new System.Drawing.Size(75, 23);
            this.btnCerca.TabIndex = 7;
            this.btnCerca.Text = "Cerca";
            this.btnCerca.UseVisualStyleBackColor = true;
            this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(714, 60);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbOrdinamento
            // 
            this.cmbOrdinamento.FormattingEnabled = true;
            this.cmbOrdinamento.Items.AddRange(new object[] {
            "Nome (A-Z)",
            "Prezzo (Crescente)",
            "Prezzo (Decrescente)"});
            this.cmbOrdinamento.Location = new System.Drawing.Point(463, 62);
            this.cmbOrdinamento.Name = "cmbOrdinamento";
            this.cmbOrdinamento.Size = new System.Drawing.Size(163, 21);
            this.cmbOrdinamento.TabIndex = 9;
            this.cmbOrdinamento.SelectedIndexChanged += new System.EventHandler(this.cmbOrdinamento_SelectedIndexChanged);
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(552, 135);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 10;
            this.btnModifica.Text = "Modifica";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnEsportaCSV
            // 
            this.btnEsportaCSV.Location = new System.Drawing.Point(12, 574);
            this.btnEsportaCSV.Name = "btnEsportaCSV";
            this.btnEsportaCSV.Size = new System.Drawing.Size(384, 23);
            this.btnEsportaCSV.TabIndex = 11;
            this.btnEsportaCSV.Text = "Esporta CSV";
            this.btnEsportaCSV.UseVisualStyleBackColor = true;
            this.btnEsportaCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnEsportaExcel
            // 
            this.btnEsportaExcel.Location = new System.Drawing.Point(404, 574);
            this.btnEsportaExcel.Name = "btnEsportaExcel";
            this.btnEsportaExcel.Size = new System.Drawing.Size(384, 23);
            this.btnEsportaExcel.TabIndex = 12;
            this.btnEsportaExcel.Text = "Esporta Excel";
            this.btnEsportaExcel.UseVisualStyleBackColor = true;
            this.btnEsportaExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(775, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 558);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(775, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ordina:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nome:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Prezzo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(775, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Cerca";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Prodotti";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 538);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Esporta";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 615);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEsportaExcel);
            this.Controls.Add(this.btnEsportaCSV);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.cmbOrdinamento);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCerca);
            this.Controls.Add(this.txtRicerca);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnAggiorna);
            this.Controls.Add(this.btnInserisci);
            this.Controls.Add(this.numPrezzo);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.dgvDati);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LocalDB CRUD";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDati)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrezzo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDati;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.NumericUpDown numPrezzo;
        private System.Windows.Forms.Button btnInserisci;
        private System.Windows.Forms.Button btnAggiorna;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.TextBox txtRicerca;
        private System.Windows.Forms.Button btnCerca;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmbOrdinamento;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnEsportaCSV;
        private System.Windows.Forms.Button btnEsportaExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

