using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]
public class BaseSpell : ScriptableObject
{

    public float ManaCost { get; set; }
    public float Damage { get; set; }
    public float HealthCost { get; set; }
    public float LifeTime { get; set; }
    public float Velocity { get; set; }
    public string Name { get; }
    public BaseSpell(string name)
    {
        Name = name;
    }
    
    
}
