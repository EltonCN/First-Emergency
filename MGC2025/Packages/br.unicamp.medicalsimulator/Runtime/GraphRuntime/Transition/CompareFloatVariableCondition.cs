using System;
using MyUnityScripts.ScriptableVariables;
using System.Collections.Generic;


namespace UNICAMP.MedicalSimulator
{
    [Serializable]
    public class CompareFloatVariableCondition : TransitionCondition
    {
        public FloatOperation operation;
        public FloatVariable variable;
        public float value;

        public void OnEnter() { }
        public void OnExecute() { }
        public void OnExit() { }

        public bool IsTrue(HashSet<ContextElement> currentContexts)
        {
            switch (operation)
            {
                case FloatOperation.EQUAL:
                    return variable.Value == value;
                case FloatOperation.LESS:
                    return variable.Value < value;
                case FloatOperation.LESS_EQUAL:
                    return variable.Value <= value;
                case FloatOperation.GREATER:
                    return variable.Value > value;
                case FloatOperation.GREATER_EQUAL:
                    return variable.Value >= value;
            }

            return false;
        }
    }
}