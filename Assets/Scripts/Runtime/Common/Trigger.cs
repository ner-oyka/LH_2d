using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace Game.Common
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(ColliderGizmo))]
    public class Trigger : MonoBehaviour
    {
        public UnityEvent onEnter;
        public UnityEvent onExit;
        public UnityEvent onTimeout;

        [Tooltip("Activate event on timer")]
        [HideInInspector]
        public bool UseTimeout;
        [HideInInspector]
        public float Delay;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("Player"))
            {
                onEnter.Invoke();

                if (UseTimeout)
                {
                    Invoke("OnTimerFinish", Delay);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag.Equals("Player"))
            {
                onExit.Invoke();
            }
        }

        private void OnTimerFinish()
        {
            onTimeout?.Invoke();
        }

    }
}