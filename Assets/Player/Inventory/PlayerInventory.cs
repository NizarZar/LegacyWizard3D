using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isInventoryOpen;

    public void OnInventoryOpen(InputAction.CallbackContext context)
    {
        isInventoryOpen = context.action.IsPressed();
    }

    private void OpenInventory()
    {
        if (isInventoryOpen)
        {
            
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
