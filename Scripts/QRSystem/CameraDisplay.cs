using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDisplay : MonoBehaviour
{
    public WebCamTexture textureCam;

    public RawImage displayTexture;

    public int cameraNumber;

    public bool cameraActivated;

    public void Start()
    {
        cameraNumber = 0;
        //StartCamera();
    }

    public void StartCamera()
    { 
        displayTexture.gameObject.SetActive(true);
        WebCamDevice device = WebCamTexture.devices[cameraNumber];
        textureCam = new WebCamTexture(device.name);
        displayTexture.texture = textureCam;
        textureCam.Play();
        cameraActivated = true;
        GetComponent<QRScanner>().searching = true;
    }


    public void StopCamera()
    {
        displayTexture.texture = null;
        textureCam.Stop();
        textureCam = null;
        displayTexture.gameObject.SetActive(false);
        cameraActivated = false;
    }

    public void SwitchCamera()
    {
        if (cameraNumber == 0)
        {
            cameraNumber = 1;
            WebCamDevice device = WebCamTexture.devices[cameraNumber];
            textureCam = new WebCamTexture(device.name);
            displayTexture.texture = textureCam;
            textureCam.Play();
        }
        else
        {
            cameraNumber = 0;
            WebCamDevice device = WebCamTexture.devices[cameraNumber];
            textureCam = new WebCamTexture(device.name);
            displayTexture.texture = textureCam;
            textureCam.Play();
        }
    }

    public void InitScanQR()
    {
        StartCamera();
        GameManager.Instance.UpdateQRScanner();    
    }

    public void Update()
    {
      /* 
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            if (cameraNumber == 0)
            {
                displayTexture.transform.eulerAngles = new Vector3(0, 0, -90);
            }
            else
            {
                displayTexture.transform.eulerAngles = new Vector3(0, 0, 90);
            }

        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            displayTexture.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            displayTexture.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        */
    }
}