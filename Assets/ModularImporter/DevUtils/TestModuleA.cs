using System;
using UnityEngine;
using UnityEditor.AssetImporters;
using UnityEditor;
using UnityEditor.Presets;

namespace ModularImporter
{
    [Serializable]
    public class TestModuleA : IImportModule
    {
        public string someVariable;
        public Preset somePreset;

        public bool Run(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null)
        {
            // your code here
            Debug.Log("--- TestModuleA " + context.assetPath);
            return true;
        }
    }
}
