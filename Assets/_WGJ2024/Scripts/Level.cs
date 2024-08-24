using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Door[] doors;

    public void SetCorrectDoor(int correctDoorIndex)
    {
        if (correctDoorIndex >= 0 && correctDoorIndex < doors.Length)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].isCorrectDoor = (i == correctDoorIndex);
            }
            Debug.Log("Puerta correcta asignada: " + correctDoorIndex);
        }
        else
        {
            Debug.LogError("�ndice de puerta incorrecto.");
        }
    }

}
