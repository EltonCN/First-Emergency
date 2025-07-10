using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

namespace MyUnityScripts.ScriptableVariables
{
    [CustomEditor(typeof(VariableSet))]
    public class VariableSetEditor : Editor
    {
        ReorderableList variablesList;
        SerializedProperty variables;
        VariableSet targetSet;

        static readonly string[] noDraw = new string[]{
            "m_Script",
            "variables"
        };

        void OnEnable()
        {
            targetSet = (VariableSet) serializedObject.targetObject;

            variables = serializedObject.FindProperty("variables");

            variablesList = new(serializedObject, variables, true, true, true, true)
            {
                drawElementCallback = drawElementCallback,
                onAddDropdownCallback = onAddDropdownCallback,
                drawHeaderCallback = drawHeaderCallback
            };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawPropertiesExcluding(serializedObject, noDraw);
            
            variablesList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();

            
            EditorGUILayout.LabelField("Remember: you need to set a Initialize Variables component to initialize the variables with this values.", EditorStyles.wordWrappedMiniLabel);
        }

        void drawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty serializedVariable = variablesList.serializedProperty.GetArrayElementAtIndex(index);

            float width = (rect.width/2)-5;

            Rect fieldRect = new(rect)
            {
                height = EditorGUIUtility.singleLineHeight,
                width = width
            };

            EditorGUI.PropertyField(fieldRect, serializedVariable.FindPropertyRelative("variable"), GUIContent.none);
            
            fieldRect.x += width+5;
            
            EditorGUI.PropertyField(fieldRect, serializedVariable.FindPropertyRelative("initialValue"), GUIContent.none);
        
        }

        void onAddDropdownCallback(Rect buttonRect, ReorderableList list)
        {
            GenericMenu menu = new GenericMenu();

            TypeCache.TypeCollection types = TypeCache.GetTypesDerivedFrom(typeof(VariableInitialValue));
        
            foreach (Type type in types)
            {
                if (type.IsAbstract || type.IsGenericType)
                {
                    continue;
                }

                GUIContent itemContent = new(type.Name);
                menu.AddItem(itemContent, false, addVariableToList, type);
            }

            menu.ShowAsContext();
        }

        void addVariableToList(object type_to_cast)
        {
            Type type = (Type) type_to_cast;

            VariableInitialValue newVariable =(VariableInitialValue) Activator.CreateInstance(type);

            targetSet.variables.Add(newVariable);
            
            serializedObject.ApplyModifiedProperties();
        }

        void drawHeaderCallback(Rect rect)
        {
            float width = (rect.width/2)-5;

            rect.width = width;
            EditorGUI.LabelField(rect, "Variable");
            rect.x += width + 5;
            EditorGUI.LabelField(rect, "Initial value");
        }
    }
}
