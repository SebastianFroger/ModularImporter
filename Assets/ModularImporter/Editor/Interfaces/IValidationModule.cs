using UnityEditor.AssetImporters;
using UnityEditor;

namespace ModularImporter
{
    public interface IValidationModule
    {
        public bool Validate(AssetImportContext context, AssetImporter assetImporter);
    }
}
