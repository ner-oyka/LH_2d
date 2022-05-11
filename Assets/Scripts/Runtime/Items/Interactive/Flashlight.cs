using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using EventBusSystem;
using Game.Player;

namespace Game.Items
{
    public class Flashlight : BaseItem
    {
    
        public Light2D flashLight;
        public bool isEnabled;

        public float BatteryCharge;

        public float minIntensity = 0f;
        public float maxIntensity = 1f;
        [Range(1, 50)]
        public int smoothing = 5;

        public bool followToMouseTarget;

        Queue<float> smoothQueue;
        float lastSum = 0;


        private void ChangeFlashlight()
        {
            isEnabled = !isEnabled;
        }

        public void Reset()
        {
            smoothQueue.Clear();
            lastSum = 0;
        }

        void Start()
        {
            smoothQueue = new Queue<float>(smoothing);
        }

        void Update()
        {
            if (isEnabled == false)
            {
                flashLight.intensity = 0;
                return;
            }

            if (BatteryCharge > 0)
            {
                if (followToMouseTarget)
                {
                    Vector3 _mousePos = PlayerInputManager.instance.MouseWorldPosition;
                    float dist = Vector3.Distance(transform.position, _mousePos);
                    flashLight.pointLightOuterRadius = dist * 1.5f;

                    while (smoothQueue.Count >= smoothing)
                    {
                        lastSum -= smoothQueue.Dequeue();
                    }

                    float newVal = UnityEngine.Random.Range(minIntensity, maxIntensity);
                    smoothQueue.Enqueue(newVal);
                    lastSum += newVal;

                    flashLight.intensity = Mathf.Lerp(lastSum / (float)smoothQueue.Count * 2f, lastSum / (float)smoothQueue.Count, dist / 20);
                }
                else
                {
                    while (smoothQueue.Count >= smoothing)
                    {
                        lastSum -= smoothQueue.Dequeue();
                    }

                    float newVal = UnityEngine.Random.Range(minIntensity, maxIntensity);
                    smoothQueue.Enqueue(newVal);
                    lastSum += newVal;

                    flashLight.intensity = lastSum / (float)smoothQueue.Count;
                }


                BatteryCharge -= 1 * Time.deltaTime;
            }
            else
            {
                BatteryCharge = -1;
            }


        }
    }
}