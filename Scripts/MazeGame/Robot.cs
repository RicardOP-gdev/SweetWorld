using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    GameObject head;
    GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        head = gameObject.transform.GetChild(0).gameObject; 
        body = gameObject.transform.GetChild(1).gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        head.transform.position = new Vector3(body.transform.position.x, body.transform.position.y + 0.8f, body.transform.position.z); 
    }
}
