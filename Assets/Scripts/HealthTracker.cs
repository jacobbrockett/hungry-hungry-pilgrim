using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Must Include:
using UnityEngine.UI;
using TMPro;

/**
* class: StatsTracker
* description: class for updating the stats text
*/
public class HealthTracker : MonoBehaviour
{
    [SerializeField] PlayerInputHandler playerInputHandler; // always connected to what player is controlling

    [SerializeField] TextMeshProUGUI healthText;

    /**
    * function: Update()
    * args: none
    * description: Update the text with current health
    */
    void Update()
    {
        int currentHealth = playerInputHandler.GetCurrentHealth();
        int maxHealth = playerInputHandler.GetMaxHealth();

        healthText.text = "Health: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
