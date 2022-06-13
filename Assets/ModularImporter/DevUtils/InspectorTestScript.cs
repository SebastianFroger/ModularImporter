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

        public void Run()
        {

        }
    }
#if UNITY_EDITOR
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
#endif
}


