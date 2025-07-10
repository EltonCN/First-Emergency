using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using MyUnityScripts.GameEvents;

namespace MyUnityScripts.Timeline
{
    [TrackColor(0.0f, 0.0f, 0.0f)]
    [TrackClipType(typeof(PauseTimelineClip))]
    [TrackBindingType(typeof(GameEvent))]
    public class PauseTimelineTrack : TrackAsset
    {
        [SerializeField] public bool pauseOnEditor = false;

        void OnValidate()
        {
            var clips = GetClips();

            foreach (var clip in clips)
            {
                PauseTimelineClip c = clip.asset as PauseTimelineClip;

                c.track = this;
            }
        }

        void OnEnable()
        {
            OnValidate();
        }

        protected override void OnCreateClip(TimelineClip clip)
        {
            (clip.asset as PauseTimelineClip).track = this;
            clip.displayName = "PauseOnEnd";
        }

        // Please note this assumes only one component of type TextMeshProUGUI on the same gameobject.
        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
        GameEvent trackBinding = director.GetGenericBinding(this) as GameEvent;
        if (trackBinding == null)
            return;

        // These field names are procedurally generated estimations based on the associated property names.
        // If any of the names are incorrect you will get a DrivenPropertyManager error saying it has failed to register the name.
        // In this case you will need to find the correct backing field name.
        // The suggested way of finding the field name is to:
        // 1. Make sure your scene is serialized to text.
        // 2. Search the text for the track binding component type.
        // 3. Look through the field names until you see one that looks correct. 
        //@todo @TODO TODO Descobrir nome da propriedade e corrigir 
        //driver.AddFromName<TextMeshProUGUI>(trackBinding.gameObject, "m_maxVisibleCharacters");
#endif
            base.GatherProperties(director, driver);
        }
    }
}