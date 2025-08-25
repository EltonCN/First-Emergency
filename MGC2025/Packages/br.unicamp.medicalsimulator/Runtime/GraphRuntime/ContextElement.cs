using System.Collections.Generic;

namespace UNICAMP.MedicalSimulator
{

    public abstract class ContextElement : MedicalRuntimeElement
    {
        public string name;
        public List<ContextElement> from = new();
        public List<ContextElement> to = new();
        public abstract void OnEnter();
        public abstract void OnExecute();
        public abstract void OnExit();
        public abstract void Transition(HashSet<ContextElement> nextElements, HashSet<ContextElement> previousRunElements);
    }
}