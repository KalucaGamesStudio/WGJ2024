using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawner : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("CheckPoint")]
    public Vector2 checkpointspos;
    public ScenesManager sceneManager;

    [Header("Timer")]
    [SerializeField] private TMP_Text Timertext;
    [SerializeField, Tooltip("Tiempo en segundos")] private float timerTime;
    private int minutes, seconds, cents;
    private float initialTimerTime;

    void Start()
    {
        initialTimerTime = timerTime;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timerTime -= Time.deltaTime;

        if (timerTime < 0) timerTime = 0;

        minutes = (int)(timerTime / 60f);
        seconds = (int)(timerTime - minutes * 60f);

        Timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timerTime == 0)
        {
            sceneManager.Lose();
        }
    }


    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointspos = pos;
    }
    public void revivir()
    {
        StartCoroutine(Respawn(1.25f));
    }

    //public GameManager gameManager;
    IEnumerator Respawn(float duration)
    {
        //gameManager.ShowRespawnScreen();

        rb.velocity = new Vector2(0, 0);
        rb.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        timerTime = initialTimerTime;
        //gameManager.ResetLevel();
        transform.position = checkpointspos;
        transform.localScale = new Vector3(1f, 1f, 1f);
        rb.simulated = true;
        enabled = true;
       //gameManager.HideRespawnScreen();

    }

}
