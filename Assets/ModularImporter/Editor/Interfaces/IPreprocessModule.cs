using UnityEditor;
using UnityEditor.AssetImporters;

namespace ModularImporter
{
    public interface IPreprocessModule
    {
        public void Process(AssetImportContext context, AssetImporter assetImporter);
    }
}
