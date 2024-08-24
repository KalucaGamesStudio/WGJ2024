using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour
{
    [Header("Level Reset")]
    [SerializeField] private GameObject[] RespawnLevels;
    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private Transform parent;

    private List<int> remainingLevels;
    private List<int> playedLevels;

    private void Start()
    {
        InitializeLevels();
        SelectRandomRespawnObject();
    }

    private void InitializeLevels()
    {
        remainingLevels = new List<int>();
        playedLevels = new List<int>();

        // Añadimos todos los índices de niveles menos el último (final)
        for (int i = 0; i < RespawnLevels.Length - 1; i++)
        {
            remainingLevels.Add(i);
        }
    }

    public void SelectRandomRespawnObject()
    {
        if (_currentLevel != null)
        {
            // Destruir el nivel actual
            Destroy(_currentLevel);
            // Asegurarse de que el objeto realmente se destruya antes de continuar
            _currentLevel = null;
        }

        if (remainingLevels.Count == 0)
        {
            // Si no hay más niveles restantes, instanciamos el nivel final
            SpawnFinalLevel();
            return;
        }

        // Seleccionar un nivel aleatorio de los restantes
        int randomIndex = UnityEngine.Random.Range(0, remainingLevels.Count);
        int selectedLevelIndex = remainingLevels[randomIndex];

        // Actualizamos las listas
        remainingLevels.RemoveAt(randomIndex);
        playedLevels.Add(selectedLevelIndex);

        Debug.Log("Instanciando nivel aleatorio");

        _currentLevel = Instantiate(RespawnLevels[selectedLevelIndex], parent);

        Level levelComponent = _currentLevel.GetComponent<Level>();
        if (levelComponent == null)
        {
            Debug.LogError("El prefab de nivel en el índice " + selectedLevelIndex + " no tiene un componente Level.");
            return;
        }

        int correctDoorIndex = UnityEngine.Random.Range(0, levelComponent.doors.Length);
        levelComponent.SetCorrectDoor(correctDoorIndex);
    }

    public void SpawnFinalLevel()
    {
        if (_currentLevel != null)
        {
            // Destruir el nivel actual
            Destroy(_currentLevel);
            // Asegurarse de que el objeto realmente se destruya antes de continuar
            _currentLevel = null;
        }

        int finalIndex = RespawnLevels.Length - 1;

        Debug.Log("Instanciando el nivel final");

        _currentLevel = Instantiate(RespawnLevels[finalIndex], parent);
    }

    // Este método lo llamarás cuando el jugador cruce una puerta correcta
    public void OnPlayerCrossedCorrectDoor()
    {
        SelectRandomRespawnObject();
    }

    // Este método lo llamarás cuando el jugador muera o reintente el nivel
    public void ResetLevels()
    {
        // Reinicia las listas para que el jugador pueda jugar todos los niveles de nuevo
        InitializeLevels();
        SelectRandomRespawnObject();
    }

}
