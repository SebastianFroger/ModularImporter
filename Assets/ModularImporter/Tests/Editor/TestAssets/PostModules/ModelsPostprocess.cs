using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;

namespace ModularImporter
{
    public class ModelsPostprocess : IPostprocessModule
    {
        public void Process(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object asset)
        {
            ImportTests.postprocessModuleExecuted = true;
            Debug.Log($"-- Module ModelsPostprocess {context.assetPath} {assetImporter} {asset.name}");
        }
    }
}