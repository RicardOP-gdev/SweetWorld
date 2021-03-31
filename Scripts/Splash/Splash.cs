using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour
{
    public VideoPlayer splashV;

    // Start is called before the first frame update
    void Start()
    {
        splashV.loopPointReached += OnMovieFinished;
    }

    void OnMovieFinished(VideoPlayer player)
    {
        splashV = player;
        player.Stop();
        SceneManager.LoadScene("MainWorld", LoadSceneMode.Single);
    }
}
