using UnityEngine;


public static class StringExtensions
{
    public static string AsUnityAssetPath(this string path)
    {
        return path.Replace("/", "\\").Replace(System.IO.Directory.GetCurrentDirectory() + "\\", "");
    }
}
