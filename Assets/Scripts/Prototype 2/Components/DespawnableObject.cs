using System.Collections;
using UnityEngine;

public class DespawnableObject : MonoBehaviour
{
    public void DespawnObject()
    {
        StartCoroutine(DelayDespawnByOneSecond());
    }

    IEnumerator DelayDespawnByOneSecond()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}