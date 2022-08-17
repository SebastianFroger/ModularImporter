using UnityEditor.AssetImporters;
using UnityEditor;

namespace ModularImporter
{
    public interface IValidationModule : IModule
    {
        public bool Validate(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null);
    }
}