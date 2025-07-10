using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyUnityScripts.GameEvents
{
    /// <summary>
    /// Raises a Game Event
    /// </summary>
    public abstract class RaiseGameEventBase : MonoBehaviour
    {
        [Tooltip("Game Event to raise.")]
        [SerializeField] List<GameEvent> events = new();
        [SerializeField] bool destroyObjectOnRaise = false;
        [SerializeField] UnityEvent LocalResponse;

        protected void raiseEvents()
        {
            events.ForEach(ge => ge.Raise());
            LocalResponse.Invoke();

            if(destroyObjectOnRaise)
            {
                Destroy(this.gameObject);
            }
        }

    }
}