using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace ModularImporter
{
    public class InspectorTestScript : MonoBehaviour
    {
        public UnityEngine.Object module;

        static SequenceManager _sequenceManager = new SequenceManager();
        static TypeHandler _typeHandler = new TypeHandler();

        public void Run()
        {
            Type type = _typeHandler.GetType(module.name);
            var inst = Activator.CreateInstance(type) as IPreprocessModule;
            
            
        }
    }

    [CustomEditor(typeof(InspectorTestScript))]
    public class InspectorTestScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            InspectorTestScript myScript = (InspectorTestScript)target;
            if (GUILayout.Button("run code"))
            {
                myScript.Run();
            }
        }
    }
}


