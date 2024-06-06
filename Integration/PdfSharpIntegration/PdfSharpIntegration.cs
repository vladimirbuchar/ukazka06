using System;

namespace Integration.PdfSharpIntegration
{
    public class PdfSharpIntegration : IPdfSharpIntegration
    {
        public PdfSharpIntegration()
        {

        }

        public Guid HtmlToPdfFile(string html)
        {
            return Guid.Empty;
            /*PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4);
            Guid pdfName = Guid.NewGuid();
            pdf.Save(string.Format("{0}{1}.pdf", _fileRepositoryPath, pdfName));
            return pdfName;*/
        }
    }
}
