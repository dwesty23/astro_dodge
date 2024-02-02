using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Astrodog : MonoBehaviour
{
    public float moveSpeed = 15f;
    public Rigidbody2D rb;
    public bool hasPart = false;
    public int partsColelcted = 0;

    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource screamSound;
    [SerializeField] private AudioSource partSound;
    [SerializeField] private AudioSource repairSound;

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;
        rb.AddForce(new Vector2(x, y));
    }
    IEnumerator LoadSceneAfterSound()
    {
        yield return new WaitForSeconds(.25f);
        SceneManager.LoadScene(3);
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Asteroid" || col.tag == "UFO")
        {
            Debug.Log("Game Over");
            deathSound.Play();
            StartCoroutine(LoadSceneAfterSound());
        }

        if (col.tag == "part1" || col.tag == "part2" || col.tag == "part3" || col.tag == "part4" || col.tag == "part5")
        {
            if(hasPart == false)
            {
                partSound.Play();
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
                    Debug.Log("You have collected part 1");
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
                    SceneManager.LoadScene(4);
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
