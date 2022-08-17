using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

namespace ModularImporter
{
    public class SequenceManager
    {
        static Dictionary<string, List<ImportSequence>> _sequences = new();

        public static List<ImportSequence> GetSequencesFor(string path)
        {
            List<ImportSequence> result = new();
            var dataPath = Application.dataPath.AsRelativePath();

            while (path != dataPath)
            {
                path = Directory.GetParent(path).FullName.AsRelativePath();

                // check if we already have loaded the sequences in the dir
                if (_sequences.ContainsKey(path))
                {
                    result.AddRange(_sequences[path]);
                    continue;
                }

                // otherwise load them and add them to the dict
                var filesInDir = Directory.GetFiles(path, "*.ImportSequence.asset");
                if (filesInDir.Length > 0)
                {
                    _sequences.Add(path, new());
                    foreach (var fPath in filesInDir)
                    {
                        var scriptableObject = (ImportSequence)AssetDatabase.LoadAssetAtPath(fPath.AsRelativePath(), typeof(ImportSequence));
                        _sequences[path].Add(scriptableObject);
                    }

                    result.AddRange(_sequences[path]);
                }
            }

            result.Reverse();
            return result;
        }
    }
}
