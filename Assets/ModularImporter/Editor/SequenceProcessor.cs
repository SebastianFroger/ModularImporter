using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
using UnityEditor.AssetImporters;

namespace ModularImporter
{
    public class SequenceProcessor
    {
        // SequenceManager _sequenceManager; // TODO: static to share already found sequences???
        ImportSequence _sequence;
        bool _failedValidation;

        public SequenceProcessor(AssetImportContext context)
        {
            _sequence = SequenceManager.GetSequenceFor(context.assetPath);

            // TODO: add log about currently processed file and what sequences where found
        }

        public void Run(ImportStep importStep, AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null)
        {
            if (_failedValidation) return;

            foreach (var module in GetModuleArray(importStep))
            {
                if (module.script == null)
                    continue;

                if (module.script is Preset)
                {
                    Preset preset = (Preset)module.script;
                    if (preset.CanBeAppliedTo(assetImporter))
                    {
                        preset.ApplyTo(assetImporter);
                        Debug.Log($"ModuleProcessor applied Preset {assetImporter}");
                        continue;
                    }

                    // TODO: log and print error
                    Debug.LogError($"ModuleProcessor Preset {preset.name} cannot be applied to {assetImporter}");
                    return;
                }

                if (module.data is IImportModule)
                {
                    try
                    {
                        if (module.data.Run(context, assetImporter, unityObject))
                            continue;

                        if (_sequence.stopOnFailedModule)
                            _failedValidation = true;
                        return;
                    }
                    catch (System.Exception e)
                    {
                        if (_sequence.stopOnFailedModule)
                            _failedValidation = true;

                        // TODO: log and print error
                        Debug.Log($"Failed to run module {module.script.name}.\n{e}");
                    }
                }
            }
        }

        Module[] GetModuleArray(ImportStep importStep) => importStep switch
        {
            ImportStep.OnPreprocessAsset => _sequence.preprocessAssetModules,
            ImportStep.OnPreprocessType => _sequence.preprocessTypedModules,
            ImportStep.OnPostprocessType => _sequence.postprocessTypedModules,
        };
    }
}