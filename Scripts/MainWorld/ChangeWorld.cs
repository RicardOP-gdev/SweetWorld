using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour
{
    public GameObject drakeWorld;
    public GameObject dronWorld;
    public GameObject shipWorld;
    
    public void LefthWorlds()
    {
        
            if(dronWorld.transform.position.x == -10)
            {
                dronWorld.transform.position = new Vector3(-20, 0, 0);
                drakeWorld.transform.position = new Vector3(-10, 0, 0);
                shipWorld.transform.position = new Vector3(0, 0, 0);
            }
           
            else if(dronWorld.transform.position.x == 0)
            {
                dronWorld.transform.position = new Vector3(-10, 0, 0);
                drakeWorld.transform.position = new Vector3(0, 0, 0);
                shipWorld.transform.position = new Vector3(10, 0, 0);
            }
         
    }

    public void RightWorlds()
    {
        
            if (shipWorld.transform.position.x == 10)
            {
                dronWorld.transform.position = new Vector3(0, 0, 0);
                drakeWorld.transform.position = new Vector3(10, 0, 0);
                shipWorld.transform.position = new Vector3(20, 0, 0);
            }
            else if(shipWorld.transform.position.x == 0)
            {
                dronWorld.transform.position = new Vector3(-10, 0, 0);
                drakeWorld.transform.position = new Vector3(0, 0, 0);
                shipWorld.transform.position = new Vector3(10, 0, 0);
            }

            
        
    }


}
