using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using UnityEngine.SceneManagement;


/**
* class: PlayerInputHandler
* description: Class is responsible for handling player inputs, tracking points, and passing the coin
* audio source to Point objects
*/
public class PlayerInputHandler : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] Pilgrim playerPilgrim;

    [Header("Stats")]
    [SerializeField] int currentPoints = 0;
    [SerializeField] int currentHealth = 5;

    [Header("Audio")]
    [SerializeField] AudioSource coinAudioSource; // or GetComponent<AudioSource>()

    /**
    * function: FixedUpdate()
    * args: None
    * description: Grabs player input and moves the spaceship accordingly
    */
    void FixedUpdate(){
        // Initialize Vector3:
        Vector3 movement = Vector3.zero;

        // Move Left:
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1, 0, 0);
        }

        // Move Right:
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1, 0, 0);
        }

        // Move player ship:
        playerPilgrim.Move(movement);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(playerPilgrim.gameObject);  // destroy the player
            SceneManager.LoadScene("MainMenu");  // load the main menu scene
         
        }
    }

    /**
    * function: IncrementPoint()
    * args: None
    * description: Increments the current points field and plays the coin audio source
    */
    public void IncrementPoint(int addPoints)
    {
        currentPoints = currentPoints + addPoints;
        coinAudioSource.Play(); // TODO: change audio to turkey gobble
    }

    public void DecrementHealth()
    {
        currentHealth = currentHealth - 1;
        // TODO: add audio source to play
    }

    /**
    * function: GetPlayerGameObject()
    * args: None
    * description: Getter for player game object field
    */
    public Pilgrim GetPlayerGameObject()
    {
        return playerPilgrim;
    }

    /**
    * function: GetCurrentPoints()
    * args: None
    * description: Getter for current points field
    */
    public int GetCurrentPoints()
    {
        return currentPoints;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    
}
