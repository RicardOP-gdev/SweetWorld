using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public Rigidbody player;
    public Renderer renderea;
    public GameObject shipManager;
    public int score;
    public GameObject impulseGO;
    public ParticleSystem impulse;

    public void Start()
    {
        //transform.position = new Vector3(600,1.3f,-3.83f);
        shipManager = GameObject.FindGameObjectWithTag("ShipManager");
        impulse = impulseGO.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.transform.parent.tag;
        switch(tag)
        {
            case "Classic":
                if ((collision.gameObject.tag == "Platform") && (player.velocity.y <= 1f))
                {
                    player.AddForce(0, 20, 0, ForceMode.Impulse);
                    Instantiate(impulse, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
                    Debug.Log("Classic");                    
                }
                break;
             case "Break":
                if ((collision.gameObject.tag == "Platform") && (player.velocity.y <= 1f))
                {
                    player.AddForce(0, 20, 0, ForceMode.Impulse);
                    Instantiate(impulse, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity); 
                    Debug.Log("Break");
                    Destroy(collision.transform.parent.gameObject);
                }
                break;
            case "Kill":
                if ((collision.gameObject.tag == "Platform") && (player.velocity.y <= 1f))
                {
                    player.AddForce(0, 20, 0, ForceMode.Impulse);
                    Instantiate(impulse, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity); Debug.Log("Kill");
                }
                break;
            case "Booty":
                if ((collision.gameObject.tag == "Platform") && (player.velocity.y <= 1f))
                {
                    player.AddForce(0, 35, 0, ForceMode.Impulse);
                    Instantiate(impulse, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
                    Debug.Log("Booty");
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.transform.parent.tag;
        switch(tag)
        {
            case "Classic":
                if (other.tag == "PlatformTrigger")
                {
                    Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>(), true);
                    Debug.Log("EnteredTrigger");
                }
                break;
            case "Break":
                if (other.tag == "PlatformTrigger")
                {
                    Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>(), true);
                    Debug.Log("EnteredTrigger");
                }
                break;
            case "Kill":
                if (other.tag == "PlatformTrigger")
                {
                    shipManager.GetComponent<ShipManager>().GameOver();
                    //Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>(), true);
                    Debug.Log("EnteredTrigger");
                    Debug.Log("Killed");
                }
                break;
            case "Booty":
                if (other.tag == "PlatformTrigger")
                {  
                    Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>(), true);
                    Debug.Log("EnteredTrigger");
                    
                }
                break;

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        string tag = other.transform.parent.tag;
        switch (tag)
        {
            case "Classic":
                if (other.tag == "PlatformTrigger")
                {
                    Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>(), false);
                    Debug.Log("ExitedTrigger");
                }
                break;
            case "Break":
                if (other.tag == "PlatformTrigger")
                {
                    Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>(), false);
                    Debug.Log("ExitedTrigger");
                }
                break;
            case "Booty":
                if (other.tag == "PlatformTrigger")
                {
                    Physics.IgnoreCollision(other.transform.parent.GetChild(0).GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>(), false);
                    Debug.Log("EnteredTrigger");                 
                }
                break;
        }
        
    }

}
