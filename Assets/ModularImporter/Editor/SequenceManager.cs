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
                        _sequences[path].Add((ImportSequence)AssetDatabase.LoadAssetAtPath(fPath.AsRelativePath(), typeof(ImportSequence)));

                    result.AddRange(_sequences[path]);
                }
            }

            result.Reverse();
            return result;
        }

        static List<ImportSequence> GetLoadedSequences(string dirPath)
        {
            if (!_sequences.ContainsKey(dirPath))
            {
                List<ImportSequence> result = new();
                foreach (var path in Directory.GetFiles(dirPath, "*.ImportSequence.asset"))
                    result.Add((ImportSequence)AssetDatabase.LoadAssetAtPath(path.AsRelativePath(), typeof(ImportSequence)));

                _sequences.Add(dirPath, result);
                return result;
            }

            return _sequences[dirPath];
        }
    }
}
