using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class Player : MonoBehaviour
    {
        private PlayerMovement m_PlayerMovement;
        private PlayerRotate m_PlayerRotate;
        private PlayerJerk m_PlayerJerk;
        private PlayerInteraction m_PlayerInteraction;

        private void Start()
        {
            m_PlayerMovement = GetComponent<PlayerMovement>();
            m_PlayerRotate = GetComponent<PlayerRotate>();
            m_PlayerJerk = GetComponent<PlayerJerk>();
            m_PlayerInteraction = GetComponent<PlayerInteraction>();
        }
        
        private void FixedUpdate()
        {
            if (m_PlayerMovement.enabled)
            {
                m_PlayerMovement.FixedUpdateMovement();
            }

            if (m_PlayerRotate.enabled)
            {
                m_PlayerRotate.FixedUpdateRotate();
            }
        }
    }

}