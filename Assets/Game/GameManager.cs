using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    // player instantiation
    public UnitHealth playerStats = new UnitHealth(100.0f, 100.0f, 100.0f, 100.0f, 15.0f);
    // enemies

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
        
    }
    
}
