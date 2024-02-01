using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRepair : MonoBehaviour
{
    public Sprite[] shipStages;
    public int currentStage = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateShipImage();    
    }

    public void RepairShip()
    {
        if(currentStage < shipStages.Length - 1)
        {
            currentStage++;
            UpdateShipImage();
        }
    }
    // Update is called once per frame
    void UpdateShipImage()
    {
        spriteRenderer.sprite = shipStages[currentStage];   
    }
}
