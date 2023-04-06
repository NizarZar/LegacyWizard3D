using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthSlider;

    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }
    

    public void SetCurrentHealth(float currentHealth)
    {
        _healthSlider.value = currentHealth;
    }

    public float GetCurrentHealth()
    {
        return _healthSlider.value;
    }

    public void SetMaxHealth(float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
    }



}
