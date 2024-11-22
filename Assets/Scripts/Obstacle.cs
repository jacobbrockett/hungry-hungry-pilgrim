using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
* class: Obstacle()
* description: Obstacles are game objects that, when a player hits, will cause the player
* to return to the main menu
*/
public class Obstacle : MonoBehaviour
{
    [SerializeField] PlayerInputHandler playerInputHandler; // decrement health
    /**
    * function: Awake()
    * args: None
    * description: After instantiation of this object, it will be destroyed after 5 seconds
    */
    void Awake()
    {
        Destroy(this.gameObject, 5); // destroy game object after 5 seconds
    } 

    /**
    * function: OnTriggerEnter2D()
    * args: 
    * - Collider2D other: game object with a 2D collider
    * description: When a player collides with an obstacle, it will destroy the game object
    * and return the player to the main menu
    */
    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Pilgrim")) // ensures object colliding is a player
        {
            playerInputHandler.DecrementHealth();
            Destroy(this.gameObject);
        }
    }

    public void SetPlayerInputHandler(PlayerInputHandler playerInputHandler)
    {
        this.playerInputHandler = playerInputHandler;
    }
}
