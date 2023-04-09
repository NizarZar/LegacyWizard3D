
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class UnitHealth 
{
   // fields
   private float _currentHealth;
   private float _currentMana;
   private float _maxHealth;
   private float _maxMana;
   private float _baseDamage;

   // properties
// base damage

   // Constructor
   public UnitHealth(float currentHealth, float currentMana, float maxHealth, float maxMana, float baseDamage)
   {
      _currentHealth = currentHealth;
      _currentMana = currentMana;
      _maxHealth = maxHealth;
      _maxMana = maxMana;
      _baseDamage = baseDamage;
   }

   public UnitHealth()
   {
      _currentHealth = 100.0f;
      _currentMana = 100.0f;
      _maxHealth = 100.0f;
      _maxMana = 100.0f;
      _baseDamage = 10.0f;
   }

   // Healing methods
   public void DamageUnit(float damage)
   {
      CurrentHealth -= damage;
      if (CurrentHealth - damage <= 0)
      {
         CurrentHealth = 0;
      }
   }

   public void HealUnit(float healAmount)
   {
      if (CurrentHealth < MaxHealth)
      {
         if (CurrentHealth + healAmount > MaxHealth)
         {
            CurrentHealth = MaxHealth;
         }
         else
         {
            CurrentHealth += healAmount;
         }
      }
   }

   public bool IsDead()
   {
      if (CurrentHealth == 0)
      {
         return true;
      }

      return false;

   }
   public float BaseDamage
   {
      get { return _baseDamage; }
      private set { _baseDamage = value; }
   }

   public float HealthRechargeRate { get; set; } = 1.75f;
   public float CurrentHealth
   {
      get {return _currentHealth; }
      set{_currentHealth = value;} 
   }


   public float ManaRechargeRate { get; set; } = 2.25f;
   public float CurrentMana
   {
      get { return _currentMana; }
      set { _currentMana = value; }
   }

   public float MaxHealth
   {
      get { return _maxHealth; }
      set { _maxHealth = value; }
   }

   public float MaxMana
   {
      get { return _maxMana; }
      set { _maxMana = value; }
   }
   
   // Mana methods
   


}
