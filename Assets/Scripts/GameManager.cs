using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int WhiteScore;
    public int BlackScore;
    public Text WhiteScoreText; 
    public Text BlackScoreText; 

    public AiCarrom aicarromscript;
    public StrikerDrag strikerdragscript;
    public StrikerPosition strikerpositionscript;

    public float GameTime ;
    public float GameTotalTime;
    public Text TimeText;

    public GameOverScript gameOverScript;

    


    public void BlackScoreIncrease() {
        BlackScore++;
        BlackScoreText.text = BlackScore.ToString();
    }

    public void WhiteScoreIncrease() {
        WhiteScore++;
        WhiteScoreText.text = WhiteScore.ToString();

    }

    public void BlackScoreDecrease() {
        if (aicarromscript.AiStrikerResting == false) 
        {
            BlackScore--;
            BlackScoreText.text = BlackScore.ToString();
        }
    }

    public void WhiteScoreDecrease() {
        if (strikerdragscript.canPlay == true) 
        {
            WhiteScore--;
            WhiteScoreText.text = WhiteScore.ToString();
        }
    }

    public void BlackScoreIncreaseQueen() {
        if (aicarromscript.AiStrikerResting == false)
        {
            BlackScore +=2;
            BlackScoreText.text = BlackScore.ToString();
        }
    }

    public void WhiteScoreIncreaseQueen() {
        if (strikerdragscript.canPlay == true)
        {
            WhiteScore +=2;
            WhiteScoreText.text = WhiteScore.ToString();

        }
    }

    
    void Start()
    {
        BlackScore = 0;
        WhiteScore = 0;
        GameTime = 120;
    }

    
    void Update()
    {
        if (GameTime > 0f)
        {
            GameTime -= Time.deltaTime;
        }
        else {
            GameTime = 0f;
            gameOverScript.Setup();
        }
        TimeText.text = GameTime.ToString("0");

    }


}
