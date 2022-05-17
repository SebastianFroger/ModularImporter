using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class InspectorTestScript : MonoBehaviour
{
    public UnityEngine.Object module;

    public void Run()
    {

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


