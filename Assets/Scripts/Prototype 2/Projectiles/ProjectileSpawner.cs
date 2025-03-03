using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;

    [SerializeField] 
    private Vector2 spawnCoordinateOffset;
    [SerializeField] 
    private float spawnRotationDegreesOffset;
    [SerializeField] 
    private float firingRate = 1.0f;
    [SerializeField] 
    private float speed = 1.0f;

    [SerializeField]
    private Sprite sprite;
    private GameObject spawnedProjectile;
    private float timer = 0.0f;    
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        if (projectilePrefab)
        {
            Vector3 offset = new Vector3(spawnCoordinateOffset.x, spawnCoordinateOffset.y, 0f);
            spawnedProjectile = Instantiate(projectilePrefab, transform.position + offset, Quaternion.identity);
            spawnedProjectile.GetComponent<EnemyProjectile>().SetProjectileSpeed(speed);
            spawnedProjectile.GetComponent<EnemyProjectile>().SetProjectileSprite(sprite);
            spawnedProjectile.transform.rotation = transform.rotation * Quaternion.Euler(0 ,0, spawnRotationDegreesOffset);
        }
    }
}
