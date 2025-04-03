using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float attackRange = 2f;
    public int damage = 50;
    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Player attacked!");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, enemyLayer))
        {
            Debug.Log("Hit: " + hit.collider.name);

            Zombiehealth enemy = hit.collider.GetComponent<Zombiehealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

}
