using UnityEngine;

public class DespawnableObject : MonoBehaviour
{
    public void DespawnObject()
    {
        gameObject.SetActive(false);
        if (TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
        {
            spriteRenderer.enabled = false;
        }
    }
}
