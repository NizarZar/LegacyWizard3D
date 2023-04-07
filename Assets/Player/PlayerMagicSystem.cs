using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagicSystem : MonoBehaviour
{
    
    // Start is called before the first frame update
    private bool castSpell;
    [SerializeField] private Transform castPoint;
    [SerializeField] private Spell spellToCast;
    private float currentCastTimer;


    public void OnCastingSpell(InputAction.CallbackContext context)
    {
        castSpell = context.action.IsPressed();
    }

    public void CastSpell()
    {
        currentCastTimer += Time.deltaTime;
        if (castSpell && currentCastTimer >= 0.25f)
        {
            currentCastTimer = 0;
            Debug.Log("Spell casted");
            Instantiate(spellToCast, castPoint.position, castPoint.rotation);


        }

        

    }

    // Update is called once per frame
    void Update()
    {
        CastSpell();
    }
}
