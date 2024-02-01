using UnityEngine;
using UnityEngine.SceneManagement;

public class Astrodog : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public bool hasPart = false;
    public int partsColelcted = 0;

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

        if (col.tag == "part1" || col.tag == "part2" || col.tag == "part3" || col.tag == "part4" || col.tag == "part5")
        {
            if(hasPart == false)
            {
                hasPart = true;
                partsColelcted++;
                Destroy(col.gameObject);
                Debug.Log("You have collected a part");

            }
            else
            {
                Debug.Log("You already have a part");
            }
            
        }

        if (col.tag == "ship") {
            if(hasPart == true)
            {
                hasPart = false;
                col.GetComponent<ShipRepair>().RepairShip();
                if (partsColelcted == 5)
                {
                    Debug.Log("You Win!");
                }
            }
            else
            {
                Debug.Log("You need to collect all the parts");
            }
        }

    }

    bool PlayerHasPart()
    {
        return hasPart;

    }
}
