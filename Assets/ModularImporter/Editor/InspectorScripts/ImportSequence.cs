using UnityEngine;
using System;
using UnityEditor.Presets;
using System.Linq;

namespace ModularImporter
{
    [Serializable]
    [CreateAssetMenu(fileName = "Template.ImportSequence.asset", menuName = "Modular Importer/New Import Sequence", order = 1)]
    public class ImportSequence : ScriptableObject
    {
        // TODO: add description
        [Header("Settings")]
        [SerializeField] public bool disable;

        [Header("Import Modules")]
        [SerializeField] public Module[] preprocessAssetModules;
        int preprocessAssetModulesCount = -1;

        [SerializeField] public Module[] preprocessTypedModules;
        int preprocessTypedModulesCount = -1;

        [SerializeField] public Module[] postprocessTypedModules;
        int postprocessTypedModulesCount = -1;

        static TypeHandler _typeHandler;

        void OnValidate()
        {
            if (_typeHandler == null)
                _typeHandler = new TypeHandler();

            UpdateModules(preprocessAssetModules, ref preprocessAssetModulesCount);
            UpdateModules(preprocessTypedModules, ref preprocessTypedModulesCount);
            UpdateModules(postprocessTypedModules, ref postprocessTypedModulesCount);
        }

        void UpdateModules(Module[] modules, ref int count)
        {
            // add empty module when expanding the inspector list
            if (count != modules.Length)
            {
                if (count != -1 && modules.Length > count)
                    modules[^1] = null;

                count = modules.Length;
            }

            foreach (var module in modules)
            {
                if (module == null)
                    continue;

                if (module.script == null)
                {
                    module.data = null;
                    continue;
                }

                if (module.data == null || module.script.name != module.data.GetType().ToString().Split(".").Last())
                {
                    Type type = _typeHandler.GetType(module.script.name);
                    if (type.GetInterfaces().Contains(typeof(IImportModule)))
                    {
                        module.data = Activator.CreateInstance(type) as IImportModule;
                        continue;
                    }

                    if (type.GetInterfaces().Contains(typeof(IValidationModule)))
                    {
                        module.data = Activator.CreateInstance(type) as IValidationModule;
                        continue;
                    }

                    Debug.LogError($"ImportSequence - {module.script.name} must implement IImportModule or IValidationModul");
                    module.script = null;
                }
            }
        }
    }
}