using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    private static GyroManager instance;

    [Header("LogicGyro")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;

    public static GyroManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                    instance.tag ="Gyro";
                }
            }

            return instance;
        }

        set 
        { 
            instance = value; 
        }
    }

    public void EnableGyro()
    {
        if(gyroActive) return;
        
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        }
        else
        {
            // Debug.LogError("Gyro is not supported on this device");
        }
    }

    private void Update()
    {
        if(gyroActive)
        {
            rotation = gyro.attitude;
        }
    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}
