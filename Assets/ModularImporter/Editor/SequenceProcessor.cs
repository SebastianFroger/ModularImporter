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
        public static void PreprocessAsset(AssetImportContext context, AssetImporter assetImporter, bool typedAsset)
        {
            // Get Sequence
            var sequence = new SequenceManager().GetNearestSequenceTo(context.assetPath);
            if (sequence == null)
                return;

            // get types from assembly
            List<Type> assemblyTypes = new List<Type>();
            assemblyTypes.AddRange(TypeHandler.GetAssemblyTypes(sequence.preprocessAssetModules));
            assemblyTypes.AddRange(TypeHandler.GetAssemblyTypes(sequence.preprocessTypedModules));
            assemblyTypes.AddRange(TypeHandler.GetAssemblyTypes(sequence.postprocessTypedModules));


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
                }

                // execute monoscript
                if (module is MonoScript)
                {
                    var type = assemblyTypes.Find(t => TypeHandler.GetTypeName(t) == module.name);
                    var inst = Activator.CreateInstance(type) as IPreprocessModule;
                    inst.Process(context, assetImporter);
                }
            }
        }

        public static void PostprocessAsset(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject)
        {
            // Get Sequence and types
            var sequence = new SequenceManager().GetNearestSequenceTo(context.assetPath);
            if (sequence == null)
                return;

            var assemblyTypes = TypeHandler.GetAssemblyTypes(sequence.postprocessTypedModules);
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
                    var type = Array.Find(assemblyTypes, t => TypeHandler.GetTypeName(t) == module.name);
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