using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace MyUnityScripts.MechanicBases
{
    /// <summary>
    /// Casts the cursor position to the world and check for collisions
    /// </summary>
    public class CursorCast : MonoBehaviour
    {
        [Tooltip("Layers that can be hit by the cursor.")]
        [SerializeField] LayerMask layermask;

        [Tooltip("Max distance for hit check.")]
        [SerializeField] float maxDistance = 100;

        [Tooltip("Methods to invoke when a hit occur.")]
        [SerializeField] protected UnityEvent<RaycastHit, Vector2> onHit;

        [Tooltip("Show the caster array for debugging.")]
        [SerializeField] bool showDebugRay = false;
        
        [Tooltip("The cursor position action. Optional, as 'ReceiveCursorInput' can be used as Unity Event.")]
        [SerializeField] InputActionReference cursorPositionAction;


        Vector2 lastPosition;

        protected virtual void OnEnable()
        {
            if(!cursorPositionAction.asset.enabled)
            {
                Debug.LogWarning($"cursorPositionAction is not enabled, {this.GetType().Name} will not work. (Add a 'Player Input' component with the Input Action Asset).");
            }
        }

        void FixedUpdate()
        {
            if(cursorPositionAction)
            {
                Vector2 cursorPosition = cursorPositionAction.action.ReadValue<Vector2>();
                processCursorPosition(cursorPosition);
            }
        }


        /// <summary>
        /// Receives the cursor action information.
        /// </summary>
        /// <param name="context">Cursor action context</param>
        public void ReceiveCursorInput(InputAction.CallbackContext context)
        {
            Vector2 cursorPosition = context.ReadValue<Vector2>();

            processCursorPosition(cursorPosition);
        }

        void processCursorPosition(Vector2 cursorPosition)
        {
            checkHit(cursorPosition);
            cursorInputCallback(cursorPosition);

            lastPosition = cursorPosition;
        }

        protected virtual void cursorInputCallback(Vector2 cursorPosition)
        {

        }

        /// <summary>
        /// Checks if the cursor hitted any object and invoke the event.
        /// </summary>
        /// <param name="position">Cursor position</param>
        void checkHit(Vector2 position)
        {
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;

            if (showDebugRay)
            {
                Debug.DrawRay(ray.origin, 100 * ray.direction, Color.green);
            }


            if (Physics.Raycast(ray, out hit, maxDistance, layermask))
            {
                onHit.Invoke(hit, position);
            }

        }

        /// <summary>
        /// Checks if the cursor is still hitting a previous object.
        /// </summary>
        /// <param name="oldHit">Old object hit.</param>
        /// <returns>True if is still hitting</returns>
        public bool checkIfHitting(RaycastHit oldHit)
        {
            Ray ray = Camera.main.ScreenPointToRay(lastPosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance, layermask))
            {
                if (ReferenceEquals(hit.collider.gameObject, oldHit.collider.gameObject))
                {
                    return true;
                }
            }

            return false;
        }
    }
}