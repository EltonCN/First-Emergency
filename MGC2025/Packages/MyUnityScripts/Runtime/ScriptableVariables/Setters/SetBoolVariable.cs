using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyUnityScripts.ScriptableVariables
{
    [AddComponentMenu("My Unity Scripts/Scriptable Variables/Setters/Set Bool Variable")]
    public class SetBoolVariable : SetVariable<BoolVariable, bool>
    {
        public void Toggle()
        {
            variable.Toggle();
        }
    }
}