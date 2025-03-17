using UnityEngine;

public class DeflectionShield : MonoBehaviour
{
    [SerializeField]
    private GameObject deflectedProjectilePrefab;
    private GameObject tmpProjectile;

    [SerializeField]
    private 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Deflectable>(out Deflectable deflectable))
        {
            tmpProjectile = Instantiate(deflectedProjectilePrefab, collision.transform.position, Quaternion.identity);
            
            if (tmpProjectile.TryGetComponent<DeflectedProjectile>(out DeflectedProjectile deflectedProjectile))
            {
                deflectedProjectile.collisionDamage.brickDmgAmount *= deflectable.deflectionDamageMultiplier;
                deflectedProjectile.collisionDamage.enemyDmgAmount *= deflectable.deflectionDamageMultiplier;
                deflectedProjectile.ScaleUpEnergyOrbSize(deflectable.deflectionSizeMultiplier);
            }
        }
    }
}
