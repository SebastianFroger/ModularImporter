using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

namespace ModularImporter
{
    public class TypeHandler
    {
        static Type[] types;
        static string assemblyName = "ImportScripts";

        public static Type[] GetAssemblyTypes(UnityEngine.Object[] modules)
        {
            List<Type> types = new List<Type>();

            Type[] assemblyTypes = GetTypesFromAssembly(assemblyName);
            foreach (var file in modules)
                foreach (var type in assemblyTypes)
                    if (GetTypeName(type) == file.name)
                        types.Add(type);

            return types.ToArray();
        }

        static Type[] GetTypesFromAssembly(string assemblyName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (assembly.GetName().Name == assemblyName)
                    return assembly.GetTypes();
            return null;
        }

        public static string GetTypeName(Type type)
        {
            string[] typeNameFull = type.FullName?.Split('.');
            string typeNameLast = typeNameFull?[typeNameFull.Length - 1];
            return typeNameLast;
        }
    }
}