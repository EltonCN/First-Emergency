using System;
using MyUnityScripts.ScriptableVariables;
using UnityEngine;

namespace UNICAMP.MedicalSimulator
{
    [Serializable]
    public abstract class VariableSimulator
    {
        public ScriptableVariable variable;
        public abstract void Run(ScriptableVariable variable);
    }

    [Serializable]
    public abstract class VariableSimulator<T> : VariableSimulator
    where T : ScriptableVariable
    {
        public abstract void Run(T variable);

        public override void Run(ScriptableVariable variable)
        {
            Run((T)variable);
        }
    }
}
