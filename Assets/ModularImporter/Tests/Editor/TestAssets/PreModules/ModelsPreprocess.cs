using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;
using ModularImporter;

public class ModelsPreprocess : IPreprocessModule
{
    public static string sharedVariable;
    public void Process(AssetImportContext context, AssetImporter assetImporter)
    {
        sharedVariable = this.GetType().Name + " variable found";
        Debug.Log($"-- Module ModelsPreprocess {context.assetPath} {assetImporter}");
    }
}
