using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChocoBar : MonoBehaviour
{

    private GameObject drake;
    private ParticleSystem chocoNam;
    // Start is called before the first frame update
    void Start()
    {
        drake = GameObject.FindGameObjectWithTag("Drake");
        chocoNam = drake.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<ChocolateMovement>().chocoBars.Remove(this.gameObject);
        drake.GetComponent<Drake>().score += 10;
        drake.GetComponent<Drake>().textScore.text = drake.GetComponent<Drake>().score.ToString("Score: #");
        Destroy(this.gameObject);
        chocoNam.Play();
    }
}
