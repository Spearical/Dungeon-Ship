using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    public GameObject bossPrefab;
    public bool isBossDead;
    public Slider healthSlider;
    public int bossScore;
    private IHealth bossHealth;

    private void Awake()
    {
        bossHealth = bossPrefab.GetComponent<IHealth>();
        healthSlider.maxValue = bossHealth.GetMaxHealth();
    }

    private void Start()
    {
        isBossDead = false;
    }

    private void Update()
    {
        if (bossPrefab == null)
        {
            isBossDead = true;
        }

        if (!isBossDead)
        {
            healthSlider.value = bossHealth.GetCurrentHealth();
        }
    }
}
