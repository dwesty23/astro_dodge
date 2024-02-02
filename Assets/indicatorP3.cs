using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorP3 : MonoBehaviour
{
    public Sprite[] partStages;
    public int currentStage = 0;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        Debug.Log("indicatorP3 Start");
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdatePartImage();    
        
    }
    public void UpdatePart()
    {
        Debug.Log("UpdatePart");
        if(currentStage < partStages.Length - 1)
        {
            currentStage++;
            UpdatePartImage();
        }
    }

    public void UpdatePartImage()
    {
       
        Debug.Log("UpdatePartImage");
        spriteRenderer.sprite = partStages[currentStage];   
    }
}
