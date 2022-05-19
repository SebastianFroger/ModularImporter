
public static class StringExtensions
{
    public static string AsUnityAssetPath(this string path)
    {
        var x = path.Replace("\\", "/");
        var c = x.Replace($"{System.IO.Directory.GetCurrentDirectory().Replace("\\", "/")}/", "");
        return c;
    }
}
