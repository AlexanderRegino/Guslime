using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spike : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Something");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Struck a player");
            SceneManager.LoadScene("MainMenu");
            Destroy(gameObject);
        }
    }
}
