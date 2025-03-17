using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealedSFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip healedSFX;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPlayerHealedSFX()
    {
        audioSource.PlayOneShot(healedSFX);
    }
}
