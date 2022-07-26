using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
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
            Debug.Log($"SequenceProcessor - ImportStep: {importStep} -  AssetPath: {context.assetPath}");

            foreach (var sequence in _sequences)
            {
                Debug.Log($"SequenceProcessor - Sequence: {AssetDatabase.GetAssetPath(sequence)}");

                foreach (var module in GetModules(importStep, sequence))
                {
                    Debug.Log($"SequenceProcessor - Module: {(module.script == null ? "null" : module.script.name)}");

                    if (module.script == null)
                        continue;

                    if (module.script is Preset)
                    {
                        Preset preset = (Preset)module.script;
                        if (preset.CanBeAppliedTo(assetImporter))
                        {
                            preset.ApplyTo(assetImporter);
                            Debug.Log($"SequenceProcessor - Applied Preset {assetImporter}");
                            continue;
                        }

                        // TODO: log and print error
                        Debug.LogError($"SequenceProcessor - Preset {preset.name} cannot be applied to {assetImporter}");
                        return;
                    }

                    if (module.data is IImportModule)
                    {
                        try
                        {
                            module.data.Run(context, assetImporter, unityObject);
                        }
                        catch (System.Exception e)
                        {
                            // TODO: log and print error
                            Debug.Log($"SequenceProcessor - Failed to run module {module.script.name}.\n{e}");
                        }
                    }
                }
            }
        }

        Module[] GetModules(ImportStep importStep, ImportSequence sequence) => importStep switch
        {
            ImportStep.OnPreprocessAsset => sequence.preprocessAssetModules,
            ImportStep.OnPreprocessType => sequence.preprocessTypedModules,
            ImportStep.OnPostprocessType => sequence.postprocessTypedModules,
        };
    }
}