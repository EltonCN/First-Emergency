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
    public abstract class SimulatorNode<V, S> : BlockNode
    where V : ScriptableVariable
    where S : VariableSimulator<V>, new()
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<V>("variable").WithDisplayName("Variable").Build();
        }

        protected virtual void initializeSimulator(S simulator)
        {
        }

        public S getRuntimeSimulator()
        {
            S simulator = new S();
            V variable;

            GetInputPortByName("variable").TryGetValue(out variable);
            simulator.variable = variable;

            return simulator;
        }

    }
}
