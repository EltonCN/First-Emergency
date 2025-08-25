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
        protected override void OnDefineOptions(IOptionDefinitionContext context)
        {
            context.AddOption<bool>("negate")
            .WithDisplayName("Negate")
            .WithDefaultValue(false);

            context.AddOption<bool>("timed")
            .WithDisplayName("Timed")
            .WithDefaultValue(false);
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
