using UnityEngine;

public class DeflectionShield : MonoBehaviour
{
    [SerializeField]
    public GameObject deflectedProjectilePrefab;
    private GameObject tmpProjectile;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Deflectable>(out Deflectable deflectable))
        {
            tmpProjectile = Instantiate(deflectedProjectilePrefab, transform.position + Vector3.up, Quaternion.identity);
        }
    }
}
