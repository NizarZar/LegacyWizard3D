using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items")]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private ElementEnum baseElement;
    [SerializeField] private float baseDamage;
    [SerializeField] private string rarity;
    [SerializeField] private float dropRate;
    [SerializeField] private ItemType type;
    private List<string> passiveAttributes;


    public ItemType Type
    {
        get { return type; }
        set { type = value; }
    }
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public ElementEnum BaseElement
    {
        get { return baseElement; }
        set { baseElement = value; }
    }

    public float BaseDamage
    {
        get { return baseDamage; }
        set { baseDamage = value; }
    }

    public string Rarity
    {
        get { return rarity; }
        set { rarity = value; }
    }

    public float DropRate
    {
        get { return dropRate; }
        set { dropRate = value; }
    }

}
