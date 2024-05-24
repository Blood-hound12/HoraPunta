using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] HordesPrefabLevel1;
    [SerializeField] private GameObject[] HordesPrefabLevel2;
    [SerializeField] private GameObject[] HordesPrefabLevel3;
    [SerializeField] private Transform[] SpawnOrigins;

    [SerializeField] private float MinimumSpawnTimeLevel1, MaximumSpawnTimeLevel1, MinimumSpawnTimeLevel2, MaximumSpawnTimeLevel2, MinimumSpawnTimeLevel3, MaximumSpawnTimeLevel3;


    //private float gameCounter;
    public int CatsCounter;
    private int difficultyLevel = 1;
    private GameManager gameManager;
    private bool spawning = true;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        StartCoroutine(SpawnCats());
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
        //gameCounter += Time.deltaTime;

        UpdateDifficultyLevel();
    }

    private void UpdateDifficultyLevel()
    {
        if (gameManager.SuccessScore >= 240)
        {
            difficultyLevel = 3;
            Debug.Log("Difficulty Level: " + difficultyLevel);
        }
        else if (gameManager.SuccessScore >= 25)
        {
            difficultyLevel = 2;
            Debug.Log("Difficulty Level: " + difficultyLevel);
        }
        else
        {
            difficultyLevel = 1;
        }
    }

    private IEnumerator SpawnCats()
    {
        while (spawning)
        {
            float spawnTime = GetSpawnTime();
            yield return new WaitForSeconds(spawnTime);

            int randomSpawnOriginIndex = Random.Range(0, SpawnOrigins.Length);

            switch (difficultyLevel)
            {
                case 1:
                    SpawnHorde(HordesPrefabLevel1, randomSpawnOriginIndex);
                    break;
                case 2:
                    
                    if (Random.value < 0.5f)
                    {
                        SpawnHorde(HordesPrefabLevel1, randomSpawnOriginIndex);
                    }
                    else
                    {
                        SpawnHorde(HordesPrefabLevel2, randomSpawnOriginIndex);
                    }
                    break;
                case 3:

                    if (Random.value < 0.13f)
                    {
                        SpawnHorde(HordesPrefabLevel1, randomSpawnOriginIndex);
                    }
                    else if (Random.value < 0.43f)
                    {
                        SpawnHorde(HordesPrefabLevel2, randomSpawnOriginIndex);
                    }
                    else
                    {
                        SpawnHorde(HordesPrefabLevel3, randomSpawnOriginIndex);
                    }
                    break;
            }
        }
    }

    private void SpawnHorde(GameObject[] hordePrefabs, int spawnOriginIndex)
    {
        int randomHordeIndex = Random.Range(0, hordePrefabs.Length);
        Instantiate(hordePrefabs[randomHordeIndex], SpawnOrigins[spawnOriginIndex].position, Quaternion.identity);
    }

    private float GetSpawnTime()
    {
        switch (difficultyLevel)
        {
            case 1:
                return Random.Range(MinimumSpawnTimeLevel1, MaximumSpawnTimeLevel1);
            case 2:
                return Random.Range(MinimumSpawnTimeLevel2, MaximumSpawnTimeLevel2);
            case 3:
                return Random.Range(MinimumSpawnTimeLevel3, MaximumSpawnTimeLevel3);
            default:
                return Random.Range(MinimumSpawnTimeLevel1, MaximumSpawnTimeLevel1);
        }
    }
}

