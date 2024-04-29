namespace Collector.Helpers;

public static class Parsers
{
    public static int ExtractCodeFromUrl(string url)
    {
        string[] parts = url.TrimEnd('/').Split('/');
        return int.TryParse(parts[^1], out int code) ? code : 0;
    }
}