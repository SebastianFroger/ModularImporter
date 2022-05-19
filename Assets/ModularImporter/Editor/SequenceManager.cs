using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace ModularImporter
{
    public class SequenceManager
    {
        Dictionary<string, string> _sequences;

        public ImportSequence GetNearestSequenceTo(string filePath)
        {
            if (_sequences == null)
                CollectAllSequences();

            var dirPath = filePath;
            ImportSequence result = null;
            while (result == null && dirPath != "Assets")
            {
                dirPath = Directory.GetParent(dirPath).FullName.AsUnityAssetPath();
                if (_sequences.ContainsKey(dirPath))
                {
                    result = (ImportSequence)AssetDatabase.LoadAssetAtPath(_sequences[dirPath], typeof(ImportSequence));
                }
            }

            return result;
        }

        void CollectAllSequences()
        {
            _sequences = new Dictionary<string, string>();

            var guids = AssetDatabase.FindAssets("t: ImportSequence");
            for (int i = 0; i < guids.Length; i++)
            {
                var filePath = AssetDatabase.GUIDToAssetPath(guids[i]);
                _sequences.Add(Path.GetDirectoryName(filePath).AsUnityAssetPath(), filePath);
            }

            Debug.Log($"{this.GetType().Name} - found {_sequences.Count} ImportSequences in project");
        }
    }
}
