using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]
public class SpellScriptableObject : ScriptableObject
{
    
    // class for spell attributes

    [SerializeField] private float manaCost;
    [SerializeField] private float damage;
    [SerializeField] private float healthCost;
    [SerializeField] private float lifeTime;
    [SerializeField] private float velocity;
    [SerializeField] private float cooldown;
    [SerializeField] private string spellName;
    
    public float ManaCost
    {
        get { return manaCost; }
        set { manaCost = value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float HealthCost
    {
        get { return healthCost; }
        set { healthCost = value; }
    }

    public float LifeTime
    {
        get { return lifeTime; }
        set { lifeTime = value; }
    }

    public float Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public float Cooldown
    {
        get { return cooldown; }
        set { cooldown = value; }
    }

    public string SpellName
    {
        get { return spellName; }
        set { spellName = value; }
    }
    public float SpellRadius { get; set; } = .5f;

    // Magic Elements

    // Icon






}