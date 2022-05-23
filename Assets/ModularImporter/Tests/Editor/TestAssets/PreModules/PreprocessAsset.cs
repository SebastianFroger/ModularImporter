using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;


namespace ModularImporter
{
    public class PreprocessAsset : IPreprocessModule
    {
        public void Process(AssetImportContext context, AssetImporter assetImporter)
        {
            Debug.Log($"-- Module PreprocessAsset {context.assetPath} {assetImporter}");
        }
    }
}