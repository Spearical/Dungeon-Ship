using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DeflectedProjectileVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color lerpedColor;
    private Color originalColor;
    [SerializeField]
    float flashDuration;
    [SerializeField]
    Color flashColor;
    [SerializeField]
    int numberOfFlashes;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void LerpEnergyToRed()
    {
        lerpedColor = Color.Lerp(spriteRenderer.material.color, Color.red, 0.33f);
        spriteRenderer.material.color = lerpedColor;
    }

    public void ExpireTimeFlash()
    {
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        Color startColor = spriteRenderer.color;
        float elapsedFlashTime = 0;
        float elapsedFlashPercentage = 0;
        
        while (elapsedFlashTime < flashDuration)
        {
            elapsedFlashTime += Time.deltaTime;
            elapsedFlashPercentage = elapsedFlashTime / flashDuration;

            if (elapsedFlashPercentage > 1)
            {
                elapsedFlashPercentage = 1;
            }

            float pingPongPercentage = Mathf.PingPong(elapsedFlashPercentage * 2 * numberOfFlashes, 1);
            spriteRenderer.color = Color.Lerp(startColor, flashColor, pingPongPercentage);

            yield return null;
        }

        // Wait one frame before turning back into original color.
        yield return null;

        spriteRenderer.color = originalColor;
    }
}
