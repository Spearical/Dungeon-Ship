using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int spawnerDestroyedScore = 100;
    [SerializeField]
    private float initialSpawnDelay = 1.0f;
    [SerializeField]
    private float enemySpawnDelay = 3.0f;
    [SerializeField]
    private float allowableRespawns = 3.0f;
    [SerializeField]
    private int currentRespawnCount;
    [SerializeField]
    private bool currentlySpawningEnemies;
    private bool isInitialSpawnPhase;
    private EnemySpawnerVisual enemySpawnerVisual;
    private EnemySpawnerSFX enemySpawnerSFX;
    private GameObject enemies;
    private List<GameObject> enemiesList;
    private const float ENEMY_SPAWN_BUFFER_TIME = 1.0f;

    private GameManager gameManager;

    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    void Awake()
    {
        enemySpawnerVisual = GetComponent<EnemySpawnerVisual>();
        enemySpawnerSFX =  GetComponent<EnemySpawnerSFX>();
        enemies = transform.Find("Enemies").gameObject;
        enemiesList = enemies.GetChildren();
    }

    void Start()
    {
        isInitialSpawnPhase = true;
        currentlySpawningEnemies = true;
        currentRespawnCount = 0;
        StartCoroutine(InitialSpawnEnemiesFromPortal());
    }

    void Update()
    {
        if (!isInitialSpawnPhase && !currentlySpawningEnemies 
            && currentRespawnCount < allowableRespawns)
        {
            CheckAllChildrenInactive();
        }
    }

    IEnumerator SpawnEnemies()
    {
        foreach (GameObject enemy in enemiesList)
        {
            if (!isInitialSpawnPhase)
            {
                enemy.transform.localPosition = Vector2.zero;

                IHealth health = enemy.GetComponent<IHealth>();
                health.ChangeHealth(health.GetMaxHealth());
            }

            enemySpawnerVisual.PlayPortalEffect();
            enemySpawnerSFX.PlayPortalOpenedSFX();
            enemy.SetActive(true);

            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }

    IEnumerator InitialSpawnEnemiesFromPortal()
    {
        yield return new WaitForSeconds(initialSpawnDelay);
        yield return StartCoroutine(SpawnEnemies());
        currentlySpawningEnemies = false;
        isInitialSpawnPhase = false;
    }

    IEnumerator SpawnEnemiesFromPortalAfterTimer()
    {
        yield return new WaitForSeconds(ENEMY_SPAWN_BUFFER_TIME);
        currentRespawnCount++;
        yield return StartCoroutine(SpawnEnemies());
        currentlySpawningEnemies = false;
    }

    private void CheckAllChildrenInactive()
    {
        bool isAllInactive = true;
        foreach (GameObject enemy in enemiesList)
        {
            if (enemy.activeSelf)
            {
                isAllInactive =  false;
                break;
            }
        }
        
        if (isAllInactive)
        {
            if (!isInitialSpawnPhase)
            {
                gameManager.UpdateScore(spawnerDestroyedScore);
            }
            currentlySpawningEnemies = true;
            StartCoroutine(SpawnEnemiesFromPortalAfterTimer());
        }
    }
}
