using UnityEngine;
using UnityEngine.Events;

namespace MyUnityScripts.MechanicBases
{
    /// <summary>
    /// Marks the object as selectable and invokes events when selected.
    /// </summary>
    [AddComponentMenu("My Unity Scripts/Mechanic Bases/Cursor/Selectable", 0)]
    public class Selectable : MonoBehaviour
    {
        [Tooltip("Methods to invoke when starting selection.")]
        [SerializeField] UnityEvent onSelectStart;

        [Tooltip("Methods to invoke when ending selection.")]
        [SerializeField] UnityEvent onSelectEnd;

        /// <summary>
        /// Marks the object as beeing selected
        /// </summary>
        public void StartSelect()
        {
            onSelectStart.Invoke();
        }

        /// <summary>
        /// Marks the object as no longer selected
        /// </summary>
        public void EndSelect()
        {
            onSelectEnd.Invoke();
        }
    }
}