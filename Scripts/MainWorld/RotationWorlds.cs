using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWorlds : MonoBehaviour
{
    public float speed = 15;
    public bool rock;

    private void Start()
    {
        if (rock)
        {

            speed = Random.Range(30, 45);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(rock)
        {
            
            transform.Rotate(speed * Time.deltaTime, speed  * Time.deltaTime, speed  * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        
    }
}
