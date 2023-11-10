using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlArea : MonoBehaviour
{
    private bool Entered = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Entered = true;
            GameObject.Find("ControlMsg").GetComponent<Text>().text = "Press E To \nControl The Ship";
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Entered = false;
            GameObject.Find("ControlMsg").GetComponent<Text>().text = "";
        }
    }

    private void Update()
    {
        if (Entered && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);
        }
    }
}
