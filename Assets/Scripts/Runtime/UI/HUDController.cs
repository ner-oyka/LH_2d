using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField]
        private Texture2D cursorDefault;

        void Start()
        {
            Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
