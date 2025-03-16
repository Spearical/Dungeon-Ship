using UnityEngine;

public class PickupProjectile : MonoBehaviour, IProjectile
{
    [SerializeField]
    private float speed = 15.0f;

    public void SetProjectileSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetProjectileSprite(Sprite sprite)
    {
        if (TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
        {
            spriteRenderer.sprite = sprite;
        }
    }
}
