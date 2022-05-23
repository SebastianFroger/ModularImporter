using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace ModularImporter
{

    public class TypeHandlerTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void GetTypeTest()
        {
            var typeHandler = new TypeHandler();
            var result = typeHandler.GetType("TypeHandler");
            Assert.AreSame(result.FullName, typeof(TypeHandler).FullName);
        }
    }
}