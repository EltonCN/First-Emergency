using UnityEngine;
using UnityEngine.InputSystem;
using MyUnityScripts.ScriptableVariables;

namespace MyUnityScripts.MechanicBases
{
    [AddComponentMenu("My Unity Scripts/Mechanic Bases/Movement Base", 0)]
    [RequireComponent(typeof(Rigidbody))]
    public class MovementBase : MonoBehaviour
    {
        [SerializeField] protected VariableField<FloatVariable, float> baseHorizontalVelocity = new(3f);
        [SerializeField] protected VariableField<FloatVariable, float> baseJumpForce = new(1f);
        [SerializeField] protected VariableField<BoolVariable, bool> allowJump = new(false);
        [SerializeField] protected Transform forwardReference;
        [SerializeField] InputActionReference movementAction;
        [SerializeField] InputActionReference jumpAction;

        bool startJump = false;
        bool endJump = false;
        protected Rigidbody rigidBody;


        protected void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        protected void OnEnable()
        {
            if (jumpAction)
            {
                jumpAction.action.started += ReceiveJumpInput;
                jumpAction.action.performed += ReceiveJumpInput;
                jumpAction.action.canceled += ReceiveJumpInput;
            }
        }

        protected void OnDisable()
        {
            if (jumpAction)
            {
                jumpAction.action.started -= ReceiveJumpInput;
                jumpAction.action.performed -= ReceiveJumpInput;
                jumpAction.action.canceled -= ReceiveJumpInput;
            }
        }

        void FixedUpdate()
        {
            Vector2 movementDirection2D = movementAction.action.ReadValue<Vector2>();
            Vector3 movementDirection = (forwardReference.right * movementDirection2D.x) + (forwardReference.forward * movementDirection2D.y);

            float currentVerticalVelocity = Vector3.Dot(rigidBody.linearVelocity, forwardReference.up);

            processMovement(movementDirection, currentVerticalVelocity, startJump, endJump);

            startJump = false;
        }


        void ReceiveJumpInput(InputAction.CallbackContext context)
        {
            float verticalVelocity = Vector3.Dot(rigidBody.linearVelocity, forwardReference.up);

            if (context.phase == InputActionPhase.Performed && Mathf.Abs(verticalVelocity) < 1e-5f && allowJump)
            {
                startJump = true;
            }
            if (context.phase == InputActionPhase.Canceled)
            {
                endJump = true;
            }
        }

        protected virtual void processMovement(Vector3 movementDirection, float currentVerticalVelocity, bool startJump, bool endJump)
        {
            Vector3 velocity = forwardReference.up * currentVerticalVelocity;
            velocity += movementDirection * baseHorizontalVelocity;

            if (startJump)
            {
                rigidBody.AddForce(forwardReference.up * baseJumpForce, ForceMode.Impulse);
            }

            rigidBody.linearVelocity = velocity;
        }

        public void SetForwardReference(Transform forwardReference)
        {
            this.forwardReference = forwardReference;
        }
    }
}