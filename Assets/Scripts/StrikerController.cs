using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerController : MonoBehaviour
{

    private bool strikerBeingSet;
    private bool strikerBeingTriggered;

    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void OnMouseDown()
    {
        strikerBeingSet = true;
    }

    public void OnMouseUp() {
        strikerBeingSet = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (strikerBeingSet == true)
        {
            Vector2 TouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) ;
            transform.position = new Vector2(
            Mathf.Clamp(TouchPosition.x, minX, maxX),
            Mathf.Clamp(TouchPosition.y, minY, maxY)
            );
        }
    }
}
