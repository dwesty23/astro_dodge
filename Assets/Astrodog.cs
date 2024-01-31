using UnityEngine;
using UnityEngine.SceneManagement;

public class Astrodog : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;

        rb.AddForce(new Vector2(x, y));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Asteroid" || col.tag == "UFO")
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
