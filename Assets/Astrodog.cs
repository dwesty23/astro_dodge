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

                ShipRepair shipRepair = GameObject.Find("Ship").GetComponent<ShipRepair>();
                shipRepair.SetPartName(col.tag);

                Destroy(col.gameObject);
                Debug.Log("You have collected a part");
                

                if (col.tag == "part1")
                {
                    indicatorP1 indicatorP1 = GameObject.FindGameObjectWithTag("ip1").GetComponent<indicatorP1>();
                    Debug.Log(indicatorP1);
                    indicatorP1.UpdatePart();
                }
                if (col.tag == "part2")
                {
                    indicatorP2 indicatorP2 = GameObject.FindGameObjectWithTag("ip2").GetComponent<indicatorP2>();
                    Debug.Log(indicatorP2);
                    indicatorP2.UpdatePart();
                }
                if (col.tag == "part3")
                {
                    indicatorP3 indicatorP3 = GameObject.FindGameObjectWithTag("ip3").GetComponent<indicatorP3>();
                    Debug.Log(indicatorP3);
                    indicatorP3.UpdatePart();
                }
                if (col.tag == "part4")
                {
                    indicatorP4 indicatorP4 = GameObject.FindGameObjectWithTag("ip4").GetComponent<indicatorP4>();
                    Debug.Log(indicatorP4);
                    indicatorP4.UpdatePart();
                }
                if (col.tag == "part5")
                {
                    indicatorP5 indicatorP5 = GameObject.FindGameObjectWithTag("ip5").GetComponent<indicatorP5>();
                    Debug.Log(indicatorP5);
                    indicatorP5.UpdatePart();
                }

            }
            else
            {
                Debug.Log("You already have a part");
            }
            
        }

        if (col.tag == "ship") {
            Debug.Log("You have entered the ship");
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
