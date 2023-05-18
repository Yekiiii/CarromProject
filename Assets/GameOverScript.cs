using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{


    public void Setup() {
        gameObject.SetActive(true);
    }

    public void RestartButton() {
        SceneManager.LoadScene(0);
    }
    
    
    public void ExitButton() {
        SceneManager.LoadScene(0);
        Application.Quit();
    }
}
