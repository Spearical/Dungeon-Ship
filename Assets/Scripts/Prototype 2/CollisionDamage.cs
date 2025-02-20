using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public float dmgAmount = 45;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObject = collision.gameObject;
        TryDamageObject(hitObject);
    }

    void TryDamageObject(GameObject objectToDamage)
    { 
        if(objectToDamage.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage(-dmgAmount);
        }
        else
        {
            Debug.Log("That object cannot be damaged.");
        }
    }
}
