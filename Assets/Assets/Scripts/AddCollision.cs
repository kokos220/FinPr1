using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollision : MonoBehaviour
{
    private void Start()
    {
        GetChildRecursive(gameObject);
    }

    private void GetChildRecursive(GameObject obj)
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;

            if (child.gameObject.GetComponent<CollisionScript>() == null)
            {
                child.gameObject.AddComponent<CollisionScript>();

            }
            GetChildRecursive(child.gameObject);
        }
    }
}
