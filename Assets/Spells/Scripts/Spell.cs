using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    private SphereCollider myCollider;
    private Rigidbody body;
    public SpellScriptableObject SpellToCast;

    private void Update()
    {
        transform.Translate(Vector3.forward * (SpellToCast.Velocity * Time.deltaTime));
        Destroy(gameObject,SpellToCast.LifeTime);
    }
    
    
    // what happens to the spell object when it collides with another
    private void OnTriggerEnter(Collider other)
    {
        // apply spell effect to whatever we hit
        // apply vfx sfx etc..
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy healthComponent = other.GetComponent<Enemy>();
            healthComponent.UnitHealth.DamageUnit(SpellToCast.Damage);
            Debug.Log("Enemy has been hit! Current Health: " + healthComponent.UnitHealth.CurrentHealth);
            if (healthComponent.UnitHealth.IsDead())
            {
                Debug.Log("Enemy is dead!");
                Destroy(other.gameObject);
            }

        }
        
    }

    private void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = SpellToCast.SpellRadius;
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
        
    }
}
