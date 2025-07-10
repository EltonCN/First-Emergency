using UnityEngine;
using UnityEditor;

namespace MyUnityScripts
{
    [CustomEditor(typeof(Timer))]
    public class TimerEditor : Editor
    {
        static readonly string[] noDraw = new string[]{
            "randomInterval",
            "randomMinimum",
            "randomMaximum"
        };

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SerializedProperty randomIntervalProperty = serializedObject.FindProperty("randomInterval");

            DrawPropertiesExcluding(serializedObject, noDraw);


            EditorGUILayout.PropertyField(serializedObject.FindProperty("randomInterval"));

            EditorGUI.indentLevel += 1;
            {
                bool showRandomProperties = randomIntervalProperty.boolValue;
                if (showRandomProperties)
                {
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("randomMinimum"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("randomMaximum"));
                }
            }
            EditorGUI.indentLevel -= 1;


            serializedObject.ApplyModifiedProperties();
        }
    }
}
