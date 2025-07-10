using UnityEngine;
using MyUnityScripts;
using MyUnityScripts.ScriptableVariables;

public class Test : MonoBehaviour
{
    [SerializeField] Optional<int> optionalInt;
    [SerializeField] VariableField<FloatVariable, float> floatField;
}