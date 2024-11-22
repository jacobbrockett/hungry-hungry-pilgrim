using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/**
* class: PlayerInputHandler
* description: Class is responsible for handling player inputs, tracking points, and passing the coin
* audio source to Point objects
*/
public class PlayerInputHandler : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] Pilgrim playerPilgrim;

    [Header("Points")]
    [SerializeField] int currentPoints = 0;

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

    /**
    * function: IncrementPoint()
    * args: None
    * description: Increments the current points field and plays the coin audio source
    */
    public void IncrementPoint(int addPoints)
    {
        currentPoints = currentPoints + addPoints;
        coinAudioSource.Play();
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

    
}
