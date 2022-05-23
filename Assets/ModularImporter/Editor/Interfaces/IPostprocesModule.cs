using UnityEditor.AssetImporters;
using UnityEditor;

namespace ModularImporter
{
    public interface IPostprocessModule
    {
        public void Process(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object asset);
    }
}