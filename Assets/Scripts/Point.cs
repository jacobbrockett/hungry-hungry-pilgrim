using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* class: Point()
* args: None
* description: Class for Point objects, which can be collected by player
*/
public class Point : MonoBehaviour
{
    [SerializeField] PlayerInputHandler playerInputHandler; // necessary for incrementing point count and coin audio source
    [SerializeField] int pointValue = 1;

    /**
    * function: Awake()
    * args: None
    * description: destroy point object after 5 seconds (if not collected by player)
    */
    
    void Awake()
    {
        Destroy(this.gameObject, 5); // destroy game object after 5 seconds
    } 

    /**
    * function: OnTriggerEnter2D()
    * args: 
    * - Collider2D other: game object with a 2D collider
    * description: When a player collides with a point, it will increment the point count by one and 
    * play a coin audio source
    */
    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Pilgrim")) // ensures object colliding is a player
        {
            playerInputHandler.IncrementPoint(pointValue);

            Destroy(this.gameObject);
        }
    }

    /**
    * function: SetPlayerInputHandler()
    * args: 
    * - PlayerInputHandler playerInputHandler: holds the point count and coin audio source
    * description: Setter for playerInputHandler field
    */
    public void SetPlayerInputHandler(PlayerInputHandler playerInputHandler)
    {
        this.playerInputHandler = playerInputHandler;
    }
}
