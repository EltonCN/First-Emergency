using System;
using UnityEditor;
using UnityEngine;
using Unity.GraphToolkit.Editor;

namespace UNICAMP.MedicalSimulator.Editor
{
    [Serializable]
    public class TransitionNode : ContextNode
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("From").Build();
            context.AddOutputPort("To").Build();
        }
    }
}