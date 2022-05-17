using UnityEditor.AssetImporters;
using UnityEditor;

public interface IPostprocessModule
{
    public void Process(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object asset);
}