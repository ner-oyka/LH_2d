using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Common
{
    public class SpawnPoint : MonoBehaviour
    {
        [HideInInspector]
        public bool Entry = true;

        // Start is called before the first frame update
        void Start()
        {
            if (Entry)
            {
                Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
                if (playerTransform != null)
                {
                    playerTransform.position = transform.position;
                    playerTransform.rotation = transform.rotation;
                }
            }
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.5f);
            Gizmos.DrawLine(transform.position, transform.position + transform.up * 3.0f);
        }
    }
}