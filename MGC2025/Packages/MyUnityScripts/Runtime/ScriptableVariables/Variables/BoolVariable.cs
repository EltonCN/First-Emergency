using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{
    /// <summary>
    /// Scriptable object variable that stores float values.
    /// </summary>
    [CreateAssetMenu(menuName = "My Unity Scripts/Scriptable Variables/Bool Variable")]
    public class BoolVariable : ScriptableVariable<bool>
    {
        public void Toggle()
        {
            Value = !Value;
        }
    }
}
