using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Base interface for enemy classes
    private UnitHealth unitHealth = new UnitHealth();

    public UnitHealth UnitHealth
    {
        get { return unitHealth; }
    }

}
