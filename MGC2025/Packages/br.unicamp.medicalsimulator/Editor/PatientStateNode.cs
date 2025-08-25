using System;
using UnityEditor;
using UnityEngine;
using Unity.GraphToolkit.Editor;

namespace UNICAMP.MedicalSimulator.Editor
{
    [Serializable]
    public class PatientStateNode : ContextNode
    {
        protected override void OnDefineOptions(IOptionDefinitionContext context)
        {
            context.AddOption<int>("priority")
                .WithDisplayName("Priority")
                .WithTooltip("The state priority for multiple simulators of same variable. Minimum is higher priority.")
                .WithDefaultValue(0);
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("From").Build();
            context.AddOutputPort("To").Build();
            context.AddOutputPort<StateReference>("stateReference").WithDisplayName("State Reference").Build();
        }

    }
}