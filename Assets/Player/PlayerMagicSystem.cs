using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMagicSystem : MonoBehaviour
{

    // Elements Object visualisation
    [SerializeField] private GameObject fireElementVisual;
    [SerializeField] private GameObject waterElementVisual;
    // inputs
    // cast spell boolean
    private bool castSpell;
    private bool spellExist;
    // elements selected
    private bool fireElementSelected;
    private bool waterElementSelected;
    private bool earthElementSelected;
    private bool windElementSelected;
    private bool lightningElementSelected;
    private bool voidElementSelected;
    private bool venomElementSelected;
    // spell build boolean
    private bool spellBuild;
    // Spell Icons Sprites
    [SerializeField] private Image firstSpellIcon;
    //[SerializeField] private Image secondSpellIcon;
    // cast point
    [SerializeField] private Transform castPoint;
    // all spells
    [SerializeField] private List<Spell> allSpells;
    // selected elements by the player
    private Queue<ElementEnum> selectedElements = new Queue<ElementEnum>();
    // spell to cast {to change later for dynamic by merging}
    private Spell currentSpell;


    // check spell build input
    public void OnSpellBuild(InputAction.CallbackContext context)
    {
        spellBuild = context.action.IsPressed();
    }
    
    // selecting elements
    public void OnSelectingFireElement(InputAction.CallbackContext context)
    {
        fireElementSelected = context.action.IsPressed();
    }
    public void OnSelectingWaterElement(InputAction.CallbackContext context)
    {
        waterElementSelected = context.action.IsPressed();
    }
    public void OnSelectingEarthElement(InputAction.CallbackContext context)
    {
        earthElementSelected = context.action.IsPressed();
    }
    public void OnSelectingWindElement(InputAction.CallbackContext context)
    {
        windElementSelected = context.action.IsPressed();
    }
    public void OnSelectingLightningElement(InputAction.CallbackContext context)
    {
        lightningElementSelected = context.action.IsPressed();
    }
    public void OnSelectingVoidElement(InputAction.CallbackContext context)
    {
        voidElementSelected = context.action.IsPressed();
    }
    public void OnSelectingVenomElement(InputAction.CallbackContext context)
    {
        venomElementSelected = context.action.IsPressed();
    }
    
// check if cast spell input is triggered
    public void OnCastingSpell(InputAction.CallbackContext context)
    {
        castSpell = context.action.IsPressed();
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

    private void EarthElementSelection()
    {
        if (selectedElements.Count < 3)
        {
            if (earthElementSelected)
            {
                selectedElements.Enqueue(ElementEnum.EARTH);
            }

            earthElementSelected = false;
        }
        else
        {
            if (earthElementSelected)
            {
                selectedElements.Dequeue();
                selectedElements.Enqueue(ElementEnum.EARTH);
                Debug.Log("New queue: " + selectedElements.ToArray()[0] + selectedElements.ToArray()[1] + selectedElements.ToArray()[2]);
            }

            earthElementSelected = false;
        }
    }

    private void WindElementSelection()
    {
        if (selectedElements.Count < 3)
        {
            if (windElementSelected)
            {
                selectedElements.Enqueue(ElementEnum.WIND);
            }

            windElementSelected = false;
        }
        else
        {
            if (windElementSelected)
            {
                selectedElements.Dequeue();
                selectedElements.Enqueue(ElementEnum.WIND);
                Debug.Log("New queue: " + selectedElements.ToArray()[0] + selectedElements.ToArray()[1] + selectedElements.ToArray()[2]);
            }

            windElementSelected = false;
        }
    }

    private void LightningElementSelection()
    {
        if (selectedElements.Count < 3)
        {
            if (lightningElementSelected)
            {
                selectedElements.Enqueue(ElementEnum.LIGHTNING);
            }

            lightningElementSelected = false;
        }
        else
        {
            if (lightningElementSelected)
            {
                selectedElements.Dequeue();
                selectedElements.Enqueue(ElementEnum.LIGHTNING);
                Debug.Log("New queue: " + selectedElements.ToArray()[0] + selectedElements.ToArray()[1] + selectedElements.ToArray()[2]);
            }

            lightningElementSelected = false;
        }
    }

    private void VoidElementSelection()
    {
        if (selectedElements.Count < 3)
        {
            if (voidElementSelected)
            {
                selectedElements.Enqueue(ElementEnum.VOID);
            }

            voidElementSelected = false;
        }
        else
        {
            if (voidElementSelected)
            {
                selectedElements.Dequeue();
                selectedElements.Enqueue(ElementEnum.VOID);
                Debug.Log("New queue: " + selectedElements.ToArray()[0] + selectedElements.ToArray()[1] + selectedElements.ToArray()[2]);
            }

            voidElementSelected = false;
        }
    }

    private void VenomElementSelection()
    {
        if (selectedElements.Count < 3)
        {
            if (venomElementSelected)
            {
                selectedElements.Enqueue(ElementEnum.VENOM);
            }

            venomElementSelected = false;
        }
        else
        {
            if (venomElementSelected)
            {
                selectedElements.Dequeue();
                selectedElements.Enqueue(ElementEnum.VENOM);
                Debug.Log("New queue: " + selectedElements.ToArray()[0] + selectedElements.ToArray()[1] + selectedElements.ToArray()[2]);
            }

            venomElementSelected = false;
        }
    }
    private void CheckSelectedElements()
    {
        WaterElementSelection();
        FireElementSelection();
        EarthElementSelection();
        WindElementSelection();
        LightningElementSelection();
        VoidElementSelection();
        VenomElementSelection();
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

    private void ElementsVisualRotation()
    {
        if (selectedElements.Contains(ElementEnum.FIRE))
        {
            fireElementVisual.SetActive(true);
            fireElementVisual.transform.RotateAround(transform.position, new Vector3(0,1,0), 150*Time.deltaTime);
        }
        else
        {
            fireElementVisual.SetActive(false);
        }

        if (selectedElements.Contains(ElementEnum.WATER))
        {
            waterElementVisual.SetActive(true);
            waterElementVisual.transform.RotateAround(transform.position, new Vector3(0,1,0), 150*Time.deltaTime);
        }
        else
        {
            waterElementVisual.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckSelectedElements();
        CastSpell();
        SpellBuild();
        ElementsVisualRotation();
        
    }

    private void Start()
    {
        firstSpellIcon.enabled = false;
        fireElementVisual.SetActive(false);
        waterElementVisual.SetActive(false);
        //secondSpellIcon.enabled = false;
    }
}

