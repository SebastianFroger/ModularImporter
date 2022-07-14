using UnityEngine;
using System;
using UnityEditor;
using UnityEditor.Presets;
using UnityEditor.AssetImporters;
using System.Collections.Generic;

namespace ModularImporter
{
    public class SequenceProcessor
    {
        static SequenceManager _sequenceManager = new SequenceManager();
        static TypeHandler _typeHandler = new TypeHandler();

        public static void PreprocessAsset(AssetImportContext context, AssetImporter assetImporter, bool typedAsset)
        {
            // Get Sequence
            var sequence = _sequenceManager.GetNearestSequenceTo(context.assetPath);
            if (sequence == null)
                return;

            if (!IsValidAsset(context, assetImporter, sequence))
                return;

            Module[] modules;
            if (!typedAsset)
                modules = sequence.preprocessAssetModules;
            else
                modules = sequence.preprocessTypedModules;

            foreach (var module in modules)
            {
                if (module.script is Preset)
                    ApplyPreset((Preset)module.script, assetImporter);

                if (module.script is MonoScript)
                {
                    Type type = _typeHandler.GetType(module.script.name);
                    var inst = Activator.CreateInstance(type) as IPreprocessModule;
                    inst.Process(context, assetImporter);
                }
            }
        }

        public static void PostprocessAsset(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject)
        {
            // Get Sequence and types
            var sequence = _sequenceManager.GetNearestSequenceTo(context.assetPath);
            if (sequence == null)
                return;

            if (!IsValidAsset(context, assetImporter, sequence))
                return;

            foreach (var module in sequence.postprocessTypedModules)
            {
                if (module.script is Preset)
                    ApplyPreset((Preset)module.script, assetImporter);

                if (module.script is MonoScript)
                {
                    Type type = _typeHandler.GetType(module.script.name);
                    var inst = Activator.CreateInstance(type) as IPostprocessModule;
                    inst.Process(context, assetImporter, unityObject);
                }
            }
        }

        static bool IsValidAsset(AssetImportContext context, AssetImporter assetImporter, ImportSequence sequence)
        {
            foreach (var module in sequence.validationModules)
            {
                if (module.data is IValidationModule)
                {
                    Debug.Log("is IValidationModule");
                    // if ((IValidationModule)module.data.Run(context, assetImporter))
                    //     return false;
                }
            }

            return true;
        }


        // static bool IsValidAsset(AssetImportContext context, AssetImporter assetImporter, ImportSequence sequence)
        // {
        //     foreach (var module in sequence.validationModules)
        //     {
        //         if (module.script is MonoScript)
        //         {
        //             Type type = _typeHandler.GetType(module.script.name);
        //             var inst = Activator.CreateInstance(type) as IValidationModule;
        //             if (!inst.Validate(context, assetImporter))
        //                 return false;
        //         }
        //     }

        //     return true;
        // }

        static void ApplyPreset(Preset preset, UnityEngine.Object asset)
        {
            if (!preset.CanBeAppliedTo(asset))
            {
                Debug.LogError($"ModuleProcessor Preset {preset.name} cannot be applied to {asset}");
                return;
            }

            preset.ApplyTo(asset);
            Debug.Log($"ModuleProcessor applied Preset {asset}");
        }
    }
}