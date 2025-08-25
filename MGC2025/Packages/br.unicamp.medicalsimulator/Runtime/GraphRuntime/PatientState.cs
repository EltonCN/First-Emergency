using System.Collections.Generic;

namespace UNICAMP.MedicalSimulator
{
    public class PatientState : ContextElement
    {
        List<VariableSimulator> simulators = new();

        public override void OnEnter()
        {
        }

        public override void OnExecute()
        {
            foreach (VariableSimulator simulator in simulators)
            {
                simulator.Run(simulator.variable);
            }
        }

        public override void OnExit()
        {
        }

        public override void Transition(HashSet<ContextElement> nextElements, HashSet<ContextElement> previousRunElements)
        {
            foreach (ContextElement context in to)
            {
                nextElements.Add(context);
            }

            nextElements.Add(this);
        }
    }
}