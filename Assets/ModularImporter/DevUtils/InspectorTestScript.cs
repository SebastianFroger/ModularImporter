using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.AssetImporters;
using System.Reflection;

// https://docs.microsoft.com/en-us/dotnet/api/system.reflection.parameterinfo?view=net-6.0
namespace ModularImporter
{
    public class InspectorTestScript : MonoBehaviour
    {
        public UnityEngine.Object module;

        public TypeHandler _typeHandler;

        public void Run()
        {
            Debug.Log("Running module");
            
            Type type = _typeHandler.GetType(module.name);
            var inst = Activator.CreateInstance(type);
            
            Debug.Log("type is " + inst.GetType().ToString());

            ConstructorInfo[] constrctorInfo = type.GetConstructors();
            foreach (var constructor in constrctorInfo)
            {
                Debug.Log("name " + constructor.Name);

                foreach (var param in constructor.GetParameters())
                {
                    Debug.Log($"type {param.ParameterType} name {param.Name}");
                    
                }
            }
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
                var dataPath = Application.dataPath;
                Debug.Log(dataPath);

                myScript._typeHandler = new ();
                myScript.Run();
            }
        }
    }
}


