using UnityEngine;
using System.Collections;

public class ScreenShotter : MonoBehaviour
{
    public bool captureScreenshot;
    public string shotName;
    int takeNumber;


    IEnumerator RecordFrame()
    {
        captureScreenshot = false;
        yield return new WaitForEndOfFrame();
        var texture = ScreenCapture.CaptureScreenshotAsTexture();
        // do something with texture
        byte[] _byteArray = texture.EncodeToJPG();
        System.IO.File.WriteAllBytes(Application.dataPath + $"/Screenshoot_{shotName}_{takeNumber}.png", _byteArray);

        // cleanup
        takeNumber++;
        Object.Destroy(texture);
    }

    public void LateUpdate()
    {
        if (captureScreenshot)        
            StartCoroutine(RecordFrame());
                    
    }
}