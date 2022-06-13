using UnityEditor.AssetImporters;
using UnityEditor.AssetImporters;
using UnityEditor;

namespace ModularImporter
{
    public class IsFBXFile : IValidationModule
    {
        public bool Validate(AssetImportContext context, AssetImporter assetImporter)
        {
            return context.assetPath.EndsWith(".fbx");
        }
    }
}