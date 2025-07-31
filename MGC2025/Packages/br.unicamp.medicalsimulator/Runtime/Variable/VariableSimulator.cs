using System;
using MyUnityScripts.ScriptableVariables;
using UnityEngine;

namespace UNICAMP.MedicalSimulator
{
    [Serializable]
    public abstract class VariableSimulator<T>
    where T : ScriptableVariable
    {
        public ScriptableVariable variable;

        public abstract void Run(T variable);
    }
}
