using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;

namespace ModularImporter
{
    public class ModelsPreprocess : IPreprocessModule
    {
        public static string sharedVariable;
        public void Process(AssetImportContext context, AssetImporter assetImporter)
        {
            ImportTests.preprocessModuleExecuted = true;
            Debug.Log($"-- Module ModelsPreprocess {context.assetPath} {assetImporter}");
        }
    }
}