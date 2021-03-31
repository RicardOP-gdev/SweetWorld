using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipManager : MonoBehaviour
{
    public GameObject shipGameObject;
    public Material classicM;
    public Material breakM;
    public Material killM;
    public Material bootyM;
    public float highDifference;
    public bool death;
    public List<GameObject> floors = new List<GameObject>();

    public void Start()
    {
        GameManager.Instance.buttonStartShip.GetComponent<Button>().onClick.AddListener(() => IniGame());
        GameManager.Instance.buttonStartShip.SetActive(true);
        GameManager.Instance.UpdateCanvasShip();
        GameManager.Instance.UpdateBG();
        highDifference = shipGameObject.transform.position.y - 275;
        foreach (GameObject platform in floors)
        {
            platform.transform.GetChild(Random.Range(0, 4)).gameObject.SetActive(true);
            
            Debug.Log(platform.transform.GetChild(0));
            switch(platform.transform.GetChild(0).tag)
            {
                case "Classic":
                    platform.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = classicM;
                    platform.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = classicM;
                    platform.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = classicM;
                    platform.transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = classicM;
                    break;
                case "Break":
                    platform.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = breakM;
                    platform.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = breakM;
                    platform.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = breakM;
                    platform.transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = breakM;
                    
                    break;
                case "Kill":
                    platform.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = killM;
                    platform.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = killM;
                    platform.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = killM;
                    platform.transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = killM;
                    platform.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                    platform.transform.GetChild(1).transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                    platform.transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                    platform.transform.GetChild(3).transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().enabled = true;
                    break;
                case "Booty":
                    platform.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = bootyM;
                    platform.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = bootyM;
                    platform.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = bootyM;
                    platform.transform.GetChild(3).transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = bootyM;
                    break;
            }    
        }
    }

    public void Update()
    {      
        if(!death)
        { 
            if (shipGameObject.transform.position.y -275 >= highDifference)
            {
                highDifference = shipGameObject.transform.position.y - 275;
                GameManager.Instance.heightTextShip.GetComponent<Text>().text = highDifference.ToString("F0");
                GameManager.Instance.progressSliderShip.GetComponent<Slider>().value = highDifference;
            }
            if(shipGameObject.transform.position.y >= 575)
            {
                EndGame();
            }
        }
    }


    public void IniGame()
    {
        Rigidbody rb = shipGameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        shipGameObject.GetComponent<FollowGyro>().enabled = true;
        rb.AddForce(0, 25, 0, ForceMode.Impulse);
        Instantiate(shipGameObject.GetComponent<Ship>().impulse, new Vector3(shipGameObject.transform.position.x, shipGameObject.transform.position.y, shipGameObject.transform.position.z), Quaternion.Euler(transform.forward));
        GameManager.Instance.buttonStartShip.SetActive(false);
    }

    public void EndGame()
    {
        if(death)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        int c = (int)highDifference;
        death = true;
        GameManager.Instance.finishPanelShip.SetActive(true);
        GameManager.Instance.yourHeightShip.GetComponent<Text>().text = c.ToString();
        float totalScore = highDifference * 5 + GameManager.Instance.chocoins ;
        GameManager.Instance.futureCoinsShip.GetComponent<Text>().text = totalScore.ToString("F0");
        GameManager.Instance.buttonBackShip.GetComponent<Button>().onClick.AddListener(() => Back());
    }

    public void Back()
    {
        float totalScore = highDifference * 5 + GameManager.Instance.chocoins;
        Destroy(GameObject.FindGameObjectWithTag("Gyro"));     
        GameManager.Instance.chocoins += (int)totalScore;
        GameManager.Instance.UpdateChocoins();
        GameManager.Instance.shipGaming = false;
        GameManager.Instance.UpdateCanvasShip();
        GameManager.Instance.mainTheme.Play();
        SceneManager.UnloadSceneAsync("ShipWorld");
        GameManager.Instance.finishPanelShip.SetActive(false);
        GameManager.Instance.UpdateBG();

    }
}
