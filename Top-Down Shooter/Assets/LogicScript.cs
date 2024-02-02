using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerHealth = 10;
    public Text healthText;
    [ContextMenu("Decrease Health")]
    public void loseHealth()
    {
        playerHealth--;
        healthText.text = playerHealth.ToString();
    }
}
