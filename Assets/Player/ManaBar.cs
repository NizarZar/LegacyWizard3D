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
    }

    public void SetCurrentMana(float currentMana)
    {
        _slider.value = currentMana;
    }

    public void SetMaxMana(float maxMana)
    {
        _slider.value = maxMana;
        _slider.maxValue = maxMana;
    }

    public float GetCurrentMana()
    {
        return _slider.value;
    }
}
