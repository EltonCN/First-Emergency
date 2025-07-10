using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{
    /// <summary>
    /// Scriptable object variable that stores int values.
    /// </summary>
    [CreateAssetMenu(menuName = "My Unity Scripts/Scriptable Variables/Int Variable")]
    public class IntVariable : ScriptableVariable<int>
    {
        [SerializeField] public Optional<int> minimum = new();
        [SerializeField] public Optional<int> maximum = new();

        public IntVariable()
        {
            minimum.value = 0;
            maximum.value = 1;
        }

        protected override void OnValueChange()
        {
            if (minimum.enabled && Value < minimum)
            {
                Value = minimum;
            }
            if (maximum.enabled && Value > maximum)
            {
                Value = maximum;
            }
        }
    }
}