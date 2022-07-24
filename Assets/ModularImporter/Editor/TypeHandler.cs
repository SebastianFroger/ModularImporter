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
        static string _libraryPath = $"{Application.dataPath.Replace("Assets", "")}Library/ScriptAssemblies".Replace("/", @"\");

        public TypeHandler()
        {
            CollectTypesFromAllAssemblies();
            Debug.Log($"TypeHandler - Loaded types from {_libraryPath}");
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
                if (!assembly.Location.StartsWith(_libraryPath))
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