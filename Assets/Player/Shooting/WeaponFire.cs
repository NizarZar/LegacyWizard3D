using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponFire : MonoBehaviour
{
    private bool isFiring;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Rigidbody bullet;

    public void OnFireButton(InputAction.CallbackContext context)
    {
        isFiring = context.action.IsPressed();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Rigidbody bulletShot = Instantiate(bullet, transform.position, Quaternion.identity);
            Vector3 direction;
            if (Physics.Raycast(ray, out RaycastHit hit, 30f))
            {
                direction = hit.point - transform.position;
                bulletShot.GetComponent<Rigidbody>().AddForce(direction*2.5f,ForceMode.Impulse);
            }
        }
        isFiring = false;
    }
}
