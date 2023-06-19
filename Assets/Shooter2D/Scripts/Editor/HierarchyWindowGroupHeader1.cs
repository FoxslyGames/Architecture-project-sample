using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor.Scripts
{
    [InitializeOnLoad]
    public static class HierarchyWindowGroupHeader
    {
        private static Dictionary<string, string> colors = new()
        {
            {"o*", "#1e90ff"},
            {"s*", "#ed9121"},
            {"c*", "#e34234"},
            {"u*", "#1caac9"},
            {"i*", "#009b76"}
        };

        static HierarchyWindowGroupHeader()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject != null)
            {
                Color color = default;
                Color backColor = default;
                string currentKey = default;

                foreach (var key in colors.Keys)
                {
                    if (!gameObject.name.StartsWith(key, System.StringComparison.Ordinal)) continue;

                    if (!gameObject.activeSelf) ColorUtility.TryParseHtmlString("#002137", out color);

                    else ColorUtility.TryParseHtmlString(colors[key], out color);

                    currentKey = key;
                }

                if (color != default)
                {
                    ColorUtility.TryParseHtmlString("#121F26", out backColor);
                    
                    Rect rect = new Rect(selectionRect.x + 3f,
                        selectionRect.y + 2f, selectionRect.width - 6f,
                        selectionRect.height - 4f);

                    EditorGUI.DrawRect(selectionRect, backColor);
                    EditorGUI.DrawRect(rect, color);
                    EditorGUI.DropShadowLabel(rect, gameObject.name.Replace(currentKey, ""));
                }
            }
        }
    }
}