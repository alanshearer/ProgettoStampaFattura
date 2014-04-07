using ProgettoStampaFatture.Model;
using ProgettStampaFatture.PDFGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoStampaFatture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          this.dataGridView1.DataError +=dataGridView1_DataError;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

            //gestisci errore nell'inserimento di un valore
            DataGridView view = (DataGridView)sender;

            if ((anError.Context.HasFlag(DataGridViewDataErrorContexts.Commit)) 
                || (anError.Context.HasFlag(DataGridViewDataErrorContexts.CurrentCellChange))
                || (anError.Context.HasFlag(DataGridViewDataErrorContexts.Parsing)))
            {
                if (view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ValueType == typeof(float))
                {
                    MessageBox.Show("Inserisci un valore numerico.");
                    view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].Value = 0;
                }
                if (view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ValueType == typeof(DateTime))
                {
                    MessageBox.Show("Inserisci una data valida nel formato GG/MM/AAAA.");
                    view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].Value = new DateTime();
                }
            }
            if (anError.Context.HasFlag(DataGridViewDataErrorContexts.LeaveControl))
            {
                MessageBox.Show("Errore nel rilascio del valore");
            }

            if ((anError.Exception) is ConstraintException)
            {
                view.Rows[anError.RowIndex].ErrorText = "Errore";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "Errore";


                anError.ThrowException = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int SelectedColumn = e.ColumnIndex;
            int SelectedRow = e.RowIndex;
            if (SelectedRow < 0)
                return;

            String percentualeNolo = this.dataGridView1.Rows[SelectedRow].Cells["percentualeNoloDataGridViewTextBoxColumn"].FormattedValue.ToString();
            String valoreTrasporto = this.dataGridView1.Rows[SelectedRow].Cells["valoreTrasportoDataGridViewTextBoxColumn"].FormattedValue.ToString();
            String percentualeIVA = this.dataGridView1.Rows[SelectedRow].Cells["percentualeIVADataGridViewTextBoxColumn"].FormattedValue.ToString();
            String imponibile = this.dataGridView1.Rows[SelectedRow].Cells["imponibileDataGridViewTextBoxColumn"].FormattedValue.ToString();
            String importoIVA = this.dataGridView1.Rows[SelectedRow].Cells["importoIVADataGridViewTextBoxColumn"].FormattedValue.ToString();
            String totaleCorrispettivo = this.dataGridView1.Rows[SelectedRow].Cells["totaleCorrispettivoDataGridViewTextBoxColumn"].FormattedValue.ToString();

            float percentualeNoloFloat, valoreTrasportoFloat, percentualeIVAFloat, imponibileFloat, importoIVAFloat, totaleCorrispettivoFloat;
            if (float.TryParse(percentualeNolo, out percentualeNoloFloat) && float.TryParse(valoreTrasporto, out valoreTrasportoFloat))
                this.dataGridView1.Rows[SelectedRow].Cells["imponibileDataGridViewTextBoxColumn"].Value = percentualeNoloFloat * valoreTrasportoFloat / 100;

             if (float.TryParse(imponibile, out imponibileFloat) && float.TryParse(percentualeIVA, out percentualeIVAFloat))
                 this.dataGridView1.Rows[SelectedRow].Cells["importoIVADataGridViewTextBoxColumn"].Value = imponibileFloat * percentualeIVAFloat / 100;

             if (float.TryParse(importoIVA, out importoIVAFloat) && float.TryParse(imponibile, out imponibileFloat))
                 this.dataGridView1.Rows[SelectedRow].Cells["totaleCorrispettivoDataGridViewTextBoxColumn"].Value = imponibileFloat + importoIVAFloat;


             double valoreTrasportoTotaleDouble = 0, imponibileTotaleDouble = 0, importoIvaTotaleDouble = 0, totaleCorrispettivoTotaleDouble = 0;

             for (int i = 0; i < dataGridView1.Rows.Count; ++i)
             {
                 valoreTrasportoTotaleDouble += Convert.ToDouble(dataGridView1.Rows[i].Cells["valoreTrasportoDataGridViewTextBoxColumn"].Value);
                 imponibileTotaleDouble += Convert.ToDouble(dataGridView1.Rows[i].Cells["imponibileDataGridViewTextBoxColumn"].Value);
                 importoIvaTotaleDouble += Convert.ToDouble(dataGridView1.Rows[i].Cells["importoIVADataGridViewTextBoxColumn"].Value);
                 totaleCorrispettivoTotaleDouble += Convert.ToDouble(dataGridView1.Rows[i].Cells["totaleCorrispettivoDataGridViewTextBoxColumn"].Value);

             }

             valoreTrasportoTotale.Text = valoreTrasportoTotaleDouble.ToString("0.00\\€");
             imponibileTotale.Text = imponibileTotaleDouble.ToString("0.00\\€");
             importoIvaTotale.Text = importoIvaTotaleDouble.ToString("0.00\\€");
             totaleCorrispettivoTotale.Text = totaleCorrispettivoTotaleDouble.ToString("0.00\\€");


        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dataGridView1.Columns["percentualeNoloDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "0.00";
            this.dataGridView1.Columns["valoreTrasportoDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "0.00";
            this.dataGridView1.Columns["percentualeIVADataGridViewTextBoxColumn"].DefaultCellStyle.Format = "0.00";
            this.dataGridView1.Columns["imponibileDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "0.00";
            this.dataGridView1.Columns["importoIVADataGridViewTextBoxColumn"].DefaultCellStyle.Format = "0.00";
            this.dataGridView1.Columns["totaleCorrispettivoDataGridViewTextBoxColumn"].DefaultCellStyle.Format = "0.00";


        }



        private void dataFatturaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void numeroFatturaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void generaFatturaButton_Click(object sender, EventArgs e)
        {
            PDFGenerator pdfGenerator = new PDFGenerator();
            Fattura fatturaToPass = new Fattura();
            fatturaToPass.Data = dateTimePicker1.Value;
            fatturaToPass.Causale = causaleTextBox.Text;
            fatturaToPass.Intestatario = intestazioneFatturaTextBox.Text;
            Int64 numeroFattura = 0;
            Int64.TryParse(numeroFatturaTextBox.Text, out numeroFattura);
            fatturaToPass.Numero = numeroFattura;
            DataGridViewRowCollection dgvrCollection = dataGridView1.Rows;
            foreach (DataGridViewRow dgvRow in dgvrCollection)
            {
                if ((dgvRow.Cells[0].Value != null))
                {
                    Trasporto trasportoTemp = new Trasporto();
                    trasportoTemp.Bolla = dgvRow.Cells[0].Value.ToString();
                    trasportoTemp.Provincia = dgvRow.Cells[1].Value.ToString();
                    trasportoTemp.Data = DateTime.Parse(dgvRow.Cells[2].Value.ToString());
                    trasportoTemp.ValoreTrasporto = float.Parse(dgvRow.Cells[3].Value.ToString());
                    trasportoTemp.PercentualeNolo = float.Parse(dgvRow.Cells[4].Value.ToString());
                    trasportoTemp.Imponibile = float.Parse(dgvRow.Cells[5].Value.ToString());
                    trasportoTemp.PercentualeIVA = float.Parse(dgvRow.Cells[6].Value.ToString());
                    trasportoTemp.ImportoIVA = float.Parse(dgvRow.Cells[7].Value.ToString());
                    trasportoTemp.TotaleCorrispettivo = float.Parse(dgvRow.Cells[8].Value.ToString());

                    fatturaToPass.Trasporti.Add(trasportoTemp);
                }

            }

            pdfGenerator.GeneraPDFFattura(fatturaToPass);

        }

        private void stampaFatturaButton_Click(object sender, EventArgs e)
        {
            PDFGenerator pdfGenerator = new PDFGenerator();
            Fattura fatturaToPass = new Fattura();
            fatturaToPass.Data = dateTimePicker1.Value;
            fatturaToPass.Causale = causaleTextBox.Text;
            fatturaToPass.Intestatario = intestazioneFatturaTextBox.Text;
            Int64 numeroFattura = 0;
            Int64.TryParse(numeroFatturaTextBox.Text, out numeroFattura);
            fatturaToPass.Numero = numeroFattura;
            DataGridViewRowCollection dgvrCollection = dataGridView1.Rows;
            foreach (DataGridViewRow dgvRow in dgvrCollection)
            {
                if ((dgvRow.Cells[0].Value != null))
                {
                    Trasporto trasportoTemp = new Trasporto();
                    trasportoTemp.Bolla = dgvRow.Cells[0].Value.ToString();
                    trasportoTemp.Provincia = dgvRow.Cells[1].Value.ToString();
                    trasportoTemp.Data = DateTime.Parse(dgvRow.Cells[2].Value.ToString());
                    trasportoTemp.ValoreTrasporto = float.Parse(dgvRow.Cells[3].Value.ToString());
                    trasportoTemp.PercentualeNolo = float.Parse(dgvRow.Cells[4].Value.ToString());
                    trasportoTemp.Imponibile = float.Parse(dgvRow.Cells[5].Value.ToString());
                    trasportoTemp.PercentualeIVA = float.Parse(dgvRow.Cells[6].Value.ToString());
                    trasportoTemp.ImportoIVA = float.Parse(dgvRow.Cells[7].Value.ToString());
                    trasportoTemp.TotaleCorrispettivo = float.Parse(dgvRow.Cells[8].Value.ToString());

                    fatturaToPass.Trasporti.Add(trasportoTemp);
                }

            }

            if (bonificoCheckBox.Checked)
            {
                fatturaToPass.Pagamenti.Add(Pagamento.Bonifico);
            }
            if (contantiCheckBox.Checked)
            {
                fatturaToPass.Pagamenti.Add(Pagamento.Contanti);
            }
            if (assegnoCheckBox.Checked)
            {
                fatturaToPass.Pagamenti.Add(Pagamento.Assegno);
            }

            pdfGenerator.StampaFattura(fatturaToPass);
        }


    }
}
