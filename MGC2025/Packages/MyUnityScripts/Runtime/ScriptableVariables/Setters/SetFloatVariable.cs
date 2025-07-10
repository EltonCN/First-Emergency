using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{
    [AddComponentMenu("My Unity Scripts/Scriptable Variables/Setters/Set Float Variable")]
    public class SetFloatVariable : SetVariable<FloatVariable, float>
    {

        public void Add(float valueToAdd)
        {
            variable.Value += valueToAdd;
        }

        public void Add(FloatVariable valueToAdd)
        {
            variable.Value += valueToAdd.Value;
        }
    }
}