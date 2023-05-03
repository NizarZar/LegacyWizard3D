using System;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject itemToUse;
    private int stackSize;
    private BoxCollider myCollider;
    private Rigidbody itemBody;
    
    public ItemScriptableObject ItemToUse
    {
        get { return itemToUse; }
        private set { itemToUse = value; }
    }

    private void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        myCollider.isTrigger = true;
        itemBody = GetComponent<Rigidbody>();
        
    }

    public int StackSize
    {
        get { return stackSize; }
        set { stackSize = value; }
    }
    
}
