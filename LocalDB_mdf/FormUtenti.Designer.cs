namespace LocalDB_mdf
{
    partial class FormUtenti
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
            this.dgvUtenti = new System.Windows.Forms.DataGridView();
            this.txtNuovoUser = new System.Windows.Forms.TextBox();
            this.txtNuovaPass = new System.Windows.Forms.TextBox();
            this.btnAggiungiUtente = new System.Windows.Forms.Button();
            this.btnEliminaUtente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtenti)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUtenti
            // 
            this.dgvUtenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUtenti.Location = new System.Drawing.Point(12, 59);
            this.dgvUtenti.Name = "dgvUtenti";
            this.dgvUtenti.Size = new System.Drawing.Size(482, 224);
            this.dgvUtenti.TabIndex = 0;
            // 
            // txtNuovoUser
            // 
            this.txtNuovoUser.Location = new System.Drawing.Point(12, 33);
            this.txtNuovoUser.Name = "txtNuovoUser";
            this.txtNuovoUser.Size = new System.Drawing.Size(157, 20);
            this.txtNuovoUser.TabIndex = 1;
            // 
            // txtNuovaPass
            // 
            this.txtNuovaPass.Location = new System.Drawing.Point(175, 33);
            this.txtNuovaPass.Name = "txtNuovaPass";
            this.txtNuovaPass.Size = new System.Drawing.Size(157, 20);
            this.txtNuovaPass.TabIndex = 2;
            this.txtNuovaPass.UseSystemPasswordChar = true;
            // 
            // btnAggiungiUtente
            // 
            this.btnAggiungiUtente.Location = new System.Drawing.Point(338, 31);
            this.btnAggiungiUtente.Name = "btnAggiungiUtente";
            this.btnAggiungiUtente.Size = new System.Drawing.Size(75, 23);
            this.btnAggiungiUtente.TabIndex = 3;
            this.btnAggiungiUtente.Text = "Aggiungi Utente";
            this.btnAggiungiUtente.UseVisualStyleBackColor = true;
            this.btnAggiungiUtente.Click += new System.EventHandler(this.btnAggiungiUtente_Click);
            // 
            // btnEliminaUtente
            // 
            this.btnEliminaUtente.Location = new System.Drawing.Point(419, 31);
            this.btnEliminaUtente.Name = "btnEliminaUtente";
            this.btnEliminaUtente.Size = new System.Drawing.Size(75, 23);
            this.btnEliminaUtente.TabIndex = 4;
            this.btnEliminaUtente.Text = "Elimina Utente";
            this.btnEliminaUtente.UseVisualStyleBackColor = true;
            this.btnEliminaUtente.Click += new System.EventHandler(this.btnEliminaUtente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password:";
            // 
            // FormUtenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 293);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminaUtente);
            this.Controls.Add(this.btnAggiungiUtente);
            this.Controls.Add(this.txtNuovaPass);
            this.Controls.Add(this.txtNuovoUser);
            this.Controls.Add(this.dgvUtenti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUtenti";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LocalDB CRUD Demo - Gestione Utenti";
            this.Load += new System.EventHandler(this.FormUtenti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUtenti;
        private System.Windows.Forms.TextBox txtNuovoUser;
        private System.Windows.Forms.TextBox txtNuovaPass;
        private System.Windows.Forms.Button btnAggiungiUtente;
        private System.Windows.Forms.Button btnEliminaUtente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
