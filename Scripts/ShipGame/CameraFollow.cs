using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public GameObject shipManager;
    public float smoothSpeed = 0.3f;



    private void LateUpdate()
    {
        if ((transform.position.y - target.position.y >= 20) && (shipManager.GetComponent<ShipManager>().death == false))
        {
            shipManager.GetComponent<ShipManager>().death = true;
            shipManager.GetComponent<ShipManager>().EndGame();                      
        }
        if(target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        }
    }
}

