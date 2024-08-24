using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isCorrectDoor = false;

    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isCorrectDoor)
            {
                Debug.Log("Has cruzado la puerta correcta!");
                gameManager.OnPlayerCrossedCorrectDoor();
                // Aquí puedes manejar la lógica para pasar al siguiente nivel.
            }
            else
            {
                gameManager.ResetLevels();
                Debug.Log("Puerta incorrecta. Regresa al inicio.");
                // Aquí puedes manejar la lógica para hacer que el jugador reaparezca.
            }
        }
    }

}
