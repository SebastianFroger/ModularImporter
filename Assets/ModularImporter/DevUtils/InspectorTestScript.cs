using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.Presets;
using System.Linq;
using System.Collections.Generic;


[Serializable]
[CreateAssetMenu(fileName = "InspectorTestScript", menuName = "Modular Importer/InspectorTestScript", order = 1)]
public class InspectorTestScript : ScriptableObject
{
    public bool executeOnValidate;

    public List<string> filePaths = new() { "C:/dir1/dir2/file.ext", "C:/dir1/dir2/dir3/file.ext", "C:/dir1/file.ext", "C:/dir1/file2.ext", "C:/dir1/dir2/file2.ext" };

    System.Diagnostics.Stopwatch watch;

    void OnValidate()
    {
        WatchStart();



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
