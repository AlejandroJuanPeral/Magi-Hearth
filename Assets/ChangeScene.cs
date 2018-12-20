using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    private void onTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("yyyy");
            SceneManager.LoadScene("level1");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("yyyy");
            SceneManager.LoadScene("level1");
        }
    }
}
