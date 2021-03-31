using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseGyro : MonoBehaviour
{

    void Start()
    {
        GyroManager.Instance.EnableGyro();
        transform.position = new Vector3(0, 320, -8.1549f);
    }


    void Update()
    {
        if (GyroManager.Instance.GetGyroRotation().z <= 0.500f)
        {
            transform.localPosition = new Vector3(GyroManager.Instance.GetGyroRotation().y * -15f, transform.localPosition.y, -8.1549f);

        }
        if (GyroManager.Instance.GetGyroRotation().z >= 0.500)
        {
            transform.localPosition = new Vector3(GyroManager.Instance.GetGyroRotation().x * -15f, transform.localPosition.y, -8.1549f);

        }
    }
}