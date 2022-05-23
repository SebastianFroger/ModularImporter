using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;

namespace ModularImporter
{
    public class TexturePostprocess : IPostprocessModule
    {
        public void Process(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object asset)
        {
            Debug.Log($"-- Module TexturePostprocess {context.assetPath} {assetImporter} {asset}");
            Debug.Log(TexturePreprocess.sharedVariable);
        }
    }
}
