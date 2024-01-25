using iText.Layout.Element;
using Lokata.Domain;
using Lokata.Tools.Pdf;
using Document = iText.Layout.Document;

namespace Lokata.Tools.PdfDomainObjects
{
    public class CompetitorsListPdf
    {
        private readonly Document document;
        private readonly MemoryStream stream;

        public CompetitorsListPdf()
        {
            stream = new MemoryStream();
            var pdfDocumentUtils = new PdfDocumentUtils(stream);
            document = pdfDocumentUtils.GetDefaultDocument("Lista uczestników");
        }

        public byte[] GetPdf(IEnumerable<Competitor> competitors)
        {
            document.Add(new Paragraph("Uczestnicy zawodów:"));
            document.Add(new Paragraph(System.Environment.NewLine));
            if (competitors.Any())
            {
                var table = new Table(4);
                table.AddHeaderCell("Lp.");
                table.AddHeaderCell("Imię i nazwisko");
                table.AddHeaderCell("Płeć");
                table.AddHeaderCell("Wiek");
                int i = 1;
                foreach (var competitor in competitors)
                {
                    table.AddCell(i.ToString());
                    table.AddCell(competitor.FullName);
                    table.AddCell(competitor.Sex.Name);
                    table.AddCell(competitor.Age.ToString());
                    i++;
                }
                document.Add(table);
            }
            else
            {
                document.Add(new Paragraph("Brak uczestników"));
            }

            document.Close();
            return stream.ToArray();
        }
    }
}
