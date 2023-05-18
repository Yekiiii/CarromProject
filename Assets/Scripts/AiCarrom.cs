using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCarrom : MonoBehaviour
{
    public float strikeForce = 10f; 
    public float delayBetweenShots = 4f; 
    public Transform[] targetPositions; 

    public Transform AiSpawnPoint;
    public Transform AiTransform;
    public Transform AiStrikerRestPoint;

    public StrikerPosition strikerpositionScript;

    public Coroutine coroutinePauser;


    private Rigidbody2D rb;
    private int currentTargetIndex = 0;

    public bool AiStrikerResting;

    public Transform BlackCoinCollectionPoint;

    public GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AiTransform.position = AiStrikerRestPoint.position;
        AiStrikerResting = true;
        coroutinePauser = StartCoroutine(ShootAutomated()); 
    }

    public System.Collections.IEnumerator ShootAutomated()
    {
        
        
        if (AiStrikerResting == false)
        {
            while (currentTargetIndex < targetPositions.Length)
            {

                if (targetPositions[currentTargetIndex].position.x > 2.8f)
                {
                    currentTargetIndex++;
                }

                yield return new WaitForSeconds(delayBetweenShots);
                Vector2 targetPosition = new Vector3(targetPositions[currentTargetIndex].position.x, targetPositions[currentTargetIndex].position.y);
                Vector2 direction = targetPosition - rb.position;

                if (targetPositions[currentTargetIndex].position.x < 2.8f)
                {
                    Strike(direction);
                }

                if (currentTargetIndex == 7)
                {
                    currentTargetIndex = -1;
                }

                currentTargetIndex++;

                yield return new WaitForSeconds(delayBetweenShots);
                AiStrikerRest();
                yield break;
                
            }
        }
    }

    private void Strike(Vector2 direction)
    {

        rb.AddForce(direction.normalized * strikeForce, ForceMode2D.Impulse);

    }

    public void NewTurnAi() {
        AiTransform.position = AiSpawnPoint.position;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        
        AiStrikerResting = false;
        StartCoroutine(ShootAutomated());

    }

    public void AiStrikerRest() {
        AiTransform.position = AiStrikerRestPoint.position;
        AiStrikerResting = true;

        strikerpositionScript.NextTurnPosition();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            transform.position = BlackCoinCollectionPoint.position;
            gameManager.BlackScoreDecrease();

        }

    }


}
