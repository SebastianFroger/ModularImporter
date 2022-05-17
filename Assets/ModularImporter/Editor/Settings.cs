using UnityEngine;
using UnityEditor;

namespace ModularImporter
{
    public class Settings
    {
        public static string[] rootDirPaths = { Application.dataPath.Replace("/", "\\") };
        public static string[] ignoredTypes = { ".cs", ".ImportSequence.asset" };
    }
}