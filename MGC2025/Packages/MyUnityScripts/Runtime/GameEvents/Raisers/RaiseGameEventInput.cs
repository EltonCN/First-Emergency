using UnityEngine;
using UnityEngine.InputSystem;
using MyUnityScripts.ScriptableVariables;

namespace MyUnityScripts.GameEvents
{
    /// <summary>
    /// Raises a Game Event on Input events.
    /// </summary>
    [AddComponentMenu("My Unity Scripts/Game Events/Raisers/Raise Game Event - Input")]
    public class RaiseGameEventInput : RaiseGameEventBase
    {
        [SerializeProperty("InputAction")]
        [SerializeField]
        InputActionReference inputAction;

        [SerializeField] bool raiseOnStarted = false;
        [SerializeField] bool raiseOnPerformed = true;
        [SerializeField] bool raiseOnCanceled = false;

        [SerializeField] bool onTrigger = false;
        [SerializeField] Optional<VariableField<GameObjectVariable, GameObject>> targetObject = new();
        [SerializeField] Optional<string> targetTag = new();

        bool targetInside = false;

        void subscribeToAction(InputActionReference inputAction)
        {
            if (inputAction)
            {
                inputAction.action.started += ReceiveInput;
                inputAction.action.performed += ReceiveInput;
                inputAction.action.canceled += ReceiveInput;
            }
        }

        void unsubscribeToAction(InputActionReference inputAction)
        {
            if (inputAction)
            {
                inputAction.action.started -= ReceiveInput;
                inputAction.action.performed -= ReceiveInput;
                inputAction.action.canceled -= ReceiveInput;
            }
        }


        public InputActionReference InputAction
        {
            get
            {
                return inputAction;
            }

            set
            {
                unsubscribeToAction(inputAction);

                inputAction = value;

                subscribeToAction(inputAction);
            }
        }

        void OnEnable()
        {
            subscribeToAction(inputAction);
        }

        void OnDisable()
        {
            unsubscribeToAction(inputAction);
        }


        public void ReceiveInput(InputAction.CallbackContext context)
        {
            print(targetInside);
            if (checkTargetInside())
            {
                if (raiseOnStarted && context.phase == InputActionPhase.Started)
                {
                    raiseEvents();
                }
                if (raiseOnPerformed && context.phase == InputActionPhase.Performed)
                {
                    raiseEvents();
                }
                if (raiseOnCanceled && context.phase == InputActionPhase.Canceled)
                {
                    raiseEvents();
                }
            }



        }

        bool checkTargetInside()
        {
            if (onTrigger)
            {
                return targetInside;
            }
            return true;
        }

        void OnTriggerEnter(Collider other)
        {
            if (checkOther(other))
            {
                targetInside = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (checkOther(other))
            {
                targetInside = false;
            }
        }

        bool checkOther(Collider other)
        {
            if (targetObject.enabled)
            {
                if (other.gameObject == targetObject.value || other.attachedRigidbody.gameObject == targetObject.value)
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

    }
}