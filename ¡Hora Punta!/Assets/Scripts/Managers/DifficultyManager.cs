using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] CatPrefab;

    [SerializeField] private Transform[] SpawnOrigins;

    [SerializeField] private float MinimumSpawnTime;

    [SerializeField] private float MaximumSpawnTime;

    private float TimeUntilSpawn;
    private float CatSelected;
    private float SpawnSelected;
    private float GameCounter;


    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        TimeUntilSpawn -= Time.deltaTime;
        GameCounter += Time.deltaTime;


        if(TimeUntilSpawn <= 0)
        {
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        SpawnSelected = Random.Range(0, 6);
        CatSelected = Random.Range(0, 3);

        if ((SpawnSelected == 1) && (CatSelected == 1))
        {
            Instantiate(CatPrefab[0], SpawnOrigins[0].position, Quaternion.identity);
        }

        if ((SpawnSelected == 2) && (CatSelected == 1))
        {
            Instantiate(CatPrefab[0], SpawnOrigins[1].position, Quaternion.identity);
        }

        if ((SpawnSelected == 3) && (CatSelected == 1))
        {
            Instantiate(CatPrefab[0], SpawnOrigins[2].position, Quaternion.identity);
        }

        if((SpawnSelected == 4) && (CatSelected == 1))
        {
            Instantiate(CatPrefab[0], SpawnOrigins[3].position, Quaternion.identity);
        }

        if((SpawnSelected == 5) && (CatSelected == 1))
        {
            Instantiate(CatPrefab[0], SpawnOrigins[4].position, Quaternion.identity);
        }

        if((SpawnSelected == 1) && (CatSelected == 2))
        {
            Instantiate(CatPrefab[1], SpawnOrigins[0].position, Quaternion.identity);
        }

        if((SpawnSelected == 2) && (CatSelected == 2))
        {
            Instantiate(CatPrefab[1], SpawnOrigins[1].position, Quaternion.identity);
        }

        if((SpawnSelected == 3) && (CatSelected == 2))
        {
            Instantiate(CatPrefab[1], SpawnOrigins[2].position, Quaternion.identity);
        }

        if((SpawnSelected == 4) && (CatSelected == 2))
        {
            Instantiate(CatPrefab[1], SpawnOrigins[3].position, Quaternion.identity);
        }

        if((SpawnSelected == 5) && (CatSelected == 2))
        {
            Instantiate(CatPrefab[1], SpawnOrigins[4].position, Quaternion.identity);
        }

        TimeUntilSpawn = Random.Range(MinimumSpawnTime, MaximumSpawnTime);
    }
}
