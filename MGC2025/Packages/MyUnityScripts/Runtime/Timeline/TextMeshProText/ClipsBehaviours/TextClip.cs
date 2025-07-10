using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MyUnityScripts.Timeline
{
    [Serializable]
    public class TextClip : PlayableAsset, ITimelineClipAsset
    {
        [NoFoldOut]
        public TextBehaviour template = new TextBehaviour();

        public ClipCaps clipCaps
        {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<TextBehaviour>.Create(graph, template);
            return playable;
        }
    }
}