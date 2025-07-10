using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MyUnityScripts.Timeline
{
    [Serializable]
    public class PauseTimelineClip : PlayableAsset, ITimelineClipAsset
    {
        [HideInInspector]
        public PauseTimelineBehaviour template = new PauseTimelineBehaviour();

        [HideInInspector]
        public PauseTimelineTrack track;

        public ClipCaps clipCaps
        {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<PauseTimelineBehaviour>.Create(graph, template);

            playable.GetBehaviour().track = track;

            return playable;
        }
    }
}