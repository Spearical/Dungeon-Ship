using TMPro;
using UnityEngine;

public class DisplayBounces : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bounceText;
    private Bounces bouncesComponent;

    private void Awake()
    {
        bouncesComponent = GetComponent<Bounces>();
    }

    public void DisplayNumberOfBouncesLeft()
    {
        bounceText.text = bouncesComponent.GetCurrentBounces().ToString();
    }
}
