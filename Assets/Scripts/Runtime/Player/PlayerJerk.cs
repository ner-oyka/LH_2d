using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerJerk : MonoBehaviour
    {
        [SerializeField]
        private float Power = 3500.0f;

        private Rigidbody2D m_Rigidbody2D;

        void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void UseJerk()
        {
            if (m_Rigidbody2D)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, PlayerInputManager.instance.MovementDirection);
                m_Rigidbody2D.AddForce(PlayerInputManager.instance.MovementDirection * Power, ForceMode2D.Impulse);
            }
        }
    }
}