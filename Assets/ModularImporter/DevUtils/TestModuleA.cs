using System;
using UnityEngine;
using UnityEditor.AssetImporters;
using UnityEditor;

namespace ModularImporter
{
    [Serializable]
    public class TestModuleA : IImportModule
    {
        public string someNameA;
        public int someIntA;
        public bool someBoolA;

        public bool Run(AssetImportContext context, AssetImporter assetImporter, GameObject gameObject = null)
        {
            // your code here
            Debug.Log("TestModuleA " + context.assetPath);
            throw new Exception("module exception");
        }
    }
}
