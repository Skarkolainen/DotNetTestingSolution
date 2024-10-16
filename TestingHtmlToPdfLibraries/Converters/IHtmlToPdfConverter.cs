namespace TestingHtmlToPdfLibraries.Converters;

public interface IHtmlToPdfConverter
{
    public abstract static Task<Stream> ConvertToPdfAsync(string htmlContent);
}