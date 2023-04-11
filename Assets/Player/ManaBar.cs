using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = GameManager.gameManager.playerStats.MaxMana;
    }

    public void SetCurrentMana(float currentMana)
    {
        _slider.value = currentMana;
    }

    public float GetCurrentMana()
    {
        return _slider.value;
    }
}
