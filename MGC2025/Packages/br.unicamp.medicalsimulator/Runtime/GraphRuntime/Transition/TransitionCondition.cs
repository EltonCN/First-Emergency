using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UNICAMP.MedicalSimulator
{
    public interface TransitionCondition : MedicalRuntimeElement
    {
        public bool IsTrue(HashSet<ContextElement> currentContexts);
    }
}