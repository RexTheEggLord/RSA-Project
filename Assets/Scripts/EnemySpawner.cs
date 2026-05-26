using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private int baseEnemies = 6;
    [SerializeField] private float enemiesPerSecond = 0.9f;
    [SerializeField] private float timeBetweenSpawns = 5f;
    [SerializeField] private float difficultyIncreaseInterval = 0.75f;
    [SerializeField] private GameObject decreaselives;

    public static UnityEvent onEnemyDestroyed = new UnityEvent();


    private int currentWaves = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    private int livesSystem;

    private void Awake()
    {
        onEnemyDestroyed.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
        livesSystem = levelManger.main.lives;

    }
    private void Update()
    {
        
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEvil();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesLeftToSpawn == 0 && enemiesAlive == 0)
        {
            EndWave();
        }
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWaves++;
        StartCoroutine(StartWave());
    }

    private void EnemyDestroyed()
    {
        
        enemiesAlive--;
        if (enemiesAlive <= 0 && enemiesLeftToSpawn <= 0)
        {
            currentWaves++;
            if (livesSystem < 20)
            {
                livesSystem = +1;
            }
            StartWave();
        }
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }
    private void SpawnEvil()
    {
        GameObject prefabToSpawn = enemyPrefab[0];
        Instantiate(prefabToSpawn, levelManger.main.startPoint.position, Quaternion.identity);
    }
    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWaves, difficultyIncreaseInterval));
    }


}
