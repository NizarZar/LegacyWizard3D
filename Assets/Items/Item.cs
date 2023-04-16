using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    private ItemScriptableObject itemToUse;

    public Item(ItemScriptableObject itemScriptableObject)
    {
        itemToUse = itemScriptableObject;
    }
    
}
