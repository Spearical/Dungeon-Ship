using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DeflectedEnergySFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip deflectedSFX;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeflectedSFX()
    {
        audioSource.volume = 0.2f;
        audioSource.pitch = 3f;
        audioSource.PlayOneShot(deflectedSFX);
    }
}
