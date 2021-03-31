using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateMovement : MonoBehaviour
{
    public List<GameObject> chocoBars = new List<GameObject>();
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        if(chocoBars.Count <=0)
        {
            gameManager.GetComponent<ChocoDrakeManager>().chocoComboList.Remove(gameObject);
            Destroy(gameObject);
        }
        transform.localPosition = new Vector3(transform.position.x, 320, transform.position.z + gameManager.GetComponent<ChocoDrakeManager>().speedGame * Time.deltaTime);
        if(transform.position.z <= -10)
        {
            transform.localPosition = gameManager.GetComponent<ChocoDrakeManager>().chocoSpawns[Random.Range(0,8)];
               // new Vector3(transform.position.x, transform.position.y, 20);
        }       
    }
}
