using UnityEngine;
using UnityEditor;
using System.IO;

namespace ModularImporter
{
    [CreateAssetMenu(fileName = "Template.ImportSequence.asset", menuName = "Modular Importer/New Import Sequence", order = 1)]
    public class ImportSequence : ScriptableObject
    {
        [Header("Asset Filters")]
        public Object[] validationModules;

        [Header("Import Modules")]
        public Object[] preprocessAssetModules;
        public Object[] preprocessTypedModules;
        public Object[] postprocessTypedModules;
        public bool ExecuteParentSequence;
    }
}