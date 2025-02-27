using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public float playerDmgAmount = 0;
    public float enemyDmgAmount = 0;
    public float brickDmgAmount = 0;
    public bool enableHitAll = false;
    public float baseDmgAmount = 45;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;

        // TODO: Refactor this to be cleaner
        if (!enableHitAll)
        {
            if (playerDmgAmount > 0 && hitObject.CompareTag("Player"))
            {
                TryDamagePlayer(hitObject, playerDmgAmount);
            }
            else if (enemyDmgAmount > 0 && hitObject.CompareTag("Enemy"))
            {
                TryDamageObject(hitObject, enemyDmgAmount);
            } 
            else if (brickDmgAmount > 0 && hitObject.CompareTag("Brick"))
            {
                TryDamageObject(hitObject, brickDmgAmount);
            }
        }
        else 
        {
            TryDamageObject(hitObject, baseDmgAmount);
        }
    }

    void TryDamageObject(GameObject objectToDamage, float dmgAmount)
    { 
        if(objectToDamage.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage(-dmgAmount);
        }
    }

    void TryDamagePlayer(GameObject objectToDamage, float dmgAmount)
    { 
        if(objectToDamage.TryGetComponent(out PlayerDamageController damageablePlayer))
        {
            damageablePlayer.DealDamageToPlayer(-dmgAmount);
        }
    }
}
