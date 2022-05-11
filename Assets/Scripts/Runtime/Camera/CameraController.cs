using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using EventBusSystem;
using Game.Player;
using Game.Events;
using Game.Items;

namespace Game.GameCamera
{
    public class CameraController : MonoBehaviour, IPlayerInventory
    {
        [SerializeField]
        private float DistanceToCameraOffset = 5.0f;
        [SerializeField]
        private float MaxDistanceCameraOffset = 8.0f;
        [SerializeField]
        private float SpeedCameraOffset = 10.0f;

        private CinemachineVirtualCamera m_VirtualCamera;
        private CinemachineTransposer m_CameraTransposer;

        private float m_cachedDistanceToCamera;

        private Transform m_playetTransform;

        private bool isLocked;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        void Start()
        {
            m_playetTransform = GameObject.FindWithTag("Player").transform;
            m_VirtualCamera = GetComponent<CinemachineVirtualCamera>();
            m_CameraTransposer = m_VirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            m_cachedDistanceToCamera = 1000.0f;
        }

        void FixedUpdate()
        {
            if (isLocked)
            {
                return;
            }

            Vector3 mouseWorldPos = PlayerInputManager.instance.MouseWorldPosition;

            //Camera offset
            m_cachedDistanceToCamera = DistanceToCameraOffset;

            if (Vector3.Distance(m_playetTransform.position, mouseWorldPos) > m_cachedDistanceToCamera)
            {
                Vector3 _camPosTarget = (m_playetTransform.position - (m_playetTransform.up * m_cachedDistanceToCamera) + mouseWorldPos) * 0.5f;
                m_CameraTransposer.m_FollowOffset = Vector3.Lerp(m_CameraTransposer.m_FollowOffset,
                    Vector3.ClampMagnitude(_camPosTarget - m_playetTransform.position, MaxDistanceCameraOffset), Time.deltaTime * SpeedCameraOffset);
            }
            else
            {
                m_CameraTransposer.m_FollowOffset = Vector3.Lerp(m_CameraTransposer.m_FollowOffset, Vector3.zero, Time.deltaTime * SpeedCameraOffset * 0.5f);
            }
            m_CameraTransposer.m_FollowOffset.z = -100;
        }

        public void OnOpenInventory(in List<BaseItem> items)
        {
            isLocked = true;
        }

        public void OnCloseInventory()
        {
            isLocked = false;
        }
    }
}
