using UnityEngine;
using UnityEditor;
using System;

namespace ModularImporter
{
    [Serializable]
    public class Module
    {
        public MonoScript script;
        [SerializeReference] public IImportModule data;
    }
}