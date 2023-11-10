using UnityEngine;

public class AddRigidbody : MonoBehaviour
{

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Rigidbody>() == null)
            {
                child.gameObject.AddComponent<Rigidbody>().useGravity = false;
            }
        }
    }
}
