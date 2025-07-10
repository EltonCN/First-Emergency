using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MyUnityScripts.Timeline
{
    public class ComponentActivationMixerBehaviour : PlayableBehaviour
    {
        Behaviour m_TrackBinding;
        bool initialState;

        public ActivationTrack.PostPlaybackState postPlaybackState;

        public override void OnPlayableDestroy(Playable playable)
        {
            if (m_TrackBinding == null)
                return;

            switch (postPlaybackState)
            {
                case ActivationTrack.PostPlaybackState.Active:
                    m_TrackBinding.enabled = true;
                    break;
                case ActivationTrack.PostPlaybackState.Inactive:
                    m_TrackBinding.enabled = false;
                    break;
                case ActivationTrack.PostPlaybackState.Revert:
                    m_TrackBinding.enabled = initialState;
                    break;
                case ActivationTrack.PostPlaybackState.LeaveAsIs:
                    break;
            }
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            

            if(m_TrackBinding == null)
            {
                m_TrackBinding = playerData as Behaviour;
                initialState = m_TrackBinding != null && m_TrackBinding.enabled;
            }

            if (m_TrackBinding == null)
                return;


            int inputCount = playable.GetInputCount();
            bool isEnabled = false;
            for (int i = 0; i < inputCount; i++)
            {
                if (playable.GetInputWeight(i) > 0)
                {
                    isEnabled = true;
                    break;
                }
            }


            m_TrackBinding.enabled = isEnabled;

        }
    }
}