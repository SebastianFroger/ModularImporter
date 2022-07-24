using System;
using UnityEngine;
using UnityEditor.AssetImporters;
using UnityEditor;

namespace ModularImporter
{
    [Serializable]
    public class TestModuleA : IImportModule
    {
        public string someVariable;

        public bool Run(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null)
        {
            // your code here
            Debug.Log("--- TestModuleA " + context.assetPath);
            return true;
        }
    }
}
