using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Must Include:
using UnityEngine.UI;
using TMPro;

/**
* class: PointCounter()
* description: class for updating the point counter text
*/
public class PointCounter : MonoBehaviour
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
        int currentPoints = playerInputHandler.GetCurrentPoints();

        pointText.text = "Point: " + currentPoints.ToString();
    }
}
