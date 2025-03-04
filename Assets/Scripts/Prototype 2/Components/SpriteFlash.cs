using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlash : MonoBehaviour
{
    public float flashDuration;
    public Color flashColor;
    public int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOfFlashes)
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
    }

    public void FlashSprite()
    {
        StartCoroutine(FlashCoroutine(flashDuration, flashColor, numberOfFlashes));
    }
}
