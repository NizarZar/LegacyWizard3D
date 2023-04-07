using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]
public class SpellScriptableObject : ScriptableObject
{

    public float ManaCost { get; set; }
    public float Damage { get; set; }
    public float HealthCost { get; set; } = 0;
    public float LifeTime { get; set; } = 10;
    public float Velocity { get; set; }
    public float CastCooldown { get; set; }
    public string Name { get; set; }
    public float SpellRadius { get; set; } = 10.0f;

    // Magic Elements

    // Icon






}