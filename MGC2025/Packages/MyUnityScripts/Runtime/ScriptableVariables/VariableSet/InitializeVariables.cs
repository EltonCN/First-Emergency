using System.Collections.Generic;
using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{
    [AddComponentMenu("My Unity Scripts/Scriptable Variables/Initiliaze Variables")]
    public class InitializeVariables : MonoBehaviour
    {
        [Tooltip("Variables to initialize.")]
        [SerializeField] List<VariableSet> variableSets;

        [SerializeField] bool destroyItselfAfterSet = true;

        void Awake()
        {
            variableSets.ForEach(variableSet => variableSet.InitializeVariables());

            if(destroyItselfAfterSet)
            {
                Destroy(this);
            }
        }

    }
}