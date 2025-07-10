using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{

    [CreateAssetMenu(menuName = "My Unity Scripts/Scriptable Variables/Variable Set", order = -10)]
    public class VariableSet : ScriptableObject
    {
        [SerializeReference] public List<VariableInitialValue> variables = new();


        public void InitializeVariables()
        {
            foreach(VariableInitialValue variable in variables)
            {
                try
                {
                    variable.InitializeVariable();
                }
                catch(NullReferenceException)
                {
                    Debug.LogWarning($"Null variable in {name}");
                }
            }
        }
    }
}