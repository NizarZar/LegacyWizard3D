using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    // CONSTANTS
    [SerializeField] private float MovementSpeed = 5.2f;
    
    //[SerializeField] private float RotationSmoothing = 200.0f;

    //inputs
    private Vector2 move;

    private Vector2 rotate;

    /* Input methods to call them in the engine
     */
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        rotate = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }
    

    // Player Movement
    private void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0, move.y);
        transform.Translate(movement*(MovementSpeed*Time.deltaTime), Space.World);
    }

    private void RotatePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(rotate);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            LookAt(point);
        }

    }

    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectPoint);
    }
    

    
}
