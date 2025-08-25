using System;
using System.Collections.Generic;
using UnityEngine;

namespace UNICAMP.MedicalSimulator
{
    [Serializable]
    public class InStateCondition : TransitionCondition
    {
        public bool negate;
        public bool timed;
        public float timerTime;
        public StateReference stateReference;


        float startTime = 0f;

        public void OnEnter() { startTime = -1f; }
        public void OnExecute() { }
        public void OnExit() { }

        public bool IsTrue(HashSet<ContextElement> previousRunElements)
        {
            bool inState = false;

            foreach (ContextElement context in previousRunElements)
            {
                if (context.name == stateReference.name)
                {
                    inState = true;
                    break;
                }
            }

            if (negate)
            {
                inState = !inState;
            }

            if (timed)
            {
                if (inState)
                {
                    if (startTime == -1f)
                    {
                        startTime = Time.time;
                        return false;
                    }
                    return (Time.time - startTime) > timerTime;
                }
                else
                {
                    startTime = -1f;
                    return false;
                }
            }

            return inState;
        }
    }
}