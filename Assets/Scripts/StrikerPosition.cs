using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerPosition : MonoBehaviour
{

    public Transform strikerAdjustPosition;
    public Transform strikerOnBoardPosition;
    private Vector2 strikerPos;
    private bool strikerOnBar;
    public Transform SpawnPointTransform;
    private Rigidbody2D rb;
    public Transform StrikerRestPoint;
    public bool StrikerResting;
    public AiCarrom aicarromScript;
    public StrikerDrag strikerDragScript;


    public void StrikerOnBarTrue() {
        strikerOnBar = true;
    }

    public void StrikerOnBarFalse()
    {
        strikerOnBar = false;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        strikerOnBar=true;
        rb = GetComponent<Rigidbody2D>();
    }

    public void strikerPosUpdate()
    {
        if (strikerOnBar == true){
            strikerPos = strikerOnBoardPosition.position;
            strikerPos.x = strikerAdjustPosition.position.x;
            strikerOnBoardPosition.position = strikerPos;
        }
    }

    public void NextTurnPosition() {

        strikerOnBoardPosition.position = SpawnPointTransform.position;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        strikerOnBar = true;
        strikerDragScript.canPlayeEnabler();

    }

    public void StrikerRest() {
        StrikerResting = true;
        strikerOnBoardPosition.position = StrikerRestPoint.position;
        aicarromScript.NewTurnAi();
        
    }

    
    void Update()
    {
        strikerPosUpdate();   
    }




}
