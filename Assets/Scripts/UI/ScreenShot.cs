using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    public class ScreenShot : MonoBehaviour
    {
        public RectTransform previewWindow; // Assign the UI element which you wanna capture
        public AudioClip snapShotSFX;
        
        int width; // width of the object to capture
        int height; // height of the object to capture

        // Use this for initialization
        void Start()
        {
            width = System.Convert.ToInt32(previewWindow.rect.width);
            height = System.Convert.ToInt32(previewWindow.rect.height);
        }

        public void CapturePreviewImage()
        {
            AudioManager.Instance.PlaySFX(snapShotSFX);
            StartCoroutine(takeScreenShot());
        }

        public IEnumerator takeScreenShot()
        {
            yield return new WaitForEndOfFrame(); // it must be a coroutine 

            Vector2 temp = previewWindow.transform.position;
            var startX = temp.x - width / 2;
            var startY = temp.y - height / 2;

            var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
            tex.Apply();

            // Encode texture into PNG
            byte[] bytes = tex.EncodeToPNG();
            Destroy(tex);

            // Convert the byte array to a base64 string
            string base64Image = System.Convert.ToBase64String(bytes);

            // Create a JavaScript function to save the image
            string jsFunction = @"
            function saveAsFile(filename, bytesBase64) {
                var link = document.createElement('a');
                link.download = filename;
                link.href = 'data:image/png;base64,' + bytesBase64;
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            }";

            // Call the JavaScript function
            Application.ExternalEval(jsFunction + $"saveAsFile('snapshot.png', '{base64Image}');");
        }
    }
}