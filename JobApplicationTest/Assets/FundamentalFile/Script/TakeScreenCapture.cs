using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using SFB;
public class TakeScreenCapture : MonoBehaviour
{

    static TakeScreenCapture instance;
    public Camera cam;
    bool takeScreenshortOnNextFrame;
    string tempPath;
    byte[] byteArrayTemp;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

    }


    private void OnPostRender()
    {
        if (takeScreenshortOnNextFrame)
        {
            takeScreenshortOnNextFrame = false;
            RenderTexture renderTexture = cam.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            byteArrayTemp = byteArray;
            renderResult.LoadImage(byteArray);
            renderResult.Apply();

            RenderTexture.ReleaseTemporary(renderTexture);
            string imgName = "img" + DateTime.Now.ToString("yyyy_MM_dd.HH_mm_ss");
            string path = StandaloneFileBrowser.SaveFilePanel("Save Image", "", imgName, "png");
            tempPath = path;
            if (!string.IsNullOrEmpty(path))
            {
                File.WriteAllBytes(path, byteArray);
                Application.OpenURL(path);
            }


            cam.targetTexture = null;
        }
    }

     void ChangePathToSave()
    {
        if (byteArrayTemp.Length > 0)
        {
            string path = StandaloneFileBrowser.SaveFilePanel("Save As Image", "", "New", "png");
        
            if (!string.IsNullOrEmpty(tempPath))
            {
                File.WriteAllBytes(path, byteArrayTemp);
          
            }
        }
    }


    void TakeScreenshort(int width, int height)
    {
        cam.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshortOnNextFrame = true;
    }
    public static void ChangePath()
    {
        instance.ChangePathToSave();
    }

    public static void TakeScreenshortStatic(int width, int height)
    {
        instance.TakeScreenshort(width, height);
    }
}

