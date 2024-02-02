using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRepair : MonoBehaviour
{
    public Sprite[] shipStages;
    public int currentStage = 0;
    private SpriteRenderer spriteRenderer;

    public bool isPart1 = false;
    public bool isPart2 = false;
    public bool isPart3 = false;
    public bool isPart4 = false;
    public bool isPart5 = false;

    void Start()
    {
        Debug.Log("ShipRepair Start");
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateShipImage();    
    }

    public void RepairShip()
    {
        Debug.Log("RepairShip");
        if(isPart1){
            indicatorP1 indicatorP1 = GameObject.FindGameObjectWithTag("ip1").GetComponent<indicatorP1>();
            Debug.Log(indicatorP1);
            indicatorP1.UpdatePart();
            isPart1 = false;
        }
        if(isPart2){
            indicatorP2 indicatorP2 = GameObject.FindGameObjectWithTag("ip2").GetComponent<indicatorP2>();
            Debug.Log(indicatorP2);
            indicatorP2.UpdatePart();
            isPart2 = false;
        }
        if(isPart3){
            indicatorP3 indicatorP3 = GameObject.FindGameObjectWithTag("ip3").GetComponent<indicatorP3>();
            Debug.Log(indicatorP3);
            indicatorP3.UpdatePart();
            isPart3 = false;
        }
        if(isPart4){
            indicatorP4 indicatorP4 = GameObject.FindGameObjectWithTag("ip4").GetComponent<indicatorP4>();
            Debug.Log(indicatorP4);
            indicatorP4.UpdatePart();
            isPart4 = false;
        }
        if(isPart5){
            indicatorP5 indicatorP5 = GameObject.FindGameObjectWithTag("ip5").GetComponent<indicatorP5>();
            Debug.Log(indicatorP5);
            indicatorP5.UpdatePart();
            isPart5 = false;
        }

        if(currentStage < shipStages.Length - 1)
        {
            currentStage++;
            UpdateShipImage();
        }
    }
    // Update is called once per frame
    void UpdateShipImage()
    {
        Debug.Log("UpdateShipImage");
        spriteRenderer.sprite = shipStages[currentStage];   
    }

    // sets part name
    public void SetPartName(string shipPartName)
    {
        if(shipPartName == "part1")
        {
            isPart1 = true;
        }
        else if(shipPartName == "part2")
        {
            isPart2 = true;
        }
        else if(shipPartName == "part3")
        {
            isPart3 = true;
        }
        else if(shipPartName == "part4")
        {
            isPart4 = true;
        }
        else if(shipPartName == "part5")
        {
            isPart5 = true;
            
        }
    }
}
