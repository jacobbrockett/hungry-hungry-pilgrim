using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/**
* class: Obstacle()
* description: Obstacles are game objects that, when a player hits, will cause the player
* to return to the main menu
*/
public class Obstacle : MonoBehaviour
{
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
    * description: When a player collides with an obstacle, it will destroy the Spaceship object
    * and return the player to the main menu
    */
    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Spaceship")) // ensures object colliding is a Spaceship
        {
            Destroy(other.gameObject);  // destroy the spaceship
            SceneManager.LoadScene("MainMenu");  // load the main menu scene
        }
    }
}
