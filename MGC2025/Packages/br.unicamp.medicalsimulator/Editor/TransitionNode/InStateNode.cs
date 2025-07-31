using System;
using UnityEditor;
using UnityEngine;
using Unity.GraphToolkit.Editor;
using UNICAMP.MedicalSimulator;
using MyUnityScripts.ScriptableVariables;

namespace UNICAMP.MedicalSimulator.Editor
{
    [UseWithContext(typeof(TransitionNode))]
    [Serializable]
    public class InStateNode : BlockNode
    {
        protected override void OnDefineOptions(INodeOptionDefinition context)
        {
            context.AddNodeOption<bool>("negate", "Negate", defaultValue: false);
            context.AddNodeOption<bool>("timed", "Timed", defaultValue: false);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<StateReference>("stateReference").WithDisplayName("State Reference").Build();

            GetNodeOptionByName("timed").TryGetValue(out bool timed);
            if (timed)
            {
                context.AddInputPort<float>("timer").WithDisplayName("Timer (seconds)").Build();
            }
        }
    }
}
