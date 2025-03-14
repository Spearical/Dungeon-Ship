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
        int numberOfBouncesLeft = bouncesComponent.GetCurrentBounces() - 1;
        bounceText.text = numberOfBouncesLeft.ToString();
    }
}
