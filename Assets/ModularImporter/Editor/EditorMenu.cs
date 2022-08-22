using UnityEditor;
using UnityEngine;

namespace ModularImporter
{
    [InitializeOnLoad]
    public static class EditorMenu
    {
        private const string MenuName = "ModularImporter/Enabled";

        internal static bool isEnabled;

        static EditorMenu()
        {
            isEnabled = EditorPrefs.GetBool(MenuName, true);
        }

        [MenuItem(MenuName)]
        private static void ToggleAction()
        {
            isEnabled = !isEnabled;
            EditorPrefs.SetBool(MenuName, isEnabled);
        }

        [MenuItem(MenuName, true)]
        private static bool ToggleActionValidate()
        {
            Menu.SetChecked(MenuName, isEnabled);
            return true;
        }
    }
}