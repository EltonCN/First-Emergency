using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{
    [AddComponentMenu("My Unity Scripts/Scriptable Variables/Setters/Set Int Variable")]
    public class SetIntVariable : SetVariable<IntVariable, int>
    {

        public void Add(int valueToAdd)
        {
            variable.Value += valueToAdd;
        }

        public void Add(IntVariable valueToAdd)
        {
            variable.Value += valueToAdd.Value;
        }
    }
}