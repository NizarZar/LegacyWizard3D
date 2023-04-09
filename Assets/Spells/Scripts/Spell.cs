using System;
using System.Security.Cryptography;
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
        transform.Translate(transform.forward * SpellToCast.Velocity * Time.deltaTime);
        Destroy(gameObject,SpellToCast.LifeTime);
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        // apply spell effect to whatever we hit
        // apply vfx sfx etc..
        
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
