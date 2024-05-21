using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] HordesPrefab;
    [SerializeField] private Transform[] SpawnOrigins;

    [SerializeField] private float MinimumSpawnTimeLevel1, MaximumSpawnTimeLevel1, MinimumSpawnTimeLevel2, MaximumSpawnTimeLevel2, MinimumSpawnTimeLevel3, MaximumSpawnTimeLevel3;


    private float gameCounter;
    public int CatsCounter;
    private int difficultyLevel = 1;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void AddCatToCounter()
    {
        CatsCounter += 1;
    }

    public void RemoveCatFromCounter()
    {
        CatsCounter -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameCounter += Time.deltaTime;

        UpdateDifficultyLevel();
    }

    private void UpdateDifficultyLevel()
    {
        if (gameCounter > 240)
        {
            difficultyLevel = 3;
            Debug.Log("Difficulty Level: " + difficultyLevel);
        }
        else if (gameCounter > 80)
        {
            difficultyLevel = 2;
            Debug.Log("Difficulty Level: " + difficultyLevel);
        }
        else
        {
            difficultyLevel = 1;
            Debug.Log("Difficulty Level: " + difficultyLevel);
        }
    }

    // Funcion para generar gatos segun vagones y nivel de dificultad
}

