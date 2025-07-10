using UnityEngine;
using UnityEngine.Events;

namespace MyUnityScripts.ScriptableVariables
{
    public class VariableListener<VariableType, ValueType> : MonoBehaviour
    where VariableType : ScriptableVariable<ValueType>
    {
        public VariableType variable; 
        [SerializeField] bool forceInvokeOnEnable = false;
        public UnityEvent<ValueType> ValueChange;
        public UnityEvent<string> AsStringValueChange;

        void OnEnable()
        {
            variable.ValueChange.AddListener(UpdateValue);

            if(forceInvokeOnEnable)
            {
                UpdateValue(variable.Value);
            }
        }

        void OnDisable()
        {
            variable.ValueChange.RemoveListener(UpdateValue);
        }

        public void UpdateValue(ValueType value)
        {
            value = preProcessValue(value);
            ValueChange.Invoke(value);
            AsStringValueChange.Invoke(value.ToString());
        }

        protected virtual ValueType preProcessValue(ValueType value)
        {
            return value;
        }
    }
}