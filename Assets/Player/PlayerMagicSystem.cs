using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMagicSystem : MonoBehaviour
{

    // Start is called before the first frame update
    // inputs
    private bool castSpell;
    private bool spellExist;
    private bool fireElementSelected;
    private bool waterElementSelected;
    private bool spellBuild;
    // Spell Icons Sprites
    [SerializeField] private Image firstSpellIcon;
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
                Debug.Log("New queue: " + selectedElements.ToArray()[0] + selectedElements.ToArray()[1] + selectedElements.ToArray()[2]);
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
                Debug.Log("New queue: " + selectedElements.ToArray()[0] + selectedElements.ToArray()[1] + selectedElements.ToArray()[2]);
            }
            fireElementSelected = false;
        }
    }

    // casting the spell by instantiating it!
    private void CastSpell()
    {
        try
        {
            if (castSpell)
            {
                Instantiate(currentSpell, castPoint.position, castPoint.rotation*Quaternion.Euler(0,90,0));
                currentSpell.DebugPrint();
            }
        }
        catch (ArgumentException ex)
        {
            Debug.Log("Can't cast non existent spell");
            ex.GetBaseException();
        }
        castSpell = false;
    }
    
    // building spell by checking selected elements and corresponding spell
    private void SpellBuild()
    {
        if (spellBuild)
        {
            try
            {
                CheckSpell();
                if (spellExist)
                {
                    Debug.Log("Following Spell has been built: " + currentSpell.SpellToCast.SpellName);
                    firstSpellIcon.sprite = currentSpell.SpellToCast.SpellIcon;
                    firstSpellIcon.enabled = true;
                }
                else
                {
                    firstSpellIcon.enabled = false;
                    Debug.Log("Spell not found!");
                }
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("Spell not found!");
                firstSpellIcon.enabled = false;
                ex.GetBaseException();
            }
        }
        spellBuild = false;
    }

    // check which corresponding spell is built with current selected elements
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
                    break;
                }
                currentSpell = null;
                spellExist = false;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                currentSpell = null;
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

    private void Start()
    {
        firstSpellIcon.enabled = false;
    }
}

