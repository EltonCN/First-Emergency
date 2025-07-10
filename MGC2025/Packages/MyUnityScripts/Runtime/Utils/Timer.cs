using UnityEngine;
using UnityEngine.Events;
using MyUnityScripts.ScriptableVariables;

namespace MyUnityScripts
{
    [AddComponentMenu("My Unity Scripts/Utils/Timer")]
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        VariableField<FloatVariable, float> interval;

        [SerializeField]
        bool loop = false;

        [SerializeField]
        bool startOnEnable = false;

        [SerializeField]
        UnityEvent onTimeout = new();

        [SerializeField]
        bool randomInterval = false;

        [SerializeField]
        VariableField<FloatVariable, float> randomMinimum = new();

        [SerializeField]
        VariableField<FloatVariable, float> randomMaximum = new();




        bool waiting = false;
        float startTime;

        public Timer()
        {
            randomMinimum.Value = 10f;
            randomMaximum.Value = 15f;
        }



        void OnEnable()
        {
            if (startOnEnable)
            {
                StartTimer();
            }
        }

        void Update()
        {
            if (waiting)
            {
                if (Time.time - startTime >= interval)
                {
                    onTimeout.Invoke();

                    if (!loop)
                    {
                        waiting = false;
                    }

                    startTime = Time.time;

                }
            }
        }

        public void StartTimer()
        {
            waiting = true;
            startTime = Time.time;

            if (randomInterval)
            {
                interval.Value = UnityEngine.Random.Range(randomMinimum, randomMaximum);
            }
        }

        public void StopTimer()
        {
            waiting = false;
        }

    }
}