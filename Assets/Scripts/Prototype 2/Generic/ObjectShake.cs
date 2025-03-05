using System.Collections;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    [SerializeField]
    private float duration;
    [SerializeField]
    private float magnitude;

    IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + xOffset, originalPosition.y + yOffset, originalPosition.z);

            elapsedTime += Time.deltaTime;
            
            // wait one frame
            yield return null;
        }
        transform.localPosition = originalPosition;
    }

    public void ShakeObject()
    {
        StartCoroutine(Shake(duration, magnitude));
    }
}
