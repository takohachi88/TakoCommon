#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace TakoLib.Editor
{
    public class EditorCommonDefine
    {
        public static GUIStyle StyleRichTextLabel => new GUIStyle(EditorStyles.label)
        {
            richText = true,
        };
    }
}

#endif