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

            UnityEngine.Object[] modules;
            if (!typedAsset)
                modules = sequence.preprocessAssetModules;
            else
                modules = sequence.preprocessTypedModules;

            foreach (var module in modules)
            {
                // apply preset
                if (module is Preset)
                {
                    ApplyPreset((Preset)module, assetImporter);
                    continue;
                }

                if (module is MonoScript)
                {
                    Type type = _typeHandler.GetType(module.name);
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

            foreach (var module in sequence.postprocessTypedModules)
            {
                // apply preset
                if (module is Preset)
                {
                    ApplyPreset((Preset)module, assetImporter);
                }

                // execute monoscript
                if (module is MonoScript)
                {
                    Type type = _typeHandler.GetType(module.name);
                    var inst = Activator.CreateInstance(type) as IPostprocessModule;
                    inst.Process(context, assetImporter, unityObject);
                }
            }
        }

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