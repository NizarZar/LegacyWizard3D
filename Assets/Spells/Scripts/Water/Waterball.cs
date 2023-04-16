using UnityEngine;

namespace Spells.Scripts
{
    public class Waterball : Spell
    {
        public override void DebugPrint()
        {
            Debug.Log("This is a " + SpellToCast.SpellName);
        }
    }
}