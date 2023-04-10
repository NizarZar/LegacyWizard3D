using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagicSystem : MonoBehaviour
{

    // Start is called before the first frame update
    private bool castSpell;

    // cast point
    [SerializeField] private Transform castPoint;
    [SerializeField] private List<Spell> allSpells;
    [SerializeField] List<string> selectedElements;

    // spell to cast {to change later for dynamic by merging}
    private Spell currentSpell;
    private float currentCastTimer;
    private bool spellExist;

// check if cast spell input is triggered
    public void OnCastingSpell(InputAction.CallbackContext context)
    {
        castSpell = context.action.IsPressed();
    }

    // casting the spell by instantiating it!
    public void CastSpell()
    {
        if (spellExist)
        {
            if (castSpell)
            {
                try
                { Instantiate(currentSpell, castPoint.position, castPoint.rotation); }
                catch (Exception ex)
                {ex.GetBaseException(); }
            }
            castSpell = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CastSpell();
        CheckSpell();
    }

    private void CheckSpell()
    {
        
        foreach (Spell spell in allSpells)
        {
            try
            {
                if (spell.SpellToCast.Elements.Contains(selectedElements[0]) &&
                    spell.SpellToCast.Elements.Contains(selectedElements[1]) &&
                    spell.SpellToCast.Elements.Contains(selectedElements[2]))
                {
                    currentSpell = spell;
                    spellExist = true;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ex.GetBaseException();
                spellExist = false;
                Debug.Log("Spell not found!");
            }
            
        }
        
    }
}

