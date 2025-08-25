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
    public class CompareFloatVariableNode : BlockNode
    {
        protected override void OnDefineOptions(IOptionDefinitionContext context)
        {
            context.AddOption<FloatOperation>("operation")
            .WithDisplayName("Operation");
        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<FloatVariable>("variable").WithDisplayName("Variable").Build();
            context.AddInputPort<float>("value").WithDisplayName("Value").Build();
        }
    }
}
