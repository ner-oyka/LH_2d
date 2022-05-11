using UnityEngine;
using UnityEngine.InputSystem;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;

namespace Game.Player
{
    public class PlayerInputManager : MonoBehaviour, InputActions.IPlayerActions
    {
        public static PlayerInputManager instance = null;

        [HideInInspector]
        public Vector2 MousePosition;
        [HideInInspector]
        public Vector3 MouseWorldPosition;
        [HideInInspector]
        public Vector2 MovementDirection;
        [HideInInspector]
        public Vector2 ScrollDirection;
        [HideInInspector]
        public float MovementMagnitude => MovementDirection.magnitude;

        private InputActions m_InputActions;

        private FSMOwner m_playerFSM;
        private PlayerInteraction m_playerInteraction;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            m_playerFSM = gameObject.GetComponent<FSMOwner>();
            m_playerInteraction = gameObject.GetComponent<PlayerInteraction>();

        }

        private void Awake()
        {
            m_InputActions = new InputActions();
            m_InputActions.Player.SetCallbacks(this);
        }

        private void OnEnable()
        {
            m_InputActions.Player.Enable();
        }

        private void OnDisable()
        {
            m_InputActions.Player.Disable();
        }

        public void OnInventory(InputAction.CallbackContext context)
        {
            if (context.action.phase == InputActionPhase.Started)
            {
                m_playerFSM.SendEvent("OnInventory");
            }
        }

        public void OnMouseLeft(InputAction.CallbackContext context)
        {
            if (context.action.phase == InputActionPhase.Started)
            {
                m_playerInteraction.StartUseMain();
            }
            if (context.action.phase == InputActionPhase.Canceled)
            {
                m_playerInteraction.StopUseMain();
            }
        }

        public void OnMouseRight(InputAction.CallbackContext context)
        {
            if (context.action.phase == InputActionPhase.Started)
            {
                m_playerInteraction.StartUseSecond();
            }
            if (context.action.phase == InputActionPhase.Canceled)
            {
                m_playerInteraction.StopUseSecond();
            }
        }

        public void OnMousePosition(InputAction.CallbackContext context)
        {
            MousePosition = context.ReadValue<Vector2>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementDirection = context.ReadValue<Vector2>();

            if (MovementDirection.magnitude > 0.0f)
            {
                m_playerFSM.SendEvent("OnMovement");
            }
            else
            {
                m_playerFSM.SendEvent("OnIdle");
            }
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.action.phase == InputActionPhase.Started)
            {
                m_playerFSM.SendEvent("OnStartRunning");
            }
            if (context.action.phase == InputActionPhase.Canceled)
            {
                m_playerFSM.SendEvent("OnStopRunning");
            }
        }

        public void OnScroll(InputAction.CallbackContext context)
        {
            ScrollDirection = context.ReadValue<Vector2>();

            if (context.action.phase == InputActionPhase.Started)
            {
                if (ScrollDirection.y > 0)
                {

                }

                if (ScrollDirection.y < 0)
                {

                }
            }

        }

        public void OnFlashlight(InputAction.CallbackContext context)
        {
            if (context.action.phase == InputActionPhase.Started)
            {
                m_playerInteraction.UseSelectedItem();
            }
            if (context.action.phase == InputActionPhase.Canceled)
            {
                
            }
        }

        private void LateUpdate()
        {
            MouseWorldPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            MouseWorldPosition.z = 0;
        }

        public void OnJerk(InputAction.CallbackContext context)
        {
            if (context.action.phase == InputActionPhase.Started)
            {
                m_playerFSM.SendEvent("OnJerk");
            }
        }
    }
}