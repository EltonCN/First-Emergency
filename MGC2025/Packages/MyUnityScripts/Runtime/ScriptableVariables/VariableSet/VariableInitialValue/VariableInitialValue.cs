using System.Collections.Generic;
using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{
    [System.Serializable]
    public abstract class VariableInitialValue
    {
        public abstract void InitializeVariable();
    }

    [System.Serializable]
    public class VariableInitialValue<VariableType, ValueType> : VariableInitialValue
    where VariableType : ScriptableVariable<ValueType>
    {
        public VariableType variable;
        public ValueType initialValue;

        public override void InitializeVariable()
        {
            variable.Value = initialValue;
        }
    }
}