using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScore : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
        if (playerScore == 20)
        {
            SceneManager.LoadScene(3);
        }
    }
    public void ToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
