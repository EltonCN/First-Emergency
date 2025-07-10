using System;
using UnityEngine;
using UnityEngine.Events;

namespace MyUnityScripts.ScriptableVariables
{
    [Serializable]
    public class VariableField<VariableType, ValueType>
    where VariableType : ScriptableVariable<ValueType>
    {
        [SerializeField] public VariableType variable;
        [SerializeField] ValueType directValue;

        protected UnityEvent<ValueType> ValueChange = new();

        public VariableField()
        {

        }

        public VariableField(ValueType defaultValue)
        {
            directValue = defaultValue;
        }


        public static implicit operator ValueType(VariableField<VariableType, ValueType> optional)
        {
            return optional.Value;
        }

        public void AddListener(UnityAction<ValueType> callback)
        {
            ValueChange.AddListener(callback);

            if (variable)
            {
                variable.ValueChange.AddListener((newValue) => { this.ValueChange.Invoke(newValue); });
            }

        }

        public void RemoveListener(UnityAction<ValueType> callback)
        {
            ValueChange.RemoveListener(callback);
        }

        public ValueType Value
        {
            get
            {
                if (variable)
                {
                    return variable.Value;
                }
                else
                {
                    return directValue;
                }
            }

            set
            {
                if (variable)
                {
                    variable.Value = value;

                    if (Application.isPlaying)
                    {
                        directValue = value;
                    }
                }
                else
                {
                    directValue = value;
                }
            }
        }
    }
}