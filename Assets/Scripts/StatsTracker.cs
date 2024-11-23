using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Must Include:
using UnityEngine.UI;
using TMPro;

public class StatsTracker : MonoBehaviour
{
    [SerializeField] PlayerInputHandler playerInputHandler; // always connected to what player is controlling

    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI tryptophanText;
    [SerializeField] TextMeshProUGUI sleepyText;

    /**
    * function: Update()
    * args: none
    * description: Update the point counter text with current points
    */
    void Update()
    {
        // Update Points:
        int currentPoints = playerInputHandler.GetCurrentPoints();
        pointText.text = "Points: " + currentPoints.ToString();

        // Update Health:
        int currentHealth = playerInputHandler.GetCurrentHealth();
        int maxHealth = playerInputHandler.GetMaxHealth();

        healthText.text = "Health: " + currentHealth.ToString() + "/" + maxHealth.ToString();

        // Update Tryptophan:
        int currentTryptophan = playerInputHandler.GetCurrentTryptophan();
        int maxTryptophan = playerInputHandler.GetMaxTryptophan();

        tryptophanText.text = "Tryptophan: " + currentTryptophan.ToString() + "/" + maxTryptophan.ToString();
        
        if(playerInputHandler.GetSleepyTime())
        {
            sleepyText.text = "Sleepy Time!!";
        }
        else
        {
            sleepyText.text = "";
        }
        
    }
}
