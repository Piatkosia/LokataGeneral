using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Lokata.Tools.Pdf
{
    public class PdfDocumentUtils
    {
        public readonly Stream stream;

        public PdfDocumentUtils(Stream stream)
        {
            this.stream = stream;
        }

        public Document GetDefaultDocument(string title)
        {
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4.Rotate());
            Document pdfDoc = new Document(pdf);
            pdfDoc.SetMargins(10, 10, 10, 10);
            Paragraph header = new Paragraph(title)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20);
            //var font = PdfFontFactory.CreateFont("Helvetica", PdfEncodings.CP1257,
            //    PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            //var boldFont = PdfFontFactory.CreateFont("Helvetica-Bold", PdfEncodings.CP1257,
            //                   PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            //var normal = PdfFontFactory.CreateFont("Helvetica", PdfEncodings.CP1257,
            //    PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            return pdfDoc;
        }

        public Stream GetStream(Document document)
        {
            document.Close();
            return stream;
        }
    }
}
