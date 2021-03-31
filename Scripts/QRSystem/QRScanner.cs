using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QRScanner : MonoBehaviour
{
    public CameraDisplay cam;
    public List<Image> controlList = new List<Image>();
    public float timerDown;
    public float timerRefresh;
    public bool searching;

    public void Start()
    {
        timerDown = 1;
        timerRefresh = 0.5f;
        searching = true;
    }
    void Update()
    {
        if (searching)
        {
            SearchCode();
        }
        else
        {
            timerDown -= Time.deltaTime;
        }
        if (timerDown <= 0)
        {
            timerDown = 1;
            searching = true;
        }
    }
    public void SearchCode()
    {
        if (cam.displayTexture.texture != null)
        {
            IBarcodeReader reader = new BarcodeReader();

            var barcodeBitmap = cam.textureCam.GetPixels32();

            var result = reader.Decode(barcodeBitmap, cam.textureCam.width, cam.textureCam.height);
            
            
            if (result != null)
            {
                if (result.Text == "ChocoDrake")
                {
                    
                    timerRefresh -= Time.deltaTime;
                    foreach (Image frame in controlList)
                    {
                        frame.color = Color.green;

                    }
                    if(timerRefresh <= 0)
                    {

                        if (!GameManager.Instance.drakeActive)
                        {
                            GameManager.Instance.PlusTokens();
                            GameManager.Instance.PlusTokens();
                            //GameManager.Instance.qrCorrectS.Play();
                        }

                        GameManager.Instance.drakeActive = true;
                        GetComponent<CameraDisplay>().StopCamera();
                        GameManager.Instance.UpdateWorlds();
                        GameManager.Instance.UpdateQRScanner();
                        timerRefresh = 0.5f;
                    }
                    //searching = false;
                }
                else if (result.Text == "ChocoShip")
                {
                    //GameManager.Instance.qrCorrectS.Play();
                    timerRefresh -= Time.deltaTime;
                    foreach (Image frame in controlList)
                    {
                        frame.color = Color.green;

                    }
                    if (timerRefresh <= 0)
                    {

                        if (!GameManager.Instance.shipActive)
                        {
                            GameManager.Instance.PlusTokens();
                            GameManager.Instance.PlusTokens();
                            //GameManager.Instance.qrCorrectS.Play();
                        }

                        GameManager.Instance.shipActive = true;
                        GetComponent<CameraDisplay>().StopCamera();
                        GameManager.Instance.UpdateWorlds();
                        GameManager.Instance.UpdateQRScanner();
                        timerRefresh = 0.5f;
                    }
                    //searching = false;
                }
                else if (result.Text == "ChocoDron")
                {
                    timerRefresh -= Time.deltaTime;
                    foreach (Image frame in controlList)
                    {
                        frame.color = Color.green;

                    }
                    if (timerRefresh <= 0)
                    {


                        if(!GameManager.Instance.dronActive)
                        {
                            GameManager.Instance.PlusTokens();
                            GameManager.Instance.PlusTokens();
                            //GameManager.Instance.qrCorrectS.Play();
                        }

                        GameManager.Instance.dronActive = true;
                        GetComponent<CameraDisplay>().StopCamera();
                        GameManager.Instance.UpdateWorlds();
                        GameManager.Instance.UpdateQRScanner();

                        timerRefresh = 0.5f;
                    }
                    //searching = false;
                }
                else
                {
                    GameManager.Instance.qrWrongS.Play();
                    searching = false;
                    timerDown -= Time.deltaTime;
                    foreach (Image frame in controlList)
                    {
                        frame.color = Color.red;
                        
                    }
                    
                    if(timerDown <= 0)
                    {
                        SearchCode();
                        foreach (Image frame in controlList)
                        {
                            frame.color = Color.white;
                        }
                        
                        searching = true;
                    }         
                }
            }
            else
            {
                foreach (Image frame in controlList)
                {
                    frame.color = Color.white;
                }
            }
        }
    }
}
