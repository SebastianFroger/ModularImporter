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
            if (_sequences == null || _sequences.Count == 0)
                CollectAllSequences();

            var dirPath = System.IO.Path.GetDirectoryName(filePath);

            ImportSequence result = null;
            while (result == null)
            {
                if (_sequences.ContainsKey(dirPath))
                {
                    result = (ImportSequence)AssetDatabase.LoadAssetAtPath(dirPath, typeof(ImportSequence));
                    break;
                }
                dirPath = System.IO.Directory.GetParent(dirPath).FullName;
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
                _sequences.Add(Path.GetDirectoryName(filePath), filePath);
            }

            Debug.Log($"{this.GetType().Name} - found {_sequences.Count} ImportSequences in project");
        }
    }
}
