using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using PuppeteerSharp.Media;
using PuppeteerSharp;

namespace TestingHtmlToPdfLibraries.Services;

class PdfService : IPdfService, IDisposable
{
    private readonly IBrowser _browser;
    public PdfService()
    {
        var browserFetcher = new BrowserFetcher();
        browserFetcher.DownloadAsync().GetAwaiter().GetResult();

        _browser = Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        }
        ).GetAwaiter().GetResult();
    }

    public async Task<Stream> ConvertToPdfStreamAsync(string htmlContent)
    {
        await using var page = await _browser.NewPageAsync();
        await page.SetContentAsync(htmlContent);

        // Generate the PDF into a memory stream

        var margin = 5;

        var pdfStream = await page.PdfStreamAsync(new PdfOptions
        {
            Format = PaperFormat.A4,
            DisplayHeaderFooter = true,
            MarginOptions = new MarginOptions
            {
                Top = $"{margin}mm",
                Right = $"{margin}mm",
                Bottom = $"{margin}mm",
                Left = $"{margin}mm",
            },
            FooterTemplate = "<div id=\"footer-template\" style=\"font-size:10px !important; color:#808080; padding-left:10px\">Footer Text</div>",
        });

        pdfStream.Position = 0; // Reset the stream position to the beginning
        return pdfStream;
    }

    public void AddPdfDocumentInformation(ref Stream pdfStream)
    {
        PdfDocument pdfDocument = PdfReader.Open(pdfStream, PdfDocumentOpenMode.Modify);

        // Modify the PDF metadata (Info dictionary)
        pdfDocument.Info.Title = "My Custom Title";
        pdfDocument.Info.Author = "";
        pdfDocument.Info.Subject = "Generated PDF with Metadata";
        pdfDocument.Info.Keywords = "Addoro:true,Channel:Postal,CustomerId 12345,ID:347563476,Name:Winnie the Winorg,Address1:hundremeterskogen 1,Address2:,PostalCode:0100,City:Skogen";

        MemoryStream result = new MemoryStream();
        pdfDocument.Save(result);

        pdfStream.Dispose();

        result.Position = 0;
        pdfStream = result;
    }

    public void Dispose() => _browser?
                                .DisposeAsync()
                                .GetAwaiter()
                                .GetResult();
}
