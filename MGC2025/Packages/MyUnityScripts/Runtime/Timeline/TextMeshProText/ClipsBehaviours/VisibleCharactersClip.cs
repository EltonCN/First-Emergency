using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MyUnityScripts.Timeline
{
    [Serializable]
    public class VisibleCharactersClip : PlayableAsset, ITimelineClipAsset
    {
        [NoFoldOut]
        public VisibleCharactersBehaviour template = new VisibleCharactersBehaviour();

        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<VisibleCharactersBehaviour>.Create(graph, template);
            return playable;
        }
    }
}