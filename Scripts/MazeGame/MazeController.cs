using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeController : MonoBehaviour
{
    [Header ("PlayerInfo")]
    public int score;
    public bool alive;

    [Header ("SceneComponents")]
    public GameObject prefabCollect;
    public GameObject maze;

    [Header ("Lists")]
    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> spawnedCollectables = new List<GameObject>();

    [Header("Animations")]
    public Animator animator_SpawnPoints;
    public Animator animator_Cupcakes_Rot;
    public Animator animator_Robot_Maze_1;
    public Animator animator_Robot_Maze_2;
    public Animator animator_Robot_Maze_3;
    public Animator animator_Robots_Maze;




    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GameManager.Instance.myMuffinsDron.GetComponent<Text>().text = score.ToString();
        alive = true;
        SpawnCollectables();
        GameManager.Instance.buttonBackDron.GetComponent<Button>().onClick.AddListener(() => GoToMainScene());
        GameManager.Instance.UpdateCanvasDron();
        GameManager.Instance.UpdateBG();
    }

    private void Update()
    {

        GameManager.Instance.progressSliderDron.GetComponent<Slider>().value = score;   
    }

    public void SpawnCollectables()
    {
        foreach (GameObject point in spawnPoints)
        {
            if(spawnedCollectables.Count < spawnPoints.Count/2)
            {
                GameObject selected = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
                if(selected.transform.childCount <=0)
                {
                    GameObject collectable = Instantiate(prefabCollect, selected.transform.position, Quaternion.identity);
                    collectable.transform.parent = selected.transform;
                    spawnedCollectables.Add(collectable);
                }
            }        
        }
    }

    public void StopAllAnimations()
    {
        animator_SpawnPoints.enabled = false;
        animator_Cupcakes_Rot.enabled = false;
        animator_Robot_Maze_1.enabled = false;
        animator_Robot_Maze_2.enabled = false;
        animator_Robot_Maze_3.enabled = false;
        animator_Robots_Maze.enabled = false;
    }


    public void FinishPanel()
    {
        alive = false;
        StopAllAnimations();
        GameManager.Instance.finishPanelDron.SetActive(true);
        GameManager.Instance.yourMuffinsDron.GetComponent<Text>().text = score.ToString();
        float totalScore = score *150;
        GameManager.Instance.futureCoinsDron.GetComponent<Text>().text = totalScore.ToString();
    }

    public void GoToMainScene()
    {
        int c = score * 150;
        GameManager.Instance.chocoins += c;
        GameManager.Instance.UpdateChocoins();
        GameManager.Instance.dronGaming = false;
        GameManager.Instance.finishPanelDron.SetActive(false);
        GameManager.Instance.UpdateCanvasDron();
        GameManager.Instance.mainTheme.Play();
        SceneManager.UnloadSceneAsync("MazeWorld");
        GameManager.Instance.UpdateBG();
    }
}
