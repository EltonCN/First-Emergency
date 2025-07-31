using System;
using UnityEditor;
using UnityEngine;
using Unity.GraphToolkit.Editor;

namespace UNICAMP.MedicalSimulator.Editor
{
    [Serializable]
    public class StartNode : Node
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddOutputPort("To").Build();
        }

    }
}