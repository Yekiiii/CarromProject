using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StrikerDrag : MonoBehaviour
{
    private bool dragging = false;
    
    public GameObject StrikerDirectionAnti;
    
    private Vector3 StrikerDirection;
    
    Rigidbody2D rb;
    
    public StrikerPosition strikerPosition;
    
    public float SimulationTime = 4f;
    
    public Transform StrikerCircle;

    public bool canPlay;

    public GameManager gameManager;

    public Transform BlackCoinCollectionPoint; 

    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        canPlay = true;
        
        StrikerCircle.localScale = Vector3.zero;
    }

    
    void OnMouseDown() {
        if (canPlay == true)
        {
            dragging = true;
            
        }

    }
    
    
    IEnumerator m_SimulationTime()
    {
        yield return new WaitForSeconds(SimulationTime);
        strikerPosition.StrikerRest();
    }


    void OnMouseUp() {
        if (canPlay == true)
        {
            dragging = false;
            
            canPlay = false;
            
            StrikerDirection = StrikerDirectionAnti.transform.position - transform.position;
            StrikerDirection.z = 0;

            Vector3 oppositeDirection = -StrikerDirection;
            oppositeDirection.z = 0;
            rb.AddForce(oppositeDirection * 1000);
            strikerPosition.StrikerOnBarFalse();

            StartCoroutine(m_SimulationTime());
            StrikerCircle.localScale = Vector3.zero;
        }
    }
    

    void m_StrikerDirection() {

        if (dragging == true && canPlay == true) {
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0;
            StrikerDirectionAnti.transform.position = cursorPosition;

            Vector3 direction = cursorPosition - transform.position;

            float scaleValue = Vector2.Distance(transform.position, cursorPosition);
            scaleValue *= 50;

            float maxScaleValue = 50f;

            scaleValue = Mathf.Min(scaleValue, maxScaleValue);

            StrikerCircle.localScale = new Vector3(scaleValue, scaleValue, scaleValue);

            if (direction != Vector3.zero)
            {
                StrikerCircle.rotation = Quaternion.LookRotation(Vector3.forward, direction);
            }

        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            transform.position = BlackCoinCollectionPoint.position;
            gameManager.WhiteScoreDecrease();

        }

    }


    public void canPlayeEnabler() {
        canPlay = true;
        
    }
    void Update() {
        m_StrikerDirection();
    }
}
