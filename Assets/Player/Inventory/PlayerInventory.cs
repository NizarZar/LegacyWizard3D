using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<ItemScriptableObject, Item> itemsDictionary;
    [SerializeField] private List<Item> inventoryItems;
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



    // Update is called once per frame
    void Update()
    {
        OpenInventory();
    }

    private void Awake()
    {
        inventoryItems = new List<Item>();
        itemsDictionary = new Dictionary<ItemScriptableObject, Item>();
    }
}
