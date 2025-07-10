using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MyUnityScripts.Timeline
{
    [Serializable]
    public class ColorClip : PlayableAsset, ITimelineClipAsset
    {
        [NoFoldOut]
        public ColorBehaviour template = new ColorBehaviour();

        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<ColorBehaviour>.Create(graph, template);
            return playable;
        }
    }
}