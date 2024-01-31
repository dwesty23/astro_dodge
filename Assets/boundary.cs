using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{

    // private Vector2 screenBounds;
    public SpriteRenderer Actual_bg;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    // Start is called before the first frame update
    void Start()
    {
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // Debug.Log(screenBounds);

        minBounds = Actual_bg.bounds.min;
        maxBounds = Actual_bg.bounds.max;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, minBounds.x, maxBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, minBounds.y, maxBounds.y);
        transform.position = viewPos;
    }
}