using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagicSystem : MonoBehaviour
{

    // Start is called before the first frame update
    // inputs
    private bool castSpell;
    private bool spellExist;
    private bool fireElementSelected;
    private bool waterElementSelected;
    private bool spellBuild;

    // cast point
    [SerializeField] private Transform castPoint;
    [SerializeField] private List<Spell> allSpells;
    private Queue<ElementEnum> selectedElements = new Queue<ElementEnum>();

    // spell to cast {to change later for dynamic by merging}
    private Spell currentSpell;


    // check spell build input
    public void OnSpellBuild(InputAction.CallbackContext context)
    {
        spellBuild = context.action.IsPressed();
    }
    public void OnSelectingFireElement(InputAction.CallbackContext context)
    {
        fireElementSelected = context.action.IsPressed();
    }

    public void OnSelectingWaterElement(InputAction.CallbackContext context)
    {
        waterElementSelected = context.action.IsPressed();
    }
    
// check if cast spell input is triggered
    public void OnCastingSpell(InputAction.CallbackContext context)
    {
        castSpell = context.action.IsPressed();
    }
    private void CheckSelectedElements()
    {
        WaterElementSelection();
        FireElementSelection();
    }
    private void WaterElementSelection()
    {
        if (selectedElements.Count < 3)
        {
            if (waterElementSelected)
            {
                selectedElements.Enqueue(ElementEnum.WATER);
            }
            waterElementSelected = false;
        }
        else
        {
            if (waterElementSelected)
            {
                selectedElements.Dequeue();
                selectedElements.Enqueue(ElementEnum.WATER);
            }
            waterElementSelected = false;
        }
    }
    private void FireElementSelection()
    {
        if (selectedElements.Count < 3)
        {
            if (fireElementSelected)
            {
                selectedElements.Enqueue(ElementEnum.FIRE);
            }
            fireElementSelected = false;
        }
        else
        {
            if (fireElementSelected)
            {
                selectedElements.Dequeue();
                selectedElements.Enqueue(ElementEnum.FIRE);
            }
            fireElementSelected = false;
        }
    }

    // casting the spell by instantiating it!
    private void CastSpell()
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
    
    // building spell by checking selected elements and corresponding spell
    private void SpellBuild()
    {
        if (spellBuild)
        {
            try
            {
                CheckSpell();
                Debug.Log("Following Spell has been built: " + currentSpell.SpellToCast.SpellName);
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("Spell not found!");
                ex.GetBaseException();
            }
        }
        spellBuild = false;
    }

    // check which corresponding spell is built with current selected elements
    // todo: fix sometimes spell doesnt find it even though combination is correct (problem most likely from queue of selected elements)
    private void CheckSpell()
    {
        foreach (Spell spell in allSpells)
        {
            try
            {
                if (spell.SpellToCast.Elements.ToArray()[0] == selectedElements.ToArray()[0] && 
                    spell.SpellToCast.Elements.ToArray()[1] == selectedElements.ToArray()[1] && 
                    spell.SpellToCast.Elements.ToArray()[2] == selectedElements.ToArray()[2])
                {
                    currentSpell = spell;
                    spellExist = true;
                }
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                spellExist = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckSelectedElements();
        CastSpell();
        SpellBuild();
    }
}

