using UnityEngine;
using UnityEngine.InputSystem;

namespace MyUnityScripts.MechanicBases
{
    /// <summary>
    /// Enable selecting objects in the screen
    /// </summary>
    [AddComponentMenu("My Unity Scripts/Mechanic Bases/Cursor/Selector", 0)]
    public class Selector : CursorCast
    {
        [Tooltip("The enable/disable select action. Optional, as 'Enable/DisableSelect' can be called manually, or 'HandleSelectAction' can be used as Unity Event.")]
        [SerializeField] InputActionReference selectAction;
        
        [Tooltip("If true, only delects a selected object when cursor is over it.")]
        [SerializeField] bool onlyDeselectWhenOver = true;

        [Tooltip("If true, allows selecting a new object without deselecting the previous object.")]
        [SerializeField] bool allowToggle = true;

        [Tooltip("If true, only keeps selecting while the cursor is over the selected object.")]
        [SerializeField] bool onlyKeepWhenOver = false;

        [Tooltip("If true, deselect the object when the cursor is released.")]
        [SerializeField] bool deselectWhenRelesease = false;


        bool selecting;
        Selectable selectedObject;
        RaycastHit lastHit;

        RaycastHit selectedHit;

        void Start()
        {
            selecting = false;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            onHit.AddListener(ReceiveCursorHit);

            if(selectAction)
            {
                selectAction.action.started += HandleSelectAction;
                selectAction.action.performed += HandleSelectAction;
                selectAction.action.canceled += HandleSelectAction;
            }
        }

        void OnDisable()
        {
            onHit.RemoveListener(ReceiveCursorHit);

            if(selectAction)
            {
                selectAction.action.started -= HandleSelectAction;
                selectAction.action.performed -= HandleSelectAction;
                selectAction.action.canceled -= HandleSelectAction;
            }
        }

        /// <summary>
        /// Handles the select action.
        /// </summary>
        /// <param name="context">Context of the select action</param>
        public void HandleSelectAction(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                if (!selecting)
                {
                    EnableSelect();
                }
                else
                {
                    DisableSelect();
                }
            }
            else if (deselectWhenRelesease && context.phase == InputActionPhase.Canceled)
            {
                DisableSelect();
            }
        }

        /// <summary>
        /// Checks if is hitting any object, and marks it as selected.
        /// </summary>
        public void EnableSelect()
        {
            if (lastHit.transform != null)
            {
                if (!checkIfHitting(lastHit))
                {
                    return;
                }

                Selectable selectable = getSelectable();

                if (selectable == null)
                {
                    return;
                }

                selecting = true;
                selectedObject = selectable;
                selectedHit = lastHit;

                selectedObject.StartSelect();
            }

        }

        /// <summary>
        /// Deselect the object if is selecting anything.
        /// </summary>
        public void DisableSelect()
        {
            if (selectedObject != null)
            {
                if (allowToggle)
                {
                    Selectable lastHitSelectable = getSelectable();
                    if (lastHitSelectable != selectedObject && checkIfHitting(lastHit))
                    {
                        selectedObject.EndSelect();
                        selectedObject = lastHitSelectable;
                        selectedHit = lastHit;
                        selectedObject.StartSelect();
                        return;
                    }
                }

                if (onlyDeselectWhenOver && !checkIfHitting(selectedHit))
                {
                    return;
                }

                selectedObject.EndSelect();
            }

            selecting = false;
        }

        public void ToggleSelect()
        {
            if(selecting)
            {
                DisableSelect();
            }
            else
            {
                EnableSelect();
            }
        }

        /// <summary>
        /// Receives the cursor hit information.
        /// </summary>
        /// <param name="hit">Hit information.</param>
        /// <param name="position">Position of the cursor when casting</param>
        public void ReceiveCursorHit(RaycastHit hit, Vector2 position)
        {
            lastHit = hit;
        }

        protected override void cursorInputCallback(Vector2 cursorPosition)
        {
            if (onlyKeepWhenOver && selecting)
            {
                if (!checkIfHitting(selectedHit))
                {
                    DisableSelect();
                }
            }
        }

        /// <summary>
        /// Checks if the hit has any Selectable and returns it.
        /// </summary>
        /// <param name="hit">Hit to check</param>
        /// <returns>S</returns>
        Selectable getSelectable()
        {
            Selectable selectable;

            //Check RigidBody object
            Selectable hitSelectable = lastHit.transform.gameObject.GetComponent<Selectable>();
            if (hitSelectable != null)
            {
                selectable = hitSelectable;
            }
            else //Check collider object
            {
                Selectable colliderSelectable = lastHit.collider.gameObject.GetComponent<Selectable>();
                selectable = colliderSelectable;
            }


            return selectable;
        }
    }
}