using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DeflectedProjectileVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color lerpedColor;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void LerpEnergyToRed()
    {
        lerpedColor = Color.Lerp(spriteRenderer.material.color, Color.red, 0.33f);
        spriteRenderer.material.color = lerpedColor;
    }
}
