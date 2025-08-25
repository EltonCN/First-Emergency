using System.Collections.Generic;

namespace UNICAMP.MedicalSimulator
{
    public class TransitionControl : ContextElement
    {
        public List<TransitionCondition> conditions;

        public override void OnEnter()
        {
            conditions.ForEach(x => x.OnEnter());
        }

        public override void OnExecute()
        {
            conditions.ForEach(x => x.OnExecute());
        }

        public override void OnExit()
        {
            conditions.ForEach(x => x.OnExit());
        }

        public override void Transition(HashSet<ContextElement> nextElements, HashSet<ContextElement> previousRunElements)
        {
            bool transition = true;

            foreach (TransitionCondition condition in conditions)
            {
                transition &= condition.IsTrue(previousRunElements);
            }

            if (transition)
            {
                foreach (ContextElement context in from)
                {
                    nextElements.Remove(context);
                }

                foreach (ContextElement context in to)
                {
                    nextElements.Add(context);
                }
            }
        }
    }
}