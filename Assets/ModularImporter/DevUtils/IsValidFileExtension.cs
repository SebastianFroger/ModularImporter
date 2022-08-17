using UnityEngine;
using UnityEditor.AssetImporters;
using UnityEditor;
using System.IO;
using System.Linq;

namespace ModularImporter
{
    public class IsValidFileExtension : IValidationModule
    {
        public string validExtensions;

        public bool Validate(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null)
        {
            var extension = Path.GetExtension(context.assetPath);
            var isValid = validExtensions.Split(",").Contains(extension);
            Debug.Log($"IsValidFileExtension {isValid} {context.assetPath}");
            return isValid;
        }
    }
}
