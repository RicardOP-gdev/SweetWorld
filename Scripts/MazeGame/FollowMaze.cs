using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowMaze : MonoBehaviour
{

    void Start()
    {
        GyroManager.Instance.EnableGyro();
        transform.position = new Vector3(0, 900, 0);
    }


    void Update()
    {
        //gameObject.transform.localEulerAngles = new Vector3(GyroManager.Instance.GetGyroRotation().x * 30, 0, GyroManager.Instance.GetGyroRotation().y*30);

        if (GyroManager.Instance.GetGyroRotation().z <= 0.500f)
        {
            gameObject.transform.localEulerAngles = new Vector3(GyroManager.Instance.GetGyroRotation().x * 30, 0, GyroManager.Instance.GetGyroRotation().y * 30);

        }
        if (GyroManager.Instance.GetGyroRotation().z >= 0.500)
        {
            gameObject.transform.localEulerAngles = new Vector3(GyroManager.Instance.GetGyroRotation().y * 30, 0, GyroManager.Instance.GetGyroRotation().x * 30);

        }
    }
}
