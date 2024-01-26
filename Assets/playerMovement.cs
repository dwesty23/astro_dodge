using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;

        rb.AddForce(new Vector2(x, y));
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
