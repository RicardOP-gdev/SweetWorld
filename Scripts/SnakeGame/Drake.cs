using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drake : MonoBehaviour
{

    [Header("Score")]
    public int score;
    public Text textScore;
    public Text lifesText;

    [Header("Lifes")]
    public int life;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        lifesText.text = life.ToString("Lifes #");
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
