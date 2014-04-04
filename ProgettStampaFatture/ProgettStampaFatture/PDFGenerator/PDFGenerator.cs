using iTextSharp.text;
using iTextSharp.text.pdf;
using ProgettoStampaFatture.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettStampaFatture.PDFGenerator
{
    public class PDFGenerator
    {
        public const float tableWidth = 540f;
        public const int tableWidthPercentage = 90;

        public void GeneraPDFFattura(Fattura fattura, Boolean stampa = false)
        {
            String NomeFattura = "Fattura";
            if (fattura.Data != null)
                NomeFattura += fattura.Data.ToString().Replace("/", "");

            var DesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            FileStream fs = new FileStream(DesktopFolder + "\\" + NomeFattura + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document(PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            doc.Add(CreateTableIntestazione());
            doc.Add(CreateTableFromTrasportiList(fattura.Trasporti));
            //doc.Add();
            doc.Close();
        }


        public static PdfPTable CreateTableIntestazione()
        {
            PdfPTable intestazioneTable = new PdfPTable(2);


            intestazioneTable.TotalWidth = tableWidth;
            intestazioneTable.WidthPercentage = tableWidthPercentage;
            intestazioneTable.LockedWidth = true;

            float[] intestazioneWidths = new float[] { 100f, 440f };

            intestazioneTable.SetWidths(intestazioneWidths);

            PdfPCell cell;

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance((byte[])converter.ConvertTo(Properties.Resources.autotreno, typeof(byte[])));
            image.ScaleAbsolute(100f, 60f);

            cell = new PdfPCell(image);

            cell.Border = Rectangle.NO_BORDER;

            intestazioneTable.AddCell(cell);



            Font timesNewRoman11 = new Font(Font.FontFamily.TIMES_ROMAN, 11f, Font.BOLD);
            Font helvetica9 = new Font(Font.FontFamily.HELVETICA, 9f, Font.NORMAL);

            Paragraph par1 = new Paragraph("AUTOTRASPORTI NEAPOLIS – SOCIETA’ COOPERATIVA", timesNewRoman11);

            Paragraph par2 = new Paragraph("SEDE LEGALE IN VIA S.BRIGIDA,51 – 80133 – NAPOLI", helvetica9);

            Paragraph par3 = new Paragraph("ISCRITTA AL REGISTRO DELLE IMPRESE DI NAPOLI – PI e CF. : 05696451219", helvetica9);

            Paragraph par4 = new Paragraph("ISCRITTA ALL’ALBO NAZIONALE DELLE COOPERATIVE A MUTUALITA’ PREVALENTE N°. A181519", helvetica9);

            Paragraph par5 = new Paragraph("ISCRITTA ALL’ALBO AUTOTRASPORTATORI PER CONTO TERZI N°. NA6614252P", helvetica9);

            Paragraph par6 = new Paragraph("TEL/FAX 081.759.95.34 -CELL. 32871.25.542 – 320.07.55.294", helvetica9);
        
            par1.Alignment = 1;
            par2.Alignment = 1;
            par3.Alignment = 1;
            par4.Alignment = 1;
            par5.Alignment = 1;
            par6.Alignment = 1;

            cell = new PdfPCell();
            cell.Border = Rectangle.NO_BORDER;
            cell.AddElement(par1);
            cell.AddElement(par2);
            cell.AddElement(par3);
            cell.AddElement(par4);
            cell.AddElement(par5);
            cell.AddElement(par6);

            intestazioneTable.AddCell(cell);

            return intestazioneTable;

        }

        public static PdfPTable CreateTableFromTrasportiList(List<Trasporto> listToParse)
        {
            PdfPTable trasportiListTable = new PdfPTable(9);

            trasportiListTable.TotalWidth = tableWidth;
            trasportiListTable.WidthPercentage = tableWidthPercentage;
            trasportiListTable.LockedWidth = true;

            float[] trasportiListTableWidths = new float[] { 70f, 30f, 70f, 70f, 45f, 70f, 45f, 45f, 70f };

            trasportiListTable.SetWidths(trasportiListTableWidths);

            trasportiListTable.SpacingBefore = 10f;
            trasportiListTable.SpacingAfter = 10f;
           // table.HeaderRows = 1;
            

            PdfPCell cell;

            List<String> headers = new List<string>() { "Bolla", "Pr.", "Data", "Valore\nTrasporto", "%Nolo", "Imponibile", "%IVA", "Importo\nIVA", "Totale\nCorrispettivo" };
            
            Font helvetica10 = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL);

            foreach (String header in headers)
            {
                cell = new PdfPCell(new Phrase(header, helvetica10));
                cell.BackgroundColor = new BaseColor(180, 180, 180);
                trasportiListTable.AddCell(cell);
            }
            //cell = new PdfPCell(new Phrase("Bolla"));
            //table.AddCell(cell);
            //cell = new PdfPCell(new Phrase("Pr."));
            //table.AddCell(cell);
            //cell = new PdfPCell(new Phrase("Data"));
            //table.AddCell(cell);
            //cell = new PdfPCell(new Phrase("Valore\nTrasporto"));
            //table.AddCell(cell);
            //cell = new PdfPCell(new Phrase("%Nolo"));
            //table.AddCell(cell);
            //cell = new PdfPCell(new Phrase("Imponibile"));
            //table.AddCell(cell);
            //cell = new PdfPCell(new Phrase("%IVA"));
            //table.AddCell(cell);
            //cell = new PdfPCell(new Phrase("Importo\nIVA"));
            //table.AddCell(cell);
            //cell = new PdfPCell(new Phrase("Totale\nCorrispettivo"));
            //table.AddCell(cell);


            foreach (Trasporto trasportoTemp in listToParse)
            {
                cell = new PdfPCell(new Phrase(trasportoTemp.Bolla.ToString()));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.Provincia.ToString()));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.Data.ToShortDateString()));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.ValoreTrasporto.ToString("0.00")));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.PercentualeNolo.ToString("0.00")));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.Imponibile.ToString("0.00")));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.PercentualeIVA.ToString("0.00")));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.ImportoIVA.ToString("0.00")));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.TotaleCorrispettivo.ToString("0.00")));
                trasportiListTable.AddCell(cell);
            }


            return trasportiListTable;

        }


        public static PdfPTable createFirstTable()
        {
            // a table with three columns
            PdfPTable table = new PdfPTable(3);
            table.SpacingBefore = 10f;
            table.SpacingAfter = 10f;

            // the cell object
            PdfPCell cell;
            // we add a cell with colspan 3
            cell = new PdfPCell(new Phrase("Cell with colspan 3"));
            cell.Colspan = 3;
            table.AddCell(cell);
            // now we add a cell with rowspan 2
            cell = new PdfPCell(new Phrase("Cell with rowspan 2"));
            cell.Rowspan = 2;
            table.AddCell(cell);
            // we add the four remaining cells with addCell()
            table.AddCell("row 1; cell 1");
            table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2");
            table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2"); table.AddCell("row 1; cell 2");
            table.AddCell("row 2; cell 1");
            table.AddCell("row 2; cell 2");
            return table;
        }

        public void StampaFattura(Fattura fattura)
        {
            GeneraPDFFattura(fattura, true);
        }
    }
}
