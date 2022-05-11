using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventBusSystem;
using Game.Events;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField]
        private float WalkSpeed = 150f;
        [SerializeField]
        private float SprintSpeed = 300f;

        private Rigidbody2D m_Rigidbody2D;
        private Camera m_mainCamera;
        private float m_CurrentSpeed;

        public void StartRunning()
        {
            m_CurrentSpeed = SprintSpeed;
            EventBus.RaiseEvent<IPlayerRunning>(h => h.OnStartRunning());
        }

        public void StopRunning()
        {
            m_CurrentSpeed = WalkSpeed;
            EventBus.RaiseEvent<IPlayerRunning>(h => h.OnStopRunning());
        }

        private void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_mainCamera = Camera.main;
            m_CurrentSpeed = WalkSpeed;
        }

        public void FixedUpdateMovement()
        {
            Vector2 movementDirection = PlayerInputManager.instance.MovementDirection;


            //m_Rigidbody2D.velocity = m_MovementDirection * m_CurrentSpeed * Time.fixedDeltaTime;
            m_Rigidbody2D.velocity = (m_mainCamera.transform.right * movementDirection.x + m_mainCamera.transform.up * movementDirection.y) * m_CurrentSpeed * Time.fixedDeltaTime;

        }
    }
}
