using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCaptureHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void PrintScreen()
    {
        TakeScreenCapture.TakeScreenshortStatic(2048, 2048);

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {

            PrintScreen();
        }

        if (Input.GetKey(KeyCode.Space))
        {

            TakeScreenCapture.ChangePath();
        }
    }
}

