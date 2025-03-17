using UnityEngine;

public class EnemyDeathSpawnPickup : MonoBehaviour
{
    public GameObject pickupPrefab;

    public void SpawnPickupOnDeath()
    {
        Vector3 spawnPosition =  new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
    }
}
