using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public List<GameObject> platform;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.position.x, 314, transform.position.z + gameManager.GetComponent<ChocoDrakeManager>().speedGame * Time.deltaTime);
        if (transform.position.z <= -30)
        {
            transform.localPosition = new Vector3(transform.position.x, 314, 45.1f);
        }      
    }
}
