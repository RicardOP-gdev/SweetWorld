using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowGyro : MonoBehaviour
{

    void Start()
    {
        GyroManager.Instance.EnableGyro();
        transform.position = new Vector3(0, 275.6f, -5);
    }

    
    void Update()
    {
            if (GyroManager.Instance.GetGyroRotation().z <= 0.500f)
            {
                transform.localPosition = new Vector3(GyroManager.Instance.GetGyroRotation().y * -20f, transform.localPosition.y, -4.53f);

            }
            if (GyroManager.Instance.GetGyroRotation().z >= 0.500)
            {
                transform.localPosition = new Vector3(GyroManager.Instance.GetGyroRotation().x * -20f, transform.localPosition.y, -4.53f);

            }       
    }
}
