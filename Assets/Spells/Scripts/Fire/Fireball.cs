using UnityEngine;

namespace Spells.Scripts
{
    public class Fireball : Spell
    {
        public override void DebugPrint()
        {
            Debug.Log("This is a " + SpellToCast.SpellName);
        }
    }
}