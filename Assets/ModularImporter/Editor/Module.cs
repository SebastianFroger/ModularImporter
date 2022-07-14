using UnityEngine;
using System;

namespace ModularImporter
{
    [Serializable]
    public class Module
    {
        public UnityEngine.Object script;
        [SerializeReference] public IModule data;
    }
}