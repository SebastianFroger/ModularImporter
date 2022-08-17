using UnityEngine;
using UnityEditor;
using System;

namespace ModularImporter
{
    [Serializable]
    public class Module
    {
        public bool disable = false;
        public MonoScript script;
        [SerializeReference] public IModule data;
    }
}