using UnityEngine;
using UnityEngine.InputSystem;

namespace MyUnityScripts.MechanicBases
{
    [AddComponentMenu("My Unity Scripts/Mechanic Bases/Cursor/Grabber", 0)]
    public class Grabber : CursorCast
    {
        [Tooltip("If should center the grabbed object on the screen. Otherwise it will stay at the cursor position.")]
        [SerializeField] bool centerOnScreen;

        bool grabbing;
        bool grabEnabled;
        Grabbable grabbedObject;

        void Start()
        {
            grabbing = false;
            grabEnabled = false;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            onHit.AddListener(ReceiveCursorHit);
        }

        void OnDisable()
        {
            onHit.RemoveListener(ReceiveCursorHit);
        }


        public void EnableGrab()
        {
            grabEnabled = true;
        }

        public void DisableGrab()
        {
            grabEnabled = false;

            if (grabbing)
            {
                grabbing = false;
                grabbedObject.EndGrab();
            }

        }

        public void ToggleGrab()
        {
            if(grabEnabled)
            {
                DisableGrab();
            }
            else
            {
                EnableGrab();
            }
        }

        public void ReceiveCursorHit(RaycastHit hit, Vector2 position)
        {
            if (!grabEnabled)
            {
                return;
            }
            if (!grabbing)
            {
                Grabbable grabbable = null;

                Grabbable hitGrabbable = hit.transform.gameObject.GetComponent<Grabbable>();
                if (hitGrabbable != null)
                {
                    grabbable = hitGrabbable;
                }
                else
                {
                    Grabbable colliderGrabbable = hit.collider.gameObject.GetComponent<Grabbable>();
                    grabbable = colliderGrabbable;
                }

                if(grabbable != null)
                {
                    grabbing = true;
                    grabbedObject = grabbable;

                    grabbedObject.StartGrab();
                }
            }

        }

        protected override void cursorInputCallback(Vector2 cursorPosition)
        {
            if (grabbing)
            {
                if (centerOnScreen)
                {
                    cursorPosition = new Vector2(Screen.width / 2, Screen.height / 2);

                }

                Ray ray = Camera.main.ScreenPointToRay(cursorPosition);

                grabbedObject.SetPosition(ray.origin, ray.direction);
            }
        }
    }
}