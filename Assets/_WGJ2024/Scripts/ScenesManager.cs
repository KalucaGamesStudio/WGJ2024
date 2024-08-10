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
    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
   /* public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
        SceneManager.LoadScene(4);
    }*/
    public void Lose()
    {
        SceneManager.LoadScene(3);
    }
    public void Win()
    {
        SceneManager.LoadScene(4);
    }
}

