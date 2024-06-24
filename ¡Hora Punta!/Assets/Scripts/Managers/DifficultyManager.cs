using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] HordesPrefabLevel1;
    [SerializeField] private GameObject[] HordesPrefabLevel2;
    [SerializeField] private GameObject[] HordesPrefabLevel3;
    [SerializeField] private GameObject[] ShoplifterPrefab;
    [SerializeField] private GameObject[] MusicianPrefab;
    [SerializeField] private GameObject[] VagonsPrefabLevel1;
    [SerializeField] private GameObject[] VagonsPrefabLevel2;
    [SerializeField] private GameObject[] VagonsPrefabLevel3;

    [SerializeField] private Transform VagonOrigin;
    [SerializeField] private Transform[] MusicianSpawnOrigins;
    [SerializeField] private Transform[] SpawnOrigins;
    [SerializeField] private Transform[] ShoplifterSpawnOrigins;

    [SerializeField] private float MinimumSpawnTimeLevel1, MaximumSpawnTimeLevel1, MinimumSpawnTimeLevel2, MaximumSpawnTimeLevel2, MinimumSpawnTimeLevel3, MaximumSpawnTimeLevel3;
    [SerializeField] private float MinimumShoplifterSpawnTime, MaximumShoplifterSpawnTime;
    [SerializeField] private float MinimumMusicianSpawnTime = 30f, MaximumMusicianSpawnTime = 50f;
    [SerializeField] private float MinimumVagonSpawnTime = 1f, MaximumVagonSpawnTime = 2f;

    public int CatsCounter;
    private int difficultyLevel = 1;
    private GameManager gameManager;
    private bool spawning = true;
    private GameObject currentVagon = null;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        StartCoroutine(SpawnCats());
        StartCoroutine(SpawnShoplifters());
        StartCoroutine(SpawnMusicians());
        StartCoroutine(SpawnVagons());
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
        if (gameManager.SuccessScore >= 50)
        {
            difficultyLevel = 3;
        }
        else if (gameManager.SuccessScore >= 25)
        {
            difficultyLevel = 2;
        }
        else
        {
            difficultyLevel = 1;
        }
    }

    private IEnumerator SpawnVagons()
    {
        currentVagon = Instantiate(VagonsPrefabLevel1[0], VagonOrigin.position, Quaternion.identity);

        while (spawning)
        {
            if (currentVagon == null)
            {
                float spawnTime = Random.Range(MinimumVagonSpawnTime, MaximumVagonSpawnTime);
                yield return new WaitForSeconds(spawnTime);

                GameObject[] vagonArray = null;

                switch (difficultyLevel)
                {
                    case 1:
                        vagonArray = VagonsPrefabLevel1;
                        break;
                    case 2:
                        vagonArray = VagonsPrefabLevel2;
                        break;
                    case 3:
                        vagonArray = VagonsPrefabLevel3;
                        break;
                }

                int randomVagonIndex = Random.Range(0, vagonArray.Length);
                currentVagon = Instantiate(vagonArray[randomVagonIndex], VagonOrigin.position, Quaternion.identity);
            }

            yield return null;
        }
    }


    private IEnumerator SpawnShoplifters()
    {
        while (true)
        {
            float spawnTime = Random.Range(MinimumShoplifterSpawnTime, MaximumShoplifterSpawnTime);
            yield return new WaitForSeconds(spawnTime);

            if (!AreMusiciansOrShopliftersPresent("Musician"))
            {
                int randomSpawnOriginIndex = Random.Range(0, ShoplifterSpawnOrigins.Length);
                Transform spawnOrigin = ShoplifterSpawnOrigins[randomSpawnOriginIndex];

                int randomShoplifterIndex = Random.Range(0, ShoplifterPrefab.Length);
                Instantiate(ShoplifterPrefab[randomShoplifterIndex], spawnOrigin.position, Quaternion.identity);
            }
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

    private IEnumerator SpawnMusicians()
    {
        while (true)
        {
            float spawnTime = Random.Range(MinimumMusicianSpawnTime, MaximumMusicianSpawnTime);
            yield return new WaitForSeconds(spawnTime);

            if (!AreMusiciansOrShopliftersPresent("Shoplifter"))
            {
                int randomSpawnOriginIndex = Random.Range(0, MusicianSpawnOrigins.Length);
                Transform spawnOrigin = MusicianSpawnOrigins[randomSpawnOriginIndex];

                int randomMusicianIndex = Random.Range(0, MusicianPrefab.Length);
                Instantiate(MusicianPrefab[randomMusicianIndex], spawnOrigin.position, Quaternion.identity);
            }
        }
    }

    private void SpawnHorde(GameObject[] hordePrefabs, int spawnOriginIndex)
    {
        int randomHordeIndex = Random.Range(0, hordePrefabs.Length);
        Instantiate(hordePrefabs[randomHordeIndex], SpawnOrigins[spawnOriginIndex].position, Quaternion.identity);
    }
    private bool AreMusiciansOrShopliftersPresent(string tag)
    {
        return GameObject.FindGameObjectWithTag(tag) != null;
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

