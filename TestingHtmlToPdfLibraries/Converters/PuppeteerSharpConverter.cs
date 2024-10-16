using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace TestingHtmlToPdfLibraries.Converters;

internal class PuppeteerSharpConverter : IHtmlToPdfConverter
{
    public static async Task<Stream> ConvertToPdfAsync(string htmlContent)
    {
        var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();

        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
        await using var page = await browser.NewPageAsync();
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
}