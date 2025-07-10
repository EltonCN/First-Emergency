using UnityEngine;
using UnityEngine.Events;

namespace MyUnityScripts.ScriptableVariables
{
    /// <summary>
    /// Scriptable object that stores values.
    /// </summary>
    public class ScriptableVariable<T> : ScriptableObject
    {
        [SerializeProperty("Value")][SerializeField]
        T _value;

        /// <summary>
        /// Stored value.
        /// </summary>
        public T Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                OnValueChange();
                ValueChange.Invoke(this.Value);
            }
        }

        /// <summary>
        /// Event raised when the stored value changes.
        /// </summary>
        public UnityEvent<T> ValueChange;

        protected virtual void OnValueChange()
        {

        }
    }
}