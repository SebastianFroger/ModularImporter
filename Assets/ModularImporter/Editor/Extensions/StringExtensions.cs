using UnityEngine;

namespace ModularImporter
{
    public static class StringExtensions
    {
        public static string AsRelativePath(this string path)
        {
            return path.Replace("\\", "/").Replace($"{System.IO.Directory.GetCurrentDirectory().Replace("\\", "/")}/", "");
        }

        public static string AsAbsolutePath(this string path)
        {
            return path.Replace("Assets", Application.dataPath);
        }
    }
}