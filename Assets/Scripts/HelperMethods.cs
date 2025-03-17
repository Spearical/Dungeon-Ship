using System.Collections.Generic;
using UnityEngine;

public static class HelperMethods
{
    public static List<GameObject> GetChildren(this GameObject go)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform tran in go.transform)
        {
            children.Add(tran.gameObject);
        }
        return children;
    }

    public static GameObject FindChildWithTag(GameObject parent, string tag) 
    {
        GameObject child = null;

        foreach(Transform transform in parent.transform) 
        {
            if (transform.CompareTag(tag)) 
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }
}
