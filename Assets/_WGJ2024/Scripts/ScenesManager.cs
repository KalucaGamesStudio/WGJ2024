using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }
    public void Game()
    {
        SceneManager.LoadScene(2);
    }
    public void Lose()
    {
        SceneManager.LoadScene(3);
    }
    public void Win()
    {
        SceneManager.LoadScene(4);
    }
}

