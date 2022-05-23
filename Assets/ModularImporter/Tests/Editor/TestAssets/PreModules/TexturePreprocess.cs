using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;

namespace ModularImporter
{
    public class TexturePreprocess : IPreprocessModule
    {
        public static string sharedVariable;

        public void Process(AssetImportContext context, AssetImporter assetImporter)
        {
            Debug.Log($"-- Module TexturePreprocess {context.assetPath} {assetImporter}");
            sharedVariable = this.GetType().Name + " variable found " + context.assetPath;
        }
    }
}
