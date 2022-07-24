using UnityEditor.AssetImporters;
using UnityEditor;
using UnityEngine;

namespace ModularImporter
{
    public interface IImportModule
    {
        bool Run(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null);
    }
}
