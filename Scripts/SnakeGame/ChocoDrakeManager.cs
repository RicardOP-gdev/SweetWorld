using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [Header("GameState")]
    public bool inGame;
    public float speedGame;
    private GameObject drake;
    public GameObject gameOverPanel;
    public Text finalChoco;
    public Text totalChoco;

    // Start is called before the first frame update
    void Start()
    {
        timerToStart = 3;
        timerGame = 0;
        timerUpdateLevel = 25;
        inGame = true;
        speedGame = -5;
        drake = GameObject.FindGameObjectWithTag("Drake");
        gameOverPanel.SetActive(false);
        drake.GetComponent<UseGyro>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(inGame)
        {
            timerGame += Time.deltaTime;
            timerUpdateLevel -= Time.deltaTime;
            timerText.text = timerGame.ToString("Timer: #.00");
            if (timerToStart >= -0.1)
            {
                timerToStart -= Time.deltaTime;
            }

            if (timerToStart <= 0)
            {
                ChocolateRain();
            }

            if(drake.GetComponent<Drake>().life == 0)
            {
                GameOver();
            }
            if(timerUpdateLevel <=0)
            {
                UpdateLevel();
                timerUpdateLevel = 25;
            }  
            
        }
        else
        {
            drake.GetComponent<UseGyro>().enabled = false;
        }
        
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
        gameOverPanel.SetActive(true);
        finalChoco.text = drake.GetComponent<Drake>().score.ToString();
        float totalScore = drake.GetComponent<Drake>().score + GameManager.Instance.chocoins;
        totalChoco.text = totalScore.ToString();
    }

    public void Back()
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
        GameManager.Instance.UpdateCanvasDrake();
        SceneManager.UnloadSceneAsync("ChocoDrake");
    }
}
