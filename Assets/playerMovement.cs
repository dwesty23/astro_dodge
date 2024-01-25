using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Include this for scene management

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(x, y, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with " + other.gameObject.name);

        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Aesteriod"))
        {
            // Restart the game by reloading the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
