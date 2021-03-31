using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;
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
    public GameObject videoCanvas;
    public GameObject drakecanvas;
    public GameObject shipcanvas;
    public GameObject droncanvas;
    
    public GameObject backgrounds;
    public GameObject settingsPanel;
    public GameObject secureExitPanel;
    public GameObject devToggle;
    //public GameObject musicButton;
    //public GameObject Button;
    public GameObject devUI;
    public GameObject worldsToggle;
    public string currentWorldS;

    [Header("DrakePayPanel")]
    public GameObject drakepaypanel;
    public GameObject infodrakepanel;
    public Text drakemytokens;
    public Text drakefuturetokens;

    [Header("ShipPayPanel")]
    public GameObject shippaypanel;
    public GameObject infoshippanel;
    public Text shipmytokens;
    public Text shipfuturetokens;

    [Header("DronPayPanel")]
    public GameObject dronpaypanel;
    public GameObject infodronpanel;
    public Text dronmytokens;
    public Text dronfuturetokens;
    public Text tokensText;
    public Text chocoinsText;
    public GameObject blockedPanel;
    public GameObject poorPanel;

    [Header("DrakeCanvas")]
    public GameObject hearth1; 
    public GameObject hearth2; 
    public GameObject hearth3; 
    public Sprite hearthEmpty; 
    public Sprite hearthFull; 
    public GameObject progressSliderDrake; 
    public GameObject muffinTextDrake; 
    public GameObject finishPanelDrake; 
    public GameObject yourMuffinsTDrake; 
    public GameObject futureCoinsTDrake; 
    public GameObject buttonBackDrake;

    [Header("ShipCanvas")]
    public GameObject progressSliderShip;
    public GameObject buttonStartShip;
    public GameObject heightTextShip;
    public GameObject finishPanelShip;
    public GameObject yourHeightShip;
    public GameObject futureCoinsShip;
    public GameObject buttonBackShip;

    [Header("DronCanvas")]
    public GameObject progressSliderDron;
    public GameObject myMuffinsDron;
    public GameObject finishPanelDron;
    public GameObject yourMuffinsDron;
    public GameObject futureCoinsDron;
    public GameObject buttonBackDron;

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
    public GameObject raycastManager;

    [Header("Videos")]
    public VideoPlayer videoPlayer;
    public VideoPlayer loadingScreenDrake;
    public VideoPlayer loadingScreenShip;
    public VideoPlayer loadingScreenDron;

    [Header("Sounds")]
    public AudioSource mainTheme;
    public AudioSource qrCorrectS;
    public AudioSource qrWrongS;
    public AudioSource pickUpMuffinS;
    public AudioSource gameOverDronS;
    public AudioMixer mixer;
    public bool muteMusic;
    public bool muteSfx;
    public Sprite muteMusicS;
    public Sprite unMuteMusicS;
    public Sprite muteSfxS;
    public Sprite unMuteSfxS;
    public Button musicB;
    public Button sfxB;


    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void Start()
    {
        UpdateWorlds();    
        UpdateChocoins();    
        UpdateTokens();
        worldsToggle.GetComponent<Toggle>().onValueChanged.AddListener((w) => OnValueChanged(dronActive));
        videoPlayer.loopPointReached += OnMovieFinished;
        loadingScreenDrake.loopPointReached += OnDrakeFinished;
        loadingScreenShip.loopPointReached += OnShipFinished;
        loadingScreenDron.loopPointReached += OnDronFinished;
    }

    public void PlaySound(AudioSource audio)
    {
        audio.Play();
    }

    public void UpdateSoundsButtons()
    {
        if(muteMusic)
        {
            musicB.image.sprite = muteMusicS;
        }
        else
        {
            musicB.image.sprite = unMuteMusicS;
        }

        if (muteSfx)
        {
            sfxB.image.sprite = muteSfxS;
        }
        else
        {
            sfxB.image.sprite = unMuteSfxS;
        }
    }

    public void MuteUnmuteMusic()
    {
        if(!muteMusic)
        {
            mixer.SetFloat("VolMusic", -80);
            muteMusic = true;
            UpdateSoundsButtons();
        }
        else
        {
            mixer.SetFloat("VolMusic", 0);
            muteMusic = false;
            UpdateSoundsButtons();
        }   
    }

    public void MuteUnmuteSfx()
    {
        if (!muteSfx)
        {
            mixer.SetFloat("VolSFX", -80);
            muteSfx = true;
            UpdateSoundsButtons();
        }
        else
        {
            mixer.SetFloat("VolSFX", 0);
            muteSfx = false;
            UpdateSoundsButtons();
        }
    }


    public void CloseApp()
    {
        Application.Quit();
    }

    public void OnDevChange(bool devChange)
    {
        devChange = devUI.activeSelf;
        devUI.SetActive(!devUI.activeSelf);
    }
    public void UpdateSettingsPanel()
    {
        UpdateSoundsButtons();
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void UpdateSecureExitPanel()
    {
        secureExitPanel.SetActive(!secureExitPanel.activeSelf);
    }


    public void OnValueChanged(bool worldBool)
    {
        switch (GetComponent<ChangeWorld>().worldPosition)
        {
            case 0:
                worldBool = dronActive;
                dronActive = !dronActive;
                UpdateWorlds();
                break;
            case 1:
                worldBool = drakeActive;
                drakeActive = !drakeActive;
                UpdateWorlds();
                break;
            case 2:
                worldBool = shipActive;
                shipActive = !shipActive;
                UpdateWorlds();
                break;
        }
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
    public void PlusTokens()
    {
        tokens += 1;
        tokensText.text = tokens.ToString();
    }

    public void LessTokens()
    {
        if (tokens - 1 >= 0)
        {
            tokens -= 1;
            tokensText.text = tokens.ToString();
        }
    }

    public void PlusCoins()
    {
        chocoins += 100;
        chocoinsText.text = chocoins.ToString();
    }

    public void LessCoins()
    {
        if(chocoins - 100 >= 0) {
            chocoins -= 100;
            chocoinsText.text = chocoins.ToString();
        }
    }



    public void UpdateVideoMcMuffin()
    {
        videoPlayer.Play();
        maincanvas.SetActive(false);
        devUI.SetActive(false);
        videoCanvas.SetActive(true);
        mainTheme.Stop();
    }

    void OnMovieFinished(VideoPlayer player)
    {
        videoPlayer = player;
        player.Stop();
        maincanvas.SetActive(true);
        if(devToggle.GetComponent<Toggle>().isOn)
        {
            devUI.SetActive(true);
        }
        videoCanvas.SetActive(false);
        mainTheme.Play();
    }

    public void SkipVideo()
    {
        mainTheme.Play();
        videoPlayer.Stop();
        maincanvas.SetActive(true);
        if (devToggle.GetComponent<Toggle>().isOn)
        {
            devUI.SetActive(true);
        }
        videoCanvas.SetActive(false);
    }

    public void UpdateBG()
    {
        backgrounds.SetActive(!backgrounds.activeSelf);
    }

    public void UpdateInfoPanel()
    {
        if(drakepaypanel.activeSelf)
        {
            if(infodrakepanel.activeSelf)
            {
                infodrakepanel.SetActive(false);
                raycastManager.GetComponent<RaycastWorlds>().enabled = true;
            }
            else
            {
                infodrakepanel.SetActive(true);
                raycastManager.GetComponent<RaycastWorlds>().enabled = false;
            }
            
        }
        else if(shippaypanel.activeSelf)
        {
            if (infoshippanel.activeSelf)
            {
                infoshippanel.SetActive(false);
                raycastManager.GetComponent<RaycastWorlds>().enabled = true;
            }
            else
            {
                infoshippanel.SetActive(true);
                raycastManager.GetComponent<RaycastWorlds>().enabled = false; ;
            }
        }
        else if(dronpaypanel.activeSelf)
        {
            if (infodronpanel.activeSelf)
            {
                infodronpanel.SetActive(false);
                raycastManager.GetComponent<RaycastWorlds>().enabled = true;
            }
            else
            {
                infodronpanel.SetActive(true);
                raycastManager.GetComponent<RaycastWorlds>().enabled = false;
            }
        }
    }

    public void CloseApply()
    {
        Application.Quit();
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
        if (!dronActive)
        {
            dronWorld.SetActive(false);
            dronLockedWorld.SetActive(true);
        }
        else
        {
            dronWorld.SetActive(true);
            dronLockedWorld.SetActive(false);
        }
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

    void OnDrakeFinished(VideoPlayer player)
    {
        player = loadingScreenDrake; 
        //UpdateCanvasDrake();
        SceneManager.LoadScene("ChocoDrake", LoadSceneMode.Additive);
        player.Stop();
    }

    void OnShipFinished(VideoPlayer player)
    {
        player = loadingScreenShip;
        //UpdateCanvasShip();
        SceneManager.LoadScene("ShipWorld", LoadSceneMode.Additive);
        player.Stop();
    }

    void OnDronFinished(VideoPlayer player)
    {
        player = loadingScreenDron;
        //UpdateCanvasDron();
        SceneManager.LoadScene("MazeWorld", LoadSceneMode.Additive);
        player.Stop();
    }
    public void PayDrake()
    {
        mainTheme.Stop();
        Debug.Log("Pay");
        tokens -= 1;
        UpdateTokens();
        drakeGaming = true;
        maincanvas.SetActive(false);
        devUI.SetActive(false);
        UpdatePanelPaymentDrake();
        loadingScreenDrake.Play();
    }

    public void PayShip()
    {
        mainTheme.Stop();
        Debug.Log("Pay");
        tokens -= 1;
        UpdateTokens();
        shipGaming = true;
        maincanvas.SetActive(false);
        devUI.SetActive(false);
        UpdatePanelPaymentShip();
        loadingScreenShip.Play();
    }
    public void PayDron()
    {
        mainTheme.Stop();
        Debug.Log("Pay");
        tokens -= 1;
        UpdateTokens();
        dronGaming = true;
        maincanvas.SetActive(false);
        devUI.SetActive(false);
        UpdatePanelPaymentDron();
        loadingScreenDron.Play();
    }

    public void UpdateTokens()
    {
        tokensText.text = tokens.ToString();
        drakemytokens.text = tokens.ToString();
        shipmytokens.text = tokens.ToString();
        dronmytokens.text = tokens.ToString();
        float futuremoney = tokens - 1; 
        drakefuturetokens.text = futuremoney .ToString();
        shipfuturetokens.text = futuremoney .ToString();
        dronfuturetokens.text = futuremoney .ToString();
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
            drakecanvas.SetActive(true);
            maincanvas.SetActive(false);
            devUI.SetActive(false);
        }
        else if (!drakeGaming)
        {
            maincanvas.SetActive(true);
            if (devToggle.GetComponent<Toggle>().isOn)
            {
                devUI.SetActive(true);
            }
            drakecanvas.SetActive(false);
        }
    }

    public void UpdateCanvasShip()
    {
        if (shipGaming)
        {
            shipcanvas.SetActive(true);
            maincanvas.SetActive(false);
            devUI.SetActive(false);
        }
        else if (!shipGaming)
        {
            maincanvas.SetActive(true);
            shipcanvas.SetActive(false);
            if (devToggle.GetComponent<Toggle>().isOn)
            {
                devUI.SetActive(true);
            }
        }
    }

    public void UpdateCanvasDron()
    {
        if (dronGaming)
        {
            maincanvas.SetActive(false);
            devUI.SetActive(false);
            droncanvas.SetActive(true);
        }
        else if (!dronGaming)
        {
            maincanvas.SetActive(true);
            droncanvas.SetActive(false);
            if (devToggle.GetComponent<Toggle>().isOn)
            {
                devUI.SetActive(true);
            }
        }
    }
}

    