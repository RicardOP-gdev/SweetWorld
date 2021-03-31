using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWorld : MonoBehaviour
{
    public GameObject drakeWorld;
    public GameObject dronWorld;
    public GameObject shipWorld;
    public int worldPosition;
    public bool worldAct;

    public void Start()
    {
        worldPosition = 0;
    }
    public void LefthWorlds()
    {
            
            if(dronWorld.transform.position.x == -10)
            {
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().isOn = GameManager.Instance.shipActive;
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().onValueChanged.AddListener((w) => GameManager.Instance.OnValueChanged(GameManager.Instance.shipActive));
            dronWorld.transform.position = new Vector3(-20, 0, 0);
                drakeWorld.transform.position = new Vector3(-10, 0, 0);
                shipWorld.transform.position = new Vector3(0, 0, 0);
                worldPosition = 2;
            }
           
            else if(dronWorld.transform.position.x == 0)
            {
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().isOn = GameManager.Instance.drakeActive;
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().onValueChanged.AddListener((w) => GameManager.Instance.OnValueChanged(GameManager.Instance.drakeActive));
            dronWorld.transform.position = new Vector3(-10, 0, 0);
                drakeWorld.transform.position = new Vector3(0, 0, 0);
                shipWorld.transform.position = new Vector3(10, 0, 0);
                worldPosition = 1;                    
            }
         
    }

    public void RightWorlds()
    {
        
            if (shipWorld.transform.position.x == 10)
            {
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().isOn = GameManager.Instance.dronActive;
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().onValueChanged.AddListener((w) => GameManager.Instance.OnValueChanged(GameManager.Instance.dronActive));
            dronWorld.transform.position = new Vector3(0, 0, 0);
                drakeWorld.transform.position = new Vector3(10, 0, 0);
                shipWorld.transform.position = new Vector3(20, 0, 0);
                worldPosition = 0;
            }
            else if(shipWorld.transform.position.x == 0)
            {
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().isOn = GameManager.Instance.drakeActive;
            GameManager.Instance.worldsToggle.GetComponent<Toggle>().onValueChanged.AddListener((w) => GameManager.Instance.OnValueChanged(GameManager.Instance.drakeActive));
            dronWorld.transform.position = new Vector3(-10, 0, 0);
                drakeWorld.transform.position = new Vector3(0, 0, 0);
                shipWorld.transform.position = new Vector3(10, 0, 0);
                worldPosition = 1;
            }  
    }


}
