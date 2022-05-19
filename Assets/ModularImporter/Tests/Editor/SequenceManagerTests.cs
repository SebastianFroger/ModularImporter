using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using System.IO;
using ModularImporter;

namespace ModularImporter.Tests
{
    public class SequenceManagerTests
    {
        [Test]
        public void GetSequenceInDir()
        {
            var assetPath = "Assets/ModularImporter/Tests/Editor/TestAssets/Robot Kyle/Model/Robot Kyle.fbx";
            var sequencePath = "Assets/ModularImporter/Tests/Editor/TestAssets/Robot Kyle/Model/ModularImportSequence.ImportSequence.asset";
            var result = new SequenceManager().GetNearestSequenceTo(assetPath);
            Assert.AreEqual(sequencePath, AssetDatabase.GetAssetPath(result));
        }

        [Test]
        public void GetSequenceInParentDir()
        {
            var assetPath = "Assets/ModularImporter/Tests/Editor/TestAssets/Robot Kyle/Textures/Robot_Normal.tga";
            var sequencePath = "Assets/ModularImporter/Tests/Editor/TestAssets/Robot Kyle/ModularImportSequence.ImportSequence.asset";
            var result = new SequenceManager().GetNearestSequenceTo(assetPath);
            Assert.AreEqual(sequencePath, AssetDatabase.GetAssetPath(result));
        }
    }
}