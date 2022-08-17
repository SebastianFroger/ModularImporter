using UnityEditor.AssetImporters;
using UnityEditor;

namespace ModularImporter
{
    public interface IImportModule : IModule
    {
        void Run(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null);
    }
}
