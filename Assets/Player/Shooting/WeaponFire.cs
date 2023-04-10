using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponFire : MonoBehaviour
{
    private bool isFiring;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private Transform castPoint;

    public void OnFireButton(InputAction.CallbackContext context)
    {
        isFiring = context.action.IsPressed();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Rigidbody bulletShot = Instantiate(bullet, castPoint.position, Quaternion.identity);
            Vector3 direction;
            if (Physics.Raycast(ray, out RaycastHit hit, 30f))
            {
                direction = hit.point - castPoint.position;
                bulletShot.GetComponent<Rigidbody>().AddForce(direction*2.5f,ForceMode.Impulse);
            }
        }
        isFiring = false;
    }

    
    // not working it needs to be fixed
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.UnitHealth.DamageUnit(GameManager.gameManager.playerStats.BaseDamage);
            Debug.Log("Enemy has been hit by a bullet!");
            if (enemy.UnitHealth.IsDead())
            {
                Debug.Log("Enemy is dead!");
                Destroy(other.gameObject);
            }
        }
    }
    
}
