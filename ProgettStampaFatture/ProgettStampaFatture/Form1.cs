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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //String currentVal = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
            //if ((currentVal == "0.00") || (currentVal == "0,00") || (currentVal == "0"))
            //    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]. = true;
            
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
