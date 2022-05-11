using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventBusSystem;

namespace Game.Events
{
    public class LogEventsController : MonoBehaviour, IPlayerRunning
    {
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void OnStartRunning()
        {
            Debug.Log("Player On Start Running");
        }

        public void OnStopRunning()
        {
            Debug.Log("Player On Stop Running");
        }
    }
}
