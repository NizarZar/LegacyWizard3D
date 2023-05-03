using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{

    private bool isInventoryOpen;
    public static PlayerInventory inventoryManager;
    [SerializeField] private List<Item> itemsList = new List<Item>();

    public void OnInventoryOpen(InputAction.CallbackContext context)
    {
        isInventoryOpen = context.action.IsPressed();
    }

    // TODO: FIX THE INVENTORY NOT ALWAYS OPENING AND CLOSING
    // SOMETIMES IT BLINKS!
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
        inventoryManager = this;
    }
    public List<Item> ItemsList
    {
        get => itemsList;
        set => itemsList = value;
    }

    public void AddItem(Item item)
    {
        itemsList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        itemsList.Remove(item);
    }
}
