using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;

    [SerializeField] 
    private Vector2 spawnCoordinateOffset;
    [SerializeField] 
    private float spawnRotationDegreesOffset;
    [SerializeField] 
    private float firingStartDelay = 0.0f;
    [SerializeField] 
    private float firingRate = 1.0f;
    [SerializeField] 
    private float speed = 1.0f;
    private bool isInitialFire;

    [SerializeField]
    private Sprite sprite;
    private GameObject spawnedProjectile;
    private float timer = 0.0f;

    private void Start()
    {
        isInitialFire = true;
        StartCoroutine(DelayCoroutine());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= firingRate && !isInitialFire)
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
            spawnedProjectile = Instantiate(projectilePrefab, transform.position + offset, Quaternion.Euler(0, 0, spawnRotationDegreesOffset));
            spawnedProjectile.GetComponent<IProjectile>().SetProjectileSpeed(speed);
            spawnedProjectile.GetComponent<IProjectile>().SetProjectileSprite(sprite);
        }
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(firingStartDelay);
        isInitialFire = false;
    }
}
