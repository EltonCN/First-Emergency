using UnityEngine;
using UnityEngine.Events;

namespace MyUnityScripts.ScriptableVariables
{
    public abstract class ScriptableVariable : ScriptableObject
    {
        // Common functionality, no generics here
    }

    /// <summary>
    /// Scriptable object that stores values.
    /// </summary>
    public class ScriptableVariable<T> : ScriptableVariable
    {
        [SerializeProperty("Value")]
        [SerializeField]
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