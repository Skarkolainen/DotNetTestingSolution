using HandlebarsDotNet;

namespace TestingHtmlToPdfLibraries;

internal static class InsertMergeValues
{
    public static string InsertMergeValueses(this string htmlString, object fields)
    {
        var template = Handlebars.Compile(htmlString);
        return template(fields);
    }
}
