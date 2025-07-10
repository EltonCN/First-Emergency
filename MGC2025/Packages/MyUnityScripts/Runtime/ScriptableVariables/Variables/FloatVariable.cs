using UnityEngine;

namespace MyUnityScripts.ScriptableVariables
{
    /// <summary>
    /// Scriptable object variable that stores float values.
    /// </summary>
    [CreateAssetMenu(menuName = "My Unity Scripts/Scriptable Variables/Float Variable")]
    public class FloatVariable : ScriptableVariable<float>
    {
        [SerializeField] public Optional<float> minimum = new();
        [SerializeField] public Optional<float> maximum = new();

        public FloatVariable()
        {
            minimum.value = 0f;
            maximum.value = 1f;
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