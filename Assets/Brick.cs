using UnityEngine;

public class Brick : MonoBehaviour
{
    public Rigidbody2D rb;
    float speed = 1f;
    public float minSpeed = 4f;
    public float maxSpeed = 8f;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
    void FixedUpdate()
    {   
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }
}
