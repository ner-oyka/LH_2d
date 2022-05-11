using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Game.Common
{
    public class TimeOfDay : MonoBehaviour
    {
        public Light2D Sun;

        [Range(0, 24)]
        public float TimeDay = 12.0f;
        public float TimeScale = 1.0f;
        public float TimeNightScale = 1.0f;

        public float NightStart = 20.0f;
        public float NightEnd = 8.0f;

        public Gradient m_SkyColor;

        public bool Pause;

        private static float currentTime;

        private bool isGlobalLightOff;

        public void OffGlobalLight()
        {
            isGlobalLightOff = true;
        }

        public void OnGlobalLight()
        {
            isGlobalLightOff = false;
        }

        public void UpdateTime()
        {
            currentTime = TimeDay;

            if (isGlobalLightOff)
            {
                Sun.color = RenderSettings.ambientLight = Color.Lerp(Sun.color, Color.black, Time.deltaTime * 3.0f);
                return;
            }
            Sun.color = RenderSettings.ambientLight = Color.Lerp(Sun.color, m_SkyColor.Evaluate((TimeDay * 100.0f / 24.0f) * 0.01f), Time.deltaTime * 3.0f);
        }

        public static string GetParseTime()
        {
            float sec = ((currentTime * 100.0f / 24.0f) * 0.01f) * 86400;
            TimeSpan timeSpan = TimeSpan.FromSeconds(sec);
            return string.Format("{0:D2}:{1:D2}", timeSpan.Hours, timeSpan.Minutes);
        }

        private void LateUpdate()
        {
            float timeScale;
            if (TimeDay >= NightStart || TimeDay <= NightEnd)
            {
                timeScale = TimeNightScale;
            }
            else
            {
                timeScale = TimeScale;
            }
            if (Pause == false)
            {
                TimeDay = TimeDay <= 24.0f ? TimeDay + 1 * timeScale * Time.deltaTime : 0.0f;
            }

            UpdateTime();
        }
    }

}