using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenPuck : MonoBehaviour
{
    public GameManager gameManager;
    public Transform BlackCoinCollectionPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            gameManager.WhiteScoreIncreaseQueen();
            gameManager.BlackScoreIncreaseQueen();
            transform.position = BlackCoinCollectionPoint.position;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
