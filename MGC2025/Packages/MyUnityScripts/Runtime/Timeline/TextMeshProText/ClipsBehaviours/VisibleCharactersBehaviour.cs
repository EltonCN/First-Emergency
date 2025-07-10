using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;
using System.Linq;

namespace MyUnityScripts.Timeline
{
    [Serializable]
    public class VisibleCharactersBehaviour : PlayableBehaviour
    {
        public float maxVisibleCharactersPercent;
    }
}