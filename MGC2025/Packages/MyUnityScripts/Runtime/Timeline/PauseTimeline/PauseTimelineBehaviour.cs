using System;
using UnityEngine;
using UnityEngine.Playables;
using MyUnityScripts.GameEvents;

namespace MyUnityScripts.Timeline
{
    [Serializable]
    public class PauseTimelineBehaviour : PlayableBehaviour, EventListener
    {

        bool clipPlayed = false;
        bool pauseScheduled = false;

        public PauseTimelineTrack track;

        PlayableDirector director;
        double directorSpeed;

        GameEvent gameEvent;

        public override void OnPlayableCreate(Playable playable)
        {
            director = playable.GetGraph().GetResolver() as PlayableDirector;
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            gameEvent = playerData as GameEvent;

            if (!clipPlayed && info.weight > 0f)
            {
                if (Application.isPlaying || track.pauseOnEditor)
                {
                    pauseScheduled = true;
                }
                clipPlayed = true;
            }
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {

            if (pauseScheduled)
            {
                pauseScheduled = false;

                gameEvent.RegisterListener(this);

                //director.Pause(); Pause have delay (don't stop exact on frame)
                if (director.playableGraph.IsValid())
                {
                    directorSpeed = director.playableGraph.GetRootPlayable(0).GetSpeed();
                    director.playableGraph.GetRootPlayable(0).SetSpeed(0d);
                }
            }

            clipPlayed = false;
        }

        public void OnEventRaised(string eventName)
        {
            gameEvent.UnregisterListener(this);

            //director.Resume();
            if (director.playableGraph.IsValid())
            {
                director.playableGraph.GetRootPlayable(0).SetSpeed(directorSpeed);
            }
        }

        public void OnEventRaised<T>(string eventName, T arg)
        {
            OnEventRaised(eventName);
        }
    }
}