using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
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

    
    void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Pilgrim")) // ensures object colliding is a player
        {
            playerInputHandler.IncrementHealth();
            Destroy(this.gameObject);
        }
    }

    public void SetPlayerInputHandler(PlayerInputHandler playerInputHandler)
    {
        this.playerInputHandler = playerInputHandler;
    }
}
