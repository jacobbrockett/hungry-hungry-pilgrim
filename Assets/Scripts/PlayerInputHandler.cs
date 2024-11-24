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

    [Header("Points")]
    [SerializeField] int currentPoints = 0;
    [Header("Health")]
    [SerializeField] int currentHealth = 5;
    [SerializeField] int maxHealth = 5;
    [Header("Tryptophan Effect")]
    [SerializeField] int currentTryptophan;
    [SerializeField] int maxTryptophan = 5;
    [SerializeField] bool sleepyTime = false;

    [Header("Audio")]
    [SerializeField] AudioSource healthAudioSource; // or GetComponent<AudioSource>()
    [SerializeField] AudioSource gobbleAudioSource;
    [SerializeField] AudioSource damageAudioSource;

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

        if (currentTryptophan == maxTryptophan)
        {
            playerPilgrim.TryptophanEffect(this);
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
        gobbleAudioSource.Play();
    }

    public void DecrementHealth()
    {
        currentHealth = currentHealth - 1;
        damageAudioSource.Play();
    }

    public void IncrementHealth()
    {
        if (currentHealth == maxHealth)
        {
            return;
        }
        else
        {
            currentHealth = currentHealth + 1;
            healthAudioSource.Play();
        }
    }

    public void IncrementTryptophan()
    {
        currentTryptophan = currentTryptophan + 1;
    }

    public void ResetTryptophan()
    {
        currentTryptophan = 0;
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

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetCurrentTryptophan()
    {
        return currentTryptophan;
    }

    public int GetMaxTryptophan()
    {
        return maxTryptophan;
    }

    public bool GetSleepyTime()
    {
        return sleepyTime;
    }

    public void SetSleepyTime(bool slumped)
    {
        this.sleepyTime = slumped;
    }

    
}
