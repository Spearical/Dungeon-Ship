using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float initialSpawnDelay = 1.0f;
    [SerializeField]
    private float enemySpawnDelay = 3.0f;

    private EnemySpawnerVisual enemySpawnerVisual;
    private GameObject enemies;
    private List<GameObject> enemiesList;

    void Awake()
    {
        enemySpawnerVisual = GetComponent<EnemySpawnerVisual>();
        enemies = transform.Find("Enemies").gameObject;
        enemiesList = enemies.GetChildren();
    }

    void Start()
    {
        Invoke(nameof(SpawnEnemiesFromPortal), initialSpawnDelay);
    }
    IEnumerator SpawnEnemies()
    {
        foreach (GameObject enemy in enemiesList)
        {
            enemySpawnerVisual.PlayPortalEffect();
            enemy.SetActive(true);
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }

    public void SpawnEnemiesFromPortal()
    {
        StartCoroutine(SpawnEnemies());
    }
}
