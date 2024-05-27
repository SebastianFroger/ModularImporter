# ModularImporter

This prototype project is an attempt to avoid complex AssetPostProcessing scripts, and create a more reusable and userfriendly import system in unity. It is a visual and modular way of defining the settings and presets, applied to an asset during import. Once a coder has written a module, it can be used by any user through the editor.

By adding an ImportSequence asset file in a project directory, all files in the directory, and subdirectories, will execute the modules referenced into the ImportSequence.
The modules are small generic scripts, that define the changes to apply to the imported file.
The ImportSequence has a filtering step, that can reference modules used to sort what files should be affected during import.


'''
using System;
using UnityEngine;
using UnityEditor.AssetImporters;
using UnityEditor;
using UnityEditor.Presets;

namespace ModularImporter
{
    [Serializable]
    public class TestModuleA : IImportModule
    {
        public string stringVariable;
        public Preset somePreset;

        public void Run(AssetImportContext context, AssetImporter assetImporter, UnityEngine.Object unityObject = null)
        {
            // your code here
            Debug.Log("--- TestModuleA " + context.assetPath);
        }
    }
}

'''
