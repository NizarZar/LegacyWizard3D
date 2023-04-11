using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    private bool isJumping;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ManaBar manaBar;
    public void OnJumping(InputAction.CallbackContext context)
    {
        isJumping = context.action.IsPressed();
    }
    private void Jump()
    {
        
        // debugging player take damage -
        // to remove later
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


    }
    private void PlayerTakeDamage(float damage)
    {
        GameManager.gameManager.playerStats.DamageUnit(damage);
        healthBar.SetCurrentHealth(GameManager.gameManager.playerStats.CurrentHealth);
        
        
    }

    private void PlayerHeal(float healAmount)
    {
        GameManager.gameManager.playerStats.HealUnit(healAmount);
    }

    private void UpdateHealManaBar()
    {
        if (!healthBar.GetCurrentHealth().Equals(GameManager.gameManager.playerStats.CurrentHealth))
        {
            healthBar.SetCurrentHealth(GameManager.gameManager.playerStats.CurrentHealth);
        }

        if (!manaBar.GetCurrentMana().Equals(GameManager.gameManager.playerStats.CurrentMana))
        {
            manaBar.SetCurrentMana(GameManager.gameManager.playerStats.CurrentMana);
        }
        
        
    }

}
