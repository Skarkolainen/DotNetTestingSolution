using System.IO;
using System.Threading.Tasks;

namespace TestingHtmlToPdfLibraries.Services;

public interface IPdfService
{
    Task<Stream> ConvertToPdfStreamAsync(string htmlContent);
    void AddPdfDocumentInformation(ref Stream pdfStream);
}
