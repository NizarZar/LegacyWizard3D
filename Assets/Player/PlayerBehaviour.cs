using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    private bool isJumping;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private ManaBar _manaBar;

    public void OnJumping(InputAction.CallbackContext context)
    {
        isJumping = context.action.IsPressed();
    }
    private void Jump()
    {
        if (isJumping)
        {
            PlayerTakeDamage(15);
            Debug.Log("Player took damage!, New Health: " + GameManager.gameManager.playerStats.CurrentHealth);
            Debug.Log("Player new Mana: " + GameManager.gameManager.playerStats.CurrentMana);
            isJumping = false;
        }
    }
    void Update()
    {
        Jump();
        UpdateHealManaBar();
        if (!GameManager.gameManager.playerStats.CurrentHealth.Equals(GameManager.gameManager.playerStats.MaxHealth))
        {
            GameManager.gameManager.playerStats.CurrentHealth+=GameManager.gameManager.playerStats.HealthRechargeRate;
        }

    }

    private void Awake()
    {
        //_healthBar.SetMaxHealth(GameManager.gameManager.playerStats.MaxHealth);
        //_manaBar.SetMaxMana(GameManager.gameManager.playerStats.MaxMana);
    }

    private void PlayerTakeDamage(float damage)
    {
        GameManager.gameManager.playerStats.DamageUnit(damage);
        _healthBar.SetCurrentHealth(GameManager.gameManager.playerStats.CurrentHealth);
        
        
    }

    private void PlayerHeal(float healAmount)
    {
        GameManager.gameManager.playerStats.HealUnit(healAmount);
    }

    private void UpdateHealManaBar()
    {
        if (!_healthBar.GetCurrentHealth().Equals(GameManager.gameManager.playerStats.CurrentHealth))
        {
            _healthBar.SetCurrentHealth(GameManager.gameManager.playerStats.CurrentHealth);
        }

        if (!_manaBar.GetCurrentMana().Equals(GameManager.gameManager.playerStats.CurrentMana))
        {
            _manaBar.SetCurrentMana(GameManager.gameManager.playerStats.CurrentMana);
        }
        
        
    }
    
}
