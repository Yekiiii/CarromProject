using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCoinScore : MonoBehaviour
{

    public Transform BlackCoinCollectionPoint;
    public GameManager gameManager;




    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Hole") {
            transform.position = BlackCoinCollectionPoint.position;
            gameManager.BlackScoreIncrease();
            
        }
    
    }

    
}
