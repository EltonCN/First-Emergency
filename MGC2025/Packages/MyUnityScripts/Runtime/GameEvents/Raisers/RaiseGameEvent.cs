using UnityEngine;

namespace MyUnityScripts.GameEvents
{
    /// <summary>
    /// Raises a Game Event on MonoBehaviour events.
    /// </summary>
    [AddComponentMenu("My Unity Scripts/Game Events/Raisers/Raise Game Event", 0)]
    public class RaiseGameEvent : RaiseGameEventBase
    {

        [SerializeField] bool raiseOnEnable = false;
        [SerializeField] bool raiseOnDisable = false;
        [SerializeField] bool raiseOnStart = false;
        [SerializeField] bool raiseOnAwake = false;

        void OnEnable()
        {
            if(raiseOnEnable)
                raiseEvents();
        }

        void OnDisable()
        {
            if(raiseOnDisable)
                raiseEvents();
        }

        void Start()
        {
            if(raiseOnStart)
                raiseEvents();
        }

        void Awake()
        {
            if(raiseOnAwake)
                raiseEvents();
        }
    }
}