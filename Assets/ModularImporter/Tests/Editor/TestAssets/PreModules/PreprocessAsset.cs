using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;
using ModularImporter;

public class PreprocessAsset : IPreprocessModule
{
    public void Process(AssetImportContext context, AssetImporter assetImporter)
    {
        Debug.Log($"-- Module PreprocessAsset {context.assetPath} {assetImporter}");
    }
}