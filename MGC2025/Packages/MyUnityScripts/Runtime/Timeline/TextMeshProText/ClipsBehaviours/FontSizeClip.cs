using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MyUnityScripts.Timeline
{
    [Serializable]
    public class FontSizeClip : PlayableAsset, ITimelineClipAsset
    {
        [NoFoldOut]
        public FontSizeBehaviour template = new FontSizeBehaviour();

        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<FontSizeBehaviour>.Create(graph, template);
            return playable;
        }
    }
}