using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Game.Utils
{
    public class ResizeToCameraRect : MonoBehaviour
    {
        void Start()
        {
            var height = 2 * Camera.main.orthographicSize;
            var width = height * Camera.main.aspect;

            transform.localScale = new Vector3(width, height, 1);

        }
    }

}