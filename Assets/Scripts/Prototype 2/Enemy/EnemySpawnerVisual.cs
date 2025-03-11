using UnityEngine;

public class EnemySpawnerVisual : MonoBehaviour
{
    [SerializeField]
    private GameObject portalPrefab;
    private ParticleSystem portalParticleSystem;

    void Awake()
    {
        portalParticleSystem = portalPrefab.GetComponent<ParticleSystem>();
    }

    public void PlayPortalEffect()
    {
        portalParticleSystem.Play();
    }
}
