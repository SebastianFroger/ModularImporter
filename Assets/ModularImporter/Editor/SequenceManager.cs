using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace ModularImporter
{
    public class SequenceManager
    {
        static Dictionary<string, string> _sequences;

        public static ImportSequence GetSequenceFor(string filePath)
        {
            if (_sequences == null)
            {
                CollectAllSequences();
            }

            ImportSequence result = null;
            while (result == null && filePath != Application.dataPath)
            {
                filePath = Directory.GetParent(filePath).FullName.AsRelativePath();
                if (_sequences.ContainsKey(filePath))
                {
                    result = (ImportSequence)AssetDatabase.LoadAssetAtPath(_sequences[filePath], typeof(ImportSequence));
                }
            }

            return result;
        }

        static void CollectAllSequences()
        {
            _sequences = new Dictionary<string, string>();

            var guids = AssetDatabase.FindAssets("t: ImportSequence");
            for (int i = 0; i < guids.Length; i++)
            {
                var filePath = AssetDatabase.GUIDToAssetPath(guids[i]);
                _sequences.Add(Path.GetDirectoryName(filePath).AsRelativePath(), filePath);
            }

            Debug.Log($"SequenceManager - found {_sequences.Count} ImportSequences in project");
        }
    }
}
