using UnityEngine;
using UnityEngine.Timeline;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine.Playables;

namespace MyUnityScripts.Timeline
{
    [CustomEditor(typeof(TextMeshProTextTrack))]
    class TextMeshProTextTrackEditor : Editor
    {
        static readonly string[] hiddenProperties = new string[]{"postPlaybackState"};

        public override void OnInspectorGUI()
        {
            TextMeshProTextTrack trackEditor = (TextMeshProTextTrack)target;

            if(trackEditor.parent is TextMeshProTextTrack)
            {
                DrawPropertiesExcluding(serializedObject, hiddenProperties);
            }
            else
            {
                DrawDefaultInspector();
            }

            
        }
    }


}