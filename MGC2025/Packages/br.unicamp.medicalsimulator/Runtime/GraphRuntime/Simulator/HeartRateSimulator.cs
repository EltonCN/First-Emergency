using System;
using MyUnityScripts.ScriptableVariables;
using UnityEngine;

namespace UNICAMP.MedicalSimulator
{
    [Serializable]
    public class HeartRateSimulator : VariableSimulator<FloatVariable>
    {
        public float minimumRate;
        public float maximumRate;

        public override void Run(FloatVariable variable)
        {
            variable.Value = 60;
        }
    }
}
