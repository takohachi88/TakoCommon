using System;
using UnityEditor;
using UnityEngine;

namespace TakoLibEditor.Common
{
    public class TakoLibShaderGui : ShaderGUI
    {
        public enum TabMode
        {
            Basic,
            Advanced,
            Default,
        }
        private static TabMode _tabMode;

        protected virtual string HeaderText => string.Empty;

        public sealed override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            if (!string.IsNullOrEmpty(HeaderText))
            {
                using (new EditorGUILayout.VerticalScope(GUI.skin.box))
                {
                    EditorGUILayout.LabelField(HeaderText, TakoLibEditorUtility.StyleRichTextWrapLabel);
                }
            }

            EditorGUILayout.Space();

            _tabMode = (TabMode)GUILayout.Toolbar((int)_tabMode, Enum.GetNames(typeof(TabMode)));

            using (new EditorGUILayout.VerticalScope(GUI.skin.box))
            {
                switch (_tabMode)
                {
                    case TabMode.Basic: BasicGui(materialEditor, properties); break;
                    case TabMode.Advanced:
                        AdvancedGui(materialEditor, properties);
                        AdvancedCommonGui(materialEditor, properties);
                        break;
                    case TabMode.Default: base.OnGUI(materialEditor, properties); break;
                }
            }
        }

        protected virtual void BasicGui(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            EditorGUILayout.HelpBox("No custom GUI implemented", MessageType.Info);
            base.OnGUI(materialEditor, properties);
        }

        protected virtual void AdvancedGui(MaterialEditor materialEditor, MaterialProperty[] properties)
        {

        }

        private void AdvancedCommonGui(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            materialEditor.RenderQueueField();
            materialEditor.DoubleSidedGIField();
            materialEditor.LightmapEmissionProperty();
            materialEditor.EnableInstancingField();

            Material material = materialEditor.target as Material;
            TakoLibShaderGuiUtility.DrawPassTable(materialEditor, material);
            EditorGUILayout.Space();
            TakoLibShaderGuiUtility.DrawKeywordTable(materialEditor, material);
        }
    }
}