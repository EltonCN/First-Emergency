using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Collections.Generic;
using TMPro;

namespace MyUnityScripts.Timeline
{
    [TrackColor(0f, 0.6823f, 0.9372f)]
    [TrackClipType(typeof(ColorClip))]
    [TrackClipType(typeof(VisibleCharactersClip))]
    [TrackClipType(typeof(FontSizeClip))]
    [TrackClipType(typeof(TextClip))]
    [TrackBindingType(typeof(TMP_Text))]
    public class TextMeshProTextTrack : TrackAsset, ILayerable
    {
        [SerializeField]
        PostPlaybackState postPlaybackState = PostPlaybackState.LeaveAsIs;

        TextMeshProTextMixerBehaviour mixer;

        protected override void OnCreateClip(TimelineClip clip)
        {
            string displayName = clip.displayName;

            if(displayName.EndsWith("Clip"))
            {
                displayName = displayName.Substring(0, displayName.Length-4);
            }

            clip.displayName = displayName;


            base.OnCreateClip(clip);
        }

        public PostPlaybackState PostPlaybackState
        {
            get { return postPlaybackState; }
            set { postPlaybackState = value; UpdateTrackMode(); }
        }

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var playableMixer = ScriptPlayable<TextMeshProTextMixerBehaviour>.Create(graph, inputCount);

            mixer = playableMixer.GetBehaviour();

            UpdateTrackMode();

            return playableMixer;
        }

        void UpdateTrackMode()
        {
            if(mixer != null)
            {
                mixer.postPlaybackState = postPlaybackState;
            }
        }

        // Please note this assumes only one component of type TextMeshProUGUI on the same gameobject.
        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            TMP_Text trackBinding = director.GetGenericBinding(this) as TMP_Text;
            if (trackBinding == null)
                return;

            // These field names are procedurally generated estimations based on the associated property names.
            // If any of the names are incorrect you will get a DrivenPropertyManager error saying it has failed to register the name.
            // In this case you will need to find the correct backing field name.
            // The suggested way of finding the field name is to:
            // 1. Make sure your scene is serialized to text.
            // 2. Search the text for the track binding component type.
            // 3. Look through the field names until you see one that looks correct. 
            
            driver.AddFromName<TMP_Text>(trackBinding.gameObject, "m_text");
            driver.AddFromName<TMP_Text>(trackBinding.gameObject, "m_fontSize");
            driver.AddFromName<TMP_Text>(trackBinding.gameObject, "m_fontColor");
            //driver.AddFromName<TMP_Text>(trackBinding.gameObject, "m_maxVisibleCharacters");
#endif
            base.GatherProperties(director, driver);
        }

        Playable ILayerable.CreateLayerMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return Playable.Null;
        }

    }
}