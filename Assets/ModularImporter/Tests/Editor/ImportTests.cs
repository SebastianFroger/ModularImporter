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
        // A Test behaves as an ordinary method
        [Test]
        public void ImportTestsApplyModelPreset()
        {
            var resetPresetPath = "Assets/ModularImporter/Tests/Editor/TestAssets/Presets/FBXModelReset.preset";
            var resetPreset = AssetDatabase.LoadAssetAtPath<Preset>(resetPresetPath);

            var modelPath = "Assets/ModularImporter/Tests/Editor/TestAssets/Robot Kyle/Model/Robot Kyle.fbx";
            ModelImporter modelImporter = (ModelImporter)AssetImporter.GetAtPath(modelPath);

            if (!resetPreset.ApplyTo(modelImporter))
                Debug.LogError($"Could not apply preset {resetPreset}");
            Assert.IsTrue(modelImporter.importBlendShapes);

            AssetDatabase.ImportAsset(modelPath);
            Assert.IsFalse(modelImporter.importBlendShapes);
        }
    }
}