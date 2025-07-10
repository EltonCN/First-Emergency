using UnityEngine;
using UnityEditor;

namespace MyUnityScripts.ScriptableVariables
{
    [CustomPropertyDrawer(typeof(VariableField<,>))]
    public class VariableFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty variableProperty = property.FindPropertyRelative("variable");
            SerializedProperty directValueProperty = property.FindPropertyRelative("directValue");

            EditorGUI.BeginProperty(position, label, property);
            {
                position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

                int indent = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;

                float width = (position.width / 2) - 5;


                Rect variableRect = new(position.x, position.y, width, position.height);
                Rect directValueRect = new(position.x + width + 5, position.y, width, position.height);

                EditorGUI.PropertyField(variableRect, variableProperty, GUIContent.none);

                EditorGUI.BeginDisabledGroup(variableProperty.objectReferenceValue);
                {
                    EditorGUI.PropertyField(directValueRect, directValueProperty, GUIContent.none);
                }
                EditorGUI.EndDisabledGroup();

                EditorGUI.indentLevel = indent;
            }
            EditorGUI.EndProperty();
        }
    }
}