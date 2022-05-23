using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;

namespace ModularImporter
{
    public class TypeHandler
    {
        static List<Type> _types;
        static string libraryPath = $"{Application.dataPath.Replace("Assets", "")}Library/ScriptAssemblies".Replace("/", @"\");

        public TypeHandler()
        {
            CollectTypesFromAllAssemblies();
        }

        public Type GetType(string typeName)
        {
            return _types.Find(t => GetTypeName(t) == typeName);
        }

        static void CollectTypesFromAllAssemblies()
        {
            _types = new List<Type>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!assembly.Location.StartsWith(libraryPath))
                    continue;

                _types.AddRange(assembly.GetTypes());
            }
        }

        static string GetTypeName(Type type)
        {
            return type.FullName?.Split('.').Last();
        }
    }
}