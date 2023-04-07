using System;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class Spell : MonoBehaviour
{
    private SphereCollider myCollider;
    private Rigidbody body;
    public SpellScriptableObject SpellToCast;

    private void Update()
    {
        if (SpellToCast.Velocity > 0)
        {
            transform.Translate(transform.forward * SpellToCast.Velocity * Time.deltaTime);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        // apply spell effect to whatever we hit
        // apply vfx sfx etc..
        Destroy(gameObject);
    }

    private void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = SpellToCast.SpellRadius;
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
        
        Destroy(gameObject,SpellToCast.LifeTime);
    }
}
