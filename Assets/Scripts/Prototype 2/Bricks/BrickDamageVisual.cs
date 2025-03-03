using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BrickDamageVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite above75PercentHealthSprite;
    public Sprite between75And50PercentHealthSprite;
    public Sprite between50And25PercentHealthSprite;
    public Sprite lessThan25PercentHealthSprite;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateSpriteBasedOnHealthPercentage(float healthPercentage)
    {
        if (healthPercentage < 1 && healthPercentage >= .75) 
        {
            spriteRenderer.sprite = above75PercentHealthSprite;
        }
        else if (healthPercentage < .75 && healthPercentage >= .5)
        {
            spriteRenderer.sprite = between75And50PercentHealthSprite;
        }
        else if (healthPercentage < .5 && healthPercentage >= .25)
        {
            spriteRenderer.sprite = between50And25PercentHealthSprite;
        }
        else if (healthPercentage < .25 && healthPercentage > 0)
        {
            spriteRenderer.sprite = lessThan25PercentHealthSprite;
        }
    }
}
