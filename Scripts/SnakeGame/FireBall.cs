using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBall : MonoBehaviour
{
    private GameObject drake;
    private GameObject gameManager;
    private float speedRock;
   

    // Start is called before the first frame update
    void Start()
    {
        drake = GameObject.FindGameObjectWithTag("Drake");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        speedRock = gameManager.GetComponent<ChocoDrakeManager>().speedGame - 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.position.x, 320.5f, transform.position.z + speedRock * Time.deltaTime);
        if (transform.position.z <= -10)
        {
            transform.localPosition = gameManager.GetComponent<ChocoDrakeManager>().chocoSpawns[Random.Range(0, 8)];
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        gameManager.GetComponent<ChocoDrakeManager>().fireBallsList.Remove(gameObject);
        drake.GetComponent<Drake>().life -= 1;
        gameManager.GetComponent<ChocoDrakeManager>().damage.Play();
        switch (drake.GetComponent<Drake>().life)
        {
            case 2:
                GameManager.Instance.hearth3.GetComponent<Image>().sprite = GameManager.Instance.hearthEmpty;
                GameManager.Instance.hearth3.GetComponent<Animator>().enabled = false;
                GameManager.Instance.hearth2.GetComponent<Animator>().speed = 1.5f;
                GameManager.Instance.hearth1.GetComponent<Animator>().speed = 1.5f;
                break;
            case 1:
                GameManager.Instance.hearth2.GetComponent<Image>().sprite = GameManager.Instance.hearthEmpty;
                GameManager.Instance.hearth2.GetComponent<Animator>().enabled = false;
                GameManager.Instance.hearth1.GetComponent<Animator>().speed = 2;
                break;
            case 0:
                GameManager.Instance.hearth1.GetComponent<Image>().sprite = GameManager.Instance.hearthEmpty;
                GameManager.Instance.hearth1.GetComponent<Animator>().enabled = false;
                break;
        }
        drake.GetComponent<Drake>().lifesText.text = drake.GetComponent<Drake>().life.ToString("Lifes #");
        Destroy(gameObject);
    }
}
