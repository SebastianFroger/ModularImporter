using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine.TestTools;

namespace ModularImporter
{
    public class ImportTests
    {
        static string resetPresetPath = "Assets/ModularImporter/Tests/Editor/TestAssets/Presets/FBXModelReset.preset";
        static Preset resetPreset = AssetDatabase.LoadAssetAtPath<Preset>(resetPresetPath);

        static string modelPath = "Assets/ModularImporter/Tests/Editor/TestAssets/Robot Kyle/Model/Robot Kyle.fbx";
        static ModelImporter modelImporter = (ModelImporter)AssetImporter.GetAtPath(modelPath);

        internal static bool preprocessModuleExecuted = false;
        internal static bool postprocessModuleExecuted = false;

        [OneTimeSetUp]
        public void ResetImportAsset()
        {
            if (!resetPreset.ApplyTo(modelImporter))
                Debug.LogError($"Could not apply preset {resetPreset}");

            Assert.IsTrue(modelImporter.importBlendShapes);
            Assert.IsTrue(modelImporter.optimizeMeshPolygons);

            AssetDatabase.ImportAsset(modelPath);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void ApplyModelPreset()
        {
            Assert.IsFalse(modelImporter.importBlendShapes);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void ApplyPreprocessModule()
        {
            Assert.IsTrue(preprocessModuleExecuted);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void ApplyPostprocessModule()
        {
            Assert.IsTrue(postprocessModuleExecuted);
        }
    }
}