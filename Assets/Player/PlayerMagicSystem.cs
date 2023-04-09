using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagicSystem : MonoBehaviour
{
    
    // Start is called before the first frame update
    private bool castSpell;
    [SerializeField] private Transform castPoint;
    [SerializeField] private Spell spell;
    private float currentCastTimer;


    public void OnCastingSpell(InputAction.CallbackContext context)
    {
        castSpell = context.action.IsPressed();
    }

    public void CastSpell()
    {
        if (castSpell)
        {
            Debug.Log("Spell casted is: " + spell.SpellToCast.SpellName ); 
            Instantiate(spell, castPoint.position,castPoint.rotation);

        }

        castSpell = false;

    }

    // Update is called once per frame
    void Update()
    {
        CastSpell();
    }
}
