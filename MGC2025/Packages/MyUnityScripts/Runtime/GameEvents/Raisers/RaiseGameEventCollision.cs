using UnityEngine;
using MyUnityScripts.ScriptableVariables;

namespace MyUnityScripts.GameEvents
{
    /// <summary>
    /// Raises a Game Event on Collision events.
    /// </summary>
    [AddComponentMenu("My Unity Scripts/Game Events/Raisers/Raise Game Event - Collision")]
    public class RaiseGameEventCollision : RaiseGameEventBase
    {
        [SerializeField] Optional<VariableField<GameObjectVariable, GameObject>> targetObject = new();
        [SerializeField] Optional<string> targetTag = new();

        [SerializeField] bool raiseOnCollisionEnter = false;
        [SerializeField] bool raiseOnTriggerEnter = false;

        [SerializeField] bool raiseOnTriggerExit = false;


        bool checkOther(Collider other)
        {
            if (targetObject.enabled)
            {
                if (other.gameObject == targetObject.value || (other.attachedRigidbody && other.attachedRigidbody.gameObject == targetObject.value))
                {
                    return true;
                }
            }

            if (targetTag.enabled)
            {
                if (other.gameObject.tag == tag || other.attachedRigidbody.gameObject.tag == tag)
                {
                    return true;
                }

            }

            if (targetTag.enabled || targetObject.enabled)
            {
                return false;
            }
            return true;
        }

        bool checkOther(Collision other)
        {
            if (targetObject.enabled)
            {
                if (other.gameObject == targetObject.value || other.rigidbody.gameObject == targetObject.value)
                {
                    return true;
                }
            }

            if (targetTag.enabled)
            {
                if (other.gameObject.tag == tag || other.rigidbody.gameObject.tag == tag)
                {
                    return true;
                }

            }

            if (targetTag.enabled || targetObject.enabled)
            {
                return false;
            }
            return true;
        }


        void OnTriggerEnter(Collider other)
        {
            if (enabled && raiseOnTriggerEnter && checkOther(other))
            {
                raiseEvents();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (enabled && raiseOnTriggerExit && checkOther(other))
            {
                raiseEvents();
            }
        }

        void OnCollisionEnter(Collision other)
        {
            if (enabled && raiseOnCollisionEnter && checkOther(other))
            {
                raiseEvents();
            }
        }


    }
}