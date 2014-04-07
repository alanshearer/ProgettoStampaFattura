using iTextSharp.text;
using iTextSharp.text.pdf;
using ProgettoStampaFatture.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettStampaFatture.PDFGenerator
{
    public class PDFGenerator
    {
        public const float tableWidth = 540f;
        public const int tableWidthPercentage = 90;

        public const float SpacingBefore = 10f;
        public const float SpacingAfter = 10f;


        public String GeneraPDFFattura(Fattura fattura, Boolean stampa = false)
        {
            String NomeFattura = "Fattura";
            if (fattura.Data != null)
                NomeFattura += fattura.Data.ToString().Replace("/", "").Replace(" ", "").Replace(".", "").Replace(":", "");

            NomeFattura += ".pdf";

            //String DesktopFolder = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\Desktop";

            String DesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //String DesktopFolder = "C:\\";

            //String CompleteFilePath = Path.Combine(DesktopFolder, NomeFattura);

            //CompleteFilePath.Replace("\\", "/");

            //MessageBox.Show(CompleteFilePath);




            FileStream fs = null;
            try
            {
                Directory.SetCurrentDirectory(DesktopFolder);

                fs = File.Create(NomeFattura);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace + e.Message, e.Message);
            }
            Document doc = new Document(PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            doc.Add(CreateTableIntestazione());
            doc.Add(CreateTableOggetto(fattura));
            doc.Add(CreateTableFromTrasportiList(fattura.Trasporti));
            doc.Add(CreateTableConclusione(fattura, writer));
            doc.Close();

            

            return NomeFattura;
        }


        public static PdfPTable CreateTableIntestazione()
        {
            PdfPTable intestazioneTable = new PdfPTable(2);


            intestazioneTable.TotalWidth = tableWidth;
            intestazioneTable.WidthPercentage = tableWidthPercentage;
            intestazioneTable.LockedWidth = true;

            float[] intestazioneWidths = new float[] { 100f, 440f };

            intestazioneTable.SetWidths(intestazioneWidths);

            intestazioneTable.SpacingAfter = SpacingAfter;
            intestazioneTable.SpacingBefore = SpacingBefore;

            PdfPCell cell;

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance((byte[])converter.ConvertTo(Properties.Resources.autotreno, typeof(byte[])));
            image.ScaleAbsolute(100f, 60f);

            cell = new PdfPCell(image);

            cell.Border = Rectangle.NO_BORDER;

            intestazioneTable.AddCell(cell);



            Font timesNewRoman11 = new Font(Font.FontFamily.TIMES_ROMAN, 11f, Font.BOLD);
            Font timesnewroman9 = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.NORMAL);

            Paragraph par1 = new Paragraph("AUTOTRASPORTI NEAPOLIS – SOCIETA’ COOPERATIVA", timesNewRoman11);

            Paragraph par2 = new Paragraph("SEDE LEGALE IN VIA S.BRIGIDA,51 – 80133 – NAPOLI", timesnewroman9);

            Paragraph par3 = new Paragraph("ISCRITTA AL REGISTRO DELLE IMPRESE DI NAPOLI – PI e CF. : 05696451219", timesnewroman9);

            Paragraph par4 = new Paragraph("ISCRITTA ALL’ALBO NAZIONALE DELLE COOPERATIVE A MUTUALITA’ PREVALENTE N°. A181519", timesnewroman9);

            Paragraph par5 = new Paragraph("ISCRITTA ALL’ALBO AUTOTRASPORTATORI PER CONTO TERZI N°. NA6614252P", timesnewroman9);

            Paragraph par6 = new Paragraph("TEL/FAX 081.759.95.34 -CELL. 32871.25.542 – 320.07.55.294", timesnewroman9);
        
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

        public static PdfPTable CreateTableOggetto(Fattura fatturaToParse)
        {
            PdfPTable oggettoTable = new PdfPTable(4);


            oggettoTable.TotalWidth = tableWidth;
            oggettoTable.WidthPercentage = tableWidthPercentage;
            oggettoTable.LockedWidth = true;

            float[] oggettoWidths = new float[] { 90f, 90f, 90f, 270f };

            oggettoTable.SetWidths(oggettoWidths);


            oggettoTable.SpacingBefore = SpacingBefore;
            oggettoTable.SpacingAfter = SpacingAfter;

            Font timesnewroman9 = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.NORMAL);

            Phrase par0 = new Phrase("FATTURA", timesnewroman9);
            Phrase par1 = new Phrase("Numero", timesnewroman9);
            Phrase par2 = new Phrase("Data", timesnewroman9);
            Phrase par3 = new Phrase("Spett.le", timesnewroman9);
            Phrase par4 = new Phrase("Causale", timesnewroman9);



            PdfPCell cell;


            cell = new PdfPCell(par0);
            cell.Border = Rectangle.NO_BORDER;
            cell.BackgroundColor = new BaseColor(210, 210, 210);

            oggettoTable.AddCell(cell);

            cell = new PdfPCell();
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 3;

            oggettoTable.AddCell(cell);

            cell = new PdfPCell(par1);
            cell.Border = Rectangle.NO_BORDER;

            oggettoTable.AddCell(cell);

            String numeroFattura = "";
            if ((fatturaToParse != null) || (fatturaToParse.Numero != 0))
                numeroFattura = fatturaToParse.Numero.ToString();

            cell = new PdfPCell(new Phrase(numeroFattura, timesnewroman9));
            cell.Border = Rectangle.NO_BORDER;

            oggettoTable.AddCell(cell);

            cell = new PdfPCell(par3);
            cell.Border = Rectangle.NO_BORDER;

            oggettoTable.AddCell(cell);

            cell = new PdfPCell();
            

            String intestatario = "";

            if ((fatturaToParse != null) || (fatturaToParse.Intestatario != null))
                intestatario = fatturaToParse.Intestatario;
            cell.AddElement(new Phrase(intestatario, timesnewroman9));
            cell.BackgroundColor = new BaseColor(210, 210, 210);
            cell.Rowspan = 4;

            oggettoTable.AddCell(cell);



            cell = new PdfPCell(par2);
            cell.Border = Rectangle.NO_BORDER;
            cell.Rowspan = 1;

            oggettoTable.AddCell(cell);


            String data = "";

            if ((fatturaToParse != null) || (fatturaToParse.Data != null))
                data = fatturaToParse.Data.ToShortDateString();
            cell = new PdfPCell(new Phrase(data, timesnewroman9));
            cell.Border = Rectangle.NO_BORDER;

            oggettoTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("", timesnewroman9));
            cell.Border = Rectangle.NO_BORDER;
            oggettoTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("", timesnewroman9));
            cell.Border = Rectangle.NO_BORDER;

            cell.Colspan = 3;

            oggettoTable.AddCell(cell);

            cell = new PdfPCell(new Phrase("", timesnewroman9));
            cell.Border = Rectangle.NO_BORDER;

            cell.Colspan = 3;

            oggettoTable.AddCell(cell);


            cell = new PdfPCell();
            cell.Border = Rectangle.NO_BORDER;

            cell.AddElement(par4);

            oggettoTable.AddCell(cell);

            cell = new PdfPCell();
            cell.Border = Rectangle.NO_BORDER;

            cell.Colspan = 4;

            String causale = "";

            if ((fatturaToParse != null) || (fatturaToParse.Causale != null))
                causale = fatturaToParse.Causale;

            cell.AddElement(new Phrase(causale, timesnewroman9));

            oggettoTable.AddCell(cell);

            return oggettoTable;
        }

        public static PdfPTable CreateTableFromTrasportiList(List<Trasporto> listToParse)
        {
            PdfPTable trasportiListTable = new PdfPTable(9);

            trasportiListTable.TotalWidth = tableWidth;
            trasportiListTable.WidthPercentage = tableWidthPercentage;
            trasportiListTable.LockedWidth = true;

            float[] trasportiListTableWidths = new float[] { 70f, 30f, 70f, 70f, 45f, 70f, 45f, 45f, 70f };

            trasportiListTable.SetWidths(trasportiListTableWidths);

            trasportiListTable.SpacingBefore = SpacingBefore;
            trasportiListTable.SpacingAfter = SpacingAfter;
            

            PdfPCell cell;

            List<String> headers = new List<string>() { "Bolla", "Pr.", "Data", "Valore\nTrasporto", "%Nolo", "Imponibile", "%IVA", "Importo\nIVA", "Totale\nCorrispettivo" };
            
            Font helvetica10 = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.NORMAL);

            foreach (String header in headers)
            {
                cell = new PdfPCell(new Phrase(header, helvetica10));
                cell.BackgroundColor = new BaseColor(180, 180, 180);
                trasportiListTable.AddCell(cell);
            }
          

            foreach (Trasporto trasportoTemp in listToParse)
            {
                cell = new PdfPCell(new Phrase(trasportoTemp.Bolla.ToString(), helvetica10));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.Provincia.ToString(), helvetica10));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.Data.ToShortDateString(), helvetica10));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.ValoreTrasporto.ToString("0.00\\€"), helvetica10));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.PercentualeNolo.ToString("0.00\\%"), helvetica10));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.Imponibile.ToString("0.00\\€"), helvetica10));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.PercentualeIVA.ToString("0.00\\%"), helvetica10));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.ImportoIVA.ToString("0.00\\€"), helvetica10));
                trasportiListTable.AddCell(cell);
                cell = new PdfPCell(new Phrase(trasportoTemp.TotaleCorrispettivo.ToString("0.00\\€"), helvetica10));
                trasportiListTable.AddCell(cell);
            }


            return trasportiListTable;

        }

        public static PdfPTable CreateTableConclusione(Fattura fatturaToParse, PdfWriter writer)
        {
            PdfPTable conclusioneTable = new PdfPTable(6);

            conclusioneTable.TotalWidth = tableWidth;
            conclusioneTable.WidthPercentage = tableWidthPercentage;
            conclusioneTable.LockedWidth = true;

            float[] conclusioneTableWidths = new float[] { 90f, 90f, 90f, 90f, 90f, 90f };

            conclusioneTable.SetWidths(conclusioneTableWidths);

            conclusioneTable.SpacingBefore = SpacingBefore;
            conclusioneTable.SpacingAfter = SpacingAfter;


            Font timesnewroman9 = new Font(Font.FontFamily.TIMES_ROMAN, 9f, Font.NORMAL);

            Paragraph modalita = new Paragraph("MODALITA' DI PAGAMENTO: RIMESSA DIRETTA A 30GG. DATA FATTURA CON:", timesnewroman9);
            Paragraph bonifico = new Paragraph("BONIFICO", timesnewroman9);
            Paragraph contanti = new Paragraph("CONTANTI", timesnewroman9);
            Paragraph assegno = new Paragraph("ASSEGNO", timesnewroman9);
            Paragraph iban = new Paragraph("IBAN PER BONIFICO: IT 10 M 01030 03421 000007804964", timesnewroman9);
            Paragraph ccn = new Paragraph("CCN° 000007804964", timesnewroman9);
            Paragraph istituto = new Paragraph("ISTITUTO BANCARIO: MONTE DEI PASCHI DI SIENA AG. 21", timesnewroman9);
            Paragraph abi = new Paragraph("ABI: 01030", timesnewroman9);
            Paragraph cab = new Paragraph("CAB: 03421", timesnewroman9);
            Paragraph cin = new Paragraph("CIN: M", timesnewroman9);
            Paragraph intestatario = new Paragraph("INTESTATO A: AUTOTRASPORTI NEAPOLIS SOCIETA' COOPERATIVA", timesnewroman9);

            Paragraph totali = new Paragraph("TOTALI GENERALI", timesnewroman9);

            PdfPCell cell;

            float valoreTrasportoTotale = 0, imponibileTotale = 0, importoIvaTotale = 0, totaleCorrispettivoTotale = 0;

            if (fatturaToParse.Trasporti != null)
            {
                foreach (Trasporto trasportoTemp in fatturaToParse.Trasporti)
                {
                    valoreTrasportoTotale += trasportoTemp.ValoreTrasporto;
                    imponibileTotale += trasportoTemp.Imponibile;
                    importoIvaTotale += trasportoTemp.ImportoIVA;
                    totaleCorrispettivoTotale += trasportoTemp.TotaleCorrispettivo;
                }
            }

            Paragraph valoreTrasportoTot = new Paragraph("Valore \n Trasporto", timesnewroman9);
            Paragraph imponibileTot = new Paragraph("Imponibile", timesnewroman9);
            Paragraph importoIvaTot = new Paragraph("Importo \n IVA", timesnewroman9);
            Paragraph totaleCorrispettivoTot = new Paragraph("Totale \n Corrispettivo", timesnewroman9);


            Paragraph valoreTrasportoTotalePar = new Paragraph(valoreTrasportoTotale.ToString("0.00\\€"), timesnewroman9);
            Paragraph imponibileTotalePar = new Paragraph(imponibileTotale.ToString("0.00\\€"), timesnewroman9);
            Paragraph importoIvaTotalePar = new Paragraph(importoIvaTotale.ToString("0.00\\€"), timesnewroman9);
            Paragraph totaleCorrispettivoTotalePar = new Paragraph(totaleCorrispettivoTotale.ToString("0.00\\€"), timesnewroman9);

            cell = new PdfPCell(modalita);
            cell.Border = Rectangle.TOP_BORDER;
            cell.Colspan = 6;
            conclusioneTable.AddCell(cell);


            Font timesnewroman20 = new Font(Font.FontFamily.TIMES_ROMAN, 20f, Font.BOLD);

            PdfPTable NoChoiceTable = new PdfPTable(4);
            PdfPCell NoChoicheTableCell = new PdfPCell(new Phrase(" ", timesnewroman20));
            NoChoicheTableCell.Border = Rectangle.NO_BORDER;
            NoChoiceTable.AddCell(NoChoicheTableCell);
            NoChoicheTableCell.Border = Rectangle.BOX;
            NoChoiceTable.AddCell(NoChoicheTableCell);
            NoChoicheTableCell.Border = Rectangle.NO_BORDER;
            NoChoiceTable.AddCell(NoChoicheTableCell);
            NoChoicheTableCell.Border = Rectangle.NO_BORDER;
            NoChoiceTable.AddCell(NoChoicheTableCell);


            PdfPTable ChoiceTable = new PdfPTable(4);
            PdfPCell ChoicheTableCell = new PdfPCell(new Phrase(" ", timesnewroman20));
            ChoicheTableCell.Border = Rectangle.NO_BORDER;
            ChoiceTable.AddCell(ChoicheTableCell);
            ChoicheTableCell = new PdfPCell(new Phrase("X", timesnewroman20));
            ChoicheTableCell.Border = Rectangle.BOX;
            ChoiceTable.AddCell(ChoicheTableCell);
            ChoicheTableCell = new PdfPCell(new Phrase(" ", timesnewroman20));
            ChoicheTableCell.Border = Rectangle.NO_BORDER;
            ChoiceTable.AddCell(ChoicheTableCell);
            ChoicheTableCell.Border = Rectangle.NO_BORDER;
            ChoiceTable.AddCell(ChoicheTableCell);


            // CELLA SPUNTA BONIFICO

            if (fatturaToParse.Pagamenti.Contains(Pagamento.Bonifico))
            {
                cell = new PdfPCell(ChoiceTable);
            }
            else
            {
                cell = new PdfPCell(NoChoiceTable);
            }

            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            // CELLA SPUNTA CONTANTI

            if (fatturaToParse.Pagamenti.Contains(Pagamento.Contanti))
            {
                cell = new PdfPCell(ChoiceTable);
            }
            else
            {
                cell = new PdfPCell(NoChoiceTable);
            }

            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);


            // CELLA SPUNTA ASSEGNO

            if (fatturaToParse.Pagamenti.Contains(Pagamento.Assegno))
            {
                cell = new PdfPCell(ChoiceTable);
            }
            else
            {
                cell = new PdfPCell(NoChoiceTable);
            }
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell();
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 3;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(bonifico);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(contanti);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(assegno);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell();
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 3;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(iban);
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 6;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(ccn);
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 2;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(istituto);
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 4;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(abi);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(cab);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(cin);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell();
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 3;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(intestatario);
            cell.Border = Rectangle.BOTTOM_BORDER;
            cell.Colspan = 6;
            conclusioneTable.AddCell(cell);


            cell = new PdfPCell();
            cell.Border = Rectangle.NO_BORDER;
            cell.Colspan = 2;
            conclusioneTable.AddCell(cell);



            //inserire qui gli ultimi dettagli

            cell = new PdfPCell(valoreTrasportoTot);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(imponibileTot);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(importoIvaTot);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(totaleCorrispettivoTot);
            cell.Border = Rectangle.NO_BORDER;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(totali);
            cell.Border = Rectangle.BOTTOM_BORDER;
            cell.BackgroundColor = new BaseColor(210, 210, 210);
            cell.Colspan = 2;
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(valoreTrasportoTotalePar);
            cell.Border = Rectangle.BOTTOM_BORDER;
            cell.BackgroundColor = new BaseColor(210, 210, 210); 
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(imponibileTotalePar);
            cell.Border = Rectangle.BOTTOM_BORDER;
            cell.BackgroundColor = new BaseColor(210, 210, 210); 
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(importoIvaTotalePar);
            cell.Border = Rectangle.BOTTOM_BORDER;
            cell.BackgroundColor = new BaseColor(210, 210, 210); 
            conclusioneTable.AddCell(cell);

            cell = new PdfPCell(totaleCorrispettivoTotalePar);
            cell.Border = Rectangle.BOTTOM_BORDER;
            cell.BackgroundColor = new BaseColor(210, 210, 210); 
            conclusioneTable.AddCell(cell);

            return conclusioneTable;
        }



        public void StampaFattura(Fattura fattura)
        {
            String fatturaGenerata = GeneraPDFFattura(fattura, true);
            Process.Start(fatturaGenerata);
        }

        public static void drawRectangle(PdfContentByte content, float width, float height)
        {
            content.SaveState();
            PdfGState state = new PdfGState();
            state.FillOpacity = 0.6f;
            content.SetGState(state);
            content.SetRGBColorFill(0xFF, 0xFF, 0xFF);
            content.SetLineWidth(3);
            content.Rectangle(0, 0, width, height);
            content.FillStroke();
            content.RestoreState();
        }
    }
}
