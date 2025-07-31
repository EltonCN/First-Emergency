using System;
using UnityEditor;
using UnityEngine;
using Unity.GraphToolkit.Editor;
using MyUnityScripts.GameEvents;

namespace UNICAMP.MedicalSimulator.Editor
{
    [Serializable]
    public class RaiseEventNode : Node
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("From").Build();
            context.AddInputPort<GameEvent>("gameEvent").WithDisplayName("Game Event").Build();
        }

    }
}