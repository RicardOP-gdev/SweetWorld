using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChocoDrakeManager : MonoBehaviour
{
    [Header("Chocolates")]
    public GameObject chocoCombo;
    public List<Vector3> chocoSpawns = new List<Vector3>();
    public List<GameObject> chocoComboList;

    [Header("FireBalls")]
    public List<GameObject> fireBallsList;
    public GameObject fireBall;

    [Header("Timers")]
    public Text timerText;
    public float timerToStart;
    public float timerGame;
    public float timerUpdateLevel;
    public float timerBetweenCombos;
    public float timerBetweenFireBalls;

    [Header("Platforms")]
    public List<GameObject> platforms = new List<GameObject>();
    public GameObject finalPlatform;

    [Header("GameState")]
    public bool inGame;
    public float speedGame;
    private GameObject drake;
    public GameObject gameOverPanel;
    public Text finalChoco;
    public Text totalChoco;
    public AudioSource pickUp;
    public AudioSource damage;
    public bool llegasFinal;


    //[Header("LevelTerrain")]
    //public GameObject levelTerrain;

    // Start is called before the first frame update    
    void Start()
    {
        GameManager.Instance.UpdateCanvasDrake();
        //loadingScreen.loopPointReached += OnMovieFinished;
        GameManager.Instance.UpdateBG();
        inGame = true;
        timerToStart = 3;
        timerGame = 0;
        timerUpdateLevel = 25;
        speedGame = -5;
        drake = GameObject.FindGameObjectWithTag("Drake");
        GameManager.Instance.finishPanelDrake.SetActive(false);
        drake.GetComponent<UseGyro>().enabled = true;
        UpdateHearts();
        drake.GetComponent<Drake>().score = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        if(inGame)
        {
            timerToStart -= Time.deltaTime;
            timerGame += Time.deltaTime;
            timerUpdateLevel -= Time.deltaTime;
            GameManager.Instance.progressSliderDrake.GetComponent<Slider>().value = timerGame;
            //timerText.text = timerGame.ToString("Timer: #.00");
            if (timerToStart >= -0.1)
            {
                timerToStart -= Time.deltaTime;
            }

            if (timerToStart <= 0)
            {
                ChocolateRain();
                //levelTerrain.transform.localPosition = new Vector3(levelTerrain.transform.position.x, levelTerrain.transform.position.y, levelTerrain.transform.position.z + speedGame * Time.deltaTime);

            }

            if (drake.GetComponent<Drake>().life == 0)
            {
                GameOver();
            }
            if(timerUpdateLevel <=0)
            {
                UpdateLevel();
                timerUpdateLevel = 25;
            }
            /*if(GameManager.Instance.progressSliderDrake.GetComponent<Slider>().value >= 100 && !llegasFinal)
            {
                //UpdatePlatforms();

            }*/
            if(timerGame >= 120)
            {
                GameOver();
            }
            
        }
        else
        {
            drake.GetComponent<UseGyro>().enabled = false;
        }
        
    }

    public void UpdateHearts()
    {
        GameManager.Instance.hearth1.GetComponent<Image>().sprite = GameManager.Instance.hearthFull;
        GameManager.Instance.hearth1.GetComponent<Animator>().enabled = true;
        GameManager.Instance.hearth1.GetComponent<Animator>().speed = 1;
        GameManager.Instance.hearth2.GetComponent<Image>().sprite = GameManager.Instance.hearthFull;
        GameManager.Instance.hearth2.GetComponent<Animator>().enabled = true;
        GameManager.Instance.hearth2.GetComponent<Animator>().speed = 1;
        GameManager.Instance.hearth3.GetComponent<Image>().sprite = GameManager.Instance.hearthFull;
        GameManager.Instance.hearth3.GetComponent<Animator>().enabled = true;
        GameManager.Instance.hearth3.GetComponent<Animator>().speed = 1;
    }

    public void UpdateLevel()
    {
        if ((drake.GetComponent<Drake>().score >= 300) &&(drake.GetComponent<Drake>().score <= 600))
        {
            speedGame = -5;
        }
        else if ((drake.GetComponent<Drake>().score >= 600) && (drake.GetComponent<Drake>().score <= 1000))
        {
            speedGame = -8;
        }
        else if (drake.GetComponent<Drake>().score >= 1000)
        {
            speedGame = -12;
        }
    }

    public void ChocolateRain()
    {
        timerBetweenCombos -= Time.deltaTime;
        timerBetweenFireBalls -= Time.deltaTime;
        if((timerBetweenCombos <=-0.01f) && (chocoComboList.Count <=2))
        {
            SpawnChocolateCombo();       
        }
        if ((timerBetweenFireBalls <= -0.01f) && (fireBallsList.Count <= 2))
        {
            SpawnFireBall();
        }


    }

    public void SpawnChocolateCombo()
    {
        GameObject chocoComboInstantiated = Instantiate(chocoCombo, chocoSpawns[Random.Range(0,8)], Quaternion.identity);
        timerBetweenCombos = Random.Range(3, 7);
        chocoComboList.Add(chocoComboInstantiated);
    }

    public void SpawnFireBall()
    {
        GameObject fireBallInstantiated = Instantiate(fireBall, chocoSpawns[Random.Range(0, 8)], Quaternion.identity);
        timerBetweenFireBalls = Random.Range(3,7);
        fireBallsList.Add(fireBallInstantiated);
    }

    public void GameOver()
    {
        speedGame = 0;
        inGame = false;
        ////////////////////////////
        GameManager.Instance.finishPanelDrake.SetActive(true);
        GameManager.Instance.yourMuffinsTDrake.GetComponent<Text>().text = drake.GetComponent<Drake>().score.ToString();
        float totalScore = drake.GetComponent<Drake>().score;
        GameManager.Instance.futureCoinsTDrake.GetComponent<Text>().text = totalScore.ToString();
        GameManager.Instance.buttonBackDrake.GetComponent<Button>().onClick.AddListener(() => BackDrake());
    }

    public void BackDrake()
    {
        Destroy(GameObject.FindGameObjectWithTag("Gyro"));
        GameObject[] fireBalls;
        fireBalls = GameObject.FindGameObjectsWithTag("FireBall");
        foreach (Object fireBall in fireBalls)
        {
            Destroy(fireBall);
        }
        GameObject[] chocoCombosD;
        chocoCombosD = GameObject.FindGameObjectsWithTag("ChocoCombo");
        foreach (Object chocoCombo in chocoCombosD)
        {
            Destroy(chocoCombo);
        }
        GameManager.Instance.chocoins += drake.GetComponent<Drake>().score;
        GameManager.Instance.UpdateChocoins();
        GameManager.Instance.drakeGaming = false;
        GameManager.Instance.UpdateBG();
        GameManager.Instance.UpdateCanvasDrake();
        GameManager.Instance.mainTheme.Play();
        SceneManager.UnloadSceneAsync("ChocoDrake");
    }

    ///
   /* public void UpdatePlatforms()
    {    
        Instantiate(finalPlatform, new Vector3(-0.13899f, 314, platforms[0].gameObject.transform.position.z +37.6f), Quaternion.identity);
        Instantiate(finalPlatform, new Vector3(-0.13899f, 314, platforms[0].gameObject.transform.position.z +75.2f), Quaternion.identity);
        llegasFinal = true;
        //Te petas quien toque
    }*/
}
