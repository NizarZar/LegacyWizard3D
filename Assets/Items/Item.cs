using System;
using UnityEngine;


public class Item : MonoBehaviour
{
    
    [SerializeField] private ItemScriptableObject itemToUse;
    private int stackSize;

    public ItemScriptableObject ItemToUse
    {
        get { return itemToUse; }
        private set { itemToUse = value; }
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    public int StackSize
    {
        get { return stackSize; }
        set { stackSize = value; }
    }
    
    
}
