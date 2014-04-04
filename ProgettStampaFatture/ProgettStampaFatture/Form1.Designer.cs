namespace ProgettoStampaFatture
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.intestazioneFatturaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bollaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provinciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoreTrasportoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentualeNoloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imponibileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentualeIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importoIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaleCorrispettivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trasportoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.valoreTrasportoTotale = new System.Windows.Forms.TextBox();
            this.imponibileTotale = new System.Windows.Forms.TextBox();
            this.totaleCorrispettivoTotale = new System.Windows.Forms.TextBox();
            this.importoIvaTotale = new System.Windows.Forms.TextBox();
            this.generaFatturaButton = new System.Windows.Forms.Button();
            this.stampaFatturaButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataFatturaTextBox = new System.Windows.Forms.TextBox();
            this.numeroFatturaTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trasportoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // intestazioneFatturaTextBox
            // 
            this.intestazioneFatturaTextBox.Location = new System.Drawing.Point(530, 30);
            this.intestazioneFatturaTextBox.Multiline = true;
            this.intestazioneFatturaTextBox.Name = "intestazioneFatturaTextBox";
            this.intestazioneFatturaTextBox.Size = new System.Drawing.Size(338, 87);
            this.intestazioneFatturaTextBox.TabIndex = 0;
            this.intestazioneFatturaTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fattura intestata a:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bollaDataGridViewTextBoxColumn,
            this.provinciaDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.valoreTrasportoDataGridViewTextBoxColumn,
            this.percentualeNoloDataGridViewTextBoxColumn,
            this.imponibileDataGridViewTextBoxColumn,
            this.percentualeIVADataGridViewTextBoxColumn,
            this.importoIVADataGridViewTextBoxColumn,
            this.totaleCorrispettivoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.trasportoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(26, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(842, 223);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.Enter += new System.EventHandler(this.dataGridView1_Enter);
            // 
            // bollaDataGridViewTextBoxColumn
            // 
            this.bollaDataGridViewTextBoxColumn.DataPropertyName = "Bolla";
            this.bollaDataGridViewTextBoxColumn.HeaderText = "Bolla";
            this.bollaDataGridViewTextBoxColumn.Name = "bollaDataGridViewTextBoxColumn";
            // 
            // provinciaDataGridViewTextBoxColumn
            // 
            this.provinciaDataGridViewTextBoxColumn.DataPropertyName = "Provincia";
            this.provinciaDataGridViewTextBoxColumn.HeaderText = "Pr.";
            this.provinciaDataGridViewTextBoxColumn.Name = "provinciaDataGridViewTextBoxColumn";
            this.provinciaDataGridViewTextBoxColumn.Width = 30;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.Width = 70;
            // 
            // valoreTrasportoDataGridViewTextBoxColumn
            // 
            this.valoreTrasportoDataGridViewTextBoxColumn.DataPropertyName = "ValoreTrasporto";
            this.valoreTrasportoDataGridViewTextBoxColumn.HeaderText = "Valore Trasporto";
            this.valoreTrasportoDataGridViewTextBoxColumn.Name = "valoreTrasportoDataGridViewTextBoxColumn";
            // 
            // percentualeNoloDataGridViewTextBoxColumn
            // 
            this.percentualeNoloDataGridViewTextBoxColumn.DataPropertyName = "PercentualeNolo";
            this.percentualeNoloDataGridViewTextBoxColumn.HeaderText = "%Nolo";
            this.percentualeNoloDataGridViewTextBoxColumn.Name = "percentualeNoloDataGridViewTextBoxColumn";
            this.percentualeNoloDataGridViewTextBoxColumn.Width = 40;
            // 
            // imponibileDataGridViewTextBoxColumn
            // 
            this.imponibileDataGridViewTextBoxColumn.DataPropertyName = "Imponibile";
            this.imponibileDataGridViewTextBoxColumn.HeaderText = "Imponibile";
            this.imponibileDataGridViewTextBoxColumn.Name = "imponibileDataGridViewTextBoxColumn";
            this.imponibileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // percentualeIVADataGridViewTextBoxColumn
            // 
            this.percentualeIVADataGridViewTextBoxColumn.DataPropertyName = "PercentualeIVA";
            this.percentualeIVADataGridViewTextBoxColumn.HeaderText = "%IVA";
            this.percentualeIVADataGridViewTextBoxColumn.Name = "percentualeIVADataGridViewTextBoxColumn";
            this.percentualeIVADataGridViewTextBoxColumn.Width = 40;
            // 
            // importoIVADataGridViewTextBoxColumn
            // 
            this.importoIVADataGridViewTextBoxColumn.DataPropertyName = "ImportoIVA";
            this.importoIVADataGridViewTextBoxColumn.HeaderText = "Importo IVA";
            this.importoIVADataGridViewTextBoxColumn.Name = "importoIVADataGridViewTextBoxColumn";
            this.importoIVADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totaleCorrispettivoDataGridViewTextBoxColumn
            // 
            this.totaleCorrispettivoDataGridViewTextBoxColumn.DataPropertyName = "TotaleCorrispettivo";
            this.totaleCorrispettivoDataGridViewTextBoxColumn.HeaderText = "Totale Corrispettivo";
            this.totaleCorrispettivoDataGridViewTextBoxColumn.Name = "totaleCorrispettivoDataGridViewTextBoxColumn";
            this.totaleCorrispettivoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // trasportoBindingSource
            // 
            this.trasportoBindingSource.DataSource = typeof(ProgettoStampaFatture.Model.Trasporto);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valore Trasporto";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Imponibile";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Totale Corrispettivo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Importo IVA";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "TOTALI GENERALI";
            // 
            // valoreTrasportoTotale
            // 
            this.valoreTrasportoTotale.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.valoreTrasportoTotale.Location = new System.Drawing.Point(306, 377);
            this.valoreTrasportoTotale.Name = "valoreTrasportoTotale";
            this.valoreTrasportoTotale.ReadOnly = true;
            this.valoreTrasportoTotale.Size = new System.Drawing.Size(118, 20);
            this.valoreTrasportoTotale.TabIndex = 8;
            // 
            // imponibileTotale
            // 
            this.imponibileTotale.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.imponibileTotale.Location = new System.Drawing.Point(306, 403);
            this.imponibileTotale.Name = "imponibileTotale";
            this.imponibileTotale.ReadOnly = true;
            this.imponibileTotale.Size = new System.Drawing.Size(118, 20);
            this.imponibileTotale.TabIndex = 9;
            // 
            // totaleCorrispettivoTotale
            // 
            this.totaleCorrispettivoTotale.BackColor = System.Drawing.SystemColors.HighlightText;
            this.totaleCorrispettivoTotale.Location = new System.Drawing.Point(572, 403);
            this.totaleCorrispettivoTotale.Name = "totaleCorrispettivoTotale";
            this.totaleCorrispettivoTotale.ReadOnly = true;
            this.totaleCorrispettivoTotale.Size = new System.Drawing.Size(118, 20);
            this.totaleCorrispettivoTotale.TabIndex = 11;
            // 
            // importoIvaTotale
            // 
            this.importoIvaTotale.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.importoIvaTotale.Location = new System.Drawing.Point(572, 377);
            this.importoIvaTotale.Name = "importoIvaTotale";
            this.importoIvaTotale.ReadOnly = true;
            this.importoIvaTotale.Size = new System.Drawing.Size(118, 20);
            this.importoIvaTotale.TabIndex = 10;
            // 
            // generaFatturaButton
            // 
            this.generaFatturaButton.Location = new System.Drawing.Point(741, 375);
            this.generaFatturaButton.Name = "generaFatturaButton";
            this.generaFatturaButton.Size = new System.Drawing.Size(127, 23);
            this.generaFatturaButton.TabIndex = 12;
            this.generaFatturaButton.Text = "Genera Fattura";
            this.generaFatturaButton.UseVisualStyleBackColor = true;
            this.generaFatturaButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // stampaFatturaButton
            // 
            this.stampaFatturaButton.Location = new System.Drawing.Point(741, 401);
            this.stampaFatturaButton.Name = "stampaFatturaButton";
            this.stampaFatturaButton.Size = new System.Drawing.Size(127, 23);
            this.stampaFatturaButton.TabIndex = 13;
            this.stampaFatturaButton.Text = "Stampa Fattura";
            this.stampaFatturaButton.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Numero:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Data";
            // 
            // dataFatturaTextBox
            // 
            this.dataFatturaTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dataFatturaTextBox.Location = new System.Drawing.Point(140, 64);
            this.dataFatturaTextBox.Name = "dataFatturaTextBox";
            this.dataFatturaTextBox.Size = new System.Drawing.Size(118, 20);
            this.dataFatturaTextBox.TabIndex = 17;
            // 
            // numeroFatturaTextBox
            // 
            this.numeroFatturaTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.numeroFatturaTextBox.Location = new System.Drawing.Point(140, 23);
            this.numeroFatturaTextBox.Name = "numeroFatturaTextBox";
            this.numeroFatturaTextBox.Size = new System.Drawing.Size(118, 20);
            this.numeroFatturaTextBox.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 443);
            this.Controls.Add(this.dataFatturaTextBox);
            this.Controls.Add(this.numeroFatturaTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stampaFatturaButton);
            this.Controls.Add(this.generaFatturaButton);
            this.Controls.Add(this.totaleCorrispettivoTotale);
            this.Controls.Add(this.importoIvaTotale);
            this.Controls.Add(this.imponibileTotale);
            this.Controls.Add(this.valoreTrasportoTotale);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intestazioneFatturaTextBox);
            this.Name = "Form1";
            this.Text = "Stampa Fatture";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trasportoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox intestazioneFatturaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource trasportoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn bollaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provinciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoreTrasportoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentualeNoloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imponibileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentualeIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importoIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaleCorrispettivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox valoreTrasportoTotale;
        private System.Windows.Forms.TextBox imponibileTotale;
        private System.Windows.Forms.TextBox totaleCorrispettivoTotale;
        private System.Windows.Forms.TextBox importoIvaTotale;
        private System.Windows.Forms.Button generaFatturaButton;
        private System.Windows.Forms.Button stampaFatturaButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox dataFatturaTextBox;
        private System.Windows.Forms.TextBox numeroFatturaTextBox;
    }
}

