using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* class: Pilgrim()
* description: The game object that the player controls
*/
public class Pilgrim : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] float currentSpeed;
    [SerializeField] float regularSpeed = 10f;
    [SerializeField] float sleepySpeed = 5f;
    [Header("Effects")]
    [SerializeField] int sleepyTimeInterval = 5;

    /**
    * function: Awake()
    * args: None
    * description: Get the player's rigidbody 2D
    */
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = regularSpeed;
    }

    /**
    * function: Move()
    * args:
    * - Vector3 movement: position to move the player object to
    * description: moves the Spaceship to a position passed as a parameter
    */
    public void Move(Vector3 movement)
    {
        rb.MovePosition(transform.position + (movement * currentSpeed) * Time.fixedDeltaTime); // add position to current position
    }

    public void TryptophanEffect(PlayerInputHandler playerInputHandler)
    {
        StartCoroutine(SleepyRoutine());

        IEnumerator SleepyRoutine()
        {
            print("Sleepy Time!");
            currentSpeed = sleepySpeed;
            yield return new WaitForSeconds(sleepyTimeInterval);
            currentSpeed = regularSpeed;
            playerInputHandler.ResetTryptophan();
            // TODO: show visual
        }
    }
}
