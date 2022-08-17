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
        public string stringVariable;
        public Preset somePreset;

        public void Run(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null)
        {
            // your code here
            Debug.Log("--- TestModuleA " + context.assetPath);
        }
    }
}
