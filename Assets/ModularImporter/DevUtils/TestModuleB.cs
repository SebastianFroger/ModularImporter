using System;
using UnityEngine;
using UnityEditor.AssetImporters;
using UnityEditor;

namespace ModularImporter
{
    [Serializable]
    public class TestModuleB : IImportModule
    {
        public float somefloatA1;
        public bool someboolA1;

        public bool Run(AssetImportContext context, AssetImporter assetImporter, GameObject gameObject = null)
        {
            Debug.Log("TestModuleB " + context.assetPath);
            return true;
        }
    }
}
