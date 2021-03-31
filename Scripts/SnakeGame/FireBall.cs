using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private GameObject drake;
    private GameObject gameManager;
   

    // Start is called before the first frame update
    void Start()
    {
        drake = GameObject.FindGameObjectWithTag("Drake");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.position.x, 320.5f, transform.position.z + gameManager.GetComponent<ChocoDrakeManager>().speedGame * Time.deltaTime);
        if (transform.position.z <= -10)
        {
            transform.localPosition = gameManager.GetComponent<ChocoDrakeManager>().chocoSpawns[Random.Range(0, 8)];
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        gameManager.GetComponent<ChocoDrakeManager>().fireBallsList.Remove(gameObject);
        drake.GetComponent<Drake>().life -= 1;
        drake.GetComponent<Drake>().lifesText.text = drake.GetComponent<Drake>().life.ToString("Lifes #");
        Destroy(gameObject);
    }
}
