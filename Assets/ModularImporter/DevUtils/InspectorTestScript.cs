using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.Presets;
using System.Linq;

namespace ModularImporter
{
    [Serializable]
    [CreateAssetMenu(fileName = "InspectorTestScript", menuName = "Modular Importer/InspectorTestScript", order = 1)]
    public class InspectorTestScript : ScriptableObject
    {
        public bool executeOnValidate;

        void OnValidate()
        {


        }

    }
}