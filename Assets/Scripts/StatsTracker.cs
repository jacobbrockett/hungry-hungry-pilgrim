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
    }
}
