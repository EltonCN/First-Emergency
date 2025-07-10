using UnityEngine;
using UnityEngine.Events;

namespace MyUnityScripts.ScriptableVariables
{
    [AddComponentMenu("My Unity Scripts/Scriptable Variables/Listeners/Float Variable Listener")]
    public class FloatVariableListener : VariableListener<FloatVariable, float>
    {
        [Tooltip("Normalizes between the variable maximum and minimum (if both enabled), or just divides by the maximum (if enabled);")]
        [SerializeField] bool normalize = false;

        protected override float preProcessValue(float value)
        {
            if (normalize)
            {
                if (variable.maximum.enabled)
                {
                    if (variable.minimum.enabled)
                        value = (value - variable.minimum) / (variable.maximum - variable.minimum);
                    else
                        value /= variable.maximum;
                }
            }

            return value;
        }
    }
}