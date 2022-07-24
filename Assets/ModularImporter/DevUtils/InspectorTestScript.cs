using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.Presets;
using System.Linq;


[Serializable]
[CreateAssetMenu(fileName = "InspectorTestScript", menuName = "Modular Importer/InspectorTestScript", order = 1)]
public class InspectorTestScript : ScriptableObject
{
    public bool executeOnValidate;

    public UnityEngine.Object script;

    System.Diagnostics.Stopwatch watch;

    void OnValidate()
    {
        WatchStart();

        Debug.Log("type " + script.GetType());


        WatchStop();
    }

    void WatchStart()
    {
        watch = new System.Diagnostics.Stopwatch();
        watch.Start();
    }
    void WatchStop()
    {
        watch.Stop();
        Debug.Log($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }
}
