using UnityEngine;
using UnityEngine.Timeline;
using UnityEditor.Timeline;
using UnityEngine.Playables;

namespace MyUnityScripts.Timeline
{
    [CustomTimelineEditor(typeof(ComponentActivationTrack))]
    class ActivationTrackEditor : TrackEditor
    {
        static readonly string errorActivatingDirector = "The bound Component is the PlayableDirector.";

        public override TrackDrawOptions GetTrackOptions(TrackAsset track, Object binding)
        {
            var options = base.GetTrackOptions(track, binding);
            options.errorText = GetErrorText(track, binding);
            return options;
        }

        string GetErrorText(TrackAsset track, Object binding)
        {
            if(binding == TimelineEditor.inspectedDirector)
            {
                return errorActivatingDirector;
            }

            return base.GetErrorText(track, binding, TrackBindingErrors.PrefabBound);
        }

        public override void OnCreate(TrackAsset track, TrackAsset copiedFrom)
        {
            // Add a default clip to the newly created track
            if (copiedFrom == null)
            {
                var clip = track.CreateClip<ComponentActivationClip>();
                clip.displayName = "Active";
                clip.duration = System.Math.Max(clip.duration, track.timelineAsset.duration * 0.5f);
            }
        }
    }


}