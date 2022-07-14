using System;
using UnityEngine;

namespace ModularImporter
{
    [Serializable]
    public class TestModuleA1 : IModule
    {
        public float somefloatA1;
        public bool someboolA1;

        public void Run()
        {
            Debug.Log("DoSomething TestModuleA1");
            Debug.Log(somefloatA1);
            Debug.Log(someboolA1);
        }
    }
}
