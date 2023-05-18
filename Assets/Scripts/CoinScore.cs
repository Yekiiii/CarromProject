using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    
    public GameObject WhiteCoinCollectionPoint;
    public GameManager gameManager;

    void Start() {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Hole") {
            gameManager.WhiteScoreIncrease();
            gameObject.transform.position = WhiteCoinCollectionPoint.transform.position;
            
        }
    
    }


    
}
