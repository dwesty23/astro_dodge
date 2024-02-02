using UnityEngine;
using UnityEngine.SceneManagement;

public class astro : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.RightArrow))
        //     rb.MovePosition(rb.position + Vector2.right);
        // else if (Input.GetKeyDown(KeyCode.LeftArrow))
        //     rb.MovePosition(rb.position + Vector2.left);
        // else if (Input.GetKeyDown(KeyCode.UpArrow))
        //     rb.MovePosition(rb.position + Vector2.up);
        // else if (Input.GetKeyDown(KeyCode.DownArrow))
        //     rb.MovePosition(rb.position + Vector2.down);
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;

        rb.AddForce(new Vector2(x, y));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Asteroid")
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
