using System.Collections;
using System.Collections.Generic;
using TooLoo;
using UnityEngine;

namespace ssj12062023
{
    public class CustomCursor : Singleton<CustomCursor>
    {
        [SerializeField] private Texture2D defaultCrosshair;
        [SerializeField] private Texture2D selectableCrosshair;

        private Vector2 defaultCursorOffset;
        private Vector2 selectableCursorOffset;
        // Start is called before the first frame update
        void Start()
        {
            defaultCursorOffset = new Vector2(defaultCrosshair.width / 2, defaultCrosshair.height / 2);
            selectableCursorOffset = new Vector2(selectableCrosshair.width / 2, selectableCrosshair.height / 2);

            UseDefaultCursor();
        }

        public void UseSelectableCursor()
        {
            Cursor.SetCursor(selectableCrosshair, selectableCursorOffset, CursorMode.Auto);
        }

        public void UseDefaultCursor()
        {
            Cursor.SetCursor(defaultCrosshair, defaultCursorOffset, CursorMode.Auto);
        }
    }
}