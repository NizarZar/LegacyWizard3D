using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    // CONSTANTS
    public const float MovementSpeed = 5.2f;

    //inputs
    private Vector2 move;
    /* Input methods to call them in the engine
     */
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    

    // Player Movement
    private void MovePlayer()
    {
        try {
            Vector3 movement = new Vector3(move.x, 0f, move.y);
            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
                transform.Translate(movement * (MovementSpeed * Time.deltaTime), Space.World);
            }
        } catch (Exception exception)
        {
            exception.Source = "Error! Movement Exception!";
        }
    }
    

    
}
