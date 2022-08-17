using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;
using System.Collections.Generic;

namespace ModularImporter
{
    public class SequenceProcessor
    {
        static List<ImportSequence> _sequences;

        public static void Run(ImportStep importStep, AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null)
        {
            _sequences = SequenceManager.GetSequencesFor(context.assetPath);

            for (int i = 0; i < _sequences.Count; i++)
            {
                if (_sequences[i].disable)
                    continue;

                Debug.Log($"SequenceProcessor - AssetPath: {context.assetPath} - ImportStep: {importStep} - Sequence: {AssetDatabase.GetAssetPath(_sequences[i])}");

                foreach (var module in GetModules(importStep, _sequences[i]))
                {
                    if (module.script == null || module.disable)
                        continue;

                    if (module.data is IValidationModule)
                    {
                        try
                        {
                            if (!(module.data as IValidationModule).Validate(context, assetImporter, unityObject))
                            {
                                i++;
                                break;
                            }
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogError($"SequenceProcessor - Failed to run module {module.script.name}.\n{e}");
                        }
                    }

                    if (module.data is IImportModule)
                    {
                        try
                        {
                            (module.data as IImportModule).Run(context, assetImporter, unityObject);
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogError($"SequenceProcessor - Failed to run module {module.script.name}.\n{e}");
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