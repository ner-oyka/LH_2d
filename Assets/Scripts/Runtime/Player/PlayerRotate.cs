using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField]
        private float RotateSpeed = 15f;

        private Rigidbody2D m_Rigidbody2D;

        void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        public void FixedUpdateRotate()
        {
            Vector2 movementDirection = PlayerInputManager.instance.MovementDirection;
            Vector3 mouseWorldPos = PlayerInputManager.instance.MouseWorldPosition;

            Quaternion _targetRotation = Quaternion.LookRotation(Vector3.forward, mouseWorldPos - transform.position);

            if (m_Rigidbody2D.velocity.magnitude > 3.1f)
            {
                _targetRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.fixedDeltaTime * RotateSpeed);
        }
    }

}