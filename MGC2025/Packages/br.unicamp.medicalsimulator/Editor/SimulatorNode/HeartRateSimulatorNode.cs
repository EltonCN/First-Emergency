using System;
using UnityEditor;
using UnityEngine;
using Unity.GraphToolkit.Editor;
using UNICAMP.MedicalSimulator;
using MyUnityScripts.ScriptableVariables;

namespace UNICAMP.MedicalSimulator.Editor
{
    [UseWithContext(typeof(PatientStateNode))]
    [Serializable]
    public class HeartRateSimulatorNode : SimulatorNode<FloatVariable, HeartRateSimulator>
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            base.OnDefinePorts(context);

            context.AddInputPort<float>("minimumRate").WithDisplayName("Minimum Rate").WithDefaultValue(60).Build();
            context.AddInputPort<float>("maximumRate").WithDisplayName("Maximum Rate").WithDefaultValue(65).Build();
        }

        protected override void initializeSimulator(HeartRateSimulator simulator)
        {
            base.initializeSimulator(simulator);

            GetInputPortByName("minimumRate").TryGetValue(out simulator.minimumRate);
            GetInputPortByName("maximumRate").TryGetValue(out simulator.maximumRate);

        }

    }
}
