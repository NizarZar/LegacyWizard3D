using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    private bool isJumping;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private ManaBar _manaBar;
    [SerializeField] private GameObject player;
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
            isJumping = false;
        }
    }
    void Update()
    {
        Jump();
    }

    private void Start()
    {
        _healthBar.SetMaxHealth(GameManager.gameManager.playerStats.MaxHealth);
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
}
