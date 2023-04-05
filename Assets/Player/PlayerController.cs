using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    // CONSTANTS
    public const float MovementSpeed = 5.2f;
    
    // variables
    [SerializeField] private GameObject bullet;
    // camera and movement
    private Plane plane = new Plane(Vector3.up, 0);
    [SerializeField] private Camera mainCamera;
    
    //inputs
    private bool fire;
    private Vector2 move;
    /* Input methods to call them in the engine
     */
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        
    }
    public void OnFireButton(InputAction.CallbackContext context)
    {
        fire = context.action.IsPressed();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Fire();
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
    
    // Attacking with weapon
    private void Fire()
    {
        if (fire)
        {
            Vector3 aim = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            GameObject bulletShot = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletShot.transform.LookAt(aim);
            Rigidbody body = bulletShot.GetComponent<Rigidbody>();
            body.AddRelativeForce(transform.forward*25.2f);
            fire = false;
        }

    }
}
