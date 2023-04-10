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
    private Spell spell;
    private float currentCastTimer;


// check if cast spell input is triggered
    public void OnCastingSpell(InputAction.CallbackContext context)
    {
        castSpell = context.action.IsPressed();
    }

    // casting the spell by instantiating it!
    public void CastSpell()
    {
        if (castSpell)
        {
            Instantiate(spell, castPoint.position, castPoint.rotation);
        }
        castSpell = false;
    }

    // Update is called once per frame
    void Update()
    {
        CastSpell();
        CheckSpell();
    }

    private void Start()
    {
        
    }

    private void CheckSpell()
    {
        foreach (string element in selectedElements)
        {
            foreach (Spell sSpell in allSpells)
            {
                if (sSpell.SpellToCast.Elements.Contains(element))
                {
                    spell = sSpell;
                }
            }
        }
    }
}

