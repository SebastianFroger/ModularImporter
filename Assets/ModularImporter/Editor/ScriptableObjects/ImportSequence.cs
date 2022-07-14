using UnityEngine;
using System;

namespace ModularImporter
{
    [Serializable]
    [CreateAssetMenu(fileName = "Template.ImportSequence.asset", menuName = "Modular Importer/New Import Sequence", order = 1)]
    public class ImportSequence : ScriptableObject
    {
        [Header("Asset Filters")]
        [SerializeField] public Module[] validationModules;
        int validationCount = -1;

        [Header("Import Modules")]
        [SerializeField] public Module[] preprocessAssetModules;
        [SerializeField] public Module[] preprocessTypedModules;
        [SerializeField] public Module[] postprocessTypedModules;
        [SerializeField] public bool ExecuteParentSequence;

        void OnValidate()
        {
            UpdateArray(validationModules, ref validationCount);

            // TODO: add rest of arrays
        }

        void UpdateArray(Module[] modules, ref int count)
        {
            // keep track of previous array length to force an empty item when adding to the array
            if (count != modules.Length)
            {
                if (count != -1 && modules.Length > count)
                    modules[^1] = null;

                count = modules.Length;
            }

            foreach (var module in modules)
            {
                if (module != null && module.script != null && module.data == null)
                {
                    var _typeHandler = new TypeHandler();
                    Type type = _typeHandler.GetType(module.script.name);
                    module.data = Activator.CreateInstance(type) as IModule;
                }
            }
        }
    }
}