using UnityEditor;
using UnityEditor.AssetImporters;

public interface IPreprocessModule
{
    public void Process(AssetImportContext context, AssetImporter assetImporter);
}
