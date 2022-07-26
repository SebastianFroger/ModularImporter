using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;
using System.Collections.Generic;

namespace ModularImporter
{
    public class SequenceProcessor
    {
        // SequenceManager _sequenceManager; // TODO: static to share already found sequences???
        List<ImportSequence> _sequences;

        public SequenceProcessor(AssetImportContext context)
        {
            _sequences = SequenceManager.GetSequencesFor(context.assetPath);

            // TODO: add log about currently processed file and what sequences where found
        }

        public void Run(ImportStep importStep, AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null)
        {
            for (int i = 0; i < _sequences.Count; i++)
            {
                Debug.Log($"START - AssetPath: {context.assetPath} - ImportStep: {importStep} - Sequence: {AssetDatabase.GetAssetPath(_sequences[i])}");

                foreach (var module in GetModules(importStep, _sequences[i]))
                {
                    if (module.script == null)
                        continue;

                    if (module.data is IImportModule)
                    {
                        try
                        {
                            if (!module.data.Run(context, assetImporter, unityObject))
                            {

                                if (_sequences[i].moveToNextOnFailedModule)
                                {
                                    i++;
                                    break;
                                }

                                // TODO: add full stop of file import. or move to next sequence or ignore all errors?
                                return;
                            }
                        }
                        catch (System.Exception e)
                        {
                            // TODO: log and print error
                            Debug.Log($"SequenceProcessor - Failed to run module {module.script.name}.\n{e}");

                            if (_sequences[i].moveToNextOnFailedModule)
                            {
                                i++;
                                break;
                            }

                            return;
                        }
                    }
                }
            }
        }

        static Module[] GetModules(ImportStep importStep, ImportSequence sequence) => importStep switch
        {
            ImportStep.OnPreprocessAsset => sequence.preprocessAssetModules,
            ImportStep.OnPreprocessType => sequence.preprocessTypedModules,
            ImportStep.OnPostprocessType => sequence.postprocessTypedModules,
        };
    }
}