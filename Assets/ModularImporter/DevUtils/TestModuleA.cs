using UnityEngine;
using System;

namespace ModularImporter
{
    [Serializable]
    public class TestModuleA : IModule
    {
        public string someNameA;
        public int someIntA;
        public bool someBoolA;

        public void Run()
        {
            Debug.Log("DoSomething TestModuleA");
            Debug.Log(someNameA);
            Debug.Log(someIntA);
            Debug.Log(someBoolA);
        }
    }
}
