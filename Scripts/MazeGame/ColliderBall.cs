using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderBall : MonoBehaviour
{
    public GameObject controller;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cupcake")
        {
            Destroy(other.gameObject);
            controller.GetComponent<MazeController>().score++;
            GameManager.Instance.myMuffinsDron.GetComponent<Text>().text = controller.GetComponent<MazeController>().score.ToString();
            if(controller.GetComponent<MazeController>().score >= 10)
            {
                controller.GetComponent<MazeController>().FinishPanel();
            }
            GameManager.Instance.pickUpMuffinS.Play();
            // PlaySound
        }

        if(other.tag == "Kill")
        {
            controller.GetComponent<MazeController>().FinishPanel();
            GameManager.Instance.gameOverDronS.Play();
        }
    }
}
