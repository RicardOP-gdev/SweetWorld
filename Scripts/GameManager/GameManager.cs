using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("PlayerStats")]
    public int chocoins;
    public int tokens;

    [Header("UI_Components")]
    public GameObject qrScanner;
    public GameObject maincanvas;
    public GameObject drakecanvas;
    public GameObject shipcanvas;
    public GameObject droncanvas;
    public GameObject drakepaypanel;
    public Text drakemymoney;
    public Text drakefuturemoney;
    public GameObject shippaypanel;
    public Text shipmymoney;
    public Text shipfuturemoney;
    public GameObject dronpaypanel;
    public Text dronmymoney;
    public Text dronfuturemoney;
    public Text tokensText;
    public Text chocoinsText;
    public GameObject blockedPanel;
    public GameObject poorPanel;

    [Header("Worlds")]
    public bool drakeActive;
    public bool shipActive;
    public bool dronActive;
    public GameObject drakeWorld;
    public GameObject drakeLockedWorld;
    public GameObject shipWorld;
    public GameObject shipLockedWorld;
    public GameObject dronWorld;
    public GameObject dronLockedWorld;
    private Color blockedColor = new Color (35,35,35,255);

    [Header("CameraManager")]
    public GameObject cameraManager;

    [Header("GameController")]
    public bool drakeGaming;
    public bool shipGaming;
    public bool dronGaming;
    

    public void Start()
    {
        UpdateWorlds();    
        UpdateChocoins();    
        UpdateTokens();    
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void UpdateQRScanner()
    {
        if(!qrScanner.activeSelf)
        {
            qrScanner.SetActive(true);     
        }
        else
        {
            qrScanner.SetActive(false);
        }     
    }

    public void UpdateWorlds()
    {
        if (!drakeActive)
        {
            drakeWorld.SetActive(false);
            drakeLockedWorld.SetActive(true);
        }
        else
        {
            drakeWorld.SetActive(true);
            drakeLockedWorld.SetActive(false);
        }
       /* if (!dronActive)
        {
            dronWorld.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.black;
        }
        else
        {
            dronWorld.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.white;
        }*/
        if (!shipActive)
        {
            shipWorld.SetActive(false);
            shipLockedWorld.SetActive(true);
        }
        else
        {
            shipWorld.SetActive(true);
            shipLockedWorld.SetActive(false);
        }
    }

    public void UpdateChocoins()
    {
        chocoinsText.text = chocoins.ToString();
    }

    public void UpdateBlockedPanel()
    {
        if(blockedPanel.activeSelf)
        {
            blockedPanel.SetActive(false);
        }
        else
        {
            blockedPanel.SetActive(true);
        }
    }

    public void UpdatePoorPanel()
    {
        if (poorPanel.activeSelf)
        {
            poorPanel.SetActive(false);
        }
        else
        {
            poorPanel.SetActive(true);
        }
    }

    public void PayDrake()
    {
        Debug.Log("Pay");
        tokens -= 1;
        UpdateTokens();
        drakeGaming = true;
        UpdateCanvasDrake();
        SceneManager.LoadScene("ChocoDrake", LoadSceneMode.Additive);
        UpdatePanelPaymentDrake();
    }

    public void PayShip()
    {
        Debug.Log("Pay");
        tokens -= 1;
        UpdateTokens();
        shipGaming = true;
        UpdateCanvasShip();
        SceneManager.LoadScene("ShipWorld", LoadSceneMode.Additive);
        UpdatePanelPaymentShip();
    }

    public void UpdateTokens()
    {
        tokensText.text = tokens.ToString();
        drakemymoney.text = tokens.ToString();
        shipmymoney.text = tokens.ToString();
        dronmymoney.text = tokens.ToString();
        float futuremoney = tokens - 1; 
        drakefuturemoney.text = futuremoney .ToString();
        shipfuturemoney.text = futuremoney .ToString();
        dronfuturemoney.text = futuremoney .ToString();
    }

    public void UpdatePanelPaymentDrake()
    {
        if (drakepaypanel.activeSelf)
        {
            drakepaypanel.SetActive(false);
        }
        else
        {
            drakepaypanel.SetActive(true);
        }
    }
    public void UpdatePanelPaymentShip()
    {
        if (shippaypanel.activeSelf)
        {
            shippaypanel.SetActive(false);
        }
        else
        {
            shippaypanel.SetActive(true);
        }
    }
    public void UpdatePanelPaymentDron()
    {       
        if (dronpaypanel.activeSelf)
        {
            dronpaypanel.SetActive(false);
        }
        else
        {
            dronpaypanel.SetActive(true);
        }
    }


    public void UpdateCanvasDrake()
    {
        if (drakeGaming)
        {
            maincanvas.SetActive(false);
            drakecanvas.SetActive(true);
        }
        else if (!drakeGaming)
        {
            maincanvas.SetActive(true);
            drakecanvas.SetActive(false);
        }
    }

    public void UpdateCanvasShip()
    {
        if (shipGaming)
        {
            maincanvas.SetActive(false);
            shipcanvas.SetActive(true);
        }
        else if (!shipGaming)
        {
            maincanvas.SetActive(true);
            shipcanvas.SetActive(false);
        }
    }

    public void UpdateCanvasDron()
    {
        if (dronGaming)
        {
            maincanvas.SetActive(false);
            droncanvas.SetActive(true);
        }
        else if (!dronGaming)
        {
            maincanvas.SetActive(true);
            droncanvas.SetActive(false);
        }
    }
}

    