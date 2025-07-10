using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Collections.Generic;

namespace MyUnityScripts.Timeline
{
    [TrackColor(0.6383543f, 1f, 0.5708405f)]
    [TrackClipType(typeof(ComponentActivationClip))]
    [TrackBindingType(typeof(Behaviour))]
    public class ComponentActivationTrack : TrackAsset
    {
        [SerializeField]
        ActivationTrack.PostPlaybackState postPlaybackState = ActivationTrack.PostPlaybackState.LeaveAsIs;

        ComponentActivationMixerBehaviour mixer;

        public ActivationTrack.PostPlaybackState PostPlaybackState
        {
            get { return postPlaybackState; }
            set { postPlaybackState = value; UpdateTrackMode(); }
        }


        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var playableMixer = ScriptPlayable<ComponentActivationMixerBehaviour>.Create(graph, inputCount);

            mixer = playableMixer.GetBehaviour();

            UpdateTrackMode();

            return playableMixer;
        }

        protected override void OnCreateClip(TimelineClip clip)
        {
            clip.displayName = "Active";
            base.OnCreateClip(clip);
        }

        void UpdateTrackMode()
        {
            if (mixer != null)
            {
                mixer.postPlaybackState = postPlaybackState;
            }
        }

        // Please note this assumes only one component of type Behaviour on the same gameobject.
        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            Behaviour trackBinding = director.GetGenericBinding(this) as Behaviour;
            if (trackBinding == null)
                return;

            // These field names are procedurally generated estimations based on the associated property names.
            // If any of the names are incorrect you will get a DrivenPropertyManager error saying it has failed to register the name.
            // In this case you will need to find the correct backing field name.
            // The suggested way of finding the field name is to:
            // 1. Make sure your scene is serialized to text.
            // 2. Search the text for the track binding component type.
            // 3. Look through the field names until you see one that looks correct.
            driver.AddFromName<Behaviour>(trackBinding.gameObject, "m_Enabled");
#endif
            base.GatherProperties(director, driver);
        }
    }
}