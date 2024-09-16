using System;

namespace Integration.PdfSharpIntegration
{
    public interface IPdfSharpIntegration
    {
        Guid HtmlToPdfFile(string html);
    }
}
